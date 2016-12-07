using System;
using System.Collections.Generic;
using System.Linq;
using nutricloud_webforms.Repositories;
using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;

namespace nutricloud_webforms
{
    public partial class Buscador : System.Web.UI.Page
    {
        UsuarioCompleto ur = new UsuarioCompleto();


        void Page_PreInit(object sender, EventArgs e)
        {
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto == null)
                this.Page.MasterPageFile = "~/Anon.Master";
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 1)
                    this.Page.MasterPageFile = "~/HeaderFooter.Master";
                else if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    this.Page.MasterPageFile = "~/MasterPro.Master";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            string nombrealimento = TxtBuscar.Text;

            if (nombrealimento.Trim() != string.Empty)
            {
                AlimentoRepository ar = new AlimentoRepository();
                List<alimento> a = ar.BuscarAlimento(nombrealimento);

                lblMsjSinResultados.Text = "";

                if (a.Count() > 0)
                {
                    repalimentos.DataSource = a;
                    repalimentos.DataBind();
                }
                else
                {
                    lblMsjSinResultados.Text = "No se encontraron resultados";
                }
            }
        }

    }
}