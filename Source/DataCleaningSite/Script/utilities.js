function HtmlEncode(value) {
    return $('<div/>').text(value).html();
};

function HtmlDecode(value) {
    return $('<div/>').html(value).text();
}

function openWindowPopup(windowName, url) {
    window.open(url, windowName);
}
function getTimeStamp() {
    var now = new Date();
    var full_date = ((now.getMonth() + 1) + '/' + (now.getDate()) + '/' + now.getFullYear() + " " + now.getHours() + ':'
                  + ((now.getMinutes() < 10) ? ("0" + now.getMinutes()) : (now.getMinutes())) + ':' + ((now.getSeconds() < 10) ? ("0" + now
                  .getSeconds()) : (now.getSeconds())));
    return new Date(full_date).getTime();
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function openSessionGoogleSuggest() {
    var session = getTimeStamp();
    var newUrl = "/GoogleSuggestAddress.aspx?session=" + session;
    window.open(newUrl, session, "height=400,width=400");
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

function AddIndicatorToDiv(divId) {
    $(divId).block({ message: "<img src='/Images/loading.gif' id='test'/>" });
}

function RemoveIndicatorToDiv(divId) {
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

function ShowBlindMessage(msg, control, color) {
    $(document).ready(function () {
        $(control).html("");
        $(control).append("<div id='idMessage' style='color:" + color + "'>" + msg + "</div>");
        setTimeout(function () {
            $('#idMessage').fadeOut();
        }, 3000);
    });

}

function SaveQcPercentMessage(isSucceess) {
    if (isSucceess) {
        ShowBlindMessage('Save QC percent success!', '#qcMessageContent', 'green');
    } else {
        ShowBlindMessage('Save QC percent unsuccess!', '#qcMessageContent', 'red');
    }
}

function StartQcMessage(isSucceess) {
    if (isSucceess) {
        ShowBlindMessage('Start QC percent success!', '#qcMessageContent', 'green');
    } else {
        ShowBlindMessage('Start QC percent unsuccess or don\' have more card for QC!', '#qcMessageContent', 'red');
    }
}

function ReturnCardMessage(isSucceess) {
    if (isSucceess) {
        ShowBlindMessage('Return card success!', '#ReturnMessageContent', 'green');
    } else {
        ShowBlindMessage('Return card unsuccess or don\'t have more card to return!', '#ReturnMessageContent', 'red');
    }
}

function ResetCardMessage(isSucceess) {
    if (isSucceess) {
        ShowBlindMessage('Reset card success!', '#ResetMessageContent', 'green');
    } else {
        ShowBlindMessage('Reset card unsuccess or don\'t have more card to reset!', '#ResetMessageContent', 'red');
    }
}

function Comparation(string1, string2) {
    var dmp = new diff_match_patch();
    var d = dmp.diff_main(string1, string2);
    dmp.diff_cleanupSemantic(d);
    var ds = dmp.diff_prettyHtml(d);
    $("#comparation_output").html(ds);
}

function doGetCaretPosition(oField) {

    // Initialize
    var iCaretPos = 0;

    // IE Support
    if (document.selection) {

        // Set focus on the element
        oField.focus();

        // To get cursor position, get empty selection range
        var oSel = document.selection.createRange();

        // Move selection start to 0 position
        oSel.moveStart('character', -oField.value.length);

        // The caret position is selection length
        iCaretPos = oSel.text.length;
    }

        // Firefox support
    else if (oField.selectionStart || oField.selectionStart == '0')
        iCaretPos = oField.selectionStart;

    // Return results
    return iCaretPos;
}