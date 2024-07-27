<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="ParametrePays.aspx.cs" Inherits="ScoringCenter.Scoring.ParametrePays" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="body">
        <div id="Header" style="background: url(../Images/LogoAndifi1.gif) no-repeat; background-size: 100%" class="Header">
            <div class="col-md-2" style="width: 15%; height: 100%;" id="idimgLogoBanque" runat="server">
            </div>
            <%--                <div  class="col-md-10" style="width:90%; height:100%; background-color:blue" >
                    <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
                </div>--%>
        </div>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu ">
                <li class="pureCssMenui" id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
                <li class="pureCssMenui" id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
                <li class="pureCssMenui " id="TB" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui pull-right" style="" id="DOC" runat="server">
                    <a style="/*font-family: cursive; */" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
                    <ul class="" style="z-index: 10;">
                        <li class="pureCssMenui" id="GUT" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                        <li class="pureCssMenui" id="MNT" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    </ul>
                </li>
                <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                    <a style="/*font-family: cursive; */ background-color: #022D65;" class="pureCssMenui" href="#">
                        <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                        <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                    <ul class="" style="z-index: 10;">
                        <li class="pureCssMenui" id="GP" runat="server"><a class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
                        <li class="pureCssMenui" id="GU" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>

                        <li class="pureCssMenui" id="GPA" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Parametre.aspx">Gestion des paramètres</a></li>
                        <%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>
                        <li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>--%>
                        <li class="pureCssMenui" id="SD" runat="server"><a class="pureCssMenui" style="" href="SeuilDelegataire.aspx">Schémas délégataires</a></li>

                        <li class="pureCssMenui" id="Pay" runat="server"><a style="/*font-family: cursive; */ background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="ParametrePays.aspx">Paramètres Pays</a></li>

                    </ul>
                </li>
            </ul>
        </div>

        <div class="br_top">
            <div id="Content" class="Content br_top">
                <br class="br_top" />
                <input type="text" runat="server" hidden id="connmou007" />
                <div id="thebody" class="noBackground">
                    <div id="bodyTitle">
                        <h3>Parametrage des Pays</h3>
                    </div>
                    <div class="row inthebody" style="background-color: rgba(208, 245, 117, 0.34); box-shadow: rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius: 4px 4px; margin-left: 5%; margin-right: 5%;">
                        <div class="row" style="margin: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="row">
                                    <div class="col-lg-12 col-sm-12 col-md-12">

                                        <div class="row">
                                            <div class="col-lg-12 col-sm-12 col-md-12">
                                                <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right; margin-top: 0.55%;">
                                                    Agences de notation 
                                                </div>
                                                <div class="col-lg-2 col-sm-2 col-md-2 ">
                                                    <select class="form-control" id="StdNot" runat="server" style="height: 24px; padding-top: 0px; padding-bottom: 0px; width: 200px;">
                                                        <option value="STPO" >Standard & Poor's</option>
                                                        <option value="MOOD" disabled="disabled">MOODY'S</option>
                                                        <option value="FITC" disabled="disabled">FITCH</option>

                                                    </select>
                                                </div>
                                                <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1">
                                                    <div class="col-lg-12 col-sm-12 col-md-12 ">

                                                        <button class="hidden btnModifBil btn btn-sm btn-primary button_div pull-right" style="height: 24px; background-color: #c3c3c3; color: rgba(204, 92, 11, 0.84); border: none; padding-top: 0px; padding-bottom: 0px; margin-left: 3px;" title="Annuler"
                                                            runat="server" onserverclick="AnnulerGeneral_ServerClick" id="AnnulerGeneral">
                                                            <span class=" glyphicon glyphicon-remove"></span>
                                                        </button>


                                                        <button class=" hidden btnModifBil btn btn-sm btn-primary button_div pull-right" style="color: #0a8f3a; background-color: #c3c3c3; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" title="Enregistrer"
                                                            onclick="saveGrid()" type="button" id="EnregistrerGeneral">
                                                            <span class=" glyphicon glyphicon-ok"></span>
                                                        </button>

                                                    </div>



                                                </div>

                                            </div>



                                            <div class="col-lg-12 col-sm-12 col-md-12" runat="server" id="getMessage">

                                                <%--  <table class="table table-bordered table-hover" id="">
                                    <thead>
                                        <tr class="table-heigth1">
                                            <th class="text-center">PAYS</th>
                                            <th class="text-center">NOTES</th>
                                            <th class="text-center">PERSPECTIVES</th>
                                            <th class="text-center">DATE MAJ</th>
                                            <th class="text-center">TYPE DE MAJ</th>
                                            <th class="text-center">ACTION</th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody id="ListDocTableauBord" runat="server" style="text-align: center">
                                        <tr>
                                            <td>
                                                TOGO
                                            </td>
                                            <td>
                                                CCC+
                                            </td>
                                            <td>
                                                Negative
                                            </td>
                                            <td>
                                                18/06/2018
                                            </td>
                                            <td>
                                                Manuel
                                            </td>
                                            <td>
                                                <div class="btn-sm btn-primary button_div pull-right"
                                                    style="margin-right: 5px; color:#022451; background-color:#ffffff; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;"
                                                    title="Editer"
                                                    id="EditerHistorique" >
                                                    <span class=" glyphicon glyphicon-edit"></span>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>--%>
                                            </div>

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

        <div id="PasvalideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="vvPas">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="vvvPas" style="float: left; margin-left: 2%">
                            <asp:Label ID="lblPasValideTitreConsult" runat="server" /></strong>
                    </div>

                    <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                        <div class="alert alert-info row" role="alert" style="margin: 2%">
                            <p id="gfdPas" style="color: black; font-weight: bolder">
                                <asp:Label ID="lblPasValidemessageConsult" runat="server" />
                            </p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">OK</button>
                    </div>
                </div>
            </div>
        </div>


        <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#PasvalideConsult">
            Launch demo modal
        </button>
        <div id="Scriptos" runat="server">
        </div>
    </div>

    <script>
        tp = 0;
        $('tr > td').on('click',
            function (e) {
                $("#EnregistrerGeneral").removeClass("hidden");
                $("#<%=AnnulerGeneral.ClientID%>").removeClass("hidden");
                closeWalkingInput();
                cellClick(e);
            });

            function cellClick(e) {
                var newCell = $(e.target);
                var oldCell = $('#_walking_input').closest('td');
                var tamponVal = 0;
                if (!$(newCell).hasClass('_dynamic')) {
                    if (!$(newCell).hasClass('_walking_input')) {
                        $(newCell).addClass('_input_cell');
                        $(oldCell).removeClass('_input_cell');
                        closeWalkingInput();
                        $(newCell).css('padding', '0');
                        tamponVal = $(newCell).html();
                        $(newCell).html('<input style="width:100%;" type="text" id="_walking_input" />');
                        $(newCell).find('input').val(tamponVal);
                        $(newCell).find('input').focus();
                    }
                }
            };
            $('#datatable_bord').DataTable({
                "paging": false,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": false,
                "autoWidth": false,
                "scrollCollapse": false
            });
            function closeWalkingInput() {
                var cell = $('#_walking_input').closest('td');
                //$(cell).css('padding', '8px');
                $(cell).html($('#_walking_input').val());

                //updateGridValues();
            }

            $(".IndivValid").click(function () {
                alert();
                $(this).hide();
                $(this).parent().find(".IndivAnnul").hide();
                var ppp = $(this).parent().parent();
                var cont = ppp.find('td').eq(1).find("input").val();
                ppp.find('td').eq(1).html(cont);
                var cont = ppp.find('td').eq(2).find("input").val();
                ppp.find('td').eq(2).html(cont);
            });
            $(".IndivAnnul").click(function () {
                alert();
                $(this).hide();
                $(this).parent().find(".IndivValid").hide();
                var ppp = $(this).parent().parent();
                var cont = ppp.find('td').eq(1).find("input").attr('id');
                ppp.find('td').eq(1).html(cont);
                var cont = ppp.find('td').eq(2).find("input").attr('id');
                ppp.find('td').eq(2).html(cont);
            });
            function rowProperties(_nom_pays, _pays_code, _note, _perspective, _datemaj) {
                this.pays_code = _pays_code;
                this.nom_pays = _nom_pays;
                this.note = _note;
                this.perspective = _perspective;
                this.datemaj = _datemaj;
            }
            function saveGrid() {
                closeWalkingInput();
                var gridRows = new Array();
                var i = 0;
                $('#<%=getMessage.ClientID%> table > tbody > tr:not(._dynamic)').each(function () {
                    var col0 = $(this).find('td').eq(0).html(); 
                    var col1 = $(this).find('td').eq(1).html();
                    var col2 = $(this).find('td').eq(2).html();
                    var col3 = $(this).find('td').eq(3).html();

                    if (!((col1 === '' && col1 === 'null') ||
                        (col2 === '' && col2 === 'null') ||
                        (col3 === '' && col3 === 'null')
                    )) {
                        gridRows[i++] = new rowProperties(
                            (col0),
                            $(this).attr('id'),
                            (col1),
                            (col2),
                            (col3));
                    }
                });

                var gridRowsJson = JSON.stringify(gridRows);
                $.ajax({
                    type: 'POST',
                    url: 'ParametrePays.aspx/Save',
                    data: "{ 'inv': '" + gridRowsJson + "','StdNots': '" + $("#<%=StdNot.ClientID%>").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                }, success: function (result) {
                }, error: function () {
                }
            });
        }


        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $(".filecss").fileinput({
            showUpload: false,
            showCaption: false,
            browseClass: "btn btn-primary btn-lg",
            fileType: "any",
            previewFileIcon: "<i class='glyphicon glyphicon-king'></i>"
        });
    </script>

</asp:Content>
