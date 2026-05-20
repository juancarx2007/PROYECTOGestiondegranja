using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_JCAA_1227526
{
    internal class Parcela //Creacion de clase parcela
    {
        int fila;
        int columna;
        public bool estaOcupada;
        public Semilla semillaSembrada;
        int mesesFaltantes;

        public Parcela(int fila, int columna, bool estaOcupada, Semilla semillaSembrada, int mesesFaltantes) { //constructor
            this.fila = fila;
            this.columna = columna;
            this.estaOcupada = estaOcupada;
            this.semillaSembrada = semillaSembrada;
            this.mesesFaltantes = mesesFaltantes;
        }
        //Metodos de la clase
        public void SembrarSemilla(Semilla semilla){
            semillaSembrada = semilla;
            estaOcupada = true;
            mesesFaltantes = semilla.ObtenerMesesCrecer();
}
        public void AvanzarMes()
        {
            if (estaOcupada==true)
            {
                mesesFaltantes -= 1;
            }
        }
        public bool EstaListaParaCosechar()
        {
            if (estaOcupada==true && mesesFaltantes<=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public float Cosechar()
        {
            float ingreso = semillaSembrada.ObtenerIngreso();
            LiberarParcela();
            return ingreso;
        }
        public void LiberarParcela()
        {
            estaOcupada=false;
            semillaSembrada = null;
            mesesFaltantes=0;
        }
        public void MostrarInfoParcela()
        {
            Console.WriteLine("La fila de la parcela es: " + (fila+1) + " La columna de la parcela es: " + (columna+1));
            if (estaOcupada==true)
            {
                Console.WriteLine("Parcela ocupada");
                semillaSembrada.MostrarInfoSemilla();
                Console.WriteLine("Meses faltantes: "+mesesFaltantes);
            }
            else
            {
                Console.WriteLine("Parcela libre\nIngreso esperado Q0.00");
            }
        }
    }

}
