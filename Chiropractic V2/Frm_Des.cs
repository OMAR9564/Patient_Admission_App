using DevExpress.XtraEditors;

namespace Chiropractic_V2
{
    public partial class Frm_Des : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Des()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Deserved frm = new Deserved();
            frm.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            DesservedType frm = new DesservedType();
            frm.ShowDialog();
        }
    }
}