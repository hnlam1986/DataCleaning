GoogleAPI = function (address) {
    this.OriginalAddress = address;
    this.HasCompleted = false;
    this.OneTimesCompleted = false;
    this.CurrentAddress = 0;
    this.CurrentItem = null;
    this.CurrentId = 0;
    this.SuggestList = new Array();
    this.Initialize();
};
GoogleAPI.prototype = {
    Initialize: function () {
        var googleAPI = this;
        googleAPI.HasCompleted = false;
        googleAPI.CurrentAddress = 0;
        googleAPI.CurrentId = 0;
        googleAPI.CurrentItem = null;
        googleAPI.OneTimesCompleted = false;
        googleAPI.SuggestList = new Array();

    },
    ChangeButtonText: function () {
        if ($("#btnButton").val() == 'Stop') {
            $("#btnButton").val('Start');
            $("#res").html("Stop running.");
            $("#Label1").html("Keyword search: 0/0");
        } else {
            $("#btnButton").val('Stop');
            $("#res").html("Waiting for new card.");
        }
    },
    GetAddressData: function () {
        var googleAPI = this;
        googleAPI.ChangeButtonText();
        googleAPI.OneTimesCompleted = true;
        if ($("#btnButton").val() == 'Stop') {
            var main = setInterval(function () {
                if (googleAPI.OneTimesCompleted == true) {
                    googleAPI.OneTimesCompleted = false;
                    $.ajax({
                        url: "ajax.aspx",
                        data: { "action": "get_address_data" }
                    }).success(function (result) {
                        if (result != undefined) {
                            googleAPI.OriginalAddress = jQuery.parseJSON(result);
                            if (googleAPI.OriginalAddress != undefined && googleAPI.OriginalAddress != null)
                                googleAPI.GeocodeAddress();
                            else {
                                $("#res").html("Waiting for new card.");
                                $("#keyword").html("...");
                                $("#Label1").html("Keyword search: 0/0");
                                googleAPI.OneTimesCompleted = true;
                            }
                        }
                    });
                }
            }, 5000);
            $("#hidInternal").val(main);
        } else {
            clearInterval(parseInt($("#hidInternal").val()));
        }
    },
    SendDataUpdate: function () {
        var googleAPI = this;
        $.ajax({
            type: "POST",
            url: "ajax.aspx",
            dataType: "json",
            data: { "action": "update_address_suggest", "data": HtmlEncode(JSON.stringify(googleAPI.SuggestList)) }
        });
    },
    GeocodeAddress: function () {
        var googleAPI = this;
        googleAPI.Initialize();
        googleAPI.HasCompleted = true;
        googleAPI.IndexAddress = 0;
        var index = 0;
        var res = "";
        var intervalId = setInterval(function () {
            if (googleAPI.HasCompleted == true) {
                googleAPI.HasCompleted = false;
                if (index < googleAPI.OriginalAddress.length) {
                    //if (index < 2) {
                    $("#Label1").html("Keyword search: " + (index + 1) + "/" + googleAPI.OriginalAddress.length);
                    googleAPI.CurrentItem = googleAPI.OriginalAddress[index];
                    googleAPI.CurrentAddress = googleAPI.OriginalAddress[index].complete_adrress_correct;
                    googleAPI.CurrentId = googleAPI.OriginalAddress[index].data_id;
                    var address = googleAPI.OriginalAddress[index].complete_adrress_correct;
                    res += googleAPI.GetSuggestAddress(address, 0, "");
                    index++;
                } else {
                    clearInterval(intervalId);
                    googleAPI.SendDataUpdate();
                    googleAPI.OneTimesCompleted = true;
                }
            }
        }, 1000);
    },

    GetSuggestAddress: function (address, loop, before) {
        if (before == undefined) {
            before = "";
        }
        var googleAPI = this;
        if (loop > 5 || address=="") {
            $("#res").html(before);
            googleAPI.SuggestList.push({
                "data_id": googleAPI.CurrentId,
                "google_suggest": before,
                "cleaning_address1": googleAPI.CurrentItem.adrress_correct1,
                "cleaning_address2": googleAPI.CurrentItem.adrress_correct2,
                "cleaning_address3": googleAPI.CurrentItem.adrress_correct3,
                "cleaning_address4": googleAPI.CurrentItem.adrress_correct4,
                "full_cleaning_address": googleAPI.CurrentItem.adrress_correct
            });
            googleAPI.HasCompleted = true;
            return res;
        }
        var searchValue = address ;
        $("#keyword").html(searchValue);
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': searchValue }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK || status === google.maps.GeocoderStatus.ZERO_RESULTS) {
                var res = before + googleAPI.BuildAdrressList(results);
                if (loop + results.length >= 5 || !address.indexOf(',')>0) {
                    loop += results.length;
                    $("#res").html(res);
                    googleAPI.SuggestList.push({ 
                        "data_id": googleAPI.CurrentId, 
                        "google_suggest": res, 
                        "cleaning_address1": googleAPI.CurrentItem.adrress_correct1,
                        "cleaning_address2": googleAPI.CurrentItem.adrress_correct2,
                        "cleaning_address3": googleAPI.CurrentItem.adrress_correct3,
                        "cleaning_address4": googleAPI.CurrentItem.adrress_correct4,
                        "full_cleaning_address": googleAPI.CurrentItem.adrress_correct
                        });
                    googleAPI.HasCompleted = true;
                    return res;
                } else {
                    loop += results.length;
                    var newAddress = googleAPI.BuildNextAddress(address);
                    setTimeout(function () {
                        googleAPI.GetSuggestAddress(newAddress, results.length, res);
                        //return res;
                    }, 500);
                }
            } else if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                var res = before;
                setTimeout(function () {
                    googleAPI.GetSuggestAddress(address, loop, res);
                    //return res;
                }, 1000);
            }
        });
    },




    BuildAdrressList: function (results) {
        var kq = "";
        var index = 1;
        if (results != undefined && results.length > 0) {
            for (i = 0; i < results.length; i++) {
                if (results[i].formatted_address != "Vietnam") {
                    kq += results[i].formatted_address + "<br/>";
                    index++;
                    if (index == 5) {
                        break;
                    }
                }
            }
        }
        return kq;
    },

    BuildNextAddress: function (address) {
        var splitAddress = address.split(',');
        var newAddress = "";
        var separate = ", ";
        for (i = 1; i < splitAddress.length; i++) {
            if (i == splitAddress.length - 1) {
                separate = "";
            }
            newAddress += splitAddress[i] + separate;
        }
        return newAddress;
    },
}