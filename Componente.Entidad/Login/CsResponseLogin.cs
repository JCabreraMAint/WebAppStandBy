using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Entidad.Login
{
    public class CsLogin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Estado { get; set; }
        public string Usuario_Ingreso { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Usuario_Actualiza { get; set; }
        public string Fecha_Actualiza { get; set; }
    }

    public class CsResponseLogin
    {
        public List<CsLogin> InfoLogin;
    }

}
