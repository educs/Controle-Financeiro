using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Collections;
using Db4objects.Db4o.TA;
using Db4objects.Db4o.Config;
using financa.model;

namespace financa.db
{

    /// <summary>
    /// Summary description for db4o
    /// </summary>
    public static class db4o
    {
        private static IObjectServer servidor;
        private static IObjectContainer db;

        public static IObjectContainer conectar()
        {
            if (servidor != null)
                servidor.Close();
            IConfiguration config = Db4oFactory.NewConfiguration();
            new TransparentActivationSupport().Prepare(config);
            config.LockDatabaseFile(false);
            config.DetectSchemaChanges(true);
            servidor = Db4oFactory.OpenServer(config, System.Web.HttpContext.Current.Server.MapPath("..\\bdoo\\financas.db4o"), 0);
            //servidor.Ext().Configure().ActivationDepth(2);
            db = servidor.OpenClient();
            db.Ext().Configure().ObjectClass(typeof(Usuario)).CascadeOnUpdate(true);
            db.Ext().Configure().ObjectClass(typeof(Conta)).CascadeOnUpdate(true);
            db.Ext().Configure().ObjectClass(typeof(Categoria)).CascadeOnUpdate(true);
            //db.Ext().Configure().ObjectClass(typeof(Lancamento)).ObjectField("Imagem").CascadeOnActivate(false);
            //db.Ext().Configure().ObjectClass(typeof(Lancamento)).ObjectField("Comprovante").CascadeOnActivate(false);

            return db;
        }

        public static long pegarId(object objeto)
        {
            long id = db.Ext().GetID(objeto);

            return id;
        }

        public static void desconectar()
        {
            if (db != null)
                db.Close();
        }

        public static void rollBack()
        {
            if (db != null)
                db.Rollback();
        }

        public static void cadastrar(object classe)
        {
            //db4o.conectar();
            db.Store(classe);
            db.Commit();

            //db.Close();
        }

        public static IObjectSet listar(object classe)
        {
            IObjectSet result;

            //db4o.conectar();
            result = db.Query(classe.GetType());

            return result;
        }

        public static IObjectSet listar(Predicate p)
        {
            return db.Query(p);
        }

        public static object Selecionar(object classe)
        {
            IObjectSet result;
            //db4o.conectar();
            object selecionado = null;

            result = db.QueryByExample(classe);
            if (result.Count > 0)
                selecionado = result.Next();
            //db.Close();

            return (selecionado);
        }

        public static object Selecionar(object classe, long id)
        {
            IObjectSet result;
            IQuery query = db.Query();
            //db4o.conectar();
            object selecionado = null;

            query.Constrain(classe.GetType());
            query.Descend("_id").Constrain(id);
            result = query.Execute();
            if (result.Count > 0)
                selecionado = result.Next();
            //db.Close();

            return (selecionado);
        }

        public static object Selecionar(object classe, string descricao)
        {
            IObjectSet result;
            IQuery query = db.Query();
            //db4o.conectar();
            object selecionado = null;

            query.Constrain(classe.GetType());
            query.Descend("_descricao").Constrain(descricao);
            result = query.Execute();
            if (result.Count > 0)
                selecionado = result.Next();
            //db.Close();

            return (selecionado);
        }
        /*
        public static object Selecionar(object classe, string descricao, Conta conta)
        {
            IObjectSet result;
            IQuery query = db.Query();
            //db4o.conectar();
            object selecionado = null;

            query.Constrain(classe.GetType());
            query.Descend("_descricao").Constrain(descricao);
            query.Descend("_conta").Constrain(conta);
            result = query.Execute();
            if (result.Count > 0)
                selecionado = result.Next();
            //db.Close();

            return (selecionado);
        }*/

        internal static int getMax(object objeto)
        {
            IQuery q = db.Query();
            q.Constrain(objeto.GetType());
            IObjectSet result = q.Execute();

            return result.Count;
        }
    }
}