let instrumentPairs = [];
const subscribeButtonsContainer = document.querySelector("#dSubscribeButtons");
const subscribedPairsContainer = document.querySelector("#dSubscribedPairsContainer");
const subscribedTemplate = document.querySelector("#dSubscribedTemplate");


async function fetchInstrumentPairs() {
    await fetch(window.API_URL + '/api/instruments')
        .then(response => response.json())
        .then(responseData => {
            instrumentPairs = responseData.data;
            console.log(instrumentPairs);
        });
}

async function loadInstrumentPairs() {
    await fetchInstrumentPairs();
    //create html button for each instrument pair
    instrumentPairs.forEach(instrumentPair => {
        const button = document.createElement("button");
        button.innerText = instrumentPair.quotesPair;
        button.dataset.symbolToSubscribe = instrumentPair.quotesPair;
        button.classList.add("btn", "btn-primary", "m-1");
        button.addEventListener("click", onSuscribeClick);
        subscribeButtonsContainer.appendChild(button);
    });
}

function createWidget(symbol) {
    let symbolInfo = null;
    for (let i = 0; i < instrumentPairs.length; i++) {
        if (symbol === instrumentPairs[i].quotesPair) {
            symbolInfo = instrumentPairs[i];
            break;
        }
    }
    if (symbolInfo) {
        //Create and append the widget
        const subscribedItem = subscribedTemplate.cloneNode(true);
        subscribedItem.querySelector('.monitor-widget-body-img').src = symbolInfo.imagePath;
        subscribedItem.querySelector('.monitor-widget-body-info-rate-base').innerHTML = "1 " + symbolInfo.baseCurrency;
        subscribedItem.querySelector('.monitor-widget-body-info-rate-non-base').innerHTML = symbolInfo.nonBaseCurrency;
        subscribedItem.querySelector('.monitor-widget-body-info-desc').innerHTML = symbolInfo.description;
        subscribedItem.id = "widget" + symbolInfo.quotesPair;
        // Assign close button to unsubscribe and remove
        subscribedItem.querySelector('.monitor-widget-close').addEventListener('click', function (e) {
            e.preventDefault();
            unsubscribeQuotes(symbol);
            document.querySelector(`button[data-symbol-to-subscribe="${symbol}"]`).classList.remove("d-none");
            subscribedItem.remove();
        });
        // Append the widget
        subscribedPairsContainer.appendChild(subscribedItem);
        subscribedItem.classList.remove('d-none');
    }
}
function onSuscribeClick(e) {
    e.preventDefault();
    const symbol = e.target.dataset.symbolToSubscribe;
    //Send request to server
    subscribeQuotes(symbol);
    //Create widget
    createWidget(symbol);
    e.target.classList.add("d-none");
}

loadInstrumentPairs();