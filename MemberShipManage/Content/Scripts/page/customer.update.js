$(function () {
    registerValidator();
    $('#updateModal').on('hide.bs.modal',
        function () {
            $("#customerupdate").data('bootstrapValidator').destroy();
            $('#customerupdate').data('bootstrapValidator', null);
            registerValidator();

            $('#userNo').val('');
            $('#userSex').val('');
            $('#name').val('');
        });

    function registerValidator() {
        $('#customerupdate').bootstrapValidator({
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
                sex: {
                    validators: {
                        notEmpty: {
                            message: '请选择性别'
                        }
                    }
                },
                name: {
                    validators: {
                        stringLength: {
                            min: 1,
                            max: 10,
                            message: ''
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {//点击提交之后
            e.preventDefault();
            var $form = $(e.target);
            $.post($form.attr('action'), $form.serialize(), function (result) {
                if (result.IsSuc) {
                    alert("修改成功！");
                    clearform();
                }
            });
        });
    }

    function clearform() {
        $('#userNo').val('');
        $('#userPwd').val('');
        $('#userRePwd').val('');
        $('#name').val('');
    }
});
