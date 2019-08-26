using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using DataBase.Prueba.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase.Prueba.Business
{
    public class FacturasBll
    {
        // 2. Conexión Servidor-Cliente
        private static IMongoClient client = 
            new MongoClient(ConfigurationManager.AppSettings["ConnectionString"]);
        // nombre conexión asignado desde la Web.Config (key)

        private static IMongoDatabase basedatos = 
            client.GetDatabase(ConfigurationManager.AppSettings["Database"]);
        // nombre base de datos asignado desde la Web.Config (key)

        // 3. Método

        // 3.1) Método Post
        public static string SetFactura(Facturas factura)
        {
            try
            {
                var collection = basedatos.GetCollection<BsonDocument>("Facturas");
                // nombre de la colección creado del robomongo ("Facturas")
                BsonDocument document = factura.ToBsonDocument();
                // conversion de todos los documentos contenidos de Facturas en Json
                collection.InsertOne(document);

                return "Factura Creada";

            }
            catch (Exception exception)
            {
                throw exception;
            }          
        }

        //  3.2 ) Método Get
        public static List<Facturas> GetFacturas()
        {
            try
            {
                List<Facturas> listafacturas = basedatos.GetCollection<Facturas>
                    ("Facturas").Find(_ => true).ToList();
                // Obtiene todas la lista de la colección que el usuario ha registrado
                // todo es almacenado en el objeto listafacturas

                return listafacturas;

            }catch (Exception exception)
            {
                throw exception;
            }
        }

        // 3.3 ) Método GetId
        public static List<Facturas> GetFacturasById(string id)
        {
            try
            {
                List<Facturas> listafacturas = basedatos.GetCollection<Facturas>
                    ("Facturas").Find(x => x.CodigoFactura == id).ToList();
                // Obtiene la búsqueda individual de cada lista, con solo colocar
                // el código de factura, para que funcione.

                return listafacturas;

            }catch(Exception exception)
            {
                throw exception;
            }
        }

        // 3.4 ) Método Delete
        public static string DeleteFactura(string id)
        {
            try
            {
                var res = basedatos.GetCollection<Facturas>
                    ("Facturas").FindOneAndDelete(x => x.CodigoFactura == id);
                // Borra todo el documento de la colección colocando el código de factura

                return "Factura Eliminada";

            }catch(Exception exception)
            {
                throw exception;
            }
        }

        // 3.5 ) Método Put
        public static string PutFacturas(string id, Facturas objfacturas)
        {
            try
            {
                objfacturas._id = ObjectId.Parse(id);
                var collection = basedatos.GetCollection<BsonDocument>("Facturas");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                collection.ReplaceOne(filter, objfacturas.ToBsonDocument());
                // En este método para realizar la modificación se realiza a través del id
                // generado por mongo

                return "Factura Actualizada";

            }
            catch(Exception exception)
            {
                throw exception;
            }

        }

    }


}

/* 1. Se agrega un public a la class Facturas
 * 2. Realizamos la conexión mongo server- cliente, importamos la librería "using MongoDB.Driver;"
 *    para configuration, importamos la libería "using System.Configuration;"
 * 3. Creación de los métodos para poder tener acceso a la colección y los documentos del mongodb
 *    importamos librería.
 *    3.1 ) Método Post (Agregar)
 *    3.2 ) Método Get  (Vista todos los elementos registrados)
 *    3.3 ) Método GetId (Vista con búsqueda de Id)
 *    3.4 ) Método Delete (Eliminar)
 *    3.5 ) Método Put (Actualizar o modificar) 
 */
