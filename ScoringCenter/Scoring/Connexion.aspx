 <%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="ScoringCenter.Connexion" %>

<asp:Content ID="ConnexionBody" ContentPlaceHolderID="ContentConnexion" runat="server">

    <%-- Nouveau template ADOU--%>
        <!-- Titre formulaire -->
        <div class="text-center mb-5">
            <h1 class="display-4">Authentification</h1>
            <p>Entrer vos informations de compte</p>
             <input type="text" runat="server" id="connmou007" hidden />
        </div>
        <!-- fin Titre formulaire -->

        <!-- Nom d'utilisateur -->
        <div class="js-form-message form-group">
           <label class="input-label" for="InputUserName">Nom d'utilisateur</label>
           <input type="text" runat="server" onchange="con007($(this),'T')" maxlength="50" autocomplete="off" class="form-control form-control-lg" name="text" id="InputUserName" placeholder="ex. Société BRICKS" aria-label="ex. Société BRICKS" required-data-msg="Entrer un nom d'utilisateur valide s'il vous plait"/>
        </div>
        <!-- Fin Nom d'utilisateur -->
        
        <!-- Mot de passe -->
        <div class="js-form-message form-group" id="af" runat="server">
          <label class="input-label" for="InputPassword" tabindex="0">Mot de passe </label>
            <div class="input-group input-group-merge">
              <input type="password" class="js-toggle-password form-control form-control-lg" name="password" runat="server" id="InputPassword" autocomplete="off" maxlength="50" placeholder="*************" aria-label="*************" required-data-msg="Your password is invalid. Please try again."
                     data-hs-toggle-password-options='{
                             "target": "#changePassTarget",
                             "defaultClass": "tio-hidden-outlined",
                             "showClass": "tio-visible-outlined",
                             "classChangeTarget": "#changePassIcon"
                           }'>
                    <div id="changePassTarget" class="input-group-append">
                      <a class="input-group-text" href="javascript:;">
                        <i id="changePassIcon" class="tio-visible-outlined"></i>
                      </a>
                    </div>
            </div>
        </div>
        <!-- Fin Mot de passe -->

        <!-- Nouveau mot de passe -->
         <fieldset id="NEWCOMPTE" visible="false" runat="server">
             <legend>Veuillez Modifier votre Mot de passe</legend>

              <!-- nouveau Mot de passe -->
              <div class="js-form-message form-group">
                <label class="input-label" for="InputPassword" tabindex="0">Nouveau Mot de passe</label>
                <div class="input-group input-group-merge">
                  <input type="password" runat="server" id="Password1" autocomplete="off" maxlength="50" name="password" class="js-toggle-password form-control form-control-lg" placeholder="*************" aria-label="*************" required-data-msg="Votre mot de passe est incorrecte. Reessayez s'il vous plait"
                             data-hs-toggle-password-options='{
                                      "target": [".js-toggle-password-target-1", ".js-toggle-password-target-2"],
                                      "defaultClass": "tio-hidden-outlined",
                                      "showClass": "tio-visible-outlined",
                                      "classChangeTarget": ".js-toggle-passowrd-show-icon-1"
                                    }'/>
                     <div class="js-toggle-password-target-1 input-group-append">
                         <a class="input-group-text" href="javascript:;">
                           <i class="js-toggle-passowrd-show-icon-1 tio-visible-outlined"></i>
                         </a>
                    </div>
               </div>
             </div>
              <!-- Fin nouveau Mot de passe -->

             <!-- confirmer nouveau Mot de passe -->
             <div class="js-form-message form-group">
               <label class="input-label" for="InputPassword" tabindex="0">Confirmer Mot de passe</label>
               <div class="input-group input-group-merge">
                 <input type="password" runat="server" id="Password2" autocomplete="off" maxlength="50" name="confirmPassword" class="js-toggle-password form-control form-control-lg" placeholder="*************" aria-label="*************" required-data-msg="Votre mot de passe est incorrecte. Reessayez s'il vous plait"
                        data-hs-toggle-password-options='{
                                 "target": [".js-toggle-password-target-1", ".js-toggle-password-target-2"],
                                 "defaultClass": "tio-hidden-outlined",
                                 "showClass": "tio-visible-outlined",
                                 "classChangeTarget": ".js-toggle-passowrd-show-icon-2"
                               }'/>
                <div class="js-toggle-password-target-1 input-group-append">
                    <a class="input-group-text" href="javascript:;">
                      <i class=".js-toggle-passowrd-show-icon-2 tio-visible-outlined"></i>
                    </a>
                  </div>
                </div>
             </div>
             <!-- Fin confirmer nouveau Mot de passe -->
         </fieldset>
        <!-- Fin Mot de passe -->

        <!-- Alerte message d'erreur -->
        <div id="getMessage" visible="false" runat="server">
          <div class="alert alert-soft-primary alert-dismissible fade show" role="alert" id="AlerteMauvaisAcces">
             <strong>Nom d'utilisateur ou Mot de passe incorrecte</strong>  Veuillez réessayer !
             <button type="button" class="close" data-dismiss="alert" aria-label="Close" onclick="closeAlertAndPostBack()">
                 <i class="tio-clear tio-lg"></i>
             </button>
           </div>
        </div>
        <!-- fin Alerte message d'erreur -->

        <!-- bouton de connexion -->
        <asp:Button type="submit" ID="Connexions" runat="server" class="btn btn-lg btn-block btn-primary"  onmousedown="con007($(this),'B')" OnClick="Connexion_Click" TexT="Se connecter"/>
        <!-- Fin bouton de connexion -->
    <%-- fin   Nouveau template ADOU--%>


    <script>
        var chaine = "";
        $(document).ready(function () {
            var ladate = new Date();
            chaine = (ladate.getFullYear()) + '-' + ('0' + (ladate.getMonth() + 1)).slice(-2) + '-' + ('0' + ladate.getDate()).slice(-2) + ' ' + ('0' + ladate.getHours()).slice(-2) + ':' + ('0' + ladate.getMinutes()).slice(-2) + ':' + ('0' + ladate.getSeconds()).slice(-2) + '';
        });
        function O42451(chain) {
            chaine = chaine + "@" + chain;
            $("#<%=connmou007.ClientID%>").val(chaine);
        }


        function closeAlertAndPostBack() {
            // Fermer l'alerte
            var alertElement = document.getElementById('AlerteMauvaisAcces');
            if (alertElement) {
                alertElement.style.display = 'none';
            }

            // Déclencher l'événement serveur
            __doPostBack('<%= ClientID %>', 'Alert_dismissible');
        }
    </script>


</asp:Content>