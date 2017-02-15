using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Sessao
    {
        private const int _diasExpiracao = 45;

        public Guid ID { get; private set; }
        public int UsuarioID { get; private set; }

        public bool Encerrada { get; set; }
        public string UltimoIP { get; private set; }
        public EDispositivo Dispositivo { get; private set; }
        public DateTime UltimoAcesso { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        protected Sessao() { }
        public Sessao(Usuario usuario, EDispositivo dispositivo, string ip)
        {
            this.ID = Guid.NewGuid();
            this.Usuario = usuario;
            this.Encerrada = false;
            this.UltimoAcesso = DateTime.Now;
            this.Dispositivo = dispositivo;
            this.UltimoIP = ip;
        }

        public bool Valida()
        {
            bool expirada = (this.UltimoAcesso.AddDays(_diasExpiracao) <= DateTime.Now);
            return (expirada || Encerrada);
        }
        
        public void AtualizarAcesso(string ip)
        {
            this.UltimoAcesso = DateTime.Now;
            this.UltimoIP = ip;
        }
    }
}
