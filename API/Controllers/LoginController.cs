using API.ModelViews.Usuario;
using Data;
using Domain.Enums;
using Domain.Model;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        private PuppiesContext _db = new PuppiesContext();

        // GET: api/Login
        public IHttpActionResult Get(string email, string senha, EDispositivo dispositivo)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(senha))
                return BadRequest("Email ou senha incorreto");

            var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null || usuario.Senha != Seguranca.Hash(senha))
                return BadRequest("Email ou senha incorreto");

            var sessao = new Sessao(usuario, dispositivo, HttpContext.Current.Request.UserHostAddress);

            _db.Sessoes.Add(sessao);
            _db.SaveChanges();

            return Ok(new UsuarioSessao(sessao));
        }

        // GET: api/Login/5
        public IHttpActionResult Get(Guid id)
        {
            var sessao = _db.Sessoes.Find(id);
            if (sessao == null)
                return NotFound();

            return Ok(sessao);
        }

        // POST: api/Login
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Post([FromBody]UsuarioCadastro obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_db.Usuarios.Any(u => u.Email == obj.Email))
                return BadRequest("Email já cadastrado");

            var usuario = new Usuario(obj.Nome, obj.Email, obj.Senha);
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            var sessao = new Sessao(usuario, obj.Dispositivo, HttpContext.Current.Request.UserHostAddress);

            _db.Sessoes.Add(sessao);
            _db.SaveChanges();

            return Ok(new UsuarioSessao(sessao));
        }
    }
}
