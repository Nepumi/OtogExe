﻿namespace Otogexe
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
            this.SuspendLayout();
            // 
            // TaskSelect
            // 
            this.TaskSelect.Enabled = false;
            this.TaskSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskSelect.FormattingEnabled = true;
            this.TaskSelect.Items.AddRange(new object[] {
            "OTOGOTOG",
            "TestA",
            "1.asdjhv\'",
            "as2.asdlkjfjk"});
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
            this.DirOfSC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirOfSC.Location = new System.Drawing.Point(29, 132);
            this.DirOfSC.Name = "DirOfSC";
            this.DirOfSC.Size = new System.Drawing.Size(520, 34);
            this.DirOfSC.TabIndex = 3;
            this.DirOfSC.TextChanged += new System.EventHandler(this.DirOfSC_TextChanged);
            // 
            // DirBro
            // 
            this.DirBro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirBro.Location = new System.Drawing.Point(564, 133);
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
            this.Sub.Location = new System.Drawing.Point(29, 186);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(117, 69);
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
            this.ResLabel.AutoSize = true;
            this.ResLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResLabel.Location = new System.Drawing.Point(55, 386);
            this.ResLabel.Name = "ResLabel";
            this.ResLabel.Size = new System.Drawing.Size(91, 32);
            this.ResLabel.TabIndex = 6;
            this.ResLabel.Text = "Result :";
            // 
            // Res
            // 
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
            this.Commenttt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Commenttt.Location = new System.Drawing.Point(59, 508);
            this.Commenttt.Multiline = true;
            this.Commenttt.Name = "Commenttt";
            this.Commenttt.ReadOnly = true;
            this.Commenttt.Size = new System.Drawing.Size(570, 172);
            this.Commenttt.TabIndex = 9;
            // 
            // Help4
            // 
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
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "File :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Task :";
            // 
            // FileSubed
            // 
            this.FileSubed.AutoSize = true;
            this.FileSubed.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSubed.Location = new System.Drawing.Point(152, 354);
            this.FileSubed.Name = "FileSubed";
            this.FileSubed.Size = new System.Drawing.Size(0, 32);
            this.FileSubed.TabIndex = 16;
            // 
            // TaskSubed
            // 
            this.TaskSubed.AutoSize = true;
            this.TaskSubed.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskSubed.Location = new System.Drawing.Point(152, 323);
            this.TaskSubed.Name = "TaskSubed";
            this.TaskSubed.Size = new System.Drawing.Size(0, 32);
            this.TaskSubed.TabIndex = 17;
            // 
            // STWStart
            // 
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
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // STW_Dis
            // 
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
            this.GroupTaskSelect.Items.AddRange(new object[] {
            "OTOGOTOG",
            "TestA",
            "1.asdjhv\'",
            "as2.asdlkjfjk"});
            this.GroupTaskSelect.Location = new System.Drawing.Point(31, 68);
            this.GroupTaskSelect.Name = "GroupTaskSelect";
            this.GroupTaskSelect.Size = new System.Drawing.Size(252, 36);
            this.GroupTaskSelect.TabIndex = 0;
            this.GroupTaskSelect.TextChanged += new System.EventHandler(this.GroupTaskSelect_TextChanged);
            this.GroupTaskSelect.Click += new System.EventHandler(this.GroupTaskSelect_Click);
            // 
            // Otog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 700);
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
            this.Name = "Otog";
            this.Text = "Form1";
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
    }
}

