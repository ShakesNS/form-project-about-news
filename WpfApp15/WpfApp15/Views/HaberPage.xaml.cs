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
using WpfApp15.Models;

namespace WpfApp15.Views
{
    /// <summary>
    /// Interaction logic for HaberPage.xaml
    /// </summary>
    public partial class HaberPage : Page
    {
        public HaberPage(Haber haber)
        {
            InitializeComponent();

            haber.OkunmaSayısı++;
            Veriler.Db.SaveChanges();

            LblOkunmaSayısı.Content = $"Okunma Sayısı: {haber.OkunmaSayısı}";
            ImgResim.Source = haber.Resim;
            TxtTarih.Text = haber.Tarih.ToString("dd.MM.yyyy HH:mm");
            TxtKategori.Text = haber.Kategori.KategoriAdı;
            TxtBaşlık.Text = haber.Başlık;
            Txtİçerik.Text = haber.İçerik;
        }

        private void BtnGeri_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
