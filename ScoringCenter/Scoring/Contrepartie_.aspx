<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Contrepartie.aspx.cs" Inherits="ScoringCenter.Scoring.Contrepartie" %>

<asp:Content ID="EnvoiBilanFinancierMenu" ContentPlaceHolderID="ContentMenu" runat="server">

     <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu ">    
              <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>             
	        <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui " id="Con" runat="server" ><a style="/*font-family: cursive; */background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Contrepartie.aspx">Créer Prospect</a></li>
	        <%--<li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Charger Encours</a></li>--%>	        
            <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui" href="#">Modèle de notation</a></li>
                </ul>
            </li>
        </ul>
    </div>

</asp:Content>

<asp:Content ID="EnvoiBilanFinancierBody" ContentPlaceHolderID="ContentBody" runat="server">
   
    <div id="Content" class="Content">
        <br class="br_top" />
        <div class="bigbody">
            <input type="text" runat="server" id="connmou007" hidden />
            <div id="thebody" class="noBackground">
                <div id="bodyTitle">
                    <h3>Créer Prospect</h3>
                </div>
                <div class="row inthebody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">

                                    <div class="row"  >
                                        
                                        
                                                    <div  class="col-lg-12 col-sm-12 col-md-12"  style="margin-bottom:1%;margin-top:-1%;padding-right:5%;">
                                                        <button 
                                                        class="btn btn-sm button_div pull-right"  onmousedown="con007($(this),'B')"
                                                        style="height:24px; background-color:#c3c3c3; color:rgba(204, 92, 11, 0.84); border:none; padding-top:0px; padding-bottom:0px;" 
                                                        title="Annuler"
                                                        runat="server"
                                                        id="btnRefreshBil" onserverclick="btnRefreshBil_ServerClick">
                                                        <span class=" glyphicon glyphicon-remove"></span>
                                                        </button>
                                                        <button 
                                                        class="btn btn-sm button_div pull-right" onmousedown="con007($(this),'B')"
                                                        style="margin-right:5px;color:#0a8f3a; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                        title="Valider" 
                                                        runat="server" 
                                                        id="ValideContrepartie" onserverclick="ValideContrepartie_ServerClick">
                                                        <span class=" glyphicon glyphicon-ok"></span>
                                                        </button> 
                                                        <%--<button class="btn btn-sm btn-primary button_div" id="ValideContrepartie" onserverclick="ValideContrepartie_ServerClick" data-toggle="tooltip" title="Valider" 
                                                            runat="server">
                                                            <span class=" glyphicon glyphicon-ok"></span></button>--%>
                                                        
                                                        <%--<button class=" btnModifBil btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Annuler"
                                                runat="server" id="btnRefreshBil" onserverclick="btnRefreshBil_ServerClick">
                                                <span class=" glyphicon glyphicon-refresh"></span></button>--%>
                                                       </div>
                                                
                                                 </div>

                                                  <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top:-10%; text-align:left;">
                                                        <div class="col-lg-12 col-sm-12 col-md-12" style="padding:0;">
                                                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding:0;">
                                                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);">
                                                                        <div class="EnteteInfo" style="text-align:center"><label for="">Identifiants</label></div>
                                                                        <div class="row push_right" style="margin-left: 6%;">
	                                                                        <div class="col-lg-4 col-sm-4 col-md-4">
		                                                                        Raison sociale
                                                                                 <label style="color: red">*</label>
	                                                                        </div>
	                                                                        <div class="col-lg-7 col-sm-7 col-md-7">
		                                                                        <input type="text" class="form-control" runat="server" onchange="con007($(this),'T')" id="Nom" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"/>
	                                                                        </div>
                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Adresse C.P
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" class="form-control" onchange="con007($(this),'T')" runat="server" id="Adresse" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Ville 
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="Ville" class="form-control" onchange="con007($(this),'T')" runat="server" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                        </div>
                                                                          <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Pays 
                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                           <div class="col-lg-7 col-sm-7 col-md-7">
			                                                                <input type="text" class="form-control" runat="server"  readonly id="TbPays" style="width:76%;height:24px;padding-top:0px;padding-bottom:0px;"/>
		                                                                   <input type="text" class="form-control" id="TbPays1" onchange="con007($(this),'T')" runat="server" style="width:76%;height:85%;display:none"/>
		                                                                </div>
		                                                                <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left:-17%">
			                                                                <a class="btn btn-sm btn-primary" title="Rechercher" id="SearchPays" runat="server" style="height:24px; background-color:#c3c3c3; color:#1f1c33; border:none; padding-top:2.5px; padding-bottom:0px;">
				                                                                <span class=" glyphicon glyphicon-search"></span></a>
			                                                                </div>
                                                                        </div>
                                                                         
                                                                        <div class="row push_right"  style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                N° Régistre du commerce
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="Rccm" onchange="con007($(this),'T')" class="form-control" runat="server" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                        </div>

                                                                        <%--<div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Pays 
                                                                                 <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="Pays" class="form-control" runat="server" style="width:100%;height:85%"/>
                                                                            </div>
                                                                        </div>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12 col-sm-12 col-md-12">
                                                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);">
                                                                        <div class="EnteteInfo" style="text-align:center"><label for="">Informations Bancaires</label>

                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Segment clientèle 
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="Segment" value="Segment ()" onchange="con007($(this),'T')" class="form-control" runat="server" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Agence 
                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                             <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                 <select runat="server" id="DdlAgence"  class="form-control" onchange="combo007($(this),'C')" style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;" >
                                                <option></option>
                                            </select>
                                                                                <%--<input type="text" class="form-control" id="TbAgence" runat="server" readonly style="width:76%;height:85%"/>
                                                                                 <input type="text" class="form-control" id="TbAgence1" runat="server" style="width:76%;height:85%;display:none"/> --%>
                                                                            </div>
                                                                       <%--     <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left:-17%">
                                                                                <a class="btn btn-sm btn-primary" title="Chercher l'agence" id="SearchAgence" runat="server" style="height:65%;text-align:center">
                                                                                    <span class=" glyphicon glyphicon-search"></span></a>
                                                                                </div>--%>
                                                                        </div>
                                                                       <div id="divgroupe" class="row push_right " style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Groupe 
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                        <%--           <select runat="server" id="Ddlgroupe" class="form-control" style="width:100%;height:85%" >
                                                <option></option>
                                            </select>--%>
                                                                                <input type="text" class="form-control" id="Tbgroupe" runat="server"  readonly style="width:76%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                                <input type="text" class="form-control" id="Tbgroupe1" onchange="con007($(this),'T')" runat="server" style="width:76%;height:85%;display:none"/>
                                                                            </div>
                                                                            <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left:-17%">
                                                                                <a class="btn btn-sm btn-primary" title="Rechercher" id="SearchGroupe" runat="server" style="height:24px; background-color:#c3c3c3; color:#1f1c33; border:none; padding-top:2.5px; padding-bottom:0px;">
                                                                                    <span class=" glyphicon glyphicon-search"></span></a>
                                                                                </div>
                                                                        </div>
                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Chiffre d'affaire :
                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="Ca" class="form-control cergiDecimalMoney" nbDecimal="0" onchange="con007($(this),'T')" runat="server" style="width:76%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                            <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left:-17%;margin-bottom:-50%">
                                                                               <asp:Label ID="DeviseLabel" runat="server" Text=""> </asp:Label>
                                                                                </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0 0 0 4px;">
                                                                 <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);">
                                                                        <div class="EnteteInfo" style="text-align:center"><label for="">Activités</label></div>
                                                                       
                                                                        
                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Branche  d'activité
                                                                                <%--<label style="color: red">*</label>--%>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                 <asp:DropDownList ID="DdlBranchActiv" AutoPostBack="true"  onchange="combo007($(this),'C')" CssClass="form-control" runat="server" Width="100%" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="DdlBranchActiv_SelectedIndexChanged">
                                         </asp:DropDownList>
                                           <%--                                      <select runat="server" id="DdlBranchActive1" class="form-control" style="width:100%;height:85%" >
                                                <option></option>
                                            </select>--%>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Secteur d'activité

                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                           <div class="col-lg-7 col-sm-7 col-md-7">
                                                                            <%--     <select runat="server" id="" class="form-control" style="width:100%;height:85%"  >
                                                <option></option>
                                            </select>--%>
                                                                                <asp:DropDownList ID="DdlSecteurActive1" AutoPostBack="true" onchange="combo007($(this),'C')"  CssClass="form-control" runat="server" Width="100%" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="DdlSecteurActive1_OnSelectedIndexChanged">
                                         </asp:DropDownList>
                                                                                
                                                                        </div>
                                                                            </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Activité principal de l'entreprise 
                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" class="form-control" runat="server" readonly id="TbActivite" style="width:76%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                               <input type="text" class="form-control" onchange="con007($(this),'T')" id="TbActivite1" runat="server" style="width:76%;height:85%;display:none"/>
                                                                            </div>
                                                                            <div class="col-lg-1 col-sm-1 col-md-1" style="margin-left:-17%">
                                                                                <a class="btn btn-sm btn-primary" title="Rechercher" id="SearchActivite" runat="server" style="height:24px; background-color:#c3c3c3; color:#1f1c33; border:none; padding-top:2.5px; padding-bottom:0px;">
                                                                                    <span class=" glyphicon glyphicon-search"></span></a>
                                                                                </div>
                                                                        </div>

                                                                         <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Statut juridique
                                                                                <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                  <select runat="server" id="DdlStatut" class="form-control" onchange="combo007($(this),'C')"  style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"  >
                                                <option></option>
                                            </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%">
                                                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);" >
                                                                        <div class="EnteteInfo" style="text-align:center"><label for="">Saisies et Analyses</label></div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Devise
                                                                                 <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                         
                                                                                 <asp:DropDownList ID="DeviseD" AutoPostBack="true" onchange="combo007($(this),'C')"   CssClass="form-control" runat="server" Width="100%" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="DeviseD_SelectedIndexChanged">
                                         </asp:DropDownList>
                                                                                <%--<input type="date" id="Mois" class="form-control" runat="server" />--%>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row push_right" hidden style="margin-left: 6%;">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Unité
                                                                                 <label style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                         
                                                                                <select runat="server" id="DblUntie" class="form-control" onchange="combo007($(this),'C')"  style="width:100%;height:24px;padding-top:0px;padding-bottom:0px;"  >
                                                <option value="MILLIERS">Milliers</option>
                                                <option value="MILLIONS">Millions</option>
                                            </select>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                                                Entreprise en création 
                                                                                <label id="EtoilEntr" style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                                                <input type="radio"  id="R_non" class="entreprise" onchange="con007($(this),'T')" runat="server" /> NON
                                                                            </div>
                                                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                                                <input type="radio"  id="R_oui" class="entreprise1" onchange="con007($(this),'T')" runat="server" /> OUI
                                                                            </div>

                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                                                Groupe 
                                                                                <label id="EtoilGroupe" style="color: red">*</label>
                                                                            </div>
                                                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                                                <input type="radio"  id="G_non" class="groupe" runat="server" onchange="con007($(this),'T')"/> NON
                                                                            </div>
                                                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                                                <input type="radio"  id="G_oui" class="groupe1"  runat="server" onchange="con007($(this),'T')"/> OUI
                                                                            </div>

                                                                        </div>
                                                                        
                                                                        <div class="row push_right" style="margin-left: 6%;">
                                                                            <div class="col-lg-5 col-sm-5 col-md-5">
                                                                               
                                                                            </div>

                                                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                                                <button  type="button" id="AjouterFiliale" style="height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover hide">Ajouter Filiale</button>                            
                                                                                <button  type="button" id="ModifierrFiliale" style="height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" class="btn btn_cergicolor btn_hover hide">Voir ou Modifier Filiale(s)</button>                            
                                                                                </div>

                                                                        </div>

                                                                        <div class="row push_right" style="margin-left: 6%;" hidden="hidden">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                                                Type analyse ANFI
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                 <select runat="server" id="TypeAnalyse" class="form-control" onchange="combo007($(this),'C')"  style="Width:99%;height:24px;padding-top:0px;padding-bottom:0px;" >
                                                                                    <%-- <option value=""></option>--%>
                                                                                   <option value="Systeme Normal">Systeme Normal</option>
                                                                                   <option value="Systeme Allege">Systeme Allege</option>
                                                                                   <option value="Systeme Minimal De Tresorerie">Systeme Minimal De Tresorerie</option>
                                                                               </select>
                                                                                </div>

                                                                            </div>
                                                                        <div class="row push_right" style="margin-left: 6%;" hidden="hidden">
                                                                            <div class="col-lg-4 col-sm-4 col-md-4" ">
                                                                                Note Groupe 
                                                                            </div>
                                                                            <div class="col-lg-7 col-sm-7 col-md-7">
                                                                                <input type="text" id="N_groupe" class="form-control" onchange="con007($(this),'T')" maxlength="2" runat="server" style="width:30%;height:24px;padding-top:0px;padding-bottom:0px;"/>
                                                                            </div>
                                                                        </div>
                                                                </div>
                                                                    <div class="row div_form text-right" style="border:none; margin-top:-2px; ">
                                                                (
                                                                <label style="color: red">*</label>) Champs obligatoires
                                                            </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                            <%-- <div class="row push_entete">
                                              <div class="col-lg-1 col-sm-1 col-md-1 col-lg-offset-5 col-sm-offset-5 col-md-offset-5" style="margin-top: 0.5%">
                                                  <asp:Button ID="Button1" runat="server" CssClass="btn btn_cergicolor btn_hover"  Text="Envoyer" />
                                                </div>
                                            </div>--%>
                                              </div>

                                          
                                    <%--</div>--%>

                                    <div class="row push_entete">
                                        <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-2 col-sm-offset-2 col-md-offset-2" id="getMessage" runat="server"></div>
                                    </div>
                               <%-- </div>--%>
                            <%--</div>--%>
                        <%--</div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

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

        <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#PasvalideConsult">
            Launch demo modal
        </button>

        <div id="MSearchMatricule" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche du matricule</strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir le nom de la contrepartie recherché</i><br />
                                <asp:TextBox runat="server" ID="TbSearchMatricule" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner la contrepartie</i><br />
                                <asp:ListBox ID="ListMatricule" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
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

      

          <%--data-backdrop="static"--%>
        <div id="MSearchActivite" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" >
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche de secteur d’activité </strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir code activité économique</i><br />
                                <asp:TextBox runat="server" ID="TbSearchActivite" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner code activité économique</i><br />
                                <asp:ListBox ID="ListActivite" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <%--data-backdrop="static"--%>
    <div id="MAjouterFiiale" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" >
                    <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                        &times;</button>
                    <strong>Ajoute de(s) filiale(s) </strong>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-11 col-sm-11 col-md-11" >
                            <div class="col-lg-7 col-sm-7 col-md-7" style="text-align: left">
                            <i>Saisir identifiant ou nom de la filiale</i><br />
                            <asp:TextBox runat="server" ID="ImpFiliale" Height="28" 
                                         CssClass="form-control" Width="205"></asp:TextBox><br />
                                <asp:TextBox runat="server" ID="Idscor" Height="28" 
                                             CssClass="form-control hide" Width="205"></asp:TextBox><br />
                        </div>
                            <div class="col-lg-5 col-sm-5 col-md-5" style="text-align: right">
                                <a href="javascript:;" class="btn btn-primary" id="ValFiliale" style="margin-left:50%;"><i class=""> Valider</i></a>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-11 col-sm-11 col-md-11" style="text-align: left">
                            <div class="col-lg-5 col-sm-5 col-md-5">
                                <i>Sélectionner la filiale</i><br />
                                <asp:ListBox ID="ListeFiliale1" runat="server" SelectionMode="Single" Rows="10"
                                             CssClass="List_Width form-control textStyle"></asp:ListBox>
                                </div>
                            <div class="col-lg-2 col-sm-2 col-md-2" >
                                <a href="javascript:;" class="btn btn-primary" id="chaineright" runat="server" style="margin-top: 90% ;margin-left:50%;" ><i class="glyphicon glyphicon-chevron-right"></i></a><br /><br />
                                <a href="javascript:;" class="btn btn-primary" id="chaineleft" runat="server" style="margin-left:50%;"><i class="glyphicon glyphicon-chevron-left"></i></a>
                            </div>

                            <div class="col-lg-5 col-sm-5 col-md-5">
                                <i>Filiales Sélectionner</i><br />
                                <asp:ListBox ID="ListeFiliale2" runat="server" SelectionMode="Single" Rows="10"
                                             CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                            
                        </div>
                    </div>
                    <div class="row hide" id="Deja" >
                        <div class="col-lg-11 col-sm-11 col-md-11" style="text-align: left">
                           <label> Déjà Ajouuter</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

               <%--data-backdrop="static"--%>
        <div id="MSearchPays" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche de Pays </strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir le pays recherché</i><br />
                                <asp:TextBox runat="server" ID="TbSearchPays" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner le pays</i><br />
                                <asp:ListBox ID="ListPays" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


         <div id="MSearchGroupe" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche du groupe</strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir le groupe recherché</i><br />
                                <asp:TextBox runat="server" ID="TbSearchGroupe" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner le groupe</i><br />
                                <asp:ListBox ID="ListGroupe" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

              <div id="MSearchModele" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close closeX" data-dismiss="modal"
                            style="color: white;">
                            &times;</button>
                        <strong>Recherche du groupe</strong>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Saisir le groupe recherché</i><br />
                                <asp:TextBox runat="server" ID="TbSearchModele" Height="28" 
                                    CssClass="form-control" Width="205"></asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-10 col-sm-10 col-md-10" style="text-align: left">
                                <i>Sélectionner le groupe</i><br />
                                <asp:ListBox ID="ListModele" runat="server" SelectionMode="Single" Rows="10"
                                    CssClass="List_Width form-control textStyle"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Scriptos" runat="server">

    </div>
    </div>

    <script>
        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }
        //$(document).ready(function () {
        //   // $('.numeric').numeric(this, 0);
        //    $('.number').number(this,0,3);
        //});


        //Recherche de groupe'

        $(document).ready(function () {
            $("#<%=SearchGroupe.ClientID%>").on("click", function (e) {
                $('#MSearchGroupe').modal('show');
            });

            $("#<%=ListGroupe.ClientID%>").on("click", "option", function (e) {
                var value = "";
                var listBox = document.getElementById("<%=ListGroupe.ClientID%>");
                for (var i = 0; i < listBox.options.length; i++) {
                    if (listBox.options[i].selected) {
                        value = value + listBox.options[i].innerHTML;
                    }
                }

                if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                    $("#<%=Tbgroupe.ClientID%>").val(value);
                    $("#<%=Tbgroupe1.ClientID%>").val($("#<%=ListGroupe.ClientID%>").val());
                }
                else {
                    $("#<%=Tbgroupe.ClientID%>").val();
                }
                $("#MSearchGroupe").modal('hide');
                return false;
            });

            $("#<%=TbSearchGroupe.ClientID%>").on('input', function (e) {
                $("#<%=ListGroupe.ClientID%>").empty();
                if ($.trim($("#<%=TbSearchGroupe.ClientID%>").val()) != "") {
                    var text = $("#<%=TbSearchGroupe.ClientID%>").val();
                    $.ajax({
                        type: "POST",
                        url: "Contrepartie.aspx/searchGroupe",
                        data: "{'text': '" + text + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function () { },
                        success: function (response) {
                            $("#<%=ListGroupe.ClientID%>").append(response.d[0]);
                         },
                         failure: function (response) {
                             alert(response.d);
                         }
                     });
                     }
            });
        });

             $("#<%=ValideContrepartie.ClientID%>").on("click", function (e) {
            $("#<%=TbSearchGroupe.ClientID%>").val('');
            $("#<%=TbSearchActivite.ClientID%>").val('');
        });


        //Recherche secteur d'activité'

        $(document).ready(function () {
            $("#<%=SearchActivite.ClientID%>").on("click", function (e) {
                $('#MSearchActivite').modal('show');
            });

            $("#<%=ListActivite.ClientID%>").on("click", "option", function (e) {
                var value = "";
                var listBox = document.getElementById("<%=ListActivite.ClientID%>");
                for (var i = 0; i < listBox.options.length; i++) {
                    if (listBox.options[i].selected) {
                        value = value + listBox.options[i].innerHTML;
                    }
                }

                if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                    $("#<%=TbActivite.ClientID%>").val(value);
                    $("#<%=TbActivite1.ClientID%>").val($("#<%=ListActivite.ClientID%>").val());
                  
                    

                }
                else {
                    $("#<%=TbActivite.ClientID%>").val();
                }
                $("#MSearchActivite").modal('hide');
                return false;
            });

            $("#<%=TbSearchActivite.ClientID%>").on('input', function (e) {
                $("#<%=TbSearchActivite.ClientID%>").attr('disabled', 'disabled');
                $("#<%=ListActivite.ClientID%>").empty();
                $("#<%=TbSearchActivite.ClientID%>").removeAttr('disabled');
                $("#<%=TbSearchActivite.ClientID%>").focus();

                if ($.trim($("#<%=TbSearchActivite.ClientID%>").val()) != "") {
                    var text = $("#<%=TbSearchActivite.ClientID%>").val();
                    $.ajax({
                        type: "POST",
                        url: "Contrepartie.aspx/ActiviteBCAO",
                        data: "{'text': '" + text + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function () { },
                        success: function (response) {
                            $("#<%=ListActivite.ClientID%>").append(response.d[0]);
                             $("#<%=TbSearchActivite.ClientID%>").focus();
                         },
                         failure: function (response) {
                             alert(response.d);
                             $("#<%=TbSearchActivite.ClientID%>").focus();
                        }
                     });
                }
            });
        });


        //Recherche secteur d'activité'

        $(document).ready(function () {
            $("#<%=SearchPays.ClientID%>").on("click", function (e) {
                $('#MSearchPays').modal('show');
            });

            $("#<%=ListPays.ClientID%>").on("click", "option", function (e) {
                var value = "";
                var listBox = document.getElementById("<%=ListPays.ClientID%>");
                for (var i = 0; i < listBox.options.length; i++) {
                    if (listBox.options[i].selected) {
                        value = value + listBox.options[i].innerHTML;
                    }
                }

                if (value != 'Aucune donnée ne correspond aux termes de recherche spécifiés') {
                    $("#<%=TbPays.ClientID%>").val(value);
                    $("#<%=TbPays1.ClientID%>").val($("#<%=ListPays.ClientID%>").val());

                }
                else {
                    $("#<%=TbPays.ClientID%>").val();
                }
                $("#MSearchPays").modal('hide');
                return false;
            });

            $("#<%=TbSearchPays.ClientID%>").on('input', function (e) {
                $("#<%=ListPays.ClientID%>").empty();
                if ($.trim($("#<%=TbSearchPays.ClientID%>").val()) != "") {
                    var text = $("#<%=TbSearchPays.ClientID%>").val();
                    $.ajax({
                        type: "POST",
                        url: "Contrepartie.aspx/ListPaysReach",
                        data: "{'text': '" + text + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        beforeSend: function () { },
                        success: function (response) {
                            $("#<%=ListPays.ClientID%>").append(response.d[0]);
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                    }
            });
        });
        <%--function Formate_Milier(nStr) {
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
        function Formate_Milier1(obj) {
            
            var toot = obj.val();
            $("#<%=Ca.ClientID%>").val(Formate_Milier(toot));
           // alert(toot);
        }--%>
        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });

        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);
        }

        $(".groupe1").click(function () {
           
            $(".entreprise1").prop("disabled", true);
            $(".entreprise").prop("disabled", true);
            $("#divgroupe").addClass("hide");
            $("#AjouterFiliale").removeClass("hide");
           
        });

        $(".groupe").click(function () {

            $(".entreprise1").prop("disabled", false);
            $(".entreprise").prop("disabled", false);
            $("#divgroupe").removeClass("hide");
            $("#AjouterFiliale").addClass("hide");
            $("#ModifierrFiliale").addClass("hide");
            $("#<%=ListeFiliale1.ClientID%>").empty();
            $("#<%=ListeFiliale2.ClientID%>").empty();
            $("#<%=Idscor.ClientID%>").val('');
            $("#<%=ImpFiliale.ClientID%>").val('');
           
           
        });

        $(".entreprise1").click(function () {
            $(".groupe1").prop("disabled", true);
            $(".groupe").prop("disabled", true);
            $("#divgroupe").removeClass("hide");
            $("#AjouterFiliale").addClass("hide");

        });

        $(".entreprise").click(function () {
            $(".groupe1").prop("disabled", false);
            $(".groupe").prop("disabled", false);
            $("#divgroupe").removeClass("hide");
            $("#AjouterFiliale").addClass("hide");

        });

        $("#AjouterFiliale").on("click", function (e) {
            $('#MAjouterFiiale').modal('show');
        });
        $("#ModifierrFiliale").on("click", function (e) {
            $('#MAjouterFiiale').modal('show');
        });
        
        $(document).ready(function() {

            if ($("#<%=DdlSecteurActive1.ClientID%>").val() === '1027') {

                $(".entreprise1").prop("checked", false);
                $(".entreprise").prop("checked", false);
                $(".groupe1").prop("checked", false);
                $(".groupe").prop("checked", false);


                $(".entreprise1").prop("disabled", false);
                $(".entreprise").prop("disabled", false);
                $(".groupe1").prop("disabled", false);
                $(".groupe").prop("disabled", false);

            
        }
        });
        $("#<%=chaineleft.ClientID%>").click(function () {
            $("#<%=ListeFiliale2.ClientID%> option:selected").remove();
        });

        $("#<%=chaineright.ClientID%>").click(function () {
               
                var liste1Value = $("#<%=ListeFiliale1.ClientID%>").find("option:selected").text();
                if (liste1Value === "") {
                    alert("Veuillez sélèctionner  un utilisateur");
                    $("#Deja").addClass("hide");
                }

                if (existeVal() === true) {
                    //$("#Deja").removeClass("hide");
                } else {
                    //$("#Deja").addClass("hide");
                    
                $("#<%=ListeFiliale2.ClientID%>").append("<option value=\"" + liste1Value.split("-")[0] + "\">" + liste1Value + "</option>");
            }
           


        });

        $(document).ready(function () {
        $("#<%=ImpFiliale.ClientID%>").on('input', function (e) {
            $("#<%=ImpFiliale.ClientID%>").attr('disabled', 'disabled');
            $("#<%=ListeFiliale1.ClientID%>").empty();
            $("#<%=ImpFiliale.ClientID%>").removeAttr('disabled');
            $("#<%=ImpFiliale.ClientID%>").focus();

            if ($.trim($("#<%=ImpFiliale.ClientID%>").val()) != "") {
                var text = $("#<%=ImpFiliale.ClientID%>").val();
                $.ajax({
                    type: "POST",
                    url: "Contrepartie.aspx/AjouterFiliale",
                    data: "{'text': '" + text + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () { },
                    success: function (response) {
                        $("#<%=ListeFiliale1.ClientID%>").append(response.d[0]);
                        $("#<%=ImpFiliale.ClientID%>").focus();
                    },
                    failure: function (response) {
                        alert(response.d);
                        $("#<%=ImpFiliale.ClientID%>").focus();
                    }
                });
            }
        });
        });

        $("#ValFiliale").on("click", function (e) {

            var tab = [];
            var index = $("#<%=ListeFiliale2.ClientID%> option").size();

            if (index > 0) {
                $("#<%=ListeFiliale2.ClientID%> option").each(function(i) {
                    tab.push($(this).val());
                });

                var chaine = '';
                if (tab.length > 0) {
                    for (var k = 0; k < tab.length; k++) {
                        if (chaine === '') {

                            chaine = tab[k].trim();
                            
                        } else {
                            chaine = chaine + ';' + tab[k].trim();
                            
                        }
                    }
                    $("#<%=Idscor.ClientID%>").val(chaine);

                }

               

                $('#MAjouterFiiale').modal('hide');
                //$("#Deja").addClass("hide");
                $("#AjouterFiliale").addClass("hide");
                $("#ModifierrFiliale").removeClass("hide");
            } else {
                //$("#Deja").removeClass("hide");
            }


        });
        //ValFiliale ModifierrFiliale
        //Idscor
        function existeVal() {

            var liste2Value = $("#<%=ListeFiliale1.ClientID%>").val();
            var tab = [];
            var index = $("#<%=ListeFiliale2.ClientID%> option").size();
           
            var existe = false;
            if (index > 0) {
                $("#<%=ListeFiliale2.ClientID%> option").each(function (i) {
                    tab.push($(this).val());
                });

                if (tab.length > 0) {
                    for (var k = 0; k < tab.length; k++) {
                        var tabl = tab[k];
                        if (liste2Value.trim() === tabl.trim()) {
                         
                            existe = true;
                        }
                    }
                }
            }


           
            return existe;
            

        }

    </script>

</asp:Content>