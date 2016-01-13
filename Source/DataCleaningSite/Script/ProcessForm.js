ProcessForm = function (currentStep) {
    this.HasCompleted = false;
    this.ItemTemplate = "";
    this.ListCard = null;
    this.CurrentCard = null;
    this.CurrentStep = currentStep;
    this.PreviousCard = null;
    this.IsPreviousButtonClick = false;
    this.Initialize(currentStep);
    this.BindHighlightTextBox();
    
};
ProcessForm.prototype = {
    Initialize: function (currentStep) {
        var screenWidth = screen.availWidth;
        var screenHeight = screen.availHeight * 60 / 100;
        window.resizeTo(screenWidth, screenHeight);
        var processForm = this;//onclick='processForm.SelectCard(this);'
        processForm.ItemTemplate = "<div class='card-item {2}' id='card_id_{0}'  data-card-id='{0}'>{1}</div>";
        var screenHeigth = $(window).height() - $("#mainNavigator").height();
        $("#MainContainBody").height(screenHeigth);
        processForm.CurrentCard = null;
        processForm.IsPreviousButtonClick = false;
        processForm.CurrentStep = currentStep;
        processForm.CheckResizeWindows();

        processForm.BindShortcut();

        //----prevent save when press ctrl+s
        if ($.browser.mozilla) {
            $(document).keypress(function (e) {
                if (e.ctrlKey && e.key == "s") {
                    e.preventDefault();
                    $('#btnSave').click();
                    $('#btnSave').focus();
                }
               
            });
        } else if ($.browser.chrome) {
            $(document).bind('keydown', function (e) {
                if (e.ctrlKey && (e.which == 83)) {
                    e.preventDefault();
                    $('#btnSave').click();
                    $('#btnSave').focus();
                    return false;
                }
            });
        }
        $("#btnSave").on("focus", function () { $("#txtAddress1").focus(); });
    },
    BindHighlightTextBox: function () {
        var processForm = this;
        $("#txtAddress1").focus(function () { processForm.HighlightFocus($("#txtAddress1")) });
        $("#txtAddress2").focus(function () { processForm.HighlightFocus($("#txtAddress2")) });
        $("#txtAddress3").focus(function () { processForm.HighlightFocus($("#txtAddress3")) });
        $("#txtAddress4").focus(function () { processForm.HighlightFocus($("#txtAddress4")) });

        $("#txtAddress1").select(function () { processForm.HighlightSelectedText("#txtAddress1") });
        $("#txtAddress2").select(function () { processForm.HighlightSelectedText("#txtAddress2") });
        $("#txtAddress3").select(function () { processForm.HighlightSelectedText("#txtAddress3") });
        $("#txtAddress4").select(function () { processForm.HighlightSelectedText("#txtAddress4") });
        if (processForm.CurrentStep == "qc") {
            $("#txtAddress1").blur(function () {
                var newText = $("#txtAddress1").val();
                if (processForm.CurrentCard && ((processForm.CurrentCard.verify_address1 != newText && processForm.CurrentCard.verify_address1 != null && newText.trim() != "") || (processForm.CurrentCard.verify_address1 == null && newText.trim() != ""))) {
                    $("#txtAddress1").addClass("highlight-background");
                } else {
                    $("#txtAddress1").removeClass("highlight-background");
                }
            });
            $("#txtAddress2").blur(function () {
                var newText = $("#txtAddress2").val();
                if (processForm.CurrentCard && ((processForm.CurrentCard.verify_address2 != newText && processForm.CurrentCard.verify_address2 != null && newText.trim() != "") || (processForm.CurrentCard.verify_address2 == null && newText.trim() != ""))) {
                    $("#txtAddress2").addClass("highlight-background");
                } else {
                    $("#txtAddress2").removeClass("highlight-background");
                }
            });
            $("#txtAddress3").blur(function () {
                var newText = $("#txtAddress3").val();
                if (processForm.CurrentCard && ((processForm.CurrentCard.verify_address3 != newText && processForm.CurrentCard.verify_address3 != null && newText.trim() != "") || (processForm.CurrentCard.verify_address3 == null && newText.trim() != ""))) {
                    $("#txtAddress3").addClass("highlight-background");
                } else {
                    $("#txtAddress3").removeClass("highlight-background");
                }
            });
            $("#txtAddress4").blur(function () {
                var newText = $("#txtAddress4").val();
                if (processForm.CurrentCard && ((processForm.CurrentCard.verify_address4 != newText && processForm.CurrentCard.verify_address4 != null && newText.trim() != "") || (processForm.CurrentCard.verify_address4 == null && newText.trim() != ""))) {
                    $("#txtAddress4").addClass("highlight-background");
                } else {
                    $("#txtAddress4").removeClass("highlight-background");
                }
            });
        } else if (processForm.CurrentStep == "approve") {
            $("#txtAddress1").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove1"));
                    $("#txtApprove1").addClass("highlight-background");
                    $("#txtAddress1").addClass("highlight-background");
                }
            });
            $("#txtAddress1").blur(function () {
                $("#txtApprove1").removeClass("highlight-background");
                $("#txtAddress1").removeClass("highlight-background");
            });

            $("#txtAddress2").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove2"));
                    $("#txtApprove2").addClass("highlight-background");
                    $("#txtAddress2").addClass("highlight-background");
                }
            });
            $("#txtAddress2").blur(function () {
                $("#txtApprove2").removeClass("highlight-background");
                $("#txtAddress2").removeClass("highlight-background");
            });

            $("#txtAddress3").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove3"));
                    $("#txtApprove3").addClass("highlight-background");
                    $("#txtAddress3").addClass("highlight-background");
                }
            });
            $("#txtAddress3").blur(function () {
                $("#txtApprove3").removeClass("highlight-background");
                $("#txtAddress3").removeClass("highlight-background");
            });

            $("#txtAddress4").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove4"));
                    $("#txtApprove4").addClass("highlight-background");
                    $("#txtAddress4").addClass("highlight-background");
                }
            });
            $("#txtAddress4").blur(function () {
                $("#txtApprove4").removeClass("highlight-background");
                $("#txtAddress4").removeClass("highlight-background");
            });
            //---------------------------------------------
            $("#txtApprove1").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove1"));
                    $("#txtApprove1").addClass("highlight-background");
                    $("#txtAddress1").addClass("highlight-background");
                }
            });
            $("#txtApprove1").blur(function () {
                $("#txtApprove1").removeClass("highlight-background");
                $("#txtAddress1").removeClass("highlight-background");
            });

            $("#txtApprove2").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove2"));
                    $("#txtApprove2").addClass("highlight-background");
                    $("#txtAddress2").addClass("highlight-background");
                }
            });
            $("#txtApprove2").blur(function () {
                $("#txtApprove2").removeClass("highlight-background");
                $("#txtAddress2").removeClass("highlight-background");
            });

            $("#txtApprove3").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove3"));
                    $("#txtApprove3").addClass("highlight-background");
                    $("#txtAddress3").addClass("highlight-background");
                }
            });
            $("#txtApprove3").blur(function () {
                $("#txtApprove3").removeClass("highlight-background");
                $("#txtAddress3").removeClass("highlight-background");
            });

            $("#txtApprove4").focus(function () {
                if (processForm.CurrentCard) {
                    processForm.HighlightFocus($("#txtApprove4"));
                    $("#txtApprove4").addClass("highlight-background");
                    $("#txtAddress4").addClass("highlight-background");
                }
            });
            $("#txtApprove4").blur(function () {
                $("#txtApprove4").removeClass("highlight-background");
                $("#txtAddress4").removeClass("highlight-background");
            });

            $("#txtApprove1").select(function () {
                processForm.HighlightSelectedText("#txtApprove1");
            });
            $("#txtApprove2").select(function () { processForm.HighlightSelectedText("#txtApprove2") });
            $("#txtApprove3").select(function () { processForm.HighlightSelectedText("#txtApprove3") });
            $("#txtApprove4").select(function () { processForm.HighlightSelectedText("#txtApprove4") });
        }
    },

    LoadProcessCard: function (divId) {
        var processForm = this;
        $("#btnSave").attr("disabled", "disabled");
        AddIndicatorToDiv(divId)
        var actionName = "get_process_data";
        $.ajax({
            url: "ajax.aspx",
            data: { "action": actionName, "step": processForm.CurrentStep }
        }).success(function (result) {
            if (result != undefined && result != "null") {
                var item_list = "";
                processForm.ListCard = jQuery.parseJSON(result);
                var is_odd = false;
                $(processForm.ListCard).each(function () {
                    is_odd = !is_odd;
                    var odd = is_odd ? "odd-item-card" : "";
                    var id = this.management_id;
                    var address = this.address;
                    item_list += String.format(processForm.ItemTemplate, id, address, odd);
                });
                $(divId).append($(item_list));
                processForm.SelectTopCard();
            }
            RemoveIndicatorToDiv(divId);
            if ($("#btnSave").val() == "Get More Card") {
                $("#btnSave").val("Next Card");
                $("#btnSave").removeAttr("onclick").attr("onclick", "processForm.NextCard();");

            }
            if (result == "null") {
                $("#btnSave").val("End of card");
            }

        });
        processForm.LoadWorkingStatus();
        $("#txtAddress2").focus();
    },
    LoadWorkingStatus: function()
    {
        $.ajax({
            url: "ajax.aspx",
            data: { "action": "get_working_status", "step": processForm.CurrentStep }
        }).success(function (result) {
            var res = jQuery.parseJSON(result);
            $("#working_status").html("Total card: " + res.total_card + "  | Total time: " + res.total_time + "(s)  | Speed: " + res.speed + "(s)");
        });
    },
    GetCardInfo: function (card_id) {
        var processForm = this;
        var item = null;
        $(processForm.ListCard).each(function () {
            if (this.management_id === card_id) {
                item = this;
                return item;
            }
        });
        return item;
    },
    CompileAddress: function (add1, add2, add3, add4) {
        var full = "";
        if (add1 != null && add1 != undefined && add1 != "") {
            full += add1 + ", ";
        }
        if (add2 != null && add2 != undefined && add2 != "") {
            full += add2 + ", ";
        }
        if (add3 != null && add3 != undefined && add3 != "") {
            full += add3 + ", ";
        }
        if (add4 != null && add4 != undefined && add4 != "") {
            full += add4;
        }
        return full;
    },
    FillDataToTextBox: function (card_info) {
        var processForm = this;
        var add1 = "";
        var add2 = "";
        var add3 = "";
        var add4 = "";
        var full_address = "";
        if (processForm.CurrentStep == 'verify') {
            add1 = card_info.cleaning_address1?card_info.cleaning_address1:"";
            add2 = card_info.cleaning_address2?card_info.cleaning_address2:"";
            add3 = card_info.cleaning_address3?card_info.cleaning_address3:"";
            add4 = card_info.cleaning_address4?card_info.cleaning_address4:"";
            full_address = card_info.full_cleaning_address?card_info.full_cleaning_address:"";
        } else {
            add1 = card_info.verify_address1;
            add2 = card_info.verify_address2;
            add3 = card_info.verify_address3;
            add4 = card_info.verify_address4;
            full_address = processForm.CompileAddress(add1, add2, add3, add4);
        }
        if (processForm.IsPreviousButtonClick == true) {
            processForm.IsPreviousButtonClick = false;
            if (processForm.CurrentStep == 'verify') {
                add1 = processForm.CurrentCard.verify_address1;
                add2 = processForm.CurrentCard.verify_address2;
                add3 = processForm.CurrentCard.verify_address3;
                add4 = processForm.CurrentCard.verify_address4;
            } else if (processForm.CurrentStep == 'qc') {
                add1 = processForm.CurrentCard.qc_address1;
                add2 = processForm.CurrentCard.qc_address2;
                add3 = processForm.CurrentCard.qc_address3;
                add4 = processForm.CurrentCard.qc_address4;
            }
        }
        
        $("#txtAddress1").val(add1);
        $("#txtAddress2").val(add2);
        $("#txtAddress3").val(add3);
        $("#txtAddress4").val(add4);
        if (processForm.CurrentStep == "approve") {
            $("#txtApprove1").val(card_info.qc_address1);
            $("#txtApprove2").val(card_info.qc_address2);
            $("#txtApprove3").val(card_info.qc_address3);
            $("#txtApprove4").val(card_info.qc_address4)

            if (card_info.qc_address1 == add1) {
                $("#txtAddress1").attr("disabled", "disabled");
                $("#txtApprove1").attr("disabled", "disabled");
            } else {
                $("#txtAddress1").removeAttr("disabled");
                $("#txtApprove1").removeAttr("disabled");
            }
            if (card_info.qc_address2 == add2) {
                $("#txtAddress2").attr("disabled", "disabled");
                $("#txtApprove2").attr("disabled", "disabled");
            }
            else {
                $("#txtAddress2").removeAttr("disabled");
                $("#txtApprove2").removeAttr("disabled");
            }
            if (card_info.qc_address3 == add3) {
                $("#txtAddress3").attr("disabled", "disabled");
                $("#txtApprove3").attr("disabled", "disabled");
            }
            else {
                $("#txtAddress3").removeAttr("disabled");
                $("#txtApprove3").removeAttr("disabled");
            }
            if (card_info.qc_address4 == add4) {
                $("#txtAddress4").attr("disabled", "disabled");
                $("#txtApprove4").attr("disabled", "disabled");
            } else {
                $("#txtAddress4").removeAttr("disabled");
                $("#txtApprove4").removeAttr("disabled");
            }
            var fullApproveAddress = processForm.CompileAddress(card_info.qc_address1, card_info.qc_address2, card_info.qc_address3, card_info.qc_address4);
            $("#lblFullApprove").text(fullApproveAddress);
        }
        $("#lblFullAddressValue").text(full_address);
        $("#lblOriginalFullAddress").text(card_info.address);
        $("#lblQcOriginalFullAddress").text(card_info.address);


        $(".lblCity").text(card_info.city_lms + ", " + card_info.state_desc);
        $("#googleSuggestResult").html(HtmlDecode(HtmlDecode(card_info.google_suggest)));
        $("#btnSave").removeAttr("disabled");
        $("#btnSave").attr("onclick", "processForm.NextCard();");
        if (processForm.CurrentStep == "approve") {
            Comparation(full_address, fullApproveAddress);
        }
    },
    CleanDataFill: function () {
        $("#txtAddress1").val("");
        $("#txtAddress2").val("");
        $("#txtAddress3").val("");
        $("#txtAddress4").val("");
        $("#lblFullAddressValue").text("");
        $("#lblOriginalFullAddress").text("");
        $("#lblQcOriginalFullAddress").text("");
        $("#lblFullApprove").text("");
        $("#comparation_output").html("");
        $(".lblCity").text("");
        $("#googleSuggestResult").html("");
        $("#btnSave").removeAttr("onclick");
        if (processForm.CurrentStep == "approve") {
            $("#txtApprove1").val("");
            $("#txtApprove2").val("");
            $("#txtApprove3").val("");
            $("#txtApprove4").val("")
            $("#txtAddress1").removeAttr("disabled");
            $("#txtApprove1").removeAttr("disabled");
            $("#txtAddress2").removeAttr("disabled");
            $("#txtApprove2").removeAttr("disabled");
            $("#txtAddress3").removeAttr("disabled");
            $("#txtApprove3").removeAttr("disabled");
            $("#txtAddress4").removeAttr("disabled");
            $("#txtApprove4").removeAttr("disabled");
        }
    },
    SelectTopCard: function () {
        var processForm = this;;
        var all_item = $(".card-item");
        if (all_item.length > 0) {
            var top = all_item[0];
            processForm.SelectCard(top);
        }
    },
    RederOddItem: function () {
        var all_item = $(".card-item");
        var is_odd = false;
        $(all_item).each(function () {
            is_odd = !is_odd;
            var odd = is_odd ? "odd-item-card" : "";
            $(this).removeClass("odd-item-card").addClass(odd);
        });
    },
    SelectCard: function (card) {
        var processForm = this;
        $(".select-card").removeClass("select-card");
        $(card).addClass("select-card");
        var management_id = $(card).attr("data-card-id")
        var card = processForm.GetCardInfo(parseInt(management_id));
        processForm.PreviousCard = processForm.CurrentCard;
        processForm.CurrentCard = card;
        processForm.CurrentCard.starttime = GetCurrentTime();
        processForm.FillDataToTextBox(card);
        //$("#ifGoogleEmbed").attr("src", "http://www.google.com.vn/custom?q=" + encodeURI(processForm.CurrentCard.full_cleaning_address +", "+ processForm.CurrentCard.city_lms +", "+processForm.CurrentCard.state_desc));
        var url = "http://www.bing.com/search?q=" + encodeURIComponent(processForm.CurrentCard.full_cleaning_address + ", " + processForm.CurrentCard.city_lms + ", " + processForm.CurrentCard.state_desc);
        var screenWidth = screen.availWidth;
        var screenHeight = screen.availHeight*40/100;
        var TheNewWin = window.open(url, "GoogleSearch", "height=" + screenHeight + ",width=" + screenWidth + ",scrollbars=yes");
        try{
            TheNewWin.moveTo(0, screen.availHeight - screenHeight);
        }catch(ex)
        {
        }
        $(".highlight-background").removeClass("highlight-background");
        processForm.LoadWorkingStatus();
    },
    GetPreviousCard: function () {
        var processForm = this;
        processForm.IsPreviousButtonClick = true;
        var preCard = String.format(processForm.ItemTemplate, processForm.PreviousCard.management_id, processForm.PreviousCard.address, true);
        var html = $("#divLeft").html();
        $("#divLeft").html(preCard + html);
        processForm.SelectTopCard();
        $("#btnPrevious").removeAttr("disabled").attr("disabled","disabled");
    },
    OpenGoogleSearch: function () {
        var processForm = this;
        if (processForm.CurrentCard != null && processForm.CurrentCard != undefined) {
            var wName = "GoogleSearchPopup";
            var url = "https://www.google.com/#q=" + encodeURI(processForm.CurrentCard.full_cleaning_address + ", " + processForm.CurrentCard.city_lms + ", " + processForm.CurrentCard.state_desc);
            
            openWindowPopup(wName, url);
        }
    },
    HighlightFocus: function (textbox) {
        var processForm = this;
        var text = $(textbox).val();
        var container = $("#googleSuggestResult");
        processForm.Highlight(container, text);
    },
    HighlightSelectedText: function (textbox_id) {
        var selectedText = GetSelectionText(textbox_id);
        var container = $("#googleSuggestResult");
        processForm.Highlight(container, selectedText);
    },
    Highlight: function (container, text) {
        $(container).unhighlight();
        var split = text.split(' ');
        $(split).each(function () {
            $(container).highlight(this);
        });

    },
    NextCard: function () {
        
        var processForm = this;
        processForm.PreviousCard = processForm.CurrentCard;
        if (processForm.CurrentStep == 'verify') {
            processForm.SaveVerifyCard();
        } else if (processForm.CurrentStep == 'qc') {
            processForm.SaveQCCard();
        } else if (processForm.CurrentStep == 'approve') {
            processForm.SaveApproveCard();
        }
        $("#txtAddress2").focus();
        $("#btnPrevious").removeAttr("disabled");
    },
    SaveVerifyCard: function () {
        var processForm = this;
        AddIndicatorToDiv("#MainContainBody");
        processForm.CurrentCard.verify_address1 = $("#txtAddress1").val();
        processForm.CurrentCard.verify_address2 = $("#txtAddress2").val();
        processForm.CurrentCard.verify_address3 = $("#txtAddress3").val();
        processForm.CurrentCard.verify_address4 = $("#txtAddress4").val();
        processForm.CurrentCard.endtime = GetCurrentTime();
        processForm.SaveCard(processForm.CurrentCard, "save_verify_data");

    },
    SaveQCCard: function () {
        var processForm = this;
        AddIndicatorToDiv("#MainContainBody");
        processForm.CurrentCard.qc_address1 = $("#txtAddress1").val();
        processForm.CurrentCard.qc_address2 = $("#txtAddress2").val();
        processForm.CurrentCard.qc_address3 = $("#txtAddress3").val();
        processForm.CurrentCard.qc_address4 = $("#txtAddress4").val();
        processForm.CurrentCard.endtime = GetCurrentTime();
        processForm.SaveCard(processForm.CurrentCard, "save_qc_data");
    },
    SaveApproveCard: function () {
        var processForm = this;
        AddIndicatorToDiv("#MainContainBody");
        processForm.CurrentCard.approve_address1 = $("#txtApprove1").val();
        processForm.CurrentCard.approve_address2 = $("#txtApprove2").val();
        processForm.CurrentCard.approve_address3 = $("#txtApprove3").val();
        processForm.CurrentCard.approve_address4 = $("#txtApprove4").val();
        processForm.CurrentCard.endtime = GetCurrentTime();
        processForm.SaveCard(processForm.CurrentCard, "save_approve_data");
    },
    SaveCard: function (card_info, action) {
        var processForm = this;
       
        $.ajax({
            type: "POST",
            url: "ajax.aspx",
            dataType: "json",
            data: { "action": action, "data": HtmlEncode(JSON.stringify(card_info)) }
        }).success(function (result) {
            if (result > 0) {
                $(".select-card").remove();
                processForm.RederOddItem();
                processForm.SelectTopCard();
            } else {
                $("#lblMessage").text("Can not save this card.");
            }
            RemoveIndicatorToDiv("#MainContainBody");
            processForm.CheckEndOfCard();
        });
    },
    CheckEndOfCard: function () {
        var processForm = this;
        var all_item = $(".card-item");
        if (all_item.length == 0) {
            $("#btnSave").val("Get More Card");
            processForm.CleanDataFill();
            $("#btnSave").removeAttr("onclick").attr("onclick", "processForm.LoadProcessCard($('#divLeft'));");
            //$("#ifGoogleEmbed").attr("src", "http://www.google.com.vn/custom?q=");
            processForm.LoadWorkingStatus();
        }
    }
    , CheckResizeWindows: function () {
        window.onresize = function (event) {

            var screenHeigth = $(window).height() - $("#mainNavigator").height();
            $("#MainContainBody").height(screenHeigth);
            $("#MainContainBody").layout();
        };
    },
    GetFocusTextbox: function () {
        if ($("#txtAddress1").is(':focus')) {
            return $("#txtAddress1");
        } else if ($("#txtAddress2").is(':focus')) {
            return $("#txtAddress2");
        } else if ($("#txtAddress3").is(':focus')) {
            return $("#txtAddress3");
        } else if ($("#txtAddress4").is(':focus')) {
            return $("#txtAddress4");
        } else if ($("#txtApprove1").is(':focus')) {
            return $("#txtApprove1");
        } else if ($("#txtApprove2").is(':focus')) {
            return $("#txtApprove2");
        } else if ($("#txtApprove3").is(':focus')) {
            return $("#txtApprove3");
        } else if ($("#txtApprove4").is(':focus')) {
            return $("#txtApprove4");
        }
    },
    InsertTextIntoFocusTextbox: function (text) {
        var value = $(processForm.GetFocusTextbox()).val();
        var cusorIndex = doGetCaretPosition($(processForm.GetFocusTextbox())[0]);
        var insertText = cusorIndex > 0 ? (value.substring(0, cusorIndex)).trim() + " " + text + " " + value.substring(cusorIndex).trim() : text + " " + value.substring(cusorIndex).trim();
        $(processForm.GetFocusTextbox()).val(insertText);
    },
    BindShortcut: function () {
        var processForm = this;
        if (processForm.CurrentStep == "approve") {
            shortcut.add("Ctrl+1", function () {
                if (processForm.CurrentCard && $("#txtApprove1").attr("disabled") == undefined) {
                    $("#txtApprove1").val(processForm.CurrentCard.verify_address1);
                }
            });
            shortcut.add("Ctrl+2", function () {
                if (processForm.CurrentCard && $("#txtApprove2").attr("disabled") == undefined) {
                    $("#txtApprove2").val(processForm.CurrentCard.verify_address2);
                }
            });
            shortcut.add("Ctrl+3", function () {
                if (processForm.CurrentCard && $("#txtApprove3").attr("disabled") == undefined) {
                    $("#txtApprove3").val(processForm.CurrentCard.verify_address3);
                }
            });
            shortcut.add("Ctrl+4", function () {
                if (processForm.CurrentCard && $("#txtApprove4").attr("disabled") == undefined) {
                    $("#txtApprove4").val(processForm.CurrentCard.verify_address4);
                }
            });
            //-----------------------------------------------------------------------
            shortcut.add("Alt+1", function () {
                if (processForm.CurrentCard && $("#txtApprove1").attr("disabled") == undefined) {
                    $("#txtApprove1").val(processForm.CurrentCard.qc_address1);
                }
            });
            shortcut.add("Alt+2", function () {
                if (processForm.CurrentCard && $("#txtApprove2").attr("disabled") == undefined) {
                    $("#txtApprove2").val(processForm.CurrentCard.qc_address2);
                }
            });
            shortcut.add("Alt+3", function () {
                if (processForm.CurrentCard && $("#txtApprove3").attr("disabled") == undefined) {
                    $("#txtApprove3").val(processForm.CurrentCard.qc_address3);
                }
            });
            shortcut.add("Alt+4", function () {
                if (processForm.CurrentCard && $("#txtApprove4").attr("disabled") == undefined) {
                    $("#txtApprove4").val(processForm.CurrentCard.qc_address4);
                }
            });
        }
        //----------------------------------------------------------------------------
        shortcut.add("Shift+1", function () {
            processForm.InsertTextIntoFocusTextbox("Khóm");
        });
        shortcut.add("Shift+2", function () {
            processForm.InsertTextIntoFocusTextbox("Thôn");
        });
        shortcut.add("Shift+3", function () {
            processForm.InsertTextIntoFocusTextbox("Ấp");
        });
        shortcut.add("Shift+4", function () {
            processForm.InsertTextIntoFocusTextbox("Tổ");
        });
        shortcut.add("Shift+5", function () {
            processForm.InsertTextIntoFocusTextbox("Phường");
        });
        shortcut.add("Shift+6", function () {
            processForm.InsertTextIntoFocusTextbox("Xã");
        });
        shortcut.add("Shift+7", function () {
            processForm.InsertTextIntoFocusTextbox("Thị trấn");
        });
        shortcut.add("Shift+8", function () {
            processForm.InsertTextIntoFocusTextbox("Quận");
        });
        shortcut.add("Shift+9", function () {
            processForm.InsertTextIntoFocusTextbox("Huyện");
        });
        shortcut.add("Shift+0", function () {
            processForm.InsertTextIntoFocusTextbox("Thị xã");
        });

    }

}
