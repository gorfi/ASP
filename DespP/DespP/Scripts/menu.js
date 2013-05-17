
$(document).ready(function () {
    $(function () {
        function myRepeat() {
            $('#detail-icon-img').delay(1000).fadeTo(3000, 0.33).delay(500).fadeTo(3000, 1);
        }
        setInterval(myRepeat, 500);

    });

//Change Active item menu.
    var pageName = (location.pathname).split('/').pop();
    if (pageName == '') {
        pageName = '/';
    }
   $('li').find('a').each(function (index, value) {
       // Append a '$' to the pagename to make the match()-function search
       // from the end of the href value:
       pageName += '$';

       if (value.href.match(pageName)) {
           // If the pagename matches the href-attribute, then add the 'active'
           // class to the parent li, and show parent ul:s:
           $(this).parent('li').addClass('active').parents('ul').show();
       }
   });
});
