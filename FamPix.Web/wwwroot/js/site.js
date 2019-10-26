// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
window.addEventListener("load", (event) => {

    const config = {
        root: null,
        rootMargin: '0px',
        threshold: 0
    };

    let callback = (entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const src = entry.target.getAttribute("data-src");
                entry.target.setAttribute("src", src);
                observer.unobserve(entry.target);
            }
        });
    };

    let observer = new IntersectionObserver(callback, config);

    const imgs = document.querySelectorAll('img[data-src]');
    imgs.forEach(img => {
        observer.observe(img);
    });

}, false);