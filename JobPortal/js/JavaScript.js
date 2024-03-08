function validateName() {
    let fname = document.querySelector("#fname").value.trim();
    let fnameError = document.querySelector("#fname-error");
    let Namecheck = /^[a-zA-Z]+$/;
    if (!Namecheck.test(fname)) {
        fnameError.innerText = "invalid firstname";
        return false;
    } else {
        fnameError.innerText = "";
        return true;
    }
}
function validateLastName() {
    let lname = document.querySelector("#lname").value.trim();
    let lnameError = document.querySelector("#lname-error");
    let lnamecheck = /^[a-zA-Z]+$/;
    if (!lnamecheck.test(lname)) {
        lnameError.innerText = " invalid lastname ";
        return false;
    } else {
        lnameError.innerText = "";
        return true;
    }
}

function validateEmail() {
    let email = document.querySelector("#email").value.trim();
    let emailError = document.querySelector("#email-error");

    let EmailRegularExpression = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!EmailRegularExpression.test(email)) {
        emailError.innerText = "Invalid email";
        return false;
    } else {
        emailError.innerText = "";
        return true;
    }
}

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



function validateConfirmPassword() {
    let password = document.querySelector("#password").value.trim();
    let password2 = document.querySelector("#password2").value.trim();
    let password2Error = document.querySelector("#password2-error");

    if (password != password2) {
        password2Error.innerText = "Passwords does not macthed";
        return false;
    } else {
        password2Error.innerText = "";
        return true;
    }
}

function validateNumber() {
    let number = document.querySelector("#number").value.trim();
    let numberError = document.querySelector("#number-error");

    let Numbercheck = /^\d{10}$/;

    if (!Numbercheck.test(number)) {
        numberError.innerText = "Invalid mobile number";
        return false;
    } else {
        numberError.innerText = "";
        return true;
    }
}

function validateAddress() {
    let address = document.querySelector("#address").value.trim();
    let addressError = document.querySelector("#address-error");

    if (address.length < 3 || address.length > 50) {
        addressError.innerText = "Invalid city";
        return false;
    } else {
        addressError.innerText = "";
        return true;
    }
}

function validateState() {
    let state = document.querySelector("#state").value.trim();
    let stateError = document.querySelector("#state-error");

    if (state.length < 3 || state.length > 50) {
        stateError.innerText = "Invalid state";
        return false;
    } else {
        stateError.innerText = "";
        return true;
    }
}

function validatePincode() {
    let pincode = document.querySelector("#pincode").value.trim();
    let pincodeError = document.querySelector("#pincode-error");

    let Pincodecheck = /^\d{6}$/;

    if (!Pincodecheck.test(pincode)) {
        pincodeError.innerText = "Invalid Pincode";
        return false;
    } else {
        pincodeError.innerText = "";
        return true;
    }
}

function validateDateOfBirth() {
    let fname = document.querySelector("#dob").value.trim();
    let fnameError = document.querySelector("#dob-error");
    let Namecheck = /^[2024]+$/;
    if (!Namecheck.test(fname)) {
        dobError.innerText = "invalid Date of birth";
        return false;
    } else {
        dobError.innerText = "";
        return true;
    }
}

function registerHandler() {

    validateName();
    validateLastName();
    validateDateOfBirth()
    validateEmail();
    validatePassword();
    validateConfirmPassword();
    validateNumber();
    validateAddress();
    validatePincode();
}
