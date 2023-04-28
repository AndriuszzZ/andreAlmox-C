namespace Models{
    public class Almox{
        public int Id { get; set; }
        public string Nome { get; set; }

        public Almox(string Nome){
            this.Nome = Nome;
        }
    }
}