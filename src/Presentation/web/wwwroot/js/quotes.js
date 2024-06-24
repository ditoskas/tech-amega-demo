const connectionToQuotesHub = new signalR.HubConnectionBuilder().withUrl(window.SOCKETS_URL + "/hubs/quotes").build();

// functions to send on server
function subscribeQuotes(symbol) {
    connectionToQuotesHub.send("SubscribeGroup", symbol);
}

function unsubscribeQuotes(symbol) {
    connectionToQuotesHub.send("UnsubscribeGroup", symbol);
}

// functions to receive from server
connectionToQuotesHub.on("receiveQuote", function (quote) {
    console.log("onQuoteReceived", quote);
    let obj = JSON.parse(quote);
    let widget = document.querySelector('#widget' + obj.symbol);
    if (widget) {
        let classToApply = '';
        const rateValue = widget.querySelector('.monitor-widget-body-info-rate-value');
        let oldValue = rateValue.innerHTML;
        if (oldValue !== '') {
            let numberOldValue = parseFloat(oldValue);
            if (numberOldValue < obj.mid) {
                classToApply = 'text-success';
            }
            else if (numberOldValue > obj.mid) {
                classToApply = 'text-danger';
            }
        }
        rateValue.innerHTML = obj.mid;
        rateValue.classList.remove(['text-success', 'text-danger']);
        rateValue.classList.add(classToApply);
    }
});

connectionToQuotesHub.on("subscriptionStatusChange", onSubscriptionStatusChanged)

function onSubscriptionStatusChanged(pair, hasSubscribed) {
    if (hasSubscribed) {
        document.querySelector(`button[data-symbol-to-subscribe="${pair}"]`).classList.add("d-none");
    }
    else {
        document.querySelector(`button[data-symbol-to-subscribe="${pair}"]`).classList.remove("d-none");
    }
}

// functions to handle connection
function fullfill() {
    console.log("Connection to QuotesHub established");
}

function reject(err) {
    console.error("Failed to connect on QuotesHub", err);
}
connectionToQuotesHub.start().then(fullfill).catch(reject);