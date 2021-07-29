using _2306calisma.YETKILENDIRME.BUSINESS;
using _2306calisma.YETKILENDIRME.CONNECTION;
using _2306calisma.YETKILENDIRME.LISTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using _2306calisma.YETKILENDIRME.ENTITIES;

namespace _2306calisma.YETKILENDIRME.PAGES
{
    /// <summary>
    /// Interaction logic for KullaniciGiris.xaml
    /// </summary>
    public partial class KullaniciGiris : UserControl
    {
        List<YetkiliGiris1> yetkiliGirises = new List<YetkiliGiris1>();

        YetkiliGiris1 gir = new YetkiliGiris1();

        public KullaniciGiris()
        {
            InitializeComponent();
        }
        MainWindow a = new MainWindow();

        private void Baglan_Click(object sender, RoutedEventArgs e)
        {

            gir.SIFRE1 = TB_SIFRE.Text;
            gir.KULLANICI_ADI1  = TB_AD.Text;
            Properties.Settings.Default.KULLANICI_ADI = gir.KULLANICI_ADI1;
            Properties.Settings.Default.KULLANICI_SIFRE = gir.SIFRE1;

            SqlConnection SqlConnection = new SqlConnection(YetkilendirmeConnection.GetConnectionString(gir));
            SqlConnection.Open();
            MessageBox.Show("Bağlantı Başarılı");
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            //açıklama ekleee

        }
    }
}

