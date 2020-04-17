using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestEasy_System.Properties;

namespace RestEasy_System.Database
{
    public class DB
    {
        private string strConn = Settings.Default.guestInfoConnectionString;
        protected SqlConnection cnMain;

        public DB()
        {

            try
            {
                cnMain = new SqlConnection(strConn);
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error: Cannot Make Database Connection");
                return;
            }
        }

        protected bool UpdateDataSource(SqlCommand currentCommand)
        {
            bool success;
            try
            {
                cnMain.Open();
                currentCommand.CommandType = CommandType.Text;
                currentCommand.ExecuteNonQuery();
                cnMain.Close();
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
                success = false;
            }
            finally
            {

            }
            return success;

        }




    }
}
