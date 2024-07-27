<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalyseQualitative.aspx.cs" Inherits="ScoringCenter.Scoring.AnalyseQualitative" %>

<asp:Content ID="AnalyseQualitativeMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
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
            <span class="col-xs-12 sub_menus" style="padding:0">
                <span class="col-xs-4" style="text-align:left; padding:10px">
                    <asp:Label ID="LblModeleNotation" runat="server"> </asp:Label></>
                    <asp:Label ID="LblADireExpert" runat="server"> </asp:Label></>
                </span>
                <span class="col-xs-8">
                    <span class="col-xs-12 sub_menus_dn">
                            <li class="pureCssMenu" id="NCP" runat="server"><a class="pureCssMenui active_menu" href="#">Notation de la contrepartie</a></li>
                            <li class="pureCssMenu" id="NOP" runat="server"><a class="pureCssMenui" href="#">Notation de l'opération</a></li>
                            <li class="pureCssMenui" id="VN" runat="server"><a class="pureCssMenui" href="ValidationNote.aspx">Validation de la note</a></li>
                    </span>
                    <span class="col-xs-12">
                        <span class="sub_menu_ncp">
                            <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                            <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                            <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui active_menu" href="#">Analyse qualitative</a></li>
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

<asp:Content ID="AnalyseQualitativeBody" ContentPlaceHolderID="ContentBody" runat="server">
    <style>
                   
        .divlod{
            position:fixed;
            top:25px;
            left:10px;
        }
        .loader {
            
            /*border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid blue;
            border-bottom: 16px solid blue;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;*/
        }

        @-webkit-keyframes spin {
            0% { -webkit-transform: rotate(0deg); }
            100% { -webkit-transform: rotate(360deg); }
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    </style>

    <div id="Content" class="Content">
        <input type="text" runat="server" id="connmou007"  hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Analyse Qualitative</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%;  margin-right: 2%; margin-top: 0.5%;">
                        <div id="<%--floatant--%>" class="" style="background-color: white">
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
                                                <b><asp:Label ID="Groupe" runat="server" CssClass="boldSize"
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
                                    <div style="width:40%;" class="col-xs-1 notation_space">
                                        <div class="col-xs-6 hidden">
                                            <label class="rm" style="font-style:normal"> Modèle de Notation : </label>
                                            <asp:Label ID="ModeleNotation" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-6 notation_note pull-right">
                                            <label class="rm">Note Qualitative :</label>
                                            <asp:Button ID="NoteQualitative" CssClass="transpa rm" runat="server"/> 
                                        </div>
                                    </div>

                                    <div style="width:3%;" class="col-xs-1"> </div>

                                    <div class="col-xs-1" style="width:22%; margin-top:-0.75%;">
                                        <div class="row">
                                            <div class="col-lg-12">
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
                                                    <span class="col-xs-1 jauge C"> </span>
                                                    <span class="col-xs-1 jauge C-p"></span>
                                                    <span class="col-xs-1 jauge B-m"></span>
                                                    <span class="col-xs-1 jauge B"></span>
                                                    <span class="col-xs-1 jauge B-p"></span>
                                                    <span class="col-xs-1 jauge A-m"></span>
                                                    <span class="col-xs-1 jauge A"></span>
                                                    <span class="col-xs-1 jauge A-p"></span>
                                                </span>
                                                <span class="">
                                                    <span id="mrk-01" class="col-xs-1 marker" ></span>
                                                    <span id="mrk-02" class="col-xs-1 marker"></span>
                                                    <span id="mrk-03" class="col-xs-1 marker"> </span>
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

                                    <div class="col-xs-1" style="width:15%">
                                        <button class="btnModifBil btn btn_cergicolor btn_hover EnregBtn" type="button" id="btnEnregistrerNote" runat="server" onserverclick="Enregistrer_Click" onmousedown="get_docsi();con007($(this),'B')" onmouseover="get_docs()" style="height: 27px; border: none; padding-top: 0px; padding-bottom: 0px;">Calculer</button>
                                    </div>

                                    <div class="hidden edit_space" >
                                        <button class=" btnModifBil btn btn-sm btn-primary button_div pull-right CalcBtn"  id="btnCalculer" onserverclick="Calculer_Click"  onmouseover="get_docs();get_docsi()"  onmousedown="con007($(this),'B')" runat="server"  style="margin-right: 5px; color: #022D65; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" title="Calculer">
                                            <b class="h3">=</b>
                                            <%--<span class="h3">&#x1F5A9;</span>--%>
                                        </button>

                                        <%--<button class=" btnModifBil btn btn-sm btn-primary button_div pull-right EnregBtn"  id="btnEnregistrerNote" runat="server"  onserverclick="Enregistrer_Click" onmousedown="get_docsi();con007($(this),'B')" onmouseover="get_docs()"  style="margin-right: 5px; color: #0a8f3a; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" title="Enregistrer">
                                            <span class=" glyphicon glyphicon-save"></span>
                                        </button>--%>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div id="EspaceQuestionnaire" runat="server">

                        </div>
                        <div style="padding-top: 10px;">
                            <%--<asp:button CssClass="btn btn_cergicolor btn_hover" ID="btnCalculer" OnClick="Calculer_Click"  onmouseover="get_docs();get_docsi()"  onmousedown="con007($(this),'B')" runat="server" Text="Calculer" />--%>
                            <%--<asp:button ID="btnEnregistrerNote" runat="server" cssclass="btn btn_cergicolor btn_hover"  OnClick="Enregistrer_Click" onmousedown="get_docsi();con007($(this),'B')" onmouseover="get_docs()"  Text="Enregistrer" />--%>
                        </div>
                    </div>
                </div>
                <div id="milod" class="row col-lg-12 divlod hidden">
                    <div class="loader"></div>
                </div>
            </div>
        </div>

        <div id="valideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="vv">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="vvv" style="float: left; margin-left: 2%"> Information</strong>
                    </div>
                    <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                        <div class="alert alert-info row" role="alert" style="margin: 2%">
                              <input type="text" id="id_d" hidden />
                            <p id="gfd" style="color: black; font-weight: bolder">
                                 Impossible de calculer la note, Merci d’apporter une réponse à toutes les questions.
                            </p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Button1" CssClass="btn btn-cergicolor" OnClick="ShowvalideOpen" runat="server" Text="Valider"  />--%>
                        <%--<button type="button" class="btn btn-primary" data-dismiss="modal" id="ShowvalideOpenConsult">Oui</button>--%>
                        <%--<button type="button" class="btn btn-primary" data-dismiss="modal" id="ShowvalideOpenConsultNon">Oui</button>--%>
                        <button type="button" class="btn btn-primary" data-dismiss="modal" >ok</button>
                    </div>
                </div>
            </div>
        </div>
        <button type="button" style="display: none;" id="ShowvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#valideConsult">
            Launch demo modal
        </button>
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

        function ShowvalideConsult() {
            $("#ShowvalideConsult").click();
        }

        var positionElementInPage = $('#floatant').offset().top;
        $(window).scroll(
         function () {
             if ($(window).scrollTop() != positionElementInPage) {
                 // fixed
                 //$('#floatant').css({ 'position': "fixed" });
                     if ($(window).scrollTop() > 150) {
                         $('#floatant').addClass('affix').css({ 'z-index': "200", 'margin-top': '0', 'top': '0' });
                         $('#floatant').width(940);


                     } else {
                         $('#floatant').removeClass('affix').css({ 'z-index': "200", 'margin-top': '0', 'top': '0' });
                     }
             }
         });
        //floattant
    </script>

    <script>
        $("#<%=btnCalculer.ClientID%>").mousedown(function () {
           // alert();
            $('#milod').removeClass('hidden');
        });
        $("#<%=btnEnregistrerNote.ClientID%>").mousedown(function () {
            // alert();
            $('#milod').removeClass('hidden');
        });
    </script>

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
            var piko = 0;
            for (var i = 1; i < tableau.length; i++) {
               // alert(i + ' -> ' + tableau[i]);
                // $("#selec" + i).val(tableau[i + 1]);
                if (tableau[i].trim()!="")
                    document.getElementById('' + tableau[i]).selected = true;
                else
                    piko++;

               // document.getElementById("selec" + i).options[document.getElementById("selec" + i).selectedIndex].id = tableau[i + 1];
               //alert(document.getElementById('selec' + i).value);
                
            }
            if (piko != 0) ShowvalideConsult();
            
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