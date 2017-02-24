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
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; private set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }

        protected Usuario()
        {
            this.Sessoes = new HashSet<Sessao>();
        }

        public Usuario(string nome, string sobrenome, string email, string senha)
            : base()
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Senha = Seguranca.Hash(senha);
        }

        public bool ValidaLogin(string email, string senha)
        {
            return String.Compare(email, this.Email, true) == 0 && this.Senha == Seguranca.Hash(senha);
        }
    }
}
