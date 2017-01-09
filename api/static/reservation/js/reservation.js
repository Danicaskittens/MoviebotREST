$(document).ready(ready);

function ready() {
    $(".button").on("click", function () {
        $(this).css("background-color", "green");
    })
    var toAdd = decodeURI(QueryString.cinemaName);
    toAdd = toAdd.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); })
    $("#cinema").append(toAdd);

    var toAdd = decodeURI(QueryString.movieName);
    toAdd = toAdd.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); })
    $("#movie").append(toAdd);

    var toAdd = QueryString.date;
    var toAdd = decodeURI(QueryString.date);
    toAdd = toAdd.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); })
    $("#date").append(toAdd);

    var toAdd = decodeURI(QueryString.time);
    toAdd = toAdd.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); })
    $("#time").append(toAdd);

    var toAdd = decodeURI(QueryString.freeSeats);
    toAdd = toAdd.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); })
    $("#free-Seats").append(toAdd);

    $("#confirm-button").on("click", function(){
        alert("Reservation Completed!");
    })
}