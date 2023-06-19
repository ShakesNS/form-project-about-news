using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp15.Models
{
    public class Haber
    {
        public int Id { get; set; }

        public DateTime Tarih { get; set; }

        public string Başlık { get; set; }

        public string İçerik { get; set; }

        public bool Okundu { get; set; }

        public int OkunmaSayısı { get; set; }

        public byte[] ResimArray { get; set; }

        [NotMapped]
        public BitmapSource Resim
        {
            get
            {
                BitmapSource resim = null;
                if (ResimArray != null && ResimArray.Length > 0)
                {
                    using (var stream = new MemoryStream(ResimArray))
                    {
                        var kodÇözücü = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        resim = kodÇözücü.Frames[0];
                    }
                }
                return resim;
            }
            set
            {
                byte[] byteDizisi;
                if (value == null)
                {
                    byteDizisi = new byte[0];
                }
                else
                {
                    using (var stream = new MemoryStream())
                    {
                        var kodlayıcı = new JpegBitmapEncoder();
                        kodlayıcı.Frames.Add(BitmapFrame.Create(value));
                        kodlayıcı.Save(stream);
                        byteDizisi = stream.ToArray();
                    }
                }
                ResimArray = byteDizisi;
            }
        }

        [ForeignKey(nameof(Kategori))]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
