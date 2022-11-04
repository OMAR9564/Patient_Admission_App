using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Chiropractic_V2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Thread t;
        public Form1()
        {
            InitializeComponent();
            try
            {
                t = new Thread(new ThreadStart(StartSplash));
                t.Start();
                Thread.Sleep(5000);
                t.Abort();
            }
            catch (Exception)
            {

            }
        }
        private void StartSplash()
        {
            try
            {
                Application.Run(new Splash());
            }
            catch (Exception)
            {

            }
        }
        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_NewPatient frm = new Frm_NewPatient();
            frm.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_Emp frm = new Frm_Emp();
            frm.ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_Employee frm = new Frm_Employee();
            frm.ShowDialog();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_Des frm = new Frm_Des();
            frm.ShowDialog();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_Backup frm = new Frm_Backup();
            frm.ShowDialog();
        }
        private bool checkDatabase()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("", conn);

            SqlDataReader rdr;
            try
            {
                cmd.CommandText = "exec sys.sp_databases";
                conn.Open();

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetString(0) == "Chiropractic")
                    {
                        return true;
                        break;
                    }
                }
                conn.Close();
                rdr.Dispose();
                cmd.Dispose();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void creatDatabase()
        {
            bool check = checkDatabase();

            if (check == false)
            {
                try
                {
                    //string conn = "Data Source=DESKTOP-164KRHE;Integrated Security=True";

                    //string script = File.ReadAllText(Application.StartupPath + @"\sqlscript.sql");

                    //SqlConnection co = new SqlConnection(conn);

                    //Server server = new Server(new ServerConnection(co));


                    //server.ConnectionContext.ExecuteNonQuery(script);

                    var fileContenet = File.ReadAllText(Application.StartupPath + @"\sqlscript.sql");
                    var sqlqueries = fileContenet.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                    var con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True");
                    var cmd = new SqlCommand("query", con);
                    con.Open();
                    foreach (var query in sqlqueries)
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                creatDatabase();
            }
            catch (Exception) { }
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Frm_Metting frm = new Frm_Metting();
            frm.ShowDialog();
        }
    }
}
