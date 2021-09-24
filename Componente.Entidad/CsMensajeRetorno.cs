using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Entidad
{
    public class CsMensajeRetorno
    {
        #region "Variables Para Datos"
        private int _CodigoRetorno = 0;
        private string _DescRetorno = "";
        #endregion
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
        public string DescRetorno
        {
            get { return _DescRetorno; }
            set { _DescRetorno = value; }
        }
        public int CodigoRetorno
        {
            get { return _CodigoRetorno; }
            set { _CodigoRetorno = value; }
        }

    }
}
