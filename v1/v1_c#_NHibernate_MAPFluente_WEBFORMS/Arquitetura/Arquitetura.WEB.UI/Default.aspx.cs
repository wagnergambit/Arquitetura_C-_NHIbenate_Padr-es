using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Domain.Entity;
using Arquitetura.Repository.Repository;

namespace Arquitetura.WEB.UI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = Consulta();
            GridView1.DataBind();
        }

        public IList<Clientes> Consulta()
        {
            BaseRepository<Clientes> cliente = new BaseRepository<Clientes>();

            IList<Clientes> lstClientes = cliente.ListaTodos();
            return lstClientes;
        }
    }
}
