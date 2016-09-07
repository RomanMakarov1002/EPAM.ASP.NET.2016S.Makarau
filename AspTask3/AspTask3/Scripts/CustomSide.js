$(document).ready(function() {
    var $nav = $("#nav");
    var $img = $("#imgSide");
        if ($("#Side").val() == "white") {
            $nav.removeClass("navbar-inverse");
            $nav.addClass("navbar-default");
            $("#Footer").css("background-color", "whitesmoke");
            $("#Footer h2").css("color", "#222");
            $img.attr("src","/Images/Yoda.png");
        } else {
            $nav.removeClass("navbar-default");
            $nav.addClass("navbar-inverse");
            $img.attr("src","/Images/Vader.png");
            $("#Footer").css("background-color", "#222");
            $("#Footer h2").css("color", "white");
            $(".header h1").css("color", "white");
            $("#btnChangeSide").on('click', function () {
                alert("LOL. There is no way out!");
        });
        }

});