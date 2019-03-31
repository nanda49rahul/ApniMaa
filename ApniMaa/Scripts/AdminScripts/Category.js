$(document).ready(function () {
    $("#addCategory").live("click", function () {
        return Category.AddCategory($(this));
    });
    $("#updateCategory").live("click", function () {
        return Category.UpdateCategory($(this));
    });
    $("#deleteCategory").live("click", function () {
        return Category.DeleteCategory($(this));
    });

    $("input[type=button]#btnFilterVersion").live("click", function () {
        return Category.ManageCategories($(this));
    });
    $("select#showRecords").on("change", function () {
        return Category.ShowRecords($(this));
    });
    $('.sorting').live("click", function () {
        return Category.SortCategories($(this));
    });
});

var Category = {
    SortCategories: function (sender) {
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
    AddCategory: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Category/AddCategory',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#categoryForm"),
            formToPost: $("#categoryForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = baseUrl + '/Category/ManageCategories';
                }, 1500);

            }
        });

    },
    UpdateUser: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Category/ModifyCategory',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#categoryForm"),
            formToPost: $("#categoryForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = baseUrl + '/Category/ManageCategories';
                }, 1500);
            }
        });

    },

    DeleteUser: function (sender) {
        $.ConfirmBox("", "Are you sure to delete this record?", null, true, "Yes", true, null, function () {
            $.ajaxExt({
                url: baseUrl + '/Category/DeleteCategory',
                type: 'POST',
                validate: false,
                showErrorMessage: true,
                messageControl: $('div.messageAlert'),
                showThrobber: true,
                button: $(sender),
                throbberPosition: { my: "left center", at: "right center", of: $(sender) },
                data: { Id: $(sender).attr("data-id") },
                success: function (results, message) {
                    $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                    Paging();
                }
            });
        });
    },

    ManageCategories: function (totalCount) {
        var totalRecords = 0;
        totalRecords = parseInt(totalCount);
        //alert(totalRecords);
        PageNumbering(totalRecords);
    },

    SearchCategories: function (sender) {
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
    var obj = new Object();
    obj.Search = $('#Search').val();
    obj.PageNo = paging.startIndex;
    obj.RecordsPerPage = paging.pageSize;
    obj.SortBy = $('#SortBy').val();
    obj.SortOrder = $('#SortOrder').val();
    $.ajaxExt({
        type: "POST",
        validate: false,
        parentControl: $("#categoryForm"),
        data: $.postifyData(obj),
        messageControl: null,
        showThrobber: false,
        throbberPosition: { my: "left center", at: "right center", of: sender, offset: "5 0" },
        url: baseUrl + '/Category/GetCategoriesPagedList',
        success: function (results, message) {
            $('#divResult table:first tbody').html(results[0]);
            PageNumbering(results[1]);

        }
    });
}