const bodyLoader = document.querySelector('#bodyLoader');
const instrumentTemplate = document.querySelector('#instrumentTemplate');
const errorMessage = document.querySelector('#errorMessage');

async function fetchInstruments()
{
    const response = await fetch('/api/instruments/GetAll');
    if (response.ok) {
        const instruments = await response.json();
        instruments.forEach(instrument => {
            console.log(instrument);
            //const instrumentElement = document.importNode(instrumentTemplate.content, true);
            //instrumentElement.querySelector('.instrument-name').textContent = instrument.name;
            //instrumentElement.querySelector('.instrument-description').textContent = instrument.description;
            //instrumentElement.querySelector('.instrument-price').textContent = instrument.price;
            //instrumentElement.querySelector('.instrument-img').src = instrument.image;
            //document.querySelector('#instruments').appendChild(instrumentElement);
        });
    }
    else {
        showErrorMessage();
    }
}

function showErrorMessage() {
    instrumentTemplate.classList.add('d-none');
    bodyLoader.classList.add('d-none');
    errorMessage.classList.remove('d-none');
}

fetchInstruments();