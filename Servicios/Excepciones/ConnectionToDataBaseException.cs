using System;

namespace Servicios.Excepciones
{
    public class ConnectionToDataBaseException : Exception
    {
        public ConnectionToDataBaseException() : base("Error conecting to DB")
        {
        }
    }
}
