using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{
    public class TareoPersonalBL
    {
        public DataTable ObtenerListaTareo(int Periodo, int Mes, int IdPersona, int TipoReporte)
        {
            TareoPersonalDL objDL = new TareoPersonalDL();
            DataTable dtTMP = new DataTable();

            DataColumn _dc;

            _dc = new DataColumn("Nuevo", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("ApeNom", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("Tipo", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("1", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("2", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("3", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("4", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("5", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("6", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("7", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("8", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("9", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("10", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("11", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("12", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("13", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("14", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("15", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("16", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("17", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("18", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("19", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("20", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("21", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("22", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("23", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("24", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("25", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("26", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("27", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("28", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("29", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("30", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("31", typeof(string));
            dtTMP.Columns.Add(_dc);

            foreach (DataRow dRow in objDL.ObtenerListaTareo(Periodo, Mes, IdPersona, TipoReporte).Rows)
            {
                DataRow newRow = dtTMP.NewRow();
                newRow["ApeNom"] = dRow["ApeNom"].ToString();
                newRow["Tipo"] = "";
                if (Convert.ToInt32(dRow["1"].ToString()) > 0)
                    newRow["1"] = "A";
                else
                    newRow["1"] = "F";
                if (Convert.ToInt32(dRow["2"].ToString()) > 0)
                    newRow["2"] = "A";
                else
                    newRow["2"] = "F";
                if (Convert.ToInt32(dRow["3"].ToString()) > 0)
                    newRow["3"] = "A";
                else
                    newRow["3"] = "F";
                if (Convert.ToInt32(dRow["4"].ToString()) > 0)
                    newRow["4"] = "A";
                else
                    newRow["4"] = "F";
                if (Convert.ToInt32(dRow["5"].ToString()) > 0)
                    newRow["5"] = "A";
                else
                    newRow["5"] = "F";
                if (Convert.ToInt32(dRow["6"].ToString()) > 0)
                    newRow["6"] = "A";
                else
                    newRow["6"] = "F";
                if (Convert.ToInt32(dRow["7"].ToString()) > 0)
                    newRow["7"] = "A";
                else
                    newRow["7"] = "F";
                if (Convert.ToInt32(dRow["8"].ToString()) > 0)
                    newRow["8"] = "A";
                else
                    newRow["8"] = "F";
                if (Convert.ToInt32(dRow["9"].ToString()) > 0)
                    newRow["9"] = "A";
                else
                    newRow["9"] = "F";
                if (Convert.ToInt32(dRow["10"].ToString()) > 0)
                    newRow["10"] = "A";
                else
                    newRow["10"] = "F";
                if (Convert.ToInt32(dRow["11"].ToString()) > 0)
                    newRow["11"] = "A";
                else
                    newRow["11"] = "F";
                if (Convert.ToInt32(dRow["12"].ToString()) > 0)
                    newRow["12"] = "A";
                else
                    newRow["12"] = "F";
                if (Convert.ToInt32(dRow["13"].ToString()) > 0)
                    newRow["13"] = "A";
                else
                    newRow["13"] = "F";
                if (Convert.ToInt32(dRow["14"].ToString()) > 0)
                    newRow["14"] = "A";
                else
                    newRow["14"] = "F";
                if (Convert.ToInt32(dRow["15"].ToString()) > 0)
                    newRow["15"] = "A";
                else
                    newRow["15"] = "F";
                if (Convert.ToInt32(dRow["16"].ToString()) > 0)
                    newRow["16"] = "A";
                else
                    newRow["16"] = "F";
                if (Convert.ToInt32(dRow["17"].ToString()) > 0)
                    newRow["17"] = "A";
                else
                    newRow["17"] = "F";
                if (Convert.ToInt32(dRow["18"].ToString()) > 0)
                    newRow["18"] = "A";
                else
                    newRow["18"] = "F";
                if (Convert.ToInt32(dRow["19"].ToString()) > 0)
                    newRow["19"] = "A";
                else
                    newRow["19"] = "F";
                if (Convert.ToInt32(dRow["20"].ToString()) > 0)
                    newRow["20"] = "A";
                else
                    newRow["20"] = "F";
                if (Convert.ToInt32(dRow["21"].ToString()) > 0)
                    newRow["21"] = "A";
                else
                    newRow["21"] = "F";
                if (Convert.ToInt32(dRow["22"].ToString()) > 0)
                    newRow["22"] = "A";
                else
                    newRow["22"] = "F";
                if (Convert.ToInt32(dRow["23"].ToString()) > 0)
                    newRow["23"] = "A";
                else
                    newRow["23"] = "F";
                if (Convert.ToInt32(dRow["24"].ToString()) > 0)
                    newRow["24"] = "A";
                else
                    newRow["24"] = "F";
                if (Convert.ToInt32(dRow["25"].ToString()) > 0)
                    newRow["25"] = "A";
                else
                    newRow["25"] = "F";
                if (Convert.ToInt32(dRow["26"].ToString()) > 0)
                    newRow["26"] = "A";
                else
                    newRow["26"] = "F";
                if (Convert.ToInt32(dRow["27"].ToString()) > 0)
                    newRow["27"] = "A";
                else
                    newRow["27"] = "F";
                if (Convert.ToInt32(dRow["28"].ToString()) > 0)
                    newRow["28"] = "A";
                else
                    newRow["28"] = "F";
                if (Convert.ToInt32(dRow["29"].ToString()) > 0)
                    newRow["29"] = "A";
                else
                    newRow["29"] = "F";
                if (Convert.ToInt32(dRow["30"].ToString()) > 0)
                    newRow["30"] = "A";
                else
                    newRow["30"] = "F";
                if (Convert.ToInt32(dRow["31"].ToString()) > 0)
                    newRow["31"] = "A";
                else
                    newRow["31"] = "F";
                
                dtTMP.Rows.Add(newRow);
            }

            return dtTMP;
        }

        public DataTable ObtenerListaTareoCalculado(int Periodo, int Mes, int IdPersona, int TipoReporte)
        {
            TareoPersonalDL objDL = new TareoPersonalDL();
            DataTable dtTMP = new DataTable();

            DataColumn _dc;

            _dc = new DataColumn("Nuevo", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("FlagApoyo", typeof(bool));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("DescCargo", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("DescTienda", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("DescArea", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("Descanso", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("Tipo", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("Dni", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("ApeNom", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("1", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("2", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("3", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("4", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("5", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("6", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("7", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("8", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("9", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("10", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("11", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("12", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("13", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("14", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("15", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("16", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("17", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("18", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("19", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("20", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("21", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("22", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("23", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("24", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("25", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("26", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("27", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("28", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("29", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("30", typeof(string));
            dtTMP.Columns.Add(_dc);

            _dc = new DataColumn("31", typeof(string));
            dtTMP.Columns.Add(_dc);


            _dc = new DataColumn("TotalF", typeof(int));
            dtTMP.Columns.Add(_dc);
            _dc = new DataColumn("TotalFI", typeof(int));
            dtTMP.Columns.Add(_dc);
            _dc = new DataColumn("TotalDM", typeof(int));
            dtTMP.Columns.Add(_dc);
            _dc = new DataColumn("TotalLC", typeof(int));
            dtTMP.Columns.Add(_dc);


            foreach (DataRow dRow in objDL.ObtenerListaTareoCalculado(Periodo, Mes, IdPersona, TipoReporte).Rows)
            {
                int TotalF = 0;
                int TotalFI = 0;
                int TotalDM = 0;
                int TotalLC = 0;
                string Tipo = "F";//Falta
                DataRow newRow = dtTMP.NewRow();
                newRow["ApeNom"] = dRow["ApeNom"].ToString();
                newRow["Tipo"] = dRow["Tipo"].ToString();
                newRow["Dni"] = dRow["Dni"].ToString();

                newRow["DescTienda"] = dRow["DescTienda"].ToString();
                newRow["DescArea"] = dRow["DescArea"].ToString();
                newRow["DescCargo"] = dRow["DescCargo"].ToString();
                newRow["Descanso"] = dRow["Descanso"].ToString();
                newRow["FlagApoyo"] = dRow["FlagApoyo"].ToString();

                if (dRow["1"].ToString() != "")
                {
                    newRow["1"] = dRow["1"].ToString();
                    Tipo = dRow["1"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(1 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["1"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["2"].ToString() != "")
                {
                    newRow["2"] = dRow["2"].ToString();
                    Tipo = dRow["2"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(2 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["2"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["3"].ToString() != "")
                {
                    newRow["3"] = dRow["3"].ToString();
                    Tipo = dRow["3"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(3 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["3"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["4"].ToString() != "")
                {
                    newRow["4"] = dRow["4"].ToString();
                    Tipo = dRow["4"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(4 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["4"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["5"].ToString() != "")
                {
                    newRow["5"] = dRow["5"].ToString();
                    Tipo = dRow["5"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(5 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["5"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["6"].ToString() != "")
                {
                    newRow["6"] = dRow["6"].ToString();
                    Tipo = dRow["6"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(6 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["6"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["7"].ToString() != "")
                {
                    newRow["7"] = dRow["7"].ToString();
                    Tipo = dRow["7"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(7 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["7"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["8"].ToString() != "")
                {
                    newRow["8"] = dRow["8"].ToString();
                    Tipo = dRow["8"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(8 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["8"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["9"].ToString() != "")
                {
                    newRow["9"] = dRow["9"].ToString();
                    Tipo = dRow["9"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(9 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["9"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["10"].ToString() != "")
                {
                    newRow["10"] = dRow["10"].ToString();
                    Tipo = dRow["10"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(10 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["10"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["11"].ToString() != "")
                {
                    newRow["11"] = dRow["11"].ToString();
                    Tipo = dRow["11"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(11 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["11"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["12"].ToString() != "")
                {
                    newRow["12"] = dRow["12"].ToString();
                    Tipo = dRow["12"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(12 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["12"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["13"].ToString() != "")
                {
                    newRow["13"] = dRow["13"].ToString();
                    Tipo = dRow["13"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(13 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["13"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["14"].ToString() != "")
                {
                    newRow["14"] = dRow["14"].ToString();
                    Tipo = dRow["14"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(14 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["14"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["15"].ToString() != "")
                {
                    newRow["15"] = dRow["15"].ToString();
                    Tipo = dRow["15"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(15 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["15"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["16"].ToString() != "")
                {
                    newRow["16"] = dRow["16"].ToString();
                    Tipo = dRow["16"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(16 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["16"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["17"].ToString() != "")
                {
                    newRow["17"] = dRow["17"].ToString();
                    Tipo = dRow["17"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(17 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["17"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["18"].ToString() != "")
                {
                    newRow["18"] = dRow["18"].ToString();
                    Tipo = dRow["18"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(18 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["18"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["19"].ToString() != "")
                {
                    newRow["19"] = dRow["19"].ToString();
                    Tipo = dRow["19"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(19 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["19"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["20"].ToString() != "")
                {
                    newRow["20"] = dRow["20"].ToString();
                    Tipo = dRow["20"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(20 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["20"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["21"].ToString() != "")
                {
                    newRow["21"] = dRow["21"].ToString();
                    Tipo = dRow["21"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(21 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["21"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["22"].ToString() != "")
                {
                    newRow["22"] = dRow["22"].ToString();
                    Tipo = dRow["22"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(22 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["22"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["23"].ToString() != "")
                {
                    newRow["23"] = dRow["23"].ToString();
                    Tipo = dRow["23"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(23 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["23"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["24"].ToString() != "")
                {
                    newRow["24"] = dRow["24"].ToString();
                    Tipo = dRow["24"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(24 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["24"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["25"].ToString() != "")
                {
                    newRow["25"] = dRow["25"].ToString();
                    Tipo = dRow["25"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(25 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["25"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["26"].ToString() != "")
                {
                    newRow["26"] = dRow["26"].ToString();
                    Tipo = dRow["26"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(26 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["26"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["27"].ToString() != "")
                {
                    newRow["27"] = dRow["27"].ToString();
                    Tipo = dRow["27"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(27 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["27"] = "F";
                    TotalF = TotalF + 1;
                }
                if (dRow["28"].ToString() != "")
                {
                    newRow["28"] = dRow["28"].ToString();
                    Tipo = dRow["28"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                }
                else
                {
                    if (Convert.ToDateTime(28 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                        newRow["28"] = "F";
                    TotalF = TotalF + 1;
                }
                //if (dRow["29"].ToString() != "")
                //{
                //    newRow["29"] = dRow["29"].ToString();
                //    Tipo = dRow["29"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                //}
                //else
                //{
                //    if (Periodo % 4 == 0 && Periodo % 100 != 0 || Periodo % 400 == 0) //Bisiesto
                //    if (Convert.ToDateTime(29 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                //        newRow["29"] = "F";
                //    TotalF = TotalF + 1;
                //}
                //if (dRow["30"].ToString() != "")
                //{
                //    newRow["30"] = dRow["30"].ToString();
                //    Tipo = dRow["30"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                //}
                //else
                //{
                //    if (Mes != 2)
                //    if (Convert.ToDateTime(30 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                //        newRow["30"] = "F";
                //    TotalF = TotalF + 1;
                //}
                //if (dRow["31"].ToString() != "")
                //{
                //    newRow["31"] = dRow["31"].ToString();
                //    Tipo = dRow["31"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                //}
                //else
                //{
                //    if (Mes == 1 || Mes == 3 || Mes == 5 || Mes == 7 || Mes == 8 || Mes == 10 || Mes == 12)
                //    if (Convert.ToDateTime(31 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                //        newRow["31"] = "F";
                //    TotalF = TotalF + 1;
                //}

                //modified by Change Mes
                //29DIAS
                if (Periodo % 4 == 0 && Periodo % 100 != 0 || Periodo % 400 == 0) //Bisiesto
                {
                    if (dRow["29"].ToString() != "")
                    {
                        newRow["29"] = dRow["29"].ToString();
                        Tipo = dRow["29"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(29 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["29"] = "F";
                        TotalF = TotalF + 1;
                    }
                }
                //30DIAS
                if (Mes == 4 || Mes == 6 || Mes == 9 || Mes == 11)
                {
                    if (dRow["29"].ToString() != "")
                    {
                        newRow["29"] = dRow["29"].ToString();
                        Tipo = dRow["29"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(29 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["29"] = "F";
                        TotalF = TotalF + 1;
                    }
                    if (dRow["30"].ToString() != "")
                    {
                        newRow["30"] = dRow["30"].ToString();
                        Tipo = dRow["30"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(30 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["30"] = "F";
                        TotalF = TotalF + 1;
                    }
                }


                //31DIAS
                if (Mes == 1 || Mes == 3 || Mes == 5 || Mes == 7 || Mes == 8 || Mes == 10 || Mes == 12)
                {
                    if (dRow["29"].ToString() != "")
                    {
                        newRow["29"] = dRow["29"].ToString();
                        Tipo = dRow["29"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(29 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["29"] = "F";
                        TotalF = TotalF + 1;
                    }
                    if (dRow["30"].ToString() != "")
                    {
                        newRow["30"] = dRow["30"].ToString();
                        Tipo = dRow["30"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(30 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["30"] = "F";
                        TotalF = TotalF + 1;
                    }
                    if (dRow["31"].ToString() != "")
                    {
                        newRow["31"] = dRow["31"].ToString();
                        Tipo = dRow["31"].ToString(); if (Tipo == "FI") TotalFI = TotalFI + 1; else if (Tipo == "DM") TotalDM = TotalDM + 1; else if (Tipo == "LC") TotalLC = TotalLC + 1;
                    }
                    else
                    {
                        if (Convert.ToDateTime(31 + "/" + Mes + "/" + Periodo) <= DateTime.Now)
                            newRow["31"] = "F";
                        TotalF = TotalF + 1;
                    }
                }


                //MESES
                //29DIAS = if (Periodo % 4 == 0 && Periodo % 100 != 0 || Periodo % 400 == 0) //Bisiesto
                //30DIAS = if (Mes != 2)
                //30DIAS = if (Mes == 1 || Mes == 3 || Mes == 4 || Mes == 5 || Mes == 6 || Mes == 7 || Mes == 8 || Mes == 9 || Mes == 10 || Mes == 11 || Mes == 12)
                //31DIAS = if(Mes == 1||Mes ==3||Mes ==5||Mes==7||Mes==8||Mes ==10||Mes==12)


                //Totales
                newRow["TotalF"] = TotalF.ToString();
                newRow["TotalFI"] = TotalFI.ToString();
                newRow["TotalDM"] = TotalDM.ToString(); ;
                newRow["TotalLC"] = TotalLC.ToString();


                dtTMP.Rows.Add(newRow);
            }

            return dtTMP;
        }
    }
}

