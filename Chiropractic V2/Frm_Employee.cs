using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Chiropractic_V2
{
    public partial class Frm_Employee : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Employee()
        {
            InitializeComponent();
        }

        private void Frm_Employee_Load(object sender, EventArgs e)
        {
            try
            {
                AutoNumber();
            }
            catch (Exception)
            {

            }
        }
        Database db = new Database();
        DataTable tbl = new DataTable();
        private void AutoNumber()
        {
            try
            {
                tbl.Clear();


                tbl = db.readData("select max(No) from Employees", "");
                //rows0 0 string'e dönüştür 
                // DBNull null sa boşsa
                //boşsa.değerleri.string'e dönüştür
                if (tbl.Rows[0][0].ToString() == DBNull.Value.ToString())
                {
                    //txtID kutusuna 1 yazdır
                    txtID.Text = "1";
                }
                else
                {
                    //tbl.Rows0 0 datatabel olduğu için ona int bir sayı eklemeyiz o yüzden
                    //ilk başta convert.toint32 dönüştürdü.. daha sonra bütün bunları txtID text olduğu için en sonra to string'e döüşütr yazdık
                    txtID.Text = ((Convert.ToInt32(tbl.Rows[0][0])) + 1).ToString();
                }
                // bir kişi eklendikten sonra bütün kutular silinir
                txtName.Clear();
                txtSurname.Clear();
                txtAddress.Clear();
                txtPhone.Clear();
                picture.BackgroundImage = null;
                //picture.Image = null;
                //imagePath = "";

                // Ekleme silme vb. kutular aktifleştirmek için yada iptal etmek için kullanırız.
                //AutoNumber fonk. içine, yeni bir sayı olunca diye burada yazdık.
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;

            }
            catch (Exception) { }

        }
        int row = 0;
        private void Show()
        {
            try
            {
                tbl.Clear();
                tbl = db.readData("select * from Employees", "");

                if (tbl.Rows.Count <= 0)
                {
                    MessageBox.Show("Information not received");

                }

                else
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtName.Text = tbl.Rows[row][1].ToString();
                    txtSurname.Text = tbl.Rows[row][2].ToString();
                    txtPhone.Text = tbl.Rows[row][3].ToString();
                    txtAddress.Text = tbl.Rows[row][4].ToString();

                    // databaseten image almak için
                    Byte[] byteimage = new Byte[0];
                    byteimage = (Byte[])(tbl.Rows[row][5]);
                    MemoryStream memoryStream = new MemoryStream(byteimage);
                    picture.BackgroundImageLayout = ImageLayout.Stretch;
                    picture.BackgroundImage = Image.FromStream(memoryStream);




                }



                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            catch (Exception) { }

        }
        string imagePath = "";

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Files(*.*) | *.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName.ToString();
                    picture.Image = null;
                    picture.ImageLocation = imagePath;
                }
            }
            catch (Exception) { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            picture.BackgroundImage = null;
            picture.Image = null;
            imagePath = "";
        }

        private void SaveImage(string stmt, string messege)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Chiropractic;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(stmt, conn);

            var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            Byte[] bytestream = new Byte[fileStream.Length];
            fileStream.Read(bytestream, 0, bytestream.Length);
            fileStream.Close();

            SqlParameter parameter = new SqlParameter("@Logo", SqlDbType.VarBinary, bytestream.Length, ParameterDirection.Input, false, 0, 0
                , null, DataRowVersion.Current, bytestream);

            cmd.Parameters.Add(parameter);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            if (messege != "")
            {
                MessageBox.Show(messege, "confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Please enter the Employee's name, Surname and address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (imagePath == "")
            {
                MessageBox.Show("Please Select the Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                SaveImage("insert into Employees Values('" + txtID.Text + "', '" + txtName.Text + "', '" + txtSurname.Text + "', '" + txtPhone.Text + "', '" + txtAddress.Text + "', @Logo)", "Information successfully saved");

                AutoNumber();
                picture.BackgroundImage = null;
                picture.Image = null;
                imagePath = "";

            }


        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {

                tbl.Clear();
                picture.BackgroundImage = null;
                picture.Image = null;
                imagePath = "";
                tbl = db.readData("select count (No) from Employees", "");
                row = (Convert.ToInt32(tbl.Rows[0][0]) - 1);
                Show();
            }
            catch (Exception) { }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                tbl.Clear();
                picture.BackgroundImage = null;
                picture.Image = null;
                imagePath = "";
                tbl = db.readData("select count (No) from Employees", "");
                if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
                {
                    row = 0;
                    Show();
                }
                else
                {
                    row++;
                    Show();
                }
            }
            catch (Exception) { }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (row == 0)
                {
                    tbl.Clear();
                    picture.BackgroundImage = null;
                    picture.Image = null;
                    imagePath = "";
                    tbl = db.readData("select count (No) from Employees", "");
                    row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                    Show();
                }
                else
                {
                    row--;
                    Show();
                }
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                row = 0;
                picture.BackgroundImage = null;
                picture.Image = null;
                imagePath = "";
                Show();
            }
            catch (Exception) { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtSurname.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Please enter the Employee's name, Surname and address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (picture.Image == null)
            {
                MessageBox.Show("Please Select the Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (imagePath == "")
            {
                MessageBox.Show("Please Select the Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SaveImage("update Employees set Name = '" + txtName.Text + "', Surname = '" + txtSurname.Text + "', Phone = '" + txtPhone.Text + "', Address = '" + txtAddress.Text + "', Logo = @Logo where No = '" + txtID.Text + "'", "Information successfully changed");
                    AutoNumber();
                }
                catch (Exception) { }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete this information?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.readData("delete from Employees where No = " + txtID.Text + "", "Information deleted successfully");
                    AutoNumber();

                }
            }
            catch (Exception)
            {

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // If you want, you can allow decimal (float) numbers
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
        }
    }
}