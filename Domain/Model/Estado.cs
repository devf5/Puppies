using System.Collections.Generic;

namespace Domain.Model
{
    public class Estado
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }

        private Estado()
        {
            this.Cidades = new HashSet<Cidade>();
        }

        public Estado(string nome) : base()
        {
            this.Nome = nome;
        }
    }
}
