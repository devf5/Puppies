using API.ModelViews.Usuario;
using Data;
using Domain.Model;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class HomeController : ApiController
    {
        PuppiesContext _db;
        public HomeController()
        {
            _db = new PuppiesContext();
        }

        [HttpGet]
        public string Index(string senha)
        {
            return Seguranca.Hash(senha);
        }

        [HttpPost]
        public Usuario Cadastro(UsuarioCadastro obj)
        {
            var usuario = new Usuario(obj.Nome, obj.Sobrenome, obj.Email, obj.Senha);

            using (_db)
            {
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();
            }

            return usuario;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
