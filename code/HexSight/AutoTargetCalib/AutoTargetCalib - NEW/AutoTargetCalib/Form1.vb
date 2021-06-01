Imports HSCLASSLIBRARYLib, HSACQUISITIONDEVICELib, HSLOCATORLib, HSPROCESSMANAGERLib, HSDISPLAYLib
#Disable Warning

Public Class Form1
    ' _________________________________________________________________________________________
    ' GENERAL MAIN PROCESSES
    Public Shared lManager As HSProcessManager
    Public Shared AcquisitionDevice As HSAcquisitionDevice
    Public Shared lLocator As HSLocator

    ' LOCATOR MODELS AND HEXSIGHT CONFIGURATION
    Const Locator_Models = "small_and_calib_targets_models.hdb"
    ' Const HexSight_Configuration = "VisionConfiguration_NoProcessing_Home.cfg"
    Const HexSight_Configuration = "VisionConfiguration_NoProcessing.cfg"

    ' RAPID PARAMS

    ' Time the controller waits before moving the tool to the next pose
    Const PAUSETIME = 12.6
    Dim INIT_DELAY = 3

    ' STARTING POSITION OF THE CALIBRATION PROCESS
    Dim STARTX = -1301.97
    Dim STARTY = -178.42

    ' FINAL POSITION OF THE CALIBRATION PROCESS
    Dim ENDX = -1782.4
    Dim ENDY = -528.08

    ' HOW MANY COLUMNS AND ROWS THE GRID PATTERN MUST HAVE (THE FIRST ROW AND COLUMN IS COUNTED IN THIS NUMBER)
    ' Dim DESIRED_ROWS = 3
    ' Dim DESIRED_COLUMNS = 2

    Dim DESIRED_ROWS = 4
    Dim DESIRED_COLUMNS = 4

    ' REMEMBER THAT THE NEXT POINT IS ON THE SAME X COORDINATE BUT INCREASING Y
    ' IF YOU HAVE 2 ROWS AND 2 COLUMNS POINT INDEXES IS LIKE THIS:
    ' 1) X = 0       , Y = 0
    ' 2) X = 0       , Y = FINAL Y
    ' 3) X = FINAL X , Y = 0
    ' 4) X = FINAL X,  Y = FINAL Y
    ' ShowRapidCoordinates helps you in this reasoning

    ' HORIZONTAL AND VERTICAL DISPLACEMENT OF POSITIONS IN THE GRID
    Dim DX = (ENDX - STARTX) / (DESIRED_ROWS - 1)
    Dim DY = (ENDY - STARTY) / (DESIRED_COLUMNS - 1)

    Dim CALIBRATION_POINTS = DESIRED_ROWS * DESIRED_COLUMNS

    Dim Dot_Pixel_Coordinates = New Double(CALIBRATION_POINTS - 1, 1) {}
    Dim Dot_World_Coordinates = New Double(CALIBRATION_POINTS - 1, 1) {}
    ' _________________________________________________________________________________________

    ' _________________________________________________________________________________________
    ' Useful variables used in the script
    Private sender As Object
    Private e As EventArgs

    ' Used to identify which image i'm processing [from 0..3] since images are 4
    Dim Dot_Index As Integer = 0
    Dim Image_Location As Integer
    ' Colors shorter name used in the HMI
    Dim green = Color.GreenYellow
    Dim red = Color.IndianRed
    Dim yellow = Color.Yellow
    Dim grey = SystemColors.Control
    Dim white = SystemColors.Window
    ' _________________________________________________________________________________________

    ' Prefer using Automatic Calibration Method instead of Perspective one
    Dim Prefer_Automatic_Cal = True
    ' How Many shot to take before taking average value
    Dim Distortion_Average_Shots = 5
    ' Boolean flag to understand which model to used based on radio button selection
    Dim Use_Distorsion_Model = False
    ' Boolean flag to understand if configuration has been loaded successfully
    Dim Configuration_Loaded_Success = False
    Dim Calibration_Loaded_Success = False
    ' Max World Error of Perspective Calibration default
    Dim Max_World_Err_Perspective = 1000
    ' Max World Error of Automatic Calibration default
    Dim Max_World_Err_Automatic = 1000
    ' Variable to detect if first time ButtonShot is clicked
    Dim First_Shot_Button As Boolean = True
    ' This variable tells when the tool is ready for the shot
    Dim PLC_OK = False
    ' How many shot to take before taking average
    Const Shot2TakeBeforeAverage = 3

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo errHandler

        Debug.WriteLine(vbCr + "_________Form1_Load")

        lManager = HSApplicationControl.ProcessManager

        ' CHANGE HERE PATH
        Configuration_Loaded_Success = lManager.LoadConfiguration(0, "C:\Users\mikel\source\repos\Config_Files\Configuration\" + HexSight_Configuration)

        If Configuration_Loaded_Success Then

            lLocator = lManager.Process("HSLocator")
            AcquisitionDevice = lManager.Process("HSAcquisition")
            AcquisitionDevice.ConfigurationDefault = "Mako503B"

            '' DISABLE IF REAL CAMERA
            'AcquisitionDevice.LoadEmulationDatabase(AcquisitionDevice.ConfigurationDefault, "C:\Users\mikel\source\repos\Config_Files\Emulation\12_calibration_positions.hdb")
            '' Start With the Bottom Right Image so when you can execute you switch for bottom left (1)
            'AcquisitionDevice.EmulationNextImageIndex(AcquisitionDevice.ConfigurationDefault) = 0
            'AcquisitionDevice.InputDevice(AcquisitionDevice.ConfigurationDefault) = 1

            ' Setup The Display
            HSDisplay.set_ImageDatabase(0, HSApplicationControl.Database.Handle)
            HSDisplay.set_ImageViewName(0, AcquisitionDevice.OutputView())
            HSDisplay.set_ImageName(0, AcquisitionDevice.OutputImage())
            HSDisplay.Zoom = -1

            ' In the Real Time Case You Can Do Execute Acquisition
            AcquisitionDevice.Execute()
            HSDisplay.RefreshDisplay()

            TextBoxLoadedConfig.BackColor = green
            TextBoxLoadedConfig.Text = "OK"

            TextBox_GigE.BackColor = green
            TextBox_GigE.Text = "OK"
            LabelAcquisitionState.Text = "Ready"
            LabelToolState.Text = "Pending"

            ' Camera Check Connection
            If Not Check_GigE_Input() Then
                TextBoxLoadedConfig.BackColor = red
                TextBoxLoadedConfig.Text = "NO"
                MsgBox("Failed to Connect to GigE Camera, check connection or remove this check", MsgBoxStyle.Critical)
                Application.Exit()
            End If

        End If

        Application.DoEvents()
        FreeMemory()
        ' CHANGE HERE PATH

        If Not lLocator.LoadModelDatabase("C:\Users\mikel\source\repos\Config_Files\Models\" + Locator_Models) Then
            Print("MODEL HDB FAILED")
        End If

        ' 
        lLocator.ModelEnabled(0) = True ' target model
        lLocator.ModelEnabled(1) = False ' small model

        ' Disable all controls the user should not interact with at the beginning
        Initialize_Control_State()

        ShowRapidCoordinates()
        Exit Sub

errHandler:
        TextBoxLoadedConfig.BackColor = red
        MsgBox("Failed To Load Emulated_VisionConfiguration.cfg", MsgBoxStyle.Critical)
        Application.Exit()
    End Sub

    Private Sub Initialize_Control_State()

        ' Disable all controls the user should not interact with at the beginning
        ButtonCalibrate.Enabled = False
        ' ButtonPLCOK.Enabled = False
        ButtonWorld2Image.Enabled = False
        ButtonImage2World.Enabled = False

        TextBoxWorldX.ReadOnly = True
        TextBoxWorldY.ReadOnly = True

        TextBoxImageX.ReadOnly = True
        TextBoxImageY.ReadOnly = True

        TextBoxImageX.BorderStyle = BorderStyle.None
        TextBoxImageY.BorderStyle = BorderStyle.None

        TextBoxWorldX.BorderStyle = BorderStyle.None
        TextBoxWorldY.BorderStyle = BorderStyle.None

        TextBoxImageX.Cursor = Cursors.No
        TextBoxImageY.Cursor = Cursors.No

        TextBoxWorldX.Cursor = Cursors.No
        TextBoxWorldY.Cursor = Cursors.No

        TextBoxWorldX.Enabled = False
        TextBoxWorldY.Enabled = False
        TextBoxImageX.Enabled = False
        TextBoxImageY.Enabled = False

        TextBoxAVGPixelErr.Text = "n/a"
        TextBoxAVGWorldErr.Text = "n/a"
        TextBoxMaxPixelErr.Text = "n/a"
        TextBoxMaxWorldErr.Text = "n/a"
    End Sub

    Private Function FreeMemory() As Object

        ' To ensure releasing of local references to Hexsight ActiveX objects 
        GC.Collect()
        GC.WaitForPendingFinalizers()
        Return Nothing ' same as lAcquisition = Nothing

    End Function

    Private Function Check_GigE_Input()

        Debug.WriteLine("_________Check_GigE_Input")

        ' *************************************************************************************
        ' Sub Description : 
        ' Check if a Check_GigE_Input() is available and try to set it as default input device
        ' *************************************************************************************

        'Current Input device id = 3

        'Input device name : Mako G - 503B (6644) 50-0536935814
        'Input device name : Mako G - 503C (6645) 50-0536876892

        'Input device available :  True
        'Input device description : GigE Vision Device

        TextBox_GigE.Visible = True
        LabelGigECamera.Visible = True
        TextBox_GigE.BackColor = red
        TextBox_GigE.Text = "-1"

        Debug.WriteLine("Check_GigE_Input : InputDeviceCount = " + AcquisitionDevice.InputDeviceCount().ToString)

        ' For every available device 
        For count = 0 To AcquisitionDevice.InputDeviceCount() - 1

            Debug.WriteLine("Check_GigE_Input : InputDeviceName = " + AcquisitionDevice.InputDeviceName(count).ToString + ", " + AcquisitionDevice.InputDeviceDescription(count).ToString)

            ' Look for a GigE Vision Device
            If String.Equals("GigE Vision Device", AcquisitionDevice.InputDeviceDescription(count).ToString) Then

                ' If there's one put yellow
                TextBox_GigE.BackColor = yellow

                ' If it's available put green and OK
                If AcquisitionDevice.InputDeviceAvailable(count) Then
                    TextBox_GigE.BackColor = green
                    TextBox_GigE.Text = "OK"

                    Debug.WriteLine("Check_GigE_Input : Found = " + AcquisitionDevice.InputDeviceName(count).ToString)

                    Return True

                End If
            End If
        Next

        ' Else Return false
        Return False
    End Function

    Private Sub Wait(ByVal seconds As Integer)
        ' A simple Wait Function with light weight on the CPU
        For i As Integer = 0 To seconds * 100
            Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Private Sub ButtonAcquire_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click

        ' Subs to restore all buttons border state and change current pushed
        RestoreAllButtons()
        PushedButtonBorder(ButtonStart)
        ButtonPLCOK.Enabled = True
        LabelTotalPoints.Text = "\" + CALIBRATION_POINTS.ToString

        Cursor = Cursors.AppStarting
        ButtonTestCalibration.Enabled = False
        ButtonLocate.Enabled = False
        HSDisplay.RemoveAllMarker()

        ' Delay to let tool and camera synchronize
        ' Wait(5)

        ' Dot_Index are from 0 
        For Dot_Index = 0 To CALIBRATION_POINTS - 1

            LabelTimer.Text = "0"
            ' Let the timer begin
            Timer1.Start()

            LabelToolState.Text = "Moving"
            LabelAcquisitionState.Text = "Ready"
            LabelDotCount.Text = (Dot_Index + 1).ToString
            Wait(0.1)

            ' Scan a new coordinate

            Print(vbCr + "--------------- TOOL MOVING THE TARGET TO POS " + (1 + Dot_Index).ToString + " ---------------" + vbCr)

            ' Restore PLC status from previous acquisition
            PLC_OK = False
            While Not PLC_OK
                Wait(0.8)
                Print("WAITING OK FROM PLC")

                ' ACTIVATE THIS FOR TIMER SYNCHRO

                'If (Double.Parse(LabelTimer.Text) > INIT_DELAY) Then
                '    ' The very first time the camera will wate 5s then 15s
                '    ' this is done to synchronize camera and tool
                '    ' the user should first start abb script and when the tool is at position 1, start the hexsight immediately
                '    ' so hexsight will wait 5 seconds, then shot and then wait 15s
                '    PLC_OK = True
                '    INIT_DELAY = PAUSETIME
                'End If

                ' Application.DoEvents()

            End While
            LabelToolState.Text = "Stop"


            ' Performing 3 shots to take average
            For Shot_index = 1 To Shot2TakeBeforeAverage

                LabelAcquisitionState.Text = "Busy"
                ' Get a new frame from the camera and scan coordinates
                AcquisitionDevice.Execute()
                lLocator.Execute()
                Wait(0.5)

                If lLocator.InstanceCount > 0 Then

                    ' accumulate X
                    Dot_Pixel_Coordinates(Dot_Index, 0) += lLocator.InstanceTranslationX(0)
                    ' accumulate Y
                    Dot_Pixel_Coordinates(Dot_Index, 1) += lLocator.InstanceTranslationY(0)

                    HSDisplay.AddPointMarker("", lLocator.InstanceTranslationX(0), lLocator.InstanceTranslationY(0), False)
                    HSDisplay.set_MarkerColor("", hsColor.hsMagenta)
                    HSDisplay.set_MarkerDisplayName("", param0:=True) ' True if name is visibles
                    Wait(0.1)

                Else
                    Print("NO MATCH")
                    If Shot_index > 0 Then
                        Shot_index -= 1
                    End If
                End If

                HSDisplay.Refresh()
                Wait(0.2)

            Next

            LabelAcquisitionState.Text = "Ready"
            Wait(0.1)
            Print("Scanning Completed, Taking Average of Dot N." + (1 + Dot_Index).ToString)

            ' average X
            Dot_Pixel_Coordinates(Dot_Index, 0) /= Shot2TakeBeforeAverage
            ' average Y
            Dot_Pixel_Coordinates(Dot_Index, 1) /= Shot2TakeBeforeAverage

            ' Check if robot hasnt moved

            If Dot_Index > 0 Then
                If Math.Abs(Dot_Pixel_Coordinates(Dot_Index, 0) - Dot_Pixel_Coordinates(Dot_Index - 1, 0)) < 10 And
                Math.Abs(Dot_Pixel_Coordinates(Dot_Index, 1) - Dot_Pixel_Coordinates(Dot_Index - 1, 1)) < 10 Then

                    Print("Robot Has Moved")
                    ' Robot Hasnt Moved, repeat this capture

                    For column = 0 To Dot_Pixel_Coordinates.GetUpperBound(1)
                        Dot_Pixel_Coordinates(Dot_Index, column) = 0.0
                    Next

                    Dot_Index -= 1
                    HSDisplay.RemoveAllMarker()

                    MsgBox("Robot Has Not Moved", MsgBoxStyle.Exclamation)
                Else
                    ' Valid Acquisition

                    HSDisplay.RemoveMarker("")
                    ' Display all points scanned by now
                    Display_All_Points()
                    HSDisplay.Refresh()

                End If
            End If

            ' Stop timer measuring how many seconds you need to measure
            ' This will be useful when 

            Print(vbCr + Dot_Index.ToString + " Completed in : " + LabelTimer.Text + " seconds" + vbCr)
            Timer1.Stop()

        Next

        Print("COMPLETED")

        LabelToolState.Text = "Completed"
        LabelAcquisitionState.Text = "Completed"
        LabelDotCount.Text = "OK"

        Cursor = Cursors.Default
        LabelTimer.Text = ""
        RestoreAllButtons()

        ' perform calibration
        Application.DoEvents()
        Wait(5)
        ButtonCalibrate_Click(sender, e)

    End Sub

    ' =========================================================================================

    Private Sub Display_All_Current_Locator_Points(color As hsColor)

        ' This sub is used to display all points scanned by locator on the screen
        Dispay_Screen_Point("i", lLocator.InstanceTranslationX(0), lLocator.InstanceTranslationY(0), color)

        '' Displays all the scanned reference point from locator to the screen
        '' with a v name and green color
        'For ref = 0 To lLocator.InstanceReferencePointCount(0) - 1
        '    Dispay_Screen_Point("r" + (ref + 1).ToString, lLocator.InstanceReferencePointPositionX(0, ref), lLocator.InstanceReferencePointPositionY(0, ref), color)
        'Next

    End Sub

    Friend Sub Dispay_Screen_Point(name As String, x As Single, y As Single, color As hsColor)

        ' It Shows the Point with x, y coordinates on the ApplicationDisplay with the choosed Name and Color

        ' False will display in Pixel coordinates
        HSDisplay.AddPointMarker(name, x, y, False)
        HSDisplay.set_MarkerColor(name, color)
        HSDisplay.set_MarkerDisplayName(name, param0:=True) ' True if name is visible

    End Sub

    Private Sub Print(message As String)
        Debug.WriteLine(message)
    End Sub

    Private Sub ButtonCalibrate_Click(sender As Object, e As EventArgs) Handles ButtonCalibrate.Click
        ' Automatic Calibration Method
        Automatic_Calibration()

    End Sub

    Private Sub Automatic_Calibration()

        ButtonCalibrate.Enabled = False
        ButtonPLCOK.Enabled = False


        Cursor = Cursors.AppStarting
        Debug.WriteLine("_________Automatic_Calibration")

        ' Start Populating AcquisitionDevice Parameters
        AcquisitionDevice.CalibrationMethod = hsCalibrationMethod.hsAuto
        AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).UnitsLength = HSCLASSLIBRARYLib.hsUnitsLength.hsMillimeter

        ' Number of pairs of calibration points 
        Print("Calibrating with " + CALIBRATION_POINTS.ToString + " points")

        AcquisitionDevice.CalibrationParameter(0) = CALIBRATION_POINTS

        'Calibrate into a right-handed coordinate system 
        AcquisitionDevice.CalibrationParameter(1) = 0

        ' Index of Insertion 
        Dim scanning_index = 0.0
        Dim insertion_index = 0.0
        Dim iw

        For Dot_Count = 1 To Dot_Pixel_Coordinates.GetUpperBound(0) + 1

            ' Increment of scanning_index 
            scanning_index += 1
            insertion_index = 10 + 4 * (scanning_index - 1)

            ' Read Instance Coordinates
            iw = Instance_World_Coordinate_from_Image_Index(Dot_Count)

            ' New Calibration point 
            ' Pixel Coordinates
            AcquisitionDevice.CalibrationParameter(insertion_index) = Dot_Pixel_Coordinates(Dot_Count - 1, 0)
            AcquisitionDevice.CalibrationParameter(insertion_index + 1) = Dot_Pixel_Coordinates(Dot_Count - 1, 1)
            ' World Coordinates
            AcquisitionDevice.CalibrationParameter(insertion_index + 2) = iw(0, 0)
            AcquisitionDevice.CalibrationParameter(insertion_index + 3) = iw(0, 1)

            Print(vbCr + "World point used : " + Dot_Count.ToString + vbCr +
                  iw(0, 0).ToString + ", " + iw(0, 1).ToString)

            Print(vbCr + "Pixel point used : " + Dot_Count.ToString + vbCr +
                  Dot_Pixel_Coordinates(Dot_Count - 1, 0).ToString + ", " + Dot_Pixel_Coordinates(Dot_Count - 1, 1).ToString)

        Next

        ' Solve the Calibration calling Acquisition Device
        AcquisitionDevice.Execute()

        ' Display Result
        Debug.WriteLine("Validate Calibration : " + (AcquisitionDevice.ValidateCalibration).ToString)
        Debug.WriteLine("Calibration State    : " + (AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).State.ToString))

        If (AcquisitionDevice.ValidateCalibration) Then

            ' Succesful Calibration
            Console.Beep()
            Debug.WriteLine("")
            Debug.WriteLine("================= [ OK ] =========================================")

            TextBoxCalibrationResult.BackColor = green
            TextBoxCalibrationResult.Text = "OK"

            ' MsgBox("Calibration Completed!", vbOKOnly, "Automatic Calibration Outcome")

            Debug.WriteLine("Calibration          : Succesful")

            ' ----------------------------------------------------
            ' Call the Sub Performing the Accuracy Evalutation
            Debug.WriteLine("==================================================================")
            Max_World_Err_Automatic = Get_Calibration_Metrics()
            ' ----------------------------------------------------

            ' Save the Calibration File
            Try
                ' Try to Save the calibration Result Somewhere
                AcquisitionDevice.SaveCalibration(AcquisitionDevice.ConfigurationDefault)
            Catch ex As Exception
            End Try

            ButtonWorld2Image.Enabled = True
            ButtonImage2World.Enabled = True

            TextBoxWorldX.ReadOnly = False
            TextBoxWorldY.ReadOnly = False

            TextBoxImageX.ReadOnly = False
            TextBoxImageY.ReadOnly = False

            TextBoxImageX.BorderStyle = BorderStyle.FixedSingle
            TextBoxImageY.BorderStyle = BorderStyle.FixedSingle

            TextBoxWorldX.BorderStyle = BorderStyle.FixedSingle
            TextBoxWorldY.BorderStyle = BorderStyle.FixedSingle

            TextBoxImageX.Cursor = Cursors.Hand
            TextBoxImageY.Cursor = Cursors.Hand

            TextBoxWorldX.Cursor = Cursors.Hand
            TextBoxWorldY.Cursor = Cursors.Hand

            TextBoxWorldX.Enabled = True
            TextBoxWorldY.Enabled = True
            TextBoxImageX.Enabled = True
            TextBoxImageY.Enabled = True

            TextBoxWorldX.Text = " "
            TextBoxWorldY.Text = " "
            TextBoxImageX.Text = " "
            TextBoxImageY.Text = " "

            LabelAcquisitionState.Text = "Calibrated"


        Else
            ' Failed Calibration
            Debug.WriteLine("Calibration : Failed")
            LabelAcquisitionState.Text = "Failed"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function Instance_World_Coordinate_from_Image_Index(DotCount As Integer)

        Dim roww = Math.Ceiling(DotCount / DESIRED_COLUMNS)
        Dim columnn = DotCount - (roww - 1) * DESIRED_COLUMNS

        For ri = 0 To DESIRED_ROWS - 1
            For ci = 0 To DESIRED_COLUMNS - 1
                ' if this is the row and column you want
                If (ri + 1) = roww And (ci + 1) = columnn Then
                    Return New Double(0, 1) {{STARTX + ri * DX, STARTY + ci * DY}}
                End If
            Next
            ' Print("")
        Next
        ' else return -1 -1 error
        Return New Double(0, 1) {{-1, -1}}
    End Function

    Private Function Get_Calibration_Metrics()

        ' Given a Calibrated AcquisitionDevice
        ' It performs reprojectior error for each available point in pixel_coordinates.
        ' It Also shows on the display the ground truth pixel and the reprojected one

        ' The Idea here is to get the same output performances of DistortionModel:

        ' - Avg Pixel Width, Height
        ' - Avg Image Error
        ' - Maximum Image Error
        ' - Avg World Error
        ' - Maximum World Error

        ' Initialize Metrics
        Dim Avg_Image_Err, Max_Image_Err, Avg_World_Err, Max_World_Err, Metrics(1, 1) As Double
        Avg_Image_Err = Max_Image_Err = Avg_World_Err = Max_World_Err = 0.0

        ' The overall amount of images i have.
        Dim total_images As Short = Dot_Pixel_Coordinates.GetUpperBound(0) + 1
        Print("total_images : " + total_images.ToString)

        ' Getting the hsCalibrationState object to compare in the If statement
        Const hsCalibrationSolveFailed As hsCalibrationState = AcquisitionDevice.Calibration(0).State.hsCalibrationSolveFailed

        ' Check if The Calibration has been Completed Sucessfully
        If Not (AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).State = hsCalibrationSolveFailed) Then

            ' Now Perform Reprojection Error on Each Point and Accumulate Errors and Other Metrics

            ' Initialize Temp Coordinates
            Dim px, py, r(0, 1) As Double

            ' Loop Over The Instance Points
            For Index = 1 To total_images

                ' Display Which point you're Reprojecting
                Debug.WriteLine("")
                Debug.WriteLine("Reprojecting Instance Point N." + Index.ToString)

                ' Getting Pixel and World Coordinates of instance
                px = Dot_Pixel_Coordinates(Index - 1, 0)
                py = Dot_Pixel_Coordinates(Index - 1, 1)
                r = Instance_World_Coordinate_from_Image_Index(Index)

                ' ---------------------------------------------------------------------------------------------------
                ' Get Reprojection Error Metrics for this instance point (px,py,r)
                ' Metrics is a 2x2 Matrix, first row is x,y error on pixel while second row is for world coordinates.
                Metrics = ShowReprojectionErrors(px, py, r(0, 0), r(0, 1))
                Debug.Write("")
                ' ---------------------------------------------------------------------------------------------------

                ' Increment of the Average Errors
                ' Error is calculated as distance between two points with Pitagora.
                Avg_Image_Err += Math.Sqrt(Metrics(0, 0) ^ 2 + Metrics(0, 1) ^ 2)
                Avg_World_Err += Math.Sqrt(Metrics(1, 0) ^ 2 + Metrics(1, 1) ^ 2)

                ' Updating The Max Error on Images and World coordinates

                ' If Current Image Error is Higher Than Max_Image_Err, Update it With the Current Image Error
                If (Math.Sqrt(Metrics(0, 0) ^ 2 + Metrics(0, 1) ^ 2)) > Max_Image_Err Then
                    Max_Image_Err = Math.Sqrt(Metrics(0, 0) ^ 2 + Metrics(0, 1) ^ 2)
                    ' PrintConsole("New Max Error on Pixels. Index " + Index.ToString + " : " + Max_Image_Err.ToString)
                End If

                ' If Current World Error is Higher Than Max_World_Err, Update it With the Current World Error
                If (Math.Sqrt(Metrics(1, 0) ^ 2 + Metrics(1, 1) ^ 2)) > Max_World_Err Then
                    Max_World_Err = Math.Sqrt(Metrics(1, 0) ^ 2 + Metrics(1, 1) ^ 2)
                    'PrintConsole("New Max Error on World. Index " + Index.ToString + " : " + Max_World_Err.ToString)
                    'Console.WriteLine("")
                End If

            Next

            ' Initialize Temp Coordinates
            Dim vx, vy, v(0, 1) As Double

        Else
            ' Exception If Calibration is Not Performed Yet
            Throw New Exception("+++ Calibration Object is Not Calibrated +++")
        End If

        ' Finally obtain avg errors
        ' Average Error is obtained dividing by 12 since i have 1 instance point each shot.

        Avg_World_Err = Math.Abs(Avg_World_Err / (total_images))
        Avg_Image_Err = Math.Abs(Avg_Image_Err / (total_images))

        '==================================================================
        ' Update Group Boxes
        '==================================================================
        ' Display in the Form the Calibration Results

        Debug.WriteLine("")
        Debug.WriteLine("==================================================================")
        Debug.WriteLine("================ Calibration Results =============================")
        Debug.WriteLine("Average Pixel Height = " + Math.Round(AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).AveragePixelHeight, 5).ToString + " pixels")
        Debug.WriteLine("Average Pixel Width  = " + Math.Round(AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).AveragePixelWidth, 5).ToString + " pixels")
        Debug.WriteLine("Average Pixel Size   = " + Math.Round(AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).AveragePixelSize, 5).ToString + " pixels")

        Debug.WriteLine("")

        Debug.WriteLine("Average Image Error  = " + Math.Round(Avg_Image_Err, 5).ToString + " pixels")
        Debug.WriteLine("Max Image Error      = " + Math.Round(Max_Image_Err, 5).ToString + " pixels")

        Debug.Write("")

        Debug.WriteLine("Average World Error  = " + Math.Round(Avg_World_Err, 5).ToString + " mm")
        Debug.WriteLine("Max World Error      = " + Math.Round(Max_World_Err, 5).ToString + " mm")
        Debug.WriteLine("==================================================================")

        Debug.WriteLine("")

        ' Pixel dimensions

        ' World Error
        TextBoxMaxWorldErr.Text = Math.Round(Max_World_Err, 7)
        TextBoxAVGWorldErr.Text = Math.Round(Avg_World_Err, 7)

        TextBoxMaxWorldErr.BackColor = red
        TextBoxAVGWorldErr.BackColor = red
        If Math.Round(Max_World_Err, 5) < 1 Then
            TextBoxMaxWorldErr.BackColor = green
            TextBoxAVGWorldErr.BackColor = green
        End If

        ' Pixel Error
        TextBoxAVGPixelErr.Text = Math.Round(Avg_Image_Err, 7)
        TextBoxMaxPixelErr.Text = Math.Round(Max_Image_Err, 7)

        '==================================================================

        'Load the Accuracy Test Image on the display

        'AcquisitionDevice.LoadEmulationDatabase(AcquisitionDevice.ConfigurationDefault, "C:\Users\mikel\source\repos\Config_Files\Emulation\accuracytest.hdb")
        'AcquisitionDevice.Execute()
        HSDisplay.RemoveAllMarker()
        HSDisplay.RefreshDisplay()

        Wait(2)

        ' Express Coordinates in Pixels
        ' If True Display is modified to look calibrated
        HSDisplay.CalibratedUnitsEnabled = False

        Debug.Write("")
        Debug.WriteLine("Displaying Reprojected Coordinates (red) and Acquired Coordinates (green)")

        ' Now Display all the reprojected Instance Point using WorldToImage
        For index = 1 To Dot_Pixel_Coordinates.GetUpperBound(0) + 1

            ' Obtain the Reprojected Point using WorldToImage function
            Dim temp_r = Instance_World_Coordinate_from_Image_Index(index)
            AcquisitionDevice.WorldToImage(temp_r(0, 0), temp_r(0, 1))

            ' Display the reprojected value VALIDATION
            Display_Screen_Point("V" + index.ToString, temp_r(0, 0), temp_r(0, 1), hsColor.hsMagenta)

            ' Add on the Application Display
            ' Display The Scanned Pixel Coordinate TRUE VALUE
            HSDisplay.AddPointMarker("T" + index.ToString, Dot_Pixel_Coordinates(index - 1, 0), Dot_Pixel_Coordinates(index - 1, 1), False)
            HSDisplay.set_MarkerDisplayName("T" + index.ToString, True)
            HSDisplay.set_MarkerColor("T" + index.ToString, hsColor.hsGreen)

        Next

        ' Refresh the Display to let the appear
        HSDisplay.RefreshDisplay()
        Wait(1)

        Return Max_World_Err

    End Function

    Friend Sub Display_Screen_Point(name As String, x As Single, y As Single, color As hsColor)
        ' It Shows the Point with x, y coordinates on the ApplicationDisplay with the choosed Name and Color

        ' False will display in Pixel coordinates
        HSDisplay.AddPointMarker(name, x, y, False)
        HSDisplay.set_MarkerColor(name, color)
        HSDisplay.set_MarkerDisplayName(name, param0:=True) ' True if name is visible

    End Sub

    Private Function ShowReprojectionErrors(px As Double, py As Double, ByRef wx As Double, ByRef wy As Double)
        '
        ' This sub shows reprojection error using WorldToImage and ImageToWorld sub of HSAcquisitionDevice class
        '
        ' Input:
        '         pixel coordinates and world coordinates of a point
        ' Output:
        '         metrics vector m 2x2 with pixel and world error on x and y coordinate. First row is for pixel img, second row for world coordinate. 
        '                                                                                First column Is x, Second y

        ' Desired output
        Dim m(1, 1) As Double

        ' used for evaluation, read ImageToWorld
        Dim temp_wx As Double = wx
        Dim temp_wy As Double = wy

        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' [WorldToImage] : From World Coordinates to Image Coordinates
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' This result should be compared to (px,py)
        Dim Res = AcquisitionDevice.WorldToImage(wx, wy)

        Debug.WriteLine("[ World To Image ] : " + Res.ToString)
        Debug.WriteLine("Resulted Pixels : ( " + wx.ToString + " , " + wy.ToString + " )")
        Debug.WriteLine("Expected Pixels : ( " + px.ToString + " , " + py.ToString + " )")
        ' Here and Below is use the Absolute Value of the Error round up to the 7th decimal digit
        Debug.WriteLine("Error in Pixels : ( " + (Math.Abs(wx) - Math.Abs(px)).ToString + " , " + (Math.Abs(wy) - Math.Abs(py)).ToString + " ) pixs")

        ' update pixel error using wx and wy because WorldToImage changes the reference value of the inputs wx,wy in pixel results
        m(0, 0) = Math.Abs(Math.Abs(wx) - Math.Abs(px))
        m(0, 1) = Math.Abs(Math.Abs(wy) - Math.Abs(py))

        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' [ImageToWorld] : From Image Coordinates to World Coordinates
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ' so now (wx, wy) are compromised since WorldToImage has changed them in pixel coordinates
        ' you need to use a temporary copy of the original values (temp_wy and temp_wx)

        ' This result should be compared to (temp_wx, temp_wy)
        Res = AcquisitionDevice.ImageToWorld(px, py)
        Debug.WriteLine("[ Image To World ] : " + Res.ToString)
        Debug.WriteLine("Resulted World : ( " + px.ToString + " , " + py.ToString + " )")
        Debug.WriteLine("Expected World : ( " + temp_wx.ToString + " , " + temp_wy.ToString + " )")
        Debug.WriteLine("Error in World : ( " + (Math.Abs(px) - Math.Abs(temp_wx)).ToString + " , " + (Math.Abs(py) - Math.Abs(temp_wy)).ToString + " ) mm")
        Debug.WriteLine("==================================================================" + vbCr)

        ' update world error
        m(1, 0) = Math.Abs(Math.Abs(px) - Math.Abs(temp_wx))
        m(1, 1) = Math.Abs(Math.Abs(py) - Math.Abs(temp_wy))

        ' now (px, py) are compromised values since ImageToWorld has changed them in world coordinates

        Return m

    End Function

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        FreeMemory()
        Application.DoEvents()
        Debug.WriteLine(vbCr + "_________ButtonQuit_Click")
        Application.Exit()
    End Sub

    Private Sub ButtonLocate_Click(sender As Object, e As EventArgs) Handles ButtonLocate.Click

        Cursor = Cursors.AppStarting
        Wait(0.1)

        lLocator.CoordinateSystem = hsLocatorCoordinatesSystem.hsLocatorWorld
        lLocator.UnitsOrientation = HSLOCATORLib.hsUnitsOrientation.hsDegree

        'If First_Shot_Button And Not AcquisitionDevice.ValidateCalibration(AcquisitionDevice.ConfigurationDefault) Then
        '    ' Locator Model Selection 

        '    If Not lLocator.LoadModelDatabase("C:\Users\mikel\source\repos\Config_Files\Models\home_big_small_board_models.hdb") Then
        '        TextBoxLoadedConfig.BackColor = red
        '        MsgBox("Failed To Load Locator Modeel Database.cfg", MsgBoxStyle.Critical)
        '        Application.Exit()
        '    End If

        '    ' First execution has been done
        '    First_Shot_Button = False

        'End If

        ' Clear Display
        ' Clear Display
        HSDisplay.RemoveAllMarker()

        '' Sub to update display with a new frame
        'AcquisitionDevice.Execute()
        'lLocator.Execute()
        lManager.Execute("HSAcquisition", "HSLocator")
        Application.DoEvents()

        If lLocator.InstanceCount > 0 Then

            Display_All_Current_Locator_Points(hsColor.hsGreen)

            Print(lManager.ElapsedTime)

            Debug.WriteLine("Locator Rotation : " + lLocator.InstanceRotation(0).ToString)

            If lLocator.InstanceRotation(0) > 0 Then
                Debug.WriteLine("Coordinate Rotation - 180 : " + (-180 + lLocator.InstanceRotation(0)).ToString)
            Else
                Debug.WriteLine("Coordinate Rotation + 180 : " + (180 + lLocator.InstanceRotation(0)).ToString)
            End If

            ' Display Axes

            ' Dimension of one Square
            Dim square_dim = 50
            ' FRAME AXES 
            Dim lMarkerName = "TargetAlignment"
            HSDisplay.AddAxesMarker(lMarkerName, lLocator.InstanceTranslationX(0), lLocator.InstanceTranslationY(0), 500, 500, lLocator.InstanceRotation(0), 90, False)
            HSDisplay.set_MarkerColor(lMarkerName, hsColor.hsRed)
            HSDisplay.set_AxesMarkerLabel1(lMarkerName, "X")
            HSDisplay.set_AxesMarkerLabel2(lMarkerName, "Y")
        Else
            Print("NO MATCH")
        End If

        HSDisplay.RefreshDisplay()
        Cursor = Cursors.Default


    End Sub

    Private Sub ButtonWorld2Image_Click(sender As Object, e As EventArgs) Handles ButtonWorld2Image.Click

        Debug.WriteLine(vbCr + "_________ButtonWorld2Image_Click_________")

        Clear_Coordinates_Projection_Colors()
        HSDisplay.RemoveAllMarker()

        Debug.WriteLine("")
        ' Read From World Textboxes and Perform World2Image Operation using Acquisition.Calib

        Dim World_X, World_Y As Double
        Dim ReadXValue = Double.TryParse(TextBoxWorldX.Text, World_X)
        Dim ReadYValue = Double.TryParse(TextBoxWorldY.Text, World_Y)

        If ReadXValue And ReadYValue Then

            Debug.WriteLine("ButtonWorld2Image_Click : Valid Values")

            ' You can Perform Convertion
            Dim Convertion_Sucess = AcquisitionDevice.WorldToImage(World_X, World_Y, AcquisitionDevice.ConfigurationDefault)
            Debug.WriteLine("ButtonWorld2Image_Click : Convertion_Sucess = " + Convertion_Sucess.ToString)

            If Convertion_Sucess Then
                ' Display the result
                TextBoxImageX.Text = Math.Round(World_X, 3)
                TextBoxImageY.Text = Math.Round(World_Y, 3)

                Dim markername = "REPROJECTED"

                HSDisplay.AddPointMarker(markername, World_X, World_Y, False)
                HSDisplay.set_MarkerDisplayName(markername, True)
                HSDisplay.set_MarkerColor(markername, hsColor.hsYellow)
                HSDisplay.CalibratedUnitsEnabled = False
                HSDisplay.RefreshDisplay()
            Else

                Debug.WriteLine("ButtonWorld2Image_Click : Unable to WorldToImage")

                If Not ReadXValue Then
                    TextBoxWorldX.BackColor = red
                End If

                If Not ReadYValue Then
                    TextBoxWorldY.BackColor = red
                End If


            End If

        Else

            Debug.WriteLine("ButtonWorld2Image_Click : Invalid Values")

            If Not ReadXValue Then
                TextBoxWorldX.BackColor = red
            End If

            If Not ReadYValue Then
                TextBoxWorldY.BackColor = red
            End If

        End If

    End Sub

    Private Sub Clear_Coordinates_Projection_Colors()

        Debug.WriteLine("_________Clear_Coordinates_Projection_Colors")

        TextBoxImageY.BackColor = white
        TextBoxImageX.BackColor = white

        TextBoxWorldX.BackColor = white
        TextBoxWorldY.BackColor = white

    End Sub

    Private Sub ButtonImage2World_Click(sender As Object, e As EventArgs) Handles ButtonImage2World.Click

        Debug.WriteLine(vbCr + "_________ButtonImage2World_Click_________")

        Clear_Coordinates_Projection_Colors()
        HSDisplay.RemoveAllMarker()

        ' Read From Image Textboxes and Perform Image2World Operation using Acquisition.Calib

        Debug.WriteLine("")
        ' Read From World Textboxes and Perform World2Image Operation using Acquisition.Calib

        Dim Image_X, Image_Y As Double
        Dim ReadXValue = Double.TryParse(TextBoxImageX.Text, Image_X)
        Dim ReadYValue = Double.TryParse(TextBoxImageY.Text, Image_Y)

        If ReadXValue And ReadYValue Then

            Debug.WriteLine("ButtonImage2World_Click : Valid Values")

            ' You can Perform Convertion
            Dim Convertion_Sucess = AcquisitionDevice.ImageToWorld(Image_X, Image_Y, AcquisitionDevice.ConfigurationDefault)
            Debug.WriteLine("ButtonImage2World_Click : Convertion_Sucess = " + Convertion_Sucess.ToString)

            If Convertion_Sucess Then
                ' Display the result
                TextBoxWorldX.Text = Math.Round(Image_X, 3)
                TextBoxWorldY.Text = Math.Round(Image_Y, 3)

                Dim markername = "REPROJECTED"

                HSDisplay.AddPointMarker(markername, Image_X, Image_Y, True)
                HSDisplay.set_MarkerDisplayName(markername, True)
                HSDisplay.set_MarkerColor(markername, hsColor.hsYellow)
                HSDisplay.CalibratedUnitsEnabled = True
                HSDisplay.RefreshDisplay()
            Else
                Debug.WriteLine("ButtonImage2World_Click : ImageToWorld Failed")

                If Not ReadXValue Then
                    TextBoxImageX.BackColor = red
                End If

                If Not ReadYValue Then
                    TextBoxImageY.BackColor = red
                End If
            End If

        Else

            Debug.WriteLine("ButtonImage2World_Click : Invalid Values")

            If Not ReadXValue Then
                TextBoxImageX.BackColor = red
            End If

            If Not ReadYValue Then
                TextBoxImageY.BackColor = red
            End If

        End If

    End Sub

    Private Sub ButtonTestCalibration_Click(sender As Object, e As EventArgs) Handles ButtonTestCalibration.Click

        Debug.WriteLine(vbCr + "_________ButtonTestCalibration_Click")

        ' Clicking Test Calibration means you want to test world2image and image2world functions
        ' of a already calibrated camera .cal file you upload

        LabelCalibrationLoaded.Visible = True
        TextBoxCalibrationLoaded.Visible = True

        ' LOAD A .cal FILE 
        Print(AcquisitionDevice.ValidateCalibration.ToString)
        If Not AcquisitionDevice.ValidateCalibration Then
            Calibration_Loaded_Success = AcquisitionDevice.LoadCalibration(AcquisitionDevice.ConfigurationDefault)
        End If

        ' At least one of them should be TRUE
        If Calibration_Loaded_Success Or AcquisitionDevice.ValidateCalibration Then
            Debug.WriteLine("ButtonTestCalibration_Click: Hexsight Calibration Loaded Sucessfully")
            TextBoxCalibrationLoaded.BackColor = green
            TextBoxCalibrationLoaded.Text = "OK"

            AcquisitionDevice.Execute()

            HSDisplay.CalibratedUnitsEnabled = True
            HSDisplay.CrossHairVisible = True

            HSDisplay.RefreshDisplay()

            Try
                Debug.WriteLine("ValidateCalibration : " + AcquisitionDevice.ValidateCalibration(AcquisitionDevice.ConfigurationDefault).ToString)
                Debug.WriteLine("State : " + AcquisitionDevice.Calibration(AcquisitionDevice.ConfigurationDefault).State.ToString)
                GroupBoxCoordinateProjection.Visible = True
                Return
            Catch ex As Exception
                TextBoxCalibrationLoaded.BackColor = red
                TextBoxCalibrationLoaded.Text = "NO"
                Debug.WriteLine("ButtonTestCalibration_Click: Failed to Load Hexsight Calibration")
                GroupBoxCoordinateProjection.Visible = False

            End Try

        End If

    End Sub

    Private Sub ErrorMessage(ex As Exception)
        ' Used to debug error messages 
        Debug.WriteLine(vbCr + ex.Message)
        Debug.WriteLine(ex.StackTrace + vbCr)
    End Sub

    Private Sub ButtonGetInstancePixel_Click(sender As Object, e As EventArgs) Handles ButtonCameraShot.Click

        HSDisplay.RemoveAllMarker()

        TextBoxImageX.Text = ""
        TextBoxImageY.Text = ""

        TextBoxWorldX.Text = ""
        TextBoxWorldY.Text = ""

        Wait(0.1)

        If AcquisitionDevice Is Nothing Or lLocator Is Nothing Then
            MsgBox("Failed To Load Locator or Acquisition", MsgBoxStyle.Critical)
        End If

        ' Search for whatever model
        lLocator.ModelEnabled(1) = True

        AcquisitionDevice.Execute()

        HSDisplay.RefreshDisplay()


    End Sub

    Private Function Robot_Has_Changed_Spot_Check()

        ' This Function is used to check if coordinates are good
        ' If the tool WASNT moved during acquisition for example instances from 2 image location shots will have same location

        Debug.WriteLine("Image_Location :" + Image_Location.ToString)

        Dim Dx, Dy As Double

        If Image_Location > 1 Then

            'Debug.WriteLine("Dx : " + Math.Abs(Instance_Pixel_Coordinates(Image_Location - 1, 0) - Instance_Pixel_Coordinates(Image_Location - 2, 0)).ToString)
            'Debug.WriteLine("Dy : " + Math.Abs(Instance_Pixel_Coordinates(Image_Location - 1, 1) - Instance_Pixel_Coordinates(Image_Location - 2, 1)).ToString)

            Dx = Math.Abs(Dot_Pixel_Coordinates(Image_Location - 1, 0) - Dot_Pixel_Coordinates(Image_Location - 2, 0))
            Dy = Math.Abs(Dot_Pixel_Coordinates(Image_Location - 1, 1) - Dot_Pixel_Coordinates(Image_Location - 2, 1))

            If Dx < 20 And Dy < 20 Then
                Debug.WriteLine("Bad Coordinates Acquisition, Repeating " + Image_Location.ToString + " Acquisition")
                MsgBox("It seems robot hasnt moved from previously spot!", MsgBoxStyle.Exclamation, "Robot Hasnt changed spot")
                Return False
            End If

        End If

        FreeMemory()

        Return True

    End Function

    Sub ShowRapidCoordinates()

        Print(vbCr + "Horizontal X Displacement : " + DX.ToString + "mm, Vertical Y Displacement :" + DY.ToString + "mm")
        Dim nexty
        Dim nextx
        Dim index = 0

        Print("")
        Print("Point i : X, Y")
        For r = 0 To DESIRED_ROWS - 1
            nextx = STARTX + r * DX
            For c = 0 To DESIRED_COLUMNS - 1
                nexty = STARTY + c * DY
                index += 1
                Print("Point " + index.ToString + " : " + nextx.ToString + ", " + nexty.ToString)
            Next
            Print("")
        Next

        Print("Calibration will be made with : " + (DESIRED_ROWS * DESIRED_COLUMNS).ToString + " points" + vbCr)

    End Sub

    'Private Function Is_Robot_Ready()

    '    Wait(0.1)

    '    Debug.WriteLine(vbCr + "_________Is_Robot_Ready" + vbCr)

    '    AcquisitionDevice.Execute()
    '    lLocator.Execute()
    '    Wait(0.1)

    '    If False Then

    '        '' Timer 10s

    '        'TextBoxTimer.Visible = True
    '        'LabelTimer.Visible = True
    '        'TextBoxTimer.BackColor = Color.Orange

    '        'For timer = 0 To 10
    '        '    Wait(1)
    '        '    Debug.WriteLine((10 - timer).ToString)
    '        '    TextBoxTimer.Text = (10 - timer).ToString
    '        'Next
    '        ''TextBoxTimer.Text = 0
    '        ''TextBoxTimer.Visible = False
    '        ''LabelTimer.Visible = False

    '        Return True

    '    Else

    '        Debug.WriteLine("Starting Analyzing")

    '        ' Understand if Robot is moving or is steady
    '        ' this is done getting it's last three coordinates 
    '        ' and comparing them 

    '        Dim Instance_x = 10000000
    '        Dim Instance_y = 10000000
    '        Dim Disp_x = 10000000
    '        Dim Disp_y = 10000000
    '        Dim Steady_Counter = 0

    '        While Steady_Counter < 4
    '            PictureBoxAcquisitionoOk.Visible = False
    '            Debug.WriteLine("Trying updating Instance...")
    '            Try
    '                Instance_x = lLocator.InstanceTranslationX(0)
    '                Instance_y = lLocator.InstanceTranslationY(0)
    '            Catch ex As Exception
    '                Debug.WriteLine(vbCr + "Unable to Get InstanceTranslation")
    '            End Try

    '            Wait(0.7)
    '            Debug.WriteLine("Acquiring New")

    '            AcquisitionDevice.Execute()
    '            lLocator.Execute()
    '            Wait(0.1)

    '            Debug.Write("Trying making Disp")
    '            Try
    '                Disp_x = Math.Abs(Instance_x - lLocator.InstanceTranslationX(0))
    '                Disp_y = Math.Abs(Instance_y - lLocator.InstanceTranslationY(0))
    '                Debug.WriteLine("DX : " + Disp_x.ToString + ", DY : " + Disp_y.ToString)
    '            Catch ex As Exception
    '                Debug.WriteLine(vbCr + "Not Detected")
    '                Wait(0.1)
    '                LabelToolState.Text = "MOVING"
    '                LabelToolState.BackColor = red
    '                PictureBoxToolMoving.Visible = True
    '                PictureBoxSteady.Visible = False
    '                Wait(0.1)
    '            End Try

    '            Debug.Write("Checking : ")
    '            If Disp_x < 20 And Disp_y < 20 Then
    '                Steady_Counter += 1
    '                Debug.Write("[ OK ] : VALID! -> Steady_Counter : " + Steady_Counter.ToString)
    '                LabelToolState.Text = "STEADY"
    '                LabelToolState.BackColor = green
    '                PictureBoxToolMoving.Visible = False
    '                PictureBoxSteady.Visible = True
    '                Wait(0.1)
    '            Else
    '                ' I want three good position in a row
    '                Steady_Counter = 0
    '                Debug.Write("[ X ]  MOVING! -> Reset Steady_Counter  : " + Steady_Counter.ToString)
    '                LabelToolState.Text = "MOVING"
    '                LabelToolState.BackColor = red
    '                PictureBoxToolMoving.Visible = True
    '                PictureBoxSteady.Visible = False
    '                Wait(0.1)
    '            End If

    '            Debug.WriteLine(vbCr + "" + vbCr)
    '        End While

    '        FreeMemory()
    '        Debug.WriteLine("[ FINAL ] : Robot is Steady" + vbCr)
    '        Wait(0.1)
    '        LabelToolState.Text = "STEADY"
    '        LabelToolState.BackColor = green
    '        PictureBoxToolMoving.Visible = False
    '        PictureBoxSteady.Visible = True
    '        Return True

    '    End If

    '    Return False

    'End Function

    'Private Sub Small_Plate_Acquisition()

    '    Debug.WriteLine(vbCr + "_________Small_Plate_Acquisition")

    '    Dim result As MsgBoxResult = MsgBox("START RAPID SCRIPT", MsgBoxStyle.OkCancel, "Ready To Start")

    '    If Not result = 1 Then
    '        Return
    '    End If

    '    ' Reset Data Structures

    '    For column = 0 To Dot_Pixel_Coordinates.GetUpperBound(1)
    '        Dot_Pixel_Coordinates(Image_Location, column) = 0.0
    '    Next

    '    For column = 0 To Dot_Pixel_Coordinates.GetUpperBound(1)
    '        Dot_Pixel_Coordinates(Image_Location, column) = 0.0
    '    Next

    '    ' Data structure where you save current points
    '    ' 2x4
    '    Dim Current_Instance_Point_Store(1, Distortion_Average_Shots - 1)

    '    ' We Have 4 Image Location, one each corner
    '    For Image_Location = 1 To 4
    '        Debug.Write(vbCr + "Next Image_Location : [" + Image_Location.ToString + "] -> Move The Target")

    '        ' Wait for the robot to be steady at the position
    '        While Not Is_Robot_Ready()
    '        End While

    '        ' Perform 5 shots to take average coordinates values
    '        For Image_Index = 1 To Distortion_Average_Shots

    '            ' Perform one frame acquisition
    '            ' Get a frame from camera and apply pattern matching using Locator
    '            AcquisitionDevice.Execute()
    '            lLocator.Execute()
    '            Wait(0.1)

    '            If lLocator.InstanceCount > 0 AndAlso lLocator.InstanceReferencePointCount(0) > 8 Then

    '                Debug.Write(vbCr + "Image_Index : [" + Image_Index.ToString + "] ->")
    '                Debug.Write("lLocator.InstanceReferencePointCount : " + lLocator.InstanceReferencePointCount(0).ToString)
    '                Debug.Write(", Rotation : " + lLocator.InstanceRotation(0).ToString)
    '                Debug.Write(", Model Fit % : " + (100 * lLocator.InstanceFitQuality(0)).ToString + vbCr)

    '                ' Display on the screen all points scanned by Locator
    '                Display_All_Current_Locator_Points(hsColor.hsMagenta)

    '                ' Accumulate current x and y coordinates of the instance point
    '                Dot_Pixel_Coordinates(Image_Location - 1, 0) += lLocator.InstanceTranslationX(0)
    '                Dot_Pixel_Coordinates(Image_Location - 1, 1) += lLocator.InstanceTranslationY(0)

    '            Else
    '                Debug.WriteLine("No Match")
    '                HSDisplay.RemoveAllMarker()
    '                ' Penalize if No Matching
    '                If Image_Index > 0 Then
    '                    Image_Index -= 1
    '                End If

    '            End If

    '            ' Refresh the display 
    '            HSDisplay.RefreshDisplay()
    '            Application.DoEvents()

    '        Next

    '        Debug.WriteLine(vbCr + "Average Shots Terminated, Saving Coordinates and Performing Average")
    '        Wait(2)

    '        ' Save Coordinates In the Matrix making average
    '        Dot_Pixel_Coordinates(Image_Location - 1, 0) /= Distortion_Average_Shots
    '        Dot_Pixel_Coordinates(Image_Location - 1, 1) /= Distortion_Average_Shots

    '        ' Update Display showing all scanned points
    '        HSDisplay.RemoveAllMarker()
    '        Display_All_Points()
    '        ' Refresh the display 
    '        HSDisplay.RefreshDisplay()
    '        Application.DoEvents()

    '        FreeMemory()

    '        ' Check IF Coordinates Acquisition was good
    '        If Not Robot_Has_Changed_Spot_Check() Then

    '            ' Since this Coordinate Acquisition isnt good, repeat
    '            Image_Location -= 1

    '            ' Reset Data Structures

    '            For column = 0 To Dot_Pixel_Coordinates.GetUpperBound(1)
    '                Dot_Pixel_Coordinates(Image_Location, column) = 0.0
    '            Next

    '            ' Clear Display
    '            HSDisplay.RemoveAllMarker()

    '        End If

    '    Next

    'End Sub

    Private Sub Display_All_Points()

        For Dot = 0 To Dot_Pixel_Coordinates.GetUpperBound(0)

            ' name : (index + 1).ToString
            ' x : pixel_coordinates(index, 0)
            ' y : pixel_coordinates(index, 1)
            ' color : hsColor.hsRed

            Display_Screen_Point("D" + (Dot + 1).ToString, Dot_Pixel_Coordinates(Dot, 0), Dot_Pixel_Coordinates(Dot, 1), hsColor.hsGreen)

        Next

    End Sub

    Private Sub RestoreAllButtons()

        RestoreButtonBorder(ButtonStart)
        RestoreButtonBorder(ButtonCalibrate)
        RestoreButtonBorder(ButtonQuit)

        RestoreButtonBorder(ButtonCameraShot)
        RestoreButtonBorder(ButtonLocate)
        RestoreButtonBorder(ButtonPLCOK)

        RestoreButtonBorder(ButtonTestCalibration)

        RestoreButtonBorder(ButtonImage2World)
        RestoreButtonBorder(ButtonWorld2Image)

    End Sub

    Private Sub RestoreButtonBorder(B As Button)

        B.FlatAppearance.BorderSize = 0

    End Sub

    Private Sub PushedButtonBorder(B As Button)

        B.FlatAppearance.BorderSize = 2
        B.FlatAppearance.BorderColor = Color.Gold

    End Sub

    Private Sub ButtonPLCOK_Click(sender As Object, e As EventArgs) Handles ButtonPLCOK.Click
        ' PLC has sent an input telling tool is steady and ready for the shot
        ' When such signal comes in the ABB timer starts, so you have 15s to complete the coordinates
        ' acquisition
        PLC_OK = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LabelTimer.Text = (Double.Parse(LabelTimer.Text) + 0.5).ToString
    End Sub

    Private Sub SaveMatrix2Text(file_name As String, image_matrix(,) As Double, world_matrix(,) As Double)

        Try

            Dim file As IO.StreamWriter
            ' Application.StartupPath is bin/debug/
            Dim filename = Application.StartupPath & "\Matrices\" + file_name + ".txt"

            file = My.Computer.FileSystem.OpenTextFileWriter(filename, False) ' False = Overwrite file content
            file.Write("% " + file_name + vbCr)

            ' ----------------------------------
            ' IMAGE 
            ' ----------------------------------

            ' Iterate inside image matrix
            For row = 0 To image_matrix.GetUpperBound(0)

                ' example output:
                ' I1 = [2981, 8137]

                file.WriteLine("I" + (row + 1).ToString + "= [" + Str(image_matrix(row, 0)) + "," + Str(image_matrix(row, 1)) + "]';")

            Next

            file.WriteLine("% Complete vector")
            file.Write("I" + "= [")

            ' Iterate inside The Data
            For row = 0 To image_matrix.GetUpperBound(0)

                ' example output:
                ' I= [I1, I2, I3...]

                file.Write("I" + (row + 1).ToString + ", ")

            Next

            file.Write("];" + vbCr)

            ' ----------------------------------
            ' WORLD
            ' ----------------------------------

            ' Iterate inside world matrix
            For row = 0 To world_matrix.GetUpperBound(0)

                ' example output:
                ' W1 = [2981, 8137]'

                file.WriteLine("W" + (row + 1).ToString + "= [" + Str(world_matrix(row, 0)) + "," + Str(world_matrix(row, 1)) + "]';")

            Next

            file.WriteLine("% Complete vector")
            file.Write("W" + "= [")

            ' Iterate inside The Data
            For row = 0 To world_matrix.GetUpperBound(0)

                ' example output:
                ' W= [W1, W2, W3...]

                file.Write("W" + (row + 1).ToString + ", ")

            Next

            file.Write("];")

            file.Close()

        Catch ex As Exception

            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' Save coordinates to file
        For i = 0 To CALIBRATION_POINTS - 1
            Dim w_coord = Instance_World_Coordinate_from_Image_Index(i + 1)
            Dot_World_Coordinates(i, 0) = w_coord(0, 0)
            Dot_World_Coordinates(i, 1) = w_coord(0, 1)
        Next

        SaveMatrix2Text(file_name:="r" + DESIRED_ROWS.ToString + "c" + DESIRED_COLUMNS.ToString + "_Coordinates",
        image_matrix:=Dot_Pixel_Coordinates,
        world_matrix:=Dot_World_Coordinates)
        Print(" ok SAVED")

    End Sub
End Class
