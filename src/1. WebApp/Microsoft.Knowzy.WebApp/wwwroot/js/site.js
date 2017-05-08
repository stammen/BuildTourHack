$(function () {
    $('#addItem').on('click', function () {
        var actualItems = [];
        $("table").find(".itemNumber").each(function () {
            actualItems.push($(this).text().trim());
        });

        $.get("/Shippings/AddOrderItem",
            $.param({ 'itemNumbers': actualItems }, true), function (partialView) {
            var tableBody = $('table tbody');
            tableBody.fadeIn(400,
                function () {
                    tableBody.append(partialView);
                });
            });
        (actualItems.length === 3) ? $('#addItem').hide() : $('#addItem').show();
    });

    $("table").on("click", ".delete", function(event) {
        event.preventDefault();
        var tr = $(this).closest('tr');
        tr.fadeOut(400,
            function() {
                tr.remove();
                $('#addItem').show();
            });
    });
});
