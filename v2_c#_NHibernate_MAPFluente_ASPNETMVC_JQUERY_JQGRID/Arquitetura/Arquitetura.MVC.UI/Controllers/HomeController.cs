using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arquitetura.Domain.Entity;
using Arquitetura.Repository.Repository;
using Arquitetura.Domain.ValueObjects;

namespace Arquitetura.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

            OperacoesGrid<Clientes> opGDUsuario = new OperacoesGrid<Clientes>();

            List<Clientes> listaUsuario = opGDUsuario.configuraPesquisa(param, CarregaGrid());

            var reader = new Reader<Clientes>(listaUsuario, param.page, param.rows);

            return Json(reader);
        }

        public List<Clientes> CarregaGrid()
        {
            BaseRepository<Clientes> cliente = new BaseRepository<Clientes>();

            List<Clientes> lstClientes = cliente.ListaTodos().ToList();
            return lstClientes;
        }

        #region Incluir
        /// <summary>
        /// Popula a Grid
        /// </summary>
        /// <param name="param">parametros da grid </param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Inserir(Clientes cliente)
        {

            BaseRepository<Clientes> persistUsuario = new BaseRepository<Clientes>();
            persistUsuario.Salva(cliente);
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
        public JsonResult deletar(Clientes cliente)
        {

            BaseRepository<Clientes> persistUsuario = new BaseRepository<Clientes>();
            persistUsuario.Exclui(cliente);
            return Json("ok");
        }
        #endregion
    }
}
