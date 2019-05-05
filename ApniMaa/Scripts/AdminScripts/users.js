$(document).ready(function () {

    $("#BtnAddUserDish").on("click", function () {
        return Users.AddDishForMother($(this));
    });

    $("#UpdateUserBtn").on("click", function () {
        return Users.UpdateUser($(this));
    });

    $("#AddDishBtn").on("click", function () {
        debugger;
        return Users.AddDish($(this));
    });

    $(document).on("click", ".deleteUser", function () {
        return Users.DeleteUser($(this));
    });

    $(document).on("click", ".DeleteDish", function () {
        return Users.DeleteDish($(this));
    });

    $("input[type=button]#btnFilterPeople").on("click", function () {
        debugger;
        return Users.SearchUsers($(this));
    });

    $("input[type=button]#btnResetSearch").on("click", function () {
        $('#Search').val('');
        $('#DDLUserType').val('');
        return Users.SearchUsers($(this));
    });

    $("select#showRecords").on("change", function () {
        return Users.ShowRecords($(this));
    });

    $('.sorting').on("click", function () {
        return Users.SortUsers($(this));
    });
});

var Users = {
    SortUsers: function (sender) {
        if ($(sender).hasClass("sorting_asc")) {
            $('.sorting').removeClass("sorting_asc");
            $('.sorting').removeClass("sorting_desc")
            $(sender).addClass("sorting_desc");
            $('#SortBy').val($(sender).attr('data-sortby'));
            $('#SortOrder').val('Desc');
            paging.startIndex = 1;
            paging.currentPage = 0;
            Paging();
        } else {
            $('.sorting').removeClass("sorting_asc");
            $('.sorting').removeClass("sorting_desc")
            $(sender).addClass("sorting_asc");
            $('#SortBy').val($(sender).attr('data-sortby'));
            $('#SortOrder').val('Asc');
            paging.startIndex = 1;
            paging.currentPage = 0;
            Paging();
        }
    },

    AddUser: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Admin/User/AddUserDetails',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $(sender).parents("form:first"),
            formToPost: $(sender).parents("form:first"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = baseUrl + '/Admin/User/ManageUsers';
                }, 1500);

            }
        });
     
    },

    AddDish: function (sender) {
        GetUpdatedDishList();
        $.ajaxExt({
            url: baseUrl + '/Dish/AddDish',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#AddDishForm"),
            formToPost: $("#AddDishForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                $('#AddDishForm #CategoryId').val('');
                $('#AddDishForm #Name').val('');
                $('#AddDishForm #Description').val('');

                //setTimeout(function () {
                //    window.location.href = '/Admin/Dish/ManageDish';
                //}, 1500);

            }
        });

    },

    UpdateUser: function (sender) {
       
        $.ajaxExt({
            url: baseUrl + '/Admin/User/UpdateUserDetails',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#UpdateDishForm"),
            formToPost: $("#UpdateDishForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = '/Admin/User/ManageUsers';
                }, 1500);
            }
        });
    
    },

    AddDishForMother: function (sender) {
        //$.ShowMessage($('div.messageAlert'), 'abc', MessageType.Success);

        //return false;
        $('#AddDishForMotherForm #MotherID').val($('#UpdateDishForm #UserID').val());
        $.ajaxExt({
            url: baseUrl + '/Admin/User/AddDishForMother',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $('#AddDishForMotherForm'),
            formToPost: $('#AddDishForMotherForm'),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                GetDishAddedByAdmin($('#AddDishForMotherForm #MotherID').val());
                $('#DishId').val('');
                $('#DishImage').val('');
            }
        });
    },

    DeleteUser: function (sender) {
        $.ConfirmBox("", "Are you sure to delete this record?", null, true, "Yes", true, null, function () {
            $.ajaxExt({
                url: baseUrl + '/Admin/User/DeleteUser',
                type: 'POST',
                validate: false,
                showErrorMessage: true,
                messageControl: $('div.messageAlert'),
                showThrobber: true,
                button: $(sender),
                throbberPosition: { my: "left center", at: "right center", of: $(sender) },
                data: { userId: $(sender).attr("data-userid") },
                success: function (results, message) {
                    $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                    Paging();
                }
            });
        });
    },

    DeleteDish: function (sender) {
        $.ConfirmBox("", "Are you sure to delete this record?", null, true, "Yes", true, null, function () {
            $.ajaxExt({
                url: baseUrl + '/Admin/User/DeleteDish',
                type: 'POST',
                validate: false,
                showErrorMessage: true,
                messageControl: $('div.messageAlert'),
                showThrobber: true,
                button: $(sender),
                throbberPosition: { my: "left center", at: "right center", of: $(sender) },
                data: { dishid: $(sender).attr("data-dishid") },
                success: function (results, message) {
                    $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                    GetDishAddedByAdmin($('#UpdateDishForm #UserID').val());
                }
            });
        });
    },

    ManageUsers: function (totalCount) {
        var totalRecords = 0;
        totalRecords = parseInt(totalCount);
    //    alert(totalRecords);
        PageNumbering(totalRecords);
    },

    SearchUsers: function (sender) {
        paging.startIndex = 1;
        Paging(sender);

    },

    ShowRecords: function (sender) {

        paging.startIndex = 1;
        paging.pageSize = parseInt($(sender).find('option:selected').val());
        Paging(sender);

    }
};

function Paging(sender) {
    debugger;
    var obj = new Object();
    obj.Search = $('#Search').val();
    obj.PageNo = paging.startIndex;
    obj.RecordsPerPage = paging.pageSize;
    obj.SortBy = $('#SortBy').val();
    obj.SortOrder = $('#SortOrder').val();
    obj.UserRole = $('#DDLUserType').val();
    

    $.ajaxExt({
        type: "POST",
        validate: false,
        parentControl: $(sender).parents("form:first"),
        data: $.postifyData(obj),
        messageControl: null,
        showThrobber: false,
        throbberPosition: { my: "left center", at: "right center", of: sender, offset: "5 0" },
        url: baseUrl + '/Admin/User/GetUsersPagingList',
        success: function (results, message) {
            $('#divResult table:first tbody').html(results[0]);
            PageNumbering(results[1]);
          
        }
    });
}


function GetDishAddedByAdmin(id) {
    $('#MotherDishListing tbody').html('<td colspan="2"><center><img src="/Content/images/loader.GIF" style="margin-top:50px;" /></center><td>');
    $.ajaxExt({
        type: "POST",
        validate: false,
        messageControl: null,
        showThrobber: false,
        url: baseUrl + '/Admin/User/GetMotherDishList',
        data: { MotherId: id },
        success: function (results, message) {
            debugger;
            $('#MotherDishListing tbody').html(results[0]);

        }
    });
}

function GetUpdatedDishList() {
    //$('#MotherDishListing tbody').html('<td colspan="2"><center><img src="/Content/images/loader.GIF" style="margin-top:50px;" /></center><td>');
    $.ajaxExt({
        type: "POST",
        validate: false,
        messageControl: null,
        showThrobber: false,
        url: baseUrl + '/Admin/User/GetUpdatedDishList',
        data: {},
        success: function (results) {
            debugger;

        }
    });
}

function GetUpdatedDishList() {
    $.ajaxExt({
        type: "POST",
        validate: false,
        data: {},
        messageControl: null,
        showThrobber: false,
        //throbberPosition: { my: "left center", at: "right center", of: sender, offset: "5 0" },
        url: baseUrl + '/Admin/User/GetUpdatedDishList',
        success: function (results, message) {
            debugger;
            $('#AddDishForMotherForm #DishId').html(results[0]);


        }
    });


}