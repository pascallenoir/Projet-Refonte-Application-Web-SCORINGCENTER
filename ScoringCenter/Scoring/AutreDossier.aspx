<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutreDossier.aspx.cs"
    Inherits="ScoringCenter.AutreDossier" %>

<asp:Content ID="AutreDossierBody" ContentPlaceHolderID="ContentBody" runat="server">

     <input type="text" runat="server" id="connmou007" hidden />
    <!-- Card -->
    <!-- Step Form -->
    <form id="form_scoring" class="py-md-5"  runat="server">
      <div class="row justify-content-lg-start">
        <div class="col-lg-10">
         
          <!-- Content Step Form -->
          <div>
            <!-- Card -->
            <div class="card card-lg">
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
                      <label for="TbIContrepartie" class="col-sm-2 col-form-label input-label">Client <i style="color: red">*</i></label>

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
                 <span id="Spinner" visible="false" class="spinner-border spinner-border-sm" role="status" runat="server" ></span>
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

          <!-- Tableau Derniers notes -->
          <div class="row justify-content-lg-start">
              <div class="col-lg-8 col-md-8">
                  <h3 style="font-size: 18px;">Derniers notés</h3>
                  <table class="table table-bordered" style="margin: 10px;">
                      <thead style="background-color: #022D65; color: #FFFFFF;">
                          <tr>
                              <th>Tiers</th>
                              <th>Agence</th>
                              <th>Date</th>
                              <th>Note</th>
                          </tr>
                      </thead>
                      <tbody id="DerniersNotesTable" runat="server">
                          <!-- Ici sera injecté le contenu du tableau généré par la méthode -->
                      </tbody>
                  </table>
              </div>
          </div>
          <!-- Fin Tableau Derniers notes -->
         </div>
         <!-- End Card -->

      </div>
      <!-- End Content Step Form -->
      <!-- End Row -->
          <div id="Select_Choix" class="chargement modal fade margin-intelligent row" role="dialog" data-keyboard="false" data-backdrop="static">
           <div class="modal-dialog">
               <!-- Modal content-->
               <div class="modal-content">
                   <div class="modal-header">
                       <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                       <strong>INFORMATION</strong>
                   </div>
                   <div class="modal-body">
                       <label>Veuillez choisir la périodicité</label>
                   </div>
                   <div class="modal-footer">
                       <%--<asp:Button ID="Btn_ControlePoste" runat="server" onclick="ControlePost();" Text="Calculer" class="btn btn-warning" />--%>
                       <button type="button" class="btn btn-cergicolor" id="Btn_Select_Periodicite" onclick="Afficher_Modal_Traitement_et_Edition();">Ok</button>
                       <asp:TextBox Style="display: none" ID="TextBox2" runat="server"></asp:TextBox>
                       <%--<button type="button" class="btn btn-cergicolor" id="AnnulerButton" data-dismiss="modal">Annuler</button>--%>
                   </div>
               </div>
           </div>
       </div>
       <div id="Reconnexionmodal" class="notification modal fade margin-intelligent timing row" role="dialog">
          <div class="modal-dialog">
             <!-- Modal content-->
             <div class="modal-content">
                 <div class="modal-header" id="vv">
                     <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                     <strong id="rvv" style="float: left; margin-left: 2%">Reconnexion </strong>
                 </div>
                 <div class="modal-body" id="red" style="margin: 0%; padding: 0 !important">
                     <div class="alert alert-info row" role="alert" style="margin: 2%">
                         <p id="rfd" style="color: black; font-weight: bolder">
                             <asp:Label CssClass="text-center" ID="Label3" Text="Veuillez saisir votre identifiant et votre mot de passe" runat="server" />
                         </p>
                     </div>
                     <div class="row push_right" style="margin-left: 6%;">
                         <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="ReconnexLogin">Identifiant:</label>
                         <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                             <input runat="server" type="text" id="ReconnexLogin" autocomplete="off" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                         </div>
                     </div>
                     <div class="row push_right" style="margin-left: 6%;">
                         <label class="control-label col-lg-5 col-sm-5 col-md-5 col-lg-pull-1 text-right" for="ReconnexPassword">Mot de Passe:</label>
                         <div class="col-lg-7 col-sm-7 col-md-7 col-lg-pull-1">
                             <input runat="server" type="password" id="ReconnexPassword" autocomplete="off" class="form-control" style="width: 100%; height: 24px; padding-top: 0px; padding-bottom: 0px;" />
                         </div>
                     </div>
                 </div>
  
                 <div class="modal-footer">
                     <button type="button" runat="server" class="btn btn-primary" data-toggle="tooltip" id="ReconnexionOpenConsult">Valider</button>
                     <button type="button" style="display: none;" id="btbtbt" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal">Fermer</button>
                 </div>
             </div>
            </div>
         </div>
  
  <button type="button" style="display: none;" id="ShowReconnexion" class="btn btn-primary btn-lg"
      data-toggle="modal" data-target="#Reconnexionmodal">
      Launch demo modal
  </button>


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
      </div>
  </div>
  <!--fin Modal Notification-->

  <input type="hidden" id="notifHiddenF" />
  </form>
  <!-- End Step Form -->
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

        var stoccount = 0; var mainte = 0;

            $("#<%=ReconnexionOpenConsult.ClientID%>").on("click", function (e) {

            var ReconnexLogin = $("#<%=ReconnexLogin.ClientID%>").val(); var ReconnexPassword = $("#<%=ReconnexPassword.ClientID%>").val();
            $.ajax({
                type: "POST",
                url: "../Scoringws.asmx/Connexion_Click",
                data: "{'ReconnexLogin': '" + ReconnexLogin + "','ReconnexPassword': '" + ReconnexPassword + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    //alert(response.d[0]);
                    if (response.d[0] != "true") {
                        stoccount++;
                        $("#<%=ReconnexPassword.ClientID%>").addClass("danger");
                            //mainte = 0;
                        }
            else {
                // mainte = 1;
                // btbtbt
                $("#btbtbt").click();
                        }
            if (stoccount == 3) {stoccount = 0; window.location = "Connexion.aspx"; }
                    },
            failure: function (response) {
                alert("failure");
                    },
            error: function (response) {
                alert("error");
                    }
                });

            });
        
    </script>
    <div id="Scriptos" runat="server"></div>
</asp:Content>