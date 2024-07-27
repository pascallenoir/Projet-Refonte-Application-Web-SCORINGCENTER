<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RisquePays.aspx.cs" Inherits="ScoringCenter.Scoring.RisquePays" %>

<asp:Content ID="RisquePaysMenu" ContentPlaceHolderID="ContentMenu" runat="server">
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
                            <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                            <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                            <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                            <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui active_menu" href="#">Risque pays</a></li>
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

<asp:Content ID="RisquePaysBody" ContentPlaceHolderID="ContentBody" runat="server">
    <div id="Content" class="Content">
        <input type="text" runat="server" id="connmou007"  hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Risque pays</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
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
                                <div style="width:35%;" class="col-xs-1 notation_space">
                                    <div class="col-xs-5">
                                        <label class="rm" style="font-style:normal"> Pays : </label>
                                        <asp:Label ID="NomPays" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-xs-7 notation_note" style="margin-top:-0.5%;">
                                        <label class="rm">Note Pays : </label>
                                        <asp:Button Height="15px" ID="NotePays" CssClass="transpa rm" runat="server"/>
                                    </div>
                                </div>

                                <div class="col-xs-1" style="width:22%; margin-top:-1%;">
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

                                <div style="width:40%;" class="col-xs-1">
                                    <label class="rm col-xs-5">Agence de Notation : </label>
                                    <div class="col-xs-7 ">
                                        <select class="form-control" id="StdNot" runat="server" onserverchange="StdNot_ServerChange"  style="height:24px;padding-top:0px;padding-bottom:0px;margin-left:4px;margin-top:-1%;">
                                            <option value="STPO">Standard & Poor's</option>
                                            <option value="MOOD">MOODY'S</option>
                                            <option value="FITC">FITCH</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="EspaceQuestionnaire" runat="server">

                        </div>
                        <div style="padding-top: 10px;" >
                            <asp:button ID="btnEnregistrerNote" runat="server" OnClick="Enregistrer_Click" onmouseover="get_docsi();con007($(this),'B')" cssclass="btn btn_cergicolor btn_hover"  Text="Enregistrer" />
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

        $(document).ready(function () {
            myload();
        });

        function myload() {

            // var checkboxes = document.getElementsByClassName('Ddltaille padding checkboxx');
            var docs = "";
            docs = $("#<%=Hidden1.ClientID%>").val();

            var chaine = docs;
            //alert(chaine);

            var tableau = chaine.split('@');
            for (var i = 1; i < tableau.length; i++) {
                //alert(i+' -> '+tableau[i]);
                // $("#selec" + i).val(tableau[i + 1]);
                document.getElementById('' + tableau[i]).selected = true;
                // document.getElementById("selec" + i).options[document.getElementById("selec" + i).selectedIndex].id = tableau[i + 1];
                //alert(document.getElementById('selec' + i).value);

            }
           
            // get_docs();

        }
        function get_docsi() {

            var checkboxes = document.getElementsByClassName('checkboxx');
            var docs = "";
            for (var i = 0, n = checkboxes.length; i < n; i++) {


                var option_user_selection_id = document.getElementById("selec" + i).options[document.getElementById("selec" + i).selectedIndex].id
                //var doc = "@" + checkboxes[i].id;

                var doc = "@" + option_user_selection_id.trim();
                docs += doc;

            }

            $("#<%=checked_docs.ClientID%>").val(docs);
            //alert(docs);
            //alert('');
        }

        function get_docs() {

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