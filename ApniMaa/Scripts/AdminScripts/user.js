$(document).ready(function () {


    $("#btnFilterPeople").click(function () {
       
            return User.SearchUsers($(this));
        
       
    });
    $("select#showRecords").on("change", function () {
       
            return User.ShowRecords($(this));
       
    });
    $('.sorting').click(function () {
        
            return User.SortUsers($(this));
        
    });
    $('#Search').keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            
             
                return User.SearchUsers($(this));
          
        }
    });

   
    
    
});
$(document).on("change", ".userrole", function () {
    Paging($(this));
});
$(document).on("change", ".userstatus", function () {
    Paging($(this));
});

var User = {
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

    ManageUsers: function (totalCount) {
        var totalRecords = 0;
        totalRecords = parseInt(totalCount);
        //alert(totalRecords);
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
    },
    SetStatus:function(UserId, StatusId)
    {
        
        var formData = new FormData();
        formData.append("UserId", UserId);
        formData.append("StatusId", StatusId);
        $.ajax({
            type: "POST",
            url: "/User/SetUserStatus",
            cache: false,
            processData: false,
            contentType: false,
            data: formData,
            success: function (response) {
                
                if (response.Status != 1) {
                    toastr.error(response.Message, 'MOOR');
                    
                }
                else {
                    toastr.success(response.Message, 'MOOR');
                    Paging();

                }

            },
            failure: function (response) {
                
            },
            error: function (response) {
                
            },
        });
    },
    GetProfile:function(UserId)
    {
        
        var formData = new FormData();
        formData.append("UserId", UserId);
        $.ajax({
            type: "POST",
            url: "/Admin/GetUserProfile",
            cache: false,
            processData: false,
            contentType: false,
            data: formData,
            success: function (results,message) {
                
                if (results.length != 0)
                {
                    
                    $('#Modalpp').html(results.Results[0]);
                    //$("#SellerId").text(response.UserId);
                    //$(".SellerName").text(response.Name);
                    //$("#SellerPhone").text(response.Phone);
                    //$("#SellerEmail").text(response.Email);
                    //$("#SellerLocation").text(((response.CityName!=null)?response.CityName:"") + " " +((response.StateName!=null)?response.StateName:"") +" "+((response.CountryName!=null)? response.CountryName:"") + " " + ((response.ZipCode!=null)?response.ZipCode:""));
                    //$("#SellerCategory").text(response.CategoryNames);
                    //$("#SellerSubCategory").text(response.SubCategoryNames);
                    //$("#SellerDescription").text(response.Description);
                    //$("#ResponseRate").css("width", response.ResponseRate + "%");
                    //$("#ResponseRateText").text(response.ResponseRate);
                    //$('#PPic').attr("src", "../../Content/ProfilePics/" + response.ProfilePic + "?" + new Date().getTime());
                    //if (response.RoleId == 2)
                    //{
                    //    $('.response-rate').css("display","none");
                    //}
                    //else
                    //{
                    //    $('.response-rate').css("display", "block");
                    //}
                    $('#ProfileModal').modal('toggle');
                }
            },
            failure: function (response) {
                
            },
            error: function (response) {
                
            },
        });
    },
};

function Paging(sender) {
    debugger;
    var obj = new Object();
    obj.Search = $('#Search').val();
    obj.PageNo = paging.startIndex;
    obj.RecordsPerPage = paging.pageSize;
    obj.SortBy = $('#SortBy').val();
    obj.SortOrder = $('#SortOrder').val();
    obj.UserRole = ($(".userrole").val() != "") ? $(".userrole").val() : 0;
    obj.UserStatus = ($(".userstatus").val() != "") ? $(".userstatus").val() : 0;
    obj.Category = ($("#CategoryId").val() != "" && $("#CategoryId").val() != null) ? $("#CategoryId").val() : 0;
    obj.SubCategory = ($("#SubCategoryId").val() != "" && $("#SubCategoryId").val() != null) ? $("#SubCategoryId").val() : 0;
    $.ajax({
        url: '/User/GetUserPagedList',
        method: "POST",
        data: $.postifyData(obj),
        success: function (results, message) {
            
            $('#Content:first tbody').html(results.Results[0]);
            
            PageNumbering( results.Results[1]);
        }
    });
}

$.postifyData = function (value) {
    var result = {};

    var buildResult = function (object, prefix) {
        for (var key in object) {

            var postKey = isFinite(key)
                    ? (prefix != "" ? prefix : "") + "[" + key + "]"
                    : (prefix != "" ? prefix + "." : "") + key;

            switch (typeof (object[key])) {
                case "number": case "string": case "boolean":
                    result[postKey] = object[key];
                    break;

                case "object":
                    if (object[key] != null) {
                        if (object[key].toUTCString) result[postKey] = object[key].toUTCString().replace("UTC", "GMT");
                        else buildResult(object[key], postKey != "" ? postKey : key);
                    }
            }
        }
    };

    buildResult(value, "");
    return result;
}