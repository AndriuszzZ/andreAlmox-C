using System.ComponentModel.DataAnnotations.Schema;

namespace Models{

    public class Saldo{
        [Column("id")]
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int Id { get; set; }
        [Column("produto_id")]
        public int IdProduto { get; set; }
        [Column("almoxarifado_id")]
        public int IdAlmoxarifado { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }

        public Saldo(int IdProduto, int IdAlmoxarifado, int Quantidade){
            this.IdProduto = IdProduto;
            this.IdAlmoxarifado = IdAlmoxarifado;
            this.Quantidade = Quantidade;
        }
    }
}