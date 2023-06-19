namespace WpfApp15.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Haber> Haberler { get; set; }
    }
}