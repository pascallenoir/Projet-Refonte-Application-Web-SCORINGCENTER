<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="ScoringCenter.Scoring.TableauBord" %>

<asp:Content ID="TableauBordMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a class="pureCssMenui active_menu" href="#">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
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
</asp:Content>

<asp:Content ID="TableauBordContent" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <div id="Content" class="Content">
        
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <input type="hidden" id="checked_docs" runat="server" value=""/>
                <div id="bodyTitle">
                    <h3>Tableau de bord</h3>
                </div>
                <div class="row inthebody br_topbody">
                   
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34); border:none; margin-top: -0.5%; padding:3px;">
                                <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" style="text-align: center; margin:-3px;" 
                                    id="ListDocTableauBord" runat="server"></div>
                                <div style="padding-left:850px">
                                     <a href="#Notification" onmouseover="get_docs()" id="ntif" data-target="#Notification" data-toggle="modal"><button id="validd" runat="server" class="btn btn_cergicolor btn_hover">Valider</button></a>                            
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <%--Modal Notification--%>
    <div id="Notification" class="notification modal fade margin-intelligent  row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vvPas">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvPas" style="float: left; margin-left: 2%">
                        <asp:Label ID="lblPasValideTitreConsult" Text="Confirmation" runat="server" /></strong>

                </div>
                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPas" style="color: black; font-weight: bolder">
                            <asp:Label ID="lblPasValidemessageConsult" Text="En cas de validation La note finale sera égale à la note proposée sur les dossiers sélectionnés  <br/>  Confirmez-vous votre choix?" runat="server" />

                        </p>
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="Validerf" OnClick="Valider_Selection" CssClass="btn btn-primary" Text="Oui" />
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="get_docs()">Non</button>
                </div>
            </div>
        </div>
    </div>
    <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#PasvalideConsult">
        Launch demo modal
    </button>
    
    <script>
        $(".checkboxx").dblclick(function () {
            $(this).prop("checked", false);

        });

        function ligneclick(id) {
            window.location = "FicheSignaletique.aspx?id=" + id;
        }
        $(document).ready(function () {
           // intmy();
        });

        function intmy() {
            // alert("fo");
            var checkboxes = document.getElementsByName('checkboxx');;
            var j = 0;
            for (var i = 0, n = checkboxes.length; i < n; i++) {
                if (checkboxes[i].checked == true) {
                    j++;

                    document.getElementById('ntif').className = 'btn btn-primary';
                }
            }
            if (j == 0) document.getElementById('ntif').className = 'hidden';
        }

        function check(id) {
            if (document.getElementById(id).checked == true) { document.getElementById(id).checked = false; }
            else { document.getElementById(id).checked = true; }
           // intmy();
        }

        function get_docs() {
            // alert("hello");
            //intmy();
            //var checkboxes = document.getElementsByName('checkboxx');
            var checkboxes = document.getElementsByClassName('checkboxx');

            var docs = "";
            for (var i = 0, n = checkboxes.length; i < n; i++) {
                if (checkboxes[i].checked == true) {
                    var doc = "@" + checkboxes[i].value + "@" + checkboxes[i].name;
                    docs += doc;
                }
            }
           //alert(docs);
            $("#<%=checked_docs.ClientID%>").val(docs);
        }
    </script>
    <script>
        //var temp = 0;
        //$(".checkboxx").click(function () {
            
        //    var iid = $(this).attr("id");
        //    //alert(iid);
        //    if (document.getElementById(iid).checked == true && temp == 0) {
        //        temp = 1;
        //    }
        //    else
        //    {
        //        document.getElementById(iid).checked = false;
        //        temp = 0;
        //    }
        //    //if ($(element).is(':radio')) {
        //    //    if ($("#radiooptradiocertifHiddenator").val() == value) {
        //    //        value = 'Non communiqué';
        //    //        $(element).prop("checked", false);
        //    //    }
        //    //    $("#radiooptradiocertifHiddenator").val(value);
        //    //}
        //});
            
    </script>
    <div id="Scriptos" runat="server">

    </div>
</asp:Content>