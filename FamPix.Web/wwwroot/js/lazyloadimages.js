$(document).ready(init);

function init() {

    window.loadedPhotos = 0;
    window.takenPhotos = 21;

    yall({
        observeChanges: true,
        observeRootSelector: "#photos",
        mutationObserverOptions: {
            childList: true,
            subtree: false
        },
        events: {
            load: function (event) {
                if (!event.target.classList.contains("lazy") && event.target.nodeName === "IMG") {
                    event.target.parentNode.classList.remove("card-lazy-img");
                    event.target.classList.add("fadeIn");
                    window.loadedPhotos++;
                    $("#loadedPhotos").text(window.loadedPhotos);
                }
            }
        }
    });

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
            $("#takenPhotos").text(window.takenPhotos);
        });

}