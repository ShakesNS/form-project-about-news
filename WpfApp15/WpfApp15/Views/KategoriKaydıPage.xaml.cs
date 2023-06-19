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
    /// Interaction logic for KategoriKaydıPage.xaml
    /// </summary>
    public partial class KategoriKaydıPage : Page
    {
        Kategori Kategori;

        public KategoriKaydıPage()
        {
            InitializeComponent();
        }

        public KategoriKaydıPage(Kategori kategori)
        {
            InitializeComponent();
            Kategori = kategori;
            TbKategoriAdı.Text = kategori.KategoriAdı;
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            #region Hata Kontrolü

            string hata = "";
            if (string.IsNullOrWhiteSpace(TbKategoriAdı.Text))
                hata += "Başlık yazmalısınız.";
            if (hata != "")
            {
                MessageBox.Show(hata, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #endregion

            if (Kategori == null)
            {
                Kategori = new Kategori();
                Veriler.Db.Kategoriler.Add(Kategori);
            }

            Kategori.KategoriAdı = TbKategoriAdı.Text;

            Veriler.Db.SaveChanges();

            NavigationService.Navigate(new HaberListesiPage());
        }

        private void TbKategoriAdı_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnKaydet_Click(null, null);
            }
        }
    }
}
