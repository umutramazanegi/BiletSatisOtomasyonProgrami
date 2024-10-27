using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaBileti
{
    public partial class seansListele : UserControl
    {
        public seansListele()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        DataTable tablo = new DataTable();
        baglantı bgl = new baglantı();
        private void SeansListesi(string sql)
        {
            SqlConnection conn = new SqlConnection(bgl.baglanti);
            conn.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, conn);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();

        }

        private void seansListele_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_bilgileri where Tarih like '" + dateTimePicker1.Text + "'");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_bilgileri where Tarih like '" + dateTimePicker1.Text + "'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_bilgileri");
        }

        private void seans_sil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Seans_Bilgileri WHERE SeansId=@SeansId";
            SqlConnection conn = new SqlConnection(bgl.baglanti);
            conn.Open();
            komut = new SqlCommand(sorgu, conn);
            komut.Parameters.AddWithValue("@SeansId", seansid.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            tablo.Clear();
            SeansListesi("select *from Seans_bilgileri");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            seansid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            filmaditxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            salonaditxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tarihtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            seanstxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
