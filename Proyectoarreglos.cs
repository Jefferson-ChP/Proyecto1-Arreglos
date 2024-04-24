//Proyecto de curso No.1

using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography;

//Variables generales

var acceso = true;
int intentos = 3;
double ventamayor = double.MinValue;
double ventamenor = double.MaxValue;
int diamenor = 0;
int diamayor = 0;

//Ingreso al sistema

try
{

    //Ciclo acceso al programa

    while (acceso == true)
    {


        Console.Clear();
        Console.WriteLine("=====================================================================");
        Console.WriteLine("Bienvenido a la página del proyecto");
        Console.WriteLine("Para continuar por favor ingrese su usuario y contraseña");
        Console.WriteLine("=====================================================================\n");

        Console.Write("Usuario: "); var usuario = Convert.ToString(Console.ReadLine());
        Console.WriteLine("");

        Console.Write("Contraseña: "); var contraseña = Convert.ToString(Console.ReadLine());
        Console.WriteLine("");

        //Caso contraseña o usuario incorrectos

        if (usuario != "1" || contraseña != "1")
        {

            //Caso exceso de intentos

            if (intentos == 1)
            {
                Console.WriteLine("Número de intentos excedido, presione cualquier tecla para salir.");
                acceso = false;
                Console.ReadKey();
            }

            //Intentos

            else
            {
                intentos--;
                Console.WriteLine("El usuario o la contraseña ingresadas son inválidos.\n");
                Console.WriteLine($"Intentos restantes: {intentos}\n");
                Console.ReadKey();
            }
        }

        //Caso usuario y contraseña correctos

        else
        {
            Console.WriteLine("Usuario y contraseña correctos. Presione cualquier tecla para acceder al sistema.");
            Console.ReadKey();

            var menu = true;

            double totalventas = 0;


            //Ciclo menu

            while (menu == true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("===============================================");
                    Console.WriteLine("--MENU DE OPERACIONES--");
                    Console.WriteLine("1. Registro de ventas");
                    Console.WriteLine("2. Calculo del total de ventas");
                    Console.WriteLine("3. Calculo del promedio de ventas");
                    Console.WriteLine("4. Identificación del día con menos ventas");
                    Console.WriteLine("5. Identificación del día con más ventas");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("===============================================\n");
                    Console.Write("Seleccione alguna de las opciones del menú "); int opcion = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");



                    //Arreglo días de la semana

                    double[] ventas = { 0, 0, 0, 0, 0, 0, 0 };
                    string[] dias = {"lunes", "martes", "miercoles", "jueves", "viernes", "sábado", "domingo"};

                    //Switch menu

                    switch (opcion)
                    {

                        //Caso registro de ventas

                        case 1:

                            //variables internas Case 1

                            ventamenor = double.MaxValue;
                            ventamayor = double.MinValue;
                            totalventas = 0;
                           
                            //Ciclo de registro de ventas

                            for (int i = 0; i < 7; i++)
                            {
                                Console.Write($"Ingrese la venta del día {dias[i]}: Q"); ventas[i] = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("");
                                

                                //Registro de la venta menor

                                if (ventas[i] < ventamenor)
                                {
                                    ventamenor = ventas[i];
                                    diamenor = i;
                                }

                                //Registro de la venta mayor

                                if (ventas[i] > ventamayor)
                                {
                                    ventamayor = ventas[i];
                                    diamayor = i;
                                }

                                //Cálculo del total de ventas

                                totalventas = totalventas + ventas[i];
                            }
                            break;

                        //Caso total de ventas

                        case 2:

                            //Caso no hay ventas ingresadas

                            if (totalventas == 0)
                            {
                                Console.WriteLine("Aún no han sido ingresadas ventas");
                                Console.ReadKey();
                            }

                            //Caso ventas ya ingresadas

                            else
                            {
                                Console.WriteLine($"El total de ventas de la semana es: Q{totalventas}\n");
                                Console.WriteLine("Presione cualquier tecla para volver al menu");
                                Console.ReadKey();
                            }
                            break;

                        //Caso promedio de ventas

                        case 3:

                            double promedioventas = totalventas / 7;

                            //Caso no hay ventas ingresadas

                            if (totalventas == 0)
                            {
                                Console.WriteLine("Aún no han sido ingresadas ventas");
                                Console.ReadKey();
                            }

                            //Caso ventas ya ingresadas

                            else
                            {
                                Console.WriteLine($"El promedio de las ventas de la semana es: Q{promedioventas}\n");
                                Console.WriteLine("Presione cualquier tecla para volver al menu");
                                Console.ReadKey();
                            }
                            break;

                        //Caso día con menos ventas

                        case 4:

                            //Caso no hay ventas ingresadas

                            if (totalventas == 0)
                            {
                                Console.WriteLine("Aún no han sido ingresadas ventas");
                                Console.ReadKey();
                            }

                            //Caso ventas ya ingresadas

                            else
                            {
                                Console.WriteLine($"Las menores ventas de la semana fueron el día {dias[diamenor]} con: Q{ventamenor}\n");
                                Console.WriteLine("Presione cualquier tecla para volver al menu");
                                Console.ReadKey();
                            }
                            break;

                        //Caso día con más ventas

                        case 5:

                            //Caso no hay ventas ingresadas

                            if (totalventas == 0)
                            {
                                Console.WriteLine("Aún no han sido ingresadas ventas");
                                Console.ReadKey();
                            }

                            //Caso ventas ya ingresadas

                            else
                            {
                                Console.WriteLine($"El día con más ventas de la semana es {dias[diamayor]} con: Q{ventamayor}\n");
                                Console.WriteLine("Presione cualquier tecla para volver al menu");
                                Console.ReadKey();
                            }
                            break;

                        //Salir del programa

                        case 6:
                            acceso = false;
                            menu = false;
                            Console.ReadKey();
                            break;

                        //Caso opción inválida

                        default:
                            Console.WriteLine($"La opción {opcion} no está dentro del menu");
                            Console.ReadKey();
                            break;
                    }

                }

                
                //Identificación de errores dentro del menu

                catch (FormatException ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Formato ingresado inválido, solamente se aceptan números enteros en el menu");
                    Console.ReadKey();
                }

            }
        }
    }
}

//Identificación de errores general

catch (FormatException ex)
{
    Console.WriteLine("");
    Console.WriteLine("Formato ingresado inválido");
    Console.ReadKey();
}