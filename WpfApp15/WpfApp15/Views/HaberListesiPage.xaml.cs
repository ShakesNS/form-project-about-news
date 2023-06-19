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
    /// Interaction logic for HaberListesiPage.xaml
    /// </summary>
    public partial class HaberListesiPage : Page
    {
        public HaberListesiPage()
        {
            InitializeComponent();
            Listele();
        }

        private void Listele()
        {
            if (string.IsNullOrWhiteSpace(TbFiltre.Text))
                DgKategoriler.ItemsSource = Veriler.Db.Kategoriler.ToArray();
            else
                DgKategoriler.ItemsSource = Veriler.Db.Kategoriler.Where(k => k.KategoriAdı.StartsWith(TbFiltre.Text)).ToArray();
        }

        private void MiOku_Click(object sender, RoutedEventArgs e)
        {
            Haber seçiliHaber = (Haber)DgHaberler.SelectedItem;
            if (seçiliHaber != null)
            {
                NavigationService.Navigate(new HaberPage(seçiliHaber));
            }
        }

        private void MiDüzenle_Click(object sender, RoutedEventArgs e)
        {
            Haber seçiliHaber = (Haber)DgHaberler.SelectedItem;
            if (seçiliHaber != null)
            {
                NavigationService.Navigate(new HaberKaydıPage(seçiliHaber));
            }
        }

        private void MiSil_Click(object sender, RoutedEventArgs e)
        {
            Haber seçiliHaber = (Haber)DgHaberler.SelectedItem;
            if (seçiliHaber != null)
            {
                var cevap = MessageBox.Show("Seçili haber silinsin mi?", "Sil", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (cevap == MessageBoxResult.Yes)
                {
                    Veriler.Db.Haberler.Remove(seçiliHaber);
                    Veriler.Db.SaveChanges();
                    DgHaberler.Items.Refresh();
                }
            }
        }

        private void TbFiltre_TextChanged(object sender, TextChangedEventArgs e)
        {
            Listele();
        }
    }
}
