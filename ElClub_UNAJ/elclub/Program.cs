/*
 * Created by SharpDevelop.
 * User: Brian
 * Date: 27/10/2024
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using elclub.Clases;
using System.Collections;

namespace elclub
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Club club = new Club("Power Club");

			CargarObjetos(club);
			
			MostrarMenu(club);
			
			Console.ReadKey(true);
		}

		public static void MostrarMenu(Club club)
		{
			bool termina = false;
			string opcion;

			while (!termina)
			{
				ImprimirMenu(club);

				Console.Write("Seleccione una opción para continuar: ");
				opcion = Console.ReadLine().ToUpper();

				switch (opcion)
				{
					case "A":
						AltaEntrenador(club);
						break;
					case "B":
						BajaEntrenador(club);
						break;
					case "C":
						AltaNinioSocio(club);
						break;
					case "D":
						BajaNinioSocio(club);
						break;
					case "E":
						PagarCuota(club);
						break;
					case "F":
						ListadosInscriptos(club);
						break;
					case "G":
						ListadoDeudores(club);
						break;
					case "H":
						AgregarDeporte(club);
						break;
					case "I":
						EliminarDeporte(club);
						break;
					case "0":
						termina = true;
						Console.WriteLine("Saliendo del programa...");
						Console.ReadKey();
						break;
					default:
						Console.WriteLine("Por favor, seleccione la opcion correspondiente.");
						Console.ReadKey();
						break;
				}
			}
			Console.ReadKey(true);
		}

		public static void ImprimirMenu(Club club)
		{
			Console.Clear();
			Console.WriteLine("Bienvenido al menú de ¡" + club.NombreClub + "!");
			Console.WriteLine(" ");
			Console.WriteLine("A. Dar de alta a un entrenador.");
			Console.WriteLine("B. Dar de baja a un entrenador.");
			Console.WriteLine("C. Dar de alta a un niño/socio en un deporte.");
			Console.WriteLine("D. Dar de baja a un niño/socio en un deporte.");
			Console.WriteLine("E. Simular el pago de una cuota.");
			Console.WriteLine("F. Listado de inscriptos.");
			Console.WriteLine("G. Listado de deudores.");
			Console.WriteLine("H. Agregar un deporte.");
			Console.WriteLine("I. Eliminar un deporte.");
			Console.WriteLine("0. Salir del programa.");
			Console.WriteLine(" ");
		}
		
		public static void AltaEntrenador(Club club)
		{
			string nombre, apellido;
			int edad = 0, dni = 0;
			Console.Clear();
			Console.WriteLine("/************ ALTA DE ENTRENADORES ************/");
			Console.WriteLine(" ");

			bool continua = false;

			while (!continua)
			{
				Console.Write("Ingrese el nombre del entrenador: ");
				nombre = Console.ReadLine().ToUpper();

				Console.Write("Ingrese el apellido del entrenador: ");
				apellido = Console.ReadLine().ToUpper();

				bool repite = true;

				while (repite)
				{
					try
					{
						Console.Write("Ingrese la edad del entrenador: ");
						edad = int.Parse(Console.ReadLine());

						Console.Write("Ingrese el DNI del entrenador: ");
						dni = int.Parse(Console.ReadLine());

						repite = false;
					}
					catch (FormatException)
					{
						Console.WriteLine("ERROR: Por favor, ingrese los datos con su correspondiente formato.");
						repite = true;
					}
				}

				bool entrenadorExiste = false;

				foreach (Entrenador elem in club.listaEntrenadores)
				{
					
					if (elem.Dni == dni && elem.Apellido == apellido)// puse para comparar dos datos al momento de estar agreagando al entrenador
					{
						Console.WriteLine("El entrenador ingresado ya existe, intente nuevamente con otro entrenador.");
						entrenadorExiste = true;
						break;
					}
				}

				if (!entrenadorExiste)
				{
					Entrenador entrenador = new Entrenador(nombre, apellido, edad, dni);
					club.AgregarEntrenador(entrenador);
					Console.WriteLine("Entrenador agregado exitosamente.");
				}

				Console.Write("¿Desea continuar agregando? (S/N): ");
				string seguir = Console.ReadLine().ToUpper();

				if (seguir == "S")
				{
					continua = false;
					Console.WriteLine(" ");
				}
				else
				{
					continua = true;
					Console.WriteLine(" ");
					Console.WriteLine("Volviendo al menú...");
					Console.ReadKey();
				}
			}
		}

						
						
						
						
		public static void BajaEntrenador(Club club)
		{
			int dni = 0;

			Console.Clear();

			Console.WriteLine("/************ BAJA DE ENTRENADORES ************/");
			Console.WriteLine(" ");

			bool repite = true;

			while (repite)
			{
				Console.WriteLine("Lista actual de entrenadores:");
				Console.WriteLine(" ");

				foreach (Entrenador e in club.Entrenadores)
				{
					Console.WriteLine(" Apellido: {0} /// Nombre: {1} /// DNI: {2}", e.Apellido, e.Nombre, e.Dni);
				}

				Console.WriteLine(" ");
				Console.WriteLine("A continuación ingrese los datos del entrenador que desea dar de baja.");

				try
				{
					Console.Write("Dni: ");
					dni = int.Parse(Console.ReadLine());
				}
				catch(FormatException)
				{
					Console.WriteLine("El DNI ingresado no existe dentro del club, por favor intente nuevamente.");
				}

				bool encontrado = false;

				foreach (Entrenador entrenador in club.Entrenadores)
				{
					if (dni == entrenador.Dni)
					{
						club.EliminarEntrenador(entrenador);
						Console.WriteLine("El/la entrenador/a {0} {1} de DNI[{2}] fue dado de baja satisfactoriamente!", entrenador.Apellido, entrenador.Nombre, entrenador.Dni);
						encontrado = true;
						break;
					}
				}

				if (!encontrado)
				{
					Console.WriteLine("El DNI ingresado no corresponde a ningun entrenador dentro del club.");
				}

				Console.Write("Desea dar de baja otro entrenador? (S/N): ");
				string op = Console.ReadLine().ToUpper();

				if (op == "S")
				{
					repite = true;
					Console.WriteLine(" ");
				}
				else
				{
					repite = false;
					Console.WriteLine("Volviendo al menú...");
					Console.ReadKey();
				}
			}
		}

							
							
							
							
		public static void AltaNinioSocio(Club c)
		{
			string nombre, apellido, deporte;
			bool otraVez = true;
			int edad = 0, dni = 0, op2 = 0;
			Deporte depo = null;

			Console.Clear();
			Console.WriteLine("/************ ALTA DE NIÑOS/SOCIOS ************/");
			Console.WriteLine(" ");

			do
			{
				Console.WriteLine("Ingrese los datos de la persona que se dará de alta.");
				Console.Write("Deporte deseado: ");
				deporte = Console.ReadLine().ToUpper();

				bool deporteExiste = false;

				foreach (Deporte d in c.Deportes)
				{
					if (d.NombreDepo == deporte)
					{
						deporteExiste = true;
						break;
					}
				}

				if (!deporteExiste)
				{
					Console.WriteLine("\nDEPORTE NO EXISTENTE\n");
					Console.WriteLine("Intente con otro deporte.");
					continue;
				}

				Console.Write("Ingrese la edad del niño: ");
				try
				{
					edad = int.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("\nIngrese solo números para la edad.\n");
					continue;
				}

				depo = null;
				int cate = 0;
				
				int anioNacimiento = DateTime.Now.Year - edad;

				foreach(Deporte d in c.Deportes)
				{
					if(d.NombreDepo == deporte && d.AnioCategoria == anioNacimiento)
					{
						depo = d;
						cate = d.AnioCategoria;
						break;
					}
				}
				if (depo != null)
				{
					try
					{		
			
						if (depo.CupoCat == depo.CantInscriptos) // saque el decremento de la cantidad de cupos, solo deje el incremento de cantidad de inscriptos

						{
							Console.WriteLine(" ");
							throw new SinCuposException("No existen cupos disponibles para la categoría, intente nuevamente con otro deporte.");	
						}
					}
					catch (SinCuposException sn)
					{
						Console.WriteLine(sn.fallo);
						continue;
					}
					Console.Write("\nComplete con los datos del niño/socio.\n");
					Console.Write("Nombre: ");
					nombre = Console.ReadLine().ToUpper();
					Console.Write("Apellido: ");
					apellido = Console.ReadLine().ToUpper();
					
					bool otra = true;
					
					while(otra)
					{
						Console.Write("Dni(sin puntos): ");
						try
						{
							dni = int.Parse(Console.ReadLine());
							otra = false;
						}
						catch (FormatException)
						{
							Console.WriteLine("\nIngrese solo números para el DNI.\n");
							otra = true;
						}
					}
					bool repite = true;

					while (repite)
					{
						Console.WriteLine("\n¿Desea hacerse socio del club?");
						Console.WriteLine("1. Aceptar.\n2. No.\n");
						Console.Write("Seleccione una opción: ");
						try
						{
							op2 = int.Parse(Console.ReadLine());
						}
						catch (FormatException)
						{
							Console.WriteLine("\nIngrese solo un número (1 o 2).");
							return;
						}

						if (op2 == 1)
						{
							int descuento = depo.DescuentoSocio;
							Socio nSocio = new Socio(nombre, apellido, dni, edad, deporte, cate, descuento);
							c.AgregarNinio(nSocio);
							repite = false;
							break;
						}
						if (op2 == 2)
						{
							Ninio nNinio = new Ninio(nombre, apellido, edad, dni, deporte, cate);
							c.AgregarNinio(nNinio);
							repite = false;
							break;
						}
						else
						{
							Console.WriteLine("Por favor, ingrese la opcion que corresponda.");
							repite = true;
						}
					}
					depo.CantInscriptos++;
					Console.WriteLine("\nEl niño ha sido asignado a la categoría {0} del deporte {1}.\n", depo.AnioCategoria, depo.NombreDepo);
					Console.WriteLine(" ");
					Console.Write("Desea dar de alta a otro niño/socio? (S/N): ");
					string sigue = Console.ReadLine().ToUpper();

					if (sigue == "S")
					{
						otraVez = true;
					}
					else
					{
						otraVez = false;
						Console.WriteLine("Volviendo al menú...");
						Console.ReadKey();
					}
				}
				else
				{
					Console.WriteLine("No se encontró una categoría adecuada para el deporte deseado, por favor intente nuevamente.");
					otraVez = true;
				}
			} while (otraVez);
		}

							
							
							
							
							
		public static void BajaNinioSocio(Club c)
		{
			bool repite = true;

			Console.Clear();
			Console.WriteLine("/************ BAJA DE NIÑOS/SOCIOS ************/");
			Console.WriteLine(" ");

			while (repite)
			{
				int dni = 0;
				string deporte;
				
				Console.WriteLine("Lista actual de niños:");
				Console.WriteLine(" ");

				foreach (Ninio n in c.Ninios)
				{
					Console.WriteLine(" Apellido: {0} /// Nombre: {1} /// DNI: {2} /// Deporte: {3} /// Categoría: {4}", n.Apellido, n.Nombre, n.Dni, n.Deporte, n.Cat_);
				}

				Console.WriteLine(" ");

				Console.WriteLine("A continuación ingrese los datos de niño/socio que desea dar de baja.");
				try
				{
					Console.Write("Ingrese el dni: ");
					dni = int.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Ingrese solo números para el DNI.");
					return;
				}
				Console.Write("Deporte: ");
				deporte = Console.ReadLine().ToUpper();

				

				Console.WriteLine(" ");

				bool ninioEncontrado = false;
				foreach (Ninio n in c.Ninios)
				{
					if (n.Dni == dni && n.Deporte == deporte)
					{
						c.EliminarNinio(n);
						Console.WriteLine("El niño/socio con DNI {0} y deporte {1} ha sido dado de baja correctamente.", dni, deporte);

						foreach (Deporte d in c.Deportes)
						{
							if (d.NombreDepo == deporte && d.AnioCategoria == n.Cat_)
							{
								d.CantInscriptos--;
								break;
							}
						}
						ninioEncontrado = true;
						break;
					}
				}

				if (!ninioEncontrado)
				{
					Console.WriteLine("No se encontró un niño/socio con el DNI y deporte especificados.");
					repite = true;
				}

				Console.Write("Desea dar baja otro niño/socio? (S/N): ");
				string sigue = Console.ReadLine().ToUpper();

				if(sigue == "S")
				{
					repite = true;
				}
				else
				{
					repite = false;
					Console.WriteLine("Volviendo al menú...");
					Console.ReadKey();
				}
			}
		}

								
								
								
								
		public static void PagarCuota(Club c)
		{
			bool otraVez = false;

			Console.Clear();

			Console.WriteLine("/************ PAGO DE CUOTAS ************/");
			Console.WriteLine(" ");

			do
			{
				int dni = 0;
				
				Console.WriteLine("Ingrese el apellido y dni del niño/a.");
				Console.Write("Apellido: ");
				string ape = Console.ReadLine().ToUpper();
				try
				{
					Console.Write("DNI (sin puntos): ");
					dni = int.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("ERROR! Para el DNI ingrese solo números.");
				}

				bool encontrado = false;

				foreach (Ninio quienPaga in c.Ninios)
				{
					if ((quienPaga.Apellido == ape) && (quienPaga.Dni == dni))
					{
						encontrado = true;

						foreach (Deporte dep_practicado in c.Deportes)
						{
							if ((dep_practicado.NombreDepo == quienPaga.Deporte) &&
							    (quienPaga.Cat_ == dep_practicado.AnioCategoria))
							{
								if (quienPaga is Socio)
								{
									bool repite = true;

									Socio socioAbona = (Socio)quienPaga;
									double cuota = dep_practicado.CostoCuota - (socioAbona.Descuento / 100) * dep_practicado.CostoCuota;

									while (repite)
									{
										Console.WriteLine("El/La socio/a debe pagar: ${0}", cuota);
										Console.Write("Ingrese cuánto abonará: $");
										double abona = double.Parse(Console.ReadLine());

										if (abona > cuota)
										{
											double vuelto = abona - cuota;
											Console.WriteLine("Su vuelto es de: ${0}", vuelto);
											quienPaga.UltimoMesPago = DateTime.Today;
											Console.WriteLine("Cuota pagada satisfactoriamente!");
											repite = false;
											break;
										}
										if (abona == cuota)
										{
											quienPaga.UltimoMesPago = DateTime.Today;
											Console.WriteLine("Cuota pagada satisfactoriamente!");
											repite = false;
											break;
										}
										else
										{
											Console.WriteLine("Por favor, abone lo correspondiente para poder pagar la cuota.");
											repite = true;
										}
									}
									break;
								}
								else
								{
									bool repite = true;

									while (repite)
									{
										Console.WriteLine("El/La niño/a debe pagar: ${0}", dep_practicado.CostoCuota);
										Console.Write("Ingrese cuánto abonará: $");
										double abona = double.Parse(Console.ReadLine());

										if (abona > dep_practicado.CostoCuota)
										{
											double vuelto = abona - (double)dep_practicado.CostoCuota;
											Console.WriteLine("Su vuelto es de: ${0}", vuelto);
											quienPaga.UltimoMesPago = DateTime.Today;
											Console.WriteLine("Cuota pagada satisfactoriamente!");
											repite = false;
											break;
										}
										if (abona == dep_practicado.CostoCuota)
										{
											quienPaga.UltimoMesPago = DateTime.Today;
											Console.WriteLine("Cuota pagada satisfactoriamente!");
											repite = false;
											break;
										}
										else
										{
											Console.WriteLine("Por favor, abone lo correspondiente para poder pagar la cuota.");
											repite = true;
										}
									}
									break;
								}
							}
						}
					}
				}
				if (!encontrado)
				{
					Console.WriteLine("NIÑO/A NO ENCONTRADO/A.");
				}

				Console.WriteLine(" ");

				Console.Write("Desea pagar la cuota de otro niño? (S/N): ");
				string sigue = Console.ReadLine().ToUpper();

				if (sigue == "S")
				{
					otraVez = true;
				}
				else
				{
					otraVez = false;
					Console.WriteLine("Volviendo al Menú...");
					Console.ReadKey();
				}

			}while (otraVez);
		}

								
								
								
		public static void SubMenuInscriptos()
		{
			Console.Clear();
			Console.WriteLine("/************ SUBMENÚ DE INSCRIPTOS ************/");
			Console.WriteLine(" ");
			Console.WriteLine("a. Listado por deporte.");
			Console.WriteLine("b. Listado por deporte y categoría.");
			Console.WriteLine("c. Listado total.");
			Console.WriteLine("0. Volver al Menú Principal");
			Console.WriteLine(" ");
		}

								
								
								
								
		public static void ListadosInscriptos(Club club)
		{
			SubMenuInscriptos();

			bool repite = true;

			while (repite)
			{
				Console.Write("Seleccione una opcion: ");
				string opcion = Console.ReadLine().ToUpper();

				switch (opcion)
				{
					case "A":
						ListadoPorDeporte(club);
						break;
					case "B":
						ListadoPorDeporteYCategoria(club);
						break;
					case "C":
						ListadoTotal(club);
						break;
					case "0":
						repite = false;
						break;
					default:
						Console.WriteLine("La opcion ingresada es incorrecta, intente nuevamente.");
						repite = true;
						break;
				}
				
			}
		}

								
								
								
								
		public static void ListadoPorDeporte(Club c)
		{
			Console.WriteLine(" ");

			if (c.Ninios.Count == 0)
			{
				Console.WriteLine("Aún no hay niños inscriptos en ningun deporte.");
				return;
			}

			ArrayList deportesMostrados = new ArrayList();

			foreach (Deporte dx in c.Deportes)
			{
				if (deportesMostrados.Contains(dx.NombreDepo))
				{ continue; }
				else
				{
					deportesMostrados.Add(dx.NombreDepo);
					Console.WriteLine("Inscriptos en {0}:", dx.NombreDepo);
					
					foreach (Ninio n in c.Ninios)
					{
						if (n.Deporte == dx.NombreDepo)
						{
							n.MostrarDatos();
						}
					}
					Console.WriteLine("----------------------");
				}
			}

			Console.WriteLine("Presione cualquier tecla para volver a mostrar el submenú de inscriptos.");
			Console.ReadKey();

			SubMenuInscriptos();
		}
						
						
						
						
					
						

		public static void ListadoPorDeporteYCategoria(Club c)
		{
			Console.WriteLine(" ");

			if (c.Ninios.Count == 0)
			{
				Console.WriteLine("Aún no hay niños inscriptos en ningun deporte.");
				return;
			}

			foreach (Deporte dd in c.Deportes)
			{
				Console.WriteLine("Inscriptos en {0} categoría {1}:", dd.NombreDepo, dd.AnioCategoria);
				Console.WriteLine(" ");

				foreach (Ninio nn in c.Ninios)
				{
					if ((nn.Deporte == dd.NombreDepo) && (nn.Cat_ == dd.AnioCategoria))
					{
						nn.MostrarDatos();
					}
				}
				Console.WriteLine("----------------");
			}

			Console.WriteLine("Presione cualquier tecla para volver a mostrar el submenú de inscriptos.");
			Console.ReadKey();
			
			SubMenuInscriptos();
		}

		
		

		
		
		public static void ListadoTotal(Club c)
		{
			Console.WriteLine(" ");

			if (c.Ninios.Count == 0)
			{
				Console.WriteLine("No hay niños inscriptos en el club.");
				Console.WriteLine(" ");
				return;
			}
			
			Console.WriteLine("Listado de niños inscriptos en todos los deportes:");
			Console.WriteLine(" ");
			foreach (Ninio ninio in c.Ninios)
			{
				ninio.DatosAmpliados();
			}

			Console.WriteLine("Presione cualquier tecla para volver a mostrar el submenú de inscriptos.");
			Console.ReadKey();
			
			SubMenuInscriptos();
		}

		
		
		
		
		public static void ListadoDeudores(Club c)
		{
			int mesActual = DateTime.Today.Month;

			Console.Clear();

			Console.WriteLine("/************ LISTADO DE DEUDORES ************/");
			Console.WriteLine(" ");

			bool hayDeudores = false;

			foreach (Ninio nx in c.Ninios)
			{
				if (nx.UltimoMesPago == null || nx.UltimoMesPago.Month < mesActual)
				{
					nx.MostrarDatos();
					hayDeudores = true;
				}
			}

			if(!hayDeudores)
			{
				Console.WriteLine("No hay deudores para mostrar.");
			}

			Console.WriteLine("\nPulse cualquier tecla para volver al menú.");
			Console.ReadKey();
		}

			
			
		
		
			
		public static void AgregarDeporte(Club club)
		{
			string nombreDepo;
			string nombreEntrenador;
			string apellidoEntrenador;
			int dniEntrenador = 0;
			int categoria;
			int cupoCat;
			string diasYHorarios = "";
			int costoCuota;
			int descuento;
			
			bool continua = true;

			Console.Clear();
			Console.WriteLine("/************ AGREGAR DEPORTE ************/");
			Console.WriteLine(" ");

			while (continua)
			{
				try
				{
					bool sigueDiaHorario = true;

					Console.Write("Ingrese el nombre del deporte que quiere agregar: ");
					nombreDepo = Console.ReadLine().ToUpper();

					Console.Write("Ingrese el año de la categoría: ");
					categoria = int.Parse(Console.ReadLine());

					bool deporteExiste = false;

					foreach (Deporte elem in club.Deportes)
					{
						if (elem.NombreDepo == nombreDepo && elem.AnioCategoria == categoria)
						{
							Console.WriteLine("El deporte ingresado y su respectiva categoría ya existe, intente nuevamente con otro deporte y categoría.");
							deporteExiste = true;
							break;
						}
					}

					if (!deporteExiste)
					{
						Console.Write("Ingrese el cupo máximo de la categoría: ");
						cupoCat = int.Parse(Console.ReadLine());

						Console.Write("Ingrese el nombre del entrenador: ");
						nombreEntrenador = Console.ReadLine();
						
						Console.Write("Ingrese el apellido del entrenador: ");
						apellidoEntrenador = Console.ReadLine();

						bool entrenadorExiste = false;

						while (!entrenadorExiste)
						{
							Console.Write("Ingrese el DNI del entrenador: ");
							dniEntrenador = int.Parse(Console.ReadLine());
							
							foreach (Entrenador elem in club.Entrenadores)
							{
								if (elem.Dni == dniEntrenador)
								{
									entrenadorExiste = true;
									break;
								}
							}

							if (!entrenadorExiste)
							{
								Console.WriteLine("El entrenador que intenta asignar NO EXISTE dentro del Club. Por favor intente nuevamente.");
							}
						}

						if (entrenadorExiste)
						{
							while (sigueDiaHorario)
							{
								Console.Write("Ingrese el día de entrenamiento (ej: martes): ");
								string dia = Console.ReadLine();

								Console.Write("Ingrese el horario de entrenamiento (ej: 15:00): ");
								string horario = Console.ReadLine();

								diasYHorarios = dia + " " + horario;

								Console.Write("¿Desea agregar otro dia y horario de entrenamiento? (S/N): ");
								string opcion = Console.ReadLine().ToUpper();

								if (opcion == "S")
								{
									sigueDiaHorario = true;
								}
								else
								{
									sigueDiaHorario = false;
								}
							}
							
							Console.Write("Ingrese el costo de la cuota del deporte: ");
							costoCuota = int.Parse(Console.ReadLine());

							Console.Write("Ingrese el descuento que se aplica para socios (por ejemplo, si es 15% solo ingrese 15): ");
							descuento = int.Parse(Console.ReadLine());

							Deporte nuevoDeporte = new Deporte(nombreDepo, categoria, cupoCat, nombreEntrenador, apellidoEntrenador, dniEntrenador, costoCuota, descuento);
							nuevoDeporte.AgregarHorario(diasYHorarios);
							club.AgregarDeporte(nuevoDeporte);
							
							Console.WriteLine(" ");

							Console.WriteLine("Deporte agregado correctamente!");

							Console.WriteLine("");

							Console.Write("¿Desea agregar otro deporte? (S/N): ");
							string agregarDepo = Console.ReadLine().ToUpper();

							if (agregarDepo == "S")
							{
								continua = true;
							}
							else
							{
								continua = false;
								Console.WriteLine("Volviendo al menú...");
								Console.ReadKey();
							}
						}
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("El último dato fue ingresado incorrectamente, por favor ingrese nuevamente lo que corresponda.");
					Console.WriteLine(" ");
					continua = true;
				}
			}
		}

		public static void EliminarDeporte(Club club)
		{
			string nombreEliminar;
			int categoriaEliminar;

			bool repite = true;

			Console.Clear();
			Console.WriteLine("/************ ELIMINAR DEPORTE ************/");
			Console.WriteLine(" ");

			while (repite)
			{
				Console.Write("Ingrese el nombre del deporte a eliminar: ");
				nombreEliminar = Console.ReadLine().ToUpper();

				Console.Write("Ingrese la categoría del deporte: ");
				categoriaEliminar = int.Parse(Console.ReadLine());

				Deporte deporteAEliminar = null;
				foreach (Deporte elem in club.Deportes)
				{
					if (elem.NombreDepo.ToUpper() == nombreEliminar && elem.AnioCategoria == categoriaEliminar)
					{
						deporteAEliminar = elem;
						break;
					}
				}

				if (deporteAEliminar != null)
				{
					if (deporteAEliminar.CantInscriptos == 0)
					{
						club.EliminarDeporte(deporteAEliminar);
						Console.WriteLine("Deporte eliminado exitosamente!");
					}
					else
					{
						Console.WriteLine("El deporte seleccionado no se puede eliminar ya que contiene inscriptos dentro de él.");
					}
				}
				else
				{
					Console.WriteLine("No se encontró el deporte ingresado. Por favor intente nuevamente con un deporte existente.");
					Console.WriteLine(" ");
					continue;
				}

				Console.Write("¿Desea eliminar otro deporte? (S/N): ");
				string opcion = Console.ReadLine();

				if(opcion.ToUpper() == "S")
				{
					repite = true;
				}
				else
				{
					repite = false;
					Console.WriteLine("Volviendo al menú...");
					Console.ReadKey();
				}
			}
		}
		
		public static void CargarObjetos(Club c)
		{
			Deporte deporte1 = new Deporte("FUTBOL", 2008, 2, "FRANCO", "LLANOS", 123, 10000, 18);
			deporte1.AgregarHorario("LUNES 15:00");
			Deporte deporte2 = new Deporte("BOXEO", 2014, 12, "JUAN", "LOBOS", 124, 7500, 10);
			deporte1.AgregarHorario("LUNES 10:00");
			Deporte deporte3 = new Deporte("FUTBOL", 2015, 20, "JULIO", "LOPEZ", 125, 10000, 12);
			deporte1.AgregarHorario("JUEVES 16:00");
			Deporte deporte4 = new Deporte("VOLEY", 2016, 16, "FLORENCIA", "QUIROZ", 126, 9500, 14);
			deporte1.AgregarHorario("VIERNES 15:30");
			Deporte deporte5 = new Deporte("NATACIÓN", 2014, 10, "LUCIA", "FERNANDEZ", 127, 8000, 15);
			deporte1.AgregarHorario("SÁBADO 11:00");
			Deporte deporte6 = new Deporte("NATACIÓN", 2010, 8, "SILVIO", "JARA", 128, 8000, 12);
			deporte1.AgregarHorario("MARTES 16:00");

			Entrenador entrenador1 = new Entrenador("FRANCO", "LLANOS", 41, 123);
			Entrenador entrenador2 = new Entrenador("JUAN", "LOBOS", 36, 124);
			Entrenador entrenador3 = new Entrenador("JULIO", "LOPEZ", 28, 125);
			Entrenador entrenador4 = new Entrenador("LUCIA", "FERNANDEZ", 31, 127);
			Entrenador entrenador5 = new Entrenador("FLORENCIA", "QUIROZ", 44, 126);
			Entrenador entrenador6 = new Entrenador("SILVIO", "JARA", 53, 128);
			
			c.AgregarEntrenador(entrenador1);
			c.AgregarEntrenador(entrenador2);
			c.AgregarEntrenador(entrenador3);
			c.AgregarEntrenador(entrenador4);
			c.AgregarEntrenador(entrenador5);
			c.AgregarEntrenador(entrenador6);
			
			c.AgregarDeporte(deporte1);
			c.AgregarDeporte(deporte2);
			c.AgregarDeporte(deporte3);
			c.AgregarDeporte(deporte4);
			c.AgregarDeporte(deporte5);
			c.AgregarDeporte(deporte6);
			

			Ninio ninio1 = new Ninio("PEDRO", "ALVAREZ", 16, 129, "FUTBOL", 2008);
			DateTime dt1 = new DateTime(2024, 8, 14);
			ninio1.UltimoMesPago = dt1;
			
			Ninio ninio2 = new Ninio("JUAN", "CASTRO", 10, 130, "BOXEO", 2014);
			DateTime dt2 = new DateTime(2024, 11, 17);
			ninio2.UltimoMesPago = dt2;

			Ninio ninio3 = new Ninio("ABRIL", "MANRIQUE", 14, 131, "NATACIÓN", 2014);
			DateTime dt3 = new DateTime(2024, 9, 29);
			ninio3.UltimoMesPago = dt3;
			
			Ninio ninio4 = new Ninio("DEMIAN", "ESCOBAR", 8, 132, "VOLEY", 2016);
			DateTime dt4 = new DateTime(2024, 11, 15);
			ninio4.UltimoMesPago = dt4;
			
			Ninio ninio5 = new Ninio("CINTIA", "CORREA", 9, 133, "FUTBOL", 2015);
			DateTime dt5 = new DateTime(2024,11, 17);
			ninio5.UltimoMesPago = dt5;
			
			Ninio ninio6 = new Ninio("JULIETA", "FRIAS", 14, 134, "NATACIÓN", 2010);
			DateTime dt6 = new DateTime(2024,10,11);
			ninio6.UltimoMesPago = dt6;

			Socio socio1 = new Socio("RAFAEL", "AGUILAR", 10, 135, "BOXEO", 2014, 18);
			DateTime dt7 = new DateTime(2024, 10, 14);
			socio1.UltimoMesPago = dt7;
			
			Socio socio2 = new Socio("SELENA", "CORREA", 10, 136, "VOLEY", 2014, 14);
			DateTime dt8 = new DateTime(2024,11,15);
			socio2.UltimoMesPago = dt8;
			
			Socio socio3 = new Socio("MIKEL", "SUAREZ", 16, 137, "FUTBOL", 2008, 18);
			DateTime dt9 = new DateTime(2024,10,15);
			socio3.UltimoMesPago = dt9;
			
			Socio socio4 = new Socio("PETER", "PETER", 14, 138, "NATACIÓN", 2010, 12);
			DateTime dt10 = new DateTime(2024,10,1);
			socio4.UltimoMesPago = dt10;
			
			c.AgregarNinio(ninio1);
			c.AgregarNinio(ninio2);
			c.AgregarNinio(ninio3);
			c.AgregarNinio(ninio4);
			c.AgregarNinio(ninio5);
			c.AgregarNinio(ninio6);
			
			c.AgregarNinio(socio1);
			c.AgregarNinio(socio2);
			c.AgregarNinio(socio3);
			c.AgregarNinio(socio4);
			
			deporte1.CantInscriptos = 2;
		}

	}
}