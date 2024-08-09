namespace CodingProject1._0
{
    partial class FRMInventory
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
            this.LBXInventory = new System.Windows.Forms.ListBox();
            this.BTNExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBXInventory
            // 
            this.LBXInventory.FormattingEnabled = true;
            this.LBXInventory.Location = new System.Drawing.Point(59, 49);
            this.LBXInventory.Name = "LBXInventory";
            this.LBXInventory.Size = new System.Drawing.Size(236, 316);
            this.LBXInventory.TabIndex = 0;
            // 
            // BTNExit
            // 
            this.BTNExit.Location = new System.Drawing.Point(346, 49);
            this.BTNExit.Name = "BTNExit";
            this.BTNExit.Size = new System.Drawing.Size(75, 23);
            this.BTNExit.TabIndex = 1;
            this.BTNExit.Text = "Exit";
            this.BTNExit.UseVisualStyleBackColor = true;
            // 
            // FRMInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNExit;
            this.ClientSize = new System.Drawing.Size(468, 403);
            this.Controls.Add(this.BTNExit);
            this.Controls.Add(this.LBXInventory);
            this.Name = "FRMInventory";
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBXInventory;
        private System.Windows.Forms.Button BTNExit;
    }
}