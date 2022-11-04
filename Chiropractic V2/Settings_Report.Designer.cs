
namespace Chiropractic_V2
{
    partial class Settings_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_Report));
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_NameCenter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Agreement = new System.Windows.Forms.TextBox();
            this.btn_Today = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name Of Center:";
            // 
            // tbx_NameCenter
            // 
            this.tbx_NameCenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_NameCenter.Location = new System.Drawing.Point(398, 64);
            this.tbx_NameCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_NameCenter.Name = "tbx_NameCenter";
            this.tbx_NameCenter.Size = new System.Drawing.Size(470, 40);
            this.tbx_NameCenter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Agreement Of Center:";
            // 
            // tbx_Agreement
            // 
            this.tbx_Agreement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbx_Agreement.Location = new System.Drawing.Point(398, 202);
            this.tbx_Agreement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_Agreement.Multiline = true;
            this.tbx_Agreement.Name = "tbx_Agreement";
            this.tbx_Agreement.Size = new System.Drawing.Size(976, 578);
            this.tbx_Agreement.TabIndex = 3;
            // 
            // btn_Today
            // 
            this.btn_Today.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Today.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Today.Appearance.Options.UseFont = true;
            this.btn_Today.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_Today.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Today.ImageOptions.SvgImage")));
            this.btn_Today.Location = new System.Drawing.Point(1142, 42);
            this.btn_Today.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.btn_Today.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Today.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Today.Name = "btn_Today";
            this.btn_Today.Size = new System.Drawing.Size(232, 110);
            this.btn_Today.TabIndex = 23;
            this.btn_Today.Text = "Save";
            this.btn_Today.Click += new System.EventHandler(this.btn_Today_Click);
            // 
            // Settings_Report
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1518, 868);
            this.Controls.Add(this.btn_Today);
            this.Controls.Add(this.tbx_Agreement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_NameCenter);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::Chiropractic_V2.Properties.Resources.dorsal_spine;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Settings_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings Report";
            this.Load += new System.EventHandler(this.Settings_Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_NameCenter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Agreement;
        private DevExpress.XtraEditors.SimpleButton btn_Today;
    }
}