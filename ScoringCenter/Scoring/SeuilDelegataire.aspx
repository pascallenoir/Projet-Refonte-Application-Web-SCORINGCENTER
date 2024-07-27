<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeuilDelegataire.aspx.cs" Inherits="ScoringCenter.Scoring.SeuilDelegataire" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">
<%--<div class="body">--%>
        <%--<div id="Header" style="background: url(../Images/LogoAndifi1.gif) no-repeat; background-size: 100%" class="Header">
            <div class="col-md-2" style="width: 15%; height: 100%;" id="idimgLogoBanque" runat="server">
            </div>
            <%--                <div  class="col-md-10" style="width:90%; height:100%; background-color:blue" >
                    <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
                </div>
        </div>--%>
        <div id="Menu" class="pureCssMenu">
            <ul class="pureCssMenu ">
                <li class="pureCssMenui" id="C" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Connexion.aspx">
                    <%--<i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-off"></i> --%>
                    Déconnexion</a></li>
                <li class="pureCssMenui" id="AD" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
                <li class="pureCssMenui " id="TB" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="TableauBordAutreDossier.aspx">Tableau de bord</a></li>
                <li class="pureCssMenui pull-right" style="" id="DOC" runat="server">
                    <a style="/*font-family: cursive; */" class="pureCssMenui " href="#">
                        <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                        <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                    </a>
                    <ul class="" style="z-index: 10;">
                        <li class="pureCssMenui" id="GUT" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                        <li class="pureCssMenui" id="MNT" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    </ul>
                </li>
                <li class="pureCssMenui pull-right" style="" id="PARAM" runat="server">
                    <a style="/*font-family: cursive; */ background-color: #022D65;" class="pureCssMenui" href="#">
                        <i style="color: white; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-cog"></i>
                        <i style="color: #FFFFFF; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i></a>
                    <ul class="" style="z-index: 10;">
                        <li class="pureCssMenui" id="GP" runat="server"><a class="pureCssMenui" href="Profil.aspx">Gestion des profils</a></li>
                        <li class="pureCssMenui" id="GU" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Utilisateur.aspx">Gestion des utilisateurs</a></li>

                        <li class="pureCssMenui" id="GPA" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="Parametre.aspx">Gestion des paramètres</a></li>
                        <%--<li class="pureCssMenui" id="CC" runat="server"><a class="pureCssMenui" href="CenCont.aspx">Données Signalétiques</a></li>
                        <li class="pureCssMenui" id="Cen" runat="server"><a class="pureCssMenui" href="Cencours.aspx">Données Comptables</a></li>--%>
                        <li class="pureCssMenui" id="SD" runat="server"><a class="pureCssMenui" style="background-color: #022D65; color: #FFFFFF;" href="SeuilDelegataire.aspx">Schémas délégataires</a></li>

                        <li class="pureCssMenui" id="Pay" runat="server"><a style="/*font-family: cursive; */ " class="pureCssMenui" href="ParametrePays.aspx">Paramètres Pays</a></li>

                    </ul>
                </li>
            </ul>
        </div>

        <div class="br_top">
            <div id="Content" class="Content br_top">
                <br class="br_top" />
                <input type="text" runat="server" hidden id="connmou007" />
                <div id="thebody" class="noBackground">
                    <div id="bodyTitle">
                        <h3>Schémas Délégataires</h3>
                    </div>
                    <div class="row inthebody" style="background-color: rgba(208, 245, 117, 0.34); box-shadow: rgba(151, 207, 247, 0.39) 2px 5px 5px; border-radius: 4px 4px; margin-left: 5%; margin-right: 5%;">
                        <div class="row" style="margin: 2%;">
                            <div class="col-lg-12 col-sm-12 col-md-12">
                                <div class="row">
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                        <a href="SeuilDelegataire.aspx">
                                            <input runat="server" value="Seuil"  id="TbSeuil" style="height:24px;padding-top:0px;padding-bottom:0px; background-color:#3a5db0; color:white;" class="form-control" type="button" />
                                        </a>
                                    </div>
                                    <div class="col-lg-6 col-sm-6 col-md-6">
                                       <a href="SchemaDelegataire.aspx">
                                            <input runat="server"  id="TbDeleg" style="height:24px;padding-top:0px;padding-bottom:0px;" class="form-control" type="button" value="Délégation" />
                                       </a>
                                    </div>
                                </div>
                                <div class="row inthebody">
                                    <div class="col-lg-12 col-sm-12 col-md-12">
                                        <div class="row">
                                    <div class="col-lg-8 col-sm-8 col-md-8">
                                    <div class="row">
                                    <div class="col-lg-3 col-sm-3 col-md-3">
                                        <label>
                                            Nombre d'intervalle
                                        </label>                          
                                    </div>
                                    <div class="col-lg-3 col-sm-3 col-md-3">
                                        
                                                <asp:DropDownList ID="nbintervalle" CssClass="form-control" AutoPostBack="true"
                                                        runat="server" Height="24" Style="font: bold 11px arial,verdana; padding: -1%; padding-top: 0%; padding-bottom: 0%; width: 70%;" OnSelectedIndexChanged="nbintervalle_ServerChange">
                                                        <asp:ListItem>0</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<input runat="server" autocomplete="off"  id="Text3" style="height:24px;padding-top:0px;padding-bottom:0px; background-color:#ff6a00; color:white;" class="form-control" type="text" placeholder="2" />--%>                                                                              
                                    </div>
                                    
                                    <div class="col-lg-3 col-sm-3 col-md-3" >
                                        <label class="text-left"> Banque </label> <label style="color: red">*</label>
                                    </div>
                                    <div class="col-lg-3 col-sm-3 col-md-3" style="overflow-y: auto; height: 50px;">
                                        <asp:DropDownList ID="DdlBanque" AutoPostBack="true" onmousedown="con007($(this),'C')"  CssClass="form-control" runat="server" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="OnBanqueChangeLoadAgences" />
                                    </div>
                                   
                                    </div>                                    
                                    </div>
                                    <div class="col-lg-4 col-sm-4 col-md-4">
                                        <div style="display: inline; text-align: left;">
                                            <div 
                                                class="btn btn-sm btn-primary button_div" 
                                                style="border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Nouveau" 
                                                runat="server"  
                                                id="btnNouveau"
                                                >
                                                Ajouter
                                            </div>
                                            <div 
                                                class="btn btn-sm btn-primary button_div" 
                                                style=" border:none; padding-top:0px; padding-bottom:0px;" 
                                                title="Valider" 
                                                runat="server"  
                                                onclick="ParcourVal()" 
                                                id="btnValider"
                                                >
                                                Valider
                                            </div>
                                           
                                           
                                        </div>
                                       
                                    </div>
                                </div>
                                        <div class="row">
                                
                                    <div style="margin-top:10px;" class="col-lg-12 col-sm-12 col-md-12">

                                            <table class="table table-bordered table-hover" id="">
                                    <thead>
                                        <tr class="table-heigth1">
                                            <th class="text-center" width=50%>Minimun</th>
                                            <th class="text-center"width=50%>Maximum</th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody id="Tbody1" runat="server" style="text-align: center">
                                        
                                    </tbody>
                                </table>


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
            <input type="hidden" class="hidden" hidden="hidden"  id="CodeBanque11" runat="server" />
        </div>

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
        <div id="Scriptos" runat="server">
        </div>
    <%--</div>--%>
    <script>
        var tp = 0;
        $("table").find('td').on('click', function (e) {
            if ($(this).html().trim() != "illimité") {//&& $(this).html().trim() != "0"
                $("table").find('tr').removeClass('alert-warning');
                if (!$(this).hasClass('min')) {
                    var cont = $(this).html();
                    if (tp == 0) {
                        $(this).html('<input class="cergiDecimalMoney"  nbDecimal="0" style="width:100%;" value="' + (cont.replace("<strong>", " ")).replace("</strong>", " ").replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "") + '"/>');
                        tp = 1;
                        FomateNumeric();
                    }
                    else {
                        if ($(this).html().substring(0, 6) != '<input') {
                            //if ($("table").find('input').val().trim() != '') {

                            //    $("table").find('input').parent().html($("table").find('input').val());
                            //} else
                            //    $("table").find('input').parent().html('0');
                            $(this).html('<input class="cergiDecimalMoney"  nbDecimal="0" style="width:100%;"  value="' + (cont.replace("<strong>", " ")).replace("</strong>", " ").replace("<i style=\"color:#69a8f4\">", "").replace("</i>", "") + '"/>');
                            tp = 1;
                            FomateNumeric();
                        }
                    }
                }
            }
            else {
                $(this).parent().addClass('alert-warning');
               
            }

        });

        function FomateNumeric() {
            $('.cergiDecimalMoney').each(function () {
                //if ($(this).val().substring(0, 1) != '-') 
                $(this).number(true, parseInt($(this).attr("nbDecimal")));
            });
        }

        $("table").find('td').on('change', function (e) {
            if ($(this).html().substring(0, 6) == '<input') {
                
                $(this).parent().next().find('td').eq(0).html((parseInt($(this).find('input').val()) + 1));
                
            }
        });

        $(document).ready(function () {
            $('table td').each(function () {
                $(this).html(formatageMillierSunsurve($(this).html()));
            });

        });

        function formatageMillierSunsurve(nombre) {
            if (isNaN(nombre)) {

                return nombre;
            }
            else {
                nombre = nombre.replace(/ /g, "");
                nombre += '';
                var sep = ' ';
                var reg = /(\d+)(\d{3})/;
                while (reg.test(nombre)) {
                    nombre = nombre.replace(reg, '$1' + sep + '$2');
                }
                return nombre.replace(/,/g, " ");
            }
        }

    </script>
    <script>
        $(document).ready(function () {
            $("#<%=nbintervalle.ClientID%>").attr("disabled", "disabled");
            <%--$("#<%=DdlBanque.ClientID%>").attr("disabled", "disabled");--%>
            $('table input').each().attr("disabled", "disabled");
        });
        
        $("#<%=btnNouveau.ClientID%>").on('click', function (e) {
            $("#<%=nbintervalle.ClientID%>").removeAttr("disabled");
            <%--$("#<%=DdlBanque.ClientID%>").removeAttr("disabled");--%>
            $('table input').each().removeAttr("disabled");
        });

        

    </script>
    <script>
        $('body').on('blur', "table input", function () {
            $(this).parent().html($(this).val() === '' ? '0' : $(this).val());
            return true;
        });

        function ParcourVal() {
            
            try{
                $("table").find('input').parent().html($("table").find('input').val());
            } catch (error) {
                
            }
            suppValInt($("#<%=CodeBanque11.ClientID%>").val());
            
            
            
        }
        function insertValInt(ValeurRec) {
            $.ajax({
                type: "POST",
                url: "SeuilDelegataire.aspx/insertValInt",
                data: "{'text': '" + ValeurRec + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    //if (response.d[0] == true) alert("good");
                },
                failure: function (response) {
                    $("#<%=lblPasValideTitreConsult.ClientID%>").html("Attention");
                    $("#<%=lblPasValidemessageConsult.ClientID%>").html("Une erreur s'est produite \n" + response.d);
                    $('#PasvalideConsult').modal('show');
                }
            });
        }

        function suppValInt(CodeBanque11) {
            $.ajax({
                type: "POST",
                url: "SeuilDelegataire.aspx/suppValInt",
                data: "{'text': '" + CodeBanque11 + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    $("#<%=Tbody1.ClientID%> tr").each(function (e) {
                        var ValeurRec = $("#<%=CodeBanque11.ClientID%>").val() + "@" + $(this).id + "@" + $(this).find('td').eq(1).html() + "@" + $(this).find('td').eq(0).html();
                        insertValInt(ValeurRec);
                    });
                    $("#<%=lblPasValideTitreConsult.ClientID%>").html("Succès");
                    $("#<%=lblPasValidemessageConsult.ClientID%>").html("Opération réussie.");
                    $('#PasvalideConsult').modal('show');
                },
                failure: function (response) {
                    $("#<%=lblPasValideTitreConsult.ClientID%>").html("Attention");
                    $("#<%=lblPasValidemessageConsult.ClientID%>").html("Une erreur s'est produite \n" + response.d);
                    $('#PasvalideConsult').modal('show');
                }
            });
        }
    </script>
</asp:Content>