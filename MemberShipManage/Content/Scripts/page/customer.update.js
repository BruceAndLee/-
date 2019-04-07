$(function () {
    registerValidator();
    $('#updateModal').on('hide.bs.modal',
        function () {
            $("#customerupdate").data('bootstrapValidator').destroy();
            $('#customerupdate').data('bootstrapValidator', null);
            registerValidator();
            clearform();
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
                        notEmpty: {
                            message: '姓名不能为空'
                        },
                        stringLength: {
                            min: 1,
                            max: 10,
                            message: '姓名长度必须在1到10之间'
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {//点击提交之后
            e.preventDefault();
            var $form = $(e.target);
            $.ajax({
                url: $form.attr('action'),
                type: 'put',
                data: $form.serialize(),
                success: function (result) {
                    if (result.IsSuc) {
                        messager.showSuccess("修改成功！");
                        $('#search').click();
                        $('#updateModal').modal('hide');
                    }
                    else {
                        messager.showError(result.Msg);
                    }
                }
            });
        });
    }

    $("#parentCustomer").autocomplete({
        autoFocus: true,
        delay: 500,
        minLength: 0,
        classes: {
            "z-index": "30 !important"
        },
        source: function (request, response) {
            var queryparam = null;
            if (request.term) {
                var patrn = /^[0-9]*$/;
                if (patrn.test(request.term)) {
                    queryparam = { "userNo": request.term };
                }
                else {
                    queryparam = { "name": request.term };
                }
            }

            $.get("/Customer/CustomerList", queryparam
                , function (data) {
                    response($.map(data, function (item) { // 此处是将返回数据转换为 JSON对象
                        return {
                            label: item.UserNo + ' (' + item.Name + ')',
                            value: item.ID
                        };
                    }));
                });
        },
        select: function (event, ui) {
            $('#parentID').val(ui.item.value);
            $('#parentCustomer').val(ui.item.label);
            return false;
        },
        change: function (event, ui) {
            if (!ui.item) {
                $('#parentID').val(null);
                $('#parentCustomer').val('');
            }
        }
    });

    function clearform() {
        $('#userNo').val('');
        $('#userPwd').val('');
        $('#userRePwd').val('');
        $('#name').val('');
    }
});
