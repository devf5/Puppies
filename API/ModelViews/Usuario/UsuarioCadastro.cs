using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.ModelViews.Usuario
{
    public class UsuarioCadastro
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public EDispositivo Dispositivo { get; set; }
    }
}