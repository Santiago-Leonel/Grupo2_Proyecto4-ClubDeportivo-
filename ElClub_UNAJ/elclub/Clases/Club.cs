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
    public class Club
    {
        public string nombreClub;
        public ArrayList listaNinios;
        public ArrayList listaDeportes;
        public ArrayList listaEntrenadores;

        public string NombreClub
        {
            get { return nombreClub; }
            set { nombreClub = value; }
        }

        public Club(string nombreClub) 
        { 
            this.nombreClub = nombreClub;
            listaNinios = new ArrayList(); 
            listaEntrenadores = new ArrayList(); 
            listaDeportes = new ArrayList(); 
        }

        public void AgregarDeporte(Deporte deporte)
        {
            listaDeportes.Add(deporte);
        }

        public void EliminarDeporte(Deporte deporte)
        {
            listaDeportes.Remove(deporte);
        }

        public ArrayList Deportes
        {
            get { return listaDeportes; }
        }

        public void AgregarEntrenador(Entrenador entrenador)
        {
            listaEntrenadores.Add(entrenador);
        }

        public void EliminarEntrenador(Entrenador entrenador)
        {
            listaEntrenadores.Remove(entrenador);
        }

        public ArrayList Entrenadores
        {
            get { return listaEntrenadores; }
        }

        public void AgregarNinio(Ninio ninio)
        {
            listaNinios.Add(ninio);
        }

        public void EliminarNinio(Ninio ninio)
        {
            listaNinios.Remove(ninio);
        }

        public ArrayList Ninios
        {
            get { return listaNinios; }
        }

    }
}
