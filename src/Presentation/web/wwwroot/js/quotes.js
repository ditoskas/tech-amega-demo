const connectionToQuotesHub = new signalR.HubConnectionBuilder().withUrl("https://localhost:44328/hubs/quotes").build();

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
});

connectionToQuotesHub.on("subscriptionStatusChange", onSubscriptionStatusChanged)

function onSubscriptionStatusChanged(pair, hasSubscribed) {
    if (hasSubscribed) {
        document.querySelector(`button[data-symbol-to-subscribe="${pair}"]`).classList.add("d-none");
    }
    else {
    
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