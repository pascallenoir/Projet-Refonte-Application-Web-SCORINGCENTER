<%@ Page Language="C#" enableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/PremierePage.Master" CodeBehind="Utilisateur.aspx.cs" Inherits="ScoringCenter.Scoring.Utilisateur" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="body">
        <div id="Header" style="background:url(../Images/LogoAndifi1.gif) no-repeat;background-size: 100%" class="Header">
                <div class="col-md-2" style="width:15%; height:100%;"  id="idimgLogoBanque" runat="server"  >
                    
                </div>
<%--                <div  class="col-md-10" style="width:90%; height:100%; background-color:blue" >
                    <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
                </div>--%>
            </div>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu ">
                <li class="pureCssMenui"  id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
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
                        <%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>--%>
                        <%--<li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>--%>
                        <li class="pureCssMenui" id="Pay" runat="server"><a class="pureCssMenui" href="ParametrePays.aspx">Paramêtres Pays</a></li>
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
                                                title="Nouveau" 
                                                runat="server"  onmousedown="con007($(this),'B')" 
                                                id="btnNouveau"
                                                onserverclick="btnNouveau_ServerClick">
                                                <span class=" glyphicon glyphicon-plus-sign"></span>
                                            </button>
                                            <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Nouveau" 
                                                runat="server" id="btnNouveau" onserverclick="btnNouveau_ServerClick">
                                                <span class=" glyphicon glyphicon-edit"></span></button>--%>
                                            <button 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="margin-right:5px;color:#0a8f3a; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Valider" 
                                                runat="server"  onmousedown="con007($(this),'B')" 
                                                id="btnValider"
                                                onserverclick="btnValider_ServerClick">
                                                <span class=" glyphicon glyphicon-ok"></span>
                                            </button>
                                            <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Valider" 
                                                runat="server" id="btnValider" onserverclick="btnValider_ServerClick">
                                                <span class=" glyphicon glyphicon-ok"></span></button>--%>
                                            <button 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="margin-right:5px;color:red; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Supprimer" 
                                                runat="server"  onmousedown="con007($(this),'B')" 
                                                id="btnSupprimer"
                                                onserverclick="btnSupprimer_ServerClick">
                                                <span class=" glyphicon glyphicon-trash"></span>
                                            </button>
                                            <%--<button class="btn btn-sm btn-primary" type="submit" data-toggle="tooltip" title="Supprimer" 
                                                runat="server" id="btnSupprimer" onserverclick="btnSupprimer_ServerClick">
                                                <span class=" glyphicon glyphicon-trash"></span></button>--%>
                                             <asp:TextBox ID="TbIdUtilisateur" runat="server" CssClass="form-control Ddlsize display" 
                                                 Width="40"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4" 
                                                style="text-align: right;">
                                                Agence <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7" style="">
                                                <%--<asp:TextBox runat="server" ID="TbAgence" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control" Width="150"></asp:TextBox>--%>

                                                <select runat="server" id="DdlAgence"  class="form-control" onchange="combo007($(this),'C')" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;" >
                                                <option></option>
                                            </select>
                                            </div>
                                            <%--<div class="col-lg-1 col-sm-1 col-md-1" style="text-align: right; margin-left:-15px;">
                                                <button class="btn btn-sm btn-primary" type="button" style="height:24px; background-color:#c3c3c3; color:#1f1c33; border:none; padding-top:2.5px; padding-bottom:0px;"
                                                    title="Chercher l'agence" id="SearchAgence" runat="server">
                                                    <span class=" glyphicon glyphicon-search"></span></button>
                                            </div>--%>
                                            
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4"
                                                style="text-align: right;">
                                                Profil <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <select id="DdlProfil" class="form-control"  onchange="con007($(this),'T')" 
                                                    runat="server" style="height:24px;padding-top:0px;padding-bottom:0px;">
                                                </select>
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
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4"
                                                style="text-align: right;" id="entetPw">
                                          Mot de passe <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server"  ID="TbPassword" style="height:24px;padding-top:0px;padding-bottom:0px;" 
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
                                                <asp:TextBox runat="server" ID="TbEmail" style="height:24px;padding-top:0px;padding-bottom:0px;" 
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4"
                                                style="text-align: right;" id="entetPwConf">
                                                Confirmez mot de passe <label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <asp:TextBox runat="server"  ID="TbConfirm" style="height:24px;padding-top:0px;padding-bottom:0px;" 
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
                                                supérieur hiérarchique<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                <select id="suphierarchique" class="form-control"  onchange="con007($(this),'T')" 
                                                    runat="server" style="height:24px;padding-top:0px;padding-bottom:0px;">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <div class="row push_entete">
                                            <asp:CheckBox runat="server"  onchange="check007($(this),'P')" ID="ChkStatUser" CssClass="Ddlsize" />
                                            <span>Activer cet utilisateur</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-sm-12 col-md-12 table-responsive">
                                <br />
                                <table class="table table-bordered table-hover" id="dataTablesexample">
                                    <thead class="table-heigth">
                                        <tr>
                                            <th>Nom & Prenoms</th>
                                            <th>Nom d'utilisateur</th>
                                            <th>Profil</th>
                                            <th>Agence</th>
                                            <th style="width: 5%">Statut</th>
                                            <th class='display'>Nom</th>
                                            <th class='display'>Prénoms</th>
                                            <th class='display'>Email</th>
                                            <th class='display'>Mot de passe</th>
                                            <th class='display'>Id Utilisateur</th>
                                            <th class='display'>Id Profil</th>
                                            <th class='display'>Id Supp</th>
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
    <script type="text/javascript">
       <%-- $(document).ready(function () {
            $("#<%=SearchAgence.ClientID%>").on("click", function (e) {
                $('#MSearchAgence').modal('show');
            });

            $("#<%=ListAgence.ClientID%>").on("click", "option", function (e) {
                var value = "";
                var listBox = document.getElementById("<%=ListAgence.ClientID%>");
                for (var i = 0; i < listBox.options.length; i++) {
                    if (listBox.options[i].selected) {
                        value = value + listBox.options[i].innerHTML;
                    }
                }

                if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                    $("#<%=TbAgence.ClientID%>").val(value);
                }
                else {
                    $("#<%=TbAgence.ClientID%>").val();
                }
                $("#MSearchAgence").modal('hide');
                return false;
            });

            $("#<%=TbSearchAgence.ClientID%>").on('input', function (e) {
                $("#<%=ListAgence.ClientID%>").empty();
                if ($.trim($("#<%=TbSearchAgence.ClientID%>").val()) != "") {
                    var text = $("#<%=TbSearchAgence.ClientID%>").val();
                    $.ajax({
                        type: "POST",
                        url: "Utilisateur.aspx/searchAgence",
                        data: "{'text': '" + text + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function () { },
                        success: function (response) {
                            $("#<%=ListAgence.ClientID%>").append(response.d[0]);
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            });
        });--%>

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
            var login_user = param.closest('tr').find('td').eq(1).html();
            var profil = param.closest('tr').find('td').eq(10).html();
            var agence = param.closest('tr').find('td').eq(3).html();
            var statut_user = param.closest('tr').find('td').eq(4).html();
            var nom_user = param.closest('tr').find('td').eq(5).html();
            var prenom_user = param.closest('tr').find('td').eq(6).html();
            var email_user = param.closest('tr').find('td').eq(7).html();
            var id_user = param.closest('tr').find('td').eq(9).html();
            var id_supp = param.closest('tr').find('td').eq(11).html();

            var chaine1 = "";
            var Changeable = param.closest('tr').attr('data-pers');
            chaine1 = chaine1 + "SC#G:" + login_user;
            O42451(chaine1);
            $('#<%=DdlAgence.ClientID%>').val(agence);
            
           
            
            //alert(profil);
            $('#<%=TbNom.ClientID%>').val(nom_user);
            $('#<%=TbPrenom.ClientID%>').val(prenom_user);
            $('#<%=suphierarchique.ClientID%>').val(id_supp);
            $('#<%=TbLoginUser.ClientID%>').val(login_user);
         <%--   //$('#<%=TbPassword.ClientID%>').val(password_user);--%>
            $('#<%=TbEmail.ClientID%>').val(email_user);
          <%--  //$('#<%=TbConfirm.ClientID%>').val(password_user);--%>
            $('#<%=TbIdUtilisateur.ClientID%>').val(id_user);
            $('#<%=DdlProfil.ClientID%>').val(profil);
            if (statut_user == "<div class='circle_green'></div>") {
                $('#<%=ChkStatUser.ClientID%>').checked = true;
            }
            else {
                $('#<%=ChkStatUser.ClientID%>').checked = false;
            }
            if (Changeable === "1") {
                //alert('changealble');
                $('#<%=TbConfirm.ClientID%>').val("");
                $('#<%=TbPassword.ClientID%>').val("");
                $('#<%=TbConfirm.ClientID%>').show();
                $('#<%=TbPassword.ClientID%>').show();
                $('#entetPwConf').show();
                $('#entetPw').show();
                
            } else {
                //alert('non changealble');
                $('#<%=TbConfirm.ClientID%>').val("SC Mot de passe a changer");
                $('#<%=TbPassword.ClientID%>').val("SC Mot de passe a changer");
                $('#<%=TbConfirm.ClientID%>').hide();
                $('#<%=TbPassword.ClientID%>').hide();
                $('#entetPwConf').hide();
                $('#entetPw').hide();
            }
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