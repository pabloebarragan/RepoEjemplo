using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidException : Exception
    {
        private string mensajeBase;

        public DniInvalidException() : this("DNI invalid Exception", null)
        {

        }

        public DniInvalidException(Exception e) : this("DNI invalid Exception", e)
        {

        }

        public DniInvalidException(string message) : this(message, null)
        {
            this.mensajeBase = message;
        }

        public DniInvalidException(string message, Exception e) : base(message, e)
        {

        }
    }

}
