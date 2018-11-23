"use strict";

var con = new signalR.HubConnectionBuilder().withUrl("/message").build();

con.start().catch(function (err) {
    return console.error(err.toString());
});

con.on("RecieveMessage",
              function (message) {
                  document.getElementById("currentMessage").textContent = message;
              }
);

