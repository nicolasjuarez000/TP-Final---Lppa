using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SesionAdmin
    {
        private SesionAdmin()
        {
        }

        private static readonly object _lock = new object();
        private static SesionAdmin instance;
        private static bool logEvents = true;

        public static bool LogEvents
        {
            get { return logEvents; }
            set { logEvents = value; }
        }

        //Genero una instancia de empleado
        public BE.User User { get; private set; }

        //Obtengo la instancia de la sesion
        public static SesionAdmin GetInstance
        {
            get
            {
                return instance;
            }
        }

        //Metodo que se encarga de realizar el inicio de sesion, recibiendo por parametro un empleado
        public static void IniciarSesion(BE.User user)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new SesionAdmin
                    {
                        User = user
                    };
                }
            }
        }

        //Metodo que cierra sesion, no recibe nada por parametro ya que lo unico que hace es setear
        //la instancia de sesion en null para cerrarla
        public static void CerrarSesion()
        {
            lock (_lock)
            {
                if (instance != null)
                {
                    instance = null;
                }
            }
        }
    }
}
