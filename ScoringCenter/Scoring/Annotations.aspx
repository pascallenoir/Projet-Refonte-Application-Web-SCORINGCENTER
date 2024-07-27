<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableSessionState="True" AutoEventWireup="true" CodeBehind="Annotations.aspx.cs" Inherits="ScoringCenter.Scoring.Notes" %>

<asp:Content ID="NotesMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Dossiers de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Effectuer une notation</a></li>
            <li class="pureCssMenui" id="AN" runat="server"><a class="pureCssMenui active_menu" href="#">Annotations</a></li>
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

<asp:Content ID="NotesBody" ContentPlaceHolderID="ContentBody" runat="server">
    
    <div id="Content" class="Content">
        <br class="br_top" />
        <input type="text" runat="server" id="connmou007" hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Annotations</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%;  margin-right: 2%; margin-top: 0.5%;">
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
                        <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: 3%;">
                            <div style="height: 150px; max-height: 150px; padding-left: 0.8%;" class="row">
                                <div onf style="overflow-y: scroll; height: 156%;" class="col-lg-12 col-sm-12 col-md-12" 
                                    id="intermess" runat="server">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div style="padding-left: 0.8%;">
                                <div class="col-lg-7 col-sm-7 col-md-7">
                                    <asp:TextBox ID="TbCommentaire" placeholder="Saisissez vos commentaires ..." runat="server" onchange="con007($(this),'T')" TextMode="MultiLine" CssClass="CommentLine form-control"
                                        Height="85px" Width="100%"></asp:TextBox>
                                    <input type="hidden" id="MyName" runat="server" />
                                    <input type="hidden" id="MyNameUs" runat="server" />
                                </div>
                                <br /><br />
                                <div class="col-lg-4 col-sm-4 col-md-4">
                                    <div class="row">
                                        <label style="color: darkslateblue; font-weight: bolder">
                                            <label for="file">Sélectionner fichier : </label>
                                            <input type="file" name="file" onclick="con007($(this),'F')" id="fileTxt" runat="server"  />
                                        </label>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-offset-6 col-sm-offset-6 col-md-offset-6" style="margin-top: 1%;">
                                            <asp:Button data-toggle="tooltip" onmousedown="con007($(this),'B')" runat="server" Text="Enregistrer"
                                                class="btn btn-primary" OnClick="Unnamed1_Click" />
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
    </div>
    <%--Modal Notification--%>
    <div id="SUPPMODAL" class="notification modal fade margin-intelligent row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vvPas">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvPas" style="float: left; margin-left: 2%">
                        <asp:Label ID="lblPasValideTitreConsult" Text="INFORMATION..." runat="server" />
                    </strong>
                </div>
                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPas" style="color: black; font-weight: bolder">Voulez-vous le supprimer?</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="supprimer" CssClass="btn btn-primary" runat="server" onmousedown="con007($(this),'B')" OnClick="Unnamed2_Click" Text="Ok" />
                    <button id="ButtonAnn" class="btn btn-primary" runat="server" data-dismiss="modal">Annuler</button>
                </div>
            </div>
        </div>
        <div id="Scriptos" runat="server">

    </div>
        
    </div>
    <script type="text/javascript">
        function Unnamed1_Click(idj, idu) {
            $('#<%=MyName.ClientID%>').val(idj);
            $('#<%=MyNameUs.ClientID%>').val(idu);
        }
        function recharger(idj, idu) {
           
            $('#<%=MyName.ClientID%>').val(idj);
              $('#<%=MyNameUs.ClientID%>').val(idu);
            //init
       
              document.getElementById('<%=TbCommentaire.ClientID%>').Text = "";
            document.getElementById('<%=TbCommentaire.ClientID%>').value = "";
              //attrib
              document.getElementById('<%=TbCommentaire.ClientID%>').Text = document.getElementById(idj).value.trim();
              document.getElementById('<%=TbCommentaire.ClientID%>').value = document.getElementById(idj).value.trim();
            //nomination
        }

        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();

            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });

            //Money Euro
            $("[data-mask]").inputmask();

            //Date range picker
            $('#reservation').daterangepicker();

            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });

            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment()
                },
                function (start, end) {
                    $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
                }
            );

            //Date picker
            $('#datepicker').datepicker({
                autoclose: true
            });

            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            });

            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            });

            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });

            //Colorpicker
            $(".my-colorpicker1").colorpicker();

            //color picker with addon
            $(".my-colorpicker2").colorpicker();

            //Timepicker
            $(".timepicker").timepicker({
                showInputs: false
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
    </script>

</asp:Content>