using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using financa.model;
using financa.model.fabrica;

public partial class forms_ExibirComprovante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long id = Convert.ToInt64(Request.QueryString.Get("Id"));
        string tipo = Request.QueryString.Get("tipo");
        //string nome= Request.QueryString["comp"];
        //Response.Write("<div style=position:absolute><img src='" + nome + ".jpg' /></div>");
        //System.IO.Stream comp = ((System.IO.Stream)Session["comp"]);
        //byte[] oc = new byte[comp.Length];
        //int i = 0;
        //while (comp.Position < comp.Length){
        //    oc[i] = (byte)comp.ReadByte();
        //    i++;
        //}
        Response.Clear();
        Context.Response.ContentType = "image/GIF";
        //bmp.Save(context.Response.OutputStream, ImageFormat.Gif);
        Lancamento l = FabricaLancamento.fabricarLancamento(tipo, id);
        //System.Drawing.Image comp = (System.Drawing.Image)Session["comp"];
        MemoryStream ms = new MemoryStream();
        l.Comprovante.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);        
        //  Response.BinaryWrite((byte[])Session["comp"]);
//Pode ser isso que está faltando!! 	
        //Response.ContentType = "jpg"; // myDataReader.Item("PersonImageType")
        Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
        Response.Flush();
        Response.Close();
    }
}
