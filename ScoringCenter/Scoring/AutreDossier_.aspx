<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master"  AutoEventWireup="true" CodeBehind="AutreDossier.aspx.cs" Inherits="ScoringCenter.AutreDossier" %>

<asp:Content ID="AutreDossierBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="body">
        <div id="Header" class="Header">
            <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
        </div>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu pureCssMenum">
                <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
                <li class="pureCssMenui " id="TB" runat="server" ><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui " id="Con" runat="server" ><a style="/*font-family: cursive; */" class="pureCssMenui" href="Contrepartie.aspx">Créer Prospect</a></li>

                <li class="pureCssMenui pull-right" style = "" id="DOC" runat="server">
                    <a style="/*font-family: cursive;*/" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
	                <ul class="pureCssMenum" style="z-index: 10;">
		                <li class="pureCssMenui"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Guide utilisateur</a></li>
		                <li class="pureCssMenui"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Modèle de notation</a></li>
	                </ul>
                </li>
                <li class="pureCssMenui pull-right"  style = "" id="PARAM" runat="server">
                   <a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">
                       <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                       <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
	                <ul class="pureCssMenum" style="z-index: 10;">
		                <li class="pureCssMenui" id="GP" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
		                <li class="pureCssMenui" id="GU" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>
		                <li class="pureCssMenui" id="GPA" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Parametre.aspx">Gestion des paramètres</a></li>
	                    <li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Charger Encours</a></li>	        
	                    <li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="ChargeContrepartie.aspx">Charger Contrepartie</a></li>	        
	                </ul>
                </li>
            </ul>
        </div>
        <div class="br_top">
        
        <div id="Content" class="Content br_top">
            <br class="br_top" />
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Recherche du tiers</h3>
                </div>
                <div class="row inthebody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row">
                                <div class="col-lg-10 col-sm-10 col-md-10 col-lg-push-1" style="background-color:rgba(208, 245, 117, 0.34); box-shadow:rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius:4px 4px; margin-left:0.5%; margin-right:5%;">
                                    <div class="row push_entete">
                                        <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right; margin-top:0.55%;">
                                            Agence
                                            <label style="color: red">*</label>
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3">
                                            <select runat="server" id="DdlAgence" class="form-control" style="height:24px;padding-top:0px;padding-bottom:0px; Width:300px;" >
                                                <option></option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row push_entete">
                                        <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right; margin-top:0.55%;">
                                            Identifiant
                                        </div>
                                        <div class="col-lg-2 col-sm-2 col-md-2">
                                            <asp:TextBox ID="TbIContrepartie" runat="server" CssClass="form-control" Style="height:24px;padding-top:0px;padding-bottom:0px;"  Width="300"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row push_entete">
                                        <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right; margin-top:0.55%;">
                                            Nom de la contrepartie
                                        </div>
                                        <div class="col-lg-3 col-sm-3 col-md-3">
                                            <asp:TextBox ID="TbNContrepartie" runat="server" CssClass="form-control" Style="height:24px;padding-top:0px;padding-bottom:0px;" Width="300"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    
                                    <%--<div class="row push_entete">
                                        <div class="col-lg-3 col-sm-3 col-md-3 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right;">
                                            Identifiant Principale
                                        </div>
                                        <div class="col-lg-2 col-sm-2 col-md-2">
                                            <asp:TextBox ID="TbIPrincipale" runat="server" CssClass="form-control" Style="padding:4px;" Height="28" Width="300"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <div class="row push_entete">
                                        <div class="col-lg-1 col-sm-1 col-md-1 col-lg-offset-4 col-sm-offset-4 col-md-offset-4" style="padding-left: 2%;">
                                            <%--<asp:Button ID="Ok" runat="server" CssClass="btn btn_cergicolor btn_hover contt" OnClick="Ok_Click1" Text="Ok" /> 
                                        --%>
                                            <button 
                                            class="btn btn-sm button_div pull-right"  
                                            style="height:24px; background-color:#c3c3c3; color:#1f1c33; border:none; padding-top:0px; padding-bottom:0px;" 
                                            title="Rechercher"
                                            runat="server"
                                            id="Ok"
                                            onserverclick="Ok_Click1">
                                            <span class=" glyphicon glyphicon-search"></span>
                                            </button>
                                            
                                        </div>
                                        <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-3 col-sm-offset-3 col-md-offset-3" style="padding-left: 4.8%;">
                                            (
                                            <label style="color: red">*</label>) Champs Obligatoires
                                        </div>
                                        
                                    </div>
                                    
                                   

                                    <div class="row push_entete">
                                        <div class="col-lg-6 col-sm-6 col-md-6 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessage" runat="server"></div>
                                    </div>
                                    <div class="col-lg-12 col-m-12 col-md-12 2" style="background-color:transparent;" id="ListDFinanciers" runat="server">
                          
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

    <div id="timing" class="notification modal fade margin-intelligent timing row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vv">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvv" style="float: left; margin-left: 2%">Gestion des alerts</strong>
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
                            <input type="color" value="#FFFFFF" class="form-control Compte_Caisse" runat="server" id="couleur" aria-describedby="telbur" />
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
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" id="ShowvalideOpenConsult" onserverclick="ShowvalideOpenConsult_ServerClick" runat="server">Valider</button>
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">Annuler</button>
                </div>
            </div>
        </div>
    </div>

    <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#PasvalideConsult">
        Launch demo modal
    </button>

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
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">OK </button>
                </div>
            </div>
        </div>
    </div>

    <script>

        function ligneclick(id) {
            window.location = "FicheSignaletique.aspx?id=" + id;
        }
        
        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $(document).ready(function () {
            $(".DdlsizeSearch").selectpicker({
                liveSearch: true,
                maxOptions: 1
            });
            //$(".contt").attr('readonly', 'readonly');
           // document.getElementsByClassName('btn btn_cergicolor btn_hover contt').readonly = 'readonly'
        });
    </script>
    <div id="Scriptos" runat="server">

    </div>


</asp:Content>