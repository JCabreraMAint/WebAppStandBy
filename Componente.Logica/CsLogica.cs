using System;
using System.Collections.Generic;
using System.Text;
using Componente.AccesoDatos;
using Componente.Entidad;
using Componente.Entidad.Login;

namespace Componente.Logica
{
    public class CsLogica : IDisposable
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

        #region CADENA CONEXION
        public string cadenaConexion;
        public string TokenObtenido;
        public CsLogica(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-EC");
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            ci.NumberFormat.CurrencyGroupSeparator = ",";
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.NumberGroupSeparator = ",";
            ci.NumberFormat.PercentDecimalSeparator = ".";
            ci.NumberFormat.PercentGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }
        public CsLogica()
        {

        }
        #endregion

        #endregion
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<CsLogin> RetornaInfoLogin(ref CsMensajeRetorno MensajeRetorno)
        {
            List<CsLogin> DatosLogin = new List<CsLogin>();
            CsConexionBD instance = new CsConexionBD();
            try
            {
                log.Info("Grabar archivo de log");
                //Datos = instance.P_CONSULTA_INFO_LOGIN(ref MensajeRetorno);
                DatosLogin = instance.P_CONSULTA_INFO_LOGIN(ref MensajeRetorno);
                //if (Datos.InfoLogin.Count > 0)
                if (DatosLogin.Count > 0)
                {
                    MensajeRetorno.CodigoRetorno = MensajeRetorno.CodigoRetorno;
                    MensajeRetorno.DescRetorno = MensajeRetorno.DescRetorno;
                }
                else
                {
                    MensajeRetorno.CodigoRetorno = MensajeRetorno.CodigoRetorno;
                    MensajeRetorno.DescRetorno = "NO HAY DATOS";
                }
                return DatosLogin;
            }
            catch (Exception ex)
            {
                MensajeRetorno.CodigoRetorno = 99;
                MensajeRetorno.DescRetorno = ex.Message.ToString();
                log.Error("Error local [Servicio : RetornaInfoLogin] --> " + ex.Message.ToString());
                return null;
            }
        }
    }
}
