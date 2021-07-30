using _2306calisma.YETKILENDIRME.CONNECTION;
using _2306calisma.YETKILENDIRME.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _2306calisma.YETKILENDIRME.MODELS
{
    public class DataGrid1Fill
    {
        public static void DataGridFill(List<YetkiAta1> tmp2)
        {
            tmp2.Clear();
            YetkiliGiris1 yetkiligiris1 = new YetkiliGiris1();
            yetkiligiris1.KULLANICI_ADI1 = Properties.Settings.Default.KULLANICI_ADI;
            yetkiligiris1.SIFRE1 = Properties.Settings.Default.KULLANICI_SIFRE;
            using (SqlConnection baglanti = new SqlConnection(YetkilendirmeConnection.GetConnectionString(yetkiligiris1)))
            {
                baglanti.Open();
                SqlCommand cmdkontol1 = new SqlCommand("Select *From sys.tables", baglanti);
                SqlDataAdapter dakontrol = new SqlDataAdapter(cmdkontol1);
                SqlDataReader drkontrol = cmdkontol1.ExecuteReader();
                while (drkontrol.Read())
                {
                    tmp2.Add(new YetkiAta1()
                    {
                        TABLO_ADI1 = drkontrol["name"].ToString(),
                    });
                }

            }
        }
    }
}
