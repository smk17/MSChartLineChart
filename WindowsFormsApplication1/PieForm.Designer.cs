namespace WindowsFormsApplication1
{
    partial class PieForm
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
            this.pie1 = new WindowsFormsApplication1.Pie();
            this.SuspendLayout();
            // 
            // pie1
            // 
            this.pie1.Location = new System.Drawing.Point(12, 22);
            this.pie1.Name = "pie1";
            this.pie1.Size = new System.Drawing.Size(473, 310);
            this.pie1.TabIndex = 0;
            // 
            // PieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 382);
            this.Controls.Add(this.pie1);
            this.Name = "PieForm";
            this.Text = "PieForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PieForm_FormClosed);
            this.Load += new System.EventHandler(this.PieForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Pie pie1;

    }
}