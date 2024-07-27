<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IntegrationGroupe.aspx.cs" Inherits="ScoringCenter.Scoring.IntegrationGroupe" %>

<asp:Content ID="IntegrationGroupeMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    
    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu pureCssMenum">                 
	        <li class="pureCssMenui"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui "><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui "><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalitique</a></li>
            <li class="pureCssMenui"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="pureCssMenum" style="z-index: 10;">
		            <li class="pureCssMenui"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="Integ_Group" runat="server"><a style=" background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui"><a  class="pureCssMenui" href="Encours.aspx">EnCours</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de note</a></li>
                </ul>
            </li>
            <li class="pureCssMenui"><a class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
	        <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="pureCssMenum" style="z-index: 10;">
                    <li class="pureCssMenui"><a class="pureCssMenui" href="#">Guide utilisateur</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="#">Modèle de notation</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style=""><a class="pureCssMenui" href="EnvoiBilanFinancier.aspx">Envoi Bilan financier</a></li>
        </ul>
    </div>

</asp:Content>

<asp:Content ID="IntegrationGroupeBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <br class="br_top" />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Intégration Groupe</h3>
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
                                                    Text="Identifiant Principal : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="Idprincip" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-5 col-sm-5 col-md-5 text-left">
                                            <b>
                                                <asp:Label ID="SActivité" CssClass="boldSize" runat="server"
                                                    Text="Secteur d'Activité : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="AEntreprise" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row contreparie_info_2">
                                        <div class="col-lg-4 col-sm-4 col-md-4 text-left">
                                            <b>
                                                <asp:Label ID="Sren" runat="server" CssClass="boldSize"
                                                    Text="Activité BCEAO : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="Siren" runat="server" Text=""></asp:Label>
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
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row">
                                <div class="col-md-12 notation_space">
                                    <div class="col-xs-6">
                                        <label class="rm" style="font-style: normal">Nom du Groupe : </label>
                                        <asp:Label ID="NomGroupe" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-xs-2 col-xs-offset-1 notation_note">
                                        <label class="rm">Note Groupe : </label>
                                        <asp:Label ID="NoteGroupe" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 rmp">
                            <div class="col-md-9 rmp" id="EspaceQuestionnaire" runat="server">
                            </div>
                            <div class="col-md-3 rmd">
                                <div class="col-md-12 alert alert-info fade in" runat="server" id="notifMessage">Note_val Null</div>
                                <div class="col-md-12 div_form" style="height: 284px; overflow: auto" runat="server" id="treeDiv">
                                    <div class="tree">
                                        <ul>
                                            <li>
                                                <span class="borderStep">
                                                    <asp:Label ID="TNomGroupe" runat="server"></asp:Label>
                                                    : A</span>
                                                <ul runat="server" id="ListFiliale"></ul>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 10px;">
                            <asp:Button ID="btnEnregistrerNote" runat="server" CssClass="btn btn_cergicolor btn_hover" Text="Enregistrer" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
           
         });

         function myload() {
            
         }

         function get_docs() {
             
         }
    </script>

</asp:Content>
