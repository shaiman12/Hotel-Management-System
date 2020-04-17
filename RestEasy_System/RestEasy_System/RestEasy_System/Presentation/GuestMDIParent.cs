using RestEasy_System.Database;
using RestEasy_System.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasy_System.Presentation
{
    public partial class GuestMDIParent : Form
    {
        private int childFormNumber = 0;
        private GuestListingForm guestListingForm;
        private GuestForm guestForm;
        private GuestController guestController;
        private AccountForm accountForm;
        private AccountDB accountDB;
        private BookingForm bookingForm;
        private BookingController bookingController;
        private EnquiryForm enquiryForm;
        private OccupancyReport occupancyReport;
        private IncomeReport incomeReport;


        public GuestMDIParent()
        {
            InitializeComponent();
            guestController = new GuestController();
            accountDB = new AccountDB(guestController);
            bookingController = new BookingController(guestController);
            accountDB.setBookingController(bookingController);
            this.WindowState = FormWindowState.Maximized;
            
        }

        public GuestForm currentGuestForm
        {
            get { return guestForm; }
            set { guestForm = value; }
        }



        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void CreateNewGuestListingForm()
        {
            guestListingForm = new GuestListingForm(guestController, accountDB);
            guestListingForm.MdiParent = this;
            guestListingForm.StartPosition = FormStartPosition.CenterParent;
        }

        private void CreateNewGuestForm()
        {
            guestForm = new GuestForm(guestController,accountDB);
            guestForm.MdiParent = this;
            guestForm.StartPosition = FormStartPosition.CenterParent;




        }

        private void CreateNewOccupancyReportForm()
        {
            occupancyReport = new OccupancyReport(guestController, bookingController, accountDB);
            occupancyReport.MdiParent = this;
            occupancyReport.StartPosition = FormStartPosition.CenterParent;




        }
        private void CreateNewIncomeReportForm()
        {
            incomeReport = new IncomeReport(guestController, bookingController, accountDB);
            incomeReport.MdiParent = this;
            incomeReport.StartPosition = FormStartPosition.CenterParent;




        }


        private void CreateNewEnquiryForm()
        {
            enquiryForm = new EnquiryForm(guestController, bookingController, accountDB);
            enquiryForm.MdiParent = this;
            enquiryForm.StartPosition = FormStartPosition.CenterParent;




        }

        private void CreateNewAccountForm()
        {
            accountForm = new AccountForm(accountDB,guestController);
            accountForm.MdiParent = this;
            accountForm.StartPosition = FormStartPosition.CenterParent;



        }


        private void CreateNewBookingForm()
        {
            bookingForm = new BookingForm(guestController, bookingController,accountDB);
            bookingForm.MdiParent = this;
            bookingForm.StartPosition = FormStartPosition.CenterParent;
        }




        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ListAllGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewGuestListingForm();
            if (guestListingForm == null)
            {
                CreateNewGuestListingForm();
            }
            if (guestListingForm.listFormClosed)
            {
                CreateNewGuestListingForm();
            }

            guestListingForm.Show();
        }

        private void AddAGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(guestForm == null)
            {
                CreateNewGuestForm();
            }
            if (guestForm.guestFormClosed)
            {
                CreateNewGuestForm();
            }
            guestForm.Display(GuestForm.FormState.Add);
            guestForm.Show();
        }

        private void EditAGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guestForm == null)
            {
                CreateNewGuestForm();
            }
            if (guestForm.guestFormClosed)
            {
                CreateNewGuestForm();
            }
            guestForm.Display(GuestForm.FormState.Edit);
            guestForm.Show();
        }

        private void ViewAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountForm == null)
            {
                CreateNewAccountForm();
            }
            if (accountForm.accountFormClosed)
            {
                CreateNewAccountForm();
            }
            accountForm.FormDisplay("view");
            accountForm.Show();
        }

        private void EditAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (accountForm == null)
            {
                CreateNewAccountForm();
            }
            if (accountForm.accountFormClosed)
            {
                CreateNewAccountForm();
            }
            accountForm.FormDisplay("edit");
            accountForm.Show();
        }

        private void EditABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                CreateNewBookingForm();
            }
            if (bookingForm.bookingFormClosed)
            {
                CreateNewBookingForm();
            }
            bookingForm.FormDisplay("edit");
            bookingForm.Show();
        }

        private void ViewAllBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                CreateNewBookingForm();
            }
            if (bookingForm.bookingFormClosed)
            {
                CreateNewBookingForm();
            }
            bookingForm.FormDisplay("view");
            bookingForm.Show();




        }

        private void CreateNewBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookingForm == null)
            {
                CreateNewBookingForm();
            }
            if (bookingForm.bookingFormClosed)
            {
                CreateNewBookingForm();
            }
            bookingForm.FormDisplay("add");
            bookingForm.Show();
        }

        private void EnquireAboutABookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enquiryForm == null)
            {
                CreateNewEnquiryForm();
            }
            if (enquiryForm.enquiryFormClosed)
            {
                CreateNewEnquiryForm();
            }
            enquiryForm.Show();
        }

        private void GenerateOccupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (occupancyReport == null)
            {
                CreateNewOccupancyReportForm();
            }
            if (occupancyReport.reportFormClosed)
            {
                CreateNewOccupancyReportForm();
            }
            occupancyReport.Show();

        }

        private void GenerateIncomeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (incomeReport == null)
            {
                CreateNewIncomeReportForm();
            }
            if (incomeReport.reportFormClosed)
            {
                CreateNewIncomeReportForm();
            }
            incomeReport.Show();
        }
    }
}
