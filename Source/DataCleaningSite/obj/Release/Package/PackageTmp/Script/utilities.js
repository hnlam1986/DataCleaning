function HtmlEncode  (value) {
    return $('<div/>').text(value).html();
};

function HtmlDecode (value) {
    return $('<div/>').html(value).text();
}

function openWindowPopup(windowName, url) {
    window.open(url, windowName);
}

function GetSelectionText(element_id) {
    var textComponent = $(element_id)[0];
    var selectedText;
    // IE version
    if (document.selection != undefined) {
        textComponent.focus();
        var sel = document.selection.createRange();
        selectedText = sel.text;
    }
        // Mozilla version
    else if (textComponent.selectionStart != undefined) {
        var startPos = textComponent.selectionStart;
        var endPos = textComponent.selectionEnd;
        selectedText = textComponent.value.substring(startPos, endPos)
    }
     return selectedText;
}

function AddIndicatorToDiv  (divId) {
    $(divId).block({ message: "<img src='/Images/loading.gif' id='test'/>" });
}

function RemoveIndicatorToDiv  (divId) {
    $(divId).unblock({ message: "<img src='/Images/loading.gif' id='test'/>" });
}

function GetCurrentTime() {
    var now = new Date();
    var hour = now.getHours();
    var minute = now.getMinutes();
    var second = now.getSeconds();
    var mili = now.getMilliseconds()
    if (hour.toString().length == 1) {
        var hour = '0' + hour;
    }
    if (minute.toString().length == 1) {
        var minute = '0' + minute;
    }
    if (second.toString().length == 1) {
        var second = '0' + second;
    }
    var dateTime = hour + ':' + minute + ':' + second + "." + mili;
    return dateTime;
}