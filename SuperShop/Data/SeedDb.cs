using SuperShop.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;//Para gerar preços e stocks aleatóriamente

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            //ver se a base de dados está criada e se não tiver criada, cria
            await _context.Database.EnsureCreatedAsync();

            //criar produtos dentro da tabela
            if (!_context.Products.Any()) //senão existirem produtos lá dentro
            {
                //Método para criar produtos
                AddProduct("iPhone X");
                AddProduct("Magic Mouse");
                AddProduct("iWatch Series 4");
                AddProduct("iPad Mini");

                //Guardar na base de dados
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true, //Por defeito está sempre disponivel
                Stock = _random.Next(100)
            });
        }
    }
}
