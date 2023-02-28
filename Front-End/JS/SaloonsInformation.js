var userOne = undefined;
var userTwo = undefined;
var userThree = undefined;

function GetSaloonInformation() {
    document.getElementById("infoSaloon-1-btn").addEventListener("click", () => BuildInformationModal(userOne))
    document.getElementById("infoSaloon-2-btn").addEventListener("click", () => BuildInformationModal(userTwo))
    document.getElementById("infoSaloon-3-btn").addEventListener("click", () => BuildInformationModal(userThree))
}

const GetPreviewSaloons = async function () {
    const req = await fetch("https://localhost:7220/api/controller/ThreeSaloonsRequest",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "GET",
            body: JSON.stringify()
        })

    const result = await req.json()

    userOne = result[0]
    userTwo = result[1]
    userThree = result[2]

    BuildPreviewSaloon('infoSaloon-1-name', 'infoSaloon-1-address', 'infoSaloon-1-workingTime', userOne)
    BuildPreviewSaloon('infoSaloon-2-name', 'infoSaloon-2-address', 'infoSaloon-2-workingTime', userTwo)
    BuildPreviewSaloon('infoSaloon-3-name', 'infoSaloon-3-address', 'infoSaloon-3-workingTime', userThree)
}

function BuildPreviewSaloon(saloonNameId, saloonAddressId, SaloonWorkingTimeId, result) {
    document.getElementById(saloonNameId).innerHTML = result.saloonName
    document.getElementById(saloonAddressId).innerHTML = result.address.fullAddress
    document.getElementById(SaloonWorkingTimeId).innerHTML = result.openTime + ' - ' + result.closeTime
}

function BuildInformationModal(result) {

    document.getElementById('saloonInfoAddress').innerHTML = 'Endereço: ' + result.address.fullAddress
    document.getElementById('saloonInfoWorkingTime').innerHTML = 'Horário: ' + result.openTime + ' - ' + result.closeTime
    document.getElementById('saloonInfoHairPrice').innerHTML = 'Corte de Cabelo: ' + '$' + result.hair
    document.getElementById('saloonInfoMustachePrice').innerHTML = 'Corte de Barba: ' + '$' + result.beard
    document.getElementById('saloonInfoBeardPrice').innerHTML = 'Corte de Bigode: ' + '$' + result.mustache
    document.getElementById('infoGoogleMaps').src = result.googleMapsSource
}

// o GetPreviewSaloons deve ser chamado primeiro para poder configurar as variaveis userOne e as demais
GetPreviewSaloons()
GetSaloonInformation()