<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="ScoringCenter.Scoring.Profil" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="body">
        <div id="Header" class="Header">
            <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
        </div>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu pureCssMenum">
                <li class="pureCssMenui" id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
                <li class="pureCssMenui"  id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
                <li class="pureCssMenui "  id="TB" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui pull-right" style = "" id="DOC" runat="server">
                    <a style="/*font-family: cursive;*/" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
	                <ul class="pureCssMenum" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GUT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Guide utilisateur</a></li>
		                <li class="pureCssMenui"  id="MNT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Modèle de notation</a></li>
	                </ul>
                </li>
                <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                   <a style="/*font-family: cursive;*/ background-color: #022D65;" class="pureCssMenui" href="#">
                       <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                       <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
	                <ul class="pureCssMenum" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GP" runat="server"><a style="/*font-family: cursive;*/ background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
		                <li class="pureCssMenui"  id="GU" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>

		                <li class="pureCssMenui"  id="GPA" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Parametre.aspx">Gestion des paramètres</a></li>
                         <li class="pureCssMenui " id="Cen" runat="server" ><a style="/*font-family: cursive; */" class="pureCssMenui" href="Cencours.aspx">Charger Encours</a></li>	
	                    <li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="ChargeContrepartie.aspx">Charger Contrepartie</a></li>	        
                                       

	                </ul>
                </li>
            </ul>
        </div>

        <div class="br_top">
            <div id="Content" class="Content br_top">
                <br class="br_top" />
                <input type="text" runat="server" id="connmou007" hidden />
                <div id="thebody" class="noBackground">
                    <div id="bodyTitle">
                        <h3>Gestion des profils</h3>
                    </div>
                    <div class="row inthebody" style="background-color:rgba(208, 245, 117, 0.34); box-shadow:rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius:4px 4px; margin-left:5%; margin-right:5%;">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="row" style="margin-bottom: 2%; text-align: left;">
                                    <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: left">
                                        <span>( <label style="color: red;">*</label>) Champs Obligatoires</span>
                                    </div>
                                    <div class="col-lg-8 col-sm-8 col-md-8">
                                        <div style="display: inline; text-align: left; margin-left: 80%;">
                                            <button 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="margin-right:5px;color:#092851; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Nouveau"   onmousedown="con007($(this),'B')"
                                                runat="server" 
                                                id="btnNouveau"
                                                onserverclick="btnNouveau_ServerClick">
                                                <span class=" glyphicon glyphicon-plus-sign"></span>
                                            </button>
                                           
                                            <button 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="margin-right:5px;color:#0a8f3a; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Valider"   onmousedown="con007($(this),'B')"
                                                runat="server" 
                                                id="btnValider"
                                                onserverclick="btnValider_ServerClick">
                                                <span class=" glyphicon glyphicon-ok"></span>
                                            </button>
                                            
                                            <button 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="margin-right:5px;color:red; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Supprimer" 
                                                runat="server"   onmousedown="con007($(this),'B')"
                                                id="btnSupprimer"
                                                onserverclick="btnSupprimer_ServerClick">
                                                <span class=" glyphicon glyphicon-trash"></span>
                                            </button>
                                            <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Nouveau" 
                                                runat="server" id="btnNouveau" onserverclick="btnNouveau_ServerClick">
                                                <span class=" glyphicon glyphicon-edit"></span></button>--%>
                                            <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Valider" 
                                                runat="server" id="btnValider" onserverclick="btnValider_ServerClick">
                                                <span class=" glyphicon glyphicon-ok"></span></button>--%>
                                            <%--<button class="btn btn-sm btn-primary" type="submit" data-toggle="tooltip" title="Supprimer" 
                                                runat="server" id="btnSupprimer" onserverclick="btnSupprimer_ServerClick">
                                                <span class=" glyphicon glyphicon-trash"></span></button>--%>
                                             <asp:TextBox ID="TbIdProfil" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 col-sm-12 col-md-12">
                                        <div class="row push_entete">
                                            <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" 
                                                style="text-align: right;">
                                                Libelle du profil
                                                <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                <asp:TextBox ID="TbNLibelleP" runat="server"   onmousedown="con007($(this),'T')" CssClass="form-control" 
                                                    style="height:24px;padding-top:0px;padding-bottom:0px;" Width="260"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row push_entete">
                                            <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" 
                                                style="text-align: right;">
                                                Plafond
                                                <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                <asp:TextBox ID="TbNPlafond"  runat="server" CssClass="form-control cergiDecimalMoney" nbDecimal="0"   onmousedown="con007($(this),'B')"
                                                    style="height:24px;padding-top:0px;padding-bottom:0px;" Width="260" MaxLength="13"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row push_entete">
                                            <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" 
                                                style="text-align: right;">
                                                Code du profil
                                                <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-2 col-sm-2 col-md-2">
                                                <asp:TextBox ID="TbICodePro" runat="server" CssClass="form-control Uper"   onmousedown="con007($(this),'B')"
                                                     style="height:24px;padding-top:0px;padding-bottom:0px;" Width="260" MaxLength="4"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row push_entete">
                                            <div class="col-lg-2 col-sm-2 col-md-2 col-lg-offset-4 col-sm-offset-4 col-md-offset-4" 
                                                style="text-align: left;">
                                                <asp:CheckBox runat="server" ID="EtatProfil" CssClass="Ddlsize" />
                                                <span>Activer ce profil</span>
                                            </div>
                                        </div>
                                        <div class="row push_entete">
                                            <div class="col-lg-6 col-sm-6 col-md-6 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" 
                                                id="getMessage" runat="server"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-sm-12 col-md-12 table-responsive">
                                <br />
                                <table class="table table-bordered table-hover" id="dataTablesexample">
                                    <thead class="table-heigth">
                                        <tr>
                                            <th style="width: 5%;">Code</th>
                                            <th>Libellé</th>
                                            <th style="width: 25%">Plafond</th>
                                            <th style="width: 5%">Etat</th>
                                            <th style="width: 12%" class='display'>Id Profil</th>
                                        </tr>
                                    </thead>
                                    <tbody runat="server" id="ListProfil" ></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </div>
        <%--Modal Notification--%>
        <div id="notification" class="notification modal fade margin-intelligent row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="" style="float: left; margin-left: 2%">
                             <asp:Label ID="titleNotification" runat="server" /></strong>
                    </div>
                    <div class="modal-body" id="" style="margin: 0%; padding: 0 !important">
                        <div class="alert alert-info row" role="alert" style="margin: 2%">
                            <p id="" style="color: black; font-weight: bolder">
                                <asp:Label ID="messageNotification" runat="server" />
                            </p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">OK</button>
                    </div>
                </div>
            </div>
        </div>
        <%--<div id="" class="notification modal fade margin-intelligent row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="" style="float: left; margin-left: 2%">
                            <asp:Label ID="titleNotification" runat="server" /></strong>
                    </div>
                </div>
                <div class="modal-body" id="" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="" style="color: black; font-weight: bolder">
                            <asp:Label ID="messageNotification" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">
                        <asp:Label ID="btnTexte" runat="server"></asp:Label>
                    </button>
                </div>
            </div>
        </div>--%>

        <%--Modal Notification--%>
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

        <%--Modal Notification--%>
        <div id="valideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="vv">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
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
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" id="ShowvalideOpenConsult" onserverclick="ShowvalideOpenConsult_ServerClick" runat="server">Valider</button>
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">Annuler</button>
                    </div>
                </div>
            </div>
        </div>

        <div id="timing" class="notification modal fade margin-intelligent timing row" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" id="vv">
                        <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="vvv" style="float: left; margin-left: 2%">TIMING Couleur </strong>
                    </div>
                    <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                        <div class="row push_entete">
                            <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right;">
                                Nombres du jours<label style="color: red">*</label>
                            </div>
                            <div class="col-lg-2 col-sm-2 col-md-2">
                                <input type="text" class="form-control Compte_Caisse" runat="server" id="nombre" aria-describedby="telbur" />
                            </div>
                        </div>
                        <div class="row push_entete">
                            <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right;">
                                Couleur<label style="color: red">*</label>
                            </div>
                            <div class="col-lg-2 col-sm-2 col-md-2">
                                <input type="color" class="form-control Compte_Caisse" runat="server" id="couleur" aria-describedby="telbur" />
                            </div>
                        </div>
                        <div class="row push_entete">
                            <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-3 col-sm-offset-3 col-md-offset-3" style="padding-left: 4.8%;">
                                (
                                <label style="color: red">*</label>) Champs Obligatoires
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="Button1" CssClass="btn btn-cergicolor" OnClick="ShowvalideOpen" runat="server" Text="Valider"  />--%>
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" id="TIMINGOpenConsult" runat="server" onserverclick="TIMINGOpenConsult_ServerClick">Valider</button>
                        <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">Annuler</button>
                    </div>
                </div>
            </div>
        </div>

        <button type="button" style="display: none;" id="ShowvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#valideConsult">
            Launch demo modal
        </button>

        <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#PasvalideConsult">
            Launch demo modal
        </button>
        <div id="Scriptos" runat="server">

    </div>
    </div>

    <script>
        $(document).ready(function () {
            $('.numeric').numeric(this, 0);
            $('.number').number(this, 0);
        });
        function separateur(id) {
            var d = id.value
            id.value = d.toString().replace(/(\d)([\d]{3})(\.|\s|\b)/, "$1 $2$3");
        }

        function formatInt(ctrl) {
            var separator = " ";
            var int = ctrl.value.replace(new RegExp(separator, "g"), "");
            var regexp = new RegExp("\\B(\\d{3})(" + separator + "|$)");
            do {
                int = int.replace(regexp, separator + "$1");
            }
            while (int.search(regexp) >= 0)
            ctrl.value = int;
        }
        function ShowNotification() {
            $("#notification").click();
        }

        function ShowvalideConsult() {
            $("#ShowvalideConsult").click();
        }

        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        function chargerchamptxt(param) {
            var code_profil = param.closest('tr').find('td').eq(0).html();
            var libelle_profil = param.closest('tr').find('td').eq(1).html();
            var plafond_profil = param.closest('tr').find('td').eq(2).html().replace(/&nbsp;/g, '');
            var id_profil = param.closest('tr').find('td').eq(4).html();
            $('#<%=TbICodePro.ClientID%>').val(code_profil);
            $('#<%=TbNLibelleP.ClientID%>').val(libelle_profil);
            $('#<%=TbNPlafond.ClientID%>').val(plafond_profil);
            $('#<%=TbIdProfil.ClientID%>').val(id_profil);
        }
        function Formate_Milier(nStr) {
            nStr += '';
            x = nStr.split('&nbsp;');
            x1 = x[0];
            x2 = x.length > 1 ? '&nbsp;' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + '&nbsp;' + '$2');
            }
            return x1 + x2;
        }
        $(document).ready(function () {
            function Replace_Space(nStr) {
                x = nStr.split('&nbsp;');
                var retour = '';
                for (i = 0; i <= x.length - 1; i++) {
                    retour += x[i] + '';
                }
                return retour;
            };

            
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