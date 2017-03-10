using System.Collections.Generic;

namespace Domain.Model
{
    public class Raca
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }

        public virtual ICollection<Cao> Caes { get; set; }

        private Raca()
        {
            this.Caes = new HashSet<Cao>();
        }

        public Raca(string nome) : base()
        {
            this.Nome = nome;
        }
    }
}
