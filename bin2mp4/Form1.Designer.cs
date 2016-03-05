namespace bin2mp4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.targetVersionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropZone = new System.Windows.Forms.Panel();
            this.dropZone2 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.dropZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Location = new System.Drawing.Point(17, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(14, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a file!";
            // 
            // targetVersionBox
            // 
            this.targetVersionBox.BackColor = System.Drawing.Color.Gray;
            this.targetVersionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetVersionBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.targetVersionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetVersionBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.targetVersionBox.FormattingEnabled = true;
            this.targetVersionBox.Items.AddRange(new object[] {
            "5.3.2",
            "5.4.0",
            "5.5.0",
            "5.5.1"});
            this.targetVersionBox.Location = new System.Drawing.Point(343, 31);
            this.targetVersionBox.Name = "targetVersionBox";
            this.targetVersionBox.Size = new System.Drawing.Size(121, 21);
            this.targetVersionBox.TabIndex = 2;
            this.targetVersionBox.SelectedIndexChanged += new System.EventHandler(this.targetVersionBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(343, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target System Version:";
            // 
            // dropZone
            // 
            this.dropZone.AllowDrop = true;
            this.dropZone.BackColor = System.Drawing.Color.Gray;
            this.dropZone.Controls.Add(this.dropZone2);
            this.dropZone.Location = new System.Drawing.Point(17, 75);
            this.dropZone.Name = "dropZone";
            this.dropZone.Size = new System.Drawing.Size(447, 96);
            this.dropZone.TabIndex = 4;
            this.dropZone.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropZone_DragDrop);
            this.dropZone.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropZone_DragEnter);
            // 
            // dropZone2
            // 
            this.dropZone2.AllowDrop = true;
            this.dropZone2.AutoSize = true;
            this.dropZone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropZone2.ForeColor = System.Drawing.Color.Silver;
            this.dropZone2.Location = new System.Drawing.Point(26, 35);
            this.dropZone2.Name = "dropZone2";
            this.dropZone2.Size = new System.Drawing.Size(397, 29);
            this.dropZone2.TabIndex = 0;
            this.dropZone2.Text = "\'OR DRAG MULTIPLE FILES HERE\'";
            this.dropZone2.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropZone_DragDrop);
            this.dropZone2.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropZone_DragEnter);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.versionLabel.Location = new System.Drawing.Point(407, 181);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(80, 13);
            this.versionLabel.TabIndex = 5;
            this.versionLabel.Text = "v0.3 by Kakkoii";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.versionLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.versionLabel_MouseClick);
            this.versionLabel.MouseEnter += new System.EventHandler(this.versionLabel_MouseEnter);
            this.versionLabel.MouseLeave += new System.EventHandler(this.versionLabel_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(490, 199);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.dropZone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.targetVersionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WiiU - BIN to MP4 exploit";
            this.dropZone.ResumeLayout(false);
            this.dropZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox targetVersionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel dropZone;
        private System.Windows.Forms.Label dropZone2;
        private System.Windows.Forms.Label versionLabel;
    }
}

