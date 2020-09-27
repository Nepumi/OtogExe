namespace Otogexe
{
    partial class Otog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Otog));
            this.TaskSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DirOfSC = new System.Windows.Forms.TextBox();
            this.DirBro = new System.Windows.Forms.Button();
            this.Sub = new System.Windows.Forms.Button();
            this.Sstate = new System.Windows.Forms.Label();
            this.ResLabel = new System.Windows.Forms.Label();
            this.Res = new System.Windows.Forms.Label();
            this.SpoilBut = new System.Windows.Forms.CheckBox();
            this.Commenttt = new System.Windows.Forms.TextBox();
            this.Help4 = new System.Windows.Forms.Button();
            this.JustUnder = new System.Windows.Forms.TextBox();
            this.Docu = new System.Windows.Forms.Button();
            this.Help3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FileSubed = new System.Windows.Forms.Label();
            this.TaskSubed = new System.Windows.Forms.Label();
            this.STWStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.STW_Dis = new System.Windows.Forms.Label();
            this.STW_Reset = new System.Windows.Forms.Button();
            this.GroupTaskSelect = new System.Windows.Forms.ComboBox();
            this.Warning = new System.Windows.Forms.Label();
            this.CurVer = new System.Windows.Forms.Label();
            this.TestModeCheck = new System.Windows.Forms.CheckBox();
            this.TestOutput = new System.Windows.Forms.TextBox();
            this.TestInput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.CheckBut = new System.Windows.Forms.Button();
            this.TimeLimitlabel = new System.Windows.Forms.Label();
            this.MemLimitlabel = new System.Windows.Forms.Label();
            this.PointLa = new System.Windows.Forms.Label();
            this.Poi = new System.Windows.Forms.Label();
            this.TimeLa = new System.Windows.Forms.Label();
            this.TimeUse = new System.Windows.Forms.Label();
            this.TimeLa2 = new System.Windows.Forms.Label();
            this.LangSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LangChan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TaskSelect
            // 
            this.TaskSelect.Enabled = false;
            this.TaskSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskSelect.FormattingEnabled = true;
            this.TaskSelect.Location = new System.Drawing.Point(297, 68);
            this.TaskSelect.Name = "TaskSelect";
            this.TaskSelect.Size = new System.Drawing.Size(252, 36);
            this.TaskSelect.TabIndex = 1;
            this.TaskSelect.TextChanged += new System.EventHandler(this.TaskSelect_TextChanged);
            this.TaskSelect.Click += new System.EventHandler(this.TaskSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task";
            // 
            // DirOfSC
            // 
            this.DirOfSC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirOfSC.Location = new System.Drawing.Point(158, 147);
            this.DirOfSC.Name = "DirOfSC";
            this.DirOfSC.Size = new System.Drawing.Size(391, 27);
            this.DirOfSC.TabIndex = 3;
            this.DirOfSC.TextChanged += new System.EventHandler(this.DirOfSC_TextChanged);
            // 
            // DirBro
            // 
            this.DirBro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirBro.Location = new System.Drawing.Point(563, 147);
            this.DirBro.Name = "DirBro";
            this.DirBro.Size = new System.Drawing.Size(109, 34);
            this.DirBro.TabIndex = 4;
            this.DirBro.Text = "browse";
            this.DirBro.UseVisualStyleBackColor = true;
            this.DirBro.Click += new System.EventHandler(this.DirBro_Click);
            // 
            // Sub
            // 
            this.Sub.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sub.Location = new System.Drawing.Point(29, 187);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(117, 68);
            this.Sub.TabIndex = 5;
            this.Sub.Text = "SUBMIT!";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // Sstate
            // 
            this.Sstate.AutoSize = true;
            this.Sstate.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sstate.ForeColor = System.Drawing.Color.IndianRed;
            this.Sstate.Location = new System.Drawing.Point(31, 259);
            this.Sstate.Name = "Sstate";
            this.Sstate.Size = new System.Drawing.Size(150, 38);
            this.Sstate.TabIndex = 5;
            this.Sstate.Text = "Select Task";
            // 
            // ResLabel
            // 
            this.ResLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResLabel.Location = new System.Drawing.Point(61, 385);
            this.ResLabel.Name = "ResLabel";
            this.ResLabel.Size = new System.Drawing.Size(91, 32);
            this.ResLabel.TabIndex = 6;
            this.ResLabel.Text = "Result :";
            this.ResLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Res
            // 
            this.Res.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Res.AutoSize = true;
            this.Res.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Res.Location = new System.Drawing.Point(152, 386);
            this.Res.Name = "Res";
            this.Res.Size = new System.Drawing.Size(29, 32);
            this.Res.TabIndex = 7;
            this.Res.Text = "[]";
            // 
            // SpoilBut
            // 
            this.SpoilBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpoilBut.AutoSize = true;
            this.SpoilBut.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpoilBut.Location = new System.Drawing.Point(61, 456);
            this.SpoilBut.Name = "SpoilBut";
            this.SpoilBut.Size = new System.Drawing.Size(154, 27);
            this.SpoilBut.TabIndex = 8;
            this.SpoilBut.Text = "Show Comment";
            this.SpoilBut.UseVisualStyleBackColor = true;
            this.SpoilBut.CheckedChanged += new System.EventHandler(this.SpoilBut_CheckedChanged);
            // 
            // Commenttt
            // 
            this.Commenttt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Commenttt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Commenttt.Location = new System.Drawing.Point(59, 508);
            this.Commenttt.Multiline = true;
            this.Commenttt.Name = "Commenttt";
            this.Commenttt.ReadOnly = true;
            this.Commenttt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Commenttt.Size = new System.Drawing.Size(570, 144);
            this.Commenttt.TabIndex = 9;
            // 
            // Help4
            // 
            this.Help4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Help4.Location = new System.Drawing.Point(564, 322);
            this.Help4.Name = "Help4";
            this.Help4.Size = new System.Drawing.Size(108, 33);
            this.Help4.TabIndex = 10;
            this.Help4.Text = "อีหยังวะ";
            this.Help4.UseVisualStyleBackColor = true;
            this.Help4.Click += new System.EventHandler(this.Help4_Click);
            // 
            // JustUnder
            // 
            this.JustUnder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.JustUnder.Font = new System.Drawing.Font("Segoe UI", 1.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JustUnder.Location = new System.Drawing.Point(29, 306);
            this.JustUnder.Name = "JustUnder";
            this.JustUnder.ReadOnly = true;
            this.JustUnder.Size = new System.Drawing.Size(643, 10);
            this.JustUnder.TabIndex = 11;
            // 
            // Docu
            // 
            this.Docu.Enabled = false;
            this.Docu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Docu.Location = new System.Drawing.Point(564, 68);
            this.Docu.Name = "Docu";
            this.Docu.Size = new System.Drawing.Size(109, 34);
            this.Docu.TabIndex = 2;
            this.Docu.Text = "Doc";
            this.Docu.UseVisualStyleBackColor = true;
            this.Docu.Click += new System.EventHandler(this.Docu_Click);
            // 
            // Help3
            // 
            this.Help3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Help3.Location = new System.Drawing.Point(564, 267);
            this.Help3.Name = "Help3";
            this.Help3.Size = new System.Drawing.Size(108, 33);
            this.Help3.TabIndex = 9;
            this.Help3.Text = "อีหยังวะ";
            this.Help3.UseVisualStyleBackColor = true;
            this.Help3.Click += new System.EventHandler(this.Help3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "File :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Task :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FileSubed
            // 
            this.FileSubed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FileSubed.AutoSize = true;
            this.FileSubed.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSubed.Location = new System.Drawing.Point(152, 354);
            this.FileSubed.Name = "FileSubed";
            this.FileSubed.Size = new System.Drawing.Size(0, 32);
            this.FileSubed.TabIndex = 16;
            // 
            // TaskSubed
            // 
            this.TaskSubed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TaskSubed.AutoSize = true;
            this.TaskSubed.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskSubed.Location = new System.Drawing.Point(152, 323);
            this.TaskSubed.Name = "TaskSubed";
            this.TaskSubed.Size = new System.Drawing.Size(0, 32);
            this.TaskSubed.TabIndex = 17;
            // 
            // STWStart
            // 
            this.STWStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.STWStart.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STWStart.Location = new System.Drawing.Point(564, 224);
            this.STWStart.Name = "STWStart";
            this.STWStart.Size = new System.Drawing.Size(108, 31);
            this.STWStart.TabIndex = 6;
            this.STWStart.Text = "Start Clock";
            this.STWStart.UseVisualStyleBackColor = true;
            this.STWStart.Click += new System.EventHandler(this.STWStart_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // STW_Dis
            // 
            this.STW_Dis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.STW_Dis.AutoSize = true;
            this.STW_Dis.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STW_Dis.Location = new System.Drawing.Point(362, 209);
            this.STW_Dis.Name = "STW_Dis";
            this.STW_Dis.Size = new System.Drawing.Size(196, 46);
            this.STW_Dis.TabIndex = 19;
            this.STW_Dis.Text = "00:00:00.00";
            this.STW_Dis.Visible = false;
            // 
            // STW_Reset
            // 
            this.STW_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.STW_Reset.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STW_Reset.Location = new System.Drawing.Point(363, 267);
            this.STW_Reset.Name = "STW_Reset";
            this.STW_Reset.Size = new System.Drawing.Size(195, 30);
            this.STW_Reset.TabIndex = 7;
            this.STW_Reset.Text = "Reset Clock";
            this.STW_Reset.UseVisualStyleBackColor = true;
            this.STW_Reset.Visible = false;
            this.STW_Reset.Click += new System.EventHandler(this.STW_Reset_Click);
            // 
            // GroupTaskSelect
            // 
            this.GroupTaskSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTaskSelect.FormattingEnabled = true;
            this.GroupTaskSelect.Location = new System.Drawing.Point(31, 68);
            this.GroupTaskSelect.Name = "GroupTaskSelect";
            this.GroupTaskSelect.Size = new System.Drawing.Size(252, 36);
            this.GroupTaskSelect.TabIndex = 0;
            this.GroupTaskSelect.TextChanged += new System.EventHandler(this.GroupTaskSelect_TextChanged);
            this.GroupTaskSelect.Click += new System.EventHandler(this.GroupTaskSelect_Click);
            // 
            // Warning
            // 
            this.Warning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Warning.AutoSize = true;
            this.Warning.Font = new System.Drawing.Font("Browallia New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Warning.ForeColor = System.Drawing.Color.Red;
            this.Warning.Location = new System.Drawing.Point(55, 656);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(0, 35);
            this.Warning.TabIndex = 20;
            // 
            // CurVer
            // 
            this.CurVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CurVer.AutoSize = true;
            this.CurVer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurVer.Location = new System.Drawing.Point(333, 20);
            this.CurVer.Name = "CurVer";
            this.CurVer.Size = new System.Drawing.Size(100, 28);
            this.CurVer.TabIndex = 21;
            this.CurVer.Text = "Beta 0.0.4";
            this.CurVer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TestModeCheck
            // 
            this.TestModeCheck.AutoSize = true;
            this.TestModeCheck.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestModeCheck.Location = new System.Drawing.Point(152, 224);
            this.TestModeCheck.Name = "TestModeCheck";
            this.TestModeCheck.Size = new System.Drawing.Size(105, 27);
            this.TestModeCheck.TabIndex = 24;
            this.TestModeCheck.Text = "TestMode";
            this.TestModeCheck.UseVisualStyleBackColor = true;
            this.TestModeCheck.CheckedChanged += new System.EventHandler(this.TestModeCheck_CheckedChanged);
            // 
            // TestOutput
            // 
            this.TestOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestOutput.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestOutput.Location = new System.Drawing.Point(344, 547);
            this.TestOutput.Multiline = true;
            this.TestOutput.Name = "TestOutput";
            this.TestOutput.ReadOnly = true;
            this.TestOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TestOutput.Size = new System.Drawing.Size(285, 105);
            this.TestOutput.TabIndex = 25;
            this.TestOutput.Visible = false;
            // 
            // TestInput
            // 
            this.TestInput.AcceptsReturn = true;
            this.TestInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestInput.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestInput.Location = new System.Drawing.Point(59, 547);
            this.TestInput.Multiline = true;
            this.TestInput.Name = "TestInput";
            this.TestInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TestInput.Size = new System.Drawing.Size(288, 105);
            this.TestInput.TabIndex = 26;
            this.TestInput.Visible = false;
            this.TestInput.WordWrap = false;
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutput.Location = new System.Drawing.Point(349, 516);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(76, 28);
            this.labelOutput.TabIndex = 27;
            this.labelOutput.Text = "Output";
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelOutput.Visible = false;
            // 
            // labelInput
            // 
            this.labelInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInput.AutoSize = true;
            this.labelInput.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInput.Location = new System.Drawing.Point(70, 516);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(60, 28);
            this.labelInput.TabIndex = 28;
            this.labelInput.Text = "Input";
            this.labelInput.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelInput.Visible = false;
            // 
            // CheckBut
            // 
            this.CheckBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBut.Location = new System.Drawing.Point(443, 17);
            this.CheckBut.Name = "CheckBut";
            this.CheckBut.Size = new System.Drawing.Size(109, 39);
            this.CheckBut.TabIndex = 29;
            this.CheckBut.Text = "Check Update";
            this.CheckBut.UseVisualStyleBackColor = true;
            this.CheckBut.Click += new System.EventHandler(this.CheckBut_Click);
            // 
            // TimeLimitlabel
            // 
            this.TimeLimitlabel.AutoSize = true;
            this.TimeLimitlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLimitlabel.ForeColor = System.Drawing.Color.Tomato;
            this.TimeLimitlabel.Location = new System.Drawing.Point(292, 116);
            this.TimeLimitlabel.Name = "TimeLimitlabel";
            this.TimeLimitlabel.Size = new System.Drawing.Size(83, 28);
            this.TimeLimitlabel.TabIndex = 31;
            this.TimeLimitlabel.Text = "Time: 1s";
            this.TimeLimitlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.TimeLimitlabel.Visible = false;
            // 
            // MemLimitlabel
            // 
            this.MemLimitlabel.AutoSize = true;
            this.MemLimitlabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemLimitlabel.ForeColor = System.Drawing.Color.Tomato;
            this.MemLimitlabel.Location = new System.Drawing.Point(425, 116);
            this.MemLimitlabel.Name = "MemLimitlabel";
            this.MemLimitlabel.Size = new System.Drawing.Size(127, 28);
            this.MemLimitlabel.TabIndex = 32;
            this.MemLimitlabel.Text = "Mem: 256mb";
            this.MemLimitlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.MemLimitlabel.Visible = false;
            // 
            // PointLa
            // 
            this.PointLa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PointLa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointLa.Location = new System.Drawing.Point(69, 418);
            this.PointLa.Name = "PointLa";
            this.PointLa.Size = new System.Drawing.Size(81, 32);
            this.PointLa.TabIndex = 33;
            this.PointLa.Text = "Point :";
            this.PointLa.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Poi
            // 
            this.Poi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Poi.AutoSize = true;
            this.Poi.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Poi.Location = new System.Drawing.Point(146, 418);
            this.Poi.Name = "Poi";
            this.Poi.Size = new System.Drawing.Size(28, 32);
            this.Poi.TabIndex = 34;
            this.Poi.Text = "0";
            // 
            // TimeLa
            // 
            this.TimeLa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeLa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLa.Location = new System.Drawing.Point(240, 418);
            this.TimeLa.Name = "TimeLa";
            this.TimeLa.Size = new System.Drawing.Size(73, 32);
            this.TimeLa.TabIndex = 35;
            this.TimeLa.Text = "Time:";
            this.TimeLa.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeUse
            // 
            this.TimeUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeUse.AutoSize = true;
            this.TimeUse.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeUse.Location = new System.Drawing.Point(319, 418);
            this.TimeUse.Name = "TimeUse";
            this.TimeUse.Size = new System.Drawing.Size(28, 32);
            this.TimeUse.TabIndex = 36;
            this.TimeUse.Text = "0";
            this.TimeUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeLa2
            // 
            this.TimeLa2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeLa2.AutoSize = true;
            this.TimeLa2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLa2.Location = new System.Drawing.Point(397, 418);
            this.TimeLa2.Name = "TimeLa2";
            this.TimeLa2.Size = new System.Drawing.Size(46, 32);
            this.TimeLa2.TabIndex = 37;
            this.TimeLa2.Text = "ms";
            // 
            // LangSelect
            // 
            this.LangSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LangSelect.FormattingEnabled = true;
            this.LangSelect.Items.AddRange(new object[] {
            "C",
            "C++",
            "Python"});
            this.LangSelect.Location = new System.Drawing.Point(31, 145);
            this.LangSelect.Name = "LangSelect";
            this.LangSelect.Size = new System.Drawing.Size(113, 36);
            this.LangSelect.TabIndex = 38;
            this.LangSelect.Text = "Python";
            this.LangSelect.SelectedIndexChanged += new System.EventHandler(this.LangSelect_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 30);
            this.label4.TabIndex = 39;
            this.label4.Text = "Lang";
            // 
            // LangChan
            // 
            this.LangChan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LangChan.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LangChan.Location = new System.Drawing.Point(564, 17);
            this.LangChan.Name = "LangChan";
            this.LangChan.Size = new System.Drawing.Size(109, 39);
            this.LangChan.TabIndex = 40;
            this.LangChan.Text = "ภาษาไทย";
            this.LangChan.UseVisualStyleBackColor = true;
            this.LangChan.Click += new System.EventHandler(this.LangChan_Click);
            // 
            // Otog
            // 
            this.AcceptButton = this.Help3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 724);
            this.Controls.Add(this.LangChan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LangSelect);
            this.Controls.Add(this.TimeLa2);
            this.Controls.Add(this.TimeUse);
            this.Controls.Add(this.TimeLa);
            this.Controls.Add(this.Poi);
            this.Controls.Add(this.PointLa);
            this.Controls.Add(this.MemLimitlabel);
            this.Controls.Add(this.TimeLimitlabel);
            this.Controls.Add(this.CheckBut);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.TestInput);
            this.Controls.Add(this.TestOutput);
            this.Controls.Add(this.TestModeCheck);
            this.Controls.Add(this.CurVer);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.GroupTaskSelect);
            this.Controls.Add(this.STW_Reset);
            this.Controls.Add(this.STW_Dis);
            this.Controls.Add(this.STWStart);
            this.Controls.Add(this.TaskSubed);
            this.Controls.Add(this.FileSubed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Help3);
            this.Controls.Add(this.Docu);
            this.Controls.Add(this.JustUnder);
            this.Controls.Add(this.Help4);
            this.Controls.Add(this.Commenttt);
            this.Controls.Add(this.SpoilBut);
            this.Controls.Add(this.Res);
            this.Controls.Add(this.ResLabel);
            this.Controls.Add(this.Sstate);
            this.Controls.Add(this.Sub);
            this.Controls.Add(this.DirBro);
            this.Controls.Add(this.DirOfSC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TaskSelect);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Otog";
            this.Text = "Otog Exe";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TaskSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DirOfSC;
        private System.Windows.Forms.Button DirBro;
        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.Label Sstate;
        private System.Windows.Forms.Label ResLabel;
        private System.Windows.Forms.Label Res;
        private System.Windows.Forms.CheckBox SpoilBut;
        private System.Windows.Forms.TextBox Commenttt;
        private System.Windows.Forms.Button Help4;
        private System.Windows.Forms.TextBox JustUnder;
        private System.Windows.Forms.Button Docu;
        private System.Windows.Forms.Button Help3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FileSubed;
        private System.Windows.Forms.Label TaskSubed;
        private System.Windows.Forms.Button STWStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label STW_Dis;
        private System.Windows.Forms.Button STW_Reset;
        private System.Windows.Forms.ComboBox GroupTaskSelect;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.Label CurVer;
        private System.Windows.Forms.CheckBox TestModeCheck;
        private System.Windows.Forms.TextBox TestOutput;
        private System.Windows.Forms.TextBox TestInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Button CheckBut;
        private System.Windows.Forms.Label TimeLimitlabel;
        private System.Windows.Forms.Label MemLimitlabel;
        private System.Windows.Forms.Label PointLa;
        private System.Windows.Forms.Label Poi;
        private System.Windows.Forms.Label TimeLa;
        private System.Windows.Forms.Label TimeUse;
        private System.Windows.Forms.Label TimeLa2;
        private System.Windows.Forms.ComboBox LangSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LangChan;
    }
}

