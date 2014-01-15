

$(document).ready(function () {

 


});

function CenteringCaptcha() {

    $(".captcha-width").css("margin-width", ($(".captcha-field").width() - $(".captcha-image").width()) / 2);

}


$(".main-submit-button").click(function () {

    var _email = $(".email").val();
    var _password = $(".password").val();

    $.post("/Home/VkLogIn/", { email: _email, password: _password }, function (html) {

        $(".captcha-field").append("<img class='captcha-image' src='http://vk.com/" + html + "'/>");
        CenteringCaptcha();
        $(".captcha-field").show();
    });
});



$(".captcha-submit-button").click(function () {
    var _email = $(".email").val();
    var _password = $(".password").val();
    var _captchaKey = $(".captcha-input").val();
    var src = $(".captcha-image").attr('src');


    $.post("/Home/VkCaptchaLogIn/", { email: _email, password: _password, src: src, captchaKey: _captchaKey }, function (data) {
        
    });

});