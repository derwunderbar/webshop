$(function () {
    initPager();
});

function initPager() {
    $('div.page-buttons > div > a').button();
    $('div.page-buttons > div > span').button().addClass('ui-state-disabled');
}