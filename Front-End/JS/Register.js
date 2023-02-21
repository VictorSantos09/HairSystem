const _name = document.getElementById("inputNameRegister")
const _saloonName = document.getElementById("inputSaloonNameRegister")
const _phoneNumber = document.getElementById("inputPhoneNumberRegister")
const _email = document.getElementById("inputEmailRegister")
const _password = document.getElementById("inputPasswordRegister")
const _confirmationPassword = document.getElementById("inputConfirmationPasswordRegister")
const _cnpj = document.getElementById("inputCNPJRegister")
const _hairPrice = document.getElementById("inputHairPriceRegister")
const _beardPrice = document.getElementById("inputBeardPriceRegister")
const _mustachePrice = document.getElementById("inputMustachePriceRegister")
const _street = document.getElementById("inputStreetRegister")
const _state = document.getElementById("inputStateRegister")
const _city = document.getElementById("inputCityRegister")
const _saloonNumber = document.getElementById("inputSaloonNumberRegister")
const _complement = document.getElementById("inputSaloonComplementRegister")
const _openningTime = document.getElementById("inputOpeningTimeRegister")
const _cloosingTime = document.getElementById("inputCloosingTimeRegister")

const Register = async function () {

    const req = await fetch("https://localhost:7220/api/controller/Register",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify({ hairPrice: _hairPrice.value, beardPrice: _beardPrice.value, mustachePrice: _mustachePrice.value, streetName: _street.value, saloonNumber: _saloonNumber.value, city: _city.value, state: _state.value, complement: _complement.value, phoneNumber: _phoneNumber.value, email: _email.value, cnpj: _cnpj.value, name: _name.value, password: _password.value, saloonName: _saloonName.value })
        })

    const result = await req.json()

    if (result.success == true)
        window.location.href = "home.html"

    else
        alert(result.message)
}

document.getElementById("registerButton").addEventListener("click", () => Register())