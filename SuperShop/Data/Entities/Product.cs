using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //formato moeda com duas casas decimais mas em modo edição não formata nada, deixa a pessoa escrever
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")] //Para aparecer 'Image' escrito na página da WEB
        public string ImageUrl { get; set; } //link da imagem do produto

        //ultima compra
        [Display(Name = "Last Purchase")]
        public DateTime LastPurchase { get; set; }


        //ultima venda
        [Display(Name = "Last Sale")]
        public DateTime LastSale { get; set; }

        //para saber se o produto está disponivel ou não
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        //formato número com duas casas decimais
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }
    }
}
