using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Funciones
{
    public class CreaTicketCajaEgreso
    {
        string ticket = "";
        string parte1, parte2;
        public string impresora = "Generic / Text Only"; // nombre exacto de la impresora como esta en el panel de control - By ERojas
        int max, cort;

        public void LineasGuion()
        {
            ticket = "----------------------------------------\n";   // agrega lineas separadoras -
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasAsterisco()
        {
            ticket = "****************************************\n";   // agrega lineas separadoras *
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasIgual()
        {
            ticket = "========================================\n";   // agrega lineas separadoras =
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasTotales()
        {
            ticket = "                             -----------\n"; ;   // agrega lineas de total
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void LineasTotalesIgual()
        {
            ticket = "                             ===========\n"; ;   // agrega lineas de total
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
        }
        public void EncabezadoVenta()
        {
            ticket = "Cant    Articulo       P.Unit    Importe\n";   // agrega lineas de  encabezados
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoIzquierda(string par1)                          // agrega texto a la izquierda
        {
            max = par1.Length;
            if (max > 42)                                 // **********
            {
                cort = max - 42;
                parte1 = par1.Remove(42, cort);        // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoIzquierdaNLineas(string par1)                          // agrega texto a la izquierda
        {
            ticket = par1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoDerecha(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 42)                                 // **********
            {
                cort = max - 42;
                parte1 = par1.Remove(42, cort);           // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = 42 - par1.Length;                     // obtiene la cantidad de espacios para llegar a 40
            for (int i = 0; i < max; i++)
            {
                ticket += " ";                          // agrega espacios para alinear a la derecha
            }
            ticket += parte1 + "\n";                    //Agrega el texto
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoCentro(string par1)
        {
            ticket = "";
            max = par1.Length;
            if (max > 42)                                 // **********
            {
                cort = max - 42;
                parte1 = par1.Remove(42, cort);          // si es mayor que 40 caracteres, lo corta
            }
            else { parte1 = par1; }                      // **********
            max = (int)(42 - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios antes del texto a centrar
            }                                            // **********
            ticket += parte1 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void TextoExtremos(string par1, string par2)
        {
            max = par1.Length;
            if (max > 18)                                 // **********
            {
                cort = max - 18;
                parte1 = par1.Remove(18, cort);          // si par1 es mayor que 18 lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1;                             // agrega el primer parametro
            max = par2.Length;
            if (max > 18)                                 // **********
            {
                cort = max - 18;
                parte2 = par2.Remove(18, cort);          // si par2 es mayor que 18 lo corta
            }
            else { parte2 = par2; }
            max = 40 - (parte1.Length + parte2.Length);
            for (int i = 0; i < max; i++)                 // **********
            {
                ticket += " ";                            // Agrega espacios para poner par2 al final
            }                                             // **********
            ticket += parte2 + "\n";                     // agrega el segundo parametro al final
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }
        public void AgregaTotales(string par1, double total)
        {
            max = par1.Length;
            if (max > 25)                                 // **********
            {
                cort = max - 25;
                parte1 = par1.Remove(25, cort);          // si es mayor que 25 lo corta
            }
            else { parte1 = par1; }                      // **********
            ticket = parte1;
            parte2 = total.ToString("c");
            max = 40 - (parte1.Length + parte2.Length);
            for (int i = 0; i < max; i++)                // **********
            {
                ticket += " ";                           // Agrega espacios para poner el valor de moneda al final
            }                                            // **********
            ticket += parte2 + "\n";
            RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        }

        //public void AgregaArticulo(string par1, int cant, double precio, double total)
        //{
        //    if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && total.ToString("c").Length <= 11) // valida que cant precio y total esten dentro de rango
        //    {
        //        max = par1.Length;
        //        if (max > 16)                                 // **********
        //        {
        //            cort = max - 16;
        //            parte1 = par1.Remove(16, cort);          // corta a 16 la descripcion del articulo
        //        }
        //        else { parte1 = par1; }                      // **********
        //        ticket = parte1;                             // agrega articulo
        //        max = (3 - cant.ToString().Length) + (16 - parte1.Length);
        //        for (int i = 0; i < max; i++)                // **********
        //        {
        //            ticket += " ";                           // Agrega espacios para poner el valor de cantidad
        //        }
        //        ticket += cant.ToString();                   // agrega cantidad
        //        max = 10 - (precio.ToString("c").Length);
        //        for (int i = 0; i < max; i++)                // **********
        //        {
        //            ticket += " ";                           // Agrega espacios
        //        }                                            // **********
        //        ticket += precio.ToString("c"); // agrega precio
        //        max = 11 - (total.ToString().Length);
        //        for (int i = 0; i < max; i++)                // **********
        //        {
        //            ticket += " ";                           // Agrega espacios
        //        }                                            // **********
        //        ticket += total.ToString("c") + "\n"; // agrega precio
        //        RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
        //    }
        //    else
        //    {
        //        MessageBox.Show("Valores fuera de rango");
        //        RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
        //    }
        //}

        public void AgregaArticulo(string par1, int cant, double precio, double total)
        {
            if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && total.ToString("c").Length <= 11) // valida que cant precio y total esten dentro de rango
            {
                max = par1.Length;
                if (max > 16)                                 // **********
                {
                    cort = max - 16;
                    parte1 = par1.Remove(16, cort);          // corta a 16 la descripcion del articulo
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;                             // agrega articulo
                max = (3 - cant.ToString().Length) + (16 - parte1.Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios para poner el valor de cantidad
                }
                ticket += cant.ToString();                   // agrega cantidad
                max = 10 - (precio.ToString("c").Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios
                }                                            // **********
                ticket += precio.ToString("c"); // agrega precio
                max = 11 - (total.ToString().Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios
                }                                            // **********
                ticket += total.ToString("c") + "\n"; // agrega precio
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            else
            {
                MessageBox.Show("Valores fuera de rango");
                RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            }
        }
        public void AgregaArticuloCodigo(int cant, string unidad, string codigo)
        {
            if (cant.ToString().Length <= 4) // valida que cant precio y total esten dentro de rango
            {
                max = cant.ToString().Length;
                if (max > 4)                                 // **********
                {
                    cort = max - 4;
                    parte1 = cant.ToString().Remove(4, cort);          // corta a 16 la descripcion del articulo
                }
                else { parte1 = cant.ToString(); }                      // **********
                ticket = parte1;                             // agrega cantidad
                max = (3 - unidad.Length) + (4 - parte1.Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios para poner el valor de cantidad
                }
                ticket += unidad.ToString() + " ";                   // agrega unidad
                max = 9 - (codigo.Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios
                }                                            // **********
                ticket += codigo.ToString() + "\n"; // agrega Codigo
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            else
            {
                MessageBox.Show("Valores fuera de rango");
                RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            }
        }
        public void AgregaArticuloDetalle(string par1, double precio, double total)
        {
            if (precio.ToString().Length <= 10 && total.ToString().Length <= 11) // valida que cant precio y total esten dentro de rango
            {
                max = par1.Length;
                if (max > 19)                                 // **********
                {
                    cort = max - 19;
                    parte1 = par1.Remove(19, cort);          // corta a 16 la descripcion del articulo
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;                             // agrega articulo
                max = 10 - (precio.ToString().Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios
                }                                            // **********
                ticket += precio.ToString(); // agrega precio
                max = 11 - (total.ToString().Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios
                }                                            // **********
                ticket += total.ToString() + "\n"; // agrega precio
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            else
            {
                MessageBox.Show("Valores fuera de rango");
                RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
            }
        }

        public void CortaTicket()
        {
            string corte = "\x1B" + "m";                  // caracteres de corte
            string avance = "\x1B" + "d" + "\x09";        // avanza 9 renglones
            RawPrinterHelper.SendStringToPrinter(impresora, avance); // avanza
            RawPrinterHelper.SendStringToPrinter(impresora, corte); // corta
        }
        public void AbreCajon()
        {
            string cajon0 = "\x1B" + "p" + "\x00" + "\x0F" + "\x96";                  // caracteres de apertura cajon 0
            //string cajon1 = "\x1B" + "p" + "\x01" + "\x0F" + "\x96";                 // caracteres de apertura cajon 1
            RawPrinterHelper.SendStringToPrinter(impresora, cajon0); // abre cajon0
            //RawPrinterHelper.SendStringToPrinter(impresora, cajon1); // abre cajon1
        }
    }
}
