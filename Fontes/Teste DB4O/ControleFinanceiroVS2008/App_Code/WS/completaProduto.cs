using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using financa.model;
using AjaxControlToolkit;

/// <summary>
/// Summary description for completaProduto
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class completaProduto : System.Web.Services.WebService {

    public completaProduto () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod]
    public string[] listarProduto(string prefixText, int count)
    {
        Produto prod = new Produto();
        List<string> items = new List<string>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        foreach (Produto p in prod.listar(prefixText))
        {
            items.Add(AutoCompleteExtender.CreateAutoCompleteItem
                (p.Nome + "   :  " + p.Valor, serializer.Serialize(p)));
        }
           
        return (items.ToArray());
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }

        if (prefixText.Equals("xyz"))
        {
            return new string[0];
        }

        Random random = new Random();
        List<string> items = new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            char c1 = (char)random.Next(65, 90);
            char c2 = (char)random.Next(97, 122);
            char c3 = (char)random.Next(97, 122);

            items.Add(prefixText + c1 + c2 + c3);
        }

        return items.ToArray();
    }
    
}

