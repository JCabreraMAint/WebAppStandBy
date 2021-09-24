using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Componente.Entidad;
using Componente.Entidad.Login;

namespace Componente.AccesoDatos
{
    public class CsConexionBD : IDisposable
    {

        #region "Finalización"
        private bool disposed = false;// Para detectar llamadas redundantes

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //TODO: eliminar estado administrado (objetos administrados).
                }
            }
        }
        #endregion
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<CsLogin> P_CONSULTA_INFO_LOGIN(ref CsMensajeRetorno Poo_Mensaje)
        {
            //RetornoDatos Datos = new RetornoDatos();
            List<CsLogin> Datos = new List<CsLogin>();
            try
            {
                int? cod = 100;
                string mens = "OK";
                CsContext DataContext = new CsContext();
                DataContext.CommandTimeout = 0;
                IMultipleResults results = DataContext.spLogin_Consulta();
                //Datos.InfoLogin  = results.GetResult<CsInfoLogin>().ToList();
                Datos = results.GetResult<CsLogin>().ToList();

                Poo_Mensaje.CodigoRetorno = (int)cod;
                Poo_Mensaje.DescRetorno = mens;

                return Datos;
            }
            catch (Exception ex)
            {
                Poo_Mensaje.CodigoRetorno = 99;
                Poo_Mensaje.DescRetorno = ex.Message;
                return null;
            }
            finally { }
        }
    }
}
