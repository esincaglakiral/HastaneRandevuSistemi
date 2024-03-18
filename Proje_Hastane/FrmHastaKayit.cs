using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje_Hastane
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frmHG = new FrmHastaGiris();
            this.Hide();
            frmHG.Show();
        }

        SqlCon con = new SqlCon();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //SQL Server veritabanına bir INSERT sorgusu yürütmek için bir SqlCommand nesnesi oluşturur.
            //Bu sorgu, 'Tbl_Hastalar' adlı bir tabloya yeni bir kayıt eklemeyi amaçlar.
            SqlCommand command = new SqlCommand("Insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1, @p2, @p3, @p4, @p5, @p6)",con.connection());
            command.Parameters.AddWithValue("@p1", txtFirstName.Text);
            command.Parameters.AddWithValue("@p2", txtLastName.Text);
            command.Parameters.AddWithValue("@p3", maskTC.Text);
            command.Parameters.AddWithValue("@p4", maskPhone.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.Parameters.AddWithValue("@p6", cmbGender.Text);
            //SqlCommand nesnesinin parametreleri, kullanıcının girdiği verilere göre belirlenir. '@p1' ile '@p6' arasındaki parametreler,
            //sırasıyla 'txtFirstName.Text', 'txtLastName.Text', 'maskTC.Text', 'maskPhone.Text', 'txtPassword.Text' ve 'cmbGender.Text'
            //olarak belirtilen Windows Forms bileşenlerinin değerlerini alır.
            command.ExecuteNonQuery();  // 'command.ExecuteNonQuery()' çağrısıyla SQL sorgusu veritabanında yürütülür ve yeni bir kayıt eklenir.
            con.connection().Close();  // Bağlantı nesnesi 'Close()' metoduyla kapatılır, böylece veritabanıyla olan bağlantı kesilir.
            MessageBox.Show("Kayıt işlemi başarılı. Şifreniz: " + txtPassword.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
