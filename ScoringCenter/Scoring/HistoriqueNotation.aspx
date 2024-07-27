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
    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui active_menu" href="#">Dossiers de notation</a></li>
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
</asp:Content>

<asp:Content ID="HistoriqueNotationBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="Content" class="Content">
        <!--br class="br_top" /-->
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
                        <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" id="ListDHistorique" runat="server">
                            <div class="row" style="margin-top: -0.5%;">
                                <table class="table table-bordered table-hover" id="">
                                    <thead>
                                        <tr class="table-heigth1">
                                            <th class="text-center" style="width:75px">Note financière</th>
                                            <th class="text-center" style="width:75px" id="DQTH" runat="server">Note qualitative</th>
                                            <th class="text-center" style="width:75px">Note intrinsèque</th>
                                            <th class="text-center" style="width:75px">Note de l'opération</th>
                                            <th class="text-center" style="width:75px">Note proposée</th>
                                            <th class="text-center" style="width:75px">Note finale</th>
                                            <th class="text-center" style="width:85px">Date de validation</th>
                                            <th class="text-center" style="width:75px">PD associée</th>
                                            <th class="text-center" style="width:75px">LGD</th>
                                            <th class="text-center" style="width:90px">Modèle de notation</th>
                                            <th class="text-center" style="">Etat</th>
                                            <th class="text-center" style="">Imp.</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ListDocTableauBord" runat="server" style="text-align: center">
                                    </tbody>
                                </table>
                                <div>
                                    <button 
                                    class=" hidden btn-sm btn-primary button_div pull-right"
                                    style="margin-right: 5px; color:#022451; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                    title="Supprimer"  onmousedown="con007($(this),'B')" 
                                    runat="server" onserverclick="suppHisto"
                                    id="SupprimerHistorique" >
                                    <span class=" glyphicon glyphicon-trash"></span>
                                </button>
                                </div>
                                <div class=" hidden col-lg-12 col-sm-12 col-md-12 div_form">
                                    <div class="" id="GraphContainer"  style="height:350px">
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
        <br />



          <div id="valideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="vv">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="vvv" style="float: left; margin-left: 2%"> Confimation</strong>
                    </div>
                    <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                        <div class="alert alert-info row" role="alert" style="margin: 2%">
                              <input type="text" id="id_d" hidden />
                            <p id="gfd" style="color: black; font-weight: bolder">
                                Voulez-vous imprimer le document?
                            </p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Button1" CssClass="btn btn-cergicolor" OnClick="ShowvalideOpen" runat="server" Text="Valider"  />--%>
                        <%--<button type="button" class="btn btn-primary" data-dismiss="modal" id="ShowvalideOpenConsult">Oui</button>--%>
                        <button type="button" class="btn btn-primary" data-dismiss="modal" id="ShowvalideOpenConsultNon">Oui</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal" >Non</button>
                    </div>
                </div>
            </div>
        </div>

        <button type="button" style="display: none;" id="ShowvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#valideConsult">
            Launch demo modal
        </button>


    </div>
       <div id="Scriptos" runat="server">

    </div>
    <script>

        function ShowvalideConsult() {
            $("#ShowvalideConsult").click();
        }

        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });
        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);

        }



        $("#ShowvalideOpenConsult").click(function () {
            var chaine = "OUI" + $("#id_d").val();
            window.open("../PrintPreview.aspx?id=" + chaine);
           
        });

        $("#ShowvalideOpenConsultNon").click(function () {
            var chaine = $("#id_d").val();
            window.open("../PrintPreview.aspx?id=" + chaine);
           

        });


        function ligneclick(enc) {
            
            $("#id_d").val(enc);
            ShowvalideConsult();
        }
        
    </script>
    <script>
       
        $(document).ready(function () {
            $("#id_d").val("");
            $("#GraphContainer>").find(".highcharts-yaxis-labels").find('tspan').each(function () {
                var vale = $(this).html().trim();
                if (vale >= 0 && vale < 2) $(this).html("D &nbsp;");
                if (vale >= 2 && vale < 4) $(this).html("C-");
                if (vale >= 4 && vale < 6) $(this).html("C &nbsp;");
                if (vale >= 6 && vale < 8) $(this).html("C+");
                if (vale >= 8 && vale < 10) $(this).html("B-");
                if (vale >= 10 && vale < 12) $(this).html("B &nbsp;");
                if (vale >= 12 && vale < 14) $(this).html("B+");
                if (vale >= 14 && vale < 16) $(this).html("A-");
                if (vale >= 16 && vale < 18) $(this).html("A &nbsp;");
                if (vale >= 18 && vale < 20) $(this).html("A+");
                if (vale >= 20) $(this).html("+∞");
            });
        });

        $("#GraphContainer").mouseover(function () {
            //alert();
            $("#GraphContainer").find(".highcharts-yaxis-labels").find('tspan').each(function () {
                var vale = $(this).html().trim();
                if (vale >= 0 && vale < 2) $(this).html("D &nbsp;");
                if (vale >= 2 && vale < 4) $(this).html("C-");
                if (vale >= 4 && vale < 6) $(this).html("C &nbsp;");
                if (vale >= 6 && vale < 8) $(this).html("C+");
                if (vale >= 8 && vale < 10) $(this).html("B-");
                if (vale >= 10 && vale < 12) $(this).html("B &nbsp;");
                if (vale >= 12 && vale < 14) $(this).html("B+");
                if (vale >= 14 && vale < 16) $(this).html("A-");
                if (vale >= 16 && vale < 18) $(this).html("A &nbsp;");
                if (vale >= 18 && vale < 20) $(this).html("A+");
                if (vale >= 20) $(this).html("+∞");
            });
        });


    </script>
</asp:Content>