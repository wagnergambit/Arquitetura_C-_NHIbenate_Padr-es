using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arquitetura.Domain.ValueObjects;
using Arquitetura.Domain.Entity;
using Arquitetura.Repository.Repository;

namespace Arquitetura.MVC.UI.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar(int page, int rows, string sidx, string sord, string filters, bool _search)
        {
            GridParam param = new GridParam();

            param.sidx = sidx;
            param.sord = sord;
            param.filters = filters;
            param.rows = rows;
            param._search = _search;
            param.page = page;

            OperacoesGrid<Usuario> opGDUsuario = new OperacoesGrid<Usuario>();

            List<Usuario> listaUsuario = opGDUsuario.configuraPesquisa(param, CarregaGrid());

            var reader = new Reader<Usuario>(listaUsuario, param.page, param.rows);

            return Json(reader);
        }

        public List<Usuario> CarregaGrid()
        {
            BaseRepository<Usuario> usuario = new BaseRepository<Usuario>();

            List<Usuario> lstClientes = usuario.ListaTodos().ToList();
            return lstClientes;
        }

        #region Incluir
        /// <summary>
        /// Popula a Grid
        /// </summary>
        /// <param name="param">parametros da grid </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Inserir(Usuario usuario)
        {

            BaseRepository<Usuario> persistUsuario = new BaseRepository<Usuario>();
            persistUsuario.Salva(usuario);
            return Json("ok");
        }
        #endregion

        #region deletar
        /// <summary>
        /// Popula a Grid
        /// </summary>
        /// <param name="param">parametros da grid </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult deletar(Usuario usuario)
        {

            BaseRepository<Usuario> persistUsuario = new BaseRepository<Usuario>();
            persistUsuario.Exclui(usuario);
            return Json("ok");
        }
        #endregion

    }
}
