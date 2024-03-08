
//Email Validation
function validateEmail() {

    let emailError = document.querySelector("#email-error");

    let EmailRegularExpression = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    let email = document.querySelector("#email").value.trim();
    //if (email.value.trim() === '') {
    //    emailError.innerText = "Invalid email";
    //}

   /* else*/ if (!EmailRegularExpression.test(email)) {
        emailError.innerText = "Invalid email .it should contain '@ .'";
        return false;
    } else {
        emailError.innerText = "";
        return true;
    }
}


//Password validation
function validatePassword() {
    let password = document.querySelector("#password").value.trim();
    let passwordError = document.querySelector("#password-error");

    if (password.length < 5 || password.length > 15) {
        passwordError.innerText = "Password should be between 5-15 characters";
        return false;
    }
    else {
        passwordError.innerText = "";
        return true;
    }
}

function registerHandler() {
    validateEmail();
    validatePassword();
}




