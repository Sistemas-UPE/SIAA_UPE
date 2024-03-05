const tiempoTotal = 10 * 60; 

function mostrarAlerta() {
    alert("¡El tiempo ha terminado! La página debe reiniciarse.");
    setTimeout(() => {
        window.location.href = window.location.href;
    }, 2000);
}

// Función para actualizar el contador visualmente
function actualizarContador(tiempoRestante) {
    const minutos = Math.floor(tiempoRestante / 60);
    const segundos = tiempoRestante % 60;
    document.getElementById("contador").textContent = `${minutos}:${segundos.toString().padStart(2, "0")}`;
}

// Inicia el contador
function iniciarContador() {
    let tiempoRestante = tiempoTotal;
    const contador = setInterval(() => {
        tiempoRestante--;
        if (tiempoRestante <= 0) {
            clearInterval(contador); // Detiene el contador
            mostrarAlerta();
        }
        actualizarContador(tiempoRestante); // Actualiza el contador visualmente
    }, 1000); // Actualiza cada segundo
}

// Llama a la función para iniciar el contador
iniciarContador();