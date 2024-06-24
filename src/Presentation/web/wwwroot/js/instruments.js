const bodyLoader = document.querySelector('#bodyLoader');
const instrumentTemplate = document.querySelector('#instrumentTemplate');
const errorMessage = document.querySelector('#errorMessage');
const instrumentsContainer = document.querySelector('#instrumentsContainer');
async function fetchInstruments()
{
    const response = await fetch(window.API_URL + '/api/instruments');
    if (response.ok) {
        const instrumentsResponse = await response.json();
        if (instrumentsResponse.isSuccess)
        {
            instrumentsResponse.data.forEach(instrument => {
                // Clone the template and replace the values
                const instrumentElement = instrumentTemplate.cloneNode(true);
                instrumentElement.querySelector('.instrument-pair').innerHTML = instrument.pair;
                instrumentElement.querySelector('.instrument-rate-value').innerHTML = "";
                instrumentElement.querySelector('.instrument-img').src = instrument.imagePath;
                instrumentElement.querySelector('.instrument-search-value').value = instrument.quotesPair;
                instrumentElement.id = "block" + instrument.quotesPair;
                instrumentElement.classList.remove('d-none');
                // Assing on click event to the get rate button
                instrumentElement.querySelector('.btn-get-rate').addEventListener('click', async function (e) {
                    e.preventDefault();
                    const getRateResponse = await fetch(window.API_URL + '/api/quotes/' + instrument.pair);
                    if (getRateResponse.ok) {
                        const rateResponse = await getRateResponse.json();
                        if (rateResponse.isSuccess) {
                            console.log(rateResponse.data);
                            instrumentElement.querySelector('.instrument-rate-value').innerHTML = rateResponse.data.lastPrice;
                            instrumentElement.querySelector('.instrument-rate').classList.remove('d-none');
                        }
                    }
                    else {
                    alert("An error has occured while getting the rate. Please try again later.");
                    }
                });
                // Add the element to the container
                instrumentsContainer.appendChild(instrumentElement);
                // Show the container and hide the loader
                errorMessage.classList.add('d-none');
                bodyLoader.classList.add('d-none');
                instrumentsContainer.classList.remove('d-none');
            });
        }
        else {
            showErrorMessage();
        }
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

let searchEventTimeout = null;
document.querySelector('#txtSeachPair').addEventListener('input', function (e) {
    e.preventDefault();
    let valueToSearch = e.target.value.trim(); 
    clearTimeout(searchEventTimeout);
    searchEventTimeout = setTimeout(function () {
        if (valueToSearch === "") {
            document.querySelectorAll('.instrument-search-value').forEach(element => {
                element.closest('.instrument-widget').classList.remove('d-none');
            });
        }
        else {
            document.querySelectorAll('.instrument-search-value').forEach(element => {
                if (element.value.toLowerCase().indexOf(valueToSearch.toLowerCase()) === -1) {
                    console.log(element);
                    console.log(element.closest('.instrument-widget'));
                    element.closest('.instrument-widget').classList.add('d-none');
                }
                else {
                    element.closest('.instrument-widget').classList.remove('d-none');
                }
            });
        }
    }, 200);
});

fetchInstruments();