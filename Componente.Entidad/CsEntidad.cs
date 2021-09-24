using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Entidad
{
    public class CsEntidad
    {

    }

    public class CsResponseEnvioMail
    {
        public string TokenObtenidoSmax { get; set; }
    }

    public class CsAutentication
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class CsInfoLogin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Estado { get; set; }
        public string Usuario_Ingreso { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Usuario_Actualiza { get; set; }
        public string Fecha_Actualiza { get; set; }
    }
}
