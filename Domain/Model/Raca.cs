using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Raca
    {
        public int ID { get; private set; }
        public string Nome { get; set; }

        public virtual ICollection<Cao> Caes { get; set; }

        private Raca()
        {
            this.Caes = new HashSet<Cao>();
        }

        public Raca(string nome):base()
        {
            this.Nome = nome;
        }
    }
}
