using Componente.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Componente.AccesoDatos
{
    public class CsContext : DataComponenteDataContext
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.Login_Consulta")]        
        [ResultType(typeof(CsInfoLogin))]
        public IMultipleResults spLogin_Consulta()
        {
            try
            {
                log.Info("Grabar archivo de log CSContext");
                IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
                return (IMultipleResults)(result.ReturnValue);
            }
            catch (Exception ex)
            {
                log.Error("Error local [Servicio : CsContext] --> " + ex.Message.ToString());
                return null;
            }

        }
    }
}
