UserManagement = function () {
    this.UserItemTemplate = "<tr>" +
                                "<td id='colSelect'>" +
                                    "<a class='select-user' onclick=''></a>" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td id='colUserName'>{0}" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td id='colDisplayName'>{1}" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td id='colRole'>{2}" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td id='colDelete'>" +
                                    "<a class='delete-user' onclick=''></a>" +
                                "</td>" +
                            "</tr>";
    this.ListOfUser = null;
    this.CurrentUser = null;
    this.Initialize();
};
UserManagement.prototype = {
    Initialize: function () {
        var userManagement = this;
        userManagement.UserItemTemplate = "<tr data-user-id='{0}'>" +
                                        "<td id='colSelect'>" +
                                            "<a class='select-user' onclick=''></a>" +
                                        "</td>" +
                                        "<td id='colUserName'>{1}</td>" +
                                        "<td id='colDisplayName'>{2}</td>" +
                                        "<td id='colRole'>{3}</td>" +
                                        "<td id='colDelete'>" +
                                            "<a class='delete-user' onclick=''></a>" +
                                        "</td>" +
                                    "</tr>";
    },
    CreateUserLineItem: function (info) {
        var userManagement = this;
        var user = String.format(userManagement.userManagement.UserItemTemplate, info.user_id, info.user_name, info.display_name, info.role);
    },
    GetRole: function () {
        return ($("#ckVerify").is(":checked") ? "1" : "0") + "|" + ($("#ckQc").is(":checked") ? "1" : "0") + "|" + ($("#ckApprove").is(":checked") ? "1" : "0") + "|" + ($("#ckSetting").is(":checked") ? "1" : "0");
    },
    BindRole: function (role) {
        var permissions = role.split("|");
        $("#ckVerify").prop('checked', permissions[0] == "1");
        $("#ckQc").prop('checked', permissions[1] == "1");
        $("#ckApprove").prop('checked', permissions[2] == "1");
        $("#ckSetting").prop('checked', permissions[3] == "1");

    },
    CheckValidateData: function (action) {
        var error_count = 0;
        var userName = $("#txtUserName").val();
        var user_password = $("#txtPassword").val();
        var user_display = $("#txtDisplayName").val();
        $("label[for=txtUserName]").addClass("non-display");
        $("label[for=txtPassword]").addClass("non-display");
        $("label[for=txtDisplayName]").addClass("non-display");
        if (userName == "") {
            $("label[for=txtUserName]").removeClass("non-display");
            error_count++;
        }
        if (action != "update") {
            if (user_password == "") {
                $("label[for=txtPassword]").removeClass("non-display");
                error_count++;
            }
        }
        if (user_display == "") {
            $("label[for=txtDisplayName]").removeClass("non-display");
            error_count++;
        }
        return error_count == 0;
    },
    CreateUser: function () {
        var userManagement = this;
        $("#dupUsernameMessage").text("");
        var action = $("#btnAdd").attr("data-action");
        if (userManagement.CheckValidateData(action)) {
            var userName = $("#txtUserName").val();
            var user_password = $("#txtPassword").val();
            var user_display = $("#txtDisplayName").val();
            var user_role = userManagement.GetRole();
            var id = 0;
            var user_status = true;
            if (action == "add") {
                var data = { user_id: 0, user_name: userName, password: user_password, display_name: user_display, role: user_role, status: true };
                $.ajax({
                    type: "POST",
                    url: "ajax.aspx",
                    dataType: "json",
                    data: { "action": "insert_user_data", "data": HtmlEncode(JSON.stringify(data)) }
                }).success(function (result) {
                    if (result == -23505) {
                        $("#dupUsernameMessage").text("The user name has already exist.");
                    } else if (result > 0) {
                        $('#dgUser').datagrid('reload');
                        userManagement.CancelUpdate();
                    }
                });
            } else {
                var row_index = userManagement.GetIndexRow();
                var data = { user_id: userManagement.CurrentUser.user_id, user_name: userName, password: user_password, display_name: user_display, role: user_role, status: true };
                $.ajax({
                    type: "POST",
                    url: "ajax.aspx",
                    dataType: "json",
                    data: { "action": "update_user_data", "data": HtmlEncode(JSON.stringify(data)) }
                }).success(function (result) {
                    if (result == -23505) {
                        $("#dupUsernameMessage").text("The user name has already exist.");
                    } else if (result > 0) {
                        $('#dgUser').datagrid('reload');
                        userManagement.CancelUpdate();
                       
                    }
                });

            }
        }
        userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
    },
    GetIndexRow: function () {
        var row_index = 0;
        userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
        $(userManagement.ListOfUser).each(function (index, item) {
            if (item.user_id == userManagement.CurrentUser.user_id) {
                row_index = index;
                return row_index;
            }
        });
        return row_index;
    },
    SelectColumn: function (val, row) {
        return '<a class="edit-function-column" data-user-id="' + row.user_id + ' " onclick="userManagement.EditUser(this)"></a>' +
            '<a class="delete-function-column" data-user-id="' + row.user_id + '" onclick="userManagement.DeleteUser(this)"></a>';
    },
    EditUser: function (button) {
        var userManagement = this;
        userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
        var userId = $(button).attr("data-user-id");
        var user = jQuery.grep(userManagement.ListOfUser, function (item) {
            return item.user_id === parseInt(userId);
        });
        if (user && user.length > 0) {
            user = user[0];
            userManagement.CurrentUser = user;
            $("#txtUserName").val(user.user_name);
            //$("#txtPassword").val(user.);
            $("#txtDisplayName").val(user.display_name);
            userManagement.BindRole(user.role);
            $("#btnAdd").val("Update User");
            $("#btnAdd").attr("data-action", "update");
            $("#btnCancel").removeClass("non-display");
        }
    },
    DeleteUser: function (button) {
        var userManagement = this;
        userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
        var userId = $(button).attr("data-user-id");
        var result = confirm("Do you want to delete this user?");
        if (result) {
            var data = { user_id: parseInt(userId), user_name: "", password: "", display_name: "", role: "", status: false };
            $.ajax({
                type: "POST",
                url: "ajax.aspx",
                dataType: "json",
                data: { "action": "update_user_data", "data": HtmlEncode(JSON.stringify(data)) }
            }).success(function (result) {
                $('#dgUser').datagrid('reload');
                userManagement.CancelUpdate();
                userManagement.ListOfUser = $("#dgUser").datagrid('getData').rows;
                //Logic to delete the item
            });

        }

    },
    CancelUpdate: function () {
        $("#txtUserName").val("");
        $("#txtPassword").val("");
        $("#txtDisplayName").val("");
        userManagement.BindRole("0|0|0|0");
        $("#btnAdd").val("Add User");
        $("#btnAdd").attr("data-action", "add");
        $("#btnCancel").addClass("non-display");
        userManagement.CurrentUser = null;
    }
}