<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ValidationNote.aspx.cs" Inherits="ScoringCenter.Scoring.ValidationNote" %>

<asp:Content ID="ValidationNoteMenu" ContentPlaceHolderID="ContentMenu" runat="server">
    <div id="Menu" class="col-xs-12 pureCssMenu" style="padding:0">
        <ul class="pureCssMenu ">
            <li class="pureCssMenui" id="AD" runat="server"><a class="pureCssMenui" href="AutreDossier.aspx">Autre Dossier</a></li>
            <li class="pureCssMenui" id="TB" runat="server"><a id="TBa" class="pureCssMenui" href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="pureCssMenui" id="FS" runat="server"><a class="pureCssMenui" href="FicheSignaletique.aspx">Fiche signalétique</a></li>
            <li class="pureCssMenui" id="HN" runat="server"><a class="pureCssMenui" href="HistoriqueNotation.aspx">Dossiers de notation</a></li>
            <li class="pureCssMenui" id="DN" runat="server"><a class="pureCssMenui active_menu" href="#">Effectuer une notation</a></li>
            <li class="pureCssMenui" id="AN" runat="server"><a class="pureCssMenui" href="Annotations.aspx">Annotations</a></li>
            <li class="pureCssMenui pull-right" style="" id="doc" runat="server">
                <a class="pureCssMenui " href="#">
                    <i style="color: #022D65; font-weight: bold; font-size: 12px;" class="glyphicon glyphicon-file"></i>
                    <i style="color: white; font-size: 6px;" class="glyphicon glyphicon-triangle-bottom"></i>
                </a>
                <ul class="" style="z-index: 10;">
                    <li class="pureCssMenui"><a style="color: #d8d8d8" class="pureCssMenui" href="#" data-toggle="modal" data-target="#">Guide Utilisateur</a></li>
                    <li class="pureCssMenui"><a style="color: #d8d8d8" class="pureCssMenui" href="#">Modèle de notation</a></li>
                    <li class="pureCssMenui"><a class="pureCssMenui Aides" href="#" data-toggle="modal" data-target="#helpmodal">Aide</a></li>
                </ul>
            </li>
            <li class="pureCssMenui pull-right" style="" id="EBF" runat="server"><a style="color: #d8d8d8" class="pureCssMenui" href="#">Envoi Bilan financier</a></li>
            <span class="col-xs-12 sub_menus" style="padding:0">
                <span class="col-xs-4" style="text-align:left; padding:10px">
                    <asp:Label ID="LblModeleNotation" runat="server"> </asp:Label></>
                    <asp:Label ID="LblADireExpert" runat="server"> </asp:Label></>
                </span>
                <span class="col-xs-8">
                    <span class="col-xs-12 sub_menus_dn">
                            <li class="pureCssMenu" id="NCP" runat="server"><a class="pureCssMenui" href="#">Notation de la contrepartie</a></li>
                            <li class="pureCssMenu" id="NOP" runat="server"><a class="pureCssMenui" href="#">Notation de l'opération</a></li>
                            <li class="pureCssMenui" id="VN" runat="server"><a class="pureCssMenui active_menu" href="#">Validation de la note</a></li>
                    </span>
                    <span class="col-xs-12">
                        <span style="display:none; float:left" class="sub_menu_ncp">
                            <li class="pureCssMenui" id="AF1" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse financière</a></li>
                            <li class="pureCssMenui" id="AF2" runat="server"><a class="pureCssMenui" href="AnalyseFinanciere.aspx">Analyse Consolidée</a></li>
                            <li class="pureCssMenui" id="AQ" runat="server"><a class="pureCssMenui" href="AnalyseQualitative.aspx">Analyse qualitative</a></li>
                            <li class="pureCssMenui" id="AS" runat="server"><a class="pureCssMenui" href="DossierNotationGroupe.aspx">Analyse Structurelle Groupe</a></li>
                            <li class="pureCssMenui" id="IG" runat="server"><a class="pureCssMenui" href="IntegrationGroupe.aspx">Intégration groupe</a></li>
                            <li class="pureCssMenui" id="RP" runat="server"><a class="pureCssMenui" href="RisquePays.aspx">Risque pays</a></li>
                        </span>
                        <span style="display:none; float:left" class="sub_menu_nop">
                            <li class="pureCssMenui" id="AOP" runat="server"><a class="pureCssMenui" href="AnalyseOperation.aspx">Analyse de l'opération</a></li>
                            <li class="pureCssMenui" id="E" runat="server"><a class="pureCssMenui" href="Encours.aspx">Encours</a></li>
                        </span>
                    </span>
                </span>
            </span>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="ValidationNoteBody" ContentPlaceHolderID="ContentBody" runat="server">
    <style>
        .bg-sombre {
            background-color: #f2f2f2;
        }
    </style>
    <div id="Content" class="Content">
        <br class="br_top" />
        <input type="text" runat="server" id="connmou007" hidden />
        <div class="bigbody">
            <div id="thebody" class="noBackground bg-claire">
                <div id="bodyTitle">
                    <h3>Validation de la note</h3>
                </div>
                <div class="row inthebody br_topbody">
                    <div class="row" style="margin-left: 2%; margin-right: 2%; margin-top: 0.5%;">
                        <div class="col-lg-12 col-sm-12 col-md-12">
                            <div class="row div_form">
                                <div class="col-lg-12 col-sm-12 col-md-12" style="max-height: 25%; overflow: hidden;">
                                    <div class="row contreparie_info_1">
                                        <div class="col-xs-4 text-left">
                                            <b>
                                                <asp:Label ID="Rsocial" runat="server" CssClass="boldSize"
                                                    Text="Raison Sociale : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="NClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">

                                            <b>
                                                <asp:Label ID="Iprincipal" CssClass="boldSize" runat="server"
                                                    Text="Id principal : "></asp:Label></b>
                                            <asp:Label ID="Idprincip" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-5 text-left">
                                            <b>
                                                <asp:Label ID="Sren" runat="server" CssClass="boldSize"
                                                    Text="Act. SYSCOHADA : "></asp:Label></b> &nbsp;
                                            <asp:Label ForeColor="#cc0000" ID="Siren" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row contreparie_info_2">
                                        <div class="col-xs-1 text-left">
                                            <asp:Label ID="SaiTypeClient" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">
                                            <b>
                                                <asp:Label ID="Groupe" runat="server" CssClass="boldSize"
                                                    Text="Groupe : "></asp:Label></b> &nbsp;
                                                <asp:Label ID="SaiGroupe" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-3 text-left">
                                            <%--<b>
                                                    <asp:Label ID="Label6" CssClass="boldSize" runat="server" Text="Id SC : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="IdScoringCenter" runat="server" Text=""></asp:Label>--%>

                                                <b>
                                                    <asp:Label ID="Label7" CssClass="boldSize" runat="server" Text="Banque : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="SigleBanq" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-xs-2 text-left">
                                            <b>
                                                <asp:Label ID="LbChiffre" CssClass="boldSize" runat="server" Text="CA : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="ChiffreAffaire" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-lg-2 col-sm-2 col-md-2 text-left">
                                            <b>
                                                <asp:Label ID="LbDevise" CssClass="boldSize" runat="server"
                                                    Text="Devise : "></asp:Label></b> &nbsp;
                                            <asp:Label ID="Devise" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-11 " style="border-radius: 0px 0px; background-color: rgba(31, 65, 94, 0.96); color:#FFFFFF; margin-left: 4%; margin-right: 4%; margin-top: 0%;">
                                    <p style="/*font-family: cursive; */ margin-top:5px; margin-bottom:5px; font-size: 13px;" class="text-left">
                                        <b>Modèle de notation :</b>
                                        <span style="font-size: 13px;">
                                            <strong style=" color:#000;">
                                                <asp:DropDownList ID="SelectNotation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectNotation_SelectedIndexChanged"> 
                                                    <asp:ListItem Value="Corporate" Text="Corporate"></asp:ListItem>
                                                    <asp:ListItem Value="ADE" Text="A dire d'expert"></asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<select id="SelectNotation" style="width:100%" runat="server">
                                                </select>--%>
                                                <%--<asp:TextBox ID="txtHideNoteEnv"  runat="server" Text="" ></asp:TextBox>
                                                <asp:TextBox ID="txtHideNoteProp" runat="server" Text=""></asp:TextBox>--%>
                                            </strong>
                                            <strong>
                                                <asp:Label ID="MNotation" runat="server" Text=""></asp:Label>
                                            </strong>
                                        </span>
                                    </p>
                                </div>
                        </div>
                        
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                
                                <div class="col-xs-12" style="border-radius: 0px 0px; background-color:rgba(12, 73, 113, 0.82); color:#FFFFFF; margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p style="/*font-family: cursive; */font-size: 13px; margin-top:5px; margin-bottom:5px;" class="text-left">
                                        <b>Analyse de la contrepartie</b>
                                    </p>
                                </div>
                                 <div class="col-xs-12" style="border-radius: 4px 4px; background-color: rgba(212, 205, 166, 0.00); margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p id="NFN" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Note financière :</b>
                                        <span id="notefinancièref" style="font-size: 13px; padding-left: 10px;">
                                            <strong>
                                                <asp:Label ID="NFinanciere" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>
                                    <p id="NCO" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Note Consolidé :</b>
                                        <span id="noteconsolidef" style="font-size: 13px; padding-left: 10px;">
                                            <strong>
                                                <asp:Label ID="NConsolide" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>

                                    <p id="NQA" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Note qualitative :</b>
                                        <span id="notequalitativef" style="font-size: 13px; padding-left: 7px;">
                                            <strong>
                                                <asp:Label ID="NQualitative" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>
                                    <p id="NST" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Note Structurelle :</b>
                                        <span id="notestructurellef" style="font-size: 13px; padding-left: 7px;">
                                            <strong>
                                                <asp:Label ID="NStructurelle" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>

                                     <p id="libgroup" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Note groupe :</b>
                                        <span id="Notegroupef" style="font-size: 13px; padding-left: 9px;">
                                            <strong>
                                                <asp:Label ID="NGroupe" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>
                                    <p id="libpays" runat="server" style="/*font-family: cursive; */ font-size: 13px;" class="text-left">
                                        <b>Risque pays :</b>
                                        <span style="font-size: 13px; padding-left: 9px;">
                                            <strong>
                                                <asp:Label ID="RPays" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>
                                </div>
                                <div class="col-xs-12" style="border-radius: 0px 0px; background-color:rgba(77, 171, 226, 0.89); margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p style="/*font-family: cursive; */font-size: 13px; margin-top:5px; margin-bottom:5px;" class="text-left">
                                        <b>Note de la contrepartie :</b>
                                        <span style="font-size: 13px; padding-left: 20px;">
                                            <strong>
                                                <asp:Label ID="Label1Calc" runat="server" Text="NC"></asp:Label>
                                            </strong>
                                        </span>
                                    </p>
                                </div>

                                <div class="col-xs-12">
                                    <div class="row contrep" style="padding-top:5%;">
                                        <div class="col-xs-12">
                                            <span class="">
                                                <span id="contrep-note-01" class="col-xs-1 contrep-note note">D</span>
                                                <span id="contrep-note-02" class="col-xs-1 contrep-note note">C-</span>
                                                <span id="contrep-note-03" class="col-xs-1 contrep-note note">C</span>
                                                <span id="contrep-note-04" class="col-xs-1 contrep-note note">C+</span>
                                                <span id="contrep-note-05" class="col-xs-1 contrep-note note">B-</span>
                                                <span id="contrep-note-06" class="col-xs-1 contrep-note note">B</span>
                                                <span id="contrep-note-07" class="col-xs-1 contrep-note note">B+</span>
                                                <span id="contrep-note-08" class="col-xs-1 contrep-note note">A-</span>
                                                <span id="contrep-note-09" class="col-xs-1 contrep-note note">A</span>
                                                <span id="contrep-note-10" class="col-xs-1 contrep-note note">A+</span>
                                            </span>
                                            <span class="the-jauge">
                                                <span class="col-xs-1 jauge D"></span>
                                                <span class="col-xs-1 jauge C-m"></span>
                                                <span class="col-xs-1 jauge C"> </span>
                                                <span class="col-xs-1 jauge C-p"></span>
                                                <span class="col-xs-1 jauge B-m"></span>
                                                <span class="col-xs-1 jauge B"></span>
                                                <span class="col-xs-1 jauge B-p"></span>
                                                <span class="col-xs-1 jauge A-m"></span>
                                                <span class="col-xs-1 jauge A"></span>
                                                <span class="col-xs-1 jauge A-p"></span>
                                            </span>
                                            <span class="">
                                                <span id="contrep-mrk-01" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-02" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-03" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-04" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-05" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-06" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-07" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-08" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-09" class="col-xs-1 contrep-marker marker"></span>
                                                <span id="contrep-mrk-10" class="col-xs-1 contrep-marker marker"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="col-md-2">
                                 <div class="col-lg-12" style="border-radius: 4px 4px; background-color: rgba(212, 205, 166, 0.59); margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    
                                 </div>
                            </div>--%>
                            <div class="col-xs-4">
                               
                                <div class="col-xs-12" style="border-radius: 0px 0px; background-color:rgba(12, 73, 113, 0.82); color:#FFFFFF; margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p style="/*font-family: cursive; */font-size: 13px; margin-top:5px; margin-bottom:5px;" class="text-left">
                                        <b>Analyse de l'opération</b>
                                    </p>
                                </div>
                                <div class="col-xs-12 " style="border-radius: 4px 4px; background-color: rgba(212, 205, 166, 0.00); margin-left: 2%; margin-bottom:10px; margin-right: 2%; margin-top: 3%;">
                                    
                                    
                                        <span style="font-size: 10px; padding-left: 0px; margin-top:-2px; margin-bottom:-2px;">
                                            <strong>
                                                <asp:Label ID="LabelOP1" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    
                                    
                                </div>
                                <div class="col-xs-12 " style="border-radius: 0px 0px; background-color:rgba(77, 171, 226, 0.89); margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p style="/*font-family: cursive; */font-size: 13px; margin-top:5px; margin-bottom:5px;" class="text-left">
                                        <b>Note calculée de l'opération :</b>
                                        <span style="font-size: 13px; padding-left: 20px;">
                                            <strong>
                                                <asp:Label ID="NICalculee" runat="server" Text=""></asp:Label></strong>
                                        </span>
                                    </p>
                                </div>

                                <div class="col-xs-12">
                                    <div class="row operat" style="padding-top:5%;">
                                        <div class="col-xs-12">
                                            <span class="">
                                                <span id="operat-note-01" class="col-xs-1 operat-note note">D</span>
                                                <span id="operat-note-02" class="col-xs-1 operat-note note">C-</span>
                                                <span id="operat-note-03" class="col-xs-1 operat-note note">C</span>
                                                <span id="operat-note-04" class="col-xs-1 operat-note note">C+</span>
                                                <span id="operat-note-05" class="col-xs-1 operat-note note">B-</span>
                                                <span id="operat-note-06" class="col-xs-1 operat-note note">B</span>
                                                <span id="operat-note-07" class="col-xs-1 operat-note note">B+</span>
                                                <span id="operat-note-08" class="col-xs-1 operat-note note">A-</span>
                                                <span id="operat-note-09" class="col-xs-1 operat-note note">A</span>
                                                <span id="operat-note-10" class="col-xs-1 operat-note note">A+</span>
                                            </span>
                                            <span class="the-jauge">
                                                <span class="col-xs-1 jauge D"></span>
                                                <span class="col-xs-1 jauge C-m"></span>
                                                <span class="col-xs-1 jauge C"></span>
                                                <span class="col-xs-1 jauge C-p"></span>
                                                <span class="col-xs-1 jauge B-m"></span>
                                                <span class="col-xs-1 jauge B"></span>
                                                <span class="col-xs-1 jauge B-p"></span>
                                                <span class="col-xs-1 jauge A-m"></span>
                                                <span class="col-xs-1 jauge A"></span>
                                                <span class="col-xs-1 jauge A-p"></span>
                                            </span>
                                            <span class="">
                                                <span id="operat-mrk-01" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-02" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-03" class="col-xs-1 operat-marker marker"> </span>
                                                <span id="operat-mrk-04" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-05" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-06" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-07" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-08" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-09" class="col-xs-1 operat-marker marker"></span>
                                                <span id="operat-mrk-10" class="col-xs-1 operat-marker marker"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-xs-4" style="">
                                <div class="row">
                                    <div class="col-xs-10" style="border-radius: 0px 0px; background-color:rgba(12, 73, 113, 0.82); color:#FFFFFF; margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                    <p style="/*font-family: cursive; */font-size: 13px; margin-top:5px; margin-bottom:5px;" class="text-left">
                                        <b>Schémas délégataires</b>
                                    </p>
                                </div>
                                <div class="col-xs-10 " style="border-radius: 4px 4px; background-color: rgba(212, 205, 166, 0.00); margin-left: 2%; margin-bottom:10px; margin-right: 2%; margin-top: 3%;">
                                        <span style="font-size: 10px; padding-left: 0px; margin-top:-2px; margin-bottom:-2px;">
                                                <asp:Label ID="LabelCont" runat="server" Text=""></asp:Label>
                                        </span>
                                </div>
                                <div class="hidden col-sx-10 " style="border-radius: 0px 0px; background-color:rgba(77, 171, 226, 0.89); margin-left: 2%; margin-right: 2%; margin-top: 3%;">
                                  
                                </div>
                                </div>
                                  <p style="/*font-family: cursive; */ margin-top: 20px; font-size: 13px;" id="CHMPADE" runat="server" class="text-center">
                                </p>
                            </div>

                        </div>
                        <div class="hidden col-xs-5 pull-right">
                            <div class="row">
                                
                                <span style="font-size: 13px; padding-left: 20px;">
                                    <strong>
                                        <%--<input type="checkbox" runat="server" id="ADE" class="" OnCheckedChanged="ADE_ServerChange" />--%>
                                        <%--<asp:CheckBox ID="ADE" runat="server" AutoPostBack="true" OnCheckedChanged="ADE_ServerChange" />--%>
                                    </strong>
                                </span>
                            </div>
                        </div>

                    </div>
                    <div class="col-xs-12">
                        <div class="row ">
                            <%--+++++++++++++++++++++x++++ Debut detail 1 +++++++++++++++++++++++--%>








                            <%--+++++++++++++++++++++++++ debut detail 2 +++++++++++++++++++++++--%>


                            <asp:TextBox ID="VerifSaisi" runat="server" CssClass="form-control"
                                Style="display: none"></asp:TextBox>

                            <asp:TextBox ID="VerifValide" runat="server" CssClass="form-control"
                                Style="display: none"></asp:TextBox>

                            <asp:TextBox ID="VerifNoteProp" runat="server" CssClass="form-control"
                                Style="display: none"></asp:TextBox>
                            <%--++++++++++++++++++++++++++ Fin detail +++++++++++++++++++++++--%>
                        </div>



                        <%--<p style="text-align: left; padding-left: 90px; font-family: cursive; font-size: 13px;">
                                    <b>Note proposée :</b>
                                    <span style="padding-left: 20px; margin-left: 6%; margin-right: 7%; font-family: cursive; font-size: 13px">
                                        <asp:Label ID="NoteProp" runat="server" Text=""></asp:Label>
                                    </span>
                                    <asp:DropDownList ID="DdlNPropose" CssClass="TextNormal"
                                        runat="server" style="height: 20px;">
                                    </asp:DropDownList>
                                </p>
                                <div id="i1" runat="server" style="padding-left: 140px; width: 300px;">
                                    <p style="padding-bottom: 0px;">
                                        <i>Commentaire</i><br />
                                        <asp:TextBox ID="TbNPropose" runat="server" TextMode="MultiLine" CssClass="lineWidth form-control"
                                            Height="72"></asp:TextBox>
                                    </p>
                                </div>
                                <p id="i3" runat="server" style="text-align: left; padding-left: 90px; font-family: cursive; font-size: 13px;">
                                    <b>Note validée :</b>
                                    <asp:DropDownList ID="DropDownList1" CssClass="TextNormal"
                                        runat="server" Height="20">
                                    </asp:DropDownList>
                                </p>
                                <div id="i2" runat="server" style="padding-left: 140px; width: 300px;">
                                    
                                    <p style="padding-bottom: 0px;">
                                        <i>Commentaire</i><br />
                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="lineWidth form-control"
                                            Height="72"></asp:TextBox>
                                    </p>
                                </div>
                                <p style="text-align: left; padding-left: 325px; padding-top: 1%;">
                                    <asp:Button ID="ValiderVN" runat="server" CssClass="btn btn_cergicolor btn_hover" OnClick="ValiderVN_Click" Text="Valider" />
                                    <asp:Button ID="EnvoyerVN" runat="server" CssClass="btn btn_cergicolor btn_hover" OnClick="EnvoyerVN_Click" Text="Envoyer" />
                                </p>--%>
                        <div class="row">
                            <%--++++++++++++++++++++++++++tab entete+++++++++++++++++++++++--%>

                            <div class="col-xs-5 div_form pull-left" style="margin-left: 60px; background-color: rgba(208, 245, 117, 0.34);" id="NoteProposer">
                                <%--+++++++++++++++++++++++++ panneau des notes propose ++++++++++++++++++++++++++--%>
                                <p style="text-align: left; padding-top: 20px; font-family: cursive; font-size: 13px;">
                                    <b>Note proposée :</b>
                                    <b style="color: blue">
                                        <span style="padding-left: 20px; margin-left: 6%; font-family: cursive; font-size: 13px">
                                            <asp:Label ID="NoteProp" runat="server" Text=""></asp:Label>
                                        </span>
                                    </b>
                                    <asp:DropDownList ID="DdlNPropose" onchange="combo007($(this),'C')" CssClass="TextNormal"
                                        runat="server" Style="height: 20px;">
                                    </asp:DropDownList>
                                </p>
                                <div runat="server" style="padding-left: 40px; width: 200px">
                                    <p style="padding-bottom: 0px;">
                                        <i>Commentaire</i><br />
                                        <asp:TextBox ID="TbNPropose" runat="server" onchange="con007($(this),'T')" TextMode="MultiLine" CssClass="lineWidth form-control"
                                            Height="120"></asp:TextBox>
                                    </p>
                                </div>

                                <div class="col-xs-12" style="margin-bottom: 15px;">
                                    <div class="col-xs-3 pull-right">
                                        <button id="EnvoyerVN" runat="server" class="btn btn_cergicolor btn_hover" onmousedown="con007($(this),'B')" onserverclick="EnvoyerVN_Click" style="margin-right: 5px; height: 20px; padding-top: 0px; padding-bottom: 0px;">
                                            Envoyer
                                        <span class=" glyphicon glyphicon-send"></span>
                                        </button>
                                    </div>
                                </div>
                                <%--+++++++++++++++++++++++++ panneau des notes propose ++++++++++++++++++++++++++--%>
                            </div>
                            <div class="col-xs-5 div_form pull-right" style="margin-right: 60px; background-color: rgba(208, 245, 117, 0.34);" id="NoteValider">
                                <%--+++++++++++++++++++++++++ panneau des notes Valide ++++++++++++++++++++++++++--%>
                                <p runat="server" style="text-align: left; padding-left: 90px; padding-top: 20px; font-family: cursive; font-size: 13px;">
                                    <b>Note validée :</b>
                                    <b style="color: blue">
                                        <span style="padding-left: 20px; margin-left: 6%; font-family: cursive; font-size: 13px">
                                            <asp:Label ID="NoteValid" runat="server" Text=""></asp:Label>
                                        </span>
                                    </b>
                                    <asp:DropDownList ID="DdlNValidRejet" onchange="combo007($(this),'C')" CssClass="TextNormal"
                                        runat="server" Height="20">
                                    </asp:DropDownList>
                                </p>
                                <div runat="server" style="padding-left: 40px; width: 200px; background-color: none;">

                                    <p style="padding-bottom: 0px;">
                                        <i>Commentaire</i><br />
                                        <asp:TextBox ID="TbNValidRejet" onchange="con007($(this),'T')" runat="server" TextMode="MultiLine" CssClass="lineWidth form-control"
                                            Height="120"></asp:TextBox>
                                    </p>
                                </div>
                                <div class="col-xs-12" style="margin-bottom: 15px;">
                                    <div class="col-xs-3 pull-right">
                                        <button id="ValiderVN" type="button" runat="server" onmousedown="con007($(this),'B')" class="btn btn_cergicolor btn_hover" onserverclick="ValiderVN_Click"   style="margin-right: 5px; height: 20px; padding-top: 0px; padding-bottom: 0px;">
                                            Valider
                                        <span class=" glyphicon glyphicon-ok"></span>
                                        </button>
                                    </div>
                                    <div class="col-xs-3 pull-right" style="margin-right: -5px;">
                                        <button id="RejeterVN" runat="server" onserverclick="RejeterVN_ServerClick" class="btn ModProp btn_cergicolor btn_hover" style="margin-right: 5px; height: 20px; padding-top: 0px; padding-bottom: 0px;">
                                            Rejeter
                                        <span class=" glyphicon glyphicon-remove"></span>
                                        </button>
                                    </div>
                                </div>
                                <%--+++++++++++++++++++++++++ panneau des notes Valide ++++++++++++++++++++++++++--%>
                            </div>

                            <%--+++++++++++++++++++++++++fin   tab++++++++++++++++++++++++--%>
                            <div class="col-xs-12" style="margin-bottom: 15px;">
                                <p id="message" runat="server">
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12">
                        <div id="messageEtat" class="text-center" style="color: #ff0000; font-family: 'Lucida Console'; font-size: larger; font-weight: 900;"></div>
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

    </div>
    <br />
    </div>
    <input type="hidden" id="iddossierdef" runat="server" />
    <div id="Scriptos" runat="server">
    </div>


    <script>
        /*Ajout Eloi 11/01/2023*/
        var marker = $("#marker").html();
        function positionMarker(note, notation_for) {
            $("." + notation_for + "-marker").each(function () { $(this).html(""); });
            $("." + notation_for + "-note").each(function () {
                if ($(this).text() === note) {
                    var index = $(this).attr("id").split("-")[2];
                    $("#" + notation_for + "-mrk-" + index).html(marker);
                }
            });
        }
        /*----------------------------------------------------*/

       <%-- $('#<%=SelectNotation.ClientID%>').change(function () {
            if ($('#<%=SelectNotation.ClientID%>').val() == "ade") {

                $('#<%=DdlNValidRejet.ClientID%>').html("<option value=''></option><option value='A+'>A+</option><option value='A'>A</option><option value='A-'>A-</option><option value='B+'>B+</option><option value='B'>B</option><option value='B-'>B-</option><option value='C+'>C+</option><option value='C'>C</option><option value='C-'>C-</option><option value='D+'>D+</option><option value='D'>D</option><option value='D-'>D-</option>'");
                $('#<%=DdlNPropose.ClientID%>').html("<option value=''></option><option value='A+'>A+</option><option value='A'>A</option><option value='A-'>A-</option><option value='B+'>B+</option><option value='B'>B</option><option value='B-'>B-</option><option value='C+'>C+</option><option value='C'>C</option><option value='C-'>C-</option><option value='D+'>D+</option><option value='D'>D</option><option value='D-'>D-</option>'");
            } else {
                $('#<%=DdlNValidRejet.ClientID%>').html("");
                $('#<%=DdlNPropose.ClientID%>').html("");
            }
        });--%>
        function ShowPasvalideConsult() {
            $("#ShowPasvalideConsult").click();
        }

        $('#<%=TbNPropose.ClientID%>').on('keyup', function () {
            if (($(this).val() != "")) {

                $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", true);
                $('#<%=TbNValidRejet.ClientID%>').prop("disabled", true);
                $('#<%=ValiderVN.ClientID%>').prop("disabled", true);
                $('#<%=RejeterVN.ClientID%>').prop("disabled", true);
            } else {
                if ($('#<%=DdlNPropose.ClientID%>').val() === "") {
                    $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", false);
                    $('#<%=TbNValidRejet.ClientID%>').prop("disabled", false);
                    $('#<%=ValiderVN.ClientID%>').prop("disabled", false);
                    $('#<%=RejeterVN.ClientID%>').prop("disabled", false);
                }

            }

        });



        $('#<%=TbNValidRejet.ClientID%>').on('keyup', function () {
            if ($(this).val() != "") {

                $('#<%=DdlNPropose.ClientID%>').prop("disabled", true);
                $('#<%=TbNPropose.ClientID%>').prop("disabled", true);
                $('#<%=EnvoyerVN.ClientID%>').prop("disabled", true);
            } else {
                if ($('#<%=DdlNValidRejet.ClientID%>').val() === "") {
                   <%-- if ($('#<%=VerifNoteProp.ClientID%>').val() === "") {--%>
                    $('#<%=DdlNPropose.ClientID%>').prop("disabled", false);
                    $('#<%=TbNPropose.ClientID%>').prop("disabled", false);
                    $('#<%=EnvoyerVN.ClientID%>').prop("disabled", false);
                    //}
        
                }

            }

        });



        $('#<%=DdlNValidRejet.ClientID%>').change(function () {

          <%--  $('#<%=NoteValid.ClientID%>').html($(this).val());--%>
            if ($(this).val() != "") {
                $('#<%=DdlNPropose.ClientID%>').prop("disabled", true);
                $('#<%=TbNPropose.ClientID%>').prop("disabled", true);
                $('#<%=EnvoyerVN.ClientID%>').prop("disabled", true);
                <%--$('#<%=txtHideNoteEnv.ClientID%>').val($(this).val());--%>
            } else {
                <%--$('#<%=txtHideNoteEnv.ClientID%>').val("");--%>
                if ($('#<%=TbNValidRejet.ClientID%>').val() === "") {
                    <%--if ($('#<%=VerifNoteProp.ClientID%>').val() === "") {--%>
                    $('#<%=DdlNPropose.ClientID%>').prop("disabled", false);
                    $('#<%=TbNPropose.ClientID%>').prop("disabled", false);
                    $('#<%=EnvoyerVN.ClientID%>').prop("disabled", false);

                    //}
                }

            }
        });


        $('#<%=DdlNPropose.ClientID%>').change(function () {
            if ($(this).val() != "") {
                $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", true);
                $('#<%=TbNValidRejet.ClientID%>').prop("disabled", true);
                $('#<%=ValiderVN.ClientID%>').prop("disabled", true);
                $('#<%=RejeterVN.ClientID%>').prop("disabled", true);
                <%--$('#<%=txtHideNoteProp.ClientID%>').val($(this).val());--%>

            } else {
                <%--$('#<%=txtHideNoteProp.ClientID%>').val("");--%>

                if ($('#<%=TbNPropose.ClientID%>').val() === "") {
                    $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", false);
                    $('#<%=TbNValidRejet.ClientID%>').prop("disabled", false);
                    $('#<%=ValiderVN.ClientID%>').prop("disabled", false);
                    $('#<%=RejeterVN.ClientID%>').prop("disabled", false);
                }

            }
        });



        $(document).ready(function () {

            if ($('#<%=VerifValide.ClientID%>').val() != "") {

               <%-- $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", true);
                 $('#<%=TbNValidRejet.ClientID%>').prop("disabled", true);
                 $('#<%=ValiderVN.ClientID%>').prop("disabled", true);
                 $('#<%=RejeterVN.ClientID%>').prop("disabled", true);

                 $('#<%=DdlNPropose.ClientID%>').prop("disabled", true);
                 $('#<%=TbNPropose.ClientID%>').prop("disabled", true);
                 $('#<%=EnvoyerVN.ClientID%>').prop("disabled", true);--%>
            } else {
                $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", false);
                $('#<%=TbNValidRejet.ClientID%>').prop("disabled", false);
                $('#<%=ValiderVN.ClientID%>').prop("disabled", false);
                $('#<%=RejeterVN.ClientID%>').prop("disabled", false);

                $('#<%=DdlNPropose.ClientID%>').prop("disabled", false);
                $('#<%=TbNPropose.ClientID%>').prop("disabled", false);
                $('#<%=EnvoyerVN.ClientID%>').prop("disabled", false);

            }


            if ($('#<%=VerifNoteProp.ClientID%>').val() != "") {
                 <%-- $('#<%=DdlNPropose.ClientID%>').prop("disabled", true);
                  $('#<%=TbNPropose.ClientID%>').prop("disabled", true);
                  $('#<%=EnvoyerVN.ClientID%>').prop("disabled", true);--%>
            }



            if ($('#<%=VerifSaisi.ClientID%>').val().trim() == "2") {


                //if ($(':input').is(':disabled') == true) {
                    //alert();
                    $('#<%=DdlNValidRejet.ClientID%>').prop("disabled", true);
                    $('#<%=TbNValidRejet.ClientID%>').prop("disabled", true);
                    $('#<%=ValiderVN.ClientID%>').prop("disabled", true);
                    $('#<%=RejeterVN.ClientID%>').prop("disabled", true);

                    <%--$('#<%=DdlNPropose.ClientID%>').prop("disabled", true);
                    $('#<%=TbNPropose.ClientID%>').prop("disabled", true);
                    $('#<%=EnvoyerVN.ClientID%>').prop("disabled", true);--%>

                //}
                //alert("non");

            }

 

            $('.ModProp').on("click", function (e) {

                //alert();iddossierdef
                var text = "-";
                text = $('#<%=iddossierdef.ClientID%>').val();
                $.ajax({
                    type: "POST",
                    url: "ValidationNote.aspx/AccordRejet",
                    data: "{'text': '" + text + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () { },
                    success: function (response) {
                        //alert("yes");
                        degriserM();
                    },
                    failure: function (response) {
                        //alert("no");
                    }
                });

            });

        });
        var ADE = 0;
        <%--$('#<%=ADE.ClientID%>').on('change', function (e) {

            if (ADE == 0) {
                
                //degriserM();
                
            $.ajax({
                type: "POST",
                url: "ValidationNote.aspx/remplirConNADE",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () { },
                success: function (response) {
                    $('#<%=DdlNPropose.ClientID%>').append($("<option></option>"));
                    $.each(response.d, function (data, value) {

                        $('#<%=DdlNPropose.ClientID%>').append($("<option></option>").val(value.NoteId).html(value.NoteHtml));
                        $('#<%=DdlNValidRejet.ClientID%>').append($("<option></option>").val(value.NoteId).html(value.NoteHtml));
                    });
                },
                failure: function (response) {
                    alert("Impossible d'effectuer cette requête");
                },
                error: function (response) {
                    alert("Impossible d'effectuer cette requête");
                }
            });
            }
            else {
                
                $.ajax({
                    type: "POST",
                    url: "Scoringws.asmx/offAdiredexpert",
                    data: "{'text': 'no'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () { },
                    success: function (response) {
                        alert();
                        gris(); ADE = 0;
                    },
                    failure: function (response) {
                        alert("Impossible d'effectuer cette requête");
                    },
                    error: function (response) {
                        alert("Impossible d'effectuer cette requête");
                    }
                });
            }
            
        });--%>
        function degriserM() {
            $(':input').removeAttr('disabled');
            $('.bg-claire').removeClass('bg-sombre');
        }

        function gris() {
            $('#<%=DdlNPropose.ClientID%>').html('');
            $('#<%=DdlNValidRejet.ClientID%>').html('');
        }
        //ModProp

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
