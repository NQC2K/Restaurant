var pages = 1;
$(document).ready(function () {
    LoadFoods();
})
//Search
//$('#btnSearch').click(function () {
//    LoadFoods();
//})
/*Paging*/
$("#paging").on("click", "li", function (e) {
    e.preventDefault();
    pages = $(this).text();
    LoadFoods();
});
function LoadFoods() {
    $.ajax({
        url: 'Home/FoodCate?cateid=' + cateid,
        type: 'GET',
        dataType: 'JSON',
        //data: {
        //    cateid: $('#h2').val(),
        //    page: pages
        //},
        success: function (data) {
            alert(data);
            /*            console.log(data);*/
            let idx = 1;
            $('#boxcontainer').empty();
            data.foods.forEach(f => {
                let tr = '<tr>';
                tr += '<td>' + (idx++) + '</td>';
                tr += '<td>' + f.FoodName + '</td>';
                tr += '<td>' + f.Image + '</td>';
                tr += '<td>' + f.Price + '</td>';
                tr += '<td>' + f.Desc + '</td>';
                tr += '<td>' + f.CateId + '<td>';
                tr += '</tr>';

                $('#boxcontainer').append(tr);

                //    $('#paging').empty();
                //    for (i = 1; i <= data.totalPage; i++) {
                //        let li = '<li class="page-item" id="' + i + '"><a class="page-link" href="#">' + i + '</a></li>';
                //        $('#paging').append(li);
                //    }

                //    let li = $('#paging li#' + pages + '');
                //    $(li).addClass('active');
            })
        }
    })
}