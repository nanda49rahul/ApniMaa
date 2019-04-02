$(document).ready(function () {

    $("#signInBtn").click(function () {
        return Admin.Login($(this));
    });

    $('#loginForm input').keyup(function (event) {
        if (event.keyCode == 13) {
            return Admin.Login($("#signInBtn"));
        }
    });

    $("button#ResetPassword").on("click", function () {
        return Admin.resetpassword($(this));
    });
});

var Admin = {
    Login: function (sender) {

        $.ajaxExt({
            url: 'admin/Home/Login',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div#status-division'),
            formToValidate: $("#loginForm"),
            formToPost: $("#loginForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                window.location.href = '/admin/Home/dashboard';
            }
        });
        return false;
    },
    ForgotPassword: function (sender) {
        debugger;
        if ($('#UserName').val() != "" && $('#UserName').val() != undefined) {
            debugger;
            $.ajaxExt({
                url: siteUrls.forgotPasswordUrl,
                type: 'POST',
                cache: false,
                showErrorMessage: true,
                messageControl: $('div#status-division'),
                showThrobber: true,
                button: $(sender),
                throbberPosition: { my: "left center", at: "right center", of: $(sender) },
                data: { "UserName": $('#UserName').val() },
                success: function (results, message) {
                    $.showGritterMessage(message, MessageType.Success);
                }
            });
        }
        else
        {
            $.showGritterMessage('Please Enter Username', MessageType.Error);
        }
    },
    resetpassword: function (sender) {
        $.ajaxExt({
            url: '/Home/ResetPassword',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div#status-division'),
            formToValidate: $(sender).parents("form:first"),
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            data: $(sender).parents("form:first").serializeArray(),
            success: function (results, message, Status) {
                $.showGritterMessage(message, MessageType.Success);
                //$.ShowMessage(sender, message, Status)
                setInterval(function () { window.location.href = '/Home/Index'; }, 3000);
            }
        });
        return false;
    }
};