using DevExpress.XtraSplashScreen;
using System;

namespace Chiropractic_V2
{
    public partial class Splash : SplashScreen
    {
        public Splash()
        {
            InitializeComponent();

        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void labelCopyright_Click(object sender, EventArgs e)
        {

        }

        private void peImage_EditValueChanged(object sender, EventArgs e)
        {

        }
        //private bool checkDatabase()
        //{
        //    SqlConnection conn = new SqlConnection(@"Data Source =.\SQLEXPRESS; Integrated Security = True");

        //    SqlCommand cmd = new SqlCommand("", conn);

        //    SqlDataReader rdr;
        //    try
        //    {
        //        cmd.CommandText = "exec sys.sp_databases";
        //        conn.Open();

        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            if (rdr.GetString(0) == "Chiropractic")
        //            {
        //                return true;
        //                break;
        //            }
        //        }
        //        conn.Close();
        //        rdr.Dispose();
        //        cmd.Dispose();
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        //private void creatDatabase()
        //{
        //    bool check = checkDatabase();

        //    if (check == false)
        //    {
        //        try
        //        {
        //            string conn = "Data Source=DESKTOP-164KRHE;Integrated Security=True";

        //            string script = File.ReadAllText(Application.StartupPath + @"\sqlscript.sql");

        //            SqlConnection co = new SqlConnection(conn);

        //            Server server = new Server(new ServerConnection(co));


        //            server.ConnectionContext.ExecuteNonQuery(script);
        //            var fileContenet = File.ReadAllText(Application.StartupPath + @"\sqlscript.sql");
        //            var sqlqueries = fileContenet.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

        //            var con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True");
        //            var cmd = new SqlCommand("query", con);
        //            con.Open();
        //            foreach (var query in sqlqueries)
        //            {
        //                cmd.CommandText = query;
        //                cmd.ExecuteNonQuery();
        //            }
        //            con.Close();
        //        }
        //        catch (Exception) { }
        //    }
        //}
        private void Splash_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    creatDatabase();
            //}
            //catch (Exception) { }
        }
    }
}