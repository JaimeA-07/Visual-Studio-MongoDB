using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataBase.Prueba.Entities
{
    public class Facturas
    {
        // 2. Id
        [BsonId]
        public ObjectId _id { get; set; }
        // 3.Documentos
        public string CodigoFactura { get; set; }
        public string Cliente { get; set; }
        public string Ciudad { get; set; }
        public string Nit { get; set; }
        public double TotalFactura { get; set; }
        public double SubTotal { get; set; }
        public double Iva { get; set; }
        public double Retencion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public bool Pagada { get; set; }
        public DateTime FechaPago { get; set; }
    }
}

/* 1. Se agrega un public a la class Facturas
 * 2. Creamos el ObjectId, por tanto importamos la librería "using MongoDB.Bson;"
 *    agregamos la funcionalidad [BsonId]; importamos librería y generamos el {get; set;}
 * 3. Agregamos los documentos que queremos que nuestra colección contenga
 */

