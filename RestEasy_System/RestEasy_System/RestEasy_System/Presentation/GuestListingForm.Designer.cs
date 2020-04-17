namespace RestEasy_System.Presentation
{
    partial class GuestListingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.guestListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Guests";
            // 
            // guestListView
            // 
            this.guestListView.HideSelection = false;
            this.guestListView.Location = new System.Drawing.Point(17, 50);
            this.guestListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guestListView.Name = "guestListView";
            this.guestListView.Size = new System.Drawing.Size(1025, 422);
            this.guestListView.TabIndex = 1;
            this.guestListView.UseCompatibleStateImageBehavior = false;
            this.guestListView.SelectedIndexChanged += new System.EventHandler(this.GuestListView_SelectedIndexChanged);
            // 
            // GuestListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 491);
            this.Controls.Add(this.guestListView);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GuestListingForm";
            this.Text = "GuestListingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView guestListView;
    }
}