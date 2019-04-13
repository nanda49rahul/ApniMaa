var followUp = followUp || {};

$(document).ready(function () {
    $("#addProspect").live("click", function () {
        return prospect.AddProspect($(this));
    });
});

var prospect = {
    AddProspect: function (sender) {
        debugger;
        $.ajaxExt({
            url: baseUrl + '/dashboard/AddProspect',
            type: 'POST',
            validate: true,
            showErrorMessage: true,
            messageControl: $('div.messageAlert'),
            formToValidate: $(sender).parents("#AddProspectForm"),
            showThrobber: true,
            button: $(sender),
            throbberPosition: { my: "left center", at: "right center", of: $(sender) },
            data: $(sender).parents("form:first").serializeArray(),
            success: function (results, message) {
                $.showGritterMessage(message, MessageType.Success);
                setInterval(function () { window.location.href = '/Dashboard/prospects'; }, 2000);
            }
        });
        return false;
    },
    ManageProspect: function (totalCount) {
        var totalRecords = 0;
        totalRecords = parseInt(totalCount);
        PageNumbering(totalRecords);
    },
    PagingRecords: function (sender) {
        var obj = new Object();
        //obj.Search = $('#Search').val();
        obj.Name = $('#Name').val();
        // obj.Email = $('#Email').val();
        obj.PageNo = paging.startIndex;
        obj.RecordsPerPage = paging.pageSize;
        obj.SortBy = $('#SortBy').val();
        obj.SortOrder = $('#SortOrder').val();

        $.ajaxExt({
            type: "POST",
            validate: false,
            parentControl: $(sender).parents("form:first"),
            data: $.postifyData(obj),
            messageControl: null,
            showThrobber: true,
            throbberPosition: { my: "left center", at: "right center", of: sender, offset: "5 0" },
            url: followUp.Urls.pagingRecords,
            success: function (results, message) {
                $('#divResult table:first tbody').html(results[0]);
                PageNumbering(results[1]);
            }
        });
    }
};