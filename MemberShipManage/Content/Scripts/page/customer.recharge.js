$(function () {
    registerRechargeValidator();
    $('#rechargeModal').on('hide.bs.modal',
        function () {
            $("#rechargeform").data('bootstrapValidator').destroy();
            $('#rechargeform').data('bootstrapValidator', null);
            registerRechargeValidator();

            $('#recharge_userNo').val('');
            $('#recharge_userName').val('');
            $('#amount').val('');
            $('#search').click();
        });

    function registerRechargeValidator() {
        $('#rechargeform').bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                amount: {
                    validators: {
                        notEmpty: {
                            message: '金额不能为空'
                        },
                        integer: {
                            message: '只能输入整数'
                        },
                        between: {
                            min: 1,
                            max: 1000000,
                            message: '金额必须介于1到1000000之间'
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {//点击提交之后
            e.preventDefault();
            if (window.confirm('请确认充值金额，确认充值' + $('#amount').val() + "？")) {
                var $form = $(e.target);
                $.post($form.attr('action'), $form.serialize(), function (result) {
                    if (result.IsSuc) {
                        messager.showSuccess("充值成功！");
                        $('#rechargeModal').modal('hide');
                    }
                    else {
                        messager.showError(result.Msg);
                    }
                });
            }
        });
    }
});
