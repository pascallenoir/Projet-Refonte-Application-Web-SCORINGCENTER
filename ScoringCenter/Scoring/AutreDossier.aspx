<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutreDossier.aspx.cs"
    Inherits="ScoringCenter.AutreDossier" %>

<%--CONTENU DU MENU LATERAL --%>
<asp:Content ID="AutreDossierMenu" ContentPlaceHolderID="ContentMenu" runat="server">
   
        <ul class="navbar-nav navbar-nav-lg nav-tabs">
          <%--Tableau de bord--%>
            <li class="nav-item " id="TB" runat="server">
              <a class="js-nav-tooltip-link nav-link " href="TableauBordAutreDossier.aspx" title="Tableau de bord" data-placement="left">
                <i class="tio-home-vs-1-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Tableau de bord</span>
              </a>
            </li>
            <%--Tableau de bord--%>
            <!-- Noter -->
            <li class="nav-item " id="AD" runat="server">
              <a class="js-nav-tooltip-link nav-link active" href="#" title="Noter" data-placement="left">
                <i class="tio-documents-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Noter</span>
              </a>
            </li>
            <!-- Noter -->
            <%--MENU GENERAL--%>
            <!-- Notifications -->
            <li class="nav-item ">
              <a class="js-nav-tooltip-link nav-link " href="#" title="Notifications" data-placement="left">
                <i class="tio-notifications-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Notifications</span>
              </a>
            </li>
            <!-- Notifications -->
            <!-- Reporting -->
            <li class="nav-item ">
              <a class="js-nav-tooltip-link nav-link " href="#" title="Reporting" data-placement="left">
                <i class="tio-report-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Reporting</span>
              </a>
            </li>
            <!-- Reporting -->
            <!-- Documentation -->
            <li class="nav-item ">
              <a class="js-nav-tooltip-link nav-link " href="#" title="Documentation" data-placement="left">
                <i class="tio-book-opened nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Documentation</span>
              </a>
            </li>
            <!-- Documentation -->
            <!-- Créer Prospect -->
            <li class="nav-item " id="Con" runat="server">
              <a class="js-nav-tooltip-link nav-link " href="Contrepartie.aspx" title="Créer Prospect" data-placement="left">
                <i class="tio-add-circle-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Créer Prospect</span>
              </a>
            </li>
            <!-- Créer Prospect -->
            <%-- FIN MENU GENERAL--%>
            <!-- Guide Utilisateur -->
            <li class="navbar-vertical-aside-has-menu " id="DOC" runat="server">
                <a class="js-navbar-vertical-aside-menu-link nav-link nav-link-toggle " href="javascript:;" title="Guide utilisateur">
                  <i class="tio-book-opened nav-icon"></i>
                  <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Guide utilisateur</span>
                </a>
                <ul class="js-navbar-vertical-aside-submenu nav nav-sub">
                     <li class="nav-item" runat="server">
                       <a class="nav-link " href="../index.html" title="Aide">
                         <span class="tio-circle nav-indicator-icon"></span>
                         <span class="text-truncate">Aide</span>
                       </a>
                     </li>
                     <li class="nav-item" runat="server">
                       <a class="nav-link " href="../index.html" title="Modèle de notation">
                         <span class="tio-circle nav-indicator-icon"></span>
                         <span class="text-truncate">Modèle de notation</span>
                       </a>
                     </li>
                </ul>
            </li>
            <!-- Guide Utilisateur -->
            <!-- Parametres -->
            <li class="navbar-vertical-aside-has-menu " id="PARAM" runat="server">
              <a class="js-navbar-vertical-aside-menu-link nav-link nav-link-toggle " href="javascript:;" title="Parametres">
                 <i class="tio-settings-outlined nav-icon"></i>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Parametres</span>
              </a>
              <ul class="js-navbar-vertical-aside-submenu nav nav-sub">
                <li class="nav-item" id="GP" runat="server">
                  <a class="nav-link " href="../index.html" title="Gestion des profils">
                    <span class="tio-circle nav-indicator-icon"></span>
                    <span class="text-truncate">Gestion des profils</span>
                  </a>
                </li>
                <li class="nav-item" id="GU" runat="server">
                  <a class="nav-link " href="../dashboard-alternative.html" title="Gestion des utilisateurs">
                    <span class="tio-circle nav-indicator-icon"></span>
                    <span class="text-truncate">Gestion des utilisateurs</span>
                  </a>
                </li>
                <li class="nav-item" id="GPA" runat="server">
                  <a class="nav-link " href="../dashboard-alternative.html" title="Gestion des paramètres">
                    <span class="tio-circle nav-indicator-icon"></span>
                    <span class="text-truncate">Gestion des paramètres</span>
                  </a>
                </li>
                <li class="nav-item" id="SD" runat="server">
                  <a class="nav-link " href="../dashboard-alternative.html" title="Schémas délégataires">
                    <span class="tio-circle nav-indicator-icon"></span>
                    <span class="text-truncate">Schémas délégataires</span>
                  </a>
                </li>
                <li class="nav-item" id="Pay" runat="server">
                  <a class="nav-link " href="../dashboard-alternative.html" title="Paramètres Pays">
                    <span class="tio-circle nav-indicator-icon"></span>
                    <span class="text-truncate">Paramètres Pays</span>
                  </a>
                </li>
              </ul>
            </li>
            <!-- fin Parametres -->
            <!-- Language -->
            <li class="navbar-vertical-aside-has-menu nav-footer-item ">
              <a class="js-navbar-vertical-aside-menu-link nav-link nav-link-toggle " href="javascript:;" title="Langue">
                <img class="avatar avatar-xss avatar-circle" src="../Content/vendor/flag-icon-css/flags/1x1/gb.svg" alt="Anglais"/>
                <span class="navbar-vertical-aside-mini-mode-hidden-elements text-truncate">Langue</span>
              </a>
            
              <ul class="js-navbar-vertical-aside-submenu nav nav-sub">
                <li class="nav-item">
                  <a class="nav-link" href="#" title="English (US)">
                    <img class="avatar avatar-xss avatar-circle mr-2" src="../Content/vendor/flag-icon-css/flags/1x1/gb.svg" alt="Flag"/>
                    Anglais
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#" title="English (UK)">
                    <img class="avatar avatar-xss avatar-circle mr-2" src="../Content/vendor/flag-icon-css/flags/1x1/fr.svg" alt="Flag"/>
                    Français
                  </a>
                </li>
              </ul>
            </li>
            <!-- End Language -->
        </ul>
 
    <input type="text" value="1" id="TextBoxrec" hidden />
    <input type="text" value="1" id="TextBoxaff" hidden />
    <input type="text" value="1" id="TextBoxDate" hidden />

</asp:Content>
<%--FIN CONTENU DU MENU LATERAL--%>
<%--CONTENU DE LA PAGE --%>
<asp:Content ID="AutreDossierBody" ContentPlaceHolderID="ContentBody" runat="server">

    <input type="text" runat="server" id="connmou007" hidden />
    <!-- Row -->
      <div class="row justify-content-lg-start">
        <div class="col-lg-10">
         
          <!-- Content Step Form -->
          <div>
            <!-- Card -->
            <div class="card card-lg">
                <!-- Body -->
              <div class="card-header">
                <h4 class="card-header-title">Recherche du tiers</h4>
              </div>
              <!-- Body -->
              <!-- Body -->
              <div class="card-body">
                <!-- Form Group -->
                <div class="row form-group">
                       <label for="DdlBanque" class="col-sm-2 col-form-label input-label">Banque <i style="color: red">*</i></label>

                        <div class="row col-sm-10">
                            <!-- Select -->
                            <div class="col-sm-4 mb-2">
                              <asp:DropDownList class="js-select2-custom custom-select"  size="1" style="opacity: 1;" ID="DdlBanque" AutoPostBack="true" onchange="combo007($(this),'C')" runat="server"  
                                   data-hs-select2-options='{"placeholder": "Choisir Banque","searchInputPlaceholder": "Rechercher une Banque"}' OnSelectedIndexChanged="OnBanqueChangeLoadAgences">                          
                               </asp:DropDownList>
                            </div>
                            <div class="col-sm-8 mb-2">
                               <select  class="js-select2-custom custom-select" runat="server" size="1" style="opacity: 1;" ID="DdlAgence" onchange="combo007($(this),'T')" 
                                   data-hs-select2-options='{"placeholder": "Choisir agence","searchInputPlaceholder": "Rechercher une agence"}'>
                               </select>
                            </div>
                             <!-- End Select -->
                        </div>
                </div>
                <!-- End Form Group -->
                <!-- Form Group -->
                <div class="row form-group">
                      <label for="TbIContrepartie" class="col-sm-2 col-form-label input-label">Client</label>

                      <div class="row col-sm-10">
                           <!-- TextBox -->
                           <div class="col-sm-4 mb-2">
                             <asp:TextBox class="form-control" type="text" name="Numero" placeholder="Numero client" aria-label="Numero client" ID="TbIContrepartie" runat="server" MaxLength="30" onchange="con007($(this),'T')"  >
                             </asp:TextBox>
                           </div>
                           <div class="col-sm-8 mb-2">
                             <asp:TextBox class="form-control" type="text" name="Nom" placeholder="Nom client" aria-label="Nom client" Text="%" autocomplete="address-level4" ID="TbNContrepartie" runat="server" MaxLength="30" onchange="con007($(this),'T')" >
                             </asp:TextBox>
                           </div>
                           <!-- End TextBox -->
                      </div>
                </div>
                <!-- End Form Group -->
                <!-- Form Group -->
                <div class="row form-group">
                     <div class="col-sm-2"></div>
                     <label class="col-sm-3 col-form-label input-label">(<i style="color: red">*</i>) Champs Obligatoires</label>
                </div>
                <!-- End Form Group -->
                <div class="row justify-content-lg-start">
                    <div class="col-lg-6 col-sm-6 col-md-6 col-lg-offset-2 col-sm-offset-2 col-md-offset-2"
                        id="getMessage" runat="server">
                    </div>
                </div>
              </div>
              <!-- End Body -->

              <!-- Footer -->
              <div class="card-footer d-flex justify-content-start align-items-center">
                <button type="button" id="Ok" class="btn btn-primary" runat="server" onmousedown="con007($(this),'B')"  onserverclick="Ok_Click1">Rechercher</button>
                 <span id="Spinner" class="spinner-border spinner-border-sm" role="status" runat="server" Style="display: none;"></span>
              </div>
              <!-- End Footer -->

              <!-- Tableau DES tiers -->
              <div class="row">
                    <div class="col-lg-12 col-md-12">
                         <div id="ListDFinanciers" runat="server">
                         </div>
                    </div>
              </div>
              <!-- Fin Tableau DES tiers -->
            </div>
            <!-- End Card -->
             
          <!-- ... fin formulaire ... -->
          </div>
         </div>
         <!-- End Card -->

      </div>
    <!-- End Row -->

    <!-- modal timing -->
    <div id="timing" class="notification modal fade margin-intelligent timing row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vv">
                    <button type="button" class="close closeX" data-dismiss="modal"
                        style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvv" style="float: left; margin-left: 2%">Gestion des alerts</strong>
                </div>
                <div class="modal-body" id="ed" style="margin: 0%; padding: 0 !important">
                    <div class="row push_entete">
                        <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-1 col-sm-offset-1 col-md-offset-1"
                            style="text-align: right;">
                            Nombres du jours<label style="color: red">*</label>
                        </div>
                        <div class="col-lg-2 col-sm-2 col-md-2">
                            <input type="text" class="form-control Compte_Caisse" runat="server" id="nombre"
                                aria-describedby="telbur" />
                        </div>
                    </div>
                    <div class="row push_entete">
                        <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-1 col-sm-offset-1 col-md-offset-1"
                            style="text-align: right;">
                            Couleur<label style="color: red">*</label>
                        </div>
                        <div class="col-lg-2 col-sm-2 col-md-2">
                            <input type="color" value="#FFFFFF" class="form-control Compte_Caisse" runat="server"
                                id="couleur" aria-describedby="telbur" />
                        </div>
                    </div>
                    <div class="row push_entete">
                        <div class="col-lg-4 col-sm-4 col-md-4 col-lg-offset-3 col-sm-offset-3 col-md-offset-3"
                            style="padding-left: 4.8%;">
                            (
                            <label style="color: red">*</label>) Champs Obligatoires
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal"
                        id="ShowvalideOpenConsult" onserverclick="ShowvalideOpenConsult_ServerClick"
                        runat="server">Valider</button>
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal"
                        onclick="return;">Annuler</button>
                </div>
            </div>
            <!-- fin Modal content-->
        </div>
    </div>
    <!-- fin modal timing -->

    <!-- div button demo -->
    <button type="button" style="display: none;" id="ShowPasvalideConsult" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#PasvalideConsult">
        Launch demo modal
    </button>
    <!-- fin div button demo -->

    <!--Modal Notification-->
    <div id="PasvalideConsult" class="notification modal fade margin-intelligent  row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vvPas">
                    <button type="button" class="close closeX" data-dismiss="modal"
                        style="color: white; margin-left: 10px;">&times;</button>
                        <strong id="vvvPas" style="float: left; margin-left: 2%">
                            <asp:Label ID="lblPasValideTitreConsult" runat="server" />
                        </strong>
                </div>
                <div class="modal-body" id="edPas" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPas" style="color: black; font-weight: bolder">
                            <asp:Label ID="lblPasValidemessageConsult" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal"
                        onclick="return;">OK </button>
                </div>
            </div>
            <!-- Modal content-->
        </div>
    </div>
    <!--fin Modal Notification-->

  <input type="hidden" id="notifHiddenF" />
  <!-- End Card -->
  
    <script>
      
        $(document).change(function () {
            $("#<%=TbIContrepartie.ClientID%>")
                .val($("#<%=TbIContrepartie.ClientID%>")
                .val()
                .replace(/</g, "")
                .replace(/>/g, "")
                .replace(/\//g, ""));
                $("#<%=TbNContrepartie.ClientID%>")
                    .val($("#<%=TbNContrepartie.ClientID%>")
                    .val()
                    .replace(/</g, "")
                    .replace(/>/g, "")
                    .replace(/\//g, ""));
        });

        $(document).ready(function () {
            $("#<%=TbIContrepartie.ClientID%>").val("");
            $("#<%=TbNContrepartie.ClientID%>").val("");
        });
        $("#notifHiddenF").val("Recherche de Tiers");
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
    <div id="Scriptos" runat="server"></div>
</asp:Content>
 <%--FIN CONTENU DE LA PAGE--%>