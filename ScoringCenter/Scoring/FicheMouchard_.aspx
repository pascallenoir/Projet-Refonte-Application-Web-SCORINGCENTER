<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FicheMouchard.aspx.cs" Inherits="ScoringCenter.Scoring.FicheMouchard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU -->
        <ul class="pureCssMenu pureCssMenum">
            <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">Déconnexion</a></li>
            <li class="pureCssMenui" id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <div id="Content" class="Content">

        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <input type="hidden" id="checked_docs" runat="server" value="" />
                <div id="bodyTitle">
                    <h3>Fiche descriptive</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0;">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="col-lg-12 col-md-12 col-sm-12" style="padding: 0;">
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Identification Utilisateur</label>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left">
                                                    Nom  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="NomUser" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Prenom  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="PrenomUser" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Email  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="EmailUser" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Profile  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="ProfilUser" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Agence  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="NomAgence" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6" style="padding: 0;">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="col-lg-12 col-md-12 col-sm-12" style="padding: 0;">
                                    <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                        <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                            <div class="EnteteInfo" style="text-align: center">
                                                <label for="">Action Realisée</label>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left">
                                                    Ecran  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7  text-left " style="font-weight: bold;">
                                                    <asp:Label ID="EcranAction" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Evenement  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="EvenementAction" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Objet  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="ObjetAction" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row push_right" style="margin-left: 2.5%;">
                                                <div class="col-lg-5 col-sm-5 col-md-5 row text-left" >
                                                    Date de réalisation  :
                                                </div>
                                                <div class="col-lg-7 col-sm-7 col-md-7 text-left " style="font-weight: bold;">
                                                    <asp:Label ID="DateAction" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 col-sm-12 col-md-12" style="padding: 0;">
                        <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12" style="margin-bottom: -2.4%; margin-top: -0.5%;">
                                <div class="row div_form" style="background-color: rgba(208, 245, 117, 0.34);">
                                    <div class="EnteteInfo" style="text-align: center;padding-bottom: 2.5%;">
                                        <label for="">Description</label>
                                    </div>
                                    <div class="row push_right" style="margin-left: 2.5%;">
                                        <div class="col-lg-12 col-sm-12 col-md-12  text-left " style="font-weight: bold;">
                                            <asp:Label ID="TextDescription" runat="server"></asp:Label>
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
    <div id="Scriptos" runat="server">
    </div>

</asp:Content>
