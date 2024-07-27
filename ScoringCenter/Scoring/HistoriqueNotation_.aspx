<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableSessionState="True" AutoEventWireup="true" CodeBehind="HistoriqueNotation.aspx.cs" Inherits="ScoringCenter.Scoring.HistoriqueNotation" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="JQChart.Web" Namespace="JQChart.Web.UI.WebControls" TagPrefix="jqChart" %>
<asp:Content ID="HistoriqueNotationMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <link rel="stylesheet" type="text/css" href="../Content/jquery.jqChart.css" />
    <link rel="stylesheet" type="text/css" href="../Content/jquery.jqRangeSlider.css" />
    <link rel="stylesheet" type="text/css" href="../Content/jquery-ui-1.10.4.css" />
    <script src="<% = ResolveUrl("../Scripts/jquery-1.11.1.min.js") %>" type="text/javascript"></script>
    <script src="<% = ResolveUrl("../Scripts/jquery.jqRangeSlider.min.js") %>" type="text/javascript"></script>
    <script src="<% = ResolveUrl("../Scripts/jquery.jqChart.min.js") %>" type="text/javascript"></script>
    <script src="<% = ResolveUrl("../Scripts/jquery.mousewheel.js") %>" type="text/javascript"></script>
    <!--[if IE]><script lang="javascript" type="text/javascript" src="<% = ResolveUrl("~/Scripts/excanvas.js") %>"></script><![endif]-->

    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">                 
	        <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui "  id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui "  id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui"  id="HN" runat="server"><a class="pureCssMenui"  style="background-color: #022D65; color: #FFFFFF;" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui"  id="DN" runat="server"><a class="pureCssMenui" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="" style="z-index: 10;">
		            <li class="pureCssMenui"  id="AF" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui"  id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui"  id="RP" runat="server"><a class="pureCssMenui" <%--style="color:#d8d8d8"--%> href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui"  id="E" runat="server"><a  class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                    <li class="pureCssMenui"  id="VN" runat="server"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
                </ul>
            </li>
            <li class="pureCssMenui"  id="AN" runat="server"><a class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
	        <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
               <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */ color:#d8d8d8" class="pureCssMenui" href="#" data-toggle="modal" data-target="#">Guide Utilisateur</a></li>
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */ color:#d8d8d8" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style="" id="EBF" runat="server"><a style="/*font-family: cursive; */ color:#d8d8d8" class="pureCssMenui" href="#">Envoi Bilan financier</a></li>
             </ul>
    </div>

</asp:Content>

<asp:Content ID="HistoriqueNotationBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <br class="br_top" />
        <input type="text" runat="server" id="connmou007" hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Historique de notation</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="max-height: 25%; overflow: hidden;">
                                    <div class="row contreparie_info_1">
                                        <div class="col-lg-4 col-sm-4 col-md-4 text-left">
                                            <b>
                                                <asp:Label ID="Rsocial" runat="server" CssClass="boldSize"
                                                    Text="Raison Sociale : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="NClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3 text-left">
                                        
                                              <b>
                                                <asp:Label ID="Iprincipal" CssClass="boldSize" runat="server"
                                                    Text="Id Scoring Center : "></asp:Label></b>
                                            <asp:Label ID="IdScoringCenter" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-5 col-sm-5 col-md-5 text-left">
                                           <%-- <b>
                                                <asp:Label ID="SActivité" CssClass="boldSize" runat="server"
                                                    Text="Secteur d'Activité : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="AEntreprise" runat="server" Text=""></asp:Label>--%>
                                             <b>
                                                <asp:Label ID="Sren" runat="server" CssClass="boldSize"
                                                    Text="Activité  : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="Siren" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row contreparie_info_2">
                                        <div class="col-lg-4 col-sm-4 col-md-4 text-left">
                                            <b>
                                                <asp:Label ID="TypeClient" runat="server" CssClass="boldSize"
                                                    Text="Type Client : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="SaiTypeClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3 text-left">
                                            <b>
                                                <asp:Label ID="CAPE" runat="server" CssClass="boldSize"
                                                    Text="RCCM : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="CodeAPE" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3 text-left">
                                            <b>
                                                <asp:Label ID="LbChiffre" CssClass="boldSize" runat="server" Text="Chiffre d'Affaire : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="ChiffreAffaire" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-2 col-sm-2 col-md-2 text-left">
                                            <b>
                                                <asp:Label ID="LbDevise" CssClass="boldSize" runat="server"
                                                    Text="Devise : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="Devise" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>   
                        <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" id="ListDHistorique" runat="server">
                            <div class="row" style="margin-top: -0.5%;">
                                <table class="table table-bordered table-hover" id="">
                                    <thead>
                                        <tr class="table-heigth1">
                                            <th class="text-center">Données Financières</th>
                                            <th class="text-center">Données Qualitatives</th>
                                            <th class="text-center">Nca</th>
                                            <th class="text-center">Note Proposée</th>
                                            <th class="text-center">Note Retenue</th>
                                            <th class="text-center">Valideur</th>
                                            <th class="text-center">Etat</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ListDocTableauBord" runat="server" style="text-align: center">
<%--                                        <tr>
                                            <td>
                                                <asp:Label ID="NoteF" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateF" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteQ" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateQ" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NSY" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteP" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateP" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteR" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateR" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Etat" runat="server" Text="Validé"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="NoteF2" runat="server" Text="B+ "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateF2" runat="server" Text=" 08/07/2014"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteQ2" runat="server" Text="B- "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateQ2" runat="server" Text=" 16/08/2014"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NSY2" runat="server" Text="B"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteP2" runat="server" Text="C+ "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateP2" runat="server" Text=" 16/08/2014"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteR2" runat="server" Text="C "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateR2" runat="server" Text=" 16/08/2014"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Etat2" runat="server" Text="Validé"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="NoteF3" runat="server" Text="A "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateF3" runat="server" Text=" 07/07/2015"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteQ3" runat="server" Text="B "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateQ3" runat="server" Text=" 15/07/2015"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NSY3" runat="server" Text="B+"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="NoteP3" runat="server" Text="B+ "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateP3" runat="server" Text=" 15/07/2015"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="NoteR3" runat="server" Text="A "></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="DateR3" runat="server" Text=" 25/07/2015"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Eta3t" runat="server" Text="En Cours"></asp:Label>
                                            </td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                                <div hidden>
                                    <button
                                    class="btn btn-sm btn-primary button_div pull-right"
                                    style="margin-right: 5px; color:#022451; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                    title="Supprimer"  onmousedown="con007($(this),'B')" 
                                    runat="server" onserverclick="suppHisto"
                                    id="SupprimerHistorique" >
                                    <span class=" glyphicon glyphicon-trash"></span>
                                </button>
                                </div>
                                
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
       <div id="Scriptos" runat="server">

    </div>
    <script>
        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });
        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);

        }
    </script>
</asp:Content>