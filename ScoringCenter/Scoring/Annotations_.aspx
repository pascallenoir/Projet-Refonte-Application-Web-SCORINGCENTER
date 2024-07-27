<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableSessionState="True" AutoEventWireup="true" CodeBehind="Annotations.aspx.cs" Inherits="ScoringCenter.Scoring.Notes" %>

<asp:Content ID="NotesMenu" ContentPlaceHolderID="ContentMenu" runat="server">

    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu pureCssMenum">                 
	        <li class="pureCssMenui"  id="AD" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui "  id="TB" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui "  id="FS" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui"  id="HN" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="HistoriqueNotation.aspx">Historique de notation</a></li>
            <li class="pureCssMenui"  id="DN" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Dossier de notation <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                <ul class="pureCssMenum" style="z-index: 10;">
		            <li class="pureCssMenui"  id="AF" runat="server"><a style="/*font-family: cursive;*/ " class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                    <li class="pureCssMenui"  id="AQ" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                    <li class="pureCssMenui" id="IG" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                    <li class="pureCssMenui"  id="RP" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                    <li class="pureCssMenui"  id="E" runat="server"><a  class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                    <li class="pureCssMenui"  id="VN" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="ValidationNote.aspx" >Validation de note</a></li>
                </ul>
            </li>
            <li class="pureCssMenui"  id="AN" runat="server"><a style="/*font-family: cursive;*/  background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
	        <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a style="/*font-family: cursive; */" class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="pureCssMenum" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#">Guide utilisateur</a></li>
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#">Modèle de notation</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right"  id="EBF" runat="server" style=""><a style="/*font-family: cursive;*/" class="pureCssMenui" href="EnvoiBilanFinancier.aspx">Envoi Bilan financier</a></li>
        </ul>
    </div>

</asp:Content>

<asp:Content ID="NotesBody" ContentPlaceHolderID="ContentBody" runat="server">
    
    <div id="Content" class="Content">
        <br class="br_top" />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Annotations</h3>
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
                                                    Text="Activité BCEAO : "></asp:Label></b> &nbsp;
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
                        <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: 3%;">
                            <div style="height: 150px; max-height: 150px; padding-left: 0.8%;" class="row">
                                <div style="overflow-y: scroll; height: 156%;" class="col-lg-12 col-sm-12 col-md-12" 
                                    id="intermess" runat="server">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div style="padding-left: 0.8%;">
                                <div class="col-lg-7 col-sm-7 col-md-7">
                                    <asp:TextBox ID="TbCommentaire" placeholder="Saisissez vos commentaires ..." runat="server" TextMode="MultiLine" CssClass="CommentLine form-control"
                                        Height="85px" Width="100%"></asp:TextBox>
                                    <input type="hidden" id="MyName" runat="server" />
                                    <input type="hidden" id="MyNameUs" runat="server" />
                                </div>
                                <br /><br />
                                <div class="col-lg-4 col-sm-4 col-md-4">
                                    <div class="row">
                                        <label style="color: darkslateblue; font-weight: bolder">
                                            <label for="file">Sélectionner fichier : </label>
                                            <input type="file" name="file" id="fileTxt" runat="server"  />
                                        </label>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-offset-6 col-sm-offset-6 col-md-offset-6" style="margin-top: 1%;">
                                            <asp:Button data-toggle="tooltip" runat="server" Text="Enregistrer"
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
                    <asp:Button ID="supprimer" CssClass="btn btn-primary" runat="server" OnClick="Unnamed2_Click" Text="Ok" />
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
    </script>

</asp:Content>