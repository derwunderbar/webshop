$(function () {
    $('div.button > a').button().addClass('add-to-cart');
});

function addShoppingCartItem(shoppingCartUpdate) {
    updateShoppingCartStatus(shoppingCartUpdate.TotalItems);
    toastr.success('"' + shoppingCartUpdate.UpdatedItem.Title + '" ' + 'added to cart');
}