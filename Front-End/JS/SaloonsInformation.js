var btn = document.getElementById("infoSaloon-1-btn")
const GetSaloonInformation = async function () {

    const req = await fetch("https://localhost:7220/api/controller/ViewInformation",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify({ userId: 'FD9F9A34-7FBD-47AE-ACCE-693728610D49' })
        })

    const result = await req.json()

    btn.addEventListener("click", () => BuildInformationModal(result))
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

    BuildPreviewSaloon('infoSaloon-1-name', 'infoSaloon-1-address', 'infoSaloon-1-workingTime', result, 0)
    BuildPreviewSaloon('infoSaloon-2-name', 'infoSaloon-2-address', 'infoSaloon-2-workingTime', result, 1)
    BuildPreviewSaloon('infoSaloon-3-name', 'infoSaloon-3-address', 'infoSaloon-3-workingTime', result, 2)

}

function BuildPreviewSaloon(saloonNameId, saloonAddressId, SaloonWorkingTimeId, result, arrayIndex) {

    document.getElementById(saloonNameId).innerHTML = result[arrayIndex].saloonName
    document.getElementById(saloonAddressId).innerHTML = result[arrayIndex].address.fullAddress
    document.getElementById(SaloonWorkingTimeId).innerHTML = result[arrayIndex].openTime + ' - ' + result[arrayIndex].closeTime
}

function BuildInformationModal(result) {

    document.getElementById('saloonInfoAddress').innerHTML = 'Endereço: ' + result.address.fullAddress
    document.getElementById('saloonInfoWorkingTime').innerHTML = 'Horário: ' + result.openTime + ' - ' + result.closeTime
    document.getElementById('saloonInfoHairPrice').innerHTML = 'Corte de Cabelo: ' + '$' + result.hair
    document.getElementById('saloonInfoMustachePrice').innerHTML = 'Corte de Barba: ' + '$' + result.beard
    document.getElementById('saloonInfoBeardPrice').innerHTML = 'Corte de Bigode: ' + '$' + result.mustache
    document.getElementById('infoGoogleMaps').src = result.googleMapsSource + "&output=embed"
}

GetSaloonInformation()
GetPreviewSaloons()