using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioWS
    {
        public Guid id { get; private set; }
        public string direccion { get; private set; }
        public string telefono { get; private set; }
        public string email { get; private set; }
        public DateTime fechaAlta { get; private set; }
        public DateTime? fechaBaja { get; private set; }
        public string nombreUsuario { get; private set; }
        public int host { get; private set; }
        public string contraseña { get; private set; }
    }
}
