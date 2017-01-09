$(document).ready(ready);

function ready() {
    $(".button").on("click", function () {
        $(this).css("background-color", "green");
    })

    var toAdd=QueryString.cinemaName;
    $("#cinema").append(toAdd);

    var toAdd=QueryString.movieName;
    $("#movie").append(toAdd);

    var toAdd=QueryString.date;
    $("#date").append(toAdd);

    var toAdd=QueryString.time;
    $("#time").append(toAdd);

    var toAdd=QueryString.freeSeats;
    $("#freeSeats").append(toAdd);

    $("#confirm-button").on("click", function(){
        alert("Reservation Completed!");
    })
}