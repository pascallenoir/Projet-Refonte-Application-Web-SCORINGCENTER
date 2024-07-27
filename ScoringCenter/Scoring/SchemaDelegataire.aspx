<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchemaDelegataire.aspx.cs" Inherits="ScoringCenter.Scoring.SchemaDelegataire" %>

<asp:Content ID="ProfilBody" ContentPlaceHolderID="ContentBody" runat="server">
    <%--<div class="body">--%>
    <%--<div id="Header" style="background: url(../Images/LogoAndifi1.gif) no-repeat; background-size: 100%" class="Header">
            <div class="col-md-2" style="width: 15%; height: 100%;" id="idimgLogoBanque" runat="server">
            </div>
            <%--                <div  class="col-md-10" style="width:90%; height:100%; background-color:blue" >
                    <img src="../Images/LogoAndifi1.gif" style="width: 100%;" />
                </div>
        </div>--%>
    <style>
        .multiselect {
            width: 250px;
        }

        .selectBox {
            position: relative;
        }

            .selectBox select {
                width: 100%;
                font-weight: bold;
            }

        .overSelect {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

        #checkboxes {
            display: none;
            border: 1px #dadada solid;
        }

            #checkboxes label {
                display: block;
            }

                #checkboxes label:hover {
                    background-color: #1e90ff;
                }

        #checkboxes_Agence {
            display: none;
            border: 1px #dadada solid;
        }

            #checkboxes_Agence label {
                display: block;
            }

                #checkboxes_Agence label:hover {
                    background-color: #1e90ff;
                }
    </style>

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

                    <li class="pureCssMenui" id="Pay" runat="server"><a style="/*font-family: cursive; */" class="pureCssMenui" href="ParametrePays.aspx">Paramètres Pays</a></li>

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
                                        <input runat="server" value="Seuil" id="TbSeuil" style="height: 24px; padding-top: 0px; padding-bottom: 0px;" class="form-control" type="button" />
                                    </a>
                                </div>
                                <div class="col-lg-6 col-sm-6 col-md-6">
                                    <a href="SchemaDelegataire.aspx">
                                        <input runat="server" id="TbDeleg" style="height: 24px; padding-top: 0px; padding-bottom: 0px; background-color: #3a5db0; color: white;" class="form-control" type="button" value="Délégation" />
                                    </a>
                                </div>
                            </div>

                            <div class="row inthebody">
                                <div class="col-lg-12 col-sm-12 col-md-12">
                                    <div class="row">
                                        <div class="col-lg-8 col-sm-8 col-md-8">
                                        </div>
                                        <div class="col-lg-4 col-sm-4 col-md-4" style="display: inline; text-align: left;">
                                            <button
                                                type="button"
                                                class="btn btn-sm btn-primary button_div"
                                                style="border: none; padding-top: 0px; padding-bottom: 0px;"
                                                title="Nouveau"
                                                runat="server" onmousedown="con007($(this),'B')"
                                                onserverclick="Button1_ServerClick"
                                                id="Button1">
                                                Ajouter
                                            </button>
                                            <button
                                                type="button"
                                                class="btn btn-sm btn-primary button_div"
                                                style="border: none; padding-top: 0px; padding-bottom: 0px;"
                                                title="Valider"
                                                runat="server" onmousedown="RecupValAgence()"
                                                onserverclick="Button2_ServerClick"
                                                id="Button2">
                                                Valider
                                            </button>
                                        </div>
                                    </div>


                                    <div class="row" style="margin-top: 8px;">
                                        
                                        <div class="col-lg-6 col-sm-6 col-md-6">

                                            <div class="row">
                                                <div class="col-lg-4 col-sm-4 col-md-4" >
                                                    <label class="text-left"> Banque </label> <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8" style="overflow-y: auto; height: 50px;">
                                                    <asp:DropDownList ID="DdlBanque" AutoPostBack="true" onmousedown="con007($(this),'C')"  CssClass="form-control" runat="server" style="height:24px;padding-top:0px;padding-bottom:0px;" OnSelectedIndexChanged="OnBanqueChangeLoadAgences" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    <label class="text-left">
                                                        Nom délégation
                                                    </label> <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8" style="overflow-y: auto; height: 50px;">
                                                    <input runat="server" autocomplete="off" aria-autocomplete="none" id="TextDeleg" style="height: 24px; padding-top: 0px; padding-bottom: 0px;" class="form-control" type="text" placeholder="Nom de la délégation"/>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    <label class="text-left">
                                                        Délegataire(S)
                                                    </label> <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8" style="overflow-wrap: break-word; overflow-x: hidden; overflow-y: auto; height: 150px;">

                                                    <%--<input runat="server" autocomplete="off"  id="Text3" style="height:24px;padding-top:0px;padding-bottom:0px;" class="form-control" type=""  />--%>

                                                    <div class="multiselect">
                                                        <div class="selectBox" onclick="showCheckboxes()">
                                                            <select class="form-control" style="height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;">
                                                                <option>Select an option</option>
                                                            </select>
                                                            <div class="overSelect"></div>
                                                        </div>
                                                        <div id="checkboxes">
                                                            <div id="serve_checkboxes" style="text-align: left" runat="server">
                                                                <label for="one">
                                                                    <input type="checkbox" id="one" />First checkbox</label>
                                                                <label for="two">
                                                                    <input type="checkbox" id="two" />Second checkbox</label>
                                                                <label for="three">
                                                                    <input type="checkbox" id="three" />Third checkbox</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-lg-6 col-sm-6 col-md-6">
                                            <div class="row">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    <label>
                                                        SEUILS
                                                    </label> <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8" style="overflow-y: auto; height: 50px;">

                                                    <select id="SeuilSelect" runat="server" class="form-control pull-left" style="width: 90%; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;">
                                                        <option value=""></option>

                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row" style="">
                                                <div class="col-lg-4 col-sm-4 col-md-4">
                                                    <label>
                                                        AGENCE(S)
                                                    </label> <label style="color: red">*</label>
                                                </div>
                                                <div class="col-lg-8 col-sm-8 col-md-8" style="overflow-wrap: break-word; overflow-x: hidden; overflow-y: auto; height: 150px;">

                                                    <div class="multiselect">
                                                        <div class="selectBox" onclick="showCheckboxes_Agence()">
                                                            <select style="width: 90%; height: 24px; border: none; padding-top: 0px; padding-bottom: 0px;" class="form-control">
                                                                <option>Select an option</option>
                                                            </select>
                                                            <div class="overSelect"></div>
                                                        </div>

                                                        <div id="checkboxes_Agence">
                                                            <div id="serve_checkboxes_Agence" style="text-align: left" runat="server">
                                                                <label for="one">
                                                                    <input type="checkbox" id="ones" />0 à 50</label>
                                                                <label for="two">
                                                                    <input type="checkbox" id="twos" />51 à 100</label>
                                                                <label for="three">
                                                                    <input type="checkbox" id="threes" />101 à illimité</label>
                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                                <%--<div class="col-lg-6 col-sm-6 col-md-6 hidden">
                                        
                                      </div>--%>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-12 col-sm-12 col-md-12">

                                            <table class="table table-bordered table-hover" id="">
                                                <thead>
                                                    <tr class="table-heigth1">
                                                        <th class="text-center">Libellé</th>
                                                        <th class="text-center">Délégataire(s)</th>
                                                        <th class="text-center">Seuil</th>
                                                        <th class="text-center">Agence(s)</th>
                                                        <th class="text-center">Action</th>
                                                    </tr>
                                                </thead>
                                                <tbody id="ListIntervalDeleg" runat="server" style="text-align: center">
                                                    <tr>
                                                        <td>Del GNAKO</td>
                                                        <td>Gnako</td>
                                                        <td>> 100 000 000</td>
                                                        <td>Toutes</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Del Risque Brou</td>
                                                        <td>Brou, Gnako</td>
                                                        <td>50 à 100</td>
                                                        <td>Toutes</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Del reseau</td>
                                                        <td>houphouet</td>
                                                        <td>30 à 50</td>
                                                        <td>Toutes</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Del Ag KOKODI</td>
                                                        <td>YAO</td>
                                                        <td>0 à 30</td>
                                                        <td>Agence A, Agence B</td>
                                                    </tr>
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
    </div>
    <input class="hidden" id="stockAg" runat="server" />
    <input class="hidden" id="stockUt" runat="server" />
    <input id="ValMod" class="hidden" hidden="hidden" onserverchange="OpenModal01" runat="server" />

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


    <div id="Supp_Choix" class="notification modal fade margin-intelligent  row" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" id="vvPasSupp_Choix">
                    <button type="button" class="close closeX" data-dismiss="modal" style="color: white; margin-left: 10px;">&times;</button>
                    <strong id="vvvPasSupp_Choix" style="float: left; margin-left: 2%">
                        <asp:Label ID="lblTitre" runat="server" /></strong>
                </div>

                <div class="modal-body" id="edPasSupp_Choix" style="margin: 0%; padding: 0 !important">
                    <div class="alert alert-info row" role="alert" style="margin: 2%">
                        <p id="gfdPasSupp_Choix" style="color: black; font-weight: bolder">
                            <asp:Label ID="lblMsg" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-primary" data-toggle="tooltip" data-dismiss="modal" onclick="return;">NON</button>--%>
                    <button type="button" class="btn btn-warning" id="ButtonNO" runat="server" onserverclick="ButtonNO_ServerClick">NON</button>
                    <button type="button" class="btn btn-warning" id="ButtonYes" runat="server" onserverclick="ValMod_ServerChange">OUI</button>

                </div>
            </div>
        </div>
    </div>


    <button type="button" style="display: none;" id="ShowSupp_Choix" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#Supp_Choix">
        Launch demo modal
    </button>


    <div id="Scriptos" runat="server">
    </div>
    <%--</div>--%>





    <script>
        var expanded = false;

        function showCheckboxes() {
            var checkboxes = document.getElementById("checkboxes");
            if (!expanded) {
                checkboxes.style.display = "block";
                expanded = true;
            } else {
                checkboxes.style.display = "none";
                expanded = false;
            }
        }
        var expanded_Agence = false;
        function showCheckboxes_Agence() {
            var checkboxes_Agence = document.getElementById("checkboxes_Agence");
            if (!expanded_Agence) {
                checkboxes_Agence.style.display = "block";
                expanded_Agence = true;
            } else {
                checkboxes_Agence.style.display = "none";
                expanded_Agence = false;
            }
        }
    </script>
    <script>
        function RecupValAgence() {
            var stockAg = "";
            var stockUt = "";
            $('.Agencesput').each(function () {
                if ($(this).is(':checked')) {
                    stockAg += "@" + $(this).attr('id');
                }
            });
            $('.Utilisput').each(function () {
                if ($(this).is(':checked')) {
                    stockUt += "@" + $(this).attr('id');
                }
            });
            
            $("#<%=stockAg.ClientID%>").val(stockAg);
            $("#<%=stockUt.ClientID%>").val(stockUt);
        }

        function TousAgencecheck() {

            if ($('#Tousagc').is(':checked')) {
                $('.Agencesput').prop("checked", true);
            }
            else {
                $('.Agencesput').prop("checked", false);
            }
        }
    </script>

    <script>



        function chargerchamptxt(param) {
            //var NomDeleg = param.closest('tr').find('td').eq(0).html();
            //var seuil = param.closest('tr').find('td').eq(2).html();
            //var ListeUser = param.closest('tr').find('td').eq(1).html();
            //var ListeAg = param.closest('tr').find('td').eq(3).html();
            var Idligne = param.closest('tr').attr('id');

            $("#<%=ValMod.ClientID%>").val(Idligne);

        }


        function ShowSupp_Choix() {
            $("#ShowSupp_Choix").click();
        }




    </script>

</asp:Content>
