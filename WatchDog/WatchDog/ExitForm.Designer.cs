namespace WatchDog
{
    partial class ExitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.yBtn = new System.Windows.Forms.Button();
            this.nBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exit WatchDog";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Checked = true;
            this.checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox.Location = new System.Drawing.Point(36, 50);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(120, 16);
            this.checkBox.TabIndex = 1;
            this.checkBox.Text = "Disable WatchDog";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // yBtn
            // 
            this.yBtn.Location = new System.Drawing.Point(10, 88);
            this.yBtn.Name = "yBtn";
            this.yBtn.Size = new System.Drawing.Size(75, 23);
            this.yBtn.TabIndex = 2;
            this.yBtn.Text = "Yes";
            this.yBtn.UseVisualStyleBackColor = true;
            this.yBtn.Click += new System.EventHandler(this.YBtn_Click);
            // 
            // nBtn
            // 
            this.nBtn.Location = new System.Drawing.Point(100, 88);
            this.nBtn.Name = "nBtn";
            this.nBtn.Size = new System.Drawing.Size(75, 23);
            this.nBtn.TabIndex = 3;
            this.nBtn.Text = "No";
            this.nBtn.UseVisualStyleBackColor = true;
            this.nBtn.Click += new System.EventHandler(this.NBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 121);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nBtn);
            this.Controls.Add(this.yBtn);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExitForm";
            this.Text = "Exit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button yBtn;
        private System.Windows.Forms.Button nBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}