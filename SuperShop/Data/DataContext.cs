using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    //Herança (o meu DataContext vai herdar do DbContext da Microsoft.EntityFrameworkCore)
    public class DataContext : DbContext
    {
        //propriedade responsável pela tabela de produtos
        public DbSet<Product> Products { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
