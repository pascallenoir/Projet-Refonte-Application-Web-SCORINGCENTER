<%@ Page Language="C#" enableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/PremierePage.Master" CodeBehind="Utilisateur.aspx.cs" Inherits="ScoringCenter.Scoring.Utilisateur" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="body">
        <div id="Header" style="background:url(../Images/LogoAndifi1.gif) no-repeat;background-size: 100%" class="Header">
            <div class="col-md-2" style="width:15%; height:100%;"  id="idimgLogoBanque" runat="server"></div>
        </div>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu ">
                <li class="pureCssMenui"  id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">Déconnexion</a></li>
                <li class="pureCssMenui"  id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
                <li class="pureCssMenui "  id="TB" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui pull-right" style = "" id="DOC" runat="server">
                    <a style="/*font-family: cursive;*/" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
	                <ul class="" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GUT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#"  data-toggle="modal" data-target="#helpmodal">Guide utilisateur</a></li>
		                <li class="pureCssMenui"  id="MNT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Modèle de notation</a></li>
	                </ul>
                </li>
                <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                   <a style="/*font-family: cursive;*/ background-color: #022D65;" class="pureCssMenui" href="#">
                       <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                       <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
	                <ul class="" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GP" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
		                <li class="pureCssMenui"  id="GU" runat="server"><a style="/*font-family: cursive;*/ background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>		 
                        <li class="pureCssMenui"  id="GPA" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Parametre.aspx">Gestion des paramètres</a></li>
                         <%--<%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>--%>
                        <%--<%--<li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>--%>
                        <li class="pureCssMenui" id="SD" runat="server"><a class="pureCssMenui" style="" href="SeuilDelegataire.aspx">Schémas délégataires</a></li>

                        <li class="pureCssMenui" id="Pay" runat="server"><a class="pureCssMenui" href="ParametrePays.aspx">Paramètres Pays</a></li>
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
                        <h3>Gestion des utilisateurs</h3>
                    </div>
                        <div><span></span></div>
                    <div class="row inthebody" style="background-color:rgba(208, 245, 117, 0.34); box-shadow:rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius:4px 4px; margin-left:5%; margin-right:5%;">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="row" style="margin-bottom: 2%; text-align: left;">
                                    <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: left">
                                        <span>( <label style="color: red;">*</label>) Champs Obligatoires</span>
                                    </div>
                                    <div class="col-lg-8 col-sm-8 col-md-8">
                                        <div style="display: inline; float: right; margin-left: 5%; ">
                                            <asp:Button  id="btnNouveau" runat="server" Text="Nouveau"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Nouveau" onclick="btnNouveau_Click" class="btn btn_cergicolor btn_hover" /> 
                                            <asp:Button  id="btnInitPwd" runat="server" OnClientClick="showPwdLabelInputs(); return false;" Text="Réinitialiser mot de passe" BorderStyle="Solid" ToolTip="Réinitialiser mot de passe" class="btn btn_cergicolor btn_hover" />
                                            <asp:Button  id="btnEnable" runat="server" Text="Activer cet utilisateur"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Activer cet utilisateur" onclick="btnEnabled_Click" class="btn btn_cergicolor btn_hover" /> 
                                            <asp:Button  id="btnDisable" runat="server" Text="Désactiver cet utilisateur"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Désactiver cet utilisateur" onclick="btnDisabled_Click" class="btn btn_cergicolor btn_hover" />
                                            <asp:Button  id="btnValider" runat="server" Text="Valider"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Valider" onclick="btnValider_Click" class="btn btn_cergicolor btn_hover" /> 
                                            <asp:TextBox ID="TbIdUtilisateur" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                            <asp:TextBox ID="TbCodeBanqueRemote" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                            <asp:TextBox ID="TbCodeAgenceRemote" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                            <asp:TextBox ID="TbIdProfilRemote" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                        </div>
                                    </div>                      
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" 
                                                style="text-align: right;">
                                                Banque <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7" style="">
                                                <asp:DropDownList ID="DdlBanque" AutoPostBack="true" title="Liste de banques" onchange="combo007($(this),'C')" CssClass="form-control" runat="server" style="height:24px;padding-top:0px;padding-bottom:0px; width: 110px" OnSelectedIndexChanged="OnBanqueChangeLoadAgences">
                                                 </asp:DropDownList>
                                            </div>                            
                                            
                                        </div>
                                   </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: right;">
                                                Agence <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7" style="">
                                                <select id="DdlAgence" class="form-control"  onchange="con007($(this),'C')" runat="server" disabled="disabled" style="height:24px;padding-top:0px;padding-bottom:0px;"></select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: right;">
                                                Profil <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <select id="DdlProfil" class="form-control"  onchange="con007($(this),'T')" runat="server" disabled="disabled" style="height:24px;padding-top:0px;padding-bottom:0px;"></select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" 
                                                style="text-align: right;">
                                                Nom <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server" ID="TbNom"   onchange="con007($(this),'T')" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4"
                                                style="text-align: right;">
                                                Prénoms <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server" ID="TbPrenom"  onchange="con007($(this),'T')" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" 
                                                style="text-align: right;">
                                                Nom d'utilisateur <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server"  onchange="con007($(this),'T')" ID="TbLoginUser" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div  class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: right;" id="entetPw">
                                                <asp:Label ID="LblPassword" runat="server">Mot de passe<label style="color: red">*</label></asp:Label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server"  ID="TbPassword" hidden="" style="height:24px;padding-top:0px;padding-bottom:0px" 
                                                    CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" 
                                                style="text-align: right;">
                                                Adresse email <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server" id="TbEmail" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" style="text-align: right;">
                                                <asp:Label ID="LblPassworConfirmed" runat="server">Confirmer mot de passe<label style="color: red">*</label></asp:Label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server"  ID="TbConfirm" style="height:24px;padding-top:0px;padding-bottom:0px;" CssClass="form-control" hidden="" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-sm-12 col-md-12" style="margin:20px 0 10px;">
                                <asp:Button  id="btnActifs" runat="server" Text="Afficher actifs"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Actifs" onserverclick="btnActifs" class="btn btn_cergicolor btn_hover float-lt" OnClick="btnActifs_Click" /> 
                                <asp:Button  id="btnInactifs" runat="server" Text="Afficher inactifs"  onmousedown="con007($(this),'B')" BorderStyle="Solid" ToolTip="Inactifs" onserverclick="btnInactifs_ServerClick" class="btn btn_cergicolor btn_hover float-lt" OnClick="btnInactifs_Click" /> 
                            </div>
                            <div class="col-lg-12 col-sm-12 col-md-12 table-responsive">
                                <table class="table table-bordered table-hover" id="dataTablesexample">
                                    <thead class="table-heigth">
                                        <tr>
                                            <th>Nom & Prenoms</th>
                                            <th>Nom d'utilisateur</th>
                                            <th>Email</th>
                                            <th>Profil</th>
                                            <th>Agence</th>
                                            <th>Banque</th>
                                            <th class='display'>Statut</th>
                                            <th class='display'>Id Utilisateur</th>
                                        </tr>
                                    </thead>
                                    <tbody runat="server" id="ListUtilisateur"></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--data-backdrop="static"--%>
        <div id="MSearchAgence" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche de l'agence</strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir l'agence recherché</i><br />
                                <asp:TextBox runat="server" ID="TbSearchAgence" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner l'agence</i><br />
                                <asp:ListBox ID="ListAgence" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
                            <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-3 col-sm-offset-3 col-md-offset-3" style="padding-left: 4.8%;" >
                                (<label style="color: red">*</label>) Champs Obligatoires
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

    <script type="text/javascript">
        function ShowNotification() {
            $("#notification").click();
        }

        function ShowvalideConsult() {
            $("#ShowvalideConsult").click();
        }

        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $('#<%=DdlAgence.ClientID%>, #<%=DdlProfil.ClientID%>, #<%=TbNom.ClientID%>, #<%=TbPrenom.ClientID%>, #<%=TbLoginUser.ClientID%>, #<%=TbEmail.ClientID%>, #<%=TbPassword.ClientID%>, #<%=TbConfirm.ClientID%> ').on('change', function () {
            $('#<%=TbCodeBanqueRemote.ClientID%>').val($('#<%=DdlBanque.ClientID%>').val());
            $('#<%=TbCodeAgenceRemote.ClientID%>').val($('#<%=DdlAgence.ClientID%>').val());
            $('#<%=TbIdProfilRemote.ClientID%>').val($('#<%=DdlProfil.ClientID%>').val());
            $('#<%=btnValider.ClientID%>').show('fast');
        });

        function chargerchamptxt(param) {
            hidePwdLabelInputs();
            var nom_user = param.closest('tr').find('td').eq(0).attr('Data1').replace(/&nbsp;/g, '').replace(',', '');
            var prenom_user = $.trim(param.closest('tr').find('td').eq(0).attr('Data2').replace(/&nbsp;/g, '').replace(',', ''));
            var login_user = $.trim(param.closest('tr').find('td').eq(1).html());
            var email_user = $.trim(param.closest('tr').find('td').eq(2).html());
            var id_profil = $.trim(param.closest('tr').find('td').eq(3).attr('Data').replace(/&nbsp;/g, '').replace(',', ''));
            var code_agence = $.trim(param.closest('tr').find('td').eq(4).attr('Data').replace(/&nbsp;/g, '').replace(',', ''));
            var code_banque = $.trim(param.closest('tr').find('td').eq(5).attr('Data').replace(/&nbsp;/g, '').replace(',', ''));
            var statut_val = param.closest('tr').find('td').eq(6).html();
            var id_user = $.trim(param.closest('tr').find('td').eq(7).html());

            var chn = "";
            var Changeable = param.closest('tr').attr('data-pers');
            chn = chn + "SC#G:" + login_user;
            O42451(chn);

            if (statut_val == 'True') {
                $('#<%=DdlBanque.ClientID%>').attr("disabled", "disabled");
                $("#<%=DdlAgence.ClientID%>").removeAttr("disabled");
                $("#<%=DdlProfil.ClientID%>").removeAttr("disabled");
                $("#<%=TbNom.ClientID%>").removeAttr("disabled");
                $("#<%=TbPrenom.ClientID%>").removeAttr("disabled");
                $("#<%=TbLoginUser.ClientID%>").removeAttr("disabled");
                $("#<%=TbEmail.ClientID%>").removeAttr("disabled");

                $("#<%=btnDisable.ClientID%>").show('fast');
                $("#<%=btnEnable.ClientID%>").hide('fast');
                $('#<%=btnInitPwd.ClientID%>').show('fast');
                $('#<%=btnValider.ClientID%>').hide('fast');
            }
            else {
                $('#<%=DdlBanque.ClientID%>').attr("disabled", "disabled");
                $("#<%=DdlAgence.ClientID%>").attr("disabled", "disabled");
                $("#<%=DdlProfil.ClientID%>").attr("disabled", "disabled");
                $("#<%=TbNom.ClientID%>").attr("disabled", "disabled");
                $("#<%=TbPrenom.ClientID%>").attr("disabled", "disabled");
                $("#<%=TbLoginUser.ClientID%>").attr("disabled", "disabled");
                $("#<%=TbEmail.ClientID%>").attr("disabled", "disabled");

                $("#<%=btnDisable.ClientID%>").hide('fast');
                $("#<%=btnEnable.ClientID%>").show('fast');
                $('#<%=btnInitPwd.ClientID%>').hide('fast');
            }

            $.ajax({
                type: "POST",
                url: "Utilisateur.aspx/LoadAgencesProfilsSelectOptionsHtml",
                data: "{'code_banque': '" + code_banque + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    $('#<%=DdlAgence.ClientID%>').html(response.d._agences);
                    $('#<%=DdlProfil.ClientID%>').html(response.d._profils);
                    $('#<%=DdlBanque.ClientID%>').val(code_banque);
                    $('#<%=DdlAgence.ClientID%>').val(code_agence);
                    $('#<%=DdlProfil.ClientID%>').val(id_profil);
                    $('#<%=TbNom.ClientID%>').val(nom_user);
                    $('#<%=TbPrenom.ClientID%>').val(prenom_user);
                    $('#<%=TbLoginUser.ClientID%>').val(login_user);
                    $('#<%=TbEmail.ClientID%>').val(email_user);
                    $('#<%=TbIdUtilisateur.ClientID%>').val(id_user);
                    hidePwdLabelInputs();
                },
                failure: function (response) { }
            });

            $('.tr_backgr').css("background", "#FFFFFF");
            param.closest('tr').css("background", "#F1F1F1");
        }

        function applySelectBoxEnableDisable() {
            $('select, input').each(function () {
                if ($(this).attr('c-disable') == "1")
                    $(this).attr("disabled", "disabled");
                else $(this).removeAttr("disabled");
            });
        }

        $(document).ready(function () {
            hidePwdLabelInputs();
            hideActionButtons();
            applySelectBoxEnableDisable();
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

        function onload() {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);
        }

        function hidePwdLabelInputs() {
            if ($('#<%=TbIdUtilisateur.ClientID%>').val() != "new") {
                $('#<%=LblPassword.ClientID%>').hide();
                $("#<%=LblPassworConfirmed.ClientID%>").hide();
                $('#<%=TbConfirm.ClientID%>').hide();
                $('#<%=TbPassword.ClientID%>').hide();
            } else showPwdLabelInputs();
        }

        function showPwdLabelInputs() {
            $('#<%=LblPassword.ClientID%>').show();
            $("#<%=LblPassworConfirmed.ClientID%>").show();
            $('#<%=TbConfirm.ClientID%>').val('');
            $('#<%=TbPassword.ClientID%>').val('');
            $('#<%=TbConfirm.ClientID%>').show();
            $('#<%=TbPassword.ClientID%>').show();
        }

        function hideActionButtons() {
            $('#<%=btnValider.ClientID%>').hide();
            $('#<%=btnEnable.ClientID%>').hide();
            $('#<%=btnDisable.ClientID%>').hide();
            $('#<%=btnInitPwd.ClientID%>').hide();
        }
    </script>
</asp:Content>