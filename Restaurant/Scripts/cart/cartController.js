var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btn-payment').off('click').on('click', function () {
            window.location.href = "/Cart/Payment";
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
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        });
    }
}
cart.init();