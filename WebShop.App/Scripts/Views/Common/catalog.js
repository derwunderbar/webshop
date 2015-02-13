$(function () {
    $('div.title').dotdotdot();
    updateHeights();
    initPagerUrls();
});

$(window).resize(function () {
    updateHeights();
});

function initPagerUrls() {
    $('div.page-buttons > div > a').each(function (i) {
        var element = $(this);
        element.click(function (e) {
            e.preventDefault();

            $.ajax({
                type: "GET",
                url: element.attr("href"),
                success: function (result) {
                    $('#catalog').html(result);

                    var pageUrl = '/Catalog';
                    var pageIndex = element.attr("href").indexOf('?page');
                    var url = pageIndex != -1 ? pageUrl + element.attr("href").substring(pageIndex) : pageUrl;
                    refreshCatalog(url);
                }
            });
        });
    });
}

function refreshCatalog(url) {
    initAddToCartButtons();
    initPager();
    $('div.title').dotdotdot();
    updateHeights();
    history.pushState(null, null, url);
    initPagerUrls();
}

function updateHeights() {
    var maxHeight = 0, rowY = 0, rowDivs = [], allDivs = $('.book-small'), count = allDivs.length;

    allDivs.each(function (i) {
        var div = $(this), y = div.offset().top, h = div.height();

        if (h > maxHeight) maxHeight = h;
        if (rowY == 0) rowY = y;

        // Resize collected elements in case of new row
        if (y > rowY) {
            resizeElements(rowDivs, maxHeight);
            rowDivs.length = 0;
            maxHeight = h;
        }

        rowY = div.offset().top;
        rowDivs.push(div);

        // Resize collected elements in case of last row element
        if (count - 1 == i) {
            resizeElements(rowDivs, maxHeight);
        }
    });

    // Update inner container layout
    $('.book-small > div').addClass('relative-upd');
    $('.book-small > div > div.bottom').addClass('bottom-upd');
}

function resizeElements(elements, height) {
    for (var i = 0; i < elements.length; i++) {
        $(elements[i]).height(height);
    }
}