/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 2/11/2024
 * Hora: 16:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace elclub.Clases
{
    public class Deporte
    {
        private string nombreDepo, nombreEntrenador, apellidoEntrenador;
        private int anioCategoria, cupoCat, dniEntrenador, cantInscriptos, costoCuota, descuentoSocio;
        private ArrayList diasYHorarios;
        
        public Deporte(string nombreDepo, int anioCategoria, int cupoCat, string nombreEntrenador, string apellidoEntrenador, int dniEntrenador, int costoCuota, int descuentoSocio)
        {
            this.nombreDepo = nombreDepo;
            this.anioCategoria = anioCategoria;
            this.cupoCat = cupoCat;
            this.nombreEntrenador = nombreEntrenador;
            this.apellidoEntrenador = apellidoEntrenador;
            this.dniEntrenador = dniEntrenador; 
            this.costoCuota = costoCuota;            
            this.descuentoSocio = descuentoSocio;
            diasYHorarios = new ArrayList();
        }
        
        public void AgregarHorario(string horario)
        {
        	diasYHorarios.Add(horario);
        }
        
        public ArrayList DiasYHorarios
        {
        	get { return diasYHorarios;}
        }
        
        public string NombreDepo
        {
            get { return nombreDepo; }
        }

        public int AnioCategoria
        {
            get { return anioCategoria; }
        }

        public int CupoCat
        {
        	set { cupoCat = value;}
            get { return cupoCat; }
        }

        public int DniEntrenador
        { 
            get { return dniEntrenador; }
        }

        public string NombreEntrenador
        {
            get { return nombreEntrenador; }
        }

        public string ApellidoEntrenador
        {
            get { return apellidoEntrenador; }
        }

        public int CantInscriptos
        {
            get { return cantInscriptos; }
            set { cantInscriptos = value; }
        }

        public int CostoCuota
        {
            get { return costoCuota; }
        }

        public int DescuentoSocio
        {
            get { return descuentoSocio; }
        }
    }
}
