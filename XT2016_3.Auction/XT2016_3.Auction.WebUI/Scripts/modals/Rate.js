(function () {
    (function () {
        $('.bidBtn').each(function () {
            addEventListener('click', ajaxPost);
        })
    })();
    function ajaxPost(event) {
        var formId = $(event.target).parents('.bidForm').attr('id'),
           form = document.getElementById(formId),
           modal = $(event.target).parents('.modal');
        $(form).submit(() => {
            event.preventDefault();
            if ($(form).valid()) {
                $.ajax({
                    url: `http://localhost:56489/Pages/Products/MakeABid`,
                    method: "POST",
                    data: {
                        "cost": $(event.target).parents('.bidForm').find('input[name="cost"]').val(),
                        "productId": $(event.target).parents('.bidForm').find('input[name="productId"]').val(),
                        "userId": $(event.target).parents('.bidForm').find('input[name="userId"]').val(),
                    },
                    success: function () {
                        modal.hide();
                        window.location.reload();
                    }
                })
            }
            return false;
        });
    }
})();