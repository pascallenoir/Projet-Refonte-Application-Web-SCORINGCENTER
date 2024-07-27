<%@ Page Language="C#" MasterPageFile="~/PremierePage.Master" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="ScoringCenter.Connexion" %>

<asp:Content ID="ConnexionBody" ContentPlaceHolderID="ContentConnexion" runat="server">
    <div class="main">
        <div class="login-form">
            <h2 style="color: white; font-size: 12px;">AUTHENTIFICATION</h2>
            <input type="text" runat="server" id="connmou007" hidden />

            <div class="agileits-top">
                <div class="styled-input">
                    <input type="text" runat="server" onchange="con007($(this),'T')" id="InputUserName" name="User Name" required="" />
                    <label>Nom d'utilisateur</label><span></span>
                </div>
                <div class="styled-input">
                    <input type="password" runat="server" id="InputPassword" name="Password" required="" />
                    <label>Mot de passe</label><span></span>
                </div>
                <div id="getMessage" runat="server"></div>
            </div>
            <div class="agileits-bottom" onclick="">
                <asp:Button ID="Connexions" runat="server" class="" onmousedown="con007($(this),'B')" OnClick="Connexion_Click" Text="Se Connecter" />
            </div>
        </div>
    </div>
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
    </script>
</asp:Content>