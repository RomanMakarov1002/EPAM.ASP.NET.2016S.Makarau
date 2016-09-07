$(document).ready(function() {
    var nav = $("#nav");
    
        if ($("#Side").val() == "white") {
            nav.removeClass("navbar-inverse");
            nav.addClass("navbar-default");
            $("#Footer").css("background-color", "whitesmoke");
            $("#Footer h2").css("color", "black");
        } else {
            nav.removeClass("navbar-default");
            nav.addClass("navbar-inverse");
            $("#Footer").css("background-color", "black");
            $("#Footer h2").css("color", "white");
            $(".header h1").css("color", "white");
            $("#btnChangeSide").on('click', function () {
                alert("LOL. There is no way out!");
        });
        }

});