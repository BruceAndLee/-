jQuery(document).ready(function () {
    $('#btnlogin').click(function () {
        var userNo = $('#userno').val();
        var password = $('#password').val();
        var validateCode = $('#validatecode').val();
        if (!userNo || !userNo.trim()) {
            messager.showInfo('用户名不能为空！');
            return;
        }

        if (!password || !userNo.trim()) {
            messager.showInfo('密码不能为空！');
            return;
        }

        if (!validateCode || !validateCode.trim()) {
            messager.showInfo('验证码不能为空！');
            return;
        }

        $.ajax({
            url: '/Home/LoginIn',
            type: 'POST',
            data: { UserNo: userNo, Password: password, validateCode: validateCode },
            dataType: "json",
            success: function (data) {
                console.log(data);
                if (data.IsSuc == 1) {
                    window.location.href = "/Home/Index";
                }
                else {
                    messager.showError(data.Msg);
                    refreshValidateCode();
                }
            },
            beforeSend: function () {
                $("#loginstatus").show();
                $("#btnlogin").prop('disabled', 'disabled');
            },
            complete: function () {
                $("#loginstatus").hide();
                $("#btnlogin").removeAttr("disabled");
            }
        });
    });

    $('#btncancel').click(function () {
        $('#userno').val('');
        $('#password').val('');
        $('#validatecode').val('');
    });

    $('#validatecode').keydown(function (event) {
        if (event.keyCode === 13) {
            $('#btnlogin').click();
        }
    });
});

function refreshValidateCode() {
    $("#imgcode").attr("src", "/HttpHandler/ValidateCodeCreate.ashx?param=" + new Date().toTimeString());
}