using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Implementacion;

namespace Trabajo_Final_p1.Clases
{
    public class SistemaGestionViajes
    {
        //Aca vamos a tener ciertas logicas de negocio

        private GestorUsuario<Cliente> gestorC;
        private GestionViajesDao gestorV;
        private GestionEmpresaDao gestorE;
        private GestionReservaDao gestorR;

        public SistemaGestionViajes()
        {
            gestorC = new GestorUsuario<Cliente>();
            gestorE = new GestionEmpresaDao();
            gestorV = new GestionViajesDao();
            gestorR = new GestionReservaDao(gestorV, gestorC);
            
        }

        public void RealizarPagoYReserva(int dni,int idViaje, int cuposDeseados) 
        {
            
            Cliente cliente = (Cliente)gestorC.Obtener(dni);            
            Viaje viaje = gestorV.Obtener(idViaje);

            if (cliente == null || viaje == null)
            {
                Console.WriteLine("Error: Cliente o Viaje no encontrado.");
                return;
            }

            if(CalcularCuposDisponibles(idViaje) >= cuposDeseados) 
            {
                //Genera una nueva ID para cada Reserva, si no hay le asigna el id=1
                int nuevaReservaId = gestorR.reservas.Count > 0 ? gestorR.reservas.Max(r => r.IdReserva) + 1 : 1;
                Reserva nuevaReserva = new Reserva(nuevaReservaId, cuposDeseados, cliente, viaje);

                gestorR.Agregar(nuevaReserva);
            }
            else
            {
                MessageBox.Show("No hay suficientes cupos disponibles");
            }
        }
        public int CalcularCuposDisponibles(int idViaje) 
        {
            Viaje viaje = gestorV.Obtener(idViaje);
            int capacidad = viaje.Transporte.Cupos;
            List<Reserva> lista = gestorR.ObtenerReservasPorViaje(idViaje);
            int cuposUsados = lista.Sum(r => r.Cupos);
            return capacidad - cuposUsados;
        }
       

    }
}
