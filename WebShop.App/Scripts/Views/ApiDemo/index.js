
$(function () {
    loadBooks(1);
});

function loadBooks(pageNumber) {
    $.ajax({
        type: "GET",
        url: '/api/catalog/' + pageNumber,
        success: function(booksPage) {

            var catalogElement = $('#catalog');
            catalogElement.html('');
            var bookElement = $('#templates > .book-api-small-template').clone();
            for (var i = 0; i < booksPage.items.length; i++) {
                var item = booksPage.items[i];

                var thumb = bookElement.find('.thumb');
                thumb.find('img').attr('src', item.cover);
                var url = '/api/catalog/book/' + item.id;
                thumb.find('a').attr('href', url);
                var title = bookElement.find('.title > a');
                title.attr('href', url);
                title.html(item.title);
                bookElement.find('.price > .price-number').html(item.price);

                catalogElement.append(bookElement.html());
            }

            catalogElement.find('.book-api-small a').each(function(i) {
                var element = $(this);
                element.click(function(e) {
                    e.preventDefault();

                    $.ajax({
                        type: "GET",
                        url: $(e.currentTarget).attr('href'),
                        success: function(book) {
                            
                            var popupElement = $('#templates > .book-api-popup-template').clone();
                            popupElement.find('.cover img').attr('src', book.cover);
                            popupElement.find('.title .value').html(book.title);
                            popupElement.find('.author .value').html(book.author.name);
                            popupElement.find('.price .value').html(book.price);
                            popupElement.find('.publisher .value').html(book.publisher.name);
                            popupElement.find('.descr .value').html(book.description);

                            popupElement.dialog({ width: 700, resizable: false });
                        }
                    });
                });
            });

            $('#pager > div').pagination({
                items: booksPage.totalItemsCount,
                itemsOnPage: booksPage.pageSize,
                currentPage : booksPage.pageNumber,
                cssStyle: 'compact-theme',
                onPageClick: function(pageNumber, event) {
                    loadBooks(pageNumber);
                }
            });
        }
    });
}