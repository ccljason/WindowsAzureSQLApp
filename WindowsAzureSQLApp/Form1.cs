using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAzureSQLApp
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         string connectionString = "Server=tcp:vqu98iw1cc.database.windows.net,1433;Database=TestSQLDB1;User ID=jason@vqu98iw1cc;Password=Sage@sql;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            try
            {
               conn.Open();

               string sql = "select * from [dbo].[Table1]";
               using (SqlCommand command = new SqlCommand(sql, conn))
               {
                  using (SqlDataReader reader = command.ExecuteReader())
                  {
                     while (reader.Read())
                     {
                        string msg = string.Format("{0};{1};{2}", reader.GetInt32(0),
                           reader.GetString(1), reader.GetInt32(2));
                        MessageBox.Show(msg);
                     }
                  }
               }
            }
            catch (Exception)
            {
            }
         }
      }
   }
}
