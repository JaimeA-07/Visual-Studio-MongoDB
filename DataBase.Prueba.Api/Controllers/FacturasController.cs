using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataBase.Prueba.Business;
using DataBase.Prueba.Entities;

namespace DataBase.Prueba.Api.Controllers
{
    // 1 [EnableCors()]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Headers")]
    // Permite solicitudes de origen cruzado del WebClient

    // 3.1 Visualización Método Post
    public class FacturasController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostFactura([FromBody] Facturas factura)
        {
            try
            {
                FacturasBll.SetFactura(factura);
                // Agrega un nuevo documento del objeto creado factura
                return Ok(true);
                // Envía un mensaje de HTTP response message
            }
            catch (Exception exeption)
            {
                return InternalServerError();
            }
        }

        // 3.2 ) Visualización Método Get
        [HttpGet]
        public IHttpActionResult GetFacturas()
        {
            try
            {
                var res = FacturasBll.GetFacturas();
                return Ok(res);
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }

        // 3.3 ) Visualización Método GetId
        [HttpGet]
        public IHttpActionResult GetFacturasById(string id)
        {
            try
            {
                var res = FacturasBll.GetFacturasById(id);
                return Ok(res);

            }
            catch(Exception exception)
            {
                return InternalServerError();
            }
        }

        // 3.4) Visualización Método Delete
        [HttpDelete]
        public IHttpActionResult DeleteFacturas(string id)
        {
            try
            {
                var res = FacturasBll.DeleteFactura(id);
                return Ok(res);

            }
            catch(Exception exception)
            {
                return InternalServerError();
            }
        }

        // 3.5 ) Visualización Método Put
        [HttpPut]
        public IHttpActionResult PutFacturas(string id, [FromBody] Facturas objFacturas)
        {
            try
            {
                var res = FacturasBll.PutFacturas(id, objFacturas);
                return Ok(res);

            }
            catch(Exception exception)
            {
                return InternalServerError();
            }
        }

    }



}

/* 1. Agregamos [EnableCors()] he importamos su libreria "using System.Web.Http.Cors;"
 * 2. Agregamos librerías "using DataBase.Prueba.Business;" y "using DataBase.Prueba.Entities;"
 *    construimos el método para visualización al html
 * 3. Agregamos las vistas para los métodos
 *    3.1 ) Visualización Método Post (Agregar)
 *    3.2 ) Visualización Método Get  (Vista todos los elementos registrados)
 *    3.3 ) Visualización Método GetId (Vista con búsqueda de Id)
 *    3.4 ) Visualización Método Delete (Eliminar)
 *    3.5 ) Visualización Método Put (Actualizar o modificar) 
 */
