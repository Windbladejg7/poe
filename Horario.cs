using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Horario
    {
        private int _horarioId;

        public int HorarioId { get;  }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public TimeSpan CantidadHoras { get; set; }

        public Horario(TimeSpan horaApertura, TimeSpan horaCierre)
        {
            HoraApertura = horaApertura;
            HoraCierre = horaCierre;
        }

        public string HoraDeAperturaComoTexto()
        {
            return HoraApertura.ToString();
        }

        public string HoraDeCierreComoTexto()
        {
            return HoraCierre.ToString();
        }

        public bool FechaIncluida(DateTime fechaActual)
        {
            return fechaActual>=FechaInicio && fechaActual<=FechaFin;
        }
    }
}
