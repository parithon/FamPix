// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
//window.addEventListener("load", () => {
//    yall({
//        observeChanges: true
//    });
//    init();
//});

$(document).ready(init);

function init() {

    yall({
        observeChanges: true
    });

    window.takenPhotos = 21;

    $(window).scroll(function () {
        if ($(window).scrollTop() + $(window).height() + 500 >= $(document).height() && !window.loadingImages) {
            loadMoreImages();
        }
    });

}

function loadMoreImages() {

    window.loadingImages = true;

    fetch(`/?skip=${window.takenPhotos}&handler=LoadImages`)
        .then((response) => {
            return response.text();
        })
        .then((result) => {
            $("#photos").append(result);
            window.takenPhotos += 21;
            window.loadingImages = false;
        });

}