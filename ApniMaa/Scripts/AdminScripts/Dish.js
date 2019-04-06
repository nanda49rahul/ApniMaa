$(document).ready(function () {

    $("#AddDishBtn").on("click", function () {
        return Dish.AddDish($(this));
    });
    $("#updateDish").on("click", function () {
        return Dish.UpdateDish($(this));
    });

    $(document).on("click",".deleteDish", function (e) {
        return Dish.DeleteDish($(this));
    });

    $("input[type=button]#btnFilterPeople").on("click", function () {
        return Dish.SearchDishes($(this));
    });

    $("input[type=button]#btnResetSearch").on("click", function () {
        $('#Search').val('');
        return Dish.SearchDishes($(this));
    });

    $("select#showRecords").on("change", function () {
        return Dish.ShowRecords($(this));
    });
    $('.sorting').on("click", function () {
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
            formToValidate: $("#AddDishForm"),
            formToPost: $("#AddDishForm"),
            isAjaxForm: true,
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            success: function (results, message) {
                $.ShowMessage($('div.messageAlert'), message, MessageType.Success);
                setTimeout(function () {
                    window.location.href = '/Admin/Dish/ManageDish';
                }, 1500);

            }
        });

    },
    UpdateDish: function (sender) {
        $.ajaxExt({
            url: baseUrl + '/Dish/UpdateDish',
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
                    window.location.href = '/Admin/Dish/ManageDish';
                }, 1500);
            }
        });

    },
    DeleteDish: function (sender) {
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
        url: '/admin/Dish/GetDishPagedList',
        success: function (results, message) {
            $('#divResult table:first tbody').html(results[0]);
            PageNumbering(results[1]);

        }
    });
}