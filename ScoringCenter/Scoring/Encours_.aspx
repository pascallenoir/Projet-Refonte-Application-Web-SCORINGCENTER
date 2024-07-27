<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encours.aspx.cs" Inherits="ScoringCenter.Scoring.Encours" %>

<asp:Content ID="EncoursMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <style>
        .gly-flip-vertical {
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=2, mirror=1);
            -webkit-transform: scale(1, -1);
            -moz-transform: scale(1, -1);
            -ms-transform: scale(1, -1);
            -o-transform: scale(1, -1);
            transform: scale(1, -1);
        }

        .le_nom_de_ ton_textarea {
            scrollbar-face-color: red;
            scrollbar-shadow-color: pink;
            scrollbar-highlight-color: black;
            scrollbar-3dlight-color: lime;
            scrollbar-darkshadow-color: yellow;
            scrollbar-track-color: green;
            scrollbar-arrow-color: white;
        }
    </style>
    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui " id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui " id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                    <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui" <%--style="color:#d8d8d8"--%> href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui" id="E" runat="server"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Encours.aspx">Encours</a></li>
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

<asp:Content ID="EncoursBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <br class="br_top" />
        <input type="text" runat="server" id="connmou007" hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Encours</h3>
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

                                <div class="col-lg-5 col-sm-5 col-md-5 text-center">
                                    <label class="rm" style="font-style: normal">Modèle de Notation : </label>
                                    <asp:Label ID="ModeleNotation" runat="server" Text=""></asp:Label>
                                </div>

                                <div class="col-lg-6 col-sm-6 col-md-6 text-right">
                                    <label class="rm" style="font-style: normal">Situation comptable au  </label>
                                    <b>
                                        <asp:Label ID="DateCompta" runat="server" Text=""> </asp:Label></b>
                                </div>
                                <%--<div class="col-lg-4 col-sm-4 col-md-4">
                                            <input id="fichier" type="file" runat="server" class="" name="fic_name" contenteditable="false" accept=".txt, .csv" required="required" />
                                     </div>
                                    <div class="col-lg-1 col-sm-1 col-md-1" style="margin-top:-0.5%">
                                            <asp:Button ID="Charger" runat="server" CssClass="btn btn_cergicolor btn_hover" Text="Charger" />
                                     </div>--%>
                            </div>
                        </div>

                        <%--<div class="col-lg-10 col-sm-10 col-md-10 col-lg-offset-1 col-sm-offset-1 col-md-offset-1 table-responsive"
                            id="ListDEncours" runat="server" style="background-color: rgba(208, 245, 117, 0.34); box-shadow: rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius: 4px 4px; margin-right: 5%;">--%>
                            <div class="row" style="margin-top: 1%;">
                                <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" style="text-align: center;" id="ListDesEncoursTableau" runat="server">
                                </div>
                            </div>
                        <%--</div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="Scriptos" runat="server">
    </div>
    <script>
        $(document).ready(function () {
            var ladateComp = new Date();
            var datefinComp = ('0' + ladateComp.getDate()).slice(-2) + '/' + ('0' + (ladateComp.getMonth() + 1)).slice(-2) + '/' + (ladateComp.getFullYear());

            $("#<%=DateCompta.ClientID%>").text(datefinComp);
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
    </script>
</asp:Content>
