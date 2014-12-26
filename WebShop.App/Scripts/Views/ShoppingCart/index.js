
function addShoppingCartItem(shoppingCartUpdate) {
    updateShoppingCart(shoppingCartUpdate, 'added to cart');
}

function removeShoppingCartItem(shoppingCartUpdate) {
    updateShoppingCart(shoppingCartUpdate, 'removed from cart');
}

function updateShoppingCart(shoppingCartUpdate, messageSuffix) {
    var itemUpdate = shoppingCartUpdate.UpdatedItem;
    var row = $('table tr#' + itemUpdate.Id);
    if (itemUpdate.Count != 0) {
        $('td.quantity>span.quantity', row).text(itemUpdate.Count);
        $('td.sub-total>span.price-number', row).text(itemUpdate.TotalPrice.toFixed(2));
    } else {
        $(row).fadeOut();
    }

    $('td.total-row span.price-number').text(shoppingCartUpdate.TotalPrice.toFixed(2));
    $('td.total-row span.items-number').text(shoppingCartUpdate.TotalItems);

    var title = $('[title]', row).attr('title');
    toastr.success('"' + title + '" ' + messageSuffix);

    updateShoppingCartStatus(shoppingCartUpdate.TotalItems);
}