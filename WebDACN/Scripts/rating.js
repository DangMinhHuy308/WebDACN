/* 
    
        Init Star Rating
    
        */

$(document).ready(function () {
    initStarRating();
});

function initStarRating() {
    if ($('.user_star_rating li').length) {
        var stars = $('.user_star_rating li');
        var dem = 0;

        stars.each(function (i) {
            var star = $(this);

            star.on('click', function () {
                dem = 0;
                stars.find('i').removeClass('fa-star').addClass('fa-star-o');

                for (var x = 0; x <= i; x++) {
                    $(stars[x]).find('i').removeClass('fa-star-o').addClass('fa-star');
                    dem++;
                }

                $('#txtRate').val(dem);
                console.log(dem);
            });
        });
    }
}

