using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Usuario
    {
        public int ID { get; private set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; private set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
        public virtual ICollection<Cao> Caes { get; set; }

        private Usuario()
        {
            this.Sessoes = new HashSet<Sessao>();
            this.Caes = new HashSet<Cao>();
        }

        public Usuario(string nome, string email, string senha)
            : base()
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = Seguranca.Hash(senha);
        }

        public bool ValidaLogin(string email, string senha)
        {
            return String.Compare(email, this.Email, true) == 0 && this.Senha == Seguranca.Hash(senha);
        }
    }
}
