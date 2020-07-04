using System;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Collections;

/// <summary>
/// Summary description for db4o
/// </summary>
public static class db4o
{
    private static IObjectContainer db;

	private static void conectar()
    {
        db = Db4oFactory.OpenFile(System.Web.HttpContext.Current.Server.MapPath("..\\bdoo\\financas.yap"));
    }

    public static void cadastrar(object classe)
    {
        db4o.conectar();
        db.Store(classe);
        db.Commit();

        db.Close();
    }

    public static IList listar(object classe)
    {
        IObjectSet result;
        ArrayList lista = new ArrayList();
        db4o.conectar();
        result = db.Query(classe.GetType());
        while(result.HasNext()){
            lista.Add(result.Next());
        }
        db.Close();

        return lista;
    }
    public static object Selecionar(object classe)
    {
        IObjectSet result;
        db4o.conectar();
        object selecionado = null;

        result = db.QueryByExample(classe);
        if (result.Count > 0)
            selecionado = result.Next();
        db.Close();

        return (selecionado);
    }

 }