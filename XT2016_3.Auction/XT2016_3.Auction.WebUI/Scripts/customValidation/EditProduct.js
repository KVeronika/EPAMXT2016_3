$(document).ready(function () {
    $('.editForm').each(function () {
        $(this).validate({
            rules: {
                name: {
                    required: true,
                    minlength: 1
                },
                cost: {
                    required: true,
                    number: true,
                    min: 0
                },
                endingDate: {
                    required: true,
                    date: true
                }
            },
            messages: {
                name: {
                    required: "Please enter product name",
                    minlength: "Product name must have a length greater than 1 character"
                },
                cost: {
                    required: "Please enter the cost of the product",
                    number: "Cost of product must contains only decimal number",
                    min: "Cost of product must be positive"
                },
                endingDate: {
                    required: "Please enter the ending date of the product",
                    date: "Ending date must be date or date and time"
                }
            }
        });
    });
});