"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/cetHub").build();

document.getElementById("posaljiButton").disabled = true;

connection.on("PrimiPoruku", function (korisnik, poruka) {
    var porukaKorisnik = korisnik + ":" + poruka;
    var li = document.createElement("li");
    li.className = "list-group-item";
    li.textContent = porukaKorisnik;
    document.getElementById("listaPoruka").appendChild(li);
})

connection.start().then(function () {
    document.getElementById("posaljiButton").disabled = false;
}
)

document.getElementById("posaljiButton").addEventListener("click", function (event) {
    var korisnik = document.getElementById("userInput").value;
    var poruka = document.getElementById("porukaInput").value;

    connection.invoke("PosaljiPoruku", korisnik, poruka);

    event.preventDefault();
})