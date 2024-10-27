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
namespace SinemaBileti
{
    public partial class GirisEkranı : Form
    {
        
        SqlDataReader dr;
        public static string user, password;
        public GirisEkranı()
        {
            InitializeComponent();
        }
        baglantı bgl = new baglantı();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void GirisEkranı_Load(object sender, EventArgs e)
        {

        }

        private void giris_yap_Click(object sender, EventArgs e)
        {
            user = kullaniciaditxt.Text;
            password = sifretxt.Text;

            SqlConnection conn = new SqlConnection(bgl.baglanti);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            
            cmd.CommandText = "SELECT * FROM Kasiyer_Bilgileri where KullaniciAdi='" + kullaniciaditxt.Text + "' AND Sifre='" + sifretxt.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                FrmAnasayfa giris = new FrmAnasayfa();
                giris.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            conn.Close();
        }



    }
}
