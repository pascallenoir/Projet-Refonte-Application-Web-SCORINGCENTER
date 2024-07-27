<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalyseFinanciere.aspx.cs" Inherits="ScoringCenter.AnalyseFinanciere" %>

<asp:Content ID="AnalyseFinanciereMenu" ContentPlaceHolderID="ContentMenu" runat="server">
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

    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding: 0">
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Dossiers de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a class="pureCssMenui active_menu" href="#">Effectuer une notation</a></li>
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
            <span class="col-xs-12 sub_menus" style="padding: 0">
                <span class="col-xs-4" style="text-align: left; padding: 10px">
                    <asp:Label ID="LblModeleNotation" runat="server"> </asp:Label></>
                    <span>A dire d'expert : 
                        <asp:DropDownList ID="DdlADireExpert" AutoPostBack="true" runat="server" OnSelectedIndexChanged="OnADireExpertChange">
                            <asp:ListItem Value="0" Text="NON"></asp:ListItem>
                            <asp:ListItem Value="1" Text="OUI"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </span>
                <span class="col-xs-8">
                    <span class="col-xs-12 sub_menus_dn">
                        <li class="pureCssMenu" id="NCP" runat="server"><a class="pureCssMenui active_menu" href="#">Notation de la contrepartie</a></li>
                        <li class="pureCssMenu" id="NOP" runat="server"><a class="pureCssMenui" href="#">Notation de l'opération</a></li>
                        <li class="pureCssMenui sub_menu_vn" id="VN" runat="server"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
                    </span>
                    <span class="col-xs-12">
                        <span class="sub_menu_ncp">
                            <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui active_menu" href="#">Analyse financière</a></li>
                            <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                            <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                            <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                            <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                            <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                        </span>
                        <span style="display: none; float: left" class="sub_menu_nop">
                            <li class="pureCssMenui" id="AOP" runat="server"><a class="pureCssMenui" href="AnalyseOperation.aspx">Analyse de l'opération</a></li>
                            <li class="pureCssMenui" id="E" runat="server"><a class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                        </span>
                    </span>
                </span>
            </span>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="AnalyseFinanciereBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <input type="text" runat="server" id="connmou007" hidden />

        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Analyse Financière</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div id="floatant" class="" style="background-color: white">
                            <div id="test" class="col-lg-12 col-sm-12 col-md-12">
                                <div class="row div_form">
                                    <div class="col-xs-12" style="max-height: 25%; overflow: hidden;">
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
                                    <div class="col-lg-12 col-sm-12 col-md-12">
                                        <div class="row" style="margin-left: -6%; margin-bottom: 0.5%;">
                                            <div class="col-lg-7 col-sm-7 col-md-7 padding" style="">
                                                <input id="SystemeList" type="hidden" class="DdltailleFinancial padding" runat="server" style="padding-top: 0%; padding-bottom: 0%; width: 50%; height: 24px"  />
                                                <div style="font: bold 13px arial,verdana; padding: -1%;">
                                                    <asp:DropDownList Style="height: 24px; width: 100%; border: none;" onchange="combo007($(this),'C')" ID="valeurtype" runat="server" AutoPostBack="true">
                                                        <asp:ListItem>Bilan Normal</asp:ListItem>
                                                        <asp:ListItem Enabled="false">Bilan Allege</asp:ListItem>
                                                        <asp:ListItem>Systeme Minimal De Tresorerie</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="col-lg-4 col-sm-4 col-md-4 text-left" style="padding-right: 0; margin-right: 0;">
                                                    <div class="row">
                                                        <div class="col-lg-12 col-sm-12 col-md-12">
                                                            <span style="font-size: 11.4px; font-weight: bold; font-family: 'Century Gothic'">ETATS FINANCIERS SYCOHADA</span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-sm-12 col-md-12">
                                                            <span style="font-size: 11px; font-weight: bold; font-family: 'Century Gothic'">Système Normal</span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-5 col-sm-5 col-md-5" style="margin-left: 0%; padding-right: 0;">
                                                    <a style="font: inherit 11px arial,verdana; color: black; text-decoration: none;">Rubrique :</a>
                                                    <asp:DropDownList ID="DdlRubrique" CssClass="" onchange="combo007($(this),'C')" AutoPostBack="true"
                                                        runat="server" Height="24" Style="font: bold 11px arial,verdana; padding: -1%; padding-top: 0%; padding-bottom: 0%; width: 70%;" OnSelectedIndexChanged="DdlRubrique_SelectedIndexChanged">
                                                        <asp:ListItem>Bilan</asp:ListItem>
                                                        <asp:ListItem>Compte de résultat</asp:ListItem>
                                                        <asp:ListItem>Bilan en grandes masses</asp:ListItem>
                                                        <asp:ListItem>Tableau synthétique des SSG</asp:ListItem>
                                                        <asp:ListItem>Tableau des documents résumés</asp:ListItem>
                                                        <asp:ListItem>Tableau des autres ratios</asp:ListItem>
                                                        <asp:ListItem>Tableau des scores</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div hidden id="Div4" runat="server" class="col-lg-2 col-sm-2 col-md-2">
                                                    <asp:DropDownList ID="DropDownList1" CssClass="" onchange="combo007($(this),'C')" AutoPostBack="true"
                                                        runat="server" Height="24" Style="font: bold 11px arial,verdana; padding: -1%; width: 105%;">
                                                        <asp:ListItem>Milliers</asp:ListItem>
                                                        <asp:ListItem>Millions</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>--%>
                                            </div>

                                            <div class="col-lg-1 col-sm-1 col-md-1 div_circle" id="affnote" runat="server" style="padding-left: 2px; margin-left: -13%;">
                                                Note Financière&nbsp;:
                                                <asp:Label ID="NoteF" runat="server" Text=""></asp:Label>
                                            </div>

                                            <div class="col-lg-2 col-sm-2 col-md-2" style="margin-top: -1%; margin-right: 0.75%; margin-left: 2%;">
                                                <div class="row">
                                                    <div class="col-lg-12" style="padding-right: 0; padding-left: 0;">
                                                        <span class="">
                                                            <span id="note-01" class="col-xs-1 note">D</span>
                                                            <span id="note-02" class="col-xs-1 note">C-</span>
                                                            <span id="note-03" class="col-xs-1 note">C</span>
                                                            <span id="note-04" class="col-xs-1 note">C+</span>
                                                            <span id="note-05" class="col-xs-1 note">B-</span>
                                                            <span id="note-06" class="col-xs-1 note">B</span>
                                                            <span id="note-07" class="col-xs-1 note">B+</span>
                                                            <span id="note-08" class="col-xs-1 note">A-</span>
                                                            <span id="note-09" class="col-xs-1 note">A</span>
                                                            <span id="note-10" class="col-xs-1 note">A+</span>
                                                        </span>
                                                        <span class="the-jauge">
                                                            <span class="col-xs-1 jauge D"></span>
                                                            <span class="col-xs-1 jauge C-m"></span>
                                                            <span class="col-xs-1 jauge C"></span>
                                                            <span class="col-xs-1 jauge C-p"></span>
                                                            <span class="col-xs-1 jauge B-m"></span>
                                                            <span class="col-xs-1 jauge B"></span>
                                                            <span class="col-xs-1 jauge B-p"></span>
                                                            <span class="col-xs-1 jauge A-m"></span>
                                                            <span class="col-xs-1 jauge A"></span>
                                                            <span class="col-xs-1 jauge A-p"></span>
                                                        </span>
                                                        <span class="">
                                                            <span id="mrk-01" class="col-xs-1 marker"></span>
                                                            <span id="mrk-02" class="col-xs-1 marker"></span>
                                                            <span id="mrk-03" class="col-xs-1 marker"></span>
                                                            <span id="mrk-04" class="col-xs-1 marker"></span>
                                                            <span id="mrk-05" class="col-xs-1 marker"></span>
                                                            <span id="mrk-06" class="col-xs-1 marker"></span>
                                                            <span id="mrk-07" class="col-xs-1 marker"></span>
                                                            <span id="mrk-08" class="col-xs-1 marker"></span>
                                                            <span id="mrk-09" class="col-xs-1 marker"></span>
                                                            <span id="mrk-10" class="col-xs-1 marker"></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-1 col-sm-1 col-md-1 edit_space" onmousedown="modifsurvol()" style="margin-left: 10px;">
                                                <button class="ImprimeEtat btn btn-sm btn-primary button_div" style="margin-right: 5px; color: #0a8f3a; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px; margin-left: 0;" title="Extraire Excel"
                                                    runat="server" id="ExcelPrint">
                                                    <span class="glyphicon glyphicon-export"></span>
                                                </button>

                                                <button class="ImprimeEtat btn btn-sm btn-primary button_div ImprimBtn" disabled="disabled" style="margin-right: 5px; color: #b8860b; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px; margin-left: 15%;" title="Imprimer"
                                                    id="ImprimeEtat" runat="server">
                                                    <span class=" glyphicon glyphicon-print"></span>
                                                </button>

                                                <button class="btnModifBil btn btn-sm btn-primary button_div AnnulBtn" style="height: 24px; background-color: #c3c3c3; color: rgba(204, 92, 11, 0.84); border: none; padding-top: 0px; padding-bottom: 0px;" title="Annuler"
                                                    runat="server" id="btnRefreshBil">
                                                    <span class=" glyphicon glyphicon-remove"></span>
                                                </button>


                                                <button class="btnModifBil btn btn_cergicolor btn_hover CalcBtn" type="button" id="btnModifBil" runat="server" onserverclick="btnModifBil_ServerClick" style="height: 25px; border: none; padding-top: 0px; padding-bottom: 0px;">Calculer</button>

                                                <%--Eloi 09/01/2023--%>
                                                <input class="hidden" runat="server" id="txtControlAncien" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-6 text-center EnteteInfo panel " id="paneauActif" style="background-color: #022d65; margin-top: 10px; margin-left: 1.5%; padding-bottom: 3%; width: 45%" hidden>
                                <label for="" style="color: white">Actifs</label>
                            </div>
                            <div class="col-md-6 text-center EnteteInfo panel " id="paneauPassif" style="background-color: #022d65; margin-top: 10px; margin-left: 3.4%; padding-bottom: 3%; width: 45%" hidden>
                                <label for="" style="color: white">Passifs</label>
                            </div>
                            <div class="col-md-6 text-center EnteteInfo panel " id="paneauCharge" style="background-color: #022d65; margin-top: 10px; margin-left: 1.5%; padding-bottom: 3%; width: 45%" hidden>
                                <label for="" style="color: white">Charges</label>
                            </div>
                            <div class="col-md-6 text-center EnteteInfo panel " id="paneauProduit" style="background-color: #022d65; margin-top: 10px; margin-left: 3.4%; padding-bottom: 3%; width: 45%" hidden>
                                <label for="" style="color: white">Produits</label>
                            </div>
                            <div class="col-md-10 text-center EnteteInfo panel " id="paneauTabSynt" style="background-color: #022d65; margin-top: 10px; margin-left: 1.4%; padding-bottom: 3%; width: 94%" hidden>
                                <label for="" id="idlabelTabSynt" style="color: white">Libelle</label>
                            </div>
                        </div>
                        <div style="font-size: 12px;" class="col-lg-12 col-sm-12 col-md-12">

                            <div class="row push_fulltable">


                                <div class="col-lg-12 col-sm-12 col-md-12 row table-responsive le_nom_de_ ton_textarea "
                                    id="ListDFinanciers" runat="server">
                                </div>


                                <div class="col-lg-12 col-sm-12 col-md-12 row table-responsive"
                                    id="Div1" visible="false" runat="server">

                                    <div class="col-lg-6 col-sm-6 col-md-6" style="overflow-x: auto" id="DIVtotauxActif" runat="server">
                                        <%--<table id="totauxActif" class="table-hover table table-bordered text-center">
                                            <tr style="background-color:rgba(210, 210, 210, 1);">
                                                <td class='text-left'><strong>Total Actif</strong></td>
                                                <td class='text-left' id="TAAnnee1" runat="server" width="23%"></td>
                                                <td class='text-left' id="TAAnnee2" runat="server" width="23%"></td>
                                                <td class='text-left' id="TAAnnee3" runat="server" width="23%"></td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6" style="overflow-x: auto" id="DIVtotauxPassif" runat="server">
                                        <%--<table id="totauxPassif" class="table-hover table table-bordered text-center">
                                            <tr style="background-color:rgba(210, 210, 210, 1);">
                                                <td class='text-left'><strong>Total Passif</strong></td>
                                                <td class='text-left' id="TPAnnee1" runat="server" width="23%"></td>
                                                <td class='text-left' id="TPAnnee2" runat="server" width="23%"></td>
                                                <td class='text-left' id="TPAnnee3" runat="server" width="23%"></td>
                                            </tr>
                                        </table>--%>
                                    </div>

                                </div>

                                <div class="col-lg-12 col-sm-12 col-md-12 row table-responsive"
                                    id="CompteResult" visible="false" runat="server">
                                    <div class="col-lg-6 col-sm-6 col-md-6" id="divCharge" runat="server">
                                        <%--<table id="totauxActif" class="table-hover table table-bordered text-center">
                                            <tr style="background-color:rgba(210, 210, 210, 1);">
                                                <td class='text-left'><strong>Total Actif</strong></td>
                                                <td class='text-left' id="TAAnnee1" runat="server" width="23%"></td>
                                                <td class='text-left' id="TAAnnee2" runat="server" width="23%"></td>
                                                <td class='text-left' id="TAAnnee3" runat="server" width="23%"></td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6" id="divProduit" runat="server">
                                        <%--<table id="totauxPassif" class="table-hover table table-bordered text-center">
                                            <tr style="background-color:rgba(210, 210, 210, 1);">
                                                <td class='text-left'><strong>Total Passif</strong></td>
                                                <td class='text-left' id="TPAnnee1" runat="server" width="23%"></td>
                                                <td class='text-left' id="TPAnnee2" runat="server" width="23%"></td>
                                                <td class='text-left' id="TPAnnee3" runat="server" width="23%"></td>
                                            </tr>
                                        </table>--%>
                                    </div>
                                </div>

                                <div class="col-lg-12 col-sm-12 col-md-12 " style="margin-left: -1.5%">
                                    <div class="col-lg-6 col-sm-6 col-md-6 col-lg-push-3 table-responsive"
                                        id="Div2" visible="false" runat="server">
                                        <div id="DivecartsActifPassif" runat="server" class="">
                                            <%--<table id="ecartsActifPassif" class="table-hover table table-bordered text-center">
                                                <tr>
                                                    <td class='text-left'><strong>Ecart</strong></td>
                                                    <td class='text-left' width="23%"><strong></strong></td>
                                                    <td class='text-left' width="23%"><strong></strong></td>
                                                    <td class='text-left' width="23%"><strong></strong></td>
                                                </tr>
                                            </table>--%>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row">
                                <div class="col-lg-12 col-sm-12 col-md-12">
                                    <div class="row" style="margin-left: -6%; margin-bottom: 0.5%;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div id="Norme" class="notification modal fade margin-intelligent  row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vvPas">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvPas" style="float: left; margin-left: 2%">
                        <asp:Label ID="lblPasValideTitreConsult" Text="NORME..." runat="server" /></strong>

                </div>
                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPas" style="color: black; font-weight: bolder">
                            <div id="lblPasValidemessageConsult">
                            </div>
                        </p>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="get_docs()">Annuler</button>
                </div>
            </div>
        </div>
    </div>
    <div id="Modvoirbill" class="notification modal fade margin-intelligent  row" style="width: 900px" role="dialog">
        <div class="modal-dialog" style="width: 900px">
            <!-- Modal content-->
            <div class="modal-content" style="background-color: none; width: 900px">
                <div class="modal-header" id="vvModVoir" style="width: 900px">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvModSaisieVoir" style="float: left; margin-left: 2%">
                        <asp:Label ID="Label3" Text="voir..." runat="server" /></strong>
                </div>

                <div class="modal-body" id="edModVoir" style="margin: 0%; padding: 0 !important; width: 900px">
                    <div class=" row" style="margin: 2%;">
                        <asp:GridView ID="GridView1" CssClass="dataTable" runat="server"></asp:GridView>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn_cergicolor btn_hover" id="Button2" runat="server" onserverclick="Ajouter_Liasse">Valider</button>
                    <button type="button" class="btn btn_cergicolor btn_hover" data-dismiss="modal" onclick="get_docs()">Annuler</button>
                </div>
            </div>
        </div>
    </div>



    <div id="ImprimeEtatLiasse" class="notification modal fade margin-intelligent  row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal Chargement-->
            <div class="modal-content" style="background-color: none;">
                <div class="modal-header" hidden id="vvImprimeEtatLiasse">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvImprimeEtatLiasse" style="float: left; margin-left: 2%">
                        <asp:Label ID="Label4" Text="Chargement de la liasse..." runat="server" /></strong>
                </div>

                <div class="modal-body" id="edImprimeEtatLiasse" style="margin: 0%; padding: 0 !important">
                    <h4>Impression Etats Financiers</h4>





                    <div class="row">
                        <div class="col-lg-8">
                            <div class="col-lg-10">
                                <div class="col-lg-8 text-left">Année </div>
                                <div class="col-lg-4 text-left">
                                    <select id="SelectValue">
                                        <option></option>
                                        <option value="01/2014">01/2014</option>
                                        <option value="01/2015">01/2015</option>
                                        <option value="01/2016">01/2016</option>
                                    </select>
                                </div>

                            </div>

                            <div class="col-lg-10">
                                <div class="col-lg-10 text-left">Bilan </div>
                                <input type="checkbox" id="EtatBilan" value="BIL" />
                            </div>
                            <div class="col-lg-10">
                                <div class="col-lg-10 text-left">Compte de résultat </div>
                                <input type="checkbox" id="EtatComptResult" value="CR" />
                            </div>

                        </div>
                        <div class="col-lg-3">
                        </div>
                    </div>

                    <%--<h4>Imprimer Analyse Financiere</h4>--%>





                    <div class="row  hidden">
                        <div class="col-lg-12">
                            <div class="col-lg-10">
                                <div class="col-lg-5 text-left">Années: </div>
                                2014<input type="checkbox" id="AnalyseAn1" value="AN1" />2015<input type="checkbox" id="AnalyseAn2" value="AN2" />2016<input type="checkbox" id="AnalyseAn3" value="AN3" />
                            </div>

                        </div>
                        <div class="col-lg-12" style="margin-top: 4%;">
                            <div class="col-lg-8">

                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Tous </div>
                                    <input type="checkbox" id="AnalyseTous" />
                                </div>

                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Bilan en grandes masses </div>
                                    <input type="checkbox" id="AnalyseBGM" value="BGM" />
                                </div>
                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Tableau synthétique des SSG </div>
                                    <input type="checkbox" id="AnalyseTS" value="TS" />
                                </div>
                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Tableau des documents résumés </div>
                                    <input type="checkbox" id="AnalyseTDR" value="TDR" />
                                </div>
                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Tableau des autres ratios </div>
                                    <input type="checkbox" id="AnalyseAUT" value="AUT" />
                                </div>
                                <div class="col-lg-10">
                                    <div class="col-lg-10 text-left">Tableau des scores  </div>
                                    <input type="checkbox" id="AnalyseRAT" value="RAT" />
                                </div>

                            </div>
                            <div class="col-lg-3">
                            </div>
                        </div>

                    </div>
                </div>


                <div class="modal-footer">
                    <button type="button" id="ImprimerEtatsRubrique" style="height: 24px; border: none; padding-top: 0px; margin-top: 5%; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover" onclick="BntEditionAnalyse()">Imprimer</button>
                    <button type="button" id="AnnulerImprimer" data-dismiss="modal" style="height: 24px; border: none; padding-top: 0px; margin-top: 5%; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover">Annuler</button>
                    <%--<asp:Button ID="Button1" OnClick="Charger_Click" runat="server" CssClass="btn btn_cergicolor btn_hover" Text="Charger" />
                    <button type="button" class="btn btn_cergicolor btn_hover" data-dismiss="modal" onclick="">Annuler</button>--%>
                </div>
            </div>
        </div>
    </div>

    <div id="ModSaisieLiasse" class="notification modal fade margin-intelligent  row" data-backdrop="static" data-keyboard="false" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content" style="background-color: none;">
                <div class="modal-header" id="vvModSaisieLiasse">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvModSaisieLiasse" style="float: left; margin-left: 2%">
                        <asp:Label ID="Label1" Text="Saisir exercice..." runat="server" /></strong>
                </div>

                <div class="modal-body" id="edModSaisieLiasse" onchange="controleLiasse()" style="margin: 0%; padding: 0 !important">
                    <div class=" row" style="margin: 2%;">
                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="DateCloture">Date clôture:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <input type="date" id="DateCloture" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="dureeExercice">Durée de l'exercice en mois:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <input type="number" min="1" max="12" id="dureeExercice" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Type Bilan:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <select runat="server" id="DdlAgenceTypeBilan" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                    <option></option>
                                    <option value="SN">Bilan Normal</option>
                                    <option value="SA" disabled>Bilan Allege</option>
                                    <option value="SMT">Systeme Minimal De Tresorerie</option>
                                </select>
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Nature Exercice:</label>

                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <select runat="server" id="DdlNatureExo" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                    <option></option>
                                    <option>Fin d’exercice</option>
                                    <option>Situation intermédiaire</option>
                                </select>
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Certification des Comptes:</label>

                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <select runat="server" id="DdlCertification" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                    <option></option>
                                    <option>Non renseigné</option>
                                    <option>Certification sans réserve</option>
                                    <option>Certification avec réserve</option>
                                    <option>Refus de certifier</option>
                                    <option>Non concerné par la certification</option>
                                </select>
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Effectif:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <input type="number" min="1" id="TxtEffectif" class="form-control" runat="server" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Confidentialité:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <select runat="server" id="DdlConfidentialite" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                    <option></option>
                                    <option>Non</option>
                                    <option>Oui</option>
                                </select>
                            </div>
                        </div>
                        <div class="row push_right" style="margin-left: 6%;">
                            <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="email">Régime fiscal:</label>
                            <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                                <select runat="server" id="TxtRegimeFiscale" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;">
                                    <option></option>
                                    <option>Réel normal</option>
                                    <option>Réel simplifié</option>
                                    <option>Synthétique</option>
                                    <option>Forfait</option>
                                </select>
                            </div>
                        </div>

                        <div class="row push_right" style="margin-left: 6%;">
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn_cergicolor btn_hover hidden" id="Button1" runat="server" onserverclick="Modifier_Liasse">Modifier</button>
                    <button type="button" class="btn btn_cergicolor btn_hover" id="BtValideSaisiLiasse" runat="server" onserverclick="Ajouter_Liasse">Valider</button>
                    <button type="button" class="btn btn_cergicolor btn_hover" data-dismiss="modal" onclick="get_docs()">Annuler</button>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" runat="server" id="ModifID" />
    <input type="hidden" runat="server" id="ModifValeur" />
    <input type="hidden" runat="server" id="ModifAnnee" />
    <input type="hidden" runat="server" id="nobcol" />
    <input type="hidden" onchange="selectcol()" runat="server" id="valdeselect" />
    <input type="hidden" id="notifHiddenF" />




    <%--Modal Notification--%>
    <div id="PasvalideConsult" class="notification modal fade margin-intelligent  row" data-keyboard="false" data-backdrop="false" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" hidden id="vvPas">
                    <%--<button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>--%>
                    <strong id="vvvPas" style="float: left; margin-left: 2%">
                        <asp:Label ID="idtitre" runat="server" /></strong>
                </div>
                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPas" style="color: black; font-weight: bolder">
                            <asp:Label ID="idmesa" runat="server" />
                        </p>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" runat="server">OK</button>
                </div>
            </div>
        </div>
    </div>

    <%--Modal Notification--%>
    <div id="valideConsult" class="notification modal fade margin-intelligent  row" data-keyboard="false" data-backdrop="false" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" hidden id="vv">
                    <%--<button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>--%>
                    <strong id="vvv" style="float: left; margin-left: 2%">
                        <asp:Label ID="lblValideTitreConsult" runat="server" /></strong>
                </div>
                <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfd" style="color: black; font-weight: bolder">
                            <asp:Label ID="lblValidemessageConsult" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<asp:Button ID="Button1" CssClass="btn btn-cergicolor" OnClick="ShowvalideOpen" runat="server" Text="Valider"  />--%>
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" id="ShowvalideOpenConsult" runat="server">Oui</button>
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">Non</button>
                </div>
            </div>
        </div>
    </div>
    <%--Modal Notification--%>
    <div id="valideDownload" class="notification modal fade margin-intelligent  row" data-keyboard="false" data-backdrop="false" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" hidden id="vv">
                    <strong style="float: left; margin-left: 2%">
                        <asp:Label ID="labelDownlaod" runat="server" /></strong>
                </div>
                <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfd" style="color: black; font-weight: bolder">
                            <a href="#" id="downExcActif" class="btn btn-primary" runat="server">Partie 1</a>
                            <a href="#" id="downExcPassif" class="btn btn-primary" runat="server">Partie 2</a>
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">Fermer</button>
                </div>
            </div>
        </div>
    </div>

    <%--Eloi 09/01/2023--%>
    <%--Modal Notification Ancienneté Date Bilan--%>
    <div id="NotifAnienneteDateBilan" class="notification modal fade margin-intelligent  row" data-keyboard="false" data-backdrop="false" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header hidden" id="NotifAnienneteDateBilanHeader">
                    <strong style="float: left; margin-left: 2%">
                        <asp:Label ID="label5" runat="server" /></strong>
                </div>
                <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-warning row" role="alert" style="margin: 2%">
                        <p id="NotifAnienneteDateBilanContent_1" class="text-center" style="color: black; font-weight: bolder">
                            L'ancienneté des bilans au moment du calcul de la note finacière est supérieure ou égale à 2 ans.
                            Voulez-vous quand même poursuire le calcul ?
                        </p>
                        <p id="NotifAnienneteDateBilanContent_2" class="text-center" style="color: black; font-weight: bolder">
                            Le calcul de la note financière est impossible car aucun bilan n'est disponible pour ce dossier.
                            Vous avez la possibilité de basculer en mode à dire d'expert.
                        </p>
                    </div>
                </div>
                <hr />
                <div class="">
                    <button type="button" class="btn btn-primary" runat="server" id="btnModifBilSuiteOui" onserverclick="btnModifBil_ServerClick">Oui</button>
                    <!-- button type="button" class="btn btn-primary" id="btnSaisirLiasseSuiteOui">Oui</!--button-->
                    <button type="button" class="btn" id="btnModifBilSuiteNon">OK</button>
                    <button type="button" class="hidden" id="btnNotifAnienModalClose" data-dismiss="modal" onclick="return;">Non</button>
                </div>
                <br />
            </div>
        </div>
    </div>

    <div id="NotifBasculeADireExpert" class="notification modal fade margin-intelligent  row" data-keyboard="false" data-backdrop="false" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-danger row" role="alert" style="margin: 2%">
                        <p class="text-center" style="color: black; font-weight: bolder">
                            Attention le modèle de notation est indéterminé parce qu’il n’y a pas de données bilancielles.
                            <br />
                            <br />
                            Pour effectuer un dossier de notation sans notation financière, basculer sur la notation à dire d’expert.
                            <br />
                            Cliquer sur la boîte de sélection « A dire d’expert » et choisir la valeur « OUI »
                        </p>
                    </div>
                </div>
                <div class="">
                    <button type="button" class="btn" data-dismiss="modal" onclick="return;">OK</button>
                </div>
                <br />
            </div>
        </div>
    </div>

    <input type="hidden" id="iddossierd" runat="server" />
    <input type="hidden" id="idscoringd" runat="server" />



    <script>
        /*Ajout Eloi 11/01/2023*/
        var marker = $("#marker").html();
        function positionMarker(note) {
            $(".marker").each(function () { $(this).html(""); });
            $(".note").each(function () {
                if ($(this).text() === note) {
                    var index = $(this).attr("id").split("-")[1];
                    $("#mrk-" + index).html(marker);
                }
            });
        }
        /*----------------------------------------------------*/

        $(document).keydown(function (event) {
            // flèche gauche avec alt
            //alert(event.which);

            if (event.which == 13
                //&& event.altKey
            ) {
                modifsurvol();
            }
            if (event.which == 13
                && event.altKey
            ) {
                modifsurvol();
                $("#<%=btnModifBil.ClientID%>").click();

            }
            if (event.which == 109
                //&& event.altKey
            ) {
                $("#<%=ListDFinanciers.ClientID%>").find('input').val($("#<%=ListDFinanciers.ClientID%>").find('input').val() * (-1));
            }
        });
    </script>

    <script>

        $("#<%=ListDFinanciers.ClientID%>").find('table').each(function () {
            $(this).find('tr').each(function () {
                $(this).find('td').each(function () {
                    //$(this).html();
                    if ($("#<%=DdlRubrique.ClientID%>").val() != "Compte de résultat" && $("#<%=DdlRubrique.ClientID%>").val() != "Bilan") {
                        if ($(this).html().trim() == "<strong>0</strong>" || $(this).html().trim() == "<strong><strong>0</strong></strong>" || $(this).html().trim() == "<strong>%</strong>" || $(this).html().trim() == "<strong>0%</strong>" || $(this).html().trim() == "<strong>00%</strong>" || $(this).html().trim() == "%" || $(this).html().trim() == "0%" || $(this).html().trim() == "00%" || $(this).html().trim() == "0")
                            $(this).html(" ");
                    }

                    if (
                        //Pour le bilan
                        $(this).parent().attr('data_code') != "BA11" && $(this).parent().attr('data_code') != "BA12"
                        && $(this).parent().attr('data_code') != "BA13" && $(this).parent().attr('data_code') != "BA15"
                        && $(this).parent().attr('data_code') != "BA1" && $(this).parent().attr('data_code') != "BA22"
                        && $(this).parent().attr('data_code') != "BA23" && $(this).parent().attr('data_code') != "BA2"
                        && $(this).parent().attr('data_code') != "BA3" && $(this).parent().attr('data_code') != "BP1A3"
                        && $(this).parent().attr('data_code') != "BP1AX" && $(this).parent().attr('data_code') != "BP1A"
                        && $(this).parent().attr('data_code') != "BP1B" && $(this).parent().attr('data_code') != "BP1"
                        && $(this).parent().attr('data_code') != "BP2" && $(this).parent().attr('data_code') != "BP3"
                        // pour le compte de resultat 
                        && $(this).parent().attr('data_code') != "CC1" && $(this).parent().attr('data_code') != "CC2"
                        && $(this).parent().attr('data_code') != "CC3" && $(this).parent().attr('data_code') != "CC4"
                        && $(this).parent().attr('data_code') != "CC5" && $(this).parent().attr('data_code') != "CC"
                        && $(this).parent().attr('data_code') != "CP1" && $(this).parent().attr('data_code') != "CP4"
                        && $(this).parent().attr('data_code') != "CP5" && $(this).parent().attr('data_code') != "CP7"
                        && $(this).parent().attr('data_code') != "CP1I" && $(this).parent().attr('data_code') != "CP3"
                        && $(this).parent().attr('data_code') != "CP5A" && $(this).parent().attr('data_code') != "CP8"
                        && $(this).parent().attr('data_code') != "CP6" && $(this).parent().attr('data_code') != "CP6A"
                        && $(this).parent().attr('data_code') != "CP1N"

                    ) {

                    } else {
                        if ($(this).html().trim() == "<strong>0</strong>" || $(this).html().trim() == "<strong><strong>0</strong></strong>" || $(this).html().trim() == "<strong>%</strong>" || $(this).html().trim() == "<strong>0%</strong>" || $(this).html().trim() == "<strong>00%</strong>" || $(this).html().trim() == "%" || $(this).html().trim() == "0%" || $(this).html().trim() == "00%" || $(this).html().trim() == "0")
                            $(this).html("—");
                    }

                });
            });

        });

        var positionElementInPage = $('#floatant').offset().top;
        $(window).scroll(
            function () {
                if ($(window).scrollTop() != positionElementInPage) {
                    // fixed
                    //$('#floatant').css({ 'position': "fixed" });
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Bilan") {
                        if ($(window).scrollTop() > 200) {
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauActif').show();
                            $('#paneauPassif').show();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();

                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();


                        }
                    }
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Compte de résultat") {
                        if ($(window).scrollTop() > 200) {
                            $('#paneauActif').hide();
                            $('#paneauTabSynt').hide();
                            $('#paneauPassif').hide();
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauCharge').show();
                            $('#paneauProduit').show();

                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();
                        }
                    }
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Tableau synthétique des SSG") {
                        if ($(window).scrollTop() > 200) {
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').show();


                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();
                            $('#idlabelTabSynt').text('Libellés');
                        }
                    }
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Bilan en grandes masses") {
                        if ($(window).scrollTop() > 200) {
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauActif').show();
                            $('#paneauPassif').show();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();

                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();


                        }
                    }
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Tableau des documents résumés") {
                        if ($(window).scrollTop() > 200) {
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').show();
                            $('#idlabelTabSynt').text('Valeurs structurelles');


                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();
                        }
                    }
                    if ($("#<%=DdlRubrique.ClientID%>").val() == "Tableau des scores") {
                        if ($(window).scrollTop() > 200) {
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#floatant').addClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#floatant').width(940);
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').show();
                            $('#idlabelTabSynt').text('Ratios');


                        } else {
                            $('#floatant').removeClass('affix').css({ 'z-index': "500", 'margin-top': '0', 'top': '0' });
                            $('#paneauActif').hide();
                            $('#paneauPassif').hide();
                            $('#paneauCharge').hide();
                            $('#paneauProduit').hide();
                            $('#paneauTabSynt').hide();
                        }
                    }
                    else {
                    }

                }
            });
        //floattant

        <%--Eloi 10/01/2023--%>
        function ShowNotifAncienBilan() {
            if ($("#<%=txtControlAncien.ClientID%>").val() === "CalculImpos") {
                $("#NotifAnienneteDateBilanContent_1").addClass("hidden");
                $("#<%=btnModifBilSuiteOui.ClientID%>").addClass("hidden");
                $("#NotifAnienneteDateBilanContent_2").removeClass("hidden");
                $("#btnSaisirLiasseSuiteOui").removeClass("hidden");
            }
            else if ($("#<%=txtControlAncien.ClientID%>").val() === "CalculSuite") {
                $("#NotifAnienneteDateBilanContent_1").removeClass("hidden");
                $("#<%=btnModifBilSuiteOui.ClientID%>").removeClass("hidden");
                $("#NotifAnienneteDateBilanContent_2").addClass("hidden");
                $("#btnSaisirLiasseSuiteOui").addClass("hidden");
            }
            $('#NotifAnienneteDateBilan').modal('show')
        }

        $("body").on("click", "#btnModifBilSuiteNon", function () {
            $("#<%=txtControlAncien.ClientID%>").val("");
            $("#btnNotifAnienModalClose").trigger("click");
        });
        $("body").on("click", "#btnSaisirLiasseSuiteOui", function () {
            $("#<%=txtControlAncien.ClientID%>").val("");
            $("#btnNotifAnienModalClose").trigger("click");
        });
    </script>

    <script>


        $(document).ready(function () {
            //ttiret


            // $("#BA").

            var li1 = '0'; if (removeSpace($("#BA").find('tr').eq(0).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') li1 = removeSpace($("#BA").find('tr').eq(0).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var lo1 = '0'; if (removeSpace($("#BA").find('tr').eq(1).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') lo1 = removeSpace($("#BA").find('tr').eq(1).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var li11 = '0'; if (removeSpace($("#BP").find('tr').eq(0).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') li11 = removeSpace($("#BP").find('tr').eq(0).find('td').eq(1).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            $("#totauxEcart").find('tr').eq(0).find('td').eq(1).html('<strong>' + formatMillier(parseInt(li1) - parseInt(li11)) + '<strong>');
            //alert((parseInt(li1) - parseInt(li11)));

            var li2 = '0'; if (removeSpace($("#BA").find('tr').eq(0).find('td').eq(2).html().replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim()) != '') li2 = removeSpace($("#BA").find('tr').eq(0).find('td').eq(2).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var lo2 = '0'; if (removeSpace($("#BA").find('tr').eq(1).find('td').eq(2).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') lo2 = removeSpace($("#BA").find('tr').eq(1).find('td').eq(2).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var li22 = '0'; if (removeSpace($("#BP").find('tr').eq(0).find('td').eq(2).html().replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim()) != '') li22 = removeSpace($("#BP").find('tr').eq(0).find('td').eq(2).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            $("#totauxEcart").find('tr').eq(0).find('td').eq(2).html('<strong>' + formatMillier(parseInt(li2) - parseInt(li22)) + '<strong>');

            var li3 = '0'; if (removeSpace($("#BA").find('tr').eq(0).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') li3 = removeSpace($("#BA").find('tr').eq(0).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var lo3 = '0'; if (removeSpace($("#BA").find('tr').eq(1).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') lo3 = removeSpace($("#BA").find('tr').eq(1).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            var li33 = '0'; if (removeSpace($("#BP").find('tr').eq(0).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim() != '') li33 = removeSpace($("#BP").find('tr').eq(0).find('td').eq(3).html()).replace('<strong>', '').replace('</strong>', '').replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "").trim();
            $("#totauxEcart").find('tr').eq(0).find('td').eq(3).html('<strong>' + formatMillier(parseInt(li3) - parseInt(li33)) + '<strong>');

        });

        function FomateNumeric() {
            $('.cergiDecimalMoney').each(function () {
                //if ($(this).val().substring(0, 1) != '-') 
                $(this).number(true, parseInt($(this).attr("nbDecimal")));
            });

        }


        /*//           -----------------------  Anciens Scripts  ------------------------       //*/
        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });
        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);

        }
        function bilan007(ModifID, ModifValeur, ModifAnnee, nobcol) {

            var codepostes = ModifID.split('@');
            var valeurs = ModifValeur.split('@');
            var annees = ModifAnnee.split('@');
            var chaine1 = "";
            var chaine11 = "";
            var nbcol = parseInt(nobcol) - 1;

            var totalis = codepostes.length - 1;

            for (i = 0; i < totalis; i++) {

                var actuoposte = codepostes[i];
                var totalis2 = annees.length - 1;
                for (j = 0; j < totalis2; j++) {

                    //service.ModiDonneLiasse(idDossier.ToString().Trim(), annees[j], Convert.ToDouble(valeurs[(i * nbcol) + j]), actuoposte, rubrType, rubriq);
                    chaine11 = chaine11 + "|" + annees[j] + "->" + parseFloat(valeurs[(i * nbcol) + j]) + "->" + actuoposte

                }
                //service.miseAjrDateFinan(idDossier);

            }

            //if (obj.find("option:selected").text().trim() != "" && obj.find("option:selected").text().trim() != null) {
            chaine1 = "SC#TabAna" + ":" + chaine11;
            //} else {
            //    chaine1 = "SC#" + type + ":***";
            //}
            //alert(chaine1);

            O42451(chaine1);
        }


        //function BntEditionAnalyse() {
        //    var bilEtat = "";
        //    if ($('#EtatBilan').is(':checked')) {

        //        bilEtat = bilEtat+"SCOR_ANAFI_SN_Actif-Immo.rpt@SCOR_ANAFI_SN_Act-Circul.rpt@SCOR_ANAFI_SN_Capitaux.rpt@SCOR_ANAFI_SN_Passif-circul.rpt"
        //        //ImprimerEtat(bilEtat, document.getElementById('SelectValue').value);

        //    }

        //    if ($('#EtatComptResult').is(':checked')) {
        //        if (bilEtat != "") bilEtat = bilEtat + "@";
        //        bilEtat = bilEtat + "SCOR_ANAFI_SN_Charge_1.rpt@SCOR_ANAFI_SN_Charge2.rpt@SCOR_ANAFI_SN_Produit1.rpt@SCOR_ANAFI_SN_Produit2.rpt"

        //    }

        //    ImprimerEtat(bilEtat, document.getElementById('SelectValue').value);

        //}


        function ImprimerEtat(ReportName, Annee) {

            //alert(ReportName+" "+ Annee);
            $.ajax({
                type: "POST",
                url: "../Scoringws.asmx/PrintState",
                data: "{'ReportName': '" + ReportName + "','Annee': '" + Annee + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                },
                success: function (response) {
                    if (response.d == "ko") {
                        //alert('sorry!!!!');
                    } else { window.open("../PrintPreview.aspx"); }
                },
                failure: function (response) {
                    error_message("Erreur", response.d, "confirmTitle");
                }
            });
        }

        function BntEditionAnalyse() {
            var bilEtat = "ANAFI";
            if ($('#EtatBilan').is(':checked')) {
                bilEtat = bilEtat + "@";
                //bilEtat = bilEtat + "SCOR_ANAFI_SN_Actif-Immo.rpt@SCOR_ANAFI_SN_Act-Circul.rpt@SCOR_ANAFI_SN_Capitaux.rpt@SCOR_ANAFI_SN_Passif-circul.rpt"
                bilEtat = bilEtat + "BILAN"
                //ImprimerEtat(bilEtat, document.getElementById('SelectValue').value);

            }

            if ($('#EtatComptResult').is(':checked')) {
                bilEtat = bilEtat + "@";
                bilEtat = bilEtat + "COMPTERESULTAT"
                //bilEtat = bilEtat + "SCOR_ANAFI_SN_Charge_1.rpt@SCOR_ANAFI_SN_Charge2.rpt@SCOR_ANAFI_SN_Produit1.rpt@SCOR_ANAFI_SN_Produit2.rpt"

            }
            if (bilEtat != "ANAFI") {
                bilEtat = bilEtat + "@" + document.getElementById('SelectValue').value;
                window.open("../PrintPreview.aspx?id=" + bilEtat);
            }
            else {
                //alert("ok");
            }
            //ImprimerEtat(bilEtat, document.getElementById('SelectValue').value);

        }
    </script>
    <script>
        function formatageMillierSunsurve(nombre) {
            if (isNaN(nombre)) {

                return nombre;
            }
            else {
                nombre = nombre.replace(/ /g, "");
                nombre += '';
                var sep = ' ';
                var reg = /(\d+)(\d{3})/;
                while (reg.test(nombre)) {
                    nombre = nombre.replace(reg, '$1' + sep + '$2');
                }
                return nombre.replace(/,/g, " ");
            }
        }
        $(document).ready(function () {
            $('table td').each(function () {
                $(this).html(formatageMillierSunsurve($(this).html()));
            });
        });

    </script>
    <div id="Scriptos" runat="server">
    </div>

    <script>
        /*Notification bloquante en fonction de la valeur du modèle de notation*/
        $('.sub_menu_vn, .sub_menu_nop, .sub_menu_ncp').on('click', 'a', function (e) {
            e.preventDefault();
            var link = $(this).prop('href');

            var id_dossier = $("#<%=iddossierd.ClientID%>").val();
            var id_scoring = $("#<%=idscoringd.ClientID%>").val();

            $.ajax({
                type: "POST",
                url: "AnalyseFinanciere.aspx/CheckModeleNotation",
                data: "{'id_dossier': '" + id_dossier + "','id_scoring': '" + id_scoring + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    if (!response.d) {
                        $('#NotifBasculeADireExpert').modal('show');
                    } else {
                        window.location.replace(link);
                    }
                },
                failure: function (response) { }
            });
        });
    </script>

</asp:Content>
