namespace Domain.Model
{
    public class Cidade
    {
        public int ID { get; private set; }
        public string EstadoID { get; private set; }
        public string Nome { get; private set; }

        public virtual Estado Estado { get; private set; }

        private Cidade() { }

        public Cidade(string nome, Estado estado) : base()
        {
            this.Nome = nome;
            this.Estado = estado;
        }
    }
}
