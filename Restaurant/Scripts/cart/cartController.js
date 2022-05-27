var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btn-payment').off('click').on('click', function () {
            window.location.href = "/payment";
        });
        $('.qty').on('change', function () {
            var list = $('.qty');
            var cartList = [];
            $.each(list, function (i, item) {
                cartList.push({
                    Quantity: $(this).val(),
                    Food: {
                        FoodID: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    } else {
                        alert("Error");
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/cart";
                    }
                }
            })
        });
    }
}
cart.init();