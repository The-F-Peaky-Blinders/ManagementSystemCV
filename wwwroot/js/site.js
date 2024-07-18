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
    //disableBackButton(); // Comentar esta línea temporalmente para ver si afecta la navegación
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
    var jwtToken = sessionStorage.getItem("jwtToken");
    console.log("checkJwtToken called. JWT Token:", jwtToken);
    console.log("Current Pathname:", window.location.pathname);

    // Ajustar la lógica de redirección según tus rutas
    if (!jwtToken && window.location.pathname !== "/Auth/Login" && window.location.pathname !== "/Auth/Register") {
        console.log("No JWT Token found, redirecting to /Auth/Login");
        window.location.href = "/Auth/Login";
    }
}

function disableBackButton() {
    history.pushState(null, null, location.href);
    window.onpopstate = function () {
        history.go(1);
    };
}
