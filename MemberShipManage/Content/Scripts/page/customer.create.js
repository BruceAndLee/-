$(function () {
    $('#customerform').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            userNo: {
                validators: {
                    notEmpty: {
                        message: '用户名不能为空'
                    },
                    regexp: {
                        regexp: /^1[3|5|8]{1}[0-9]{9}$/,///^\d{11}$/,
                        message: '请输入11位手机号.'
                    }
                }
            },
            name: {
                validators: {
                    notEmpty: {
                        message: '姓名不能为空'
                    },
                    stringLength: {
                        min: 1,
                        max: 10,
                        message: '姓名长度必须在1到10之间'
                    }
                }
            },
            passWord: {
                validators: {
                    notEmpty: {
                        message: '密码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 10,
                        message: '密码长度必须在6到10之间'
                    },
                    different: {//不能和用户名相同
                        field: 'userNo',
                        message: '不能和用户名相同'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9\.]+$/,
                        message: '只能是数字或字母'
                    }
                }
            },
            userRePwd: {
                validators: {
                    notEmpty: {
                        message: '确认密码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 10,
                        message: '确认密码必须在6到10之间'
                    },
                    identical: {//相同
                        field: 'passWord',
                        message: '两次密码不一致'
                    },
                    regexp: {//匹配规则
                        regexp: /^[a-zA-Z0-9\.]+$/,
                        message: '只能是数字或字母'
                    }
                }
            },
            sex: {
                validators: {
                    notEmpty: {
                        message: '请选择性别'
                    }
                }
            }
        }
    }).on('success.form.bv', function (e) {//点击提交之后
        e.preventDefault();
        var $form = $(e.target);
        $.post($form.attr('action'), $form.serialize(), function (result) {
            if (result.IsSuc) {
                alert("注册成功！");
                clearform();
            }
        });
        });

    function clearform() {
        $('#userNo').val('');
        $('#userPwd').val('');
        $('#userRePwd').val('');
        $('#userSex').val('');
        $('#name').val('');
    }
});
