<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="Parametre.aspx.cs" Inherits="ScoringCenter.Scoring.Parametre" %>

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
                <li class="pureCssMenui" id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
                <li class="pureCssMenui" id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
                <li class="pureCssMenui "  id="TB" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui pull-right" style = "" id="DOC" runat="server">
                    <a style="/*font-family: cursive;*/" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
	                <ul class="" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GUT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#"  data-toggle="modal" data-target="#helpmodal">Aide</a></li>
		                <li class="pureCssMenui"  id="MNT" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="#">Modèle de notation</a></li>
	                </ul>
                </li>
                <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                   <a style="/*font-family: cursive;*/ background-color: #022D65;" class="pureCssMenui" href="#">
                       <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                       <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
	                <ul class="" style="z-index: 10;">
		                <li class="pureCssMenui"  id="GP" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
		                <li class="pureCssMenui"  id="GU" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>
		                <li class="pureCssMenui"  id="GPA" runat="server"><a style="/*font-family: cursive;*/ background-color: #022D65; color: #FFFFFF;" class="pureCssMenui" href="Parametre.aspx">Gestion des Paramètres</a></li>
                         <%--<%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>--%>--%>
                        <%--<%--<li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>--%>--%>
                        <li class="pureCssMenui" id="Pay" runat="server"><a class="pureCssMenui" href="ParametrePays.aspx">Paramêtres Pays</a></li>
                    </ul>
                </li>
            </ul>
        </div>

        <div class="br_top">
            <div id="Content" class="Content br_top">
                <br class="br_top" />
                <div id="thebody" class="noBackground">
                    <div id="bodyTitle">
                        <h3>Gestion des parametres</h3>
                    </div>
                    <div class="row inthebody">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%; text-align:left;">
                        <div class="col-lg-12 col-sm-12 col-md-12" style="padding:0;">
                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding:0;">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align:center"><label for="">Gestion des alertes</label></div>
                                       
                                         <div class="col-lg-12 col-sm-12 col-md-12">
                                            <div class="row" style="margin-bottom: 2%; text-align: left;">
                                                <div class="col-lg-6 col-sm-6 col-md-6" style="text-align: left;">
                                                    <span>( <label style="color: red;">*</label>) Champs Obligatoires</span>
                                                </div>
                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                    <div style="display: inline; text-align: left; margin-left: 80%;">
                                                            
                                                        <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Valider" 
                                                            runat="server" id="btnValider" onserverclick="btnValider_ServerClick">
                                                            <span class=" glyphicon glyphicon-ok"></span></button>--%>
                                                        <button 
                                                            class="btn btn-sm btn-primary button_div pull-right" 
                                                            style="margin-right:5px;color:#0a8f3a; background-color:#c3c3c3; height:24px; border:none; padding-top:0px; padding-bottom:0px;" 
                                                            title="Valider" 
                                                            runat="server" 
                                                            id="btnValider" onserverclick="btnValider_ServerClick">
                                                            <span class=" glyphicon glyphicon-ok"></span>
                                                            </button>
                                                         <asp:TextBox ID="TbIdProfil" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>

                                                            <input id="checked_doc_completsM" type="hidden" class="validate checked_vNumordsM" runat="server"/>
                                                            <input id="checked_doc_completsV" type="hidden" class="validate checked_vNumordsV" runat="server"/>

                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </div>

                                         <div class="row push_entete">
                                            <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" style="text-align: right;">
                                                Nombres du jours<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-2 col-sm-2 col-md-2">
                                                <input type="text" class="form-control Compte_Caisse" runat="server" id="nombre" aria-describedby="telbur" style="height:32%;"/>
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
                                       
                                    </div>
                                </div>

                            </div>

                                
                                    <%--<div class="row div_form">
                                        <div class="EnteteInfo" style="text-align:center"><label for="">Gestion ...</label></div>
                                       
                                         <div class="col-lg-12 col-sm-12 col-md-12">
                                            <div class="row" style="margin-bottom: 2%; text-align: left;">
                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                    <div style="display: inline; text-align: left; margin-right: 80%;">
                                                            
                                                        <button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Valider" 
                                                            runat="server" id="Button2" onserverclick="btnValider_ServerClick">
                                                            <span class=" glyphicon glyphicon-ok"></span></button>
                                                         <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>


                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-sm-6 col-md-6" style="text-align: right">
                                                    <span>( <label style="color: red;">*</label>) Champs Obligatoires</span>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-lg-12 col-sm-12 col-md-12">
                                            <div class="row" style="margin-bottom: 2%; text-align: left;">
                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                        <div class="panel panel-default"style="width:100%;">

                                                        <div style="margin-left:2%">
                                                            <label  class="Label_s" style="border:none;font-size:small;color:blue">Pondération
                                                              </label>
                                                         </div>

                                                          <div class="row" style="margin-left:2%;margin-right:2%">
                            
                                                                <div class="col-lg-6 col-sm-6 col-md-6" style="padding-top:4%">
                                                                    <label class="control-label" for="TextLibelleSpecifique" id="Label1" runat="server" >Financière( <label style="color: red;">A</label>)</label>
                                                                </div>
                                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                                    <input  style="height:30PX;margin-bottom:10%" type="text" class="form-control" id="Text1" runat="server"  />
                                                                </div>

                                                          </div>

                                                             <div class="row" style="margin-left:2%;margin-right:2%">
                            
                                                                <div class="col-lg-6 col-sm-6 col-md-6" style="padding-top:4%">
                                                                    <label class="control-label" for="TextLibelleSpecifique" id="Label2" runat="server">Qualitative( <label style="color: red;">B</label>)</label>
                                                                </div>
                                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                                    <input  style="height:30PX;margin-bottom:10%" type="text" class="form-control" id="Text2" runat="server"  />
                                                                </div>

                                                          </div>

                                                        </div>
                                                </div>
                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                    <div class="panel panel-default"style="width:100%;">

                                                        <div style="margin-left:2%">
                                                            <label  class="Label_s" style="border:none;font-size:small;color:blue"> Formule</label>
                                                         </div>

                                                          <div class="row" style="margin-left:2%;margin-right:2%;margin-top:5%">
                            
                                                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom:5%">
                                                                    <input  style="height:30PX;" type="text" class="form-control" id="lbl_soldeDispo" runat="server"  />
                                                                </div>
                                                              <div class="row" style="margin-left:2%;margin-right:2%;margin-bottom:2%">
                                                                  <label style="color:black; margin-left:4%">
                                                                      Rapel:
                                                                  </label>
                                                              <label style="color: red">(</label> A +B/B <label style="color: red">)</label>
                                                                  </div>

                                                          </div>

                                                        </div>
                                                </div>
                                            </div>
                                        </div>




<%--                                        <div class="col-lg-12 col-sm-12 col-md-12">
                                        <div class="col-lg-6 col-sm-6 col-md-6">
                                          <div class="row">
                                            <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-1 col-sm-offset-1 col-md-offset-1"">
                                                Pondération financière<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                <input type="text" class="form-control Compte_Caisse" runat="server" id="Text3" aria-describedby="telbur" style="height:32%;"/>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-8 col-sm-8 col-md-8 col-lg-offset-1 col-sm-offset-1 col-md-offset-1" >
                                                Pondération qualitative<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-4 col-sm-4 col-md-4">
                                                <input type="color" class="form-control Compte_Caisse" runat="server" id="Color1" aria-describedby="telbur" />
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-lg-6 col-sm-6 col-md-6">
                                            </div>

                                            </div>--%>

                                      <%--   <div class="col-lg-12 col-sm-12 col-md-12">
                                            <div class="col-lg-4 col-sm-4 col-md4">
                                                Pondération financière<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-3 col-sm-3 col-md-3">
                                                <input type="text" class="form-control" runat="server" id="Text1" style="height:30%;width:70%"/>
                                            </div>

                                           <div class="col-lg-3 col-sm-3 col-md3">
                                                Pondération qualitative<label style="color: red">*</label>
                                            </div>
                                            <div class="col-lg-3 col-sm-3 col-md3">
                                                <input type="text" class="form-control " runat="server" id="Text2"  style="height:30%;width:70%"/>
                                            </div>
                                        </div>--%>
                                       
                                    
                    
                            <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0 0 0 4px;">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                    <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34);">
                                        <div class="EnteteInfo" style="text-align:center"><label for="">Gestion des habilitations</label></div>
                                       
                                         <div class="col-lg-12 col-sm-12 col-md-12">
                                            <div class="row" style="margin-bottom: 2%; text-align: left;">
                                                <div class="col-lg-6 col-sm-6 col-md-6" style="text-align: left">
                                                    <span>( <label style="color: red;">*</label>) Champs Obligatoires</span>
                                                </div>
                                                <div class="col-lg-6 col-sm-6 col-md-6">
                                                    <div style="display: inline; text-align: left; margin-left: 80%;">
                                                        <%--<button class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Nouveau" 
                                                            runat="server" id="Button1" >
                                                            <span class=" glyphicon glyphicon-edit"></span></button>--%>
                                                        <div 
                                                            class="btn btn-sm btn-primary button_div pull-right" 
                                                            style="margin-right:5px;color:#0a8f3a; background-color:#c3c3c3 !important; height:24px; border:none; padding-top:2.5px; padding-bottom:0px;" 
                                                            title="Valider" 
                                                            data-toggle="tooltip" 
                                                            id="BtnValiderHabil">
                                                            <span class=" glyphicon glyphicon-ok"></span>
                                                            </div>
                                                        <%--<div class="btn btn-sm btn-primary button_div" data-toggle="tooltip" title="Valider" 
                                                            id="BtnValiderHabil">
                                                            <span class=" glyphicon glyphicon-ok"></span></div>--%>
                                                       <%-- <a  href="javascript:;" class="btn btn-sm btn-primary button_div" 
                                                           id="Btnvalide">
                                                            <span class=" glyphicon glyphicon-ok"></span> </a>--%>
                                                         <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control Ddlsize display" Width="40"></asp:TextBox>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </div>

                                         <div class="col-lg-12 col-sm-12 col-md-12">
                                                <div class="row push_entete">
                                                    <div class="col-lg-3 col-sm-3 col-md-3"
                                                        style="text-align: right;">
                                                        Profil <label style="color: red">*</label>
                                                    </div>
                                                    <div class="col-lg-7 col-sm-7 col-md-7">
                                                          <asp:DropDownList ID="DblProfil" CssClass="form-control" AutoPostBack="true" runat="server" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="DblProfil_SelectedIndexChanged">
                                                       </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control Ddlsize display " Width="40"></asp:TextBox>
                                                        <%--<select id="DdlProfil" class="form-control"
                                                            runat="server" style="Height:28px;" AutoPostBack="true"   onserverchange ="DdlProfil_ServerChange">
                                                        </select>--%>
                                                    </div>
                                                </div>
                                             </div>

                                         <div class="col-lg-12 col-sm-12 col-md-12">

                                              <table id="datatable_bord" class="table table-bordered table-hover scor_table1">
                                                  <thead class='table-heigth1'>
                                                      <tr>
                                                          <th class="text-center" style="display:none">Code</th>
                                                          <th class="text-center">Ecrans</th>
                                                            <th class="text-center" style="width:10%;">M</th>
                                                            <th class="text-center" style="width:10%;">V</th>
                                                      </tr>
                                                            
                                                    </thead>
                                                    <tbody runat="server" id="ListDroit" style="background-color:white;">
                                                        <tr>
                                                           <%-- <td style="padding-left:2%">Connexion</td>
                                                            <td class="text-center"><input type="checkbox" class="" runat="server"/></td>
                                                            <td class="text-center"><input type="checkbox" checked='checked' class="" runat="server"/></td>--%>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                             </div>

                                        <div class="col-lg-12 col-sm-12 col-md-12">
                                              <div class="col-lg-9 col-sm-9 col-md-9"
                                             <span>( <label style="color: red;">M</label>) Valider, Modifier,Supprimer</span>
                                            </div>

                                           <div class="col-lg-3 col-sm-3 col-md-3"
                                             <span>( <label style="color: red;">V</label>) Visualiser</span>
                                            </div>
                                        </div>
                                       
                                    </div>
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

        
      <%--Modal de confirmer d'édiction--%>
    <div id="ModalEditionDocs" class="choixdoc modal fade margin-intelligent row ModalEditionDocs" role="dialog" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                            <strong>Validation des Droits</strong>
                        </div>

                         <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                        <div class="alert alert-info row" role="alert" style="margin: 2%">
                            <p id="gfd" style="color: black; font-weight: bolder">
                               <span style="color:black; font-weight:bolder; font-size: 13px;" id="LbEditDoc">Voulez-vous modifier les droits ?</span>
                            </p>
                        </div>
                    </div>

                        <div class="modal-footer">
                               <asp:Button ID="Button1" CssClass="btn btn-sm btn-primary button_div" OnCommand="editSelectionM" runat="server" Text="Oui" CommandArgument="0" /> 
                            <asp:Button ID="Btnnon" CssClass="btn btn-sm btn-primary button_div" Text="Non" runat="server"/> 
                            
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
            $("#BtnValiderHabil").click(function () {
                get_docs();
                //alert('ok');

            });
        });

        $(document).ready(function () {
            $("#<%=Btnnon.ClientID%>").click(function () {
                return;
            });
        });



        function get_docs() {

            var checkboxesM = document.getElementsByName('selectM');          
            var checkboxesV = document.getElementsByName('selectV');
            var doc_completsM_Check = "";
            var doc_completsV_Check = "";
            var doc_completsM_NoCheck = "";
            var doc_completsV_NoCheck = "";
            var doc_completsM = "";
            var doc_completsV = "";

                for (var i = 0, n = checkboxesM.length; i < n; i++) {
                    if (checkboxesM[i].checked == true) {
                        var doc_completsM_Check = "@" + checkboxesM[i].getAttribute("codeM") + "#" + "1";
                        doc_completsM += doc_completsM_Check;
                    }else{
                        var doc_completsM_NoCheck = "@" + checkboxesM[i].getAttribute("codeM") + "#" + "0";
                        doc_completsM += doc_completsM_NoCheck;

                    }
                }
                $("#<%=checked_doc_completsM.ClientID%>").val(doc_completsM); 

                for (var i = 0, n = checkboxesV.length; i < n; i++) {
                    if (checkboxesV[i].checked == true) {
                        var doc_completsV_Check = "@" + checkboxesV[i].getAttribute("codeV") + "#" + "2";
                        doc_completsV += doc_completsV_Check;
                    }else{
                        var doc_completsV_NoCheck = "@" + checkboxesV[i].getAttribute("codeV") + "#" + "0";
                        doc_completsV += doc_completsV_NoCheck;
                    }
                }

                $("#<%=checked_doc_completsV.ClientID%>").val(doc_completsV);  
            $('#ModalEditionDocs').modal({ backdrop: 'static', keyboard: false });
         }


        function ShowvalideConsult() {
            $("#ShowvalideConsult").click();
        }

        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $(document).ready(function () {
            var TextBox2 = $("#<%=TextBox2.ClientID%>").val();
            if (TextBox2 === "") {

                $('.clickable').each(function (e) {
                    var M_Cocher = "M_Cocher" + (e + 1);
                    var V_Cocher = "V_Cocher" + (e + 1);
                    $("." + M_Cocher).prop("disabled", true);
                    $("." + V_Cocher).prop("disabled", true);

                });
            } else {
                $('.clickable').each(function (e) {
                    var M_Cocher = "M_Cocher" + (e + 1);
                    var V_Cocher = "V_Cocher" + (e + 1);
                    $("." + M_Cocher).prop("disabled", false);
                    $("." + V_Cocher).prop("disabled", false);

                });
            }
        });

        $("#<%=DblProfil.ClientID%>").change(function () {
            var TextBox2 = $("#<%=TextBox2.ClientID%>").val();
            if (TextBox2 === "") {

                $('.clickable').each(function (e) {
                    var M_Cocher = "M_Cocher" + (e + 1);
                    var V_Cocher = "V_Cocher" + (e + 1);
                    $("." + M_Cocher).prop("disabled", true);
                    $("." + V_Cocher).prop("disabled", true);

                });
            } else {
                $('.clickable').each(function (e) {
                    var M_Cocher = "M_Cocher" + (e + 1);
                    var V_Cocher = "V_Cocher" + (e + 1);
                    $("." + M_Cocher).prop("disabled", false);
                    $("." + V_Cocher).prop("disabled", false);

                });
            }
        });

        $('.clickable').each(function (e) {
            var M_Cocher = "M_Cocher" + (e + 1);
            var V_Cocher = "V_Cocher" + (e + 1);
            $("." + M_Cocher).click(function () {
                if ($("." + M_Cocher).is(':checked')) {
                    $("." + V_Cocher).prop("checked", true);
                }
            });
            $("." + V_Cocher).click(function () {
                if ($("." + V_Cocher).is(':checked') == false) {
                    $("." + M_Cocher).prop("checked", false);
                }
            });



            // autre dossier
            $(".M_Cocher5").click(function () {
                if ($(".M_Cocher5").is(':checked') == false) {
                    $(".M_Cocher6").prop("checked", false);
                    $(".M_Cocher7").prop("checked", false);
                    $(".M_Cocher8").prop("checked", false);
                    $(".M_Cocher9").prop("checked", false);
                    $(".M_Cocher10").prop("checked", false);
                    $(".M_Cocher11").prop("checked", false);
                }

            });
            $(".V_Cocher5").click(function () {
                if ($(".V_Cocher5").is(':checked') == false) {
                    $(".V_Cocher6").prop("checked", false);
                    $(".V_Cocher7").prop("checked", false);
                    $(".V_Cocher8").prop("checked", false);
                    $(".V_Cocher9").prop("checked", false);
                    $(".V_Cocher10").prop("checked", false);
                    $(".V_Cocher11").prop("checked", false);
                    $(".M_Cocher6").prop("checked", false);
                    $(".M_Cocher7").prop("checked", false);
                    $(".M_Cocher8").prop("checked", false);
                    $(".M_Cocher9").prop("checked", false);
                    $(".M_Cocher10").prop("checked", false);
                    $(".M_Cocher11").prop("checked", false);
                }

            });

            // les fils de l'autre dossier

            $(".M_Cocher6").click(function () {
                if ($(".M_Cocher6").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }
                
            });
            $(".V_Cocher6").click(function () {
                if ($(".V_Cocher6").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }

            });

            $(".M_Cocher7").click(function () {
                if ($(".M_Cocher7").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }

            });
            $(".V_Cocher7").click(function () {
                if ($(".V_Cocher7").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }

            });

            $(".M_Cocher8").click(function () {
                if ($(".M_Cocher8").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }

            });
            $(".V_Cocher8").click(function () {
                if ($(".V_Cocher8").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }

            });
            $(".M_Cocher9").click(function () {
                if ($(".M_Cocher9").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }

            });
            $(".V_Cocher9").click(function () {
                if ($(".V_Cocher9").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }
            });
            $(".M_Cocher10").click(function () {
                if ($(".M_Cocher10").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }

            });
            $(".V_Cocher10").click(function () {
                if ($(".V_Cocher10").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }
            });

            $(".M_Cocher11").click(function () {
                if ($(".M_Cocher11").is(':checked')) {
                    $(".M_Cocher5").prop("checked", true);
                    $(".V_Cocher5").prop("checked", true);
                }

            });
            $(".V_Cocher11").click(function () {
                if ($(".V_Cocher11").is(':checked')) {
                    $(".V_Cocher5").prop("checked", true);
                }
                if ($(".V_Cocher6").is(':checked') == false && $(".V_Cocher7").is(':checked') == false && $(".V_Cocher8").is(':checked') == false && $(".V_Cocher9").is(':checked') == false && $(".V_Cocher10").is(':checked') == false && $(".V_Cocher11").is(':checked') == false) {
                    $(".V_Cocher5").prop("checked", false);
                    $(".M_Cocher5").prop("checked", false);
                }
            });

            // habilitation  paramettre
            $(".M_Cocher14").click(function () {
                if ($(".M_Cocher14").is(':checked') == false) {
                    $(".M_Cocher15").prop("checked", false);
                    $(".M_Cocher16").prop("checked", false);
                    $(".M_Cocher17").prop("checked", false);
                    $(".M_Cocher18").prop("checked", false);
                }

            });
            $(".V_Cocher14").click(function () {
                if ($(".V_Cocher14").is(':checked') == false) {
                    $(".V_Cocher15").prop("checked", false);
                    $(".V_Cocher16").prop("checked", false);
                    $(".V_Cocher17").prop("checked", false);
                    $(".V_Cocher18").prop("checked", false);
                    $(".M_Cocher15").prop("checked", false);
                    $(".M_Cocher16").prop("checked", false);
                    $(".M_Cocher17").prop("checked", false);
                    $(".M_Cocher18").prop("checked", false);
                }

            });

            // les fils du paramettre

            $(".M_Cocher15").click(function () {
                if ($(".M_Cocher15").is(':checked')) {
                    $(".M_Cocher14").prop("checked", true);
                    $(".V_Cocher14").prop("checked", true);
                }


            });
            $(".V_Cocher15").click(function () {
                if ($(".V_Cocher15").is(':checked')) {
                    $(".V_Cocher14").prop("checked", true);
                }
                if ($(".V_Cocher15").is(':checked') == false && $(".V_Cocher16").is(':checked') == false && $(".V_Cocher17").is(':checked') == false && $(".V_Cocher18").is(':checked') == false) {
                    $(".V_Cocher14").prop("checked", false);
                    $(".M_Cocher14").prop("checked", false);
                }

            });

            $(".M_Cocher16").click(function () {
                if ($(".M_Cocher16").is(':checked')) {
                    $(".M_Cocher14").prop("checked", true);
                    $(".V_Cocher14").prop("checked", true);
                }

            });
            $(".V_Cocher16").click(function () {
                if ($(".V_Cocher16").is(':checked')) {
                    $(".V_Cocher14").prop("checked", true);
                }
                if ($(".V_Cocher15").is(':checked') == false && $(".V_Cocher16").is(':checked') == false && $(".V_Cocher17").is(':checked') == false && $(".V_Cocher18").is(':checked') == false) {
                    $(".V_Cocher14").prop("checked", false);
                    $(".M_Cocher14").prop("checked", false);
                }
            });

            $(".M_Cocher17").click(function () {
                if ($(".M_Cocher17").is(':checked')) {
                    $(".M_Cocher14").prop("checked", true);
                    $(".V_Cocher14").prop("checked", true);
                }

            });
            $(".V_Cocher17").click(function () {
                if ($(".V_Cocher17").is(':checked')) {
                    $(".V_Cocher14").prop("checked", true);
                }
                if ($(".V_Cocher15").is(':checked') == false && $(".V_Cocher16").is(':checked') == false && $(".V_Cocher17").is(':checked') == false && $(".V_Cocher18").is(':checked') == false) {
                    $(".V_Cocher14").prop("checked", false);
                    $(".M_Cocher14").prop("checked", false);
                }
            });

            $(".M_Cocher18").click(function () {
                if ($(".M_Cocher18").is(':checked')) {
                    $(".M_Cocher14").prop("checked", true);
                    $(".V_Cocher14").prop("checked", true);
                }

            });
            $(".V_Cocher18").click(function () {
                if ($(".V_Cocher18").is(':checked')) {
                    $(".V_Cocher14").prop("checked", true);
                }
                if ($(".V_Cocher15").is(':checked') == false && $(".V_Cocher16").is(':checked') == false && $(".V_Cocher17").is(':checked') == false && $(".V_Cocher18").is(':checked') == false) {
                    $(".V_Cocher14").prop("checked", false);
                    $(".M_Cocher14").prop("checked", false);
                }
            });
           
          
        });
       
    </script>
</asp:Content>