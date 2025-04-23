
function handleLogin(event) {
    event.preventDefault();
    window.location.href = "home.html";
  }

  document
    .getElementById("togglePassword")
    .addEventListener("click", function () {
      const passwordInput = document.getElementById("password");
      if (passwordInput.type === "password") {
        passwordInput.type = "text";
      } else {
        passwordInput.type = "password";
      }
    });