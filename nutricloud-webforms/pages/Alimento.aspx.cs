using nutricloud_webforms.DataBase;
using nutricloud_webforms.Models;
using nutricloud_webforms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nutricloud_webforms
{
    public partial class Alimento : System.Web.UI.Page
    {
        AlimentoRepository ar = new AlimentoRepository();
        DiarioRepository dr = new DiarioRepository();
        UsuarioCompleto ur = new UsuarioCompleto();
        FavoritosRepository fr = new FavoritosRepository();

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
            usuario_alimento_favorito uaf = new usuario_alimento_favorito();
            string idalimento = Server.UrlDecode(Request.QueryString["Idalimento"].ToString());

            int idaliment = Convert.ToInt32(Server.UrlDecode(Request.QueryString["Idalimento"].ToString()));
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            if (UsuarioCompleto != null)
            {
                int idusuario = UsuarioCompleto.Usuario.id_usuario;
                uaf = fr.BuscarAliFav(idaliment, idusuario);

                if (uaf != null)
                {
                    add_fav.Visible = false;
                    del_fav.Visible = true;
                }
                else
                {
                    add_fav.Visible = true;
                    del_fav.Visible = false;
                }
            }
            else
            {
                add_fav.Visible = false;
                del_fav.Visible = false;
            }

            alimento a = ar.BuscarAlimentoId(idalimento);
            LblNombre.Text = a.nombre_alimento;
            LblCalo.Text = Convert.ToString(a.energia_kcal);
            LblCalo2.Text = Convert.ToString(a.energia_kcal);
            LblCarbo.Text = Convert.ToString(a.carbohidratos_totales_g);
            lblCarbo2.Text = Convert.ToString(a.carbohidratos_totales_g);
            LblProt.Text = Convert.ToString(a.proteinas_g);
            LblProt2.Text = Convert.ToString(a.proteinas_g);
            LblGrasa.Text = Convert.ToString(a.grasa_total_g);
            LblGrasa2.Text = Convert.ToString(a.grasa_total_g);
            LblAgua.Text = Convert.ToString(a.agua_g);
            LblFibra.Text = Convert.ToString(a.fibra_dietetica_g);
            LblVitC.Text = Convert.ToString(a.vitamina_c_mg);
            LblCal.Text = Convert.ToString(a.calcio_mg);
            LblHie.Text = Convert.ToString(a.hierro_mg);
            LblB1.Text = Convert.ToString(a.tiamina_mg);
            LblB2.Text = Convert.ToString(a.rivoflavina_mg);
            LblB3.Text = Convert.ToString(a.niacina_mg);
            Hidden1.Value = Convert.ToString(a.id_alimento);

              LblTipo.Text = a.alimento_tipo.unidad_medida;

            if (Session["UsuarioCompleto"] == null)
                agregar.Visible = false;
            else
            {
                if (UsuarioCompleto.Usuario.id_usuario_tipo == 2)
                    agregar.Visible = false;
            }
        }

        protected void ingresar_Click(object sender, EventArgs e)
        {
            string id = Hidden1.Value;

            alimento a = ar.BuscarAlimentoId(id);
            usuario_alimento diario = new usuario_alimento();
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            DateTime fecha = (DateTime)Session["fecha_diario"];

            diario.id_alimento = a.id_alimento;
            diario.id_comida_tipo = Convert.ToInt32(ddlComidaTipo.SelectedValue);
            diario.id_usuario = Convert.ToInt32(UsuarioCompleto.Usuario.id_usuario);
            diario.cantidad = Convert.ToInt32(porcion.Text);
            diario.f_ingreso = fecha;
            
            if (diario != null)
            {
                dr.IngresarAlimentoDiario(diario);
                Response.Redirect("Home.aspx");
            }
        }

        protected void add_fav_Click(object sender, EventArgs e)
        {

            usuario_alimento_favorito uaf = new usuario_alimento_favorito();
            int idalimento = Convert.ToInt32(Server.UrlDecode(Request.QueryString["Idalimento"].ToString()));
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];
            int idusuario = UsuarioCompleto.Usuario.id_usuario;

            uaf.id_alimento = idalimento;
            uaf.id_usuario = idusuario;

            fr.add(uaf);

            add_fav.Visible = false;
            del_fav.Visible = true;

        }
        protected void del_fav_Click(object sender, EventArgs e)
        {
            usuario_alimento_favorito uaf = new usuario_alimento_favorito();
            UsuarioCompleto UsuarioCompleto = (UsuarioCompleto)Session["UsuarioCompleto"];

            int idalimento = Convert.ToInt32(Server.UrlDecode(Request.QueryString["Idalimento"].ToString()));
            int idusuario = UsuarioCompleto.Usuario.id_usuario;

            uaf = fr.BuscarAliFav(idalimento, idusuario);

            if (uaf != null)
            {
                fr.delete(uaf);

                add_fav.Visible = true;
                del_fav.Visible = false;
            }
            else infor.Text = "Error. Intente mas tarde.";
        }
    }
}