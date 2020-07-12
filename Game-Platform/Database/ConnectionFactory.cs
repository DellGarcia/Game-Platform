using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game_Platform.Database
{
    public class ConnectionFactory
    {

        public SqlConnection Connection { get; set; }

        public ConnectionFactory()
        {
            try
            {
                Connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=" +
                    "False;Initial Catalog=bdGamePlatform;Data Source=DELLGARCIA-PC\\SQLEXPRESS");
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível conseguir a conexão com o banco de dados SQL Server.");
            }
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
