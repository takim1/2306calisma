using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2306calisma.YETKILENDIRME.ENTITIES
{
    public class YetkiliGiris1
    {
        public string KULLANICI_ADI1 { get; set; }
        public string SIFRE1 { get; set; }
    }

    public class YetkiGöster
    {
        public string YETKI_VEREN { get; set; }
        public string YETKI_ALAN { get; set; }
        public string VERI_TABANI { get; set; }
       
        public string TABLO_ADI{ get; set; }
        public string YETKI_TIPI { get; set; }
        public string YETKILI_MI { get; set; } 
    }
    public class KullaniciAdi
    {
        public string KULLANICI_ADICOMBO { get; set; }

    }
   

}

