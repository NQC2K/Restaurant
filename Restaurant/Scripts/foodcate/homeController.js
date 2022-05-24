var homeconfig = {
    pageSize: 2,
    pageIndex: 1
}
var homeController = {
    init: function () {
        homeController.loadData();
        homeController.registerEvent();
    },
    registerEvent: function () {
        $('#txtSearch').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                homeController.loadData(true);
            }
        });
        $('#btnSearch').off().on('click', function () {
            homeController.loadData(true);
        });
    },
    loadData: function (changePageSize) {
        var searchname = $('#txtSearch').val();
        $.ajax({
            url: '/Home/GetFood',
            type: 'GET',
            dataType: 'json',
            data: {
                searchname: searchname,
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            success: function (res) {
                if (res.status) {
                    /*alert(res.status);*/
                    var data = res.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            FoodName: item.FoodName,
                            Price: item.Price,
                            PriceDiscount: item.PriceDiscount,
                            Image: item.Image,
                        });
                    });
                    $('#tblData').html(html);
                    homeController.paging(res.total, function () {
                        homeController.loadData();
                    }, changePageSize);
                    homeController.registerEvent();
                } else {
                    alert('Load failed.');
                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize)
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "<<",
            next: ">",
            last: ">>",
            prev: "<",
            initiateStartPageClick: false,
            visiblePages: 5,
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page
                setTimeout(callback, 200);
            }
        });
    }
}
homeController.init();