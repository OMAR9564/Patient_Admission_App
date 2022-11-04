using DevExpress.XtraEditors;

namespace Chiropractic_V2
{
    public partial class Frm_Emp : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Emp()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Frm_Load frm = new Frm_Load();
            frm.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            Frm_LoadToday frm = new Frm_LoadToday();
            frm.ShowDialog();
        }
    }
}