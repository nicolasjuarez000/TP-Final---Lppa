using System;

namespace BE
{
    public class Log
    {

        public Log()
        {
        }

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Severity { get; set; }
        public string AssociatedInfo { get; set; }  

    }
}
