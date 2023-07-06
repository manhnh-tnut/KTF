"use strict";

let history = { model: '', code: '', name: '', creater: '', currentCode: '' };

let selected = {};
let isRunning = false;
let isSensor = false;
let allowSubmit = true;
let sensorOn = $('#sensor-on')
let sensorOff = $('#sensor-off')
let error = $('#error')
let handmade = $('#handmade')
let code = $('#code')
let currentCode = $('#current-code')
let totalQty = $('#total-qty')
let okQty = $('#ok-qty')
let okRate = $('#ok-rate')
let ngQty = $('#ng-qty')
let ngRate = $('#ng-rate')

function gridBox_valueChanged(e) {
    var $dataGrid = $("#embedded-datagrid");
    if (e.value === null) {
        history = { model: '', code: '', name: '', creater: '', currentCode: '' };

        code.text(history.code);
        totalQty.val(0);
        okQty.val(0);
        ngQty.val(0);
        okRate.val((0.0).toFixed(2));
        ngRate.val((0.0).toFixed(2));
    }
    if ($dataGrid.length) {
        var dataGrid = $dataGrid.dxDataGrid("instance");
        dataGrid.selectRows(e.value, false);
    }
}

function gridBox_displayExpr(item) {
    onSelected(item);
    return item && item.Name + "(" + item.Model + ")";
}

function onSelected(item) {
    selected = item;

    history.lineId = item.Id;
    history.line = item.Name;
    history.model = item.Model;
    history.code = item.Code;

    code.text(history.code);

    getCurrent();
}

function getCurrent() {
    if (history.model === '' || history.code === '') {
        return
    }
    $.ajax({
        url: 'api/stapler/current',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(history),
        success: function (res) {
            onRunning()
            totalQty.val(res.Ok + res.Ng);
            okQty.val(res.Ok);
            ngQty.val(res.Ng);
            okRate.val(res.OkRate.toFixed(2));
            ngRate.val(res.NgRate.toFixed(2));
        },
        error: function (xhr, ajaxOptions, thrownError) {
            showNotify(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText, 'error', 600);
        }
    });
}

function onRunning() {
    isRunning = true;
    code.focus();
}

$(() => {
    let connection = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl("/hubs/monitor")
        .withAutomaticReconnect()
        .build();

    function sendCommandToIO(name, delay, retry = 0) {
        if (connection.state === signalR.HubConnectionState.Connected) {
            try {
                connection.invoke("SendCommandToIO", name, delay);
            } catch (error) {
                console.error(error);
                if (++retry < 3) {
                    sendCommandToIO(name, delay, retry);
                }
            }
        }
    }

    function sendCommandToScanner(retry = 0) {
        if (connection.state === signalR.HubConnectionState.Connected) {
            try {
                connection.invoke("SendCommandToScanner");
                showNotify('Sended', 'success', 600);
            } catch (error) {
                showNotify(error.toString(), 'error', 600);
                if (++retry < 3) {
                    sendCommandToScanner(retry);
                }
                console.error(error);
            }
        }
    }

    function showNotify(message, type, time, position = 'bottom center', direction = 'up-push') {
        DevExpress.ui.notify({
            message: message,
            type: type,
            displayTime: time,
            animation: {
                show: {
                    type: 'fade', duration: 400, from: 0, to: 1,
                },
                hide: { type: 'fade', duration: 40, to: 0 },
            },
        },
        {
            position,
            direction,
        });
    }

    function onSubmit() {
        if (!isRunning || !isSensor || !allowSubmit || history.model === '' || history.code === '' || history.currentCode === '') {
            return;
        }
        allowSubmit = false;

        $.ajax({
            url: 'api/stapler',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(history),
            success: function (res) {
                allowSubmit = true;
                showNotify('Done', 'success', 600);
                totalQty.val(res.Ok + res.Ng);
                okQty.val(res.Ok);
                ngQty.val(res.Ng);
                okRate.val(res.OkRate.toFixed(2));
                ngRate.val(res.NgRate.toFixed(2));
                //sendCommandToIO("Horn", 500);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                allowSubmit = true;
                showNotify(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText, 'error', 600);
            }
        });
    }

    error.on("click", function (e) {
        if (history.model === '' || history.code === '') {
            return;
        }
        var result = DevExpress.ui.dialog.confirm("<i>Xác nhận?</i>", "Xác nhận lỗi");
        result.done(function (dialogResult) {
            if (dialogResult) {
                $.ajax({
                    url: 'api/stapler/cancel',
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(history),
                    success: function (res) {
                        showNotify('Done', 'success', 600);
                        onRunning()
                        totalQty.val(res.Ok + res.Ng);
                        okQty.val(res.Ok);
                        ngQty.val(res.Ng);
                        okRate.val(res.OkRate.toFixed(2));
                        ngRate.val(res.NgRate.toFixed(2));
                        //sendCommandToIO("Horn", 500);
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        showNotify(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText, 'error', 600);
                    }
                });
            }
        });
    })

    handmade.on("click", function (e) {
        var result = DevExpress.ui.dialog.confirm("<i>Xác nhận?</i>", "Xác nhận dập thủ công");
        result.done(function (dialogResult) {
            if (dialogResult) {
                currentCode.val(history.code).change();
            }
        });
    })

    totalQty.on('focus', function () {
        code.focus();
        code.select();
    });

    currentCode.on("change", function (e) {
        let value = e.target.value
        history.currentCode = value;
        currentCode.removeClass('bg-success text-white')
        currentCode.removeClass('bg-danger text-white')
        if (history.currentCode === '') {
            return;
        }
        setTimeout(() => {
            currentCode.val('').change();
        }, 500)
        if (history.currentCode === history.code) {
            //sendCommandToIO("Horn", 500);
            currentCode.addClass('bg-success text-white')
            history = { ...history, ...{ name: "OK" } }
        } else {
            currentCode.addClass('bg-danger text-white')
            history = { ...history, ...{ name: "NG" } }
        }
        onSubmit();
    })

    connection.start().then(function () {
        onRunning();
        connection.on("GpioResponse", function (data) {
            data = JSON.parse(data);
            let sensor = data.find(i => i.Type === "INPUT" && i.Name === "ScannerSensor");
            if (sensor !== null) {
                if (sensor.Value) {
                    sensorOn.removeClass('btn-outline-success')
                    sensorOn.addClass('btn-success')
                    sensorOff.removeClass('btn-danger')
                    sensorOff.addClass('btn-outline-danger')
                    if (history.model === '' || history.code === '') {
                        return;
                    }
                    if (!isSensor) {
                        sendCommandToScanner(0);
                    }
                    isSensor = true;
                } else {
                    isSensor = false;
                    sensorOn.removeClass('btn-success')
                    sensorOn.addClass('btn-outline-success')
                    sensorOff.removeClass('btn-outline-danger')
                    sensorOff.addClass('btn-danger')
                }
            }
        });
        connection.on("UartResponse", function (data) {
            data = JSON.parse(data);
            if (data.Name === "Scanner") {
                currentCode.val(data.Data).change();
            }
        });
    }).catch(function (err) {
        return console.error(err.toString());
    });
});
