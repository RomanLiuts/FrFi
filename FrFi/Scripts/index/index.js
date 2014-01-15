

$(document).ready(function () {

 


});

function CenteringCaptcha() {

    $(".captcha-width").css("margin-width", ($(".search").width() - $(".captcha-image").width()) / 2);

}


$(".main-submit-button").click(function () {

    var _email = $(".email").val();
    var _password = $(".password").val();

    $.post("/Home/VkLogIn/", { email: _email, password: _password }, function (html) {

        $(".main-content").append("<img class='captcha-image' src='http://vk.com/" + html + "'/>");
        CenteringCaptcha();


    });


});