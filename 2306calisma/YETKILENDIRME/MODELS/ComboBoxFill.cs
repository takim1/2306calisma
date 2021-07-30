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
    public class ComboBoxFill
    {
        public static void PersonelTablo(string tabloadi, string sutun, ComboBox Box)
        {
            if (Box.Items.Count > 0)
            {
                Box.Items.Clear();
            }
            YetkiliGiris1 yetkiligiris1 = new YetkiliGiris1();
            yetkiligiris1.KULLANICI_ADI1 = Properties.Settings.Default.KULLANICI_ADI;
            yetkiligiris1.SIFRE1 = Properties.Settings.Default.KULLANICI_SIFRE;
            
            using (SqlConnection baglanti = new SqlConnection(YetkilendirmeConnection.GetConnectionString(yetkiligiris1)))
            {
                

                baglanti.Open();
                SqlCommand cmdkontol = new SqlCommand("SELECT * FROM " + tabloadi + " WHERE name NOT LIKE 'public' AND name NOT LIKE 'dbo' AND name NOT LIKE 'guest' AND name NOT LIKE 'INFORMATION_SCHEMA'  AND name NOT LIKE 'sys' AND name NOT LIKE 'db%'", baglanti);
                cmdkontol.Connection = baglanti;

                SqlDataAdapter dakontrol = new SqlDataAdapter(cmdkontol);
                SqlDataReader drkontrol = cmdkontol.ExecuteReader();
                while (drkontrol.Read())
                {

                    Box.Items.Add(drkontrol[sutun].ToString());
                }
            }

        }
    }
}
