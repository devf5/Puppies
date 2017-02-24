using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Model;

namespace API.ModelViews.Usuario
{
    public class UsuarioSessao
    {
        public UsuarioSessao(Sessao sessao)
        {
            this.Sessao = sessao?.ID ?? Guid.Empty;
            this.Nome = sessao?.Usuario?.Nome;
            this.Sobrenome = sessao?.Usuario?.Sobrenome;
            this.Email = sessao?.Usuario?.Email;
            this.Foto = sessao?.Usuario?.Foto;
        }

        public Guid Sessao { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public byte[] Foto { get; set; }
    }
}