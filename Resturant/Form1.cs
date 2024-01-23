using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Resturant
{

    public partial class SplashScreen : Form
    {
        string connectionString = @"Data Source=MyDatabase.db;Version=3;";

        public SplashScreen()
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine();
                string sql = "CREATE TABLE SampleTable (Id INTEGER PRIMARY KEY, TextValue TEXT)";
                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
                // Perform database operations
            }



        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
