using _2306calisma.YETKILENDIRME.BUSINESS;
using _2306calisma.YETKILENDIRME.CONNECTION;
using _2306calisma.YETKILENDIRME.ENTITIES;
using _2306calisma.YETKILENDIRME.LISTS;
using _2306calisma.YETKILENDIRME.MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace _2306calisma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        YetkiliGiris1 gir = new YetkiliGiris1();


        public MainWindow()
        {
            InitializeComponent();

            ComboBoxFill.PersonelTablo("sysusers", "name", CB_Personel);
            DataGrid1Fill.DataGridFill(Yetkilendirme.yetkiAta1s);
            Dgv_Deneme.ItemsSource = null;
            Dgv_Deneme.ItemsSource = Yetkilendirme.yetkiAta1s;

            gir.KULLANICI_ADI1 = Properties.Settings.Default.KULLANICI_ADI;
            gir.SIFRE1 = Properties.Settings.Default.KULLANICI_SIFRE;


        }

        #region   // YETKİ ATAMA KODLARI
        private void Yetki_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection SqlConnection = new SqlConnection(YetkilendirmeConnection.GetConnectionString(gir));
            SqlConnection.Open();
            foreach (var item in Yetkilendirme.yetkiAta1s)
            {
                if (item.SELECT == true)
                {
                    Tamamla.YetkiVer(gir, CB_Personel.Text, item.TABLO_ADI1, "SELECT");
                }
                else
                {
                    Tamamla.YetkiAl(gir, CB_Personel.Text, item.TABLO_ADI1, "SELECT");
                }
                if (item.INSERT == true)
                {
                    Tamamla.YetkiVer(gir, CB_Personel.Text, item.TABLO_ADI1, "INSERT");
                }
                else
                {
                    Tamamla.YetkiAl(gir, CB_Personel.Text, item.TABLO_ADI1, "INSERT");
                }
                if (item.UPDATE == true)
                {
                    Tamamla.YetkiVer(gir, CB_Personel.Text, item.TABLO_ADI1, "UPDATE");
                }
                else
                {
                    Tamamla.YetkiAl(gir, CB_Personel.Text, item.TABLO_ADI1, "UPDATE");
                }
            }
        }
        #endregion
        #region //YETKİ GÖSTERME KODLARI
        private void CB_Personel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            if (CB_Personel.SelectedItem != null  )
            {

            YetkiGösterFill.YetkiGösterDoldur(Yetkilendirme.YetkiGösters, CB_Personel.SelectedItem);
            //Dgv_Göster.ItemsSource = null;
            //Dgv_Göster.ItemsSource = Yetkilendirme.YetkiGösters;
          
                Yetkilendirme.yetkiAta1s.ToList().ForEach(c => { c.SELECT = false; c.INSERT = false; c.UPDATE = false; });

                foreach (var item1 in Yetkilendirme.YetkiGösters)
                {
                    foreach (var item in Yetkilendirme.yetkiAta1s)
                    {
                        if (item.TABLO_ADI1 == item1.TABLO_ADI)
                        {
                            if (item1.YETKI_TIPI == "SELECT")
                            {
                                item.SELECT = true;
                            }

                            if (item1.YETKI_TIPI == "INSERT")
                            {
                                item.INSERT = true;
                            }

                            if (item1.YETKI_TIPI == "UPDATE")
                            {
                                item.UPDATE = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}








