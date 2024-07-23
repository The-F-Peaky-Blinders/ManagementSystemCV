console.log("Script loaded");

document.addEventListener("DOMContentLoaded", function() {
    var loginForm = document.getElementById("loginForm");
    if (loginForm) {
        loginForm.addEventListener("submit", handleLogin);
    }

    var logoutButton = document.getElementById("logoutButton");
    if (logoutButton) {
        logoutButton.addEventListener("click", handleLogout);
    }



    checkJwtToken();
    disableBackButton();
});

function handleLogin(event) {
    event.preventDefault();
    var formData = new FormData(event.target);

    fetch("/Home/Login", {
        method: "POST",
        body: formData
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('El correo electrónico o la contraseña son incorrectos.');
        }
        return response.json();
    })
    .then(data => {
        if (data.token) {
            sessionStorage.setItem("jwtToken", data.token);
            window.location.href = "/Home/Index";
        } else {
            throw new Error('El correo electrónico o la contraseña son incorrectos.');
        }
    })
    .catch(error => {
        document.getElementById("errorMessage").innerText = error.message;
        document.getElementById("errorMessage").style.display = "block";
    });
}

function handleLogout(event) {
    event.preventDefault();
    console.log("Logout button clicked");

    fetch("/Home/Logout", {
        method: "POST"
    })
    .then(() => {
        console.log("Logged out successfully");
        sessionStorage.removeItem("jwtToken");
        sessionStorage.clear();
        window.location.href = "/Auth/Login";
    })
    .catch(error => console.error('Error:', error));
}

function checkJwtToken() {
    // Obtiene el token JWT del almacenamiento de sesión
    const jwtToken = sessionStorage.getItem("jwtToken");

    // Comprueba si el token no existe y la página actual  es la página de login
    const shouldRedirect = !jwtToken && window.location.pathname == "/Home/Index";

    // Redirige al usuario a la página de inicio si es necesario
    if (shouldRedirect) {
        window.location.href = "/Auth/Login";
    }
}

function disableBackButton() {
    history.pushState(null, null, location.href);
    window.onpopstate = function () {
        history.go(1);
    };
}
