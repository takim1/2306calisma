using _2306calisma.YETKILENDIRME.CONNECTION;
using _2306calisma.YETKILENDIRME.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2306calisma.YETKILENDIRME.MODELS
{
   public class Tamamla
    { 
        public static void YetkiVer(YetkiliGiris1 yetkiliGiris1, string personeladi, string tabloadi, string yetkituru)
        {       
            SqlConnection sqlConnection = new SqlConnection(YetkilendirmeConnection.GetConnectionString(yetkiliGiris1));
            sqlConnection.Open();
            string queryString1 = "GRANT "+ yetkituru + " ON " + tabloadi + " TO " + personeladi ;
            SqlCommand command1 = new SqlCommand(queryString1, sqlConnection);
            command1.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public static void YetkiAl(YetkiliGiris1 yetkiliGiris1, string personeladi, string tabloadi, string yetkituru)
        {
            SqlConnection sqlConnection = new SqlConnection(YetkilendirmeConnection.GetConnectionString(yetkiliGiris1));
            sqlConnection.Open();
            string queryString1 = "REVOKE " + yetkituru + " ON " + tabloadi + " TO " + personeladi;
            SqlCommand command1 = new SqlCommand(queryString1, sqlConnection);
            command1.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
