<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPreview.aspx.cs" Inherits="ScoringCenter.PrintPreview" MasterPageFile="~/Site.Master"%>--%>

<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="PrintPreview.aspx.cs" Inherits="ScoringCenter.PrintPreview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    
    <div>
        <center>
            <div class="col-lg-8 col-md-8 col-sm-8 col-lg-offset-2 col-md-offset-2 col-sm-offset-2">
                <div runat="server" id="CloseMsg"></div>
            </div>
            <div id="contentetat" runat="server">
                <%--<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" DisplayStatusbar="False" EnableDrillDown="False" EnableToolTips="False" HasCrystalLogo="False" HasDrillUpButton="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" ToolPanelView="None" />--%>
                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1241px" ToolbarImagesFolderUrl="" Width="846px" EnableDatabaseLogonPrompt="False" EnableDrillDown="False" HasCrystalLogo="False" HasDrilldownTabs="False" HasSearchButton="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" ToolPanelView="None" ToolPanelWidth="200px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="M61_Etat_M63_CENTRALE_RISQUES bceao\DEC2000_1_Situation Compta.rpt">
                    </Report>
                </CR:CrystalReportSource>--%>
            </div>
            <div hidden id="BdossierNotation">
                <button onclick="printHtml()" class="cergi_color"> print</button>
            </div>
            <div id="PdossierNotation" style="height:2px; max-height:4px; overflow:hidden;">
             <center>
                <h1>
                    
                    <label style="font-family:'Century Gothic','Lucida Console'; font-size:10px large; font:bold; width:100%; text-align:center;"> DOSSIER DE NOTATION</label>
                </h1> 
             </center>   
                <div style="width:100%; height:1125px;">
                    <div style="width:100%; height:200px;">
                        <table style="width:100%; height:70%; font-size:2px;">
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Unité en Charge</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:40%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Date d'ouverture</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:15%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Chargé de clientèle</td>
                                <td style="border:solid 0.4px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                                <td style="width:20%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Date de cloture</td>
                                <td style="border:solid 1px #000000; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Etat de la demande</td>
                                <td style="border:solid 0.4px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                                <td style="width:20%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Date d'expiration de la revision annuelle</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Organe de délibération</td>
                                <td style="border:solid 0.4px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                                <td style="width:20%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Dernière date ECA</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                            </tr>
                        </table>
                    </div>
                    <hr />
                    <div style="width:100%;">
                       
                            <div style="width:100%; background-color:#c8e588; margin-top:1%; height:250px; border-radius:5px 5px; border:solid 2px #130a4b;">
                                <center><h3 style="color:#808080;">Identifiants</h3></center>
                                <table style="width:100%; height:70%; font-size:2px;">
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Raison sociale</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Adresse C.P</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Ville</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Pays</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">N° Registre Commerce</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Identifiant Principal</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Identifiant Scoring</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Type Client</td>
                                      <td style="width:50%; padding-left:1%;"><label>Defitex</label></td>
                                    </tr>

                                </table>
                                
                            </div>
                       
                            <div style="width:100%; background-color:#c8e588; margin-top:1%; height:170px; border-radius:5px 5px; border:solid 2px #130a4b;">
                                <center><h3 style="color:#808080;">Activités</h3></center>
                                <table style="width:100%; height:70%; font-size:2px;">
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Secteur d'activité</td>
                                      <td style="width:50%; padding-left:1%;"><label>Services</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Activité principale de l'entreprise</td>
                                      <td style="width:50%; padding-left:1%;">Activités informatiques</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Statut juridique</td>
                                      <td style="width:50%; padding-left:1%;">Société Anonyme (SA) à participation publique</td>
                                    </tr>
                                   

                                </table>
                                
                            </div>
                       
                            <div style="width:100%; background-color:#c8e588; margin-top:1%; height:200px; border-radius:5px 5px; border:solid 2px #130a4b;">
                                <center><h3 style="color:#808080;">Informations Bancaires</h3></center>
                                <table style="width:100%; height:70%; font-size:2px;">
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Segment clientèle</td>
                                      <td style="width:50%; padding-left:1%;"><label>Segment()</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Agence</td>
                                      <td style="width:50%; padding-left:1%;">Agence Marcory</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Groupe</td>
                                      <td style="width:50%; padding-left:1%;"><label>ONOMA</label></td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Chiffre d'affaire</td>
                                      <td style="width:50%; padding-left:1%;">5 000 000 000</td>
                                    </tr>
                                </table>
                                
                            </div>
                    </div>
                    <hr />
                </div>
               
                
                <div style="width:100%; height:1125px;">
                
                <div style="width:100%; height:100px; margin-top:1%;">
                    
                        <table style="border-bottom: 2px solid #4cff00; width:100%; height:50%;">
                           <tr> <td> Notation/Information sur le statut </td></tr>
                        </table>
                </div>

                
                    <div style="width:100%; height:200px;">
                        <table style="width:100%; height:80%; font-size:2px;">
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"> </td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;">Notation</td>
                                <td style="padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;">DT Notation</td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Information sur le statut</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Notation BC</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                            </tr>
                            <tr>
                               <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Classe interne</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">-</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Classe à risque elevé</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">-</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Classification Nationale</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">-</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;"></td>
                            </tr>
                            <tr>
                                <td style="width:25%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"></td>
                                <td style="padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:35%;"></td>
                                <td style="width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;">-</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;">-</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:10%;">-</td>
                            </tr>
                        </table>
                        <br />
                         <table style="width:100%; height:30%; font-size:2px;">
                            <tr>
                                <td style="width:20%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> Rating précedent</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"> </td>
                                <td style="border:solid 1px #000000;width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"> </td>
                            </tr>
                            <tr>
                                <td style="width:20%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> Rating actuel </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"> </td>
                                <td style="border:solid 1px #000000;width:20%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:20%;"> </td>
                            </tr>
                            
                        </table>

                    </div>

                <br />
                    <div style="width:100%; height:50px; margin-top:5%;">
                    
                        <table style="border-bottom: 2px solid #4cff00; width:100%; height:50%; margin-top:5px;">
                           <tr> <td><b> Output RatingPro </b></td></tr>
                           <tr> <td> Resultat final </td></tr>
                        </table>
                    </div>
                <br />
                <div style="width:100%; height:200px;">
                    <table style="width:100%; height:30%; font-size:2px;">
                            <tr>
                                <td style="width:16%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> Rating précedent</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                                <td style="border:solid 1px #000000;width:16%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                            </tr>
                            <tr>
                                <td style="width:16%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> Rating actuel </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                                <td style="border:solid 1px #000000;width:16%; padding-bottom:-1%;padding-top:-1%;padding-left:1%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"></td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:16%;"> </td>
                            </tr>
                        </table>
                    <hr />
                </div>
                    
                    </div>
                <div style="width:100%; height:1125px; margin-top:100px;" >
                    <h2>ANALYSE FINANCIERE</h2>
                <div id="ListDFinanciers1"  runat="server">
                  </div>
                    <br /><hr />
                    <div id="ListDFinanciers2"  runat="server">
                  </div>
                    <br /><br /> <br />
                <div style="width:100%; height:200px;">
                    <table style="width:100%; height:40%; font-size:2px;">
                            <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Modèle de notation</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                               </tr>
                            <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Notching financier </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Score qualitatif </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">PD du modèle financier </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        </table>
                </div>
                
                <div style="width:100%; margin-top:100px;" >

                    <div style="width:100%; background-color:#c8e588; margin-top:1%; height:300px; border-radius:5px 5px; border:solid 2px #130a4b;">
                                <center><h3 style="color:#808080;">Saisie et Analyse</h3></center>
                                <table style="width:100%; height:70%; font-size:2px;">
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Modele d'Analyse</td>
                                      <td style="width:50%; padding-left:1%;">Corporate</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Date cloture</td>
                                      <td style="width:50%; padding-left:1%;">31/12/2017</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Duree de l'exercise en mois</td>
                                      <td style="width:50%; padding-left:1%;">2</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Type Bilan</td>
                                      <td style="width:50%; padding-left:1%;">Bilan Normal</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Nature de l'exercice</td>
                                      <td style="width:50%; padding-left:1%;">Fin d'exercice</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Certification des comptes</td>
                                      <td style="width:50%; padding-left:1%;">Certificat sans reserve</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Effectif</td>
                                      <td style="width:50%; padding-left:1%;">133</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Devise</td>
                                      <td style="width:50%; padding-left:1%;">XOF</td>
                                    </tr>
                                    <tr>
                                      <td style="width:50%; padding-left:2%;">Regime Fiscal</td>
                                      <td style="width:50%; padding-left:1%;">Reel Normal</td>
                                    </tr>
                                </table>
                                
                            </div>
                    <h2> BILAN </h2>
                   
                   <div id="ListDFinanciers3"  runat="server">

                    </div>
                       
                     <div id="Div2" style="width:100%; margin-top:100px;" runat="server">
                                            <div id="DivecartsActifPassif" runat="server" class="">
                                               
                                            </div>
                    </div>
                     
                    </div>

                    
                <div style="width:100%; margin-top:100px;" >
                <h2> COMPTE DE RESULTAT</h2>

                <div id="ListDFinanciers4"  runat="server">

                    </div>

                 <h2> BILAN EN GRANDE MASSE</h2>

                <div id="ListDFinanciers5"  runat="server">

                </div>
                
                    <h2> TABLEAU SYNTHETIQUE DES SOLDES SIGNIFICATIFS DE GESTION</h2>

                <div id="ListDFinanciers6"  runat="server">

                    </div>
                    <br />
                    <div style="width:100%; margin-top:50%;" >
                    <h2> TABLEAU DES DOCUMENTS RESUMES</h2>

                     <div id="ListDFinanciers7"  runat="server">

                    </div></div>


                    <div style="width:100%; margin-top:100px;" >
                    <h2> ANALYSE QUALITATIVE</h2>

                        <div id="EspaceQuestionnaire" runat="server">

                        </div>
                        <input type="hidden" id="checked_docs" value="" runat="server" />
                        <input type="hidden" id="Hidden1" value="" runat="server" />
                        <input type="hidden" id="Totcha" value="0" runat="server" />
                        <input type="hidden" id="valnote" runat="server" />
                        <input type="hidden" id="valnotecalc" runat="server" />
                        <input type="hidden" id="fili" runat="server" />
                         <input type="hidden" id="notifHiddenF" /> 
                    </div>

                    <div style="width:100%; height:200px; margin-top:50%; margin-bottom:50%;">
                    <table style="width:100%; height:40%; font-size:2px;">
                            <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Modèle de notation</td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                               </tr>
                            <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Notching qualitatif </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">Score qualitatif </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        <tr>
                                <td style="border:solid 1px #000000;width:30%;padding-bottom:-1%;padding-top:-1%;padding-left:1%;">PD du modèle Finaciere </td>
                                <td style="border:solid 1px #000000;padding-bottom:-1%;padding-top:-1%;padding-left:1%; width:70%;"> </td>
                            </tr>
                        </table>
                </div>
                    <div style="width:100%; height:1125px;">
                
                <div style="width:100%; height:100px; margin-top:1%;">
                    
                        <table style="border-bottom: 2px solid #4cff00; width:100%; height:50%;">
                           <tr> <td><h3> Note de la demande </h3></td></tr>
                        </table>
                </div>
                        <div style="width:100%; height:300px; margin-top:1%;">
                    
                        <table style="border: 1px solid #000000; width:100%; height:250px; font-size:5px;">
                           <tr style="height:25px; border: 1px solid #000000;"> <td><h5> Note de la demande </h5></td></tr>
                           <tr style="height:200px; border: 1px solid #000000;"> <td> Note de la demande </td></tr>
                        </table>
                </div>
                        <div style="width:100%; height:100px; margin-top:1%;">
                    
                        <table style="border-bottom: 2px solid #4cff00; width:100%; height:50%;">
                           <tr> <td><h3> </h3></td></tr>
                        </table>
                </div>

                    </div> 


                    </div>
                </div>
               

            </div>
        </center>
    </div>
    <script src='print.min.js'></script>
    <script>

        function printHtml() {
            printJS('PdossierNotation', 'html');
        }

    </script>
    <script>
        // $("#notifHiddenF").val("Analyse Qualitative");

        $(document).ready(function () {

            myload();
            //changeNote();

            get_docs();
        });
    </script>
    <script type="text/javascript">

        function enregistre() {
            alert("Enregistrement effectué");
        }



        function myload() {

            // var checkboxes = document.getElementsByClassName('Ddltaille padding checkboxx');
            var docs = "";
            docs = $("#<%=Hidden1.ClientID%>").val();
            var chaine = docs;
            //alert(chaine);

            var tableau = chaine.split('@');
            for (var i = 1; i < tableau.length; i++) {
                // alert(i + ' -> ' + tableau[i]);
                // $("#selec" + i).val(tableau[i + 1]);
                document.getElementById('' + tableau[i]).selected = true;

                // document.getElementById("selec" + i).options[document.getElementById("selec" + i).selectedIndex].id = tableau[i + 1];
                //alert(document.getElementById('selec' + i).value);

            }
            // alert('');
            // get_docs();

        }

        function get_docsi() {
            // get_docs();
            var checkboxes = document.getElementsByClassName('checkboxx');
            var docs = "";
            for (var i = 0, n = checkboxes.length; i < n; i++) {


                var option_user_selection_id = document.getElementById("selec" + i).options[document.getElementById("selec" + i).selectedIndex].id
                //var doc = "@" + checkboxes[i].id;

                var doc = "@" + option_user_selection_id.trim();
                docs += doc;

            }

            $("#<%=checked_docs.ClientID%>").val(docs);
            // alert(docs);
        }

        function get_docs() {
            // alert();

            var checkboxes = document.getElementsByClassName('checkboxx');
            var docs = "";
            for (var i = 0, n = checkboxes.length; i < n; i++) {

                var doc = "@" + checkboxes[i].value;
                docs += doc;
            }



            $("#<%=checked_docs.ClientID%>").val(docs.trim());
            //alert(docs);

            var chaine = docs.trim();
            var tableau = chaine.split('@');
            var vss = 0;
            for (var i = 1; i < tableau.length; i++) {
                vss = vss + parseInt(tableau[i]);

            }

            var result = (vss / parseInt($("#<%=Totcha.ClientID%>").val())) * 20;



            $("#<%=Totcha.ClientID%>").val(vss);

            $("#<%=valnote.ClientID%>").val(result + "");

            //get_docsi();
            //loadNote();
        }

        function Calc_get_docs() {
            $("#<%=valnotecalc.ClientID%>").val('1');
            if ($("#<%=valnotecalc.ClientID%>").val() != "") {
                get_docs();
                changeNote();
                alert('');
                $("#<%=valnotecalc.ClientID%>").val('');
            }
        }

        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });



    </script>
    <script>
        $(document).ready(function () {
            printHtml();
        });
    </script>
</asp:Content>
