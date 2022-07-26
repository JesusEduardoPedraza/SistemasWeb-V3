using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace SistemasWeb.Library
{
    public class LPaginador<T>
    {
        //cantidad de resultados por página 
        private int pagi_cuantos = 1;
        //cantidad de enlaces que se mostrarán como máximo en la barra de navegación 
        private int pagi_nav_num_enlaces = 3;
        private int pagi_actual;
        //definimos qué irá en el enlace a la página anterior 
        private String pagi_nav_anterior = " &laquo; Anterior ";
        //definimos qué irá en el enlace a la página siguiente 
        private String pagi_nav_siguiente = " Siguiente &raquo; ";
        //definimos qué irá en el enlace a la página siguiente 
        private String pagi_nav_primera = " &laquo; Primero ";
        private String pagi_nav_ultima = " Último &raquo; ";
        private String pagi_navegacion = null;

        public object[] paginador(List<T> table, int pagina, int Registros, String area, String controller,
            String action, String host)
        {
            if (Registros > 0)
            {
                pagi_cuantos = Registros;
            }
            if (pagina.Equals(0))
            {
                // Si no se ha hecho click a ninguna página específica 
                // O sea si es la primera vez que se ejecuta el script 
                // pagi_actual es la página actual-->será por defecto la primera. 
                pagi_actual = 1;
            }
            else
            {
                // Si se "pidió" una página específica: 
                // La página actual será la que se pidió. 
                pagi_actual = pagina;
            }
            int pagi_totalReg = table.Count;
            int pagi_totalRegs = pagi_totalReg;
            if ((pagi_totalReg % pagi_cuantos) > 0)
            {
                pagi_totalRegs += 2;
            }
            int pagi_totalPags = pagi_totalRegs / pagi_cuantos;
            if (pagi_actual != 1)
            {
                // Si no estamos en la página 1. Ponemos el enlace "primera" 
                int pagi_url = 1; //será el número de página al que enlazamos 
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action
                    + "?id=" + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_primera + "</a>";

                // Si no estamos en la página 1. Ponemos el enlace "anterior" 
                pagi_url = pagi_actual - 1; //será el número de página al que enlazamos 
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action
                    + "?id=" + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_anterior + " </a>";
            }
            // Si se definió la variable pagi_nav_num_enlaces 
            // Calculamos el intervalo para restar y sumar a partir de la página actual 
            double valor2 = (pagi_nav_num_enlaces / 2);
            int pagi_nav_intervalo = Convert.ToInt16(Math.Round(valor2));
            // Calculamos desde qué número de página se mostrará 
            int pagi_nav_desde = pagi_actual - pagi_nav_intervalo;
            // Calculamos hasta qué número de página se mostrará 
            int pagi_nav_hasta = pagi_actual + pagi_nav_intervalo;


        }

    }
}
