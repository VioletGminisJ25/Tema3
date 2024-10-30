using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: CLAVE DUPLICADA EN HASH Y RECORRER HASH SIN BUCLE CLÁSICO SOLVED
namespace Ejercicio1
{
    internal class Program
    {
        public delegate void Functions();
        static string[] options;
        static Hashtable ordenadores;
        private static IFormatProvider result;
        private static String ipString = "";

        static void Main(string[] args)
        {
            ordenadores = new Hashtable();
            bool resp = MenuGenerator(options = new string[] { "Introducir datos", "Eliminar dato por clave", "Muestra colección", "Muestra elemento de la colección" }, new Functions[] { IntroducirDatos, EliminarDato, MuestraColeccion, MuestraElemento });
            Console.WriteLine(resp);
        }




        public static bool MenuGenerator(string[] opciones, Functions[] deleg)
        {
            bool finished = false;
            bool valid = true;
            if (options != null && deleg != null && !deleg.Contains(null) && !options.Contains(null) && options.Length == deleg.Length)
            {
                do
                {
                    Console.WriteLine("MENU\n----");
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} -- {opciones[i]}");
                    }
                    Console.WriteLine($"{opciones.Length + 1} -- Salir");
                    //notValid = false;
                    try
                    {
                        if (Int32.TryParse(Console.ReadLine(), out int resp))
                        {
                            if (resp > 0 && resp <= options.Length)
                            {
                                deleg[resp - 1]();
                            }
                            if (resp <= 0 || resp > options.Length + 1)
                            {
                                Console.WriteLine("ERR: Opción no valida");
                            }
                            if (resp == opciones.Length + 1)
                            {
                                finished = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERR: Error de formato");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("ERR: El formato no es correcto");
                        //return false;
                    }


                    //return true;
                } while (!finished);
            }
            else
            {
                valid = false;
            }
            return valid;
        }



        public static void IntroducirDatos()
        {
            bool ipOK;
            do
            {
                ipOK = true;
                Console.WriteLine("Introduce una IP: ");
                ipString = Console.ReadLine();

                string[] ipArrayString = ipString.Split('.');


                if (ipArrayString.Length != 4)
                {
                    ipOK = false;
                    Console.WriteLine("ERR: No es una ip válida");
                }
                else
                {
                    for (int i = 0; i < ipArrayString.Length; i++)
                    {
                        if (Byte.TryParse(ipArrayString[i], out byte data) && !ordenadores.ContainsKey(ipString))
                        {
                            ipOK = true;
                        }else
                        {
                            ipOK = false;
                        }
                    }
                    if (!ipOK)
                    {
                        Console.WriteLine("ERR: La ip no es válida o está duplicada!");
                    }
                }
            } while (!ipOK);
            bool ramOK;
            int ram;
            do
            {
                Console.WriteLine("Introduce la RAM del dispositivo");
                if (Int32.TryParse(Console.ReadLine(), out ram))
                {
                    if (ram > 0)
                    {
                        ramOK = true;
                    }
                    else
                    {
                        Console.WriteLine("ERR: El error debe ser un entero positivo");
                        ramOK = false;
                    }
                }
                else
                {
                    Console.WriteLine("El valor introducido no es correcto");
                    ramOK = false;
                }
            } while (!ramOK);

            ordenadores.Add(ipString, ram);
            Console.WriteLine("INFO: Ordenador creado correctamente!");


        }


        public static void EliminarDato()
        {
            if (ordenadores.Count != 0)
            {
                bool elimOK;
                do
                {
                    Console.WriteLine("Introduce la ip a eliminar");
                    string resp = Console.ReadLine();

                    if (ordenadores.ContainsKey(resp))
                    {
                        ordenadores.Remove(resp);
                        if (!ordenadores.ContainsKey(resp))
                        {
                            Console.WriteLine("INFO: Se ha eliminado con éxito");
                            elimOK = true;
                        }
                        else
                        {
                            elimOK = false;
                            Console.WriteLine("Ha habido un error eliminado el ordenador");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No existe esa IP");
                        elimOK = false;
                    }
                } while (!elimOK);
            }
            else
            {
                Console.WriteLine("ERR: No se han encontrado elementos");
            }
        }

        public static void MuestraColeccion()
        {

            if (ordenadores.Count != 0)
            {

                foreach (DictionaryEntry item in ordenadores)
                {
                    Console.WriteLine($"IP:{item.Key,-20} RAM: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("ERR: No se han encontrado elementos");
            }
        }

        public static void MuestraElemento()
        {
            bool muestraOK = false;
            if (ordenadores.Count != 0)
            {
                do
                {
                    Console.WriteLine("Introduce la ip a mostrar");
                    string resp = Console.ReadLine();
                    Console.WriteLine(ordenadores.Count);
                    if (ordenadores.ContainsKey(resp))
                    {
                        Console.WriteLine($"IP:{resp} --- RAM: {ordenadores[resp]}");
                        muestraOK = true;
                    }
                    else
                    {
                        Console.WriteLine("ERR: La ip no existe");
                    }

                } while (!muestraOK);


            }
            else
            {
                Console.WriteLine("ERR: No se han encontrado elementos");
            }
        }
    }
}


