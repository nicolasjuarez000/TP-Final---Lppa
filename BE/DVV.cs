namespace BE
{
    public class DVV
    {
        public DVV(string Tabla, byte[] DV)
        {
            this.Tabla = Tabla;
            this.DV = DV;
        }

        public string Tabla { get; set; }
        public byte[] DV { get; set; }
    }
}
