using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;//Extraindo o usuário por injeção de dependências  
        private readonly IWebHostEnvironment webHostEnvironment;//Está váriavel será a responsável por armazenar os dados da foto que iremos gravar em nosso repositório imag

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await usuarioRepositorio.PegarTodos());
        }


        //[AllowAnonymous]
        [HttpGet]//Get pegamos dados e retornamos formulários
        public IActionResult Registro()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]//Post inserimos os dados em nosso banco de dados
        public async Task<IActionResult> Registro(RegistroViewModel model, IFormFile foto)//IFormFile nos permitirá pegar a foto do usuário e gravar em nosso diretório img, o nome neste caso "foto" deve ser igual ao id neste caso presente em Registro.cshtml, que também é "foto", isto é muito importante
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    string diretorioPasta = Path.Combine(webHostEnvironment.WebRootPath, "Imagens");
                    string nomeFoto = Guid.NewGuid().ToString() + foto.FileName;

                    using (FileStream fileStream = new FileStream(Path.Combine(diretorioPasta, nomeFoto), FileMode.Create))
                    {
                        await foto.CopyToAsync(fileStream);
                        model.Foto = "~/Imagens/" + nomeFoto;
                    }
                }
                else
                {
                    model.Foto = "~/Imagens/ImagemPadrao.png";
                }

                Usuario usuario = new Usuario();
                IdentityResult usuarioCriado;

                if (usuarioRepositorio.VerificarSeExisteRegistro() == 0)//Este caso ocorre quando não temos nenhum usuário cadastrado ainda
                {
                    usuario.UserName = model.Nome;
                    usuario.CPF = model.CPF;
                    usuario.Email = model.Email;
                    usuario.PhoneNumber = model.Telefone;
                    usuario.Foto = model.Foto;
                    usuario.PrimeiroAcesso = false;
                    usuario.Status = StatusConta.Aprovado;

                    usuarioCriado = await usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                    if (usuarioCriado.Succeeded)
                    {
                        await usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Administrador");
                        await usuarioRepositorio.LogarUsuario(usuario, false);

                        return RedirectToAction("Index", "Usuarios");
                    }

                }

                usuario.UserName = model.Nome;
                usuario.CPF = model.CPF;
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.Telefone;
                usuario.Foto = model.Foto;
                usuario.PrimeiroAcesso = true;
                usuario.Status = StatusConta.Analisando;

                usuarioCriado = await usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    return View("Analise", usuario.UserName);
                }
                else
                {
                    foreach (var erro in usuarioCriado.Errors)
                    {
                        ModelState.AddModelError("", erro.Description);
                    }

                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Analise(string nome)
        {
            return View(nome);
        }

        public IActionResult Reprovado(string nome)
        {
            return View(nome);
        }

        public async Task<JsonResult> AprovarUsuario(string usuarioId)
        {
            Usuario usuario = await usuarioRepositorio.PegarPeloId(usuarioId);
            usuario.Status = StatusConta.Aprovado;

            await usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Morador");
            await usuarioRepositorio.AtualizarUsuario(usuario);

            return Json(true);
        }

        public async Task<JsonResult> ReprovarUsuario(string usuarioId)
        {
            Usuario usuario = await usuarioRepositorio.PegarPeloId(usuarioId);
            usuario.Status = StatusConta.Reprovado;

            await usuarioRepositorio.AtualizarUsuario(usuario);

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                await usuarioRepositorio.DeslogarUsuario();
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Usuario usuario = await usuarioRepositorio.PegarUsuarioPeloEmail(model.Email);

            if (ModelState.IsValid)
            {

                if (usuario != null)
                {
                    if (usuario.Status == StatusConta.Analisando)
                    {
                        return View("Analise", usuario.UserName);
                    }
                    else if (usuario.Status == StatusConta.Reprovado)
                    {
                        return View("Reprovado", usuario.UserName);
                    }
                    else if (usuario.PrimeiroAcesso == true)
                    {
                        
                       return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();

                        if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != (PasswordVerificationResult.Failed))
                        {
                            await usuarioRepositorio.LogarUsuario(usuario, false);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Usuario e/ou senhas inválidas");
                            return View(model);
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario e/ou senhas inválidas");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await usuarioRepositorio.DeslogarUsuario();
            return RedirectToAction("Login");
        }

       

    }
}
