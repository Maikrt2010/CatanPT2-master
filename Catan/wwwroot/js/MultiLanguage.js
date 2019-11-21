var arrLang = {
    "en": {
        'DarkMode': 'Dark Mode',
        'Generateboard': 'Generate Board',
        'Languages': 'Change Languages to Dutch',
        'Library': 'Library'
    },
    "nl": {
        'DarkMode': 'Donkere Modes',
        'Generateboard': 'Genereer Bord',
        'Languages': 'Verander Taal naar engels',
        'Library': 'Bibliotheek'
    }
};
var lang = sessionStorage.getItem('lang');

$(function () {
    if (sessionStorage.getItem('lang') == null || undefined) {
        sessionStorage.setItem('lang', 'en');
    }
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function(index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
});

// Process translation
function Changelanguage(parameters) {
    if (sessionStorage.getItem('lang') === 'en') {
        sessionStorage.setItem('lang', 'nl');
    }
    else if (sessionStorage.getItem('lang') === 'nl') {
        sessionStorage.setItem('lang',  'en');
    }
    lang = sessionStorage.getItem('lang');
    $('.lang').each(function (index, item) {
        $(this).text(arrLang[lang][$(this).attr('key')]);
    })
}
