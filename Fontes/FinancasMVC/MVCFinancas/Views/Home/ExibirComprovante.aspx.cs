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

public partial class forms_ExibirComprovante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string nome= Request.QueryString["comp"];
        //Response.Write("<div style=position:absolute><img src='" + nome + ".jpg' /></div>");
        System.IO.Stream comp = ((System.IO.Stream)Session["comp"]);
        byte[] oc = new byte[comp.Length];
        int i = 0;
        while (comp.Position < comp.Length){
            oc[i] = (byte)comp.ReadByte();
            i++;
        }
        //  Response.BinaryWrite((byte[])Session["comp"]);
//Pode ser isso que está faltando!! 	
//Response.ContentType = myDataReader.Item("PersonImageType")

        Response.OutputStream.Write(oc, 0, (int)comp.Length);
        //Response.
    }
}
