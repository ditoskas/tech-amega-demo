let instrumentPairs = [];
const subscribeButtonsContainer = document.querySelector("#dSubscribeButtons");
const subscribedPairsContainer = document.querySelector("#dSubscribedPairsContainer");

async function fetchInstrumentPairs() {
    instrumentPairs.push("EURUSD");
    //fetch('/api/instruments')
    //    .then(response => response.json())
    //    .then(data => {
    //        instrumentPairs = data;
    //        console.log(instrumentPairs);
    //    });
}

async function loadInstrumentPairs() {
    await fetchInstrumentPairs();
    //create html button for each instrument pair
    instrumentPairs.forEach(instrumentPair => {
        const button = document.createElement("button");
        button.innerText = instrumentPair;
        button.dataset.symbolToSubscribe = instrumentPair;
        button.classList.add("btn", "btn-primary", "m-1");
        button.addEventListener("click", onSuscribeClick);
        subscribeButtonsContainer.appendChild(button);
    });
}
function onSuscribeClick(e) {
    e.preventDefault();
    const symbol = e.target.dataset.symbolToSubscribe;
    subscribeQuotes(symbol);
    const button = document.createElement("button");
    button.innerText = symbol;
    button.dataset.symbolToUnsubscribe = symbol;
    button.classList.add("btn", "btn-danger", "m-1");
    button.addEventListener("click", (event) => { event.preventDefault(); onUnsubscribeClick(symbol, e.target, event.target); });
    subscribedPairsContainer.appendChild(button);

    e.target.classList.add("d-none");
}

function onUnsubscribeClick(symbol, elementToShow, elementToRemove) {
    unsubscribeQuotes(symbol);
    elementToShow.classList.remove("d-none");
    elementToRemove.remove();
}

loadInstrumentPairs();