using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParical_GrupoDeAccionN_2
{
    class Program
    {
        static void cargarCarrito(ref int cantidadCamisas)//Agregar camisas al carrito
        {
            cantidadCamisas++;
            Console.Clear();
            Console.WriteLine("Usted ha agregado una camisa al carrito");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void eliminarUnElementoCarrito(ref int cantidadCamisas)//Eliminar camisas
        {
            Console.Clear();
            if (cantidadCamisas <= 0)//Si la variable de cantidad camisas esta en 0 no modificamos la variable y imprimimos un mensaje por pantalla
            {
                Console.WriteLine("No hay ningun elemento en el carrito para elminar");
            }
            else
            {
                cantidadCamisas--;
                Console.WriteLine("Usted ha quitado una camisa del carrito");
            }
            
            
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static double precioSinDescuento(int cantidadCamisa,double precioCamisa)//Calculamos el precio sin descuento de las camisas
        {
            double preciototal=0;

            preciototal = (cantidadCamisa * precioCamisa);

            return preciototal;
        }

        static double aplicarDescuento(int cantidadCamisa,double preciototal,ref double preciofinal)//Determinamos el descuento a aplicar
        {

            int tipoDescuento=0;

            if (cantidadCamisa >= 3 && cantidadCamisa<=5)//Segun las cantidad de camisas es el descuento al cual le corresponde
            {
                tipoDescuento = 10;
            }
            else if (cantidadCamisa > 5)
            {
                tipoDescuento = 20;

            }
            else
            {
                tipoDescuento = 0;
            }

            preciofinal = (preciototal - ((preciototal * tipoDescuento) / 100));

            return tipoDescuento;
        }
        static void Main(string[] args)
        {

            

            string salida="";
            double precioCamisa=1000;
            int opc=0,cantidadCamisas=0;
            double preciofinal = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Camisas PRADBIT - Ventas minoristas y mayoristas");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("Digite  1: Añadir camisa al carro de compra \n"); 
                Console.WriteLine("Digite  2: Eliminar camisa del carro de compra \n");
                Console.WriteLine("Digite  3: Salir \n");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("     -   Cantidad de camisas en el carro de compras: {0} \n ", cantidadCamisas);
                Console.WriteLine("     -   Precio unitario: $1000 \n");
                Console.WriteLine("     -   Precio total sin descuento: ${0} \n", precioSinDescuento(cantidadCamisas,precioCamisa));
                Console.WriteLine("     -   Tipo de descuento aplicado: %{0} \n", aplicarDescuento(cantidadCamisas, precioSinDescuento(cantidadCamisas, precioCamisa), ref preciofinal));
                Console.WriteLine("     -   Precio final con descuento: ${0} \n", preciofinal);
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.Write("Elija una opcion: ");
                try
                {
                    opc = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opc = 0;//Opc se restaura en 0 para que no siga ejecutando la opcion seleccionada anteriormente en caso de ingresar un tipo de dato diferente al pedido.
                }
                

                switch (opc)
                {
                    case 1://Agregar camisas al carrito
                        {
                            cargarCarrito(ref cantidadCamisas);
                            break;
                        }
                    case 2://Elminamos camisas del carrito
                        {
                            eliminarUnElementoCarrito(ref cantidadCamisas);
                            break;
                        }
                    case 3://Salida del programa
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Estas seguro que desea salir? s/n");
                                try
                                {
                                    salida = Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                }
                            } while (salida != "s" && salida != "n" && salida != "N" && salida != "S");//Validar dato ingresado

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("La opcion ingresada no es correcta.Presione una tecla para continuar");
                            Console.ReadKey();
                            break;
                        }
                }
            } while (salida != "s" && salida != "S");//Condicion para salir

            Console.ReadKey();
        }
    }
}
