using Microsoft.Win32;
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
    /// Interaction logic for HaberKaydıPage.xaml
    /// </summary>
    public partial class HaberKaydıPage : Page
    {
        Haber Haber;

        public HaberKaydıPage()
        {
            InitializeComponent();
            CbKategoriler.ItemsSource = Veriler.Db.Kategoriler.ToArray();
        }

        public HaberKaydıPage(Haber haber)
        {
            InitializeComponent();
            CbKategoriler.ItemsSource = Veriler.Db.Kategoriler.ToArray();
            Haber = haber;
            TbBaşlık.Text = haber.Başlık;
            Tbİçerik.Text = haber.İçerik;
            CbKategoriler.SelectedItem = haber.Kategori;
            ImgResim.Source = haber.Resim;
        }

        private void BtnResimSeç_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Resim Seç",
                Filter = "Resim Dosyaları|*.jpg;*.png;*.bmp"
            };
            if (ofd.ShowDialog() == true)
            {
                ImgResim.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            #region Hata Kontrolü

            string hata = "";
            if (CbKategoriler.SelectedItem == null)
                hata += "Kategori seçilmelidir.";
            if (string.IsNullOrWhiteSpace(TbBaşlık.Text))
                hata += "Başlık yazmalısınız.";
            if (string.IsNullOrWhiteSpace(Tbİçerik.Text))
                hata += "İçerik yazmalısınız.";
            if (hata != "")
            {
                MessageBox.Show(hata, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #endregion

            if (Haber == null)
            {
                Haber = new Haber();
                Veriler.Db.Haberler.Add(Haber);
            }

            Haber.Tarih = DateTime.Now;
            Haber.Kategori = (Kategori)CbKategoriler.SelectedItem;
            Haber.Başlık = TbBaşlık.Text;
            Haber.İçerik = Tbİçerik.Text;
            Haber.Resim = (BitmapSource)ImgResim.Source;

            Veriler.Db.SaveChanges();

            NavigationService.Navigate(new HaberListesiPage());
        }
    }
}
