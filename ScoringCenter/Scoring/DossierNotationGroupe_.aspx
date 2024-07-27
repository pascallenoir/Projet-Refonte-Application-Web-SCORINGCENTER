<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DossierNotationGroupe.aspx.cs" Inherits="ScoringCenter.Scoring.DossierNotationGroupe" %>

<asp:Content ID="HistoriqueNotationMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui " id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui " id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a class="pureCssMenui" style="background-color: #022D65; color: #FFFFFF;" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="" style="z-index: 10;">
                   <li class="pureCssMenui"  id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
		            <li class="pureCssMenui"  id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                    <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" style="background-color: #022D65; color: #FFFFFF;" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui" id="E" runat="server"><a class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                    <li class="pureCssMenui" id="VN" runat="server"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
                </ul>
            </li>
            <li class="pureCssMenui" id="AN" runat="server"><a class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
            <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */ color: #d8d8d8" class="pureCssMenui" href="#" data-toggle="modal" data-target="#">Guide Utilisateur</a></li>
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */ color: #d8d8d8" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style="" id="EBF" runat="server"><a style="/*font-family: cursive; */ color: #d8d8d8" class="pureCssMenui" href="#">Envoi Bilan financier</a></li>
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
                    <h3>Analyse structurelle du groupe</h3>
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
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row">
                                <div class="col-md-12 notation_space" style="margin-bottom:5px;">
                                    <div class="col-lg-3">
                                        <label class="rm" style="font-style:normal"> Modèle de Notation : </label>
                                        <asp:Label ID="ModeleNotation" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-3">
                                        <label class="rm" style="font-style:normal"> Nom du Groupe : </label>
                                        <asp:Label ID="LabelNomDuGroupe" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="affnote" runat="server" style="padding-left: 2px; margin-left: -1%;" class="col-lg-1 col-sm-1 col-md-1 div_circle">
                                                Note Financière&nbsp;: 
                                            <asp:Label ID="NoteGROUPE" runat="server" Text=""></asp:Label>

                                            </div>
                                    
                                    <div class="col-lg-2">
                                        <button class=" btnModifBil btn btn-sm btn-primary button_div pull-right" style="color: #0a8f3a; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" title="Actualiser"
                                                    runat="server" id="BtnEnregistrer" onserverclick="BtnEnregistrer_ServerClick">
                                                    <span class=" glyphicon glyphicon-refresh"></span>
                                                </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" id="ListDHistorique" runat="server">
                            <div class="row" style="margin-top: -0.5%;">
                                <div style=" height:200px; max-height:300px; overflow:auto;">
                                    <table class="table table-bordered table-hover" id="">
                                    <thead>
                                        <tr class="table-heigth1">
                                            <th class="text-center">Filiale</th>
                                            <th class="text-center">Note Retenue</th>
                                            <th class="text-center">Part en chiffre d'affaire </th>
                                            <th class="text-center">Poids économique</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ListDocTableauBord" runat="server" style="text-align: center;">
                                        <%--<tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Sofinex"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="A "></asp:Label><span class="glyphicon glyphicon-arrow-right"></span>
                                                <asp:Label ID="Label4" runat="server" Text="A +"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="50"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text=" %"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="XX"></asp:Label>&nbsp;&nbsp;
                                                <asp:Label ID="Label7" runat="server" Text=" %"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="STIF"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="B "></asp:Label>
                                                <span class="glyphicon glyphicon-arrow-right"></span>
                                                <asp:Label ID="Label10" runat="server" Text="A +"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="25"></asp:Label>
                                                <asp:Label ID="Label12" runat="server" Text=" %"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text="XX"></asp:Label>&nbsp;&nbsp;
                                                <asp:Label ID="Label14" runat="server" Text=" %"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="SOUK SA"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="B "></asp:Label>
                                                <asp:Label ID="Label17" runat="server" Text=" "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="23.8"></asp:Label>
                                                <asp:Label ID="Label19" runat="server" Text=" %"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text="XX"></asp:Label>&nbsp;&nbsp;
                                                <asp:Label ID="Label21" runat="server" Text=" %"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label22" runat="server" Text="Autres"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label23" runat="server" Text=".."></asp:Label>
                                                <asp:Label ID="Label24" runat="server" Text="."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label25" runat="server" Text="1.2"></asp:Label>
                                                <asp:Label ID="Label26" runat="server" Text=" %"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="Label27" runat="server" Text=".."></asp:Label>&nbsp;&nbsp;
                                                <asp:Label ID="Label28" runat="server" Text="."></asp:Label>
                                            </td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                                </div>
                                
                                <div class="col-lg-6 col-sm-6 col-md-6 div_form" style="border-left:none;border-bottom:none;border-top:none">
                                    <div class="" id="CamemberPartFinanciere"  style="height:350px">
                                    </div>
                                </div>
                                <div class="col-lg-6 col-sm-6 col-md-6 div_form"  style="border-right:none;border-bottom:none;border-top:none" >
                                    <div class="" id="CamemberTaux" style="height:350px">
                                    </div>
                                </div>
                            </div>
                        </div>  
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>    
</asp:Content>
