<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnvoiBilanFinancier.aspx.cs" Inherits="ScoringCenter.Scoring.EnvoiBilanFinancier" %>

<asp:Content ID="EnvoiBilanFinancierMenu" ContentPlaceHolderID="ContentMenu" runat="server">

     <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui " id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui " id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Dossiers de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="#">Effectuer une notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                    <li class="pureCssMenui" id="AQ" runat="server"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui" id="RP" runat="server"><a <%--style="color:#d8d8d8"--%> class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
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
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui Aides" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style="" id="EBF" runat="server"><a style="/*font-family: cursive; */ color: #d8d8d8" class="pureCssMenui" href="#">Envoi Bilan financier</a></li>
        </ul>
    </div>

</asp:Content>

<asp:Content ID="EnvoiBilanFinancierBody" ContentPlaceHolderID="ContentBody" runat="server">
   
    <div id="Content" class="Content">
        <br class="br_top" />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Chargement des documents financiers</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%;  margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="max-height: 25%; overflow: hidden;">
                                    <div class="row contreparie_info_1">
                                        <div class="col-xs-4 text-left">
                                            <b>
                                                <asp:Label ID="Rsocial" runat="server" CssClass="boldSize"
                                                    Text="Raison Sociale : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="NClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">

                                            <b>
                                                <asp:Label ID="Iprincipal" CssClass="boldSize" runat="server"
                                                    Text="Id principal : "></asp:Label></b>
                                            <asp:Label ID="Idprincip" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-5 text-left">
                                            <b>
                                                <asp:Label ID="Sren" runat="server" CssClass="boldSize"
                                                    Text="Act. SYSCOHADA : "></asp:Label></b> &nbsp;
                                            <asp:Label ForeColor="#cc0000" ID="Siren" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row contreparie_info_2">
                                        <div class="col-xs-1 text-left">
                                            <asp:Label ID="SaiTypeClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">
                                            <b>
                                                <asp:Label ID="Groupe" runat="server" CssClass="boldSize"
                                                    Text="Groupe : "></asp:Label></b> &nbsp;
                                                <asp:Label ID="SaiGroupe" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">
                                            <%--<b>
                                                    <asp:Label ID="Label6" CssClass="boldSize" runat="server" Text="Id SC : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="IdScoringCenter" runat="server" Text=""></asp:Label>--%>

                                                <b>
                                                    <asp:Label ID="Label7" CssClass="boldSize" runat="server" Text="Banque : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="SigleBanq" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-2 text-left">
                                            <b>
                                                <asp:Label ID="LbChiffre" CssClass="boldSize" runat="server" Text="CA : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="ChiffreAffaire" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-2 text-left">
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
                            <div class="row div_form">
                                <div class="col-lg-12 col-sm-12 col-md-12">
                                    <div class="row push_fulltable col-lg-12 col-sm-12 col-md-12" >
                                        <div class="col-lg-3 col-sm-3 col-md-3">
                                            <asp:DropDownList ID="DdlRubrique" CssClass="form-control Ddlsize" AutoPostBack="false"
                                                runat="server" Height="30" Width="150">
                                                <asp:ListItem>Bilan</asp:ListItem>
                                                <asp:ListItem>Compte de Résultat</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3" style="margin-top: 0.5%; margin-left: -5%;">
                                            <asp:Label ID="Annee" runat="server" Text="Saisir dernier exercice"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3" style="margin-left: -0.5%;">
                                            <%--<asp:TextBox runat="server" ID="datepicker" CssClass="form-control Ddlsize" Width="60"></asp:TextBox>--%>
                                            <select runat="server" id="datepicker" class="form-control" style="Height:28px; Width:100px">
                                                <option></option>
                                            </select>
                                            
                                        </div>
                                        <%--<div class="col-lg-2 col-sm-2 col-md-2 " style="margin-top: 0.5%; margin-left: -5%;">
                                            <asp:Label ID="LbDossier" runat="server" Text="Dossier Client"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3 " style="margin-left: -3.5%;">
                                            <asp:TextBox runat="server" ID="NumDossier" Enabled="true" MaxLength="10" CssClass="form-control Ddlsize" Width="100"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="col-lg-1 col-sm-1 col-md-1 " style="margin-left: -13.7%; margin-top: 0.2%;">
                                            <a href="#ButtonDossier" data-toggle="modal" data-target="#ButtonDossier">
                                                <button style="font-weight: bold;" class="btn btn-sm btn-primary" type="button"
                                                    data-toggle="tooltip" title="Rechercher dossier client" onclick="getDossiers()">
                                                    ...</button>
                                            </a>
                                            <a href="#myModal" data-toggle="modal" data-target="#ButtonDossier">
                                                <button style="font-weight: bold;" class="btn btn-sm btn-primary" type="button"
                                                    data-toggle="tooltip" title="Rechercher dossier client" onclick="getDossiers()">
                                                    ...</button>
                                            </a>
                                        </div>--%>

                                        <div class="col-lg-2 col-sm-2 col-md-2" style="margin-top: 0.5%">
                                            <input id="fichier" type="file" runat="server" class="" name="fic_name" contenteditable="false" accept=".txt, .csv" required="required" />
                                        </div>
                                    </div>
                                    <div class="row push_entete">
                                        
                                    </div>
                                    <div class="row push_entete">
                                        <div class="col-lg-1 col-sm-1 col-md-1 col-lg-offset-5 col-sm-offset-5 col-md-offset-5" style="margin-top: 0.5%">
                                            <asp:Button ID="Envoyer" runat="server" CssClass="btn btn_cergicolor btn_hover" OnClick="Envoyer_Click" Text="Envoyer" />
                                        </div>
                                    </div>
                                    <div class="row push_entete">
                                        <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessage" runat="server"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="ButtonDossier" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal" 
                            style="color: white;">&times;</button>
                        <strong>RECHERCHE DU NUMERO DE DOSSIER</strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="margin-top:-1%;">
                                <i>Sélectionner le dossier client</i><br />
                                <asp:ListBox ID="ListDClient" runat="server" SelectionMode="Single" Rows="15" 
                                    CssClass="List_Width"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Scriptos" runat="server">

    </div>
    </div>

    <script>
        $(".filecss").fileinput({
            showUpload: false,
            showCaption: false,
            browseClass: "btn btn-primary btn-lg",
            fileType: "any",
            previewFileIcon: "<i class='glyphicon glyphicon-king'></i>"
        });

        <%--$(function () {
            $('#<%=datepicker.ClientID%>').datepicker({
                changeYear: true,
                showButtonPanel: true,
                dateFormat: 'yy',
                onClose: function (dateText, inst) {
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).datepicker('setDate', new Date(year, 1));
                }
            }).focus(function () {
                $(".ui-datepicker-calendar").hide();
            });
            $("#<%=datepicker.ClientID%>").focus(function () {
                $(".ui-datepicker-month").hide();
            });
        });--%>

        $(document).ready(function () {
            //Initialize Select2 Elements
            $(".select2").select2();
            //---------------------
            $("#<%=ListDClient.ClientID%>").on("dblclick", "option", function (e) {
                $('#ButtonDossier').modal('hide');
            })
        });
    </script>

</asp:Content>