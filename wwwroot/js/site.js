console.log("Script loaded");

document.addEventListener("DOMContentLoaded", function () {
  var loginForm = document.getElementById("loginForm");
  if (loginForm) {
    loginForm.addEventListener("submit", handleLogin);
  }

  var registerForm = document.getElementById("registerForm");
  if (registerForm) {
    registerForm.addEventListener("submit", handleRegister);
  }

  var logoutButton = document.getElementById("logoutButton");
  if (logoutButton) {
    logoutButton.addEventListener("click", handleLogout);
  }

  checkJwtToken();
  disableBackButton();
});

async function handleLogin(event) {
  event.preventDefault();
  var formData = new FormData(event.target);

  try {
    const response = await fetch("/Home/Login", {
      method: "POST",
      body: formData,
    });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(errorText || "Error en la solicitud de inicio de sesión.");
    }

    const data = await response.json();
    if (data.token) {
      sessionStorage.setItem("jwtToken", data.token);
      window.location.href = "/Home/Index";
    } else {
      throw new Error("El correo electrónico o la contraseña son incorrectos.");
    }
  } catch (error) {
    displayErrorMessage(error.message);
  }
}

async function handleRegister(event) {
  event.preventDefault();
  var formData = new FormData(event.target);

  try {
    const response = await fetch("/Auth/Register", {
      method: "POST",
      body: formData,
    });

    if (!response.ok) {
      const errorText = await response.text();
      throw new Error(errorText || "Error al registrar el usuario.");
    }

    const data = await response.json();
    if (data.success) {
      window.location.href = "/Auth/Login";
    } else {
      throw new Error(data.message || "Error al registrar el usuario.");
    }
  } catch (error) {
    displayErrorMessage(error.message);
  }
}

async function handleLogout(event) {
  event.preventDefault();
  console.log("Logout button clicked");

  try {
    await fetch("/Home/Logout", {
      method: "POST",
    });
    console.log("Logged out successfully");
    sessionStorage.removeItem("jwtToken");
    sessionStorage.clear();
    window.location.href = "/Auth/Login";
  } catch (error) {
    console.error("Error:", error);
  }
}

function checkJwtToken() {
  var jwtToken = sessionStorage.getItem("jwtToken");
  var currentPath = window.location.pathname;
  var allowedPaths = ["/Auth/Register", "/Auth/Login", "/Auth/RememberPassword"];

  if (!jwtToken && !allowedPaths.includes(currentPath)) {
    window.location.href = "/Auth/Login";
  }
}

function disableBackButton() {
  history.pushState(null, null, location.href);
  window.onpopstate = function () {
    history.go(1);
  };
}

function displayErrorMessage(message) {
  var errorMessage = document.getElementById("errorMessage");
  if (errorMessage) {
    errorMessage.innerText = message;
    errorMessage.style.display = "block";
  } else {
    console.error("Element with id 'errorMessage' not found.");
  }
}
