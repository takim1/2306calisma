using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _2306calisma.YETKILENDIRME.ENTITIES;
namespace _2306calisma.YETKILENDIRME.CONNECTION
{
    public class YetkilendirmeConnection
    {
        public static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public static string GetConnectionString(YetkiliGiris1 kullanici)
        {
            builder.UserID =kullanici.KULLANICI_ADI1;
            builder.Password = kullanici.SIFRE1;
            builder["Data Source"] = "192.168.4.98";
            //builder["Integrated Security"] = true;
            builder["Initial Catalog"] = "EntityYetkilendirme";
            return builder.ConnectionString;
            
         
        }   
        

       
    }    
} 






