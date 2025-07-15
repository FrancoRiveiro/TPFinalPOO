using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Interfaces;

namespace Trabajo_Final_p1.Implementacion
{
    public class GestionReservaDao : IGestor<Reserva>
    {
        //gestores
        GestionEmpresaDao gestorE = new GestionEmpresaDao();
        GestionTransporteDao gestorT = new GestionTransporteDao();
        GestorUsuario<Cliente> GestorC;
        //listas
        BindingList<Cliente> clientes = new BindingList<Cliente>();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        BindingList<MedioDeTransporte> transportes = new BindingList<MedioDeTransporte>();
        BindingList<Viaje> viajes = new BindingList<Viaje>();

        private BindingList<Reserva> _reservas;
        public BindingList<Reserva> reservas => _reservas;
        public GestionReservaDao(GestionViajesDao gestorV, GestorUsuario<Cliente> gestorC)
        {
            GestorC = gestorC;
            clientes = GestorC.CargarLista();
            transportes = gestorT.CargarLista();
            empresas = gestorE.CargarLista();
            viajes = gestorV.CargarLista(empresas, transportes);
            _reservas = new BindingList<Reserva>();
            CargarLista();
        }
        public void Agregar(Reserva res)
        {

            if (res == null)

            {

                throw new ArgumentNullException(nameof(res), "Cree la reserva primero.");
            }
            else
            {
                using (FileStream fs = new FileStream("Reservas.csv", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{res.IdReserva};{res.Cupos};{res.Cliente.DNI};{res.ViajeReservado.IDViaje};{res.CostoTotal}");
                }
                this.CargarLista();
            }
        }

        public void Eliminar(int id)
        {
            //No se van a eliminar reservas
            throw new NotImplementedException();
        }

        public void Modificar(Reserva entidad, params object[] valoresExtra)
        {
            //No se van a modificar reservas
            throw new NotImplementedException();
        }
        public BindingList<Reserva> CargarLista() 
        {
            _reservas.Clear();
            foreach (var linea in File.ReadAllLines("Reservas.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 5)
                {
                    Reserva res = new Reserva(Convert.ToInt32(partes[0]),
                        Convert.ToInt32(partes[1]),
                        clientes.FirstOrDefault(c => c.DNI == Convert.ToInt32(partes[2])) ,
                        viajes.FirstOrDefault(v => v.IDViaje == Convert.ToInt32(partes[3])));
                    _reservas.Add(res);
                }
            }
            return _reservas;
        }


        public List<Reserva> ObtenerReservasPorViaje(int idViaje) 
        {
            CargarLista();
            return _reservas.Where(r => r.ViajeReservado.IDViaje == idViaje).ToList();
            
        }
    }
}
