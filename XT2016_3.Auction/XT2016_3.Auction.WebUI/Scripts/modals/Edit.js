(function () {
    (function () {
        $('.editBtn').each(function () {
            addEventListener('click', ajaxPost);
        })
    })();
    function ajaxPost(event) {
        var formId = $(event.target).parents('.editForm').attr('id'),
            form = document.getElementById(formId),
            modal = $(event.target).parents('.modal'),
            image;
        $(form).submit(() => {
            //event.target.name !== 'image'
            event.preventDefault();
            var formdata = new FormData();
            formdata.set("productId", $(event.target).parents('.editForm').find('input[name="productId"]').val());
            formdata.set("name", $(event.target).parents('.editForm').find('input[name="name"]').val());
            formdata.set("description", $(event.target).parents('.editForm').find('textarea[name="description"]').text());
            formdata.set("cost", $(event.target).parents('.editForm').find('input[name="cost"]').val());
            formdata.set("buyNow", $(event.target).parents('.editForm').find('input[name="buyNow"]').prop('checked'));
            formdata.set("endingDate", $(event.target).parents('.editForm').find('input[name="endingDate"]').val());
            image = $(event.target).parents('.editForm').find('input[name="image"]')[0].files[0];
            if (image !== undefined) {
                formdata.set("image", image);
            }
            if ($(form).valid()) {
                $.ajax({
                    url: `./EditProduct`,
                    method: "POST",
                    data: formdata,
                    contentType: false,
                    processData: false,
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