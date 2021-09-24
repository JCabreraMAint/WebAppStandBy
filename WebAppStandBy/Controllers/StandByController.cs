using Componente.Entidad;
using Componente.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppStandBy.Models;

namespace WebAppStandBy.Controllers
{
    [RoutePrefix("Gestion")]    
    public class StandByController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet]
        [Route("ConsultaLogin")]
        public RespuestaModelo ConsultaLogin()
        {
            string MensajeError = string.Empty;
            string NumeroError = string.Empty;
            RespuestaModelo respuestaModelo = new RespuestaModelo();
            string cadenaConexion = string.Empty;
            try
            {
                log.Info("Inicio de metodo ConsultaLogin");
                log4net.ThreadContext.Properties["Usuario"] = Environment.UserName;
                using (CsLogica ObjLogica = new CsLogica(cadenaConexion))
                {
                    CsMensajeRetorno MensajeRetorno = new CsMensajeRetorno();
                    respuestaModelo.Respuesta.Add(ObjLogica.RetornaInfoLogin(ref MensajeRetorno));
                    if (MensajeRetorno.CodigoRetorno == 99)
                    {
                        respuestaModelo.MensajeError = MensajeRetorno.DescRetorno;
                        respuestaModelo.ProcesoExitoso = false;
                        return respuestaModelo;
                    }
                    if (respuestaModelo.Respuesta == null || respuestaModelo.Respuesta.Count() == 0)//|| ((System.Collections.Generic.List<Proveedores.Entidades.InfoProveedor>)respuestaModelo.Respuesta[0]).Count() == 0)
                    {
                        respuestaModelo.MensajeError = "¡Información no existe!";
                        respuestaModelo.NumeroError = "400";
                        respuestaModelo.ProcesoExitoso = false;
                        return respuestaModelo;
                    }
                    else
                    {
                        respuestaModelo.MensajeError = "Transaccion OK";
                        respuestaModelo.NumeroError = "200";
                        respuestaModelo.ProcesoExitoso = true;
                        return respuestaModelo;
                    }                    
                }
            }
            catch (Exception ex)
            {
                log.Info("[ConsultaLogin]Exception -->" + ex.Message.ToString());
                respuestaModelo.MensajeError = ex.Message.ToString();
                respuestaModelo.NumeroError = "99";
                return respuestaModelo;
            }
        }
    }
}
