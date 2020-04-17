namespace RestEasy_System.Presentation
{
    partial class OccupancyReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.submitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalGuestsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roomsOccupiedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.longestGuestTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.shortestStayTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.averageStayTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.averageRoomsTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.longStayLengthTextBox = new System.Windows.Forms.TextBox();
            this.shortStayLengthTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate Occupancy Report For:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date:";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(99, 41);
            this.startDateTimePicker.MinDate = new System.DateTime(2019, 9, 25, 0, 0, 0, 0);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(226, 20);
            this.startDateTimePicker.TabIndex = 3;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Location = new System.Drawing.Point(99, 68);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(226, 20);
            this.endDateTimePicker.TabIndex = 4;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(17, 94);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(308, 23);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Generate Report";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-54, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1015, 10);
            this.label4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total Guests Staying at Hotel: ";
            // 
            // totalGuestsTextBox
            // 
            this.totalGuestsTextBox.Enabled = false;
            this.totalGuestsTextBox.Location = new System.Drawing.Point(250, 134);
            this.totalGuestsTextBox.Name = "totalGuestsTextBox";
            this.totalGuestsTextBox.Size = new System.Drawing.Size(75, 20);
            this.totalGuestsTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Percentage of Rooms Occupied:";
            // 
            // roomsOccupiedTextBox
            // 
            this.roomsOccupiedTextBox.Enabled = false;
            this.roomsOccupiedTextBox.Location = new System.Drawing.Point(250, 179);
            this.roomsOccupiedTextBox.Name = "roomsOccupiedTextBox";
            this.roomsOccupiedTextBox.Size = new System.Drawing.Size(75, 20);
            this.roomsOccupiedTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Guest with Longest Stay:";
            // 
            // longestGuestTextBox
            // 
            this.longestGuestTextBox.Enabled = false;
            this.longestGuestTextBox.Location = new System.Drawing.Point(163, 252);
            this.longestGuestTextBox.Name = "longestGuestTextBox";
            this.longestGuestTextBox.Size = new System.Drawing.Size(162, 20);
            this.longestGuestTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Guest with Shortest Stay:";
            // 
            // shortestStayTextBox
            // 
            this.shortestStayTextBox.Enabled = false;
            this.shortestStayTextBox.Location = new System.Drawing.Point(163, 333);
            this.shortestStayTextBox.Name = "shortestStayTextBox";
            this.shortestStayTextBox.Size = new System.Drawing.Size(162, 20);
            this.shortestStayTextBox.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Average Stay Length:";
            // 
            // averageStayTextBox
            // 
            this.averageStayTextBox.Enabled = false;
            this.averageStayTextBox.Location = new System.Drawing.Point(250, 406);
            this.averageStayTextBox.Name = "averageStayTextBox";
            this.averageStayTextBox.Size = new System.Drawing.Size(75, 20);
            this.averageStayTextBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "Average Amount of Rooms Occupied Per Day:";
            // 
            // averageRoomsTextBox
            // 
            this.averageRoomsTextBox.Enabled = false;
            this.averageRoomsTextBox.Location = new System.Drawing.Point(250, 217);
            this.averageRoomsTextBox.Name = "averageRoomsTextBox";
            this.averageRoomsTextBox.Size = new System.Drawing.Size(75, 20);
            this.averageRoomsTextBox.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Longest Stay Length: ";
            // 
            // longStayLengthTextBox
            // 
            this.longStayLengthTextBox.Enabled = false;
            this.longStayLengthTextBox.Location = new System.Drawing.Point(250, 295);
            this.longStayLengthTextBox.Name = "longStayLengthTextBox";
            this.longStayLengthTextBox.Size = new System.Drawing.Size(75, 20);
            this.longStayLengthTextBox.TabIndex = 20;
            // 
            // shortStayLengthTextBox
            // 
            this.shortStayLengthTextBox.Enabled = false;
            this.shortStayLengthTextBox.Location = new System.Drawing.Point(250, 369);
            this.shortStayLengthTextBox.Name = "shortStayLengthTextBox";
            this.shortStayLengthTextBox.Size = new System.Drawing.Size(75, 20);
            this.shortStayLengthTextBox.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Shortest Stay Length: ";
            // 
            // OccupancyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 451);
            this.Controls.Add(this.shortStayLengthTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.longStayLengthTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.averageRoomsTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.averageStayTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.shortestStayTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.longestGuestTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.roomsOccupiedTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalGuestsTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OccupancyReport";
            this.Text = "OccupancyReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox totalGuestsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox roomsOccupiedTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox longestGuestTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox shortestStayTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox averageStayTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox averageRoomsTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox longStayLengthTextBox;
        private System.Windows.Forms.TextBox shortStayLengthTextBox;
        private System.Windows.Forms.Label label12;
    }
}