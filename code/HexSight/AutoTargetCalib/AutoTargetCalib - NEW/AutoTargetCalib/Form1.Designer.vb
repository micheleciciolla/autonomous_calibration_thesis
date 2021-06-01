<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.HSApplicationControl = New AxHSAPPLICATIONLib.AxHSApplication()
        Me.HSDisplay = New AxHSDISPLAYLib.AxHSDisplay()
        Me.LabelCalibrationResult = New System.Windows.Forms.Label()
        Me.TextBoxCalibrationResult = New System.Windows.Forms.TextBox()
        Me.LabelCalibrationLoaded = New System.Windows.Forms.Label()
        Me.TextBoxCalibrationLoaded = New System.Windows.Forms.TextBox()
        Me.LabelGigECamera = New System.Windows.Forms.Label()
        Me.TextBox_GigE = New System.Windows.Forms.TextBox()
        Me.LabelLoadedConfig = New System.Windows.Forms.Label()
        Me.TextBoxLoadedConfig = New System.Windows.Forms.TextBox()
        Me.ButtonLocate = New System.Windows.Forms.Button()
        Me.ButtonCalibrate = New System.Windows.Forms.Button()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.GroupBoxCoordinateProjection = New System.Windows.Forms.GroupBox()
        Me.GroupBoxImageCoordinates = New System.Windows.Forms.GroupBox()
        Me.TextBoxImageY = New System.Windows.Forms.TextBox()
        Me.TextBoxImageX = New System.Windows.Forms.TextBox()
        Me.GroupBoxWorldCoordinates = New System.Windows.Forms.GroupBox()
        Me.TextBoxWorldY = New System.Windows.Forms.TextBox()
        Me.TextBoxWorldX = New System.Windows.Forms.TextBox()
        Me.ButtonWorld2Image = New System.Windows.Forms.Button()
        Me.ButtonImage2World = New System.Windows.Forms.Button()
        Me.ButtonCameraShot = New System.Windows.Forms.Button()
        Me.ButtonTestCalibration = New System.Windows.Forms.Button()
        Me.GroupBoxCalibrationPerformance = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxAVGWorldErr = New System.Windows.Forms.TextBox()
        Me.TextBoxMaxWorldErr = New System.Windows.Forms.TextBox()
        Me.TextBoxAVGPixelErr = New System.Windows.Forms.TextBox()
        Me.TextBoxMaxPixelErr = New System.Windows.Forms.TextBox()
        Me.GroupBoxProgressControl = New System.Windows.Forms.GroupBox()
        Me.LabelAcquisitionState = New System.Windows.Forms.Label()
        Me.LabelToolState = New System.Windows.Forms.Label()
        Me.LabelTool = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelProgress = New System.Windows.Forms.Label()
        Me.ButtonPLCOK = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBoxICAP = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelTotalPoints = New System.Windows.Forms.Label()
        Me.LabelTimer = New System.Windows.Forms.Label()
        Me.LabelTimerName = New System.Windows.Forms.Label()
        Me.LabelDotCount = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.HSApplicationControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HSDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCoordinateProjection.SuspendLayout()
        Me.GroupBoxImageCoordinates.SuspendLayout()
        Me.GroupBoxWorldCoordinates.SuspendLayout()
        Me.GroupBoxCalibrationPerformance.SuspendLayout()
        Me.GroupBoxProgressControl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBoxICAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HSApplicationControl
        '
        Me.HSApplicationControl.Enabled = True
        Me.HSApplicationControl.Location = New System.Drawing.Point(9, 3)
        Me.HSApplicationControl.Name = "HSApplicationControl"
        Me.HSApplicationControl.OcxState = CType(resources.GetObject("HSApplicationControl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.HSApplicationControl.Size = New System.Drawing.Size(16, 15)
        Me.HSApplicationControl.TabIndex = 0
        '
        'HSDisplay
        '
        Me.HSDisplay.Enabled = True
        Me.HSDisplay.Location = New System.Drawing.Point(12, 10)
        Me.HSDisplay.Name = "HSDisplay"
        Me.HSDisplay.OcxState = CType(resources.GetObject("HSDisplay.OcxState"), System.Windows.Forms.AxHost.State)
        Me.HSDisplay.Size = New System.Drawing.Size(692, 428)
        Me.HSDisplay.TabIndex = 1
        '
        'LabelCalibrationResult
        '
        Me.LabelCalibrationResult.AutoSize = True
        Me.LabelCalibrationResult.BackColor = System.Drawing.Color.Transparent
        Me.LabelCalibrationResult.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCalibrationResult.ForeColor = System.Drawing.Color.Brown
        Me.LabelCalibrationResult.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelCalibrationResult.Location = New System.Drawing.Point(719, 18)
        Me.LabelCalibrationResult.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCalibrationResult.Name = "LabelCalibrationResult"
        Me.LabelCalibrationResult.Size = New System.Drawing.Size(111, 18)
        Me.LabelCalibrationResult.TabIndex = 34
        Me.LabelCalibrationResult.Text = "Calib Result"
        '
        'TextBoxCalibrationResult
        '
        Me.TextBoxCalibrationResult.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxCalibrationResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCalibrationResult.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxCalibrationResult.Enabled = False
        Me.TextBoxCalibrationResult.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCalibrationResult.Location = New System.Drawing.Point(839, 10)
        Me.TextBoxCalibrationResult.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBoxCalibrationResult.Name = "TextBoxCalibrationResult"
        Me.TextBoxCalibrationResult.ReadOnly = True
        Me.TextBoxCalibrationResult.Size = New System.Drawing.Size(32, 26)
        Me.TextBoxCalibrationResult.TabIndex = 33
        '
        'LabelCalibrationLoaded
        '
        Me.LabelCalibrationLoaded.AutoSize = True
        Me.LabelCalibrationLoaded.BackColor = System.Drawing.Color.Transparent
        Me.LabelCalibrationLoaded.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCalibrationLoaded.ForeColor = System.Drawing.Color.Brown
        Me.LabelCalibrationLoaded.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelCalibrationLoaded.Location = New System.Drawing.Point(719, 52)
        Me.LabelCalibrationLoaded.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCalibrationLoaded.Name = "LabelCalibrationLoaded"
        Me.LabelCalibrationLoaded.Size = New System.Drawing.Size(89, 18)
        Me.LabelCalibrationLoaded.TabIndex = 32
        Me.LabelCalibrationLoaded.Text = "Calib File"
        '
        'TextBoxCalibrationLoaded
        '
        Me.TextBoxCalibrationLoaded.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxCalibrationLoaded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCalibrationLoaded.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxCalibrationLoaded.Enabled = False
        Me.TextBoxCalibrationLoaded.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCalibrationLoaded.Location = New System.Drawing.Point(838, 44)
        Me.TextBoxCalibrationLoaded.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBoxCalibrationLoaded.Name = "TextBoxCalibrationLoaded"
        Me.TextBoxCalibrationLoaded.ReadOnly = True
        Me.TextBoxCalibrationLoaded.Size = New System.Drawing.Size(32, 26)
        Me.TextBoxCalibrationLoaded.TabIndex = 31
        '
        'LabelGigECamera
        '
        Me.LabelGigECamera.AutoSize = True
        Me.LabelGigECamera.BackColor = System.Drawing.Color.Transparent
        Me.LabelGigECamera.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGigECamera.ForeColor = System.Drawing.Color.Brown
        Me.LabelGigECamera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelGigECamera.Location = New System.Drawing.Point(879, 52)
        Me.LabelGigECamera.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelGigECamera.Name = "LabelGigECamera"
        Me.LabelGigECamera.Size = New System.Drawing.Size(115, 18)
        Me.LabelGigECamera.TabIndex = 30
        Me.LabelGigECamera.Text = "GigE Camera"
        '
        'TextBox_GigE
        '
        Me.TextBox_GigE.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox_GigE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_GigE.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox_GigE.Enabled = False
        Me.TextBox_GigE.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_GigE.Location = New System.Drawing.Point(1002, 44)
        Me.TextBox_GigE.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBox_GigE.Name = "TextBox_GigE"
        Me.TextBox_GigE.ReadOnly = True
        Me.TextBox_GigE.Size = New System.Drawing.Size(32, 26)
        Me.TextBox_GigE.TabIndex = 29
        '
        'LabelLoadedConfig
        '
        Me.LabelLoadedConfig.AutoSize = True
        Me.LabelLoadedConfig.BackColor = System.Drawing.Color.Transparent
        Me.LabelLoadedConfig.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLoadedConfig.ForeColor = System.Drawing.Color.Brown
        Me.LabelLoadedConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelLoadedConfig.Location = New System.Drawing.Point(879, 18)
        Me.LabelLoadedConfig.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLoadedConfig.Name = "LabelLoadedConfig"
        Me.LabelLoadedConfig.Size = New System.Drawing.Size(84, 18)
        Me.LabelLoadedConfig.TabIndex = 28
        Me.LabelLoadedConfig.Text = "HexSight"
        '
        'TextBoxLoadedConfig
        '
        Me.TextBoxLoadedConfig.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxLoadedConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxLoadedConfig.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxLoadedConfig.Enabled = False
        Me.TextBoxLoadedConfig.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLoadedConfig.Location = New System.Drawing.Point(1002, 10)
        Me.TextBoxLoadedConfig.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBoxLoadedConfig.Name = "TextBoxLoadedConfig"
        Me.TextBoxLoadedConfig.ReadOnly = True
        Me.TextBoxLoadedConfig.Size = New System.Drawing.Size(32, 26)
        Me.TextBoxLoadedConfig.TabIndex = 27
        '
        'ButtonLocate
        '
        Me.ButtonLocate.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLocate.FlatAppearance.BorderSize = 0
        Me.ButtonLocate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLocate.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLocate.ForeColor = System.Drawing.Color.Brown
        Me.ButtonLocate.Image = CType(resources.GetObject("ButtonLocate.Image"), System.Drawing.Image)
        Me.ButtonLocate.Location = New System.Drawing.Point(820, 266)
        Me.ButtonLocate.Name = "ButtonLocate"
        Me.ButtonLocate.Size = New System.Drawing.Size(86, 103)
        Me.ButtonLocate.TabIndex = 35
        Me.ButtonLocate.Text = "Locate"
        Me.ButtonLocate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonLocate.UseVisualStyleBackColor = False
        '
        'ButtonCalibrate
        '
        Me.ButtonCalibrate.BackColor = System.Drawing.Color.Transparent
        Me.ButtonCalibrate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCalibrate.FlatAppearance.BorderSize = 0
        Me.ButtonCalibrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCalibrate.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCalibrate.ForeColor = System.Drawing.Color.Brown
        Me.ButtonCalibrate.Image = CType(resources.GetObject("ButtonCalibrate.Image"), System.Drawing.Image)
        Me.ButtonCalibrate.Location = New System.Drawing.Point(709, 379)
        Me.ButtonCalibrate.Name = "ButtonCalibrate"
        Me.ButtonCalibrate.Size = New System.Drawing.Size(98, 113)
        Me.ButtonCalibrate.TabIndex = 36
        Me.ButtonCalibrate.Text = "Calibrate"
        Me.ButtonCalibrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonCalibrate.UseVisualStyleBackColor = False
        Me.ButtonCalibrate.Visible = False
        '
        'ButtonQuit
        '
        Me.ButtonQuit.BackColor = System.Drawing.Color.Transparent
        Me.ButtonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonQuit.FlatAppearance.BorderSize = 0
        Me.ButtonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonQuit.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonQuit.ForeColor = System.Drawing.Color.Brown
        Me.ButtonQuit.Image = CType(resources.GetObject("ButtonQuit.Image"), System.Drawing.Image)
        Me.ButtonQuit.Location = New System.Drawing.Point(726, 555)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(69, 97)
        Me.ButtonQuit.TabIndex = 37
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonQuit.UseVisualStyleBackColor = False
        '
        'ButtonStart
        '
        Me.ButtonStart.BackColor = System.Drawing.Color.Transparent
        Me.ButtonStart.FlatAppearance.BorderSize = 0
        Me.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStart.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStart.ForeColor = System.Drawing.Color.Brown
        Me.ButtonStart.Image = CType(resources.GetObject("ButtonStart.Image"), System.Drawing.Image)
        Me.ButtonStart.Location = New System.Drawing.Point(709, 267)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(98, 106)
        Me.ButtonStart.TabIndex = 38
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonStart.UseVisualStyleBackColor = False
        '
        'GroupBoxCoordinateProjection
        '
        Me.GroupBoxCoordinateProjection.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxCoordinateProjection.Controls.Add(Me.GroupBoxImageCoordinates)
        Me.GroupBoxCoordinateProjection.Controls.Add(Me.GroupBoxWorldCoordinates)
        Me.GroupBoxCoordinateProjection.Controls.Add(Me.ButtonWorld2Image)
        Me.GroupBoxCoordinateProjection.Controls.Add(Me.ButtonImage2World)
        Me.GroupBoxCoordinateProjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxCoordinateProjection.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxCoordinateProjection.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBoxCoordinateProjection.Location = New System.Drawing.Point(9, 449)
        Me.GroupBoxCoordinateProjection.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBoxCoordinateProjection.Name = "GroupBoxCoordinateProjection"
        Me.GroupBoxCoordinateProjection.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxCoordinateProjection.Size = New System.Drawing.Size(375, 199)
        Me.GroupBoxCoordinateProjection.TabIndex = 39
        Me.GroupBoxCoordinateProjection.TabStop = False
        '
        'GroupBoxImageCoordinates
        '
        Me.GroupBoxImageCoordinates.Controls.Add(Me.TextBoxImageY)
        Me.GroupBoxImageCoordinates.Controls.Add(Me.TextBoxImageX)
        Me.GroupBoxImageCoordinates.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxImageCoordinates.Location = New System.Drawing.Point(267, 30)
        Me.GroupBoxImageCoordinates.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBoxImageCoordinates.Name = "GroupBoxImageCoordinates"
        Me.GroupBoxImageCoordinates.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxImageCoordinates.Size = New System.Drawing.Size(98, 107)
        Me.GroupBoxImageCoordinates.TabIndex = 16
        Me.GroupBoxImageCoordinates.TabStop = False
        Me.GroupBoxImageCoordinates.Text = "IMAGE"
        '
        'TextBoxImageY
        '
        Me.TextBoxImageY.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxImageY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxImageY.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImageY.Location = New System.Drawing.Point(10, 62)
        Me.TextBoxImageY.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxImageY.Name = "TextBoxImageY"
        Me.TextBoxImageY.Size = New System.Drawing.Size(69, 26)
        Me.TextBoxImageY.TabIndex = 3
        '
        'TextBoxImageX
        '
        Me.TextBoxImageX.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxImageX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxImageX.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxImageX.Location = New System.Drawing.Point(10, 25)
        Me.TextBoxImageX.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxImageX.Name = "TextBoxImageX"
        Me.TextBoxImageX.Size = New System.Drawing.Size(69, 26)
        Me.TextBoxImageX.TabIndex = 2
        '
        'GroupBoxWorldCoordinates
        '
        Me.GroupBoxWorldCoordinates.Controls.Add(Me.TextBoxWorldY)
        Me.GroupBoxWorldCoordinates.Controls.Add(Me.TextBoxWorldX)
        Me.GroupBoxWorldCoordinates.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxWorldCoordinates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBoxWorldCoordinates.Location = New System.Drawing.Point(14, 30)
        Me.GroupBoxWorldCoordinates.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBoxWorldCoordinates.Name = "GroupBoxWorldCoordinates"
        Me.GroupBoxWorldCoordinates.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxWorldCoordinates.Size = New System.Drawing.Size(98, 107)
        Me.GroupBoxWorldCoordinates.TabIndex = 15
        Me.GroupBoxWorldCoordinates.TabStop = False
        Me.GroupBoxWorldCoordinates.Text = "WORLD"
        '
        'TextBoxWorldY
        '
        Me.TextBoxWorldY.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxWorldY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxWorldY.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWorldY.Location = New System.Drawing.Point(10, 62)
        Me.TextBoxWorldY.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxWorldY.Name = "TextBoxWorldY"
        Me.TextBoxWorldY.Size = New System.Drawing.Size(69, 26)
        Me.TextBoxWorldY.TabIndex = 1
        '
        'TextBoxWorldX
        '
        Me.TextBoxWorldX.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxWorldX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxWorldX.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWorldX.Location = New System.Drawing.Point(10, 25)
        Me.TextBoxWorldX.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBoxWorldX.Name = "TextBoxWorldX"
        Me.TextBoxWorldX.Size = New System.Drawing.Size(69, 26)
        Me.TextBoxWorldX.TabIndex = 0
        '
        'ButtonWorld2Image
        '
        Me.ButtonWorld2Image.BackColor = System.Drawing.Color.Transparent
        Me.ButtonWorld2Image.FlatAppearance.BorderSize = 0
        Me.ButtonWorld2Image.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonWorld2Image.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonWorld2Image.ForeColor = System.Drawing.Color.Brown
        Me.ButtonWorld2Image.Image = CType(resources.GetObject("ButtonWorld2Image.Image"), System.Drawing.Image)
        Me.ButtonWorld2Image.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonWorld2Image.Location = New System.Drawing.Point(121, 8)
        Me.ButtonWorld2Image.Margin = New System.Windows.Forms.Padding(5)
        Me.ButtonWorld2Image.Name = "ButtonWorld2Image"
        Me.ButtonWorld2Image.Size = New System.Drawing.Size(146, 90)
        Me.ButtonWorld2Image.TabIndex = 13
        Me.ButtonWorld2Image.Text = "WorldToImage"
        Me.ButtonWorld2Image.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonWorld2Image.UseVisualStyleBackColor = False
        '
        'ButtonImage2World
        '
        Me.ButtonImage2World.BackColor = System.Drawing.Color.Transparent
        Me.ButtonImage2World.FlatAppearance.BorderSize = 0
        Me.ButtonImage2World.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImage2World.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonImage2World.ForeColor = System.Drawing.Color.Brown
        Me.ButtonImage2World.Image = CType(resources.GetObject("ButtonImage2World.Image"), System.Drawing.Image)
        Me.ButtonImage2World.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonImage2World.Location = New System.Drawing.Point(121, 93)
        Me.ButtonImage2World.Margin = New System.Windows.Forms.Padding(5)
        Me.ButtonImage2World.Name = "ButtonImage2World"
        Me.ButtonImage2World.Size = New System.Drawing.Size(151, 96)
        Me.ButtonImage2World.TabIndex = 14
        Me.ButtonImage2World.Text = "ImageToWorld"
        Me.ButtonImage2World.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonImage2World.UseVisualStyleBackColor = False
        '
        'ButtonCameraShot
        '
        Me.ButtonCameraShot.BackColor = System.Drawing.Color.Transparent
        Me.ButtonCameraShot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCameraShot.FlatAppearance.BorderSize = 0
        Me.ButtonCameraShot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCameraShot.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCameraShot.ForeColor = System.Drawing.Color.Brown
        Me.ButtonCameraShot.Image = CType(resources.GetObject("ButtonCameraShot.Image"), System.Drawing.Image)
        Me.ButtonCameraShot.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonCameraShot.Location = New System.Drawing.Point(932, 266)
        Me.ButtonCameraShot.Margin = New System.Windows.Forms.Padding(5)
        Me.ButtonCameraShot.Name = "ButtonCameraShot"
        Me.ButtonCameraShot.Size = New System.Drawing.Size(98, 114)
        Me.ButtonCameraShot.TabIndex = 17
        Me.ButtonCameraShot.Text = "Camera Shot"
        Me.ButtonCameraShot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonCameraShot.UseVisualStyleBackColor = False
        '
        'ButtonTestCalibration
        '
        Me.ButtonTestCalibration.BackColor = System.Drawing.Color.Transparent
        Me.ButtonTestCalibration.FlatAppearance.BorderSize = 0
        Me.ButtonTestCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTestCalibration.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonTestCalibration.ForeColor = System.Drawing.Color.Brown
        Me.ButtonTestCalibration.Image = CType(resources.GetObject("ButtonTestCalibration.Image"), System.Drawing.Image)
        Me.ButtonTestCalibration.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonTestCalibration.Location = New System.Drawing.Point(921, 375)
        Me.ButtonTestCalibration.Margin = New System.Windows.Forms.Padding(5)
        Me.ButtonTestCalibration.Name = "ButtonTestCalibration"
        Me.ButtonTestCalibration.Size = New System.Drawing.Size(119, 122)
        Me.ButtonTestCalibration.TabIndex = 40
        Me.ButtonTestCalibration.Text = "Test Calibration"
        Me.ButtonTestCalibration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonTestCalibration.UseVisualStyleBackColor = False
        '
        'GroupBoxCalibrationPerformance
        '
        Me.GroupBoxCalibrationPerformance.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.Label10)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.Label11)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.Label7)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.Label9)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.TextBoxAVGWorldErr)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.TextBoxMaxWorldErr)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.TextBoxAVGPixelErr)
        Me.GroupBoxCalibrationPerformance.Controls.Add(Me.TextBoxMaxPixelErr)
        Me.GroupBoxCalibrationPerformance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxCalibrationPerformance.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxCalibrationPerformance.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBoxCalibrationPerformance.Location = New System.Drawing.Point(722, 79)
        Me.GroupBoxCalibrationPerformance.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxCalibrationPerformance.Name = "GroupBoxCalibrationPerformance"
        Me.GroupBoxCalibrationPerformance.Padding = New System.Windows.Forms.Padding(7)
        Me.GroupBoxCalibrationPerformance.Size = New System.Drawing.Size(304, 183)
        Me.GroupBoxCalibrationPerformance.TabIndex = 45
        Me.GroupBoxCalibrationPerformance.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Brown
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(12, 144)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 18)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Max World Error"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Brown
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(10, 113)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(181, 18)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Average World Error"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Brown
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 67)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 18)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Max Pixel Error"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Brown
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(12, 38)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(172, 18)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Average Pixel Error"
        '
        'TextBoxAVGWorldErr
        '
        Me.TextBoxAVGWorldErr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxAVGWorldErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAVGWorldErr.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxAVGWorldErr.Enabled = False
        Me.TextBoxAVGWorldErr.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAVGWorldErr.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TextBoxAVGWorldErr.Location = New System.Drawing.Point(192, 113)
        Me.TextBoxAVGWorldErr.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxAVGWorldErr.Name = "TextBoxAVGWorldErr"
        Me.TextBoxAVGWorldErr.ReadOnly = True
        Me.TextBoxAVGWorldErr.Size = New System.Drawing.Size(105, 26)
        Me.TextBoxAVGWorldErr.TabIndex = 22
        Me.TextBoxAVGWorldErr.Text = "-1"
        Me.TextBoxAVGWorldErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxMaxWorldErr
        '
        Me.TextBoxMaxWorldErr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxMaxWorldErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxMaxWorldErr.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxMaxWorldErr.Enabled = False
        Me.TextBoxMaxWorldErr.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMaxWorldErr.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TextBoxMaxWorldErr.Location = New System.Drawing.Point(192, 144)
        Me.TextBoxMaxWorldErr.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxMaxWorldErr.Name = "TextBoxMaxWorldErr"
        Me.TextBoxMaxWorldErr.ReadOnly = True
        Me.TextBoxMaxWorldErr.Size = New System.Drawing.Size(105, 26)
        Me.TextBoxMaxWorldErr.TabIndex = 23
        Me.TextBoxMaxWorldErr.Text = "-1"
        Me.TextBoxMaxWorldErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxAVGPixelErr
        '
        Me.TextBoxAVGPixelErr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxAVGPixelErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAVGPixelErr.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxAVGPixelErr.Enabled = False
        Me.TextBoxAVGPixelErr.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAVGPixelErr.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TextBoxAVGPixelErr.Location = New System.Drawing.Point(192, 38)
        Me.TextBoxAVGPixelErr.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxAVGPixelErr.Name = "TextBoxAVGPixelErr"
        Me.TextBoxAVGPixelErr.ReadOnly = True
        Me.TextBoxAVGPixelErr.Size = New System.Drawing.Size(105, 26)
        Me.TextBoxAVGPixelErr.TabIndex = 19
        Me.TextBoxAVGPixelErr.Text = "-1"
        Me.TextBoxAVGPixelErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxMaxPixelErr
        '
        Me.TextBoxMaxPixelErr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBoxMaxPixelErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxMaxPixelErr.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxMaxPixelErr.Enabled = False
        Me.TextBoxMaxPixelErr.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMaxPixelErr.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TextBoxMaxPixelErr.Location = New System.Drawing.Point(192, 67)
        Me.TextBoxMaxPixelErr.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxMaxPixelErr.Name = "TextBoxMaxPixelErr"
        Me.TextBoxMaxPixelErr.ReadOnly = True
        Me.TextBoxMaxPixelErr.Size = New System.Drawing.Size(105, 26)
        Me.TextBoxMaxPixelErr.TabIndex = 21
        Me.TextBoxMaxPixelErr.Text = "-1"
        Me.TextBoxMaxPixelErr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBoxProgressControl
        '
        Me.GroupBoxProgressControl.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxProgressControl.Controls.Add(Me.LabelAcquisitionState)
        Me.GroupBoxProgressControl.Controls.Add(Me.LabelToolState)
        Me.GroupBoxProgressControl.Controls.Add(Me.LabelTool)
        Me.GroupBoxProgressControl.Controls.Add(Me.Label1)
        Me.GroupBoxProgressControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxProgressControl.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxProgressControl.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBoxProgressControl.Location = New System.Drawing.Point(407, 450)
        Me.GroupBoxProgressControl.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBoxProgressControl.Name = "GroupBoxProgressControl"
        Me.GroupBoxProgressControl.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBoxProgressControl.Size = New System.Drawing.Size(170, 198)
        Me.GroupBoxProgressControl.TabIndex = 46
        Me.GroupBoxProgressControl.TabStop = False
        '
        'LabelAcquisitionState
        '
        Me.LabelAcquisitionState.AutoSize = True
        Me.LabelAcquisitionState.Font = New System.Drawing.Font("Lucida Fax", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAcquisitionState.ForeColor = System.Drawing.Color.Black
        Me.LabelAcquisitionState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelAcquisitionState.Location = New System.Drawing.Point(32, 144)
        Me.LabelAcquisitionState.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAcquisitionState.Name = "LabelAcquisitionState"
        Me.LabelAcquisitionState.Size = New System.Drawing.Size(0, 24)
        Me.LabelAcquisitionState.TabIndex = 54
        Me.LabelAcquisitionState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelToolState
        '
        Me.LabelToolState.AutoSize = True
        Me.LabelToolState.Font = New System.Drawing.Font("Lucida Fax", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelToolState.ForeColor = System.Drawing.Color.Black
        Me.LabelToolState.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToolState.Location = New System.Drawing.Point(30, 56)
        Me.LabelToolState.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelToolState.Name = "LabelToolState"
        Me.LabelToolState.Size = New System.Drawing.Size(0, 24)
        Me.LabelToolState.TabIndex = 53
        Me.LabelToolState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelTool
        '
        Me.LabelTool.AutoSize = True
        Me.LabelTool.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTool.ForeColor = System.Drawing.Color.Brown
        Me.LabelTool.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTool.Location = New System.Drawing.Point(31, 24)
        Me.LabelTool.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTool.Name = "LabelTool"
        Me.LabelTool.Size = New System.Drawing.Size(94, 18)
        Me.LabelTool.TabIndex = 47
        Me.LabelTool.Text = "Tool State"
        Me.LabelTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(19, 118)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 18)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Camera State"
        '
        'LabelProgress
        '
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.ForeColor = System.Drawing.Color.Brown
        Me.LabelProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelProgress.Location = New System.Drawing.Point(7, 24)
        Me.LabelProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(82, 18)
        Me.LabelProgress.TabIndex = 54
        Me.LabelProgress.Text = "Next Dot"
        Me.LabelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonPLCOK
        '
        Me.ButtonPLCOK.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPLCOK.FlatAppearance.BorderSize = 0
        Me.ButtonPLCOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPLCOK.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPLCOK.ForeColor = System.Drawing.Color.Brown
        Me.ButtonPLCOK.Image = CType(resources.GetObject("ButtonPLCOK.Image"), System.Drawing.Image)
        Me.ButtonPLCOK.Location = New System.Drawing.Point(812, 378)
        Me.ButtonPLCOK.Name = "ButtonPLCOK"
        Me.ButtonPLCOK.Size = New System.Drawing.Size(98, 119)
        Me.ButtonPLCOK.TabIndex = 1
        Me.ButtonPLCOK.Text = "Simulate PLC Ok"
        Me.ButtonPLCOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonPLCOK.UseVisualStyleBackColor = False
        Me.ButtonPLCOK.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBoxICAP)
        Me.Panel1.Controls.Add(Me.HSApplicationControl)
        Me.Panel1.Location = New System.Drawing.Point(878, 555)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 98)
        Me.Panel1.TabIndex = 48
        '
        'PictureBoxICAP
        '
        Me.PictureBoxICAP.Image = CType(resources.GetObject("PictureBoxICAP.Image"), System.Drawing.Image)
        Me.PictureBoxICAP.Location = New System.Drawing.Point(4, 37)
        Me.PictureBoxICAP.Name = "PictureBoxICAP"
        Me.PictureBoxICAP.Size = New System.Drawing.Size(161, 45)
        Me.PictureBoxICAP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxICAP.TabIndex = 0
        Me.PictureBoxICAP.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LabelTotalPoints)
        Me.GroupBox1.Controls.Add(Me.LabelTimer)
        Me.GroupBox1.Controls.Add(Me.LabelTimerName)
        Me.GroupBox1.Controls.Add(Me.LabelDotCount)
        Me.GroupBox1.Controls.Add(Me.LabelProgress)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.GroupBox1.Location = New System.Drawing.Point(585, 450)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(119, 198)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'LabelTotalPoints
        '
        Me.LabelTotalPoints.Font = New System.Drawing.Font("Lucida Fax", 15.25!, System.Drawing.FontStyle.Bold)
        Me.LabelTotalPoints.ForeColor = System.Drawing.Color.Black
        Me.LabelTotalPoints.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTotalPoints.Location = New System.Drawing.Point(45, 45)
        Me.LabelTotalPoints.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTotalPoints.Name = "LabelTotalPoints"
        Me.LabelTotalPoints.Size = New System.Drawing.Size(66, 36)
        Me.LabelTotalPoints.TabIndex = 58
        Me.LabelTotalPoints.Text = "/"
        Me.LabelTotalPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTimer
        '
        Me.LabelTimer.AutoSize = True
        Me.LabelTimer.Font = New System.Drawing.Font("Lucida Fax", 15.25!, System.Drawing.FontStyle.Bold)
        Me.LabelTimer.ForeColor = System.Drawing.Color.Black
        Me.LabelTimer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTimer.Location = New System.Drawing.Point(39, 141)
        Me.LabelTimer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTimer.Name = "LabelTimer"
        Me.LabelTimer.Size = New System.Drawing.Size(31, 24)
        Me.LabelTimer.TabIndex = 57
        Me.LabelTimer.Text = "-1"
        Me.LabelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTimerName
        '
        Me.LabelTimerName.AutoSize = True
        Me.LabelTimerName.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTimerName.ForeColor = System.Drawing.Color.Brown
        Me.LabelTimerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTimerName.Location = New System.Drawing.Point(25, 118)
        Me.LabelTimerName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelTimerName.Name = "LabelTimerName"
        Me.LabelTimerName.Size = New System.Drawing.Size(60, 18)
        Me.LabelTimerName.TabIndex = 56
        Me.LabelTimerName.Text = "Timer"
        Me.LabelTimerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelDotCount
        '
        Me.LabelDotCount.Font = New System.Drawing.Font("Lucida Fax", 15.25!, System.Drawing.FontStyle.Bold)
        Me.LabelDotCount.ForeColor = System.Drawing.Color.Black
        Me.LabelDotCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelDotCount.Location = New System.Drawing.Point(-8, 45)
        Me.LabelDotCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDotCount.Name = "LabelDotCount"
        Me.LabelDotCount.Size = New System.Drawing.Size(59, 36)
        Me.LabelDotCount.TabIndex = 55
        Me.LabelDotCount.Text = "0"
        Me.LabelDotCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Fax", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Brown
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(356, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 18)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "HexSight Display"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(820, 626)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 27)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "save"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CancelButton = Me.ButtonQuit
        Me.ClientSize = New System.Drawing.Size(1047, 661)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonCameraShot)
        Me.Controls.Add(Me.ButtonPLCOK)
        Me.Controls.Add(Me.GroupBoxProgressControl)
        Me.Controls.Add(Me.GroupBoxCalibrationPerformance)
        Me.Controls.Add(Me.ButtonLocate)
        Me.Controls.Add(Me.ButtonTestCalibration)
        Me.Controls.Add(Me.GroupBoxCoordinateProjection)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.ButtonQuit)
        Me.Controls.Add(Me.ButtonCalibrate)
        Me.Controls.Add(Me.HSDisplay)
        Me.Controls.Add(Me.LabelCalibrationResult)
        Me.Controls.Add(Me.TextBoxCalibrationResult)
        Me.Controls.Add(Me.LabelCalibrationLoaded)
        Me.Controls.Add(Me.TextBoxCalibrationLoaded)
        Me.Controls.Add(Me.LabelGigECamera)
        Me.Controls.Add(Me.TextBox_GigE)
        Me.Controls.Add(Me.LabelLoadedConfig)
        Me.Controls.Add(Me.TextBoxLoadedConfig)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoTarget CALIB - Michele Ciciolla"
        Me.TopMost = True
        CType(Me.HSApplicationControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HSDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCoordinateProjection.ResumeLayout(False)
        Me.GroupBoxImageCoordinates.ResumeLayout(False)
        Me.GroupBoxImageCoordinates.PerformLayout()
        Me.GroupBoxWorldCoordinates.ResumeLayout(False)
        Me.GroupBoxWorldCoordinates.PerformLayout()
        Me.GroupBoxCalibrationPerformance.ResumeLayout(False)
        Me.GroupBoxCalibrationPerformance.PerformLayout()
        Me.GroupBoxProgressControl.ResumeLayout(False)
        Me.GroupBoxProgressControl.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBoxICAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HSApplicationControl As AxHSAPPLICATIONLib.AxHSApplication
    Friend WithEvents HSDisplay As AxHSDISPLAYLib.AxHSDisplay
    Friend WithEvents LabelCalibrationResult As Label
    Friend WithEvents TextBoxCalibrationResult As TextBox
    Friend WithEvents LabelCalibrationLoaded As Label
    Friend WithEvents TextBoxCalibrationLoaded As TextBox
    Friend WithEvents LabelGigECamera As Label
    Friend WithEvents TextBox_GigE As TextBox
    Friend WithEvents LabelLoadedConfig As Label
    Friend WithEvents TextBoxLoadedConfig As TextBox
    Friend WithEvents ButtonLocate As Button
    Friend WithEvents ButtonCalibrate As Button
    Friend WithEvents ButtonQuit As Button
    Friend WithEvents ButtonStart As Button
    Friend WithEvents GroupBoxCoordinateProjection As GroupBox
    Friend WithEvents ButtonCameraShot As Button
    Friend WithEvents GroupBoxImageCoordinates As GroupBox
    Friend WithEvents TextBoxImageY As TextBox
    Friend WithEvents TextBoxImageX As TextBox
    Friend WithEvents GroupBoxWorldCoordinates As GroupBox
    Friend WithEvents TextBoxWorldY As TextBox
    Friend WithEvents TextBoxWorldX As TextBox
    Friend WithEvents ButtonWorld2Image As Button
    Friend WithEvents ButtonImage2World As Button
    Friend WithEvents ButtonTestCalibration As Button
    Friend WithEvents GroupBoxCalibrationPerformance As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxAVGWorldErr As TextBox
    Friend WithEvents TextBoxMaxWorldErr As TextBox
    Friend WithEvents TextBoxAVGPixelErr As TextBox
    Friend WithEvents TextBoxMaxPixelErr As TextBox
    Friend WithEvents GroupBoxProgressControl As GroupBox
    Friend WithEvents LabelTool As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelToolState As Label
    Friend WithEvents LabelProgress As Label
    Friend WithEvents ButtonPLCOK As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBoxICAP As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelDotCount As Label
    Friend WithEvents LabelAcquisitionState As Label
    Friend WithEvents LabelTimer As Label
    Friend WithEvents LabelTimerName As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LabelTotalPoints As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
End Class
