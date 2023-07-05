using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace ErpPanorama.Presentation.Funciones
{
    public class BoletaContinua
    {
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;

        int count = 0;

        int maxChar = 150; //35 -- 32 ok
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

        public Image HeaderImageBoleta
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxCharBoleta
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescriptionBoleta
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSizeBoleta
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontNameBoleta
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLineBoleta(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLineBoleta(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItemBoleta(string cantidad, string item, string price)
        {
            OrderItemBoleta newItem = new OrderItemBoleta('?');
            items.Add(newItem.GenerateItemBoleta(cantidad, item, price));
        }

        public void AddTotalBoleta(string name, string price)
        {
            OrderTotalBoleta newTotal = new OrderTotalBoleta('?');
            totales.Add(newTotal.GenerateTotalBoleta(name, price));
        }

        public void AddFooterLineBoleta(string line)
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

        public bool PrinterExistsBoleta(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicketBoleta(string impresora)
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
                HeaderImageBoleta.Dispose();
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
            OrderItemBoleta ordIt = new OrderItemBoleta('?');

            gfx.DrawString("CANT  DESCRIPCION                     IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();

            foreach (string item in items)
            {
                line = ordIt.GetItemCantidadBoleta(item);

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                line = ordIt.GetItemPriceBoleta(item);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                string name = ordIt.GetItemNameBoleta(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemNameBoleta(item);
                        gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemNameBoleta(item);
                    gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("      " + ordIt.GetItemNameBoleta(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());

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
            OrderTotalBoleta ordTot = new OrderTotalBoleta('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidadBoleta(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalNameBoleta(total);
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

    public class OrderItemBoleta
    {
        char[] delimitador = new char[] { '?' };

        public OrderItemBoleta(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidadBoleta(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemNameBoleta(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPriceBoleta(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItemBoleta(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }
    }

    public class OrderTotalBoleta
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotalBoleta(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalNameBoleta(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidadBoleta(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotalBoleta(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}
