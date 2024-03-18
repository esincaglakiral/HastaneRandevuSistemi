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

namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            this.Hide();
            fr.Show();
        }

        private void linkSign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr = new FrmHastaKayit();
            this.Hide();
            fr.Show();
        }

        SqlCon con = new SqlCon();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Metot, SQL Server veritabanından kullanıcının kimlik bilgilerini kontrol etmek için bir SqlCommand nesnesi oluşturur.
            //Bu sorgu, 'Tbl_Hastalar' adlı tablodan kullanıcının TC kimlik numarası('HastaTC') ve şifresi('HastaSifre') eşleşen kaydı arar.

            SqlCommand command = new SqlCommand("Select * from Tbl_Hastalar where HastaTC = @p1 and HastaSifre = @p2",con.connection());
            // SqlCommand nesnesinin parametreleri, kullanıcının girdiği TC kimlik numarası ('maskTC.Text') ve şifre ('txtPassword.Text') değerlerini alır.
            command.Parameters.AddWithValue("@p1", maskTC.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);

            SqlDataReader dr = command.ExecuteReader();  //'command.ExecuteReader()' çağrısıyla SQL sorgusu veritabanında yürütülür ve SqlDataReader nesnesi ('dr') oluşturulur.
            if (dr.Read())
            {
              // SqlDataReader nesnesi, sorgudan dönen sonuçları okumak için kullanılır.Eğer veri okunabiliyorsa, yani kullanıcı doğru kimlik bilgilerini girdiyse, 'if' bloğu çalışır.
              //'FrmHastaDetay' adlı bir form nesnesi oluşturulur.
              //Mevcut form gizlenir('this.Hide()').
              //'FrmHastaDetay' formunun 'tc' adlı bir alanına, kullanıcının TC kimlik numarası atanır.
              //'FrmHastaDetay' formu gösterilir('fr.Show()').
                FrmHastaDetay fr = new FrmHastaDetay();
                this.Hide();
                fr.tc = maskTC.Text;
                fr.Show();
            }
            else
            {
            //Eğer veri okunamıyorsa, yani kullanıcı hatalı TC kimlik numarası veya şifre girdiyse, 'else' bloğu çalışır.
            //Kullanıcıya bir ileti kutusu gösterilir, bu ileti kutusu hatalı kimlik bilgilerini belirtir.
            //TC kimlik numarası alanı temizlenir('maskTC.Clear()').
            //Şifre alanı temizlenir('txtPassword.Clear()').
            //TC kimlik numarası alanına odaklanılır('maskTC.Focus()').
                MessageBox.Show("Kimlik numaranız veya şifreniz hatalı");
                maskTC.Clear();
                txtPassword.Clear();
                maskTC.Focus();
            }
            con.connection().Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
