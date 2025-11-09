namespace Modelo
{
    public class Juego
    {
        private int juegoId;
        public int JuegoId => this.juegoId; //Solo lectura
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstadoJuego Estado { get; private set; }
        public int EdadMinimaPermitida { get; set; }

        //Implementación actual de la persistencia, solo para implementar el método obtenerTodos usado en la clase Boleto
        private static List<Juego> repositorioTemporal = [];


        //El campo id no debe leído desde la vista. En el futuro se recuperará desde la base de datos.
        //Este constructor en el futuro se hará privado
        public Juego(int juegoId, string nombre, string descripcion, int edadMinimaPermitida)
        {
            this.juegoId = juegoId;
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = EstadoJuego.disponible;
            EdadMinimaPermitida = edadMinimaPermitida;
        }

        public bool ClienteEsAdmitido(int edadCliente)
        {
            return edadCliente >= EdadMinimaPermitida;
        }

        public void CerrarPorMantenimiento()
        {
            Estado = EstadoJuego.noDisponible;
        }
        
        public void AbrirJuego()
        {
            Estado = EstadoJuego.disponible;
        }

        public bool EstaDisponible()
        {
            return Estado == EstadoJuego.disponible;
        }

        //Métodos de persistencia temporales
        public static List<Juego> ObtenerTodos() {
            return repositorioTemporal;
        }

        public void GuardarJuego() {
            repositorioTemporal.Add(this);
        }

        private string EstadoEnTexto()
        {
            return Estado == EstadoJuego.disponible ? "Disponible" : "No disponible";
        }

        public override string ToString()
        {
            return $"Id del juego: {JuegoId} " +
                $"\nNombre del juego: {Nombre} " +
                $"\nDescripcion: {Descripcion} " +
                $"\nEstado: {EstadoEnTexto()}" +
                $"\nEdad Minima para subir: {EdadMinimaPermitida}";
        }


    }

    public enum EstadoJuego
    {
        disponible,
        noDisponible
    }
}
