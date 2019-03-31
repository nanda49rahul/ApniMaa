$(document).ready(function () {
    $("#addDish").live("click", function () {
        return Dish.AddDish($(this));
    });
    $("#modifydsish").live("click", function () {
        return Dish.UpdateDish($(this));
    });
    $("#deleteDish").live("click", function () {
        return Dish.DeleteDish($(this));
    });

    $("input[type=button]#btnFilterVersion").live("click", function () {
        return Dish.ManageDishes($(this));
    });
    $("select#showRecords").on("change", function () {
        return Dish.ShowRecords($(this));
    });
    $('.sorting').live("click", function () {
        return Dish.SortDishes($(this));
    });
});

var Dish = {
    SortDishes: function (sender) {
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
    AddDish: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Dish/AddDish',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#DishForm"),
            formToPost: $("#DishForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = baseUrl + '/Dish/ManageDishes';
                }, 1500);

            }
        });

    },
    UpdateUser: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Dish/ModifyDish',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $("#DishForm"),
            formToPost: $("#DishForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = baseUrl + '/Dish/ManageDishes';
                }, 1500);
            }
        });

    },

    DeleteUser: function (sender) {
        $.ConfirmBox("", "Are you sure to delete this record?", null, true, "Yes", true, null, function () {
            $.ajaxExt({
                url: baseUrl + '/Dish/DeleteDish',
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

    ManageDishes: function (totalCount) {
        var totalRecords = 0;
        totalRecords = parseInt(totalCount);
        //alert(totalRecords);
        PageNumbering(totalRecords);
    },

    SearchDishes: function (sender) {
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
        parentControl: $("#DishForm"),
        data: $.postifyData(obj),
        messageControl: null,
        showThrobber: false,
        throbberPosition: { my: "left center", at: "right center", of: sender, offset: "5 0" },
        url: baseUrl + '/Dish/GetDishesPagedList',
        success: function (results, message) {
            $('#divResult table:first tbody').html(results[0]);
            PageNumbering(results[1]);

        }
    });
}