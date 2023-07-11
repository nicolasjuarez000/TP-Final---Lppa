using System;

namespace DAL.Excepciones
{
    public class DatabaseUnknownErrorException : Exception
    {
        public DatabaseUnknownErrorException() : base("database_unknown_error_occurred")
        {
        }
    }
}
