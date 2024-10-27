using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SinemaBileti
{
    class baglantı
    {
        public string baglanti = System.IO.File.ReadAllText(@"C:\veritabani.txt");
        //public static SqlConnection conn;

        //public void a1()
        //{
        //    conn = new SqlConnection("Data Source=UMUT\\SQLEXPRESS;Initial Catalog=Sinema_Bileti;Integrated Security=True");

        //    conn.Open();

        //}
    }
}
