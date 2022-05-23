var homeconfig = {
    pageSize: 2,
    pageIndex: 1
}
var homeController = {
    init: function () {
        homeController.loadData();
    },
    loadData: function () {
        $.ajax({
            url: '/Home/GetFood',
            type: 'GET',
            dataType: 'json',
            data: {
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            success: function (res) {
                if (res.status) {
                    /*alert(res.status);*/
                    var data = res.data;
                    /*                    alert(data);*/
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            FoodID: item.FoodID,
                            FoodName: item.FoodName,
                            CateId: item.CateId,
                            Description: item.Description,
                            Price: item.Price,
                            Image: item.Image,
                        });
                    });
                    $('#tblData').html(html);
                    homeController.paging(res.total, function () {
                        homeController.loadData();
                    });
/*                    homeController.registerEvent();*/
                } else {
                    alert('Load failed.');
                }
            }
        })
    },
    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / homeconfig.pageSize)
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "<<",
            next: ">",
            last: ">>",
            prev: "<",
            visiblePages: 5,
            onPageClick: function (event, page) {
                homeconfig.pageIndex = page
                setTimeout(callback, 200);
            }
        });
    }
}
homeController.init();