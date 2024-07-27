<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableSessionState="True" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="FicheSignaletique.aspx.cs" Inherits="ScoringCenter.FicheSignaletique" %>

<asp:Content ID="FicheSignaletiqueMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <style>
        .scor_input_transparent {
            border: none;
        }

        .scor_input_visible {
            color: black;
        }
    </style>

    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui active_menu" href="#">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Dossiers de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Effectuer une notation</a></li>
            <li class="pureCssMenui" id="AN" runat="server"><a class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
            <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="color: #d8d8d8" class="pureCssMenui" href="#" data-toggle="modal" data-target="#">Guide Utilisateur</a></li>
                    <li class="pureCssMenui"><a style="color: #d8d8d8" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui Aides" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style="" id="EBF" runat="server"><a style="color: #d8d8d8" class="pureCssMenui" href="#">Envoi Bilan financier</a></li>
            <span class="col-xs-12 sub_menus" style="padding:0; display:none; float:left">
                <span class="col-xs-4" style="text-align:left; padding:10px">
                    
                </span>
                <span class="col-xs-8">
                    <span class="col-xs-12 sub_menus_dn">
                            <li class="pureCssMenu" id="NCP" runat="server"><a class="pureCssMenui" href="#">Notation de la contrepartie</a></li>
                            <li class="pureCssMenu" id="NOP" runat="server"><a class="pureCssMenui" href="#">Notation de l'opération</a></li>
                            <li class="pureCssMenui" id="VN" runat="server"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
                    </span>
                    <span class="col-xs-12">
                        <span style="display:none; float:left" class="sub_menu_ncp">
                            <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                            <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                            <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                            <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                            <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                            <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                        </span>
                        <span style="display:none; float:left" class="sub_menu_nop">
                            <li class="pureCssMenui" id="AOP" runat="server"><a class="pureCssMenui" href="AnalyseOperation.aspx">Analyse de l'opération</a></li>
                            <li class="pureCssMenui" id="E" runat="server"><a class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                        </span>
                    </span>
                </span>
            </span>
        </ul>
    </div>
    <input type="text" value="1" id="TextBoxrec" hidden />
    <input type="text" value="1" id="TextBoxaff" hidden />
    <input type="text" value="1" id="TextBoxDate" hidden />

</asp:Content>

<asp:Content ID="FicheSignaletiqueBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <!--br class="br_top" /-->
        <div class="bigbody">
            <input type="text" runat="server" id="connmou007" hidden />
            <div id="thebody" class="noBackground" >
                <div id="bodyTitle">
                    <h3>Fiche signalétique</h3>
                </div>
                <div class="row inthebody br_topbody" style="margin:0">
                    <div class="row push_entete">
                        <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessageValide" runat="server"></div>
                    </div>

                    <div class="row" id="Panneau1" runat="server" style="margin:0 10px; text-align: left;">
                        <%--hiden--%>

                        <%--<button class="btn pull-right" id="Button1" onserverclick="afficher_input"
                                    runat="server">
                                    <span class="glyphicon glyphicon-pencil"></span>
                           </button>--%>
                        <div class="col-lg-12 col-sm-12 col-md-12" style="padding:0">



                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0;">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                    <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align: center">
                                            <label for="">Identifiants</label>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Raison Sociale :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7" style="font-weight: bold;">
                                                <asp:Label ID="RSocial" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Adresse C.P:
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="Adresse" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Ville :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="CPVille" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Pays :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="Pays" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                N° Régistre du commerce
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblAPE" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="DdlAPE" CssClass="form-control" AutoPostBack="false" Enabled="false"
                                                    runat="server" Height="30"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Identifiant principal :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="IPrincipal" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <%--<div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Siret :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="Siret" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>--%>
                                        <div class="row push_right" runat="server" id="idscoringDiv" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Identifiant scoring center :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="ISCenter" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Type client :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="lblTypeProspect" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Identifiant fiscale :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="lblIdentifFiscal" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-sm-12 col-md-12 ">
                                    <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align: center">
                                            <label for="">Informations bancaires</label>
                                        </div>

                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Segment clientèle :
                                            </div>
                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                <asp:Label ID="LblSClientele" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="DdlSClientele" CssClass="form-control" AutoPostBack="false" Enabled="false"
                                                    runat="server" Height="30"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Banque :
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:Label ID="lblBanque" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Agence :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblAgence" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="DdlAgence" CssClass="form-control" AutoPostBack="false" Enabled="false"
                                                    runat="server" Height="30"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Groupe :
                                            </div>
                                            <div class="col-xs-7">
                                                <asp:Label ID="LblGroupe" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="DdlGroupe" CssClass="form-control" AutoPostBack="false" Enabled="false"
                                                    runat="server" Height="30"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Chiffre d'affaire :
                                            </div>
                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                <asp:Label ID="LblChiffre" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="fill: inherit">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0 0 0 4px;">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                    <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align: center">
                                            <label for="">Activités</label>
                                        </div>

                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Branche d'activité :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblBranche" runat="server"></asp:Label>
                                                <%-- <asp:DropDownList ID="DdlNAF" CssClass="form-control" AutoPostBack="false" Enabled="false"
                                                    runat="server" Height="30"></asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Secteur d'activité :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblNAF2" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Section d'activité (BCEAO):
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="lblSectionActiv" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Activité principale de l'entreprise:
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblNAF" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Statut juridique :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="LblStatut" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Code activité (SYSCOHADA) :
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:Label ID="lblCodeActivite" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-12 col-sm-12 col-md-12">
                                    <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align: center">
                                            <label for="">Informations financières</label>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Modèle d'analyse :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="MAnalyse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;" >
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Unité :
                                            </div>
                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                <asp:Label ID="LblUnite" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Date de clôture :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBDateClotureLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Durée de l'exercice en mois :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBDurreExoMoisLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Type bilan :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBTypeBilLiass" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Nature de l'exercice:
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBNatureExoLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Certification des comptes :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBCertifCompteLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Effectif :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBEffectifLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Chiffre d'affaire :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="lblCA" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Devise :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LblDevise" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row push_right hidden" style="margin-left: -2.5%;">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                Régime fiscal :
                                            </div>
                                            <div class="col-lg-6 col-sm-6 col-md-6">
                                                <asp:Label ID="LBregimFiscalLiasse" runat="server" Text="NC"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="pull-right">
                                    <span class="btn glyphicon glyphicon-pencil pull-right"  title="Modifier" onclick="afficher_input()"></span>
                                </div>--%>


                                <div id="Scriptos" runat="server">
                                </div>
                            </div>

                            <div style="margin-top: -15px;">
                                <button
                                    class="btn btn-sm button_div pull-right"
                                    style="margin-right: 5px; color: #092851; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                    title="Modifier"
                                    runat="server"
                                    id="Button1" onserverclick="afficher_input">
                                    <span class=" glyphicon glyphicon-pencil"></span>
                                </button>
                            </div>
                        </div>

                        <%--hidden2--%>
                    </div>



                    <div class="row" id="Panneau2" runat="server" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">


                        <%--<div class="row">
                            <button class="btn pull-right" id="ValideContrepartie" onserverclick="modifierFiche"
                                runat="server">
                                <span class="glyphicon glyphicon-ok"></span>
                            </button>
                        </div>--%>

                        <%--<div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: 5px;">

                            <div style="margin-top: -15px; margin-bottom: 5px;">

                                <button
                                    class="btn btn-sm btn-primary button_div pull-right" onmousedown="cacher_input()"
                                    style="margin-right: 5px; color: rgba(204, 92, 11, 0.84); background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                    title="Annuler" value="Annuler"
                                    runat="server"
                                    id="BtAnnuler" onserverclick="cacher_input">
                                    <span class=" glyphicon glyphicon-remove"></span>
                                </button>
                                <button
                                    class="btn btn-sm btn-primary button_div pull-right" onmousedown="con007($(this),'B')"
                                    style="margin-right: 5px; color: #0a8f3a; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                    title="Valider"
                                    runat="server"
                                    id="ValideContrepartie" onserverclick="modifierFiche">
                                    <span class=" glyphicon glyphicon-ok"></span>
                                </button>

                            </div>

                        </div>--%>


                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: -5%; text-align: left;">
                            <div class="col-lg-12 col-sm-12 col-md-12" style="padding: 0;">
                                <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0;">
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Identifiants</label>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Raison sociale :
                                                                                 <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" class="form-control" onchange="con007($(this),'T')" runat="server" id="Nom" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Adresse C.P :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" class="form-control" onchange="con007($(this),'T')" runat="server" id="adr" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    ville :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" id="Ville" class="form-control" onchange="con007($(this),'T')" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Pays :
                                                                                <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" class="form-control" runat="server" readonly id="paysLab" style="width: 76%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                    <input type="text" class="form-control" id="TbPays1" onchange="con007($(this),'T')" runat="server" style="width: 76%; height: 85%; display: none" />
                                                </div>
                                                <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left: -17%">
                                                    <a class="btn btn-sm btn-primary" title="Rechercher" id="SearchPays" runat="server" style="height: 24px; background-color: #c3c3c3; color: #1f1c33; border: none; padding-top: 2.5px; padding-bottom: 0px;">
                                                        <span class=" glyphicon glyphicon-search"></span></a>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-xs-4">
                                                    Identifiant principal :
                                                </div>
                                                <div class="col-xs-7">
                                                    <asp:Label ID="lblIdentifPrincipalP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-xs-4">
                                                    Identifiant scoring :
                                                </div>
                                                <div class="col-xs-7">
                                                    <asp:Label ID="lblIdentifScorP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-xs-4">
                                                    Type client :
                                                </div>
                                                <div class="col-xs-7">
                                                    <asp:Label ID="lblTypeClientP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right hidden" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Identifiant fiscal :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" onchange="con007($(this),'T')" id="IdentFisc" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>
                                            <div class="row push_right hidden" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    N° Régistre du commerce :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" onchange="con007($(this),'T')" id="Rccm" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-sm-12 col-md-12">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Informations bancaires</label>
                                            </div>
                                            <div class="row push_right hidden" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Segment clientèle 
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" id="Segment" onchange="con007($(this),'T')" value="Segment ()" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-xs-4">
                                                    Banque :
                                                </div>
                                                <div class="col-xs-7">
                                                    <asp:Label ID="lblBanqueP2" runat="server" Text=""></asp:Label>                                                                            
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Agence :
                                                                                <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <select runat="server" id="DdlAgence" onchange="combo007($(this),'C')" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                                        <option></option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Groupe :
                                                    <%--<label id="EtoilGroupe_" style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8">
                                                    <asp:DropDownList ID="DdlGroup" CssClass="form-control"
                                                        runat="server" Height="24" Style="font: bold 11px arial,verdana; padding: -1%; padding-top: 0%; padding-bottom: 0%; width: 86%;">
                                                        <asp:ListItem>NON</asp:ListItem>
                                                        <asp:ListItem>OUI</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Groupe :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" class="form-control" id="Tbgroupe" runat="server" readonly style="width: 76%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                    <input type="text" class="form-control" id="Tbgroupe1" runat="server" style="width: 76%; height: 85%; display: none" />
                                                </div>
                                                <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left: -17%">
                                                    <a class="btn btn-sm btn-primary" title="Chercher l'agence" id="SearchGroupe" runat="server" style="height: 24px; background-color: #c3c3c3; color: #1f1c33; border: none; padding-top: 2.5px; padding-bottom: 0px;">
                                                        <span class=" glyphicon glyphicon-search"></span></a>
                                                </div>
                                            </div>

                                            <div class="row push_right hidden" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Chiffre d'affaire :
                                                <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" id="Ca" onchange="con007($(this),'T')" class="form-control numeric" runat="server" style="width: 76%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                                <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left: -17%; margin-bottom: -50%">
                                                    <asp:Label ID="DeviseLabel" runat="server" Text=""> </asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0 0 0 4px;">
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Activités</label>
                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;" hidden="hidden">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Branche  d'activité
                                                    <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <asp:DropDownList ID="DdlBranchActiv" AutoPostBack="true" onchange="combo007($(this),'C')" CssClass="form-control" runat="server" Width="100%" Style="height: 24px; padding-top: 0px; padding-bottom: 0px;" OnSelectedIndexChanged="DdlBranchActiv_SelectedIndexChanged1">
                                                    </asp:DropDownList>
                                                    <%--<asp:DropDownList ID="DdlBranchActiv" AutoPostBack="true"  onchange="combo007($(this),'C')" CssClass="form-control" runat="server" Width="100%" Style="height: 24px; padding-top: 0px; padding-bottom: 0px;" OnSelectedIndexChanged="DdlBranchActiv_SelectedIndexChanged">--%>
                                                    <%--</asp:DropDownList>--%>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Section d'activité (BCEAO) :
                                                                                <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:DropDownList ID="DdlSecteurActive1" AutoPostBack="false" onchange="combo007($(this),'C')" CssClass="form-control" runat="server" Width="100%" Style="height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                                    </asp:DropDownList>
                                                    <%--<asp:DropDownList ID="DropDownList2" AutoPostBack="true"  onchange="combo007($(this),'C')"  CssClass="form-control" runat="server" Width="100%" Style="height: 24px; padding-top: 0px; padding-bottom: 0px;" OnSelectedIndexChanged="DdlSecteurActive1_SelectedIndexChanged">
                                                    </asp:DropDownList>--%>
                                                </div>
                                            </div>

                                            <div class="row push_right hidden" style="margin-left: 6%;">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Activité principale de l'entreprise
                                                                                <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" class="form-control" runat="server" readonly id="TbActivite" style="width: 76%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                    <input type="text" class="form-control" id="TbActivite1" runat="server" style="width: 76%; height: 85%; display: none" />
                                                </div>
                                                <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left: -17%">
                                                    <a class="btn btn-sm btn-primary" title="Chercher l'agence" id="SearchActivite" runat="server" style="height: 24px; background-color: #c3c3c3; color: #1f1c33; border: none; padding-top: 2.5px; padding-bottom: 0px;">
                                                        <span class=" glyphicon glyphicon-search"></span></a>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Statut juridique :
                                                                         <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <select runat="server" id="DdlStatut" onchange="combo007($(this),'C')" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                                        <option></option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Code activité (SYSCOHADA) :
                                                                         <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblCodeActivSYSCOHADA" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Informations financières</label>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Modèle d'analyse :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblModelAnalP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            
                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Date de clôture :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblDateClotP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Durée de l'exercice en mois :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblDureeExerP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Type bilan :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblTypeBilanP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Nature de l'exercice :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblNatureExercP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>
                                            
                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Chiffre d'affaire :
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:Label ID="lblCAP2" runat="server" Text="NC"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 3%;">
                                                <div class="col-xs-1" style="width: 42%; padding-right:0;">
                                                    Devise
                                                    <%--<label style="color: red">*</label>--%>
                                                </div>
                                                <div class="col-xs-1" style="width: 55%;">
                                                    <asp:DropDownList ID="DeviseD" onchange="combo007($(this),'C')" AutoPostBack="false" CssClass="form-control" runat="server" Width="100%" Style="height: 24px; padding-top: 0px; padding-bottom: 0px;" OnSelectedIndexChanged="DeviseD_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5">
                                                </div>

                                                <div class="col-lg-3 col-sm-3 col-md-3">
                                                    <%--<button  type="button" id="AjouterFiliale" style="height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover">Ajouter Filiale</button>--%>
                                                    <button type="button" id="ModifierrFiliale" runat="server" style="height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover">Voir ou Modifier Filiale(s)</button>
                                                </div>

                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;" hidden>
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Unité
                                                                                 <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">

                                                    <select runat="server" id="DblUntie" onchange="combo007($(this),'C')" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                                        <option value="MILLIERS">Milliers</option>
                                                        <option value="MILLIONS">Millions</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;" hidden>
                                                <div class="col-lg-5 col-sm-5 col-md-5">
                                                    Entreprise en création 
                                                                                <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-3 col-sm-3 col-md-3">
                                                    <input type="radio" id="R_non" runat="server" checked />
                                                    NON
                                                </div>
                                                <div class="col-lg-3 col-sm-3 col-md-3">
                                                    <input type="radio" id="R_oui" runat="server" />
                                                    OUI
                                                </div>

                                            </div>

                                            <div class="row push_right" style="margin-left: 6%;" hidden="hidden">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Type analyse ANFI
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <select runat="server" id="TypeAnalyse" onchange="combo007($(this),'C')" class="form-control" style="width: 99%; height: 24px; padding-top: 0px; padding-bottom: 0px;">

                                                        <option value="Systeme Normal">Systeme Normal</option>
                                                        <option value="Systeme Allege">Systeme Allege</option>
                                                        <option value="Systeme Minimal De Tresorerie">Systeme Minimal De Tresorerie</option>
                                                    </select>
                                                </div>

                                            </div>
                                            <div class="row push_right" style="margin-left: 6%;" hidden="hidden">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    Note groupe 
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7">
                                                    <input type="text" id="N_groupe" onchange="combo007($(this),'C')" class="form-control" maxlength="2" runat="server" style="width: 30%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-sm-12 col-md-12 hidden" style="margin-left: 30%">
                                        (
                                                                <label style="color: red">*</label>) Champs Obligatoires
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: 5px;">
                                        <div style="margin-top: -4%; margin-bottom: 5px;">
                                            <button
                                                class=" btn btn_cergicolor btn_hover pull-right" onmousedown="con007($(this),'B')"
                                                style="height: 25px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                                title="Valider"
                                                runat="server"
                                                id="ValideContrepartie" onserverclick="modifierFiche">
                                                Enregistrer
                                            </button>
                                            <button
                                                class="btn btn_hover pull-right" onmousedown="cacher_input()"
                                                style="height: 25px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                                title="Annuler" value="Annuler"
                                                runat="server"
                                                id="BtAnnuler" onserverclick="cacher_input">
                                                Annuler
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row push_entete">
                            <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessage" runat="server"></div>
                        </div>
                    </div>


                    <div id="MSearchActivite" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close closeX" data-dismiss="modal"
                                        style="color: white;">
                                        &times;</button>
                                    <strong>Recherche des secteurs d’activité </strong>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Saisir code activité économique</i><br />
                                            <asp:TextBox runat="server" ID="TbSearchActivite" Height="28"
                                                CssClass="form-control" Width="205"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Sélectionner code activité économique</i><br />
                                            <asp:ListBox ID="ListActivite" runat="server" SelectionMode="Single" Rows="10"
                                                CssClass="List_Width form-control textStyle"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <%--data-backdrop="static"--%>
                    <div id="MAjouterFiiale" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close closeX" data-dismiss="modal"
                                        style="color: white;">
                                        &times;</button>
                                    <strong>Ajoute de(s) filiale(s) </strong>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-11 col-sm-11 col-md-11">
                                            <div class="col-lg-7 col-sm-7 col-md-7" style="text-align: left">
                                                <i>Saisir identifiant ou nom de la filiale</i><br />
                                                <asp:TextBox runat="server" ID="ImpFiliale" Height="28"
                                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                                                <asp:TextBox runat="server" ID="Idscor" Height="28"
                                                    CssClass="form-control hide" Width="205"></asp:TextBox><br />
                                                <asp:TextBox runat="server" ID="Idscor1" Height="28"
                                                    CssClass="form-control hide" Width="205"></asp:TextBox><br />
                                            </div>
                                            <div class="col-lg-5 col-sm-5 col-md-5" style="text-align: right">
                                                <a href="javascript:;" class="btn btn-primary" id="ValFiliale" style="margin-left: 50%;"><i class="">Valider</i></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-11 col-sm-11 col-md-11" style="text-align: left">
                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                <i>Sélectionner la filiale</i><br />
                                                <asp:ListBox ID="ListeFiliale1" runat="server" SelectionMode="Single" Rows="10"
                                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                                            </div>
                                            <div class="col-lg-2 col-sm-2 col-md-2">
                                                <a href="javascript:;" class="btn btn-primary" id="chaineright" runat="server" style="margin-top: 90%; margin-left: 50%;"><i class="glyphicon glyphicon-chevron-right"></i></a>
                                                <br />
                                                <br />
                                                <a href="javascript:;" class="btn btn-primary" id="chaineleft" runat="server" style="margin-left: 50%;"><i class="glyphicon glyphicon-chevron-left"></i></a>
                                            </div>

                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                <i>Filiales Sélectionner</i><br />
                                                <asp:ListBox ID="ListeFiliale2" runat="server" SelectionMode="Single" Rows="10"
                                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                                                <asp:ListBox ID="ListeFiliale3" runat="server" SelectionMode="Single" Rows="10"
                                                    CssClass="List_Width form-control textStyle hide"></asp:ListBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row hide" id="Deja">
                                        <div class="col-lg-11 col-sm-11 col-md-11" style="text-align: left">
                                            <label>Déjà Ajouuter</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="MSearchGroupe" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close closeX" data-dismiss="modal"
                                        style="color: white;">
                                        &times;</button>
                                    <strong>Recherche du groupe</strong>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Saisir le groupe recherché</i><br />
                                            <asp:TextBox runat="server" ID="TbSearchGroupe" Height="28"
                                                CssClass="form-control" Width="205"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Sélectionner le groupe</i><br />
                                            <asp:ListBox ID="ListGroupe" runat="server" SelectionMode="Single" Rows="10"
                                                CssClass="List_Width form-control textStyle"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="MSearchPays" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close closeX" data-dismiss="modal"
                                        style="color: white;">
                                        &times;</button>
                                    <strong>Recherche de Pays </strong>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Saisir le pays recherché</i><br />
                                            <asp:TextBox runat="server" ID="TbSearchPays" Height="28"
                                                CssClass="form-control" Width="205"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                            <i>Sélectionner le pays</i><br />
                                            <asp:ListBox ID="ListPays" runat="server" SelectionMode="Single" Rows="10"
                                                CssClass="List_Width form-control textStyle"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="PasvalideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header" id="vvPas">
                                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                                    <strong id="vvvPas" style="float: left; margin-left: 2%">
                                        <asp:Label ID="lblPasValideTitreConsult" runat="server" /></strong>
                                </div>
                                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                                        <p id="gfdPas" style="color: black; font-weight: bolder">
                                            <asp:Label ID="lblPasValidemessageConsult" runat="server" />
                                        </p>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">OK</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
                        data-toggle="modal" data-target="#PasvalideConsult">
                        Launch demo modal
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div id="ses" runat="server"></div>
    <script>
        $(function () {

            $("#<%=LblUnite.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblDevise.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=MAnalyse.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblStatut.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblNAF.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblNAF2.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblBranche.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblAPE.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblChiffre.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblGroupe.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblAgence.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=LblSClientele.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=ISCenter.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=IPrincipal.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=Pays.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=CPVille.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=Adresse.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            $("#<%=RSocial.ClientID%>").removeClass('scor_input_visible').addClass('scor_input_transparent').prop('disabled', true);
            //afficher_input();
            //if ($("#TextBoxaff").val()=="0"){
            //    $("#Panneau1").hide();
            //    $("#Panneau2").show();
            //    $("#TextBoxaff").val("1");
            //}
            //else {
            //    $("#Panneau2").hide();
            //    $("#Panneau1").show();
            //    $("#TextBoxaff").val("1");
            //}

        })
        function afficher_input() {

            $("#<%=Panneau1.ClientID%>").hide();
            $("#<%=Panneau2.ClientID%>").show();
            $("#TextBoxrec").val("0");


        }

        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $(document).ready(function () {
            $('.numeric').numeric(this, 0);
            $('.number').number(this, 0);

        });
        $(document).ready(function () {

            $("#<%=LblNAF.ClientID%>").text(($("#<%=LblNAF.ClientID%>").text().substring(0, 30)));
        });


            $(document).ready(function () {
                $("#<%=SearchPays.ClientID%>").on("click", function (e) {
                    $('#MSearchPays').modal('show');
                });

                $("#<%=ListPays.ClientID%>").on("click", "option", function (e) {
                    var value = "";
                    var listBox = document.getElementById("<%=ListPays.ClientID%>");
                    for (var i = 0; i < listBox.options.length; i++) {
                        if (listBox.options[i].selected) {
                            value = value + listBox.options[i].innerHTML;
                        }
                    }

                    if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                        $("#<%=paysLab.ClientID%>").val(value);
                        $("#<%=TbPays1.ClientID%>").val($("#<%=ListPays.ClientID%>").val());

                    }
                    else {
                        $("#<%=paysLab.ClientID%>").val();
                    }
                    $("#MSearchPays").modal('hide');
                    return false;
                });
                $("#<%=TbSearchPays.ClientID%>").on('input', function (e) {
                    $("#<%=ListPays.ClientID%>").empty();
                    if ($.trim($("#<%=TbSearchPays.ClientID%>").val()) != "") {
                        var text = $("#<%=TbSearchPays.ClientID%>").val();
                        $.ajax({
                            type: "POST",
                            url: "Contrepartie.aspx/ListPaysReach",
                            data: "{'text': '" + text + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            beforeSend: function () { },
                            success: function (response) {
                                $("#<%=ListPays.ClientID%>").append(response.d[0]);
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                    }
                });
            });

            //Recherche de groupe'

            $(document).ready(function () {
                $("#<%=SearchGroupe.ClientID%>").on("click", function (e) {
                    $('#MSearchGroupe').modal('show');
                });

                $("#<%=ListGroupe.ClientID%>").on("click", "option", function (e) {
                    var value = "";
                    var listBox = document.getElementById("<%=ListGroupe.ClientID%>");
                    for (var i = 0; i < listBox.options.length; i++) {
                        if (listBox.options[i].selected) {
                            value = value + listBox.options[i].innerHTML;
                        }
                    }

                    if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                        $("#<%=Tbgroupe.ClientID%>").val(value);
                        $("#<%=Tbgroupe1.ClientID%>").val($("#<%=ListGroupe.ClientID%>").val());
                    }
                    else {
                        $("#<%=Tbgroupe.ClientID%>").val();
                    }
                    $("#MSearchGroupe").modal('hide');
                    return false;
                });

                $("#<%=TbSearchGroupe.ClientID%>").on('input', function (e) {
                    $("#<%=ListGroupe.ClientID%>").empty();
                    if ($.trim($("#<%=TbSearchGroupe.ClientID%>").val()) != "") {
                        var text = $("#<%=TbSearchGroupe.ClientID%>").val();
                        $.ajax({
                            type: "POST",
                            url: "FicheSignaletique.aspx/searchGroupe",
                            data: "{'text': '" + text + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            beforeSend: function () { },
                            success: function (response) {
                                $("#<%=ListGroupe.ClientID%>").append(response.d[0]);
                            },
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                        }
                });
            });


                //Recherche secteur d'activité'

                $(document).ready(function () {
                    $("#<%=SearchActivite.ClientID%>").on("click", function (e) {
                    $('#MSearchActivite').modal('show');
                });

                $("#<%=ListActivite.ClientID%>").on("click", "option", function (e) {
                    var value = "";
                    var listBox = document.getElementById("<%=ListActivite.ClientID%>");
                    for (var i = 0; i < listBox.options.length; i++) {
                        if (listBox.options[i].selected) {
                            value = value + listBox.options[i].innerHTML;
                        }
                    }

                    if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                        $("#<%=TbActivite.ClientID%>").val(value);
                        $("#<%=TbActivite1.ClientID%>").val($("#<%=ListActivite.ClientID%>").val());

                    }
                    else {
                        $("#<%=TbActivite.ClientID%>").val();
                    }
                    $("#MSearchActivite").modal('hide');
                    return false;
                });

                $("#<%=TbSearchActivite.ClientID%>").on('input', function (e) {
                    $("#<%=ListActivite.ClientID%>").empty();
                    if ($.trim($("#<%=TbSearchActivite.ClientID%>").val()) != "") {
                        var text = $("#<%=TbSearchActivite.ClientID%>").val();
                        $.ajax({
                            type: "POST",
                            url: "FicheSignaletique.aspx/ActiviteBCAO",
                            data: "{'text': '" + text + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            beforeSend: function () { },
                            success: function (response) {
                                $("#<%=ListActivite.ClientID%>").append(response.d[0]);
                            },
                            failure: function (response) {
                                alert(response.d);
                            }
                        });
                        }
                });
            });
                var chaine = "";
                $(document).ready(function () {
                    var ladate = new Date();
                    chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
                });
                function O42451(chain) {
                    chaine = chaine + "@" + chain;
                    $("#<%=connmou007.ClientID%>").val(chaine);

                }


                //$("#AjouterFiliale").on("click", function (e) {
                //    $('#MAjouterFiiale').modal('show');
                //});
                $("#<%=ModifierrFiliale.ClientID%>").on("click", function (e) {
            $("#<%=ListeFiliale1.ClientID%>").empty();
                $("#<%=ImpFiliale.ClientID%>").val('');
                $('#MAjouterFiiale').modal('show');

            });


            $("#<%=chaineleft.ClientID%>").click(function () {
            $("#<%=ListeFiliale2.ClientID%> option:selected").remove();
            });

            $("#<%=chaineright.ClientID%>").click(function () {

            var liste1Value = $("#<%=ListeFiliale1.ClientID%>").find("option:selected").text();
            if (liste1Value === "") {
                alert("Veuillez sélèctionner  un utilisateur");
                $("#Deja").addClass("hide");
            }

            if (existeVal() === true) {
                //$("#Deja").removeClass("hide");
            } else {
                //$("#Deja").addClass("hide");

                $("#<%=ListeFiliale2.ClientID%>").append("<option value=\"" + liste1Value.split("-")[0] + "\">" + liste1Value + "</option>");
            }
        });

        $(document).ready(function () {

            $("#<%=ListeFiliale2.ClientID%>").empty();
            $("#<%=ListeFiliale3.ClientID%>").empty();
            var text = $("#<%=ImpFiliale.ClientID%>").val();

            $.ajax({
                type: "POST",
                url: "FicheSignaletique.aspx/VoirFiliale",
                data: "{'text': '" + text + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    $("#<%=ListeFiliale2.ClientID%>").append(response.d[0]);
                        $("#<%=ListeFiliale3.ClientID%>").append(response.d[0]);


                        var tab1 = [];
                        var index1 = $("#<%=ListeFiliale2.ClientID%> option").size();

                    if (index1 > 0) {
                        $("#<%=ListeFiliale3.ClientID%> option").each(function (i) {
                            tab1.push($(this).val());
                        });

                        var chaine1 = '';
                        if (tab1.length > 0) {
                            for (var k = 0; k < tab1.length; k++) {
                                if (chaine1 === '') {

                                    chaine1 = tab1[k].trim();

                                } else {
                                    chaine1 = chaine1 + ';' + tab1[k].trim();

                                }
                            }

                            $("#<%=Idscor1.ClientID%>").val(chaine1);

                        }
                    }
                        if ($("#<%=MAnalyse.ClientID%>").text() === "Groupe") {
                            $("#ValFiliale").click();
                        }
                    },
                    failure: function (response) {

                    }
                });

            //alert();

        });

            $(document).ready(function () {
                $("#<%=ImpFiliale.ClientID%>").on('input', function (e) {
                $("#<%=ImpFiliale.ClientID%>").attr('disabled', 'disabled');
                $("#<%=ListeFiliale1.ClientID%>").empty();
                $("#<%=ImpFiliale.ClientID%>").removeAttr('disabled');
                $("#<%=ImpFiliale.ClientID%>").focus();

                if ($.trim($("#<%=ImpFiliale.ClientID%>").val()) != "") {
                    var text = $("#<%=ImpFiliale.ClientID%>").val();
                    $.ajax({
                        type: "POST",
                        url: "Contrepartie.aspx/AjouterFiliale",
                        data: "{'text': '" + text + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function () { },
                        success: function (response) {
                            $("#<%=ListeFiliale1.ClientID%>").append(response.d[0]);
                            $("#<%=ImpFiliale.ClientID%>").focus();
                        },
                        failure: function (response) {
                            alert(response.d);
                            $("#<%=ImpFiliale.ClientID%>").focus();
                        }
                    });
                }
            });
        });

        $("#ValFiliale").on("click", function (e) {

            var tab = [];
            var index = $("#<%=ListeFiliale2.ClientID%> option").size();

        if (index > 0) {
            $("#<%=ListeFiliale2.ClientID%> option").each(function (i) {
                tab.push($(this).val());
            });

            var chaine = '';
            if (tab.length > 0) {
                for (var k = 0; k < tab.length; k++) {
                    if (chaine === '') {

                        chaine = tab[k].trim();

                    } else {
                        chaine = chaine + ';' + tab[k].trim();

                    }
                }

                $("#<%=Idscor.ClientID%>").val(chaine);

            }
            $('#MAjouterFiiale').modal('hide');
            //$("#Deja").addClass("hide");
            //$("#AjouterFiliale").addClass("hide");
            //$("#ModifierrFiliale").removeClass("hide");
        } else {
            //$("#Deja").removeClass("hide");
        }
    });
    //ValFiliale ModifierrFiliale
    //Idscor
    function existeVal() {

        var liste2Value = $("#<%=ListeFiliale1.ClientID%>").val();
        var tab = [];
        var index = $("#<%=ListeFiliale2.ClientID%> option").size();

            var existe = false;
            if (index > 0) {
                $("#<%=ListeFiliale2.ClientID%> option").each(function (i) {
                    tab.push($(this).val());
                });

                if (tab.length > 0) {
                    for (var k = 0; k < tab.length; k++) {
                        var tabl = tab[k];
                        if (liste2Value.trim() === tabl.trim()) {
                            existe = true;
                        }
                    }
                }
            }
            return existe;
        }

    </script>
</asp:Content>
