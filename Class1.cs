using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_JCAA_1227526
{
    internal class Semilla //clase de semilla
    {
        public string nombreSemilla;
        int mesesCrecer;
        float costoSemilla;
        float ingresoCosecha;
        public Semilla(string nombreSemilla, int mesesCrecer, float costoSemilla, float ingresoCosecha) //Constructor de la clase
        {
            this.nombreSemilla = nombreSemilla;
            this.mesesCrecer = mesesCrecer;
            this.costoSemilla = costoSemilla;
            this.ingresoCosecha = ingresoCosecha;
        }
        //Metodos de la clase
        public void MostrarInfoSemilla()
        {
            Console.WriteLine();
            Console.WriteLine("La informacion es: \nNombre semilla: "+nombreSemilla+"\nMeses para crecer: "+mesesCrecer+"\n Costo de semilla: "+costoSemilla+"\nIngreso de cosecha: "+ingresoCosecha);
            Console.WriteLine();
        }
        public float ObtenerCosto()
        {
            return costoSemilla;
        }
        public float ObtenerIngreso()
        {
            return ingresoCosecha;
        }
        public int ObtenerMesesCrecer()
        {
            return mesesCrecer;
        }

    }
}
