const _email = document.getElementById("inputEmailLogin")
const _password = document.getElementById("inputPasswordLogin")

const Login = async function () {

    const req = await fetch("https://localhost:7220/Login/Login",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify({ email: _email.value, password: _password.value })
        })

    const result = await req.json()

    if (result.successful == true)
        window.location.href = "./home.html"

    else
        alert(result.message)
}

document.getElementById("loginButton").addEventListener("click", () => Login())