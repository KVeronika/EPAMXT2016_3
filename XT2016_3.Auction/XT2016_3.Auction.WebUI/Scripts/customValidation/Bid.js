$(document).ready(function () {
    $('.bidForm').each(function () {
        $(this).validate({
            rules: {
                cost: {
                    required: true,
                    number: true,
                    min: 0
                }
            },
            messages: {
                cost: {
                    required: "Please enter the cost of the product",
                    number: "Cost of product must contains only decimal number",
                    min: "Cost of product must be positive"
                }
            }
        });
    });

});