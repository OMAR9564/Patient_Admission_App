using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Windows.Forms;


namespace Chiropractic_V2
{
    public partial class Frm_Backup : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                string d = DateTime.Now.Date.ToString("dd-MM-yyyy");
                SaveFileDialog open = new SaveFileDialog();

                open.Filter = "BackUp Files (*.back) | *.back";
                open.FileName = "Chiropractic_BackUP_" + d;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    db.exceuteData("BACKUP DATABASE Chiropractic To Disk = '" + open.FileName + "'", "Backup Successfully Received.");
                }
            }
            catch (Exception)
            {

            }
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            Server server = new Server(@".\SQLEXPRESS");

            Microsoft.SqlServer.Management.Smo.Database db = server.Databases["Chiropractic"];

            if (db != null)
            {
                server.KillAllProcesses(db.Name);
            }

            Restore restore = new Restore();

            restore.Database = db.Name;
            restore.Action = RestoreActionType.Database;
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "BackUp Files (*.back) | *.back";
            if (open.ShowDialog() == DialogResult.OK)
            {
                restore.Devices.AddDevice(open.FileName, DeviceType.File);
                restore.ReplaceDatabase = true;
                restore.NoRecovery = false;
                restore.SqlRestore(server);
                MessageBox.Show("Backup successfully received", "confirmation");
            }
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            Settings_Report frm = new Settings_Report();
            frm.ShowDialog();
        }
    }
}