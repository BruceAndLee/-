$(function () {
    $('#btnCalculate').click(function () {
        if (!$('#hfdCustomerId').val()
            || !$('#customerId').val()) {
            messager.showInfo('请选择用户名！');
            return;
        }

        if (!$('#balanceAmount').val()) {
            messager.showInfo('消费金额不能为空！');
            return;
        }

        var amount = parseFloat($('#balanceAmount').val()).toFixed(2);
        if (amount <= 0) {
            messager.showInfo('消费金额必须大于0！');
            return;
        }

        var detail = $('#detail').val();
        if (!detail || !detail.trim()) {
            messager.showInfo('消费明细不能为空！');
            return;
        }

        $.post('/Customer/CreateConsume', {
            CustomerID: $('#hfdCustomerId').val(),
            Amount: amount,
            Detail: detail.trim()
        }, function (data) {
            if (data) {
                if (data.IsSuc) {
                    messager.showSuccess('结算成功，消费金额：' + amount + '元');
                    clearForm();
                }
                else {
                    messager.showError(data.Msg);
                }
            }
            else {
                messager.showInfo('结算失败，请检查网络！');
            }
        });
    });

    $('#balanceAmount').blur(function () {
        if ($('#balanceAmount').val()) {
            $('#balanceAmount').val(parseFloat($('#balanceAmount').val()).toFixed(2));
        }
    });

    $("#customerId").autocomplete({
        autoFocus: true,
        delay: 500,
        minLength: 0,
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
                    response($.map(data, function (item) { //此处是将返回数据转换为 JSON对象
                        return {
                            label: item.UserNo + '(' + item.Name + ')',
                            value: item.ID,
                            display: item.Name,
                            amount: item.Amount
                        };
                    }));
                });
        },
        select: function (event, ui) {
            $('#hfdCustomerId').val(ui.item.value);
            $('#customerId').val(ui.item.label);
            $('#customerName').val(ui.item.display);
            $('#amount').val(ui.item.amount);
            return false;
        },
        change: function (event, ui) {
            if (!ui.item) {
                clearForm();
            }
        }
    });

    $("#dishinput").autocomplete({
        autoFocus: true,
        delay: 1000,
        minLength: 0,
        source: function (request, response) {
            $.get("/System/Dishes", { "name": request.term }
                , function (data) {
                    response($.map(data, function (item) { //此处是将返回数据转换为 JSON对象
                        return {
                            label: item.Name,
                            value: item.ID
                        };
                    }));
                });
        },
        select: function (event, ui) {
            if ($('#detail').val()) {
                $('#detail').val($('#detail').val() + ',' + ui.item.label);
            }
            else {
                $('#detail').val(ui.item.label);
            }
            $('#dishinput').val('');
            return false;
        },
        change: function (event, ui) {
            if (!ui.item) {
                $('#dishinput').val('');
            }
        }
    });

    $('#btnCancel').click(function () {
        clearForm();
    });

    $('#detail').dblclick(function () {
        $('#dishesModal').modal('show');
    });

    function clearForm() {
        $('#hfdCustomerId').val('');
        $('#customerId').val('');
        $('#customerName').val('');
        $('#amount').val(null);
        $('#balanceAmount').val(null);
        $('#detail').val('');
        $('#dishinput').val('');
    }
});