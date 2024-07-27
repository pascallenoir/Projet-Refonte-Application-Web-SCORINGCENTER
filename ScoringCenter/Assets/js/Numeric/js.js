/**
/*    Auteur : selom.tsekpuia@cergibs.com
/*    Edit   : 13/03/2017
**/

$(document).ready(function() {
    /**
     * Initialisation des datepicker
     */
    initDatePicker();
    /**
     * Format montant
     */
    
    $('.cergiMoney').each(function () {
        $(this).number(true, 4);
    });

    /**
     * Activer la saisie numerique sur le clavier
     */
    $('.numeric').numeric();
    /**
     * Activer la saisie numerique à 10-n près
     */
    FomateNumeric();
   
    
    /**
     *  Ce bout de code permet de mettre  du html dans l'attribut title pour titleIsHtml=true (modal)
     */
    $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
        _title: function (title) {
            var $title = this.options.title || '&nbsp;';
            if (("titleIsHtml" in this.options) && this.options.titleIsHtml === true)
                title.html($title);
            else title.text($title);
        }
    }));
});

function FomateNumeric() {
    $('.cergiDecimalMoney').each(function () {
        $(this).number(true, parseInt($(this).attr("nbDecimal")));
    });

}
// affiche un message 

function afficher_message(titre, msg, classMessage, icon) {
    $('<div id="msg" ><p>' + msg + '</p></div>').dialog({
        hide: {
            effect: "explode",
            duration: 500
        },
        show: {
            effect: "inplode",
            duration: 500
        },
        title: icon + ' ' + titre,
        titleIsHtml: true,
        modal: true,
        autoOpen: false,
        draggable: true,
        resizable: false,
        zIndex: '1080',
        dialogClass: classMessage,
        buttons: {
            " OK ": function () {
                $(this).dialog('close');
            }
        }

    }).dialog('open');
}

// affiche un message de succès
function success_message(titre, msg, classMessage) {
    afficher_message(titre, msg, classMessage, '<img src="./images/icon/valider.png" style="padding-right: 10px" />');
}
// affiche un message de succès
function warning_message(titre, msg, classMessage) {
    afficher_message(titre, msg, classMessage, '<img src="./images/icon/icon-48-alert.png" style="padding-right: 10px" />');
}
// affiche un message de succès
function error_message(titre, msg, classMessage) {
    afficher_message(titre, msg, classMessage, '<img src="./images/icon/stop.png" style="padding-right: 10px" />');
    //afficher_message(titre, msg, classMessage, classIcon );
}

/**
 * Pour cocher tous les checkbox ayant la class nomClass
 * 
 * @param {string} nomClass
 * @returns {undefined}
 */
function toutDecocher(nomClass) {
    var query = document.querySelectorAll('.' + nomClass);
    var i = 0;
    for (i = 0; i < query.length; i++) {
        query[i].checked = false;
    }
    $('.' + nomClass).each(function (e) {
        $(this).parent('span').removeClass('checked');
    });
}

/**
 * Pour décocher tous les checkbox ayant la class nomClass
 * 
 * @param {string} nomClass
 * @returns {undefined}
 */
function toutCocher(nomClass) {
   // alert("hahahahahaha");
    var query = document.querySelectorAll('.' + nomClass);
    var i = 0;
    for (i = 0; i < query.length; i++) {
        query[i].checked = true;
    }

    $('.' + nomClass).each(function (e) {
        $(this).parent('span').addClass('checked');
    });
}

/**
 * Cré un string qui sera envoyé par ajax au serveur, à partir du contenu du tableau tab
 * exple [2, 7, 8] donnera : |2|7|8 
 * @param {type} tab
 * @returns {String}
 */
function prepareAjaxData(tab) {
    var rep = '';
    var max = tab.length;
    for (var i = 0; i < max; i++) {
        var delimiter = (i == 0) ? "" : "|";
        rep += delimiter + tab[i];
    }

    return rep;
}

/**
 * Retourne un tableau contenant les valeurs des checkboxs cochés ayant la class nomClass
 * 
 * @param {string} nomClass
 * @param {string} valeurAttribut : nom de l'attribut du checkbox contenant la valeur à récupérer
 * @param {boolean} isNombre : indique si la valeur à récuperer est un nombre, si oui une conversion de type a lieu
 * 
 * @returns {Array}
 */
function getCheckedId(nomClass, valeurAttribut, isNombre) {
    var tab = [], i = 0;
    $('.' + nomClass).each(function () {
        if ($(this).is(':checked')) {
            var val = $(this).attr(valeurAttribut);
            if (isNombre) {
                val = parseInt(val);
            }
            tab[i++] = val;
        }
    });

    return tab;
}
// Plage Horaire
function getCheckedDay(nomClass, valeurAttribut, isNombre) {
    var tab = [], i = 0;
    $('.' + nomClass).each(function () {
            var val = $(this).attr(valeurAttribut);
            if (isNombre) {
                val = parseInt(val);
            }
            tab[i++] = val;
    });

    return tab;
}
function getNoCheckedId(nomClass, valeurAttribut, isNombre) {
    var tab = [], i = 0;
    $('.' + nomClass).each(function () {
        if ($(this).is(':checked') === false) {
            var val = $(this).attr(valeurAttribut);
            if (isNombre) {
                val = parseInt(val);
            }

            tab[i++] = val;

        }
    });

    return tab;
}

function getCheckedTd(nomClass) {
    var tab = [], i = 0;
    var tabInd = [2, 3, 4, 5];
    $('.' + nomClass).each(function (index) {
        if ($(this).is(':checked') === true) {
            var rep = '';
            for (var k = 0; k < tabInd.length; k++) {
                  var delimiter = (k === 0) ? "" : "_";
                  rep += delimiter + $("td.tdTache" + (k + 2) + "_" + (index + 1)).html();
            }
            tab[i++] = rep;
        }
    });

    return tab;
}
function getCheckedHoraireTd(nomClass) {
    var tab = [], i = 0;
    var tabInd = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 0];
    $('.' + nomClass).each(function (index) {
       // if ($(this).is(':checked') === true) {
            var rep = '';
            for (var k = 0; k < tabInd.length; k++) {
                var delimiter = (k === 0) ? "" : "_";
                if ($("td.horaireTd" + (index + 1) + "_" + (k + 1)).html() === "#") {
                    rep += delimiter + $("td.horaireTd" + (index + 1) + "_" + (k + 1)).attr("tdValue");
                } else {
                    rep += delimiter;
                }
            }
            tab[i++] = rep;
      //  }
    });

    return tab;
}


// Mes fonctions pour ouvrir et fermer le loader
function onLoadCergiOriginal() {
    $('body').oLoader({
        backgroundColor: '#000000',
        image: '../images/refresh.gif',
        fadeInTime: 500,
        wholeWindow: true,
        fadeOutTime: 1000,
        fadeLevel: 0.5,
        hideAfter: 500
    });
}

function closeOnLoadCergiOriginal() {
    $('body').oLoader('hide');
}
/**
 * Initialisation des dates picker
 * @returns {undefined}
 */
function initDatePicker() {
    $.datepicker.regional['fr'] = {
        closeText: 'Fermer',
        prevText: 'Précédent',
        nextText: 'Suivant',
        currentText: 'Aujourd\'hui',
        monthNames: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
        monthNamesShort: ['Janv.', 'Févr.', 'Mars', 'Avril', 'Mai', 'Juin', 'Juil.', 'Août', 'Sept.', 'Oct.', 'Nov.', 'Déc.'],
        dayNames: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'],
        dayNamesShort: ['Dim.', 'Lun.', 'Mar.', 'Mer.', 'Jeu.', 'Ven.', 'Sam.'],
        dayNamesMin: ['D', 'L', 'M', 'M', 'J', 'V', 'S'],
        weekHeader: 'Sem.',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['fr']);
}
/*
 * Renseigne si une chaine de caractère est une date au format JJ/MM/AA
 */
function isDate(chaine) {
    var lengthDate = 10;
    if (chaine.length !== lengthDate) {
        error_message("Attention", "Veuillez revoir le format (JJ/MM/AA) de la date saisie et continuer !");
        return false;
    }
    var regexDate = /^[1-2][0-9]{3}-0[0-9]-[0-2][0-9]$|^[1-2][0-9]{3}-0[0-9]-3[0-1]$|^[1-2][0-9]{3}-1[0-2]-[0-2][0-9]$|^[1-2][0-9]{3}-1[0-2]-3[0-1]$/;
    return regexDate.test(chaine);
}

/**
 * Permet de faire attendre une execution pendant une durée donnée
 * 
 * @param {} seconds 
 * @returns {} 
 */
function sleep(seconds) {
    var waitUntil = new Date().getTime() + seconds * 1000;
    while (new Date().getTime() < waitUntil) true;
}