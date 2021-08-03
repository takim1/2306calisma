using _2306calisma.YETKILENDIRME.CONNECTION;
using _2306calisma.YETKILENDIRME.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2306calisma.YETKILENDIRME.BUSINESS
{
    public class YetkiGösterFill
    {
        public static void YetkiGösterDoldur(List<YetkiGöster> tmp1, Object kullaniciadi)
        {
            YetkiliGiris1 yetkiligiris1 = new YetkiliGiris1();
            yetkiligiris1.KULLANICI_ADI1 = Properties.Settings.Default.KULLANICI_ADI;
            yetkiligiris1.SIFRE1 = Properties.Settings.Default.KULLANICI_SIFRE;
            using (SqlConnection baglanti = new SqlConnection(YetkilendirmeConnection.GetConnectionString(yetkiligiris1)))
            {
                baglanti.Open();
                tmp1.Clear();
                SqlCommand cmdkontol = new SqlCommand("Select * from INFORMATION_SCHEMA.TABLE_PRIVILEGES where GRANTEE = " + "'" + kullaniciadi + "'" + " ;", baglanti);
                SqlDataAdapter dakontrol = new SqlDataAdapter(cmdkontol);
                SqlDataReader drkontrol = cmdkontol.ExecuteReader();
                while (drkontrol.Read())
                {
                    tmp1.Add(new YetkiGöster()
                    {
                        YETKI_VEREN = drkontrol["GRANTOR"].ToString(),
                        YETKI_ALAN = drkontrol["GRANTEE"].ToString(),
                        VERI_TABANI = drkontrol["TABLE_CATALOG"].ToString(),
                        //TABLE_SCHEMA = drkontrol["TABLE_SCHEMA"].ToString(),
                        TABLO_ADI = drkontrol["TABLE_NAME"].ToString(),
                        YETKI_TIPI = drkontrol["PRIVILEGE_TYPE"].ToString(),
                        YETKILI_MI = drkontrol["IS_GRANTABLE"].ToString(),

                        //değişiklik

                        //Recep Değişiklik yaptıaaaasdfssdf
                       

                    });
                }
            }
        }
    

    }
}
  



 
