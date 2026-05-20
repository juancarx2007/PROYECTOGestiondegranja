using Proyecto2_JCAA_1227526;
using System;
class Program
{
    static void Main() // Funcion main
    {
        //Se mandan a llamar la funciones para crear el entorno del juego y configurarlo. 
        Granja granja = new Granja(0,0,0,0,0,0,0,0,null,null,0,0,0,0,0,0,0,0,true);
        granja.ConfigurarGranja();
        granja.CrearSemillas();
        granja.CrearParcelas();
        //Ciclo para el menu.
        while (granja.seguirSimulacion == true)
        {
            Console.Clear();
            granja.MostrarMenu();
            int opcionMenu = granja.LeerEntero("Ingrese la opcion del menu");
            Console.WriteLine();
            if (opcionMenu==1)
            {
                granja.ComprarSemillas();
            }else if (opcionMenu==2)
            {
                granja.Sembrar();
            }else if (opcionMenu==3)
            {
                granja.ConsultarParcelas();
            }else if (opcionMenu==4)
            {
                granja.AvanzarMes();
            } else if (opcionMenu==5)
            {
                Console.WriteLine("Saliendo de la simulacion...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ingrese una opcion valida");

            }
            granja.seguirSimulacion = granja.VerificarFinSimulacion(opcionMenu);
            if (granja.seguirSimulacion==true)
            {
                Console.WriteLine("\nPresione ENTER para continuar...");
                Console.ReadLine();
            }

        }
        //Salida del juego.
        Console.Clear();
        Console.WriteLine("\nSe acabo el juego...");
        granja.GenerarReporteFinal();
        Console.WriteLine("\nPresione ENTER para continuar...");
        Console.ReadLine();

    }
}