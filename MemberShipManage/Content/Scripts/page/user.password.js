$(function () {
    $('#updatePwdform').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            orgPassword: {
                validators: {
                    notEmpty: {
                        message: '原密码不能为空'
                    }
                }
            },
            newPassword: {
                validators: {
                    notEmpty: {
                        message: '新密码不能为空'
                    }, regexp: {
                        regexp: /^[a-zA-Z0-9\.]+$/,
                        message: '只能是数字或字母'
                    },
                    stringLength: {
                        min: 6,
                        max: 10,
                        message: '密码长度必须在6到10之间'
                    }
                }
            },
            rePassword: {
                validators: {
                    notEmpty: {
                        message: '重复密码不能为空'
                    }
                }
            }
        }
    }).on('success.form.bv', function (e) {//点击提交之后
        e.preventDefault();
        $.ajax({
            url: $form.attr('action'),
            type: 'put',
            data: {
                OrgPassword: $('#orgPassword').val(),
                NewPassword: $('#newPassword').val()
            },
            success: function (result) {
                if (result.IsSuc) {
                    alert("修改成功，请重新登录！");
                    window.location.href = 'Home/Login';
                }
                else {
                    alert(data.Msg);
                }
            }
        });
    });
});