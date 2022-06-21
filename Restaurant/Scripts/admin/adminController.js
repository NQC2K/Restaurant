var adminconfig = {
    pageSize: 4,
    pageIndex: 1
}
var adminController = {
    init: function () {
        adminController.loadData();
        adminController.registerEvent();
    },
    registerEvent: function () {
    //    $('#txtSearch').off('keypress').on('keypress', function (e) {
    //        if (e.which == 13) {
    //            adminController.loadData(true);
    //        }
    //    });
    //    $('#btnSearch').off().on('click', function () {
    //        adminController.loadData(true);
    //    });
        //$('.btn-primary').off().on('click', function () {
        //    $('#modalDetail').modal('show');
        //    var id = $(this).data('id');
        //    adminController.loadDetail(id);
        //});
        $('.btn-edit').off().on('click', function () {
            $('#modalAddUpdate').modal('show');
            var id = $(this).data('id');
            adminController.loadDetail(id);
        });
        $('#btnSave').off().on('click', function () {
/*            if ($('#frmSaveData').valid()) {*/
                adminController.saveData();
/*            }*/
        });
        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            adminController.resetForm();
        });
        $('.btn-delete').off().on('click', function () {
            var id = $(this).data('id');
            //confirm("Sure?", function (result) {
            //    if (result) {
            //        adminController.deleteEmployee(id);
            //    }
            //});
            var result = confirm("Sure?");
            if (result) {
                adminController.deleteData(id);
            }
            else {
                alert("Cancel");
            }
        });           
    },
    deleteData: function (id) {
        $.ajax({
            url: '/Admin/Dashboard/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    alert('Delete success');
                    adminController.loadData(true);
                }
                else {
                    alert(res.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    saveData: function () {
        var name = $('#txtName').val();
        var cateid = parseInt($('#txtCateId').val());
        var desc = $('#txtDesc').val();
        var price = parseFloat($('#txtPrice').val());
        var pricediscount = parseFloat($('#txtPriceDiscount').val());
        var id = parseInt($('#txtId').val());
        var food = {
            FoodName: name,
            CateId: cateid,
            Description: desc,
            Price: price,
            PriceDiscount: pricediscount,
            FoodID: id
        }
        $.ajax({
            url: '/Admin/Dashboard/SaveData',
            data: {
                str: JSON.stringify(food)
            },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    alert('Save success');
                    $('#modalAddUpdate').modal('hide');
                    adminController.loadData(true);
                }
                else {
                    alert(res.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    resetForm: function () {
        $('#hidId').val('0');
        $('#txtName').val('');
        $('#txtCateId').val(1);
        $('#txtDesc').val('');
        $('#txtPrice').val(0);
        $('#txtPriceDiscount').val(0);
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/Admin/Dashboard/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status == true) {
                    var data = res.data;
                    $('#txtId').val(data.FoodID);
                    $('#txtName').val(data.FoodName);
                    $('#txtCateId').val(data.CateId);
                    $('#txtDesc').val(data.Description);
                    $('#txtPrice').val(data.Price);
                    $('#txtPriceDiscount').val(data.PriceDiscount);
                }
                else {
                    alert(res.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    loadData: function (changePageSize) {
        var searchname = $('#txtSearch').val();
        $.ajax({
            url: '/Admin/Dashboard/GetFood',
            type: 'GET',
            dataType: 'json',
            data: {
                searchname: searchname,
                page: adminconfig.pageIndex,
                pageSize: adminconfig.pageSize
            },
            success: function (res) {
                if (res.status) {
                    /*alert(res.status);*/
                    var data = res.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            FoodID: item.FoodID,
                            Image: item.Image,
                            FoodName: item.FoodName,
                            Description: item.Description,
                            Price: item.Price,
                            PriceDiscount: item.PriceDiscount,
                        });
                    });
                    $('#tblData').html(html);
                    adminController.paging(res.total, function () {
                        adminController.loadData();
                    }, changePageSize);
                    adminController.registerEvent();
                } else {
                    alert('Load failed.');
                }
            }
        })
    },
    paging: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / adminconfig.pageSize)
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
                adminconfig.pageIndex = page
                setTimeout(callback, 200);
            }
        });
    }
}
adminController.init();
