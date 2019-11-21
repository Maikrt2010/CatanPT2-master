// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//For darkmode
document.body.style.backgroundColor = sessionStorage.getItem('bg');
document.body.style.color = sessionStorage.getItem('cc');
function darker() {
    if (sessionStorage.getItem('bg') === 'rgb(94, 178, 143)') {

        sessionStorage.setItem('bg', 'rgb(6, 23, 37)');
        sessionStorage.setItem('cc', '#777');


    }
    else if (sessionStorage.getItem('bg') == null || undefined) {
        sessionStorage.setItem('bg', 'rgb(6, 23, 37)');
        sessionStorage.setItem('cc', '#777');

    }
    else if (sessionStorage.getItem('bg') === 'rgb(6, 23, 37)') {

        sessionStorage.setItem('bg', 'rgb(94, 178, 143)');
        sessionStorage.setItem('cc', '#333');
    }

    document.body.style.backgroundColor = sessionStorage.getItem('bg');
    document.body.style.color = sessionStorage.getItem('cc');

}


