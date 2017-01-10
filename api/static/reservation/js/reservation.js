$(document).ready(ready);

function ready() {
    let locationIDs = ["top", "mid", "bottom"];
    let locationIDs2 = ["left", "center", "right"];
    let locationButtons = [];
    for (var i = 0; i < locationIDs.length; i++) {
        let id = "";
        for (var g = 0; g < locationIDs2.length; g++) {
            id = locationIDs[i] + "-" + locationIDs2[g];
            locationButtons.push($("#" + id));
        }
    }
    
    $(".button").on("click", function () {
        for (var i = 0; i < locationButtons.length; i++) {
            locationButtons[i].removeClass("selectedLocation");
        }
        $(this).addClass("selectedLocation");
    });
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
    $("#free-seats").append(toAdd);

    $("#confirm-button").on("click", function(){
        alert("Reservation Completed!");
    })
}