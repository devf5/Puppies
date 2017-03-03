using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Cao
    {
        public int ID { get; set; }
        public int RacaID { get; private set; }
        public int UsuarioID { get; private set; }

        public string Nome { get; set; }
        public ESexoCao Sexo { get; private set; }
        public bool Pedigree { get; private set; }
        public bool TeveFilhotes { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; private set; }

        public virtual Raca Raca { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual ICollection<Midia> Midias { get; private set; }

        private Cao()
        {
            this.Midias = new HashSet<Midia>();
            this.DataCadastro = DateTime.Now;
        }

        public Cao(string nome, bool pedigree, bool teveFilhotes, DateTime dataNascimento, Usuario usuario, Raca raca) : base()
        {
            this.Nome = nome;
            this.Pedigree = pedigree;
            this.TeveFilhotes = teveFilhotes;
            this.DataNascimento = this.DataNascimento;
            this.Usuario = usuario;
            this.Raca = raca;
        }
    }
}
