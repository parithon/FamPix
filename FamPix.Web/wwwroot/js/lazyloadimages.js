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