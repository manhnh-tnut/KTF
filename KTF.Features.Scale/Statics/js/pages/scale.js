"use strict";

let history = { model: '', code: '', name: 'OK', creater: '', currentCode: '', quantity: 0, weight: 0 };
let selected = null;
let isRunning = false;
let isSensor = false;
let isReady = true;
let trigger = false;
let allowSubmit = true;
let error = false;
let running = $('#running')
let sensorOn = $('#sensor-on')
let sensorOff = $('#sensor-off')
let currentCode = $('#current-code')
let code = $('#code')
let currentQty = $('#current-qty')
let quantity = $('#quantity')
let currentWeight = $('#current-weight')
let weight = $('#weight')

let timers = { submit: null, error: null, sensor: null };
const delay = (delayInms) => {
    return new Promise(resolve => setTimeout(resolve, delayInms));
}
function gridBox_valueChanged(e) {
    var $dataGrid = $("#embedded-datagrid");
    if (e.value === null) {
        history = { model: '', code: '', name: 'OK', creater: '', currentCode: '', quantity: 0, weight: 0 };

        currentQty.val(history.quantity);
        currentWeight.val(history.weight);
        code.text("");
        quantity.text("");
        weight.text("");
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
    history.line = selected.Name;
    history.model = selected.Model;
    history.code = selected.Code;
    history.quantity = 0;
    history.weight = 0;

    currentQty.val(history.quantity);
    currentWeight.val(history.weight);
    code.text(history.code);
    quantity.text(selected.Quantity);
    weight.text(`${selected.Minimum}-${selected.Maximun}`);
}

$(() => {
    let popup = $('#popup').dxPopup({
        width: 300,
        height: 200,
        container: '.dx-viewport',
        showTitle: true,
        title: 'Warning',
        visible: false,
        dragEnabled: false,
        closeOnOutsideClick: true,
        showCloseButton: false,
        onShowing: function (e) {
            console.log("sendCommandToIO");
            sendCommandToIO("Horn", 500, 3);
        },
        position: {
            at: 'center',
            my: 'center',
        },
        toolbarItems: [{
            widget: 'dxButton',
            toolbar: 'bottom',
            location: 'after',
            options: {
                icon: 'close',
                type: 'default',
                text: 'Close',
                stylingMode: 'outlined',
                onClick() {
                    error = false;
                    popup.hide();
                },
            },
        }],
    }).dxPopup('instance');

    let connection = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl("/hubs/monitor")
        .withAutomaticReconnect()
        .build();

    function sendCommandToIO(name, delay, times = 1) {
        if (connection.state === signalR.HubConnectionState.Connected) {
            connection.invoke("SendCommandToIO", name, delay, times);
        }
    }

    function sendCommandToWeight(retry = 0) {
        if (connection.state === signalR.HubConnectionState.Connected) {
            try {
                connection.invoke("SendCommandToWeight");
            } catch (error) {
                showNotify(error.toString(), 'error', 600);
                if (++retry < 3) {
                    sendCommandToWeight(retry);
                }
                console.error(err);
            }
        }
    }

    function sendCommandToScanner(retry = 0) {
        if (connection.state === signalR.HubConnectionState.Connected) {
            try {
                connection.invoke("SendCommandToScanner");
                showNotify('Scanner ON', 'info', 600);
            } catch (error) {
                showNotify(error.toString(), 'error', 600);
                if (++retry < 3) {
                    sendCommandToScanner(retry);
                }
                console.error(err);
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
        if (!isRunning || !allowSubmit || history.model === '' || history.code === '' || history.quantity !== selected.Quantity || history.weight < selected.Minimum || history.weight > selected.Maximun) {
            console.log('cancel submit')
            console.log(!isRunning, !allowSubmit, history.model === '', history.code === '', history.quantity !== selected.Quantity, history.weight < selected.Minimum, history.weight > selected.Maximun)
            clearTimer("submit");
            return;
        }
        allowSubmit = false;
        console.info("submit");
        $.ajax({
            url: 'api/scale',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(history),
            success: function (res) {
                console.log('done')
                history.quantity = 0;
                showNotify('Success', 'success', 5000);
                sendCommandToIO("Horn", 2000);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText)
                allowSubmit = true;
                showNotify(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText, 'error', 3000);
            }
        });
    }

    currentCode.on("change", function (e) {
        let value = e.target.value
        history.currentCode = value;
        currentCode.removeClass('bg-success text-white')
        currentCode.removeClass('bg-danger text-white')
        if (history.currentCode === '' || !allowSubmit) {
            return;
        }
        setTimeout(() => {
            currentCode.val('').change();
        }, 500)
        if (history.currentCode === history.code) {
            currentCode.addClass('bg-success text-white')
            history.quantity++;
            if (history.quantity > selected.Quantity) {
                history.quantity = selected.Quantity;
            } else {
                sendCommandToIO("Horn", 500);
            }
            currentQty.val(history.quantity);
        } else {
            currentCode.addClass('bg-danger text-white')
        }
    })

    currentQty.on("change", function (e) {
        let value = e.target.value
        history.quantity = value;
    });

    function submitFunction() {
        error = false;
        console.log('run submit function')
        onSubmit();
    }

    function errorFunction() {
        if (history.quantity !== selected.Quantity) {
            currentQty.addClass('bg-danger text-white')
        }
        if (history.weight < selected.Minimum || history.weight > selected.Maximun) {
            currentWeight.addClass('bg-danger text-white')
        }
        $('div.dx-popup-content').text('Trọng lượng hoặc số lượng không khớp.');
        popup.show();
    }

    function sensorFunction() {
        isReady = true;
    }

    function sensorFunction() {
        isReady = true;
    }

    function setTimer(timer, func, time = 3000) {
        timers[timer] = setTimeout(func, time);
    }

    function clearTimer(timer) {
        clearTimeout(timers[timer]);
        timers[timer] = null;
    }

    connection.start().then(function () {
        isRunning = true;
        connection.on("GpioResponse", function (data) {
            data = JSON.parse(data);
            //scanner
            let sensor = data.find(i => i.Type === "INPUT" && i.Name === "ScannerSensor");
            if (sensor !== undefined) {
                if (sensor.Value) {
                    sensorOn.removeClass('btn-outline-success')
                    sensorOn.addClass('btn-success')
                    sensorOff.removeClass('btn-danger')
                    sensorOff.addClass('btn-outline-danger')

                    if (history.model === '' || history.code === '') {
                        return;
                    }
                    if (!isSensor && isReady) {
                        sendCommandToScanner(0);
                        //disable sensor
                        isReady = false;
                        setTimer("sensor", sensorFunction, readyTime)
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

            return;
            //weight
            sensor = data.find(i => i.Type === "INPUT" && i.Name === "WeightSensor");
            if (sensor !== undefined) {
                if (sensor.Value) {
                    isRunning = true;
                } else {
                    isRunning = false;
                }
            }

            //submit
            sensor = data.find(i => i.Type === "INPUT" && i.Name === "SubmitButton");
            if (sensor !== undefined) {
                onSubmit();
            }
        });

        connection.on("UartResponse", function (data) {
            data = JSON.parse(data);
            if (data.Name === "Scanner") {
                currentCode.val(data.Data).change();
            } else if (data.Name === "Weight") {
                data.Value = parseFloat(data.Data.split(" ").filter(item => item != '').slice(-1)[0])
                history.weight = data.Value;
                currentWeight.val(history.weight);

                if (selected === null //not select line
                    || (!error && history.quantity === 0 && history.weight < minimum) // not start
                ) {
                    trigger = false;
                    // clear error
                    if (timers["error"] != null) {
                        clearTimer("error");
                    }
                    // clear submit
                    if (timers["submit"] != null) {
                        clearTimer("submit");
                    }
                    // reset program
                    if (!allowSubmit) {
                        history.quantity = 0;
                        currentQty.val(history.quantity);
                        allowSubmit = true;
                    }
                } else if (allowSubmit // submitable
                    && history.quantity === selected.Quantity
                    && !(history.weight < selected.Minimum || history.weight > selected.Maximun)) {
                    // clear error
                    error = false;
                    if (timers["error"] != null) {
                        clearTimer("error");
                    }
                    // submit
                    if (timers["submit"] === null) {
                        setTimer("submit", submitFunction, 2000);
                        console.log('submit timmer started')
                    }
                } else if (!error && allowSubmit && history.quantity > 0 && history.weight < minimum) {
                    error = true;
                    if (timers["submit"] != null) {
                        clearTimer("submit");
                    }
                } else if (history.weight > minimum) {
                    error = false;
                    popup.hide();
                    trigger = true;
                    // clear error
                    if (timers["error"] != null) {
                        clearTimer("error");
                    }
                    if (history.weight > selected.Maximun && timers["submit"] != null) {
                        clearTimer("submit");
                    }
                    currentQty.removeClass('bg-danger text-white')
                    currentWeight.removeClass('bg-danger text-white')
                } else if (error && trigger && history.weight < minimum) { //  show error
                    if (timers["error"] === null) {
                        setTimer("error", errorFunction, 2000);
                    }
                }
            }
        });
    }).catch(function (err) {
        return console.error(err.toString());
    });
});
