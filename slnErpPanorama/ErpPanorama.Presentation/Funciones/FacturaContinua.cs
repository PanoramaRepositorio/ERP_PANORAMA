using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace ErpPanorama.Presentation.Funciones
{
    public class FacturaContinua
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;

        int count = 0;

        int maxChar = 75; //35 -- 32 ok
        int maxCharDescription = 45;//20

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "Arial Narrow";
        int fontSize = 9;

        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;

        //public Ticket()
        //{

        //}

        public Image HeaderImageFactura
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxCharFactura
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescriptionFactura
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSizeFactura
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontNameFactura
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLineFactura(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLineFactura(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItemFactura(string cantidad, string item, string price)
        {
            OrderItemFactura newItem = new OrderItemFactura('?');
            items.Add(newItem.GenerateItemFactura(cantidad, item, price));
        }

        public void AddTotalFactura(string name, string price)
        {
            OrderTotalFactura newTotal = new OrderTotalFactura('?');
            totales.Add(newTotal.GenerateTotalFactura(name, price));
        }

        public void AddFooterLineFactura(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "="; // LINEAS By eder
            return dotted;
        }

        public bool PrinterExistsFactura(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicketFactura(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }

        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImage();
            DrawHeader();
            DrawSubHeader();
            DrawItems();
            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImageFactura.Dispose();
                headerImage.Dispose();
            }
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58) * 15;
                    imageHeight = (int)Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;

                    line = DottedLine();

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawItems()
        {
            OrderItemFactura ordIt = new OrderItemFactura('?');

            gfx.DrawString("CANT  DESCRIPCION                     IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();

            foreach (string item in items)
            {
                line = ordIt.GetItemCantidadFactura(item);

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                line = ordIt.GetItemPriceFactura(item);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                string name = ordIt.GetItemNameFactura(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemNameFactura(item);
                        gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemNameFactura(item);
                    gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("      " + ordIt.GetItemNameFactura(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }

            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotalFactura ordTot = new OrderTotalFactura('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidadFactura(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalNameFactura(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
        }
    }

    public class OrderItemFactura
    {
        char[] delimitador = new char[] { '?' };

        public OrderItemFactura(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidadFactura(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemNameFactura(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPriceFactura(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItemFactura(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }
    }

    public class OrderTotalFactura
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotalFactura(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalNameFactura(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidadFactura(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotalFactura(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}
