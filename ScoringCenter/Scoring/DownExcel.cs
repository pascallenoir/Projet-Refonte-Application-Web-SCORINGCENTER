using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ScoringCenter.Scoring
{
    public class DownExcel
    {
        static string Type_anafi;
        Scoringws service = new Scoringws();
        double[] TabLOTECART = new double[3];
        double[] TabLOTECART1 = new double[3];
        public string formatMillier(string str)
        {

            char[] toto1 = str.ToCharArray();
            var toto2 = "";
            foreach (var t in toto1)
            {
                toto2 = t + toto2;
            }
            str = "";
            int cpt = 0;
            toto1 = toto2.ToCharArray();
            foreach (var t in toto1)
            {
                if (cpt == 3)
                {
                    str = t + " " + str;
                    cpt = 1;
                }
                else
                {
                    str = t + str;
                    cpt++;
                }
            }
            return str;
        }
        public void BilanActifs(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
                if (liste_annee.Count != 0)
                {
                    wtr.Write("Actifs;");
                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                            }
                            i++;
                        }
                    }
                    wtr.WriteLine();
                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");



                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A")
                        {
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                             || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X5" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX34" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX33" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BXA")
                                {

                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "")+";");
                                    int p = 0;
                                    var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur3.Count) - 3;
                                    foreach (var l in liste_valeur3)
                                    {

                                        if (liste_valeur3.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                                p++;
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                            // TabLOTA[p] = l.VALEUR_B_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                    wtr.WriteLine();
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                    var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                    foreach (var l in liste_valeur2)
                                    {

                                        if (liste_valeur2.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                {
                                                    wtr.Write(";");
                                                }
                                                else
                                                {
                                                    wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                            {
                                                wtr.Write(";");
                                            }
                                            else
                                            {
                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                            }
                                        }
                                    }
                                    wtr.WriteLine();
                                }
                            }
                            else
                            {

                                string SENS = "";
                                if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                                {
                                    SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                                }

                                if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4" || SENS == "BAX")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                            foreach (var l in liste_valeur2)
                                            {

                                                if (liste_valeur2.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                        {
                                                            wtr.Write(";");
                                                        }
                                                        else
                                                        {
                                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                    }
                                                }
                                            }
                                            wtr.WriteLine();
                                        }
                                        else
                                        {
                                            if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                            {
                                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                            }
                                            else
                                            {
                                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                            }
                                            var liste_valeur1 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur1.Count) - 3;
                                            foreach (var l in liste_valeur1)
                                            {

                                                if (liste_valeur1.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                        {
                                                            wtr.Write(";");
                                                        }
                                                        else
                                                        {
                                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                    }
                                                }

                                            }
                                            wtr.WriteLine();
                                        }
                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                        {
                                            if (lr.RUBR_ETAT_CODE.ToString() == "BA31" || lr.RUBR_ETAT_CODE.ToString() == "BA32" || lr.RUBR_ETAT_CODE.ToString() == "BA33")
                                            {
                                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                                var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                                int j = 0;
                                                int v = 0;
                                                v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                                foreach (var l in liste_valeur2)
                                                {

                                                    if (liste_valeur2.Count > 3)
                                                    {
                                                        j++;
                                                        if (v < j)
                                                        {
                                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                            {
                                                                wtr.Write(";");
                                                            }
                                                            else
                                                            {
                                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                        {
                                                            wtr.Write(";");
                                                        }
                                                        else
                                                        {
                                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                        }
                                                    }
                                                }
                                                wtr.WriteLine();
                                            }
                                            else
                                            {
                                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                                var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                                int j = 0;
                                                int v = 0;
                                                v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                                foreach (var l in liste_valeur2)
                                                {

                                                    if (liste_valeur2.Count > 3)
                                                    {
                                                        j++;
                                                        if (v < j)
                                                        {
                                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                            {
                                                                wtr.Write(";");
                                                            }
                                                            else
                                                            {
                                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                        {
                                                            wtr.Write(";");
                                                        }
                                                        else
                                                        {
                                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                        }
                                                    }
                                                }

                                                wtr.WriteLine();
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                            var liste_valeur2 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                            int j = 0;
                                            int v = 0;
                                            v = Convert.ToInt32(liste_valeur2.Count) - 3;
                                            foreach (var l in liste_valeur2)
                                            {

                                                if (liste_valeur2.Count > 3)
                                                {
                                                    j++;
                                                    if (v < j)
                                                    {
                                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                        {
                                                            wtr.Write(";");
                                                        }
                                                        else
                                                        {
                                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                    }
                                                }
                                            }

                                            wtr.WriteLine();
                                        }


                                    }
                                }

                                if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                                {


                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "")+";");
                                    int p = 0;
                                    var liste_valeur3 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur3.Count) - 3;
                                    foreach (var l in liste_valeur3)
                                    {

                                        if (liste_valeur3.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                                p++;
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                            p++;
                                        }
                                    }
                                    wtr.WriteLine();
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", ""));
                                    var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int t = 0;
                                    int u = 0;
                                    u = Convert.ToInt32(liste_valeur4.Count) - 3;
                                    foreach (var l in liste_valeur4)
                                    {

                                        if (liste_valeur4.Count > 3)
                                        {
                                            t++;
                                            if (u < t)
                                            {
                                                wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(formatMillier(l.VALEUR_B_DETAIL.ToString() + ";"));
                                        }
                                    }
                                    wtr.WriteLine();
                                }


                            }

                        }


                    }
                }
                else
                {
                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX12" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA12A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA13A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA15A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX53" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX54" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA1A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3A"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX11" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA11B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX13"
                           || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA21A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X4" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA14A"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX21" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX22" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX23"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX24" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX31" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX32" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX35"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA22A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX51" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BAX52" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X2"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X8" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X6" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA2X7"
                            || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA3X1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA32A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BA33A"
                            )
                        {
                        }
                        else
                        {

                            string SENS = "";
                            if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                            {
                                SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                            }

                            if (SENS == "BA1" || SENS == "BA2" || SENS == "BA3" || SENS == "BA4" || SENS == "BAX")
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BA4")
                                    {
                                        wtr.Write(lr.RUBR_ETAT_CODE.ToString().Trim());
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");

                                        wtr.WriteLine();

                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");
                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");
                                        }



                                        wtr.WriteLine();
                                    }

                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 4)
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString() == "BA31" || lr.RUBR_ETAT_CODE.ToString() == "BA32" || lr.RUBR_ETAT_CODE.ToString() == "BA33")
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");

                                            wtr.WriteLine();
                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");

                                            wtr.WriteLine();
                                        }

                                    }
                                    else
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                        wtr.WriteLine();
                                    }
                                }
                            }
                            if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", ""));
                                wtr.Write(";");
                                wtr.WriteLine();
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", ""));
                                wtr.Write(";");
                                wtr.WriteLine();
                            }
                        }
                    }
                }
            }
        }
        public void BilanPassifs(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
                if (liste_annee.Count != 0)
                {
                    wtr.Write("Passifs;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();
                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP2" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP3")
                            {
                                if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                }
                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        }

                                    }
                                    else
                                    {
                                        wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    }
                                }

                                wtr.WriteLine();
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                {
                                    if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    }
                                    else
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    }
                                    var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur4.Count) - 3;
                                    foreach (var l in liste_valeur4)
                                    {

                                        if (liste_valeur4.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        }
                                    }
                                    wtr.WriteLine();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                        var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                        foreach (var l in liste_valeur5)
                                        {

                                            if (liste_valeur5.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                {
                                                    wtr.Write(";");
                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                                }
                                            }
                                        }

                                        wtr.WriteLine();

                                    }
                                    else
                                    {

                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                        var liste_valeur5 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur5.Count) - 3;
                                        foreach (var l in liste_valeur5)
                                        {

                                            if (liste_valeur5.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                {
                                                    wtr.Write(";");
                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                                }
                                            }
                                        }

                                        wtr.WriteLine();
                                    }

                                }
                            }
                        }
                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {

                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            int p = 0;
                            var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        p++;
                                    }

                                }
                                else
                                {
                                    wtr.Write(l.VALEUR_B_DETAIL.ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    p++;
                                }
                            }
                            wtr.WriteLine();
                        }
                    }
                }
                else
                {

                    wtr.Write("Passifs;");
                    wtr.Write(";");

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() != "Ecart")
                        {
                            string SENS = "";
                            if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                            {
                                SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                            }

                            if (SENS == "BP1" || SENS == "BP2" || SENS == "BP3" || SENS == "BP4" || SENS == "BP5" || SENS == "BP")
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1B" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP2" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP3")
                                {
                                    if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                    }
                                    else
                                    {
                                        wtr.WriteLine(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString().Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                    }
                                    wtr.WriteLine();
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1")
                                    {
                                        if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");
                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");
                                        }
                                        wtr.WriteLine();
                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A1" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A3" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1A9" || lr.RUBR_ETAT_CODE.ToString().Trim() == "BP1AX")
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");

                                            wtr.Write(";");

                                            wtr.WriteLine();

                                        }
                                        else
                                        {

                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write("");


                                            wtr.WriteLine();
                                        }

                                    }
                                }
                            }
                            if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("Â", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                wtr.Write("");
                                wtr.WriteLine();

                            }
                        }
                    }
                }
            }
        }
        public void BGMAtifs(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

                //BGM  ACTIF

                Type_anafi = "BN";

                if (liste_annee.Count != 0)
                {

                    wtr.Write("Actifs;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";;");
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";;");
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;

                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {


                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    int pa = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                wtr.Write(Convert.ToDecimal(l.TAUX_BGR_DETAIL) + ";");

                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                            wtr.Write(Convert.ToDecimal(l.TAUX_BGR_DETAIL) + ";");

                                        }
                                    }

                                    wtr.WriteLine();

                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {


                                    }
                                    else
                                    {

                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                        int p = 0;
                                        var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                    {
                                                        wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                        wtr.Write(Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString() + ";");
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL.ToString() + ";");

                                                }
                                            }
                                        }

                                        wtr.WriteLine();
                                    }
                                }

                                //wtr.WriteLine();

                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z1")
                                {

                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    if (l.VALEUR_BGR_DETAIL == 0)
                                                    {
                                                        wtr.Write("");
                                                        wtr.Write(Convert.ToDecimal(l.TAUX_BGR_DETAIL).ToString() + ";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                        wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                                    }


                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                if (l.VALEUR_BGR_DETAIL == 0)
                                                {
                                                    wtr.Write(";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL.ToString() + ";");
                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                                }
                                            }
                                        }
                                    }

                                    wtr.WriteLine();
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");


                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");


                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                            }
                                        }
                                    }

                                    wtr.WriteLine();
                                }


                            }
                        }
                    }

                    wtr.WriteLine();

                }
                else
                {

                    wtr.Write("Actifs;");
                    wtr.Write(";");


                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle)
                    {

                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI1" || SENS == "BI2" || SENS == "BI3")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    wtr.Write(";");
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                    {
                                    }
                                    else
                                    {
                                        wtr.Write(lr.RUBR_ETAT_CODE.ToString().Trim() + ";");
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                        wtr.Write(";");

                                        wtr.WriteLine();
                                    }
                                }
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.Trim() == "BI3Z1")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");

                                    wtr.WriteLine();
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");
                                    wtr.WriteLine();
                                }


                            }
                        }
                    }

                }
            }
        }
        public void BGMPassifs(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
                if (liste_annee.Count != 0)
                {
                    wtr.Write("Passifs;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";;");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";;");
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();

                    var liste_libelle1 = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    string[] TabLOTN = null;
                    foreach (var lr in liste_libelle1)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {


                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    int iv = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                            wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                        }
                                    }
                                    wtr.WriteLine();


                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    int p = 0;
                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                wtr.Write(l.TAUX_BGR_DETAIL + ";");


                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                            wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                        }
                                    }
                                    wtr.WriteLine();
                                }


                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z1")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    if (l.VALEUR_BGR_DETAIL == 0)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                        wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                                    }

                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                if (l.VALEUR_BGR_DETAIL == 0)
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL + ";");

                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL.ToString() + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL.ToString() + ";");
                                                }

                                            }
                                        }
                                    }
                                    wtr.WriteLine();
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");


                                    var liste_valeur = service.AnafiAfficheLiasse(3, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                                {
                                                    wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                    wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_BGR_DETAIL + ";");
                                                wtr.Write(l.TAUX_BGR_DETAIL + ";");
                                            }
                                        }
                                    }
                                    wtr.WriteLine();
                                }


                            }
                        }
                    }
                }
                else
                {
                    wtr.Write("Passifs;");
                    wtr.Write(";;");

                    wtr.WriteLine();

                    var liste_libelle2 = service.AnafiAfficheLiasse(0, "", "", "BIL");
                    foreach (var lr in liste_libelle2)
                    {



                        string SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        if (SENS == "BI4" || SENS == "BI5" || SENS == "BI6" || SENS == "BI7")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim().Length == 4)
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    wtr.Write(";");
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");

                                    wtr.WriteLine();
                                }
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "BI7Z1")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");

                                    wtr.WriteLine();
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");
                                    wtr.WriteLine();
                                }
                            }
                        }
                    }
                }

            }
        }
        public void TS(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
                if (liste_annee.Count != 0)
                {
                    wtr.Write("Libellés;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";;");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";;");
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();
                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {

                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(4, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(l.VALEUR_TS_DETAIL.ToString() + ";");
                                            wtr.Write(l.TAUX_TS_DETAIL.ToString() + ";");
                                            p++;
                                        }
                                    }
                                }
                                else
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        wtr.Write(l.VALEUR_TS_DETAIL.ToString() + ";");
                                        wtr.Write(l.TAUX_TS_DETAIL.ToString() + ";");
                                        p++;
                                    }
                                }
                            }
                            wtr.WriteLine();
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")
                            {

                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(4, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_TS_DETAIL.ToString() + ";");
                                                wtr.Write(l.TAUX_TS_DETAIL + ";");
                                                p++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(l.VALEUR_TS_DETAIL.ToString() + ";");
                                            wtr.Write(l.TAUX_TS_DETAIL.ToString() + ";");
                                            p++;
                                        }
                                    }
                                }
                                wtr.WriteLine();
                            }
                        }
                    }
                }
                else
                {
                    wtr.Write("Libellés;");
                    wtr.Write(";");

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CR");

                    foreach (var lr in liste_libelle)
                    {


                        if (lr.RUBR_ETAT_CODE.Trim() == "C019" || lr.RUBR_ETAT_CODE.Trim() == "C029" || lr.RUBR_ETAT_CODE.Trim() == "C039" || lr.RUBR_ETAT_CODE.Trim() == "C049" || lr.RUBR_ETAT_CODE.Trim() == "C059" || lr.RUBR_ETAT_CODE.Trim() == "C069" || lr.RUBR_ETAT_CODE.Trim() == "C079" || lr.RUBR_ETAT_CODE.Trim() == "C089" || lr.RUBR_ETAT_CODE.Trim() == "C099" || lr.RUBR_ETAT_CODE.Trim() == "C109" || lr.RUBR_ETAT_CODE.Trim() == "C119")
                        {
                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            wtr.Write(";");
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() != "C0203" && lr.RUBR_ETAT_CODE.Trim() != "C0204" && lr.RUBR_ETAT_CODE.Trim() != "C0205" && lr.RUBR_ETAT_CODE.Trim() != "C0206" && lr.RUBR_ETAT_CODE.Trim() != "C0207")
                            {
                                wtr.Write(lr.RUBR_ETAT_CODE.ToString().Trim());
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                wtr.Write("");
                            }
                        }
                        wtr.WriteLine();
                    }
                }
            }
        }
        public void Ratios(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");
                if (liste_annee.Count != 0)
                {
                    wtr.Write("Ratios;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {
                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(6, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {
                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "R03" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R04" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R05" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R06" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R07" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R08")
                                            wtr.Write(l.VALEUR_RAT_AFF_DETAIL + ";");
                                        else
                                            wtr.Write(l.VALEUR_RAT_AFF_DETAIL + ";");
                                        p++;
                                    }
                                }
                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "R03" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R04" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R05" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R06" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R07" || lr.RUBR_ETAT_CODE.ToString().Trim() == "R08")
                                        wtr.Write(l.VALEUR_RAT_AFF_DETAIL + ";");
                                    else
                                        wtr.Write(l.VALEUR_RAT_AFF_DETAIL + ";");
                                    p++;
                                }
                            }
                        }
                        wtr.WriteLine();
                    }
                }
                else
                {

                    wtr.Write("Ratios;");
                    wtr.Write(";");
                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "RAT");

                    foreach (var lr in liste_libelle)
                    {
                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                        wtr.Write(";");
                        wtr.WriteLine();
                    }
                }
            }
        }
        public void BilanEcarts(string csvOutputFile, string id_dossier)
        {

            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {

                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");


                if (liste_annee.Count != 0)
                {
                    wtr.Write("Ecrats des totaux;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();


                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "BIN");

                    int limite = 0;

                    foreach (var lr in liste_libelle)
                    {
                        limite++;
                        if (lr.RUBR_ETAT_CODE.Trim() == "BA")
                        {

                            wtr.Write("TOTAL GÉNERAL DES ACTIFS;");

                            var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            int t = 0;
                            int u = 0;
                            int i = 0;
                            u = Convert.ToInt32(liste_valeur4.Count) - 3;
                            foreach (var l in liste_valeur4)
                            {

                                if (liste_valeur4.Count > 3)
                                {
                                    t++;
                                    if (u < t)
                                    {

                                        wtr.Write(l.VALEUR_B_DETAIL + ";");
                                        TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                        i++;
                                    }

                                }
                                else
                                {
                                    wtr.Write(l.VALEUR_B_DETAIL + ";");
                                    TabLOTECART[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    i++;
                                }

                            }
                            wtr.WriteLine();

                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "BP")
                        {
                            wtr.Write("TOTAL GÉNERAL DES PASSIFS;");


                            int p = 0;
                            var liste_valeur6 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur6.Count) - 3;
                            int i = 0;
                            foreach (var l in liste_valeur6)
                            {

                                if (liste_valeur6.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace(" ", "&nbsp;");
                                        wtr.Write(l.VALEUR_B_DETAIL + ";");
                                        TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                        i++;
                                        p++;
                                    }

                                }
                                else
                                {
                                    var testjkjh = formatMillier(l.VALEUR_B_DETAIL.ToString()).Replace("&nbsp;", " ");
                                    wtr.Write(l.VALEUR_B_DETAIL + ";");
                                    TabLOTECART1[i] = Convert.ToDouble(l.VALEUR_B_DETAIL);
                                    i++;
                                    p++;
                                }
                                //i++;
                            }
                            wtr.WriteLine();



                            if (limite == liste_libelle.Count)
                            {
                                wtr.Write("ECARTS;");

                                var liste_valeur4 = service.AnafiAfficheLiasse(9, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int t = 0;
                                int u = 0;
                                int b = 0;
                                u = Convert.ToInt32(liste_valeur4.Count) - 3;
                                foreach (var l in liste_valeur4)
                                {

                                    if (liste_valeur4.Count > 3)
                                    {
                                        t++;
                                        if (u < t)
                                        {
                                            double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                            if (nombre == 0)
                                            {
                                                wtr.Write(nombre.ToString() + ";");

                                            }
                                            else
                                            {
                                                wtr.Write(nombre.ToString() + ";");

                                            }
                                            b++;
                                        }

                                    }
                                    else
                                    {
                                        double nombre = TabLOTECART[b] - TabLOTECART1[b];
                                        if (nombre == 0)
                                        {
                                            wtr.Write(nombre.ToString() + ";");
                                        }
                                        else
                                        {
                                            wtr.Write(nombre.ToString() + ";");
                                        }
                                        b++;
                                    }


                                }
                                wtr.WriteLine();

                            }

                        }
                    }
                }
                else
                {
                    wtr.Write("Ecrats des totaux" + ";");
                    wtr.WriteLine();
                    wtr.Write("TOTAL GÉNERAL DES ACTIFS;");
                    wtr.WriteLine();



                    wtr.Write(";");
                    wtr.WriteLine();



                    wtr.Write(";");
                    wtr.WriteLine();
                }
            }
            Type_anafi = "BN";
        }
        public void CompteResultatsCharge(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

                if (liste_annee.Count != 0)
                {
                    wtr.Write("Charges;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                            }
                            i++;
                        }
                    }
                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1" || SENS == "CC2" || SENS == "CC3" || SENS == "CC4" || SENS == "CC5")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {

                                if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                }

                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                            {
                                                wtr.Write(";");
                                            }
                                            else
                                            {
                                                wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(";");
                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                        }
                                    }
                                }
                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                            {
                                                wtr.Write(";");
                                            }
                                            else
                                            {
                                                wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");

                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(";");
                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                        }
                                    }
                                }


                                wtr.WriteLine();

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {
                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                        p++;
                                    }

                                }
                                else
                                {
                                    wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                    p++;
                                }
                            }
                            wtr.WriteLine();
                        }

                    }
                }
                else
                {
                    wtr.Write("Charges;");
                    wtr.Write(";");

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");

                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CC0" || SENS == "CC1" || SENS == "CC2" || SENS == "CC3" || SENS == "CC4" || SENS == "CC5")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {
                                wtr.Write(lr.RUBR_ETAT_CODE + ";");


                                if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    wtr.Write(";");
                                }
                                else
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    wtr.Write(";");
                                }
                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                wtr.Write(";");
                                wtr.WriteLine();

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CC")
                        {

                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            wtr.Write(";");
                            wtr.WriteLine();

                        }

                    }
                }
            }

        }
        public void CompteResultatsProduits(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

                //debut produit 
                //si liste des année est superrieur à 0

                if (liste_annee.Count != 0)
                {
                    wtr.Write("Produits;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");
                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2" || SENS == "CP3" || SENS == "CP4" || SENS == "CP5" || SENS == "CP6" || SENS == "CP7" || SENS == "CP8")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {


                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "CP7" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP8")
                                {


                                    if (SENS == "CP8")
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                    {
                                                        wtr.Write(";");
                                                    }
                                                    else
                                                    {
                                                        wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                {
                                                    wtr.Write(";");
                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                                }
                                            }
                                        }
                                        wtr.WriteLine();
                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                        }
                                        var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                        int j = 0;
                                        int v = 0;
                                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                                        foreach (var l in liste_valeur)
                                        {

                                            if (liste_valeur.Count > 3)
                                            {
                                                j++;
                                                if (v < j)
                                                {
                                                    wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                                }

                                            }
                                            else
                                            {
                                                wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                            }
                                        }
                                        wtr.WriteLine();
                                    }
                                }
                                else
                                {
                                    if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    }
                                    else
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                    }
                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                            }

                                        }
                                        else
                                        {
                                            wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                        }
                                    }

                                    wtr.WriteLine();
                                }
                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");

                                    var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                                    int j = 0;
                                    int v = 0;
                                    v = Convert.ToInt32(liste_valeur.Count) - 3;
                                    foreach (var l in liste_valeur)
                                    {

                                        if (liste_valeur.Count > 3)
                                        {
                                            j++;
                                            if (v < j)
                                            {
                                                if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                                {
                                                    wtr.Write(";");
                                                }
                                                else
                                                {
                                                    wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (l.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                            {
                                                wtr.Write(";");
                                            }
                                            else
                                            {
                                                wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                            }
                                        }
                                    }

                                    wtr.WriteLine();
                                }

                            }
                        }

                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {

                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            // TabLOTP = new string[Convert.ToInt32(liste_annee.Count)];
                            int p = 0;
                            var liste_valeur = service.AnafiAfficheLiasse(10, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");
                            int j = 0;
                            int v = 0;
                            v = Convert.ToInt32(liste_valeur.Count) - 3;
                            foreach (var l in liste_valeur)
                            {

                                if (liste_valeur.Count > 3)
                                {
                                    j++;
                                    if (v < j)
                                    {
                                        wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                        // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                        p++;
                                    }

                                }
                                else
                                {
                                    wtr.Write(l.VALEUR_CR_DETAIL.ToString() + ";");
                                    // TabLOTP[p] = l.VALEUR_B_DETAIL.ToString();
                                    p++;
                                }
                            }

                        }
                    }

                    wtr.WriteLine();

                }
                else
                {
                    wtr.Write("Produits;");
                    wtr.Write(";");

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "CRN");
                    foreach (var lr in liste_libelle)
                    {
                        string SENS = "";
                        if (lr.RUBR_ETAT_CODE.Trim().Length > 2)
                        {
                            SENS = lr.RUBR_ETAT_CODE.ToString().Trim().Substring(0, 3);
                        }

                        if (SENS == "CP0" || SENS == "CP1" || SENS == "CP2" || SENS == "CP3" || SENS == "CP4" || SENS == "CP5" || SENS == "CP6" || SENS == "CP7" || SENS == "CP8")
                        {
                            if (lr.RUBR_ETAT_CODE.ToString().Trim().Length == 3)
                            {

                                if (lr.RUBR_ETAT_CODE.ToString().Trim() == "CP7" || lr.RUBR_ETAT_CODE.ToString().Trim() == "CP8")
                                {


                                    if (SENS == "CP8")
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                        wtr.WriteLine();
                                    }
                                    else
                                    {
                                        if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").ToString() + ";");
                                            wtr.Write(";");
                                        }
                                        else
                                        {
                                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                            wtr.Write(";");
                                        }
                                        wtr.WriteLine();
                                    }



                                }
                                else
                                {


                                    if (lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "").Trim().Length <= 1)
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                    }
                                    else
                                    {
                                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                        wtr.Write(";");
                                    }

                                    wtr.WriteLine();
                                }


                            }
                            else
                            {
                                if (lr.RUBR_ETAT_CODE.ToString().Trim() != "CP6C")
                                {
                                    wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                    wtr.Write(";");

                                    wtr.WriteLine();
                                }

                            }
                        }


                        if (lr.RUBR_ETAT_CODE.Trim() == "CP")
                        {
                            wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                            wtr.Write(";");
                        }
                    }
                }
            }
        }
        public void TDR(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {
                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

                // tableau des documents resumé

                if (liste_annee.Count != 0)
                {
                    wtr.Write("Valeurs structurelles");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }


                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }
                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }
                                wtr.WriteLine();
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                wtr.Write("RATIOS;");

                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(";");

                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(";");

                                            p++;
                                        }
                                    }
                                }
                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                                int p = 0;
                                var liste_valeur = service.AnafiAfficheLiasse(5, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                                int j = 0;
                                int v = 0;
                                v = Convert.ToInt32(liste_valeur.Count) - 3;
                                foreach (var l in liste_valeur)
                                {

                                    if (liste_valeur.Count > 3)
                                    {
                                        j++;
                                        if (v < j)
                                        {
                                            if (l.TYPE_ANAFI_A.Trim() == "SN")
                                            {
                                                wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                                // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                                p++;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (l.TYPE_ANAFI_A.Trim() == "SN")
                                        {
                                            wtr.Write(l.VALEUR_TDR_DETAIL + ";");
                                            // TabLOTA[p] = l.VALEUR_TDR_DETAIL.ToString();
                                            p++;
                                        }
                                    }
                                }

                                wtr.WriteLine();
                            }
                        }
                    }
                }
                else
                {
                    wtr.Write("Valeurs structurelles;");
                    wtr.Write(";");

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "TDR");

                    foreach (var lr in liste_libelle)
                    {
                        if (lr.RUBR_ETAT_CODE.Trim() == "BI40" || lr.RUBR_ETAT_CODE.Trim() == "BI41" || lr.RUBR_ETAT_CODE.Trim() == "BI42" || lr.RUBR_ETAT_CODE.Trim() == "BI43" || lr.RUBR_ETAT_CODE.Trim() == "BJ00" || lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BI6A" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "TN20" || lr.RUBR_ETAT_CODE.Trim() == "TN21" || lr.RUBR_ETAT_CODE.Trim() == "ZN2" || lr.RUBR_ETAT_CODE.Trim() == "BI2A" || lr.RUBR_ETAT_CODE.Trim() == "BI3A" || lr.RUBR_ETAT_CODE.Trim() == "BI7A")
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "BJ1" || lr.RUBR_ETAT_CODE.Trim() == "BK1" || lr.RUBR_ETAT_CODE.Trim() == "TN1" || lr.RUBR_ETAT_CODE.Trim() == "ZN2")
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                wtr.Write(";");

                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                wtr.Write(";");

                                wtr.WriteLine();
                            }
                        }
                        else
                        {
                            if (lr.RUBR_ETAT_CODE.Trim() == "ZN3")
                            {
                                wtr.Write("RATIOS;");
                                wtr.Write(";");
                                wtr.WriteLine();
                            }
                            else
                            {
                                wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                                wtr.Write(";");

                                wtr.WriteLine();
                            }
                        }
                    }
                }
            }
        }
        public void TAR(string csvOutputFile, string id_dossier)
        {
            try
            {
                File.Delete(csvOutputFile);
            }
            catch (Exception excep)
            {
            }
            string compar = id_dossier;
            using (var wtr = new StreamWriter(csvOutputFile, false, Encoding.Unicode))
            {

                var liste_annee = service.AnafiAfficheLiasse(7, compar, "", "SN");
                var nombre_annee = service.AnafiAfficheLiasse(8, compar, "", "SN");

                //Tableau des autre ratio


                if (liste_annee.Count != 0)
                {
                    wtr.Write("Autres ratios;");

                    if (liste_annee.Count > 3)
                    {
                        int j = 0;
                        int v = 0;
                        int i = 0;
                        v = Convert.ToInt32(liste_annee.Count) - 3;
                        foreach (var lr in liste_annee)
                        {
                            j++;
                            if (v < j)
                            {
                                if (i < Convert.ToInt32(liste_annee.Count))
                                {
                                    wtr.Write(lr.ANNEE_DETAIL + ";");
                                    //TabLOT[i] = lr.ANNEE_DETAIL;
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        foreach (var lr in liste_annee)
                        {

                            if (i < Convert.ToInt32(liste_annee.Count))
                            {
                                wtr.Write(lr.ANNEE_DETAIL + ";");
                                //TabLOT[i] = lr.ANNEE_DETAIL;
                            }
                            i++;
                        }
                    }

                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                    foreach (var lr in liste_libelle)
                    {



                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                        // TabLOTA = new string[Convert.ToInt32(liste_annee.Count)];
                        int p = 0;
                        var liste_valeur = service.AnafiAfficheLiasse(13, compar, lr.RUBR_ETAT_CODE.ToString().Trim(), "SN");

                        int j = 0;
                        int v = 0;
                        v = Convert.ToInt32(liste_valeur.Count) - 3;
                        foreach (var l in liste_valeur)
                        {

                            if (liste_valeur.Count > 3)
                            {
                                j++;
                                if (v < j)
                                {
                                    if (l.TYPE_ANAFI_A.Trim() == "SN")
                                    {
                                        if (lr.RUBR_ETAT_CODE.ToString().Trim() == "AU1")
                                            wtr.Write(l.VALEUR_AUTRE_RAT_AFF_DETAIL + ";");
                                        else
                                            wtr.Write(l.VALEUR_AUTRE_RAT_AFF_DETAIL + ";");
                                        // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                        p++;
                                    }
                                }

                            }
                            else
                            {
                                if (l.TYPE_ANAFI_A.Trim() == "SN")
                                {
                                    if (lr.RUBR_ETAT_CODE.ToString().Trim() == "AU1")
                                        wtr.Write(l.VALEUR_AUTRE_RAT_AFF_DETAIL + ";");
                                    else
                                        wtr.Write(l.VALEUR_AUTRE_RAT_AFF_DETAIL + ";");
                                    // TabLOTA[p] = l.VALEUR_RAT_AFF_DETAIL.ToString();
                                    p++;
                                }
                            }
                        }


                        wtr.WriteLine();
                    }


                }
                else
                {
                    wtr.Write("Autres ratios;");
                    wtr.Write(";");
                    wtr.WriteLine();

                    var liste_libelle = service.AnafiAfficheLiasse(0, "", "", "AUT");

                    foreach (var lr in liste_libelle)
                    {



                        wtr.Write(lr.RUBR_ETAT_LIBELLE.Replace("&nbsp", "").Replace("<strong>", "").Replace("</strong>", "") + ";");
                        wtr.Write(";");

                        wtr.WriteLine();
                    }


                }

            }
        }
    }
}