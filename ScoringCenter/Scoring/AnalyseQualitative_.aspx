<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalyseQualitative.aspx.cs" Inherits="ScoringCenter.Scoring.AnalyseQualitative" %>

<asp:Content ID="AnalyseQualitativeMenu" ContentPlaceHolderID="ContentMenu" runat="server">

    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">                 
	        <li class="pureCssMenui" id="AD" runat="server" ><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui "  id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui "  id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui"  id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui"  id="DN" runat="server"><a style="background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="" style="z-index: 10;">
		            <li class="pureCssMenui"  id="AF" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui"  id="AQ" runat="server"><a style=" background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a  class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui"  id="RP" runat="server"><a <%--style="color:#d8d8d8"--%> class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui"  id="E" runat="server"><a  class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                    <li class="pureCssMenui"  id="VN" runat="server"><a  class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
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

<asp:Content ID="AnalyseQualitativeBody" ContentPlaceHolderID="ContentBody" runat="server">
   
    <div id="Content" class="Content">
        <br class="br_top" />
        <input type="text" runat="server" id="connmou007"  hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Analyse Qualitative</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%;  margin-right: 2%; margin-top: 0.5%;">
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
                                <div class="col-md-12 notation_space">
                                    <div class="col-xs-6">
                                        <label class="rm" style="font-style:normal"> Modèle de Notation : </label>
                                        <asp:Label ID="ModeleNotation" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-xs-2 col-xs-offset-1 notation_note">
                                        <label class="rm">Note Qualitative :</label>
                                        <asp:Button ID="NoteQualitative" CssClass="transpa rm" runat="server"/> 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="EspaceQuestionnaire" runat="server">

                        </div>
                        <div style="padding-top: 10px;">
                            <asp:button CssClass="btn btn_cergicolor btn_hover" ID="btnCalculer" OnClick="Calculer_Click"  onmouseover="get_docs();get_docsi()"  onmousedown="con007($(this),'B')" runat="server" Text="Calculer" />
                            <asp:button ID="btnEnregistrerNote" runat="server" cssclass="btn btn_cergicolor btn_hover"  OnClick="Enregistrer_Click" onmousedown="get_docsi();con007($(this),'B')" onmouseover="get_docs()"  Text="Enregistrer" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="checked_docs" value="" runat="server" />
        <input type="hidden" id="Hidden1" value="" runat="server" />
        <input type="hidden" id="Totcha" value="0" runat="server" />
        <input type="hidden" id="valnote" runat="server" />
        <input type="hidden" id="valnotecalc" runat="server" />
        <input type="hidden" id="fili" runat="server" />
         <input type="hidden" id="notifHiddenF" /> 

        <br />
        <div id="Scriptos" runat="server">

    </div>
    </div>
    <script>
        $("#notifHiddenF").val("Analyse Qualitative");

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

        function Calc_get_docs()
        {
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
        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);

        }


    </script>

    

</asp:Content>