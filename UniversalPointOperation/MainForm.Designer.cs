namespace UniversalPointOperation
{
    partial class MainForm
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
            this.openImagePictureBox = new System.Windows.Forms.PictureBox();
            this.histpgramPictureBox = new System.Windows.Forms.PictureBox();
            this.linesPictureBox = new System.Windows.Forms.PictureBox();
            this.bezierPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histpgramPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bezierPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openImagePictureBox
            // 
            this.openImagePictureBox.Location = new System.Drawing.Point(13, 13);
            this.openImagePictureBox.Name = "openImagePictureBox";
            this.openImagePictureBox.Size = new System.Drawing.Size(360, 320);
            this.openImagePictureBox.TabIndex = 0;
            this.openImagePictureBox.TabStop = false;
            // 
            // histpgramPictureBox
            // 
            this.histpgramPictureBox.Location = new System.Drawing.Point(379, 13);
            this.histpgramPictureBox.Name = "histpgramPictureBox";
            this.histpgramPictureBox.Size = new System.Drawing.Size(360, 320);
            this.histpgramPictureBox.TabIndex = 1;
            this.histpgramPictureBox.TabStop = false;
            this.histpgramPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.histpgramPictureBox_Paint);
            this.histpgramPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.histpgramPictureBox_MouseClick);
            // 
            // linesPictureBox
            // 
            this.linesPictureBox.Location = new System.Drawing.Point(13, 339);
            this.linesPictureBox.Name = "linesPictureBox";
            this.linesPictureBox.Size = new System.Drawing.Size(360, 320);
            this.linesPictureBox.TabIndex = 2;
            this.linesPictureBox.TabStop = false;
            // 
            // bezierPictureBox
            // 
            this.bezierPictureBox.Location = new System.Drawing.Point(379, 339);
            this.bezierPictureBox.Name = "bezierPictureBox";
            this.bezierPictureBox.Size = new System.Drawing.Size(360, 320);
            this.bezierPictureBox.TabIndex = 3;
            this.bezierPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 686);
            this.Controls.Add(this.bezierPictureBox);
            this.Controls.Add(this.linesPictureBox);
            this.Controls.Add(this.histpgramPictureBox);
            this.Controls.Add(this.openImagePictureBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histpgramPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bezierPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox openImagePictureBox;
        private System.Windows.Forms.PictureBox histpgramPictureBox;
        private System.Windows.Forms.PictureBox linesPictureBox;
        private System.Windows.Forms.PictureBox bezierPictureBox;
    }
}

