$('#reference').click(function () {
    var state = $('#innerList').attr('data-view');

    if (state == 'hide') {
        $('#innerList')
            .removeClass('b-nav__menu__collection__inner_hide')
            .addClass('b - nav__menu__collection__inner_show');

        $('#innerList').attr('data-view', 'show');
    }
    else if (state == 'show') {
        $('#innerList')
            .removeClass('b - nav__menu__collection__inner_show')
            .addClass('b-nav__menu__collection__inner_hide');

        $('#innerList').attr('data-view', 'hide');
    }

});