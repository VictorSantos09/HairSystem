const _email = document.getElementById("inputEmailDelete")
const _password = document.getElementById("inputPasswordDelete")
const _userName = document.getElementById("inputNameDelete")
const _cnpj = document.getElementById("inputCnpjDelete")
const _confirmed = document.getElementById('accountCancelationConfirm')

const DeleteAccount = async function () {

    const req = await fetch("https://localhost:7220/api/controller/DeleteAccount",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify({ userName: _userName.value, email: _email.value, password: _password.value, cnpj: _cnpj.value, confirmed: _confirmed.checked })
        })

    const result = await req.json()

    if (result.successful == true)
        window.location.href = "./index.html"

    else
        alert(result.message)
}

document.getElementById("deleteAccountButton").addEventListener("click", () => DeleteAccount())