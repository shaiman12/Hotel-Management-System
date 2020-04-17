namespace RestEasy_System.Presentation
{
    partial class AccountForm
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
            this.accountsListView = new System.Windows.Forms.ListView();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guestIDTextBox = new System.Windows.Forms.TextBox();
            this.accountNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.amtDueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cardNoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cardNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.expYearUpDown = new System.Windows.Forms.NumericUpDown();
            this.expMonthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.paymentTextBox = new System.Windows.Forms.TextBox();
            this.paymentButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.originalAmtTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.depositCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.expYearUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expMonthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Accounts";
            // 
            // accountsListView
            // 
            this.accountsListView.HideSelection = false;
            this.accountsListView.Location = new System.Drawing.Point(17, 42);
            this.accountsListView.Name = "accountsListView";
            this.accountsListView.Size = new System.Drawing.Size(854, 211);
            this.accountsListView.TabIndex = 1;
            this.accountsListView.UseCompatibleStateImageBehavior = false;
            this.accountsListView.SelectedIndexChanged += new System.EventHandler(this.AccountsListView_SelectedIndexChanged);
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(986, 144);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(179, 109);
            this.errorTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(982, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Errors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Guest ID:";
            // 
            // guestIDTextBox
            // 
            this.guestIDTextBox.Enabled = false;
            this.guestIDTextBox.Location = new System.Drawing.Point(157, 271);
            this.guestIDTextBox.Name = "guestIDTextBox";
            this.guestIDTextBox.Size = new System.Drawing.Size(43, 20);
            this.guestIDTextBox.TabIndex = 5;
            // 
            // accountNumberTextBox
            // 
            this.accountNumberTextBox.Enabled = false;
            this.accountNumberTextBox.Location = new System.Drawing.Point(157, 307);
            this.accountNumberTextBox.Name = "accountNumberTextBox";
            this.accountNumberTextBox.Size = new System.Drawing.Size(43, 20);
            this.accountNumberTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account Number: ";
            // 
            // amtDueTextBox
            // 
            this.amtDueTextBox.Enabled = false;
            this.amtDueTextBox.Location = new System.Drawing.Point(157, 344);
            this.amtDueTextBox.Name = "amtDueTextBox";
            this.amtDueTextBox.Size = new System.Drawing.Size(43, 20);
            this.amtDueTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Amount Left to Pay:";
            // 
            // cardNoTextBox
            // 
            this.cardNoTextBox.Location = new System.Drawing.Point(367, 275);
            this.cardNoTextBox.Name = "cardNoTextBox";
            this.cardNoTextBox.Size = new System.Drawing.Size(189, 20);
            this.cardNoTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Card Number:";
            // 
            // cardNameTextBox
            // 
            this.cardNameTextBox.Location = new System.Drawing.Point(367, 311);
            this.cardNameTextBox.Name = "cardNameTextBox";
            this.cardNameTextBox.Size = new System.Drawing.Size(189, 20);
            this.cardNameTextBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(231, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cardholder Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(231, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Expiration Year:";
            // 
            // expYearUpDown
            // 
            this.expYearUpDown.Location = new System.Drawing.Point(367, 345);
            this.expYearUpDown.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.expYearUpDown.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.expYearUpDown.Name = "expYearUpDown";
            this.expYearUpDown.Size = new System.Drawing.Size(61, 20);
            this.expYearUpDown.TabIndex = 15;
            this.expYearUpDown.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // expMonthUpDown
            // 
            this.expMonthUpDown.Location = new System.Drawing.Point(367, 373);
            this.expMonthUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.expMonthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.expMonthUpDown.Name = "expMonthUpDown";
            this.expMonthUpDown.Size = new System.Drawing.Size(61, 20);
            this.expMonthUpDown.TabIndex = 17;
            this.expMonthUpDown.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(231, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Expiration Month:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(600, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Make Payment:";
            // 
            // paymentTextBox
            // 
            this.paymentTextBox.Location = new System.Drawing.Point(603, 300);
            this.paymentTextBox.Name = "paymentTextBox";
            this.paymentTextBox.Size = new System.Drawing.Size(108, 20);
            this.paymentTextBox.TabIndex = 19;
            // 
            // paymentButton
            // 
            this.paymentButton.Location = new System.Drawing.Point(603, 327);
            this.paymentButton.Name = "paymentButton";
            this.paymentButton.Size = new System.Drawing.Size(108, 23);
            this.paymentButton.TabIndex = 20;
            this.paymentButton.Text = "PAY";
            this.paymentButton.UseVisualStyleBackColor = true;
            this.paymentButton.Click += new System.EventHandler(this.PaymentButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(986, 278);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(179, 49);
            this.submitButton.TabIndex = 21;
            this.submitButton.Text = "Save Changes";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(986, 344);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(179, 49);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Original Amount Due:";
            // 
            // originalAmtTextBox
            // 
            this.originalAmtTextBox.Enabled = false;
            this.originalAmtTextBox.Location = new System.Drawing.Point(157, 378);
            this.originalAmtTextBox.Name = "originalAmtTextBox";
            this.originalAmtTextBox.Size = new System.Drawing.Size(43, 20);
            this.originalAmtTextBox.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(600, 373);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 24);
            this.label12.TabIndex = 25;
            this.label12.Text = "Deposit Paid:";
            // 
            // depositCheckBox
            // 
            this.depositCheckBox.AutoSize = true;
            this.depositCheckBox.Enabled = false;
            this.depositCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depositCheckBox.Location = new System.Drawing.Point(739, 379);
            this.depositCheckBox.Name = "depositCheckBox";
            this.depositCheckBox.Size = new System.Drawing.Size(15, 14);
            this.depositCheckBox.TabIndex = 26;
            this.depositCheckBox.UseVisualStyleBackColor = true;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 407);
            this.Controls.Add(this.depositCheckBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.originalAmtTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.paymentButton);
            this.Controls.Add(this.paymentTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.expMonthUpDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.expYearUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cardNameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cardNoTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.amtDueTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.accountNumberTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guestIDTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.accountsListView);
            this.Controls.Add(this.label1);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountForm_FormClosing);
            this.Load += new System.EventHandler(this.AccountForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.expYearUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expMonthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView accountsListView;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox guestIDTextBox;
        private System.Windows.Forms.TextBox accountNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amtDueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cardNoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cardNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown expYearUpDown;
        private System.Windows.Forms.NumericUpDown expMonthUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox paymentTextBox;
        private System.Windows.Forms.Button paymentButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox originalAmtTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox depositCheckBox;
    }
}