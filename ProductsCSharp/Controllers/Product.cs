using Models;
using MyProject.Data;

namespace Controllers{

    public class Product{

        public static void CriarProduct(Models.Product Product){
            using(var context = new Context()){
                context.Products.Add(Product);
                context.SaveChanges();
            }
        }

        public static void AtualizarProduct(Models.Product Product){
            using(var context = new Context()){
                context.Products.Update(Product);
                context.SaveChanges();
            }
        }

        public static void DeletarProduct(Models.Product Product){
            using(var context = new Context()){
                context.Products.Remove(Product);
                context.SaveChanges();
            }
        }

        public static List<Models.Product> ListarProducts(){
            using(var context = new Context()){
                return context.Products.ToList();
            }
        }

        public static Models.Product BuscarProduct(int id){
            using(var context = new Context()){
                return context.Products.Find(id);
            }
    
        }
    }
}
