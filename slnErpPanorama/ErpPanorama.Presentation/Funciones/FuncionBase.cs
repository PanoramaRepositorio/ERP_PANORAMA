using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;

namespace ErpPanorama.Presentation.Funciones
{
    public class FuncionBase
    {

        public byte[] Image2Bytes(Image img)
        {
            if (img != null)
            {
                string sTemp = Path.GetTempFileName();
                FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                fs.Position = 0;
                //
                int imgLength = Convert.ToInt32(fs.Length);
                byte[] bytes = new byte[imgLength];
                fs.Read(bytes, 0, imgLength);
                fs.Close();
                return bytes;
            }
            else
            { return null; }
        }

        public Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

        public Image GetImageFromByteArray(byte[] picData)
        {
            if (picData == null) return null;

            // is this is an embedded object?
            int bmData = (picData[0] == 0x15 && picData[1] == 0x1c) ? 78 : 0;

            // load the picture
            Image img = null;
            try
            {
                MemoryStream ms = new MemoryStream(picData, bmData, picData.Length - bmData);
                img = Image.FromStream(ms);
            }
            catch { }

            // return what we got
            return img;
        }

        public string GetXML(DataTable table)
        {
            table.TableName = "Table";
            StringBuilder sb = new StringBuilder();
            StringWriter sr = new StringWriter(sb);
            XmlTextWriter tw = new XmlTextWriter(sr);
            table.WriteXml(tw);

            tw.Flush();
            tw.Close();
            sr.Flush();
            sr.Dispose();
            sr.Close();
            string result = sb.ToString();
            return result;
        }

        public string GetXML(DataSet dataSet)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sr = new StringWriter(sb);
            XmlTextWriter tw = new XmlTextWriter(sr);
            dataSet.WriteXml(tw);

            tw.Flush();
            tw.Close();
            sr.Flush();
            sr.Dispose();
            sr.Close();
            string result = sb.ToString();
            return result;
        }

        public DataTable GetMonths()
        {
            DataTable dt = new DataTable();
            DataColumn dc;

            dc = new DataColumn("Month", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("MonthName", typeof(string));
            dt.Columns.Add(dc);

            DataRow dr;

            dr = dt.NewRow();
            dr["Month"] = 1;
            dr["MonthName"] = "Enero";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 2;
            dr["MonthName"] = "Febrero";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 3;
            dr["MonthName"] = "Marzo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 4;
            dr["MonthName"] = "Abril";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 5;
            dr["MonthName"] = "Mayo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 6;
            dr["MonthName"] = "Junio";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 7;
            dr["MonthName"] = "Julio";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 8;
            dr["MonthName"] = "Agosto";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 9;
            dr["MonthName"] = "Septiembre";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 10;
            dr["MonthName"] = "Octubre";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 11;
            dr["MonthName"] = "Noviembre";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Month"] = 12;
            dr["MonthName"] = "Diciembre";
            dt.Rows.Add(dr);

            return dt;
        }

        public string GetMonthName(int Month)
        {
            string result = string.Empty;

            switch (Month)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break;
            }

            return result;
        }

        public static string AgregarCaracter(string cadena, string caracter, int digitos)
        {
            string nuevo = "";
            for (int i = 0; i < digitos; i++)
            {
                if (i == 0)
                    nuevo = caracter + cadena;
                else
                    nuevo = caracter + nuevo;
            }
            return nuevo.Substring(nuevo.Length - digitos, digitos);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {

            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);

            }

            return tb;
        }

        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {

                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        public static string Enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;
            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }
            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }
            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private static string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }
            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

    }
}
