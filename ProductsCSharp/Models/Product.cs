
namespace Models{
    public class Product{

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }        

        public Product(string Nome, decimal Preco){
            this.Nome = Nome;
            this.Preco = Preco;
        }

    }
}