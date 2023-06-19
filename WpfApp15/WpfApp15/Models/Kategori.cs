using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp15.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        public string KategoriAdı { get; set; }

        public virtual ICollection<Haber> Haberler { get; set; } = new HashSet<Haber>();
    }
}
