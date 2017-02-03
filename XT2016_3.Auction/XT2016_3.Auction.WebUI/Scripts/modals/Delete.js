(function () {
    (function () {
        $('.deleteBtn').each(function () {
            addEventListener('click', ajaxPost);
        })
    })();
    function ajaxPost(event) {
        var formId = $(event.target).parents('.deleteForm').attr('id'),
           form = document.getElementById(formId),
           modal = $(event.target).parents('.modal');
        $(form).submit(() => {
            event.preventDefault();
            $.ajax({
                url: `./DeleteProduct`,
                method: "POST",
                data: {
                    "productId": $(event.target).siblings('input[name="productId"]').first().val()
                },
                success: function () {
                    modal.hide();
                    window.location.reload();
                }
            })
            return false;
        });
    }
})();