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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.path_disp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar_read = New System.Windows.Forms.ProgressBar()
        Me.units = New System.Windows.Forms.CheckBox()
        Me.points = New System.Windows.Forms.CheckBox()
        Me.element_conn = New System.Windows.Forms.CheckBox()
        Me.sections = New System.Windows.Forms.CheckBox()
        Me.constraints = New System.Windows.Forms.CheckBox()
        Me.material = New System.Windows.Forms.CheckBox()
        Me.story = New System.Windows.Forms.CheckBox()
        Me.section_assignment = New System.Windows.Forms.CheckBox()
        Me.point_loads = New System.Windows.Forms.CheckBox()
        Me.area_loading = New System.Windows.Forms.CheckBox()
        Me.thicknesses = New System.Windows.Forms.CheckBox()
        Me.area_conn = New System.Windows.Forms.CheckBox()
        Me.area_ass = New System.Windows.Forms.CheckBox()
        Me.line_loads = New System.Windows.Forms.CheckBox()
        Me.load_pattern = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.POINT_SPRING = New System.Windows.Forms.CheckBox()
        Me.SURFACE_SPRING = New System.Windows.Forms.CheckBox()
        Me.point_disp_load = New System.Windows.Forms.CheckBox()
        Me.unifloadset = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar_writing = New System.Windows.Forms.ProgressBar()
        Me.browse_button = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.MeshBar = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Process_Text = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.MeshBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Constantia", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(442, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ETABS/SAFE  ->  MIDAS GEN"
        '
        'path_disp
        '
        Me.path_disp.Location = New System.Drawing.Point(8, 40)
        Me.path_disp.Name = "path_disp"
        Me.path_disp.Size = New System.Drawing.Size(775, 20)
        Me.path_disp.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(13, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(775, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "CONVERT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "NO_FILE_SELECTED"
        '
        'ProgressBar_read
        '
        Me.ProgressBar_read.Location = New System.Drawing.Point(13, 384)
        Me.ProgressBar_read.Name = "ProgressBar_read"
        Me.ProgressBar_read.Size = New System.Drawing.Size(770, 23)
        Me.ProgressBar_read.TabIndex = 3
        '
        'units
        '
        Me.units.AutoSize = True
        Me.units.Enabled = False
        Me.units.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units.Location = New System.Drawing.Point(31, 243)
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(64, 17)
        Me.units.TabIndex = 4
        Me.units.TabStop = False
        Me.units.Text = "UNITS"
        Me.units.UseVisualStyleBackColor = True
        '
        'points
        '
        Me.points.AutoSize = True
        Me.points.Enabled = False
        Me.points.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.points.Location = New System.Drawing.Point(31, 289)
        Me.points.Name = "points"
        Me.points.Size = New System.Drawing.Size(72, 17)
        Me.points.TabIndex = 5
        Me.points.TabStop = False
        Me.points.Text = "POINTS"
        Me.points.UseVisualStyleBackColor = True
        '
        'element_conn
        '
        Me.element_conn.AutoSize = True
        Me.element_conn.Enabled = False
        Me.element_conn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.element_conn.Location = New System.Drawing.Point(31, 312)
        Me.element_conn.Name = "element_conn"
        Me.element_conn.Size = New System.Drawing.Size(179, 17)
        Me.element_conn.TabIndex = 6
        Me.element_conn.TabStop = False
        Me.element_conn.Text = "ELEMENT CONNECTIVITY"
        Me.element_conn.UseVisualStyleBackColor = True
        '
        'sections
        '
        Me.sections.AutoSize = True
        Me.sections.Enabled = False
        Me.sections.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sections.Location = New System.Drawing.Point(222, 18)
        Me.sections.Name = "sections"
        Me.sections.Size = New System.Drawing.Size(150, 17)
        Me.sections.TabIndex = 7
        Me.sections.TabStop = False
        Me.sections.Text = "ELEMENT SECTIONS"
        Me.sections.UseVisualStyleBackColor = True
        '
        'constraints
        '
        Me.constraints.AutoSize = True
        Me.constraints.Enabled = False
        Me.constraints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.constraints.Location = New System.Drawing.Point(222, 41)
        Me.constraints.Name = "constraints"
        Me.constraints.Size = New System.Drawing.Size(114, 17)
        Me.constraints.TabIndex = 8
        Me.constraints.TabStop = False
        Me.constraints.Text = "CONSTRAINTS"
        Me.constraints.UseVisualStyleBackColor = True
        '
        'material
        '
        Me.material.AutoSize = True
        Me.material.Enabled = False
        Me.material.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.Location = New System.Drawing.Point(222, 64)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(159, 17)
        Me.material.TabIndex = 9
        Me.material.TabStop = False
        Me.material.Text = "MATERIAL PROPERTY"
        Me.material.UseVisualStyleBackColor = True
        '
        'story
        '
        Me.story.AutoSize = True
        Me.story.Enabled = False
        Me.story.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.story.Location = New System.Drawing.Point(31, 266)
        Me.story.Name = "story"
        Me.story.Size = New System.Drawing.Size(105, 17)
        Me.story.TabIndex = 10
        Me.story.TabStop = False
        Me.story.Text = "STORY DATA"
        Me.story.UseVisualStyleBackColor = True
        '
        'section_assignment
        '
        Me.section_assignment.AutoSize = True
        Me.section_assignment.Enabled = False
        Me.section_assignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.section_assignment.Location = New System.Drawing.Point(222, 87)
        Me.section_assignment.Name = "section_assignment"
        Me.section_assignment.Size = New System.Drawing.Size(165, 17)
        Me.section_assignment.TabIndex = 11
        Me.section_assignment.TabStop = False
        Me.section_assignment.Text = "SECTION ASSIGNEMNT"
        Me.section_assignment.UseVisualStyleBackColor = True
        '
        'point_loads
        '
        Me.point_loads.AutoSize = True
        Me.point_loads.Enabled = False
        Me.point_loads.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.point_loads.Location = New System.Drawing.Point(402, 41)
        Me.point_loads.Name = "point_loads"
        Me.point_loads.Size = New System.Drawing.Size(109, 17)
        Me.point_loads.TabIndex = 18
        Me.point_loads.TabStop = False
        Me.point_loads.Text = "POINT LOADS"
        Me.point_loads.UseVisualStyleBackColor = True
        '
        'area_loading
        '
        Me.area_loading.AutoSize = True
        Me.area_loading.Enabled = False
        Me.area_loading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.area_loading.Location = New System.Drawing.Point(569, 64)
        Me.area_loading.Name = "area_loading"
        Me.area_loading.Size = New System.Drawing.Size(118, 17)
        Me.area_loading.TabIndex = 17
        Me.area_loading.TabStop = False
        Me.area_loading.Text = "AREA LOADING"
        Me.area_loading.UseVisualStyleBackColor = True
        '
        'thicknesses
        '
        Me.thicknesses.AutoSize = True
        Me.thicknesses.Enabled = False
        Me.thicknesses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thicknesses.Location = New System.Drawing.Point(569, 41)
        Me.thicknesses.Name = "thicknesses"
        Me.thicknesses.Size = New System.Drawing.Size(112, 17)
        Me.thicknesses.TabIndex = 16
        Me.thicknesses.TabStop = False
        Me.thicknesses.Text = "THICKNESSES"
        Me.thicknesses.UseVisualStyleBackColor = True
        '
        'area_conn
        '
        Me.area_conn.AutoSize = True
        Me.area_conn.Enabled = False
        Me.area_conn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.area_conn.Location = New System.Drawing.Point(569, 18)
        Me.area_conn.Name = "area_conn"
        Me.area_conn.Size = New System.Drawing.Size(154, 17)
        Me.area_conn.TabIndex = 15
        Me.area_conn.TabStop = False
        Me.area_conn.Text = "AREA CONNECTIVITY"
        Me.area_conn.UseVisualStyleBackColor = True
        '
        'area_ass
        '
        Me.area_ass.AutoSize = True
        Me.area_ass.Enabled = False
        Me.area_ass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.area_ass.Location = New System.Drawing.Point(402, 87)
        Me.area_ass.Name = "area_ass"
        Me.area_ass.Size = New System.Drawing.Size(152, 17)
        Me.area_ass.TabIndex = 14
        Me.area_ass.TabStop = False
        Me.area_ass.Text = "AREA ASSIGNMENTS"
        Me.area_ass.UseVisualStyleBackColor = True
        '
        'line_loads
        '
        Me.line_loads.AutoSize = True
        Me.line_loads.Enabled = False
        Me.line_loads.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.line_loads.Location = New System.Drawing.Point(402, 64)
        Me.line_loads.Name = "line_loads"
        Me.line_loads.Size = New System.Drawing.Size(99, 17)
        Me.line_loads.TabIndex = 13
        Me.line_loads.TabStop = False
        Me.line_loads.Text = "LINE LOADS"
        Me.line_loads.UseVisualStyleBackColor = True
        '
        'load_pattern
        '
        Me.load_pattern.AutoSize = True
        Me.load_pattern.Enabled = False
        Me.load_pattern.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.load_pattern.Location = New System.Drawing.Point(402, 18)
        Me.load_pattern.Name = "load_pattern"
        Me.load_pattern.Size = New System.Drawing.Size(129, 17)
        Me.load_pattern.TabIndex = 12
        Me.load_pattern.TabStop = False
        Me.load_pattern.Text = "LOAD PATTERNS"
        Me.load_pattern.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 366)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 49)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reading"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.POINT_SPRING)
        Me.GroupBox2.Controls.Add(Me.SURFACE_SPRING)
        Me.GroupBox2.Controls.Add(Me.point_disp_load)
        Me.GroupBox2.Controls.Add(Me.unifloadset)
        Me.GroupBox2.Controls.Add(Me.load_pattern)
        Me.GroupBox2.Controls.Add(Me.line_loads)
        Me.GroupBox2.Controls.Add(Me.area_ass)
        Me.GroupBox2.Controls.Add(Me.area_conn)
        Me.GroupBox2.Controls.Add(Me.thicknesses)
        Me.GroupBox2.Controls.Add(Me.area_loading)
        Me.GroupBox2.Controls.Add(Me.section_assignment)
        Me.GroupBox2.Controls.Add(Me.point_loads)
        Me.GroupBox2.Controls.Add(Me.sections)
        Me.GroupBox2.Controls.Add(Me.material)
        Me.GroupBox2.Controls.Add(Me.constraints)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(729, 135)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Read"
        '
        'POINT_SPRING
        '
        Me.POINT_SPRING.AutoSize = True
        Me.POINT_SPRING.Enabled = False
        Me.POINT_SPRING.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.POINT_SPRING.Location = New System.Drawing.Point(402, 110)
        Me.POINT_SPRING.Name = "POINT_SPRING"
        Me.POINT_SPRING.Size = New System.Drawing.Size(115, 17)
        Me.POINT_SPRING.TabIndex = 21
        Me.POINT_SPRING.Text = "POINT SPRING"
        Me.POINT_SPRING.UseVisualStyleBackColor = True
        '
        'SURFACE_SPRING
        '
        Me.SURFACE_SPRING.AutoSize = True
        Me.SURFACE_SPRING.Enabled = False
        Me.SURFACE_SPRING.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SURFACE_SPRING.Location = New System.Drawing.Point(222, 110)
        Me.SURFACE_SPRING.Name = "SURFACE_SPRING"
        Me.SURFACE_SPRING.Size = New System.Drawing.Size(134, 17)
        Me.SURFACE_SPRING.TabIndex = 20
        Me.SURFACE_SPRING.Text = "SURFACE SPRING"
        Me.SURFACE_SPRING.UseVisualStyleBackColor = True
        '
        'point_disp_load
        '
        Me.point_disp_load.AutoSize = True
        Me.point_disp_load.Enabled = False
        Me.point_disp_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.point_disp_load.Location = New System.Drawing.Point(30, 112)
        Me.point_disp_load.Name = "point_disp_load"
        Me.point_disp_load.Size = New System.Drawing.Size(163, 17)
        Me.point_disp_load.TabIndex = 19
        Me.point_disp_load.Text = "POINT DISPLACEMENT"
        Me.point_disp_load.UseVisualStyleBackColor = True
        '
        'unifloadset
        '
        Me.unifloadset.AutoSize = True
        Me.unifloadset.Enabled = False
        Me.unifloadset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unifloadset.Location = New System.Drawing.Point(569, 86)
        Me.unifloadset.Name = "unifloadset"
        Me.unifloadset.Size = New System.Drawing.Size(148, 17)
        Me.unifloadset.TabIndex = 0
        Me.unifloadset.Text = "UNIFORM LOAD SET"
        Me.unifloadset.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 502)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(333, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Output file is generated in the same folder, where input file is provided"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ProgressBar_writing)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 447)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(787, 52)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Writing"
        '
        'ProgressBar_writing
        '
        Me.ProgressBar_writing.Location = New System.Drawing.Point(12, 20)
        Me.ProgressBar_writing.Name = "ProgressBar_writing"
        Me.ProgressBar_writing.Size = New System.Drawing.Size(769, 23)
        Me.ProgressBar_writing.TabIndex = 0
        '
        'browse_button
        '
        Me.browse_button.Location = New System.Drawing.Point(361, 51)
        Me.browse_button.Name = "browse_button"
        Me.browse_button.Size = New System.Drawing.Size(94, 23)
        Me.browse_button.TabIndex = 27
        Me.browse_button.Text = "Browse"
        Me.browse_button.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(717, 502)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(736, 230)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(52, 106)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "Notes"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(118, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Import file  ETABS:  .e2k OR .$et "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(501, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Import file  SAFE:   .f2k"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.path_disp)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 42)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(788, 70)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        '
        'MeshBar
        '
        Me.MeshBar.Location = New System.Drawing.Point(7, 118)
        Me.MeshBar.Maximum = 35
        Me.MeshBar.Minimum = 1
        Me.MeshBar.Name = "MeshBar"
        Me.MeshBar.Size = New System.Drawing.Size(791, 45)
        Me.MeshBar.TabIndex = 0
        Me.MeshBar.Value = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(299, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Mesh Smooting      :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(426, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(464, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Percent"
        '
        'Process_Text
        '
        Me.Process_Text.AutoSize = True
        Me.Process_Text.Location = New System.Drawing.Point(358, 431)
        Me.Process_Text.Name = "Process_Text"
        Me.Process_Text.Size = New System.Drawing.Size(23, 13)
        Me.Process_Text.TabIndex = 33
        Me.Process_Text.Text = "...."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 545)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Process_Text)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.browse_button)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.story)
        Me.Controls.Add(Me.element_conn)
        Me.Controls.Add(Me.points)
        Me.Controls.Add(Me.units)
        Me.Controls.Add(Me.ProgressBar_read)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.MeshBar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "CONVERTER"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.MeshBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar_read As System.Windows.Forms.ProgressBar
    Friend WithEvents units As System.Windows.Forms.CheckBox
    Friend WithEvents points As System.Windows.Forms.CheckBox
    Friend WithEvents element_conn As System.Windows.Forms.CheckBox
    Friend WithEvents sections As System.Windows.Forms.CheckBox
    Friend WithEvents constraints As System.Windows.Forms.CheckBox
    Friend WithEvents material As System.Windows.Forms.CheckBox
    Friend WithEvents story As System.Windows.Forms.CheckBox
    Friend WithEvents section_assignment As System.Windows.Forms.CheckBox
    Friend WithEvents point_loads As System.Windows.Forms.CheckBox
    Friend WithEvents area_loading As System.Windows.Forms.CheckBox
    Friend WithEvents thicknesses As System.Windows.Forms.CheckBox
    Friend WithEvents area_conn As System.Windows.Forms.CheckBox
    Friend WithEvents area_ass As System.Windows.Forms.CheckBox
    Friend WithEvents line_loads As System.Windows.Forms.CheckBox
    Friend WithEvents load_pattern As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar_writing As System.Windows.Forms.ProgressBar
    Friend WithEvents browse_button As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents unifloadset As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents path_disp As TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents point_disp_load As System.Windows.Forms.CheckBox
    Friend WithEvents SURFACE_SPRING As System.Windows.Forms.CheckBox
    Friend WithEvents POINT_SPRING As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents MeshBar As TrackBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Process_Text As System.Windows.Forms.Label
End Class
