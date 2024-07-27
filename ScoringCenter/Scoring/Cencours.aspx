<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cencours.aspx.cs" Inherits="ScoringCenter.Scoring.Cencours" %>

<asp:Content ID="EnvoiBilanFinancierMenu" ContentPlaceHolderID="ContentMenu" runat="server">

     <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">    
              <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>             
	        <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
	        <li class="pureCssMenui" id="Con" runat="server"><a class="pureCssMenui" href="Contrepartie.aspx">Creer Prospect</a></li>	        
	        
            
            <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui Aides" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="#">Modèle de notation</a></li>
                </ul>
            </li>

            <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                   <a style="/*font-family: cursive;*/ background-color: #022D65;" class="pureCssMenui" href="#">
                       <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                       <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
	                <ul class="" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GP" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
		                <li class="pureCssMenui"  id="GU" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>
		                <li class="pureCssMenui"  id="GPA" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Parametre.aspx">Gestion des parametres</a></li>
	                    <%--<%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>--%>--%>
                        <li class="pureCssMenui" id="Cen" runat="server"><a style="/*font-family: cursive; */background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>
                        <li class="pureCssMenui" id="Pay" runat="server"><a class="pureCssMenui" href="ParametrePays.aspx">Paramètres Pays</a></li>	        

	                </ul>
                </li>
        </ul>
    </div>

</asp:Content>

<asp:Content ID="EnvoiBilanFinancierBody" ContentPlaceHolderID="ContentBody" runat="server">

    <div id="content" class="Content">
        <br class="br_top" />
            <input type="text" runat="server" id="connmou007" hidden  />
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Les Encours des Contreparties</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">

                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form">
                                <div class="col-lg-12 col-sm-12 col-md-12">
                                    <div class="row push_fulltable col-lg-12 col-sm-12 col-md-12">
                                        <div class="panel panel-default" style="background-color:rgba(208, 245, 117, 0.34); box-shadow:rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius:4px 4px; margin-right:5%; width: 100%; margin-left: 2%">
                                            <%--   <div style="text-align:left">
                                                <label  class="Label_s" style="border:none;font-size:small;color:blue">Choisissessssssssss</label>

                                            </div>--%>
                                            <div class="row" style="margin: 2%;">
                                                
                                            </div>

                                            <div class="row" style="margin-top: 1%;margin:2%">
                                                        <div class="col-lg-12 col-sm-12 col-md-12 table-responsive" style="text-align: center;" 
                                                            id="ListDesEncoursTableau" runat="server"></div>
                                            </div>
                                        </div>
                                        <div class="row push_entete">
                                            <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessage" runat="server"></div>
                                        </div>
<%--                                        <div class="panel panel-default" style="background-color:rgba(208, 245, 117, 0.34); box-shadow:rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius:4px 4px; margin-left:5%; margin-right:5%; width: 100%; margin-left: 2%">
                                         
                                                    
                                         </div>--%>
                                    </div>
                                    
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="Scriptos" runat="server">
    </div>

    <script>
        $(".filecss").fileinput({
            showUpload: false,
            showCaption: false,
            browseClass: "btn btn-primary btn-lg",
            fileType: "any",
            previewFileIcon: "<i class='glyphicon glyphicon-king'></i>"
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