using Models;
using MyProject.Data;

namespace Controllers{
    public class Saldo{

        public static void CriarSaldo(Models.Saldo saldo){
            using(var context = new Context()){
                context.Saldos.Add(saldo);
                context.SaveChanges();
            }
        }

        public static void AtualizarSaldo(Models.Saldo saldo){
            using(var context = new Context()){
                context.Saldos.Update(saldo);
                context.SaveChanges();
            }
        }

        public static void DeletarSaldo(Models.Saldo saldo){
            using(var context = new Context()){
                context.Saldos.Remove(saldo);
                context.SaveChanges();
            }
        }

        public static List<Models.Saldo> ListarSaldos(){
            using(var context = new Context()){
                return context.Saldos.ToList();
            }
        }

        public static Models.Saldo BuscarSaldo(int id){
            using(var context = new Context()){
                return context.Saldos.Find(id);
            }
    
        }
    }
}