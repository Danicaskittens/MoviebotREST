$(document).ready(ready);

function ready(){
    
    var reg = "<p id='register-text'>New user? To register click <a href='registration?projID="+QueryString.projID+"'>here</a>";
    $("#register").append(reg);

    $("#the-button").on("click", function () {

        var settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://moviebot-rage.azurewebsites.net/api/Account/Register",
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "cache-control": "no-cache",
            },
            "processData": false,
            "data": '{\r\n  "Email": "'+$("#register-form").val()+'",\r\n  "Password": "'+$("#password-form").val()+'",\r\n  "ConfirmPassword": "'+$("#conf-password-form").val()+'"\r\n}'
        }

        $.ajax(settings).always(function (responce) {
            if(responce == ""){
                $("#dialog").empty();
                var toApp= '<p> Registration Completed! Click <a href="login.html?projID="'+QueryString.projID+'">here</a> to be redirected to the Login page'
                $("#dialog").append(toApp);
                $("#dialog").dialog();
            }
            else{
                $("#dialog").empty();
                var res = responce.responseText.replace(/model./g, ""); 
                var modelStateError = $.parseJSON(res);
                var errorList1 = modelStateError.ModelState.ConfirmPassword;
                var errorList2 = modelStateError.ModelState.Password;
                if(errorList1 != null){
                    for (i=0; i<errorList1.length; i++){
                        $("#dialog").append("<p>"+errorList1[i]+"</p>");
                    }
                }

                if(errorList2 != null){
                    for (i=0; i<errorList2.length; i++){
                        $("#dialog").append("<p>"+errorList2[i]+"</p>");
                    }
                }
                $("#dialog").dialog();
            }
        });
    })
}