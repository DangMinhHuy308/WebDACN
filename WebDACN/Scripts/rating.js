/* 
    
        Init Star Rating
    
        */

$(document).ready(function () {
    initStarRating();
    initFavorite();
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




function initFavorite() {
    if ($('.favorite').length) {
        var favs = $('.favorite');

        favs.each(function () {
            var fav = $(this);
            var active = false;
            if (fav.hasClass('active')) {
                active = true;
            }

            fav.on('click', function () {
                var id = $(this).data('id');
                if (active) {
                    fav.removeClass('active');
                    active = false;
                    DeleteWishlist(id);
                }
                else {
                    fav.addClass('active');
                    active = true;
                    AddWishList(id);
                }
            });
        });
    }
}
function AddWishList(id) {
    $.ajax({
        url: '/wishlist/PostWishlist',
        type: 'POST',
        data: { ProductId: id },
        success: function (res) {
            if (res.Success == false) {
                alert(res.Message);
            }
        }
    })
}
function DeleteWishlist(id) {
    $.ajax({
        url: '/wishlist/PostDeleteWishlist',
        type: 'POST',
        data: { ProductId: id },
        success: function (res) {
            if (res.Success == false) {
                alert(res.Message);
            }
        }
    })
}