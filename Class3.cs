using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_JCAA_1227526
{
    internal class Granja //Clase granja
    {//Inician las variables
        float capitalInicial;
        float dineroCaja;
        int numEmpleados;
        float sueldoMensual;
        int mesesSimular;
        int mesesRestantes;
        int filasParc;
        int colsParc;
        Parcela[,]parcelas;
        Semilla[] listaSemillas;
        int invTrigo;
        int invRepollo;
        int invTomate;
        int invCalabaza;
        int invEsparrago;
        float ingresosCosecha;
        float gastoSemillas;
        float gastoSalarios;
        public bool seguirSimulacion; //Se utiliza publica para poder usarla en otras partes del programa.
        public Granja(float capitalInicial, float dineroCaja, int numEmpleados,
    float sueldoMensual, int mesesSimular, int mesesRestantes,
    int filasParc, int colsParc, Parcela[,]parcelas,
    Semilla[] listaSemillas, int invTrigo, int invRepollo,
    int invTomate, int invCalabaza, int invEsparrago,
    float ingresosCosecha, float gastoSemillas,
    float gastoSalarios, bool seguirSimulacion)
        {
            this.capitalInicial = capitalInicial;
            this.dineroCaja = dineroCaja;
            this.numEmpleados = numEmpleados;
            this.sueldoMensual = sueldoMensual;
            this.mesesSimular = mesesSimular;
            this.mesesRestantes = mesesRestantes;
            this.filasParc = filasParc;
            this.colsParc = colsParc;
            this.parcelas = parcelas;
            this.listaSemillas = listaSemillas;
            this.invTrigo = invTrigo;
            this.invRepollo = invRepollo;
            this.invTomate = invTomate;
            this.invCalabaza = invCalabaza;
            this.invEsparrago = invEsparrago;
            this.ingresosCosecha = ingresosCosecha;
            this.gastoSemillas = gastoSemillas;
            this.gastoSalarios = gastoSalarios;
            this.seguirSimulacion = seguirSimulacion;
        }//Funcion para configurar los datos iniciales
        public void ConfigurarGranja()
        {
            capitalInicial = LeerFloat("Ingrese capital inicial");
            numEmpleados = LeerEntero("Ingrese numero de empleados");
            sueldoMensual = LeerFloat("Ingrese sueldo mensual");
            mesesSimular = LeerEntero("Ingrese meses por simular");
            filasParc = LeerEntero("Ingrese cantidad de filas");
            colsParc = LeerEntero("Ingrese cantidad de columnas");
            dineroCaja = capitalInicial;
            mesesRestantes = mesesSimular;
            ingresosCosecha = 0;
            gastoSemillas = 0;
            gastoSalarios = 0;
            invTrigo = 0;
            invRepollo = 0;
            invTomate = 0;
            invCalabaza = 0;
            invEsparrago = 0;
        }
        //Se crean las semillas usando el objeto
        public void CrearSemillas()
        {
            Semilla trigo = new Semilla("trigo", 1, 100, 130);
            Semilla repollo = new Semilla("repollo", 2, 180, 280);
            Semilla tomate = new Semilla("tomate", 3, 250, 450);
            Semilla calabaza = new Semilla("calabaza", 4, 220, 360);
            Semilla esparrago = new Semilla("esparrago", 6, 500, 1000);
            listaSemillas = new Semilla[] { trigo, repollo, tomate, calabaza, esparrago };
        }
        public void CrearParcelas() //Se crean las parcelas usando el objeto. 
        {
            parcelas = new Parcela[filasParc, colsParc];
            for (int fila = 0; fila < filasParc; fila++)
            {
                for (int col = 0; col < colsParc; col++)
                {
                    parcelas[fila, col] = new Parcela(fila, col, false, null, 0);
                }
            }
            }
        public void MostrarMenu()//Menu visual
        {
            Console.WriteLine("===== MENÚ PRINCIPAL ===== \n1. Comprar semillas \n 2. Sembrar \n3. Consultar parcelas \n4. Avanzar de mes\n5. Salir");
        }
        //Funciones de acciones
        public void ComprarSemillas()
        {
            float costoMensual = CalcularCostoMensual();
            float utilidadDisp = CalcularUtilidadDisponible();
            Semilla semillaSeleccionada = null;
            Console.WriteLine("El dinero en caja es: " + dineroCaja + "\nEl costo mensual es: " + costoMensual + "\n La utilidad disponible es: " + utilidadDisp);
            if (utilidadDisp>=0)
            {
                Console.WriteLine("La lista de semillas es:");
                for (int i = 0; i < listaSemillas.Length; i++)
                {
                    listaSemillas[i].MostrarInfoSemilla();
                }
                Console.WriteLine("Ingrese el tipo de semilla");
                string tipoSemilla = Console.ReadLine().ToLower();
                int cantSemillas = LeerEntero("Ingrese la cantidad de semilla");
                bool encontrada = false;
                for (int i = 0; i < listaSemillas.Length; i++)
                {
                    if (listaSemillas[i].nombreSemilla==tipoSemilla)
                    {
                        semillaSeleccionada = listaSemillas[i];
                        encontrada = true;
                    }
                }
                if (encontrada==true)
                {
                    float costoCompra = semillaSeleccionada.ObtenerCosto() * cantSemillas;
                    if (dineroCaja>=costoCompra)
                    {
                        AgregarSemillas(tipoSemilla, cantSemillas);
                        dineroCaja = dineroCaja - costoCompra;
                        gastoSemillas += costoCompra;
                        Console.WriteLine("Compra realizada correctamente");
                    }
                    else
                    {
                        Console.WriteLine("Dinero insuficiente");
                    }

                }
                else
                {
                    Console.WriteLine("Tipo de semilla invalido");
                }

            }
            else
            {
                Console.WriteLine("No se pueden comprar semillas porque la utilidad es negativa");
            }
        }
        public void MostrarInventario()
        {
            Console.WriteLine("Inventario de semillas\n trigo: "+invTrigo + "\nrepollo: " + invRepollo + " \nTomate; " +invTomate + "\nCalabaza: " + invCalabaza + "\nEspárrago: " + invEsparrago);
        }
        public void AgregarSemillas(string tipoSemilla, int cantidad)
        {
            if (tipoSemilla == "trigo")
            {
                invTrigo += cantidad;
            }
            else if (tipoSemilla == "repollo")
            {
                invRepollo += cantidad;
            }
            else if (tipoSemilla == "tomate")
            {
                invTomate += cantidad;
            }
            else if (tipoSemilla == "calabaza")
            {
                invCalabaza += cantidad;
            }
            else if (tipoSemilla == "esparrago")
            {
                invEsparrago += cantidad;
            }
            else
            {
                Console.WriteLine("Tipo de semilla invalido");
            }

        }
        public void DescontarSemilla(string tipoSemilla)
        {
            if (tipoSemilla == "trigo")
            {
                invTrigo -= 1;
            }
            else if (tipoSemilla == "repollo")
            {
                invRepollo -=1;
            }
            else if (tipoSemilla == "tomate")
            {
                invTomate -= 1;
            }
            else if (tipoSemilla == "calabaza")
            {
                invCalabaza -= 1;
            }
            else if (tipoSemilla == "esparrago")
            {
                invEsparrago -= 1;
            }
            else
            {
                Console.WriteLine("Tipo de semilla invalido");
            }
        }
        public bool VerificarDisponibilidad(string tipoSemilla)
        {
            if (tipoSemilla=="trigo")
            {
                if (invTrigo>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else if (tipoSemilla=="repollo")
            {
                if (invRepollo > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tipoSemilla == "tomate")
            {
                if (invTomate > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tipoSemilla == "calabaza")
            {
                if (invCalabaza > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (tipoSemilla == "esparrago")
            {
                if (invEsparrago > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public float CalcularCostoMensual()
        {
            float costoMensual = numEmpleados * sueldoMensual;
            return costoMensual;
        }
        public float CalcularUtilidadDisponible()
        {
            float costoMensual = CalcularCostoMensual();
            float utilidadDisp = dineroCaja - costoMensual;
            return utilidadDisp;
        }
        public void Sembrar()
        {
            Semilla semillaSeleccionada = null;
            MostrarInventario();
            Console.WriteLine("Estado actual de parcelas:");
            for (int fila = 0; fila < filasParc; fila++)
            {
                for (int columna = 0; columna < colsParc; columna++)
                {
                    if (parcelas[fila, columna].estaOcupada == true)
                    {
                        Console.Write("[O]");
                    }
                    else
                    {
                        Console.Write("[L]");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ingrese el tipo de semilla");
            string tipoSemilla = Console.ReadLine().ToLower();
            int filaSelec = LeerEntero("Ingrese la fila");
            int colSelec = LeerEntero("Ingrese la columna");
            int filaPos = filaSelec - 1;
            int colPos = colSelec - 1;
            if (filaPos>=0 &&  filaPos<filasParc && colPos>=0 && colPos<colsParc)
            {
                if (parcelas[filaPos, colPos].estaOcupada == false)
                {
                    bool disponible = VerificarDisponibilidad(tipoSemilla);
                    if (disponible == true)
                    {
                        bool encontrada = false;
                        for (int i = 0; i < listaSemillas.Length; i++)
                        {
                            if (listaSemillas[i].nombreSemilla == tipoSemilla)
                            {
                                semillaSeleccionada = listaSemillas[i];
                                encontrada = true;
                            }
                        }
                        if (encontrada==true)
                        {
                            disponible = VerificarDisponibilidad(tipoSemilla);
                            if (disponible==true)
                            {
                                parcelas[filaPos, colPos].SembrarSemilla(semillaSeleccionada);
                                DescontarSemilla(tipoSemilla);
                                Console.WriteLine("Semilla sembrada correctamente");
                            }
                            else
                            {
                                Console.WriteLine("No hay semillas disponibles de ese tipo");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tipo de semilla invalido");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay semillas disponibles de ese tipo");
                    }
                }
                else
                {
                    Console.WriteLine("La parcela ya esta ocupada");
                }
            }
            else
            {
                Console.WriteLine("La posicion ingresada no existe");
            }
        }
        public void ConsultarParcelas()
        {
            for (int fila = 0; fila < filasParc; fila++)
            {
                for (int columna = 0; columna < colsParc; columna++)
                {
                    if (parcelas[fila,columna].estaOcupada==true)
                    {
                        Console.Write("[O]");
                    }
                    else
                    {
                        Console.Write("[L]");
                    }
                }
                Console.WriteLine();
            }
            int filaSelec = LeerEntero("Ingrese la fila");
            int colSelec = LeerEntero("Ingrese la columna");
            int filaPos = filaSelec - 1;
            int colPos = colSelec - 1;
            if (filaPos>=0 && filaPos<filasParc && colPos>=0 && colPos<colsParc)
            {
                parcelas[filaPos, colPos].MostrarInfoParcela();              
            }
            else
            {
                Console.WriteLine("La posicion ingresada no existe");
            }
        }
        public void AvanzarMes()
        {
            mesesRestantes -=1;
            float pagoSalarios = CalcularCostoMensual();
            dineroCaja = dineroCaja - pagoSalarios;
            gastoSalarios = gastoSalarios + pagoSalarios;
            Console.WriteLine("Se avanzo un mes"+"\nPago: "+pagoSalarios+"\ncaja: "+dineroCaja);
            for (int fila = 0; fila < filasParc; fila++)
            {
                for (int columna = 0; columna < colsParc; columna++)
                {
                    if (parcelas[fila,columna].estaOcupada==true)
                    {
                        parcelas[fila, columna].AvanzarMes();
                        if (parcelas[fila,columna].EstaListaParaCosechar()==true)
                        {
                            float ingreso = parcelas[fila, columna].Cosechar();
                            dineroCaja = dineroCaja + ingreso;
                            ingresosCosecha = ingresosCosecha + ingreso;
                            Console.WriteLine("Parcela [" + (fila + 1) + "," + (columna + 1) + "] cosechada");
                            Console.WriteLine("Ingreso: "+ingreso);
                        }
                        else
                        {
                            Console.WriteLine("La parcela [" + (fila + 1) + "," + (columna + 1) + "] avanzo en su crecimiento");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Parcela [" + (fila + 1) + "," + (columna + 1) + "] vacia sin cambios");
                    }

                }
            }
        }
        public float CalcularInventarioProceso()
        {
            float inventarioProceso = 0;
            for (int fila = 0; fila < filasParc; fila++)
            {
                for (int columna = 0; columna < colsParc; columna++)
                {
                    if (parcelas[fila,columna].estaOcupada==true)
                    {
                        float ingresoEsperado = parcelas[fila, columna].semillaSembrada.ObtenerIngreso();
                        inventarioProceso += ingresoEsperado;
                    }
                }
            }
            return inventarioProceso;
        }
        public void GenerarReporteFinal()
        {
            float inventarioProceso = CalcularInventarioProceso();
            float utilidadFinal = capitalInicial + ingresosCosecha + inventarioProceso - gastoSalarios - gastoSemillas;
            Console.WriteLine("REPORTE FINAL" +"\ncapital inicial: "+capitalInicial+"\nIngresos de cosecha: "+ingresosCosecha+"\nInventario proceso: "+inventarioProceso+"\nGastos salarios: "+gastoSalarios+"\nGastos semillas: "+gastoSemillas+"\nUtilidad Final: "+utilidadFinal+ "\n Dinero en caja al finalizar: " + dineroCaja);
        }
        public bool VerificarFinSimulacion(int opcionMenu)
        {
            if (opcionMenu == 5)
            {
                return false;
            }
            else if(mesesRestantes<=0)
            {
                return false; 
            } else if (dineroCaja<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int LeerEntero(string mensaje) //Funcion para verificar entradas correctas, usando try catch y un do-while
        {
            int numero;
            bool valido = false;

            do
            {
                Console.WriteLine(mensaje);

                try
                {
                    numero = int.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("Error: debe ingresar un numero entero.");
                    numero = 0;
                }

            } while (valido == false);

            return numero;
        }

        public float LeerFloat(string mensaje) //Funcion para leer entradas usando try catch y do-while
        {
            float numero;
            bool valido = false;

            do
            {
                Console.WriteLine(mensaje);

                try
                {
                    numero = float.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("Error: debe ingresar un numero valido.");
                    numero = 0;
                }

            } while (valido == false);

            return numero;
        }
    }
    
}
