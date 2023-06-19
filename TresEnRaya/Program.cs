using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TresEnRaya
{
    internal class Program
    {
        static char[] plazas = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };//Poniendo las plazas del tablero
        static int jugador1 = 1;

        static int turno;//Guardara la posicion que el jugador marque en el tablero
        static int check = 0;
        static void Main(string[] args)
        {
            InicioDeJuego();
        }

        public static void InicioDeJuego()
        {
            do
            {
                Console.Clear();//Ponemos esto para limpiar la pantalla
                Console.WriteLine("Jugador1 X:Jugador2 0");
                Console.WriteLine("\n");

                if (jugador1 % 2 == 0)//Comprobaremos el turno de los jugadores cuando es par jugador2
                {
                    Console.WriteLine("Turno para jugador 2");
                }
                else
                {
                    Console.WriteLine("Turno para jugador 1");//Cuando no es par jugador1
                }
                Console.WriteLine("\n");
                Tabla();//Llamamos al tablero
                turno = int.Parse(Console.ReadLine());
                if (plazas[turno] != 'X' && plazas[turno] != 'O')//Hacemos esta condicion cuando la casilla esta vacia
                {
                    if (jugador1 % 2 == 0) //Dependiendo del turno se marca uno o la otra
                    {
                        plazas[turno] = 'O';
                        jugador1++;
                    }
                    else
                    {
                        plazas[turno] = 'X';
                        jugador1++;
                    }
                }
                else
                {
                    Console.WriteLine("Lo siento la columna {0} ha sido marcada {1}", turno, plazas[turno]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Cargando la tabla.....");
                    Thread.Sleep(2000);
                }

                check = Ganador();

            } while (check != 1 && check != -1);

            Console.Clear();//Limpiando la consola
            Tabla();

            if (check == 1)
            {
                Console.WriteLine("Jugador {0} ha ganado", (jugador1 % 2) + 1);
            }

            else
            {
                Console.WriteLine("Empate");
            }

            Console.ReadLine();
        }

        static void Tabla()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", plazas[1], plazas[2], plazas[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", plazas[4], plazas[5], plazas[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", plazas[7], plazas[8], plazas[9]);
            Console.WriteLine("     |     |      ");
        }

        static int Ganador()
        {
            //Comprobar si hay tres fichas iguales en horitzontal
            if (plazas[1] == plazas[2] && plazas[2] == plazas[3])
            {
                return 1;
            }

            else if (plazas[4] == plazas[5] && plazas[5] == plazas[6])
            {
                return 1;
            }
            else if (plazas[6] == plazas[7] && plazas[7] == plazas[8])
            {
                return 1;
            }
            //Comprobar si hay fichas iguales en vertical
            else if (plazas[1] == plazas[4] && plazas[4] == plazas[7])
            {
                return 1;
            }
            else if (plazas[2] == plazas[5] && plazas[5] == plazas[8])
            {
                return 1;
            }
            else if (plazas[3] == plazas[6] && plazas[6] == plazas[9])
            {
                return 1;
            }
            //Viendo si hay empate
            return 0;

        }
    }
}
