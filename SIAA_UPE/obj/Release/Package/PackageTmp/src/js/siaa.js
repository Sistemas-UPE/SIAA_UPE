function imprimirDiv(nombreDiv) {
    var contenido = document.getElementById(nombreDiv).innerHTML;
    var contenidoOriginal = document.body.innerHTML;

    document.body.innerHTML = contenido;

    window.print();

    document.body.innerHTML = contenidoOriginal;
}
setTimeout(function () {
    var snackbar = document.getElementById("body_divToast");
    if (snackbar) {
        snackbar.style.transition = "opacity 1s ease";
        snackbar.style.opacity = "0";
        setTimeout(function () {
            snackbar.style.display = "none";
        }, 600);
    }
}, 5000);