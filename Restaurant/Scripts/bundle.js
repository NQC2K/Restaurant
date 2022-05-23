var pages = 1;
$(document).ready(function () {
    LoadFoods();
})
//Search
$('#btnSearch').click(function () {
    LoadFoods();
})
//Paging
$("#Paging").on("click", "li", function (e) {
    e.preventDefault();
    pages = $(this).text();
    LoadFoods();
});
function LoadFoods() {
    $.ajax({
        url: '@Url.Action("FoodCate","Home")',
        type: 'GET',
        data: {
            cateid: $('#h2').val(),
            page: pages
        },
        success: function (data) {
            let idx = 1;
            $('#box-container').empty();
            data.foods.forEach(f => {
                let tr = '<tr>';
                tr += '<td>' + f.FoodName + '</td>';
                tr += '<td>' + f.Image + '</td>';
                tr += '<td>' + f.Price + '</td>';
                tr += '</tr>';
                $('#box-container').append(tr);

                $('#Paging').empty();
                for (i = 1; i <= data.soTrang; i++) {
                    let li = '<li class="page-item" id="' + i + '"><a class="page-link" href="#">' + i + '</a></li>';
                    $('#Paging').append(li);
                }

                let li = $('#Paging li#' + page + '');//tìm li có id = trang truyền vào
                //ví dụ trang = 2, sẽ tìm tới cái thằng li có id = 2
                //tìm ra đc thằng cần tìm thì add class active để đánh dấu trang hiện tại đang đc load
                $(li).addClass('active');
            })
        } 
    })
}



        //<div class="box">
        //    <a href="#" class="fas fa-heart"></a>
        //    <div class="image">
        //        <a href="@Url.Action("FoodDetails", "Home", new {id = item.FoodID})">
        //        <img src="~/Content/images/f.Image" alt="">
        //        </a>
        //    </div>
        //    <div class="content">
        //        <h3>f.FoodName</h3>
        //        <div class="stars">
        //            <i class="fas fa-star"></i>
        //            <i class="fas fa-star"></i>
        //            <i class="fas fa-star"></i>
        //            <i class="fas fa-star"></i>
        //            <i class="fas fa-star-half-alt"></i>
        //            <span> (50) </span>
        //        </div>
        //        <div class="price">f.Price VND <span>50000 VND</span></div>
        //        <a href="#" class="btn">add to cart</a>
        //    </div>
        //</div>
 
let searchForm = document.querySelector('.search-form-container');

document.querySelector('#search-btn').onclick = () =>{
    searchForm.classList.toggle('active');
    cart.classList.remove('active');    
    loginForm.classList.remove('active');
    navbar.classList.remove('active');
}

let cart = document.querySelector('.shopping-cart-container');

document.querySelector('#cart-btn').onclick = () =>{
    cart.classList.toggle('active');
    searchForm.classList.remove('active');
    loginForm.classList.remove('active');
    navbar.classList.remove('active');
}

let loginForm = document.querySelector('.login-form-container');

document.querySelector('#login-btn').onclick = () =>{
    loginForm.classList.toggle('active');
    searchForm.classList.remove('active');
    cart.classList.remove('active');    
    navbar.classList.remove('active');
}

let navbar = document.querySelector('.header .navbar');

document.querySelector('#menu-btn').onclick = () =>{
    navbar.classList.toggle('active');
    searchForm.classList.remove('active');
    cart.classList.remove('active');    
    loginForm.classList.remove('active');
}

window.onscroll = () =>{
    navbar.classList.remove('active');
}

document.querySelector('.home').onmousemove = (e) =>{

    let x = (window.innerWidth - e.pageX * 2) / 90;
    let y = (window.innerHeight - e.pageY * 2) / 90;

    document.querySelector('.home .home-parallax-img').style.transform = `translateX(${y}px) translateY(${x}px)`;
}

document.querySelector('.home').onmouseleave = () =>{

    document.querySelector('.home .home-parallax-img').style.transform = `translateX(0px) translateY(0px)`;
}   