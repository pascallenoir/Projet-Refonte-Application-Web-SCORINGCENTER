<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mouchard.aspx.cs" Inherits="ScoringCenter.Scoring.Mouchard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMenu" runat="server">
        <div id="Menu" class="pureCssMenu">
        <!-- Start PureCSSMenu.com MENU --> 
        <ul class="pureCssMenu ">   
            <li class="pureCssMenui"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx"> Déconnexion</a></li>                         
	        <li class="pureCssMenui" id="AD" runat="server"><a style="/*font-family: cursive;*/" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <div id="Content" class="Content">
        
        <div class="bigbody">
            <div id="thebody" class="noBackground">
                <input type="hidden" id="checked_docs" runat="server" value=""/>
                <div id="bodyTitle">
                    <h3>Mouchard</h3>
                </div>
                <div class="row inthebody br_topbody">
                   
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 2%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form" style="background-color:rgba(208, 245, 117, 0.34); border:none; margin-top: -0.5%; padding:3px;">
                                <table class="table table-bordered table-hover" id="tableMou007">
                                    <thead class="table-heigth">
                                        <tr class="table-heigth1">
                                            <th class="text-center">Date</th>
                                            <th class="text-center">Utilisateur</th>
                                            <th class="text-center">Ecran</th>
                                            <th class="text-center">Evenement</th>
                                            <th class="text-center">Action</th>
                                            <th class="text-center">Objet</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ListDocTableauBord" runat="server" style="text-align: center">
                                           
                                    </tbody>
                                </table>

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
        function ligneclick(id) {
            window.location = "FicheMouchard.aspx?id=" + id;
        }
        $('#tableMou007').DataTable({
            "paging": true,
            "lengthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "scrollY": "200px",
            "scrollCollapse": true,
        });
    </script>
</asp:Content>
