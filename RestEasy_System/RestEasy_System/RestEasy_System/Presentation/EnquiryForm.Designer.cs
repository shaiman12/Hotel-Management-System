namespace RestEasy_System.Presentation
{
    partial class EnquiryForm
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
            this.guestComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bookingListView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dsf = new System.Windows.Forms.Label();
            this.accountsListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a Guest:";
            // 
            // guestComboBox
            // 
            this.guestComboBox.FormattingEnabled = true;
            this.guestComboBox.Location = new System.Drawing.Point(12, 46);
            this.guestComboBox.Name = "guestComboBox";
            this.guestComboBox.Size = new System.Drawing.Size(183, 21);
            this.guestComboBox.TabIndex = 1;
            this.guestComboBox.SelectedIndexChanged += new System.EventHandler(this.GuestComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-54, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1129, 11);
            this.label2.TabIndex = 2;
            // 
            // bookingListView
            // 
            this.bookingListView.Enabled = false;
            this.bookingListView.HideSelection = false;
            this.bookingListView.Location = new System.Drawing.Point(12, 114);
            this.bookingListView.Name = "bookingListView";
            this.bookingListView.Size = new System.Drawing.Size(776, 97);
            this.bookingListView.TabIndex = 3;
            this.bookingListView.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Booking Information:";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-164, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1129, 11);
            this.label4.TabIndex = 5;
            // 
            // dsf
            // 
            this.dsf.AutoSize = true;
            this.dsf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsf.Location = new System.Drawing.Point(8, 231);
            this.dsf.Name = "dsf";
            this.dsf.Size = new System.Drawing.Size(259, 20);
            this.dsf.TabIndex = 6;
            this.dsf.Text = "Customer Account Information:";
            // 
            // accountsListView
            // 
            this.accountsListView.Enabled = false;
            this.accountsListView.HideSelection = false;
            this.accountsListView.Location = new System.Drawing.Point(12, 263);
            this.accountsListView.Name = "accountsListView";
            this.accountsListView.Size = new System.Drawing.Size(776, 97);
            this.accountsListView.TabIndex = 7;
            this.accountsListView.UseCompatibleStateImageBehavior = false;
            // 
            // EnquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 372);
            this.Controls.Add(this.accountsListView);
            this.Controls.Add(this.dsf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bookingListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guestComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnquiryForm";
            this.Text = "EnquiryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox guestComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView bookingListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dsf;
        private System.Windows.Forms.ListView accountsListView;
    }
}