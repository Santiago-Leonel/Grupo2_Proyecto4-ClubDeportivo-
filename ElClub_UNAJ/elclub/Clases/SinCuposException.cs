/*
 * Creado por SharpDevelop.
 * Usuario: Usuario
 * Fecha: 17/11/2024
 * Hora: 00:42
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace elclub.Clases
{
	public class SinCuposException : Exception
	{
    	public string fallo;

    	public SinCuposException(string f)
    	{
        	fallo = f;
    	}
	}
}
