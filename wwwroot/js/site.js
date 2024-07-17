console.log("Script loaded");

document.addEventListener("DOMContentLoaded", function() {
    var loginForm = document.getElementById("loginForm");
    if (loginForm) {
        loginForm.addEventListener("submit", function(event) {
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
                    window.location.href = "/Home/Dashboard";
                } else {
                    throw new Error('El correo electrónico o la contraseña son incorrectos.');
                }
            })
            .catch(error => {
                document.getElementById("errorMessage").innerText = error.message;
                document.getElementById("errorMessage").style.display = "block";
            });
        });
    }

    var logoutButton = document.getElementById("logoutButton");
    if (logoutButton) {
        logoutButton.addEventListener("click", function(event) {
            event.preventDefault();
            console.log("Logout button clicked");

            fetch("/Home/Logout", {
                method: "POST"
            })
            .then(() => {
                console.log("Logged out successfully");
                sessionStorage.removeItem("jwtToken");
                // Clear session storage to prevent going back to dashboard
                sessionStorage.clear();
                // Redirect to login page
                window.location.href = "/Home/Index";
            })
            .catch(error => console.error('Error:', error));
        });
    }

    // Check session storage for token to guard the dashboard
    var jwtToken = sessionStorage.getItem("jwtToken");
    if (!jwtToken) {
        // No token found, redirect to login page
        window.location.href = "/Home/Index";
    }
});

// Disable back button on certain pages
history.pushState(null, null, location.href);
window.onpopstate = function () {
    history.go(1);
};
