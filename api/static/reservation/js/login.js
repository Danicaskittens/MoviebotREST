$(document).ready(ready);

function ready(){
     $("#the-button").on("click", function () {
        var href= "reservation.html?cinemaName="+QueryString.cinemaName+"&movieName="+QueryString.movieName
            +"&date="+QueryString.date+"&time="+QueryString.time+"&freeSeats="+QueryString.freeSeats;
        location.href = href;
    })
}