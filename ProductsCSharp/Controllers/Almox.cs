using Models;
using MyProject.Data;

namespace Controllers{

    public class Almox{
            
        public static void CriarAlmox(Models.Almox almox){
            using(var context = new Context()){
                context.Almox.Add(almox);
                context.SaveChanges();
            }
        }

        public static void AtualizarAlmox(Models.Almox almox){
            using(var context = new Context()){
                context.Almox.Update(almox);
                context.SaveChanges();
            }
        }

        public static void DeletarAlmox(Models.Almox almox){
            using(var context = new Context()){
                context.Almox.Remove(almox);
                context.SaveChanges();
            }
        }

        public static List<Models.Almox> ListarAlmox(){
            using(var context = new Context()){
                return context.Almox.ToList();
            }
        }

        public static Models.Almox BuscarAlmox(int id){
            using(var context = new Context()){
                return context.Almox.Find(id);
            }
    
        }
    }
}