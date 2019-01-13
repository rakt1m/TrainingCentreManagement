(function ($) {
    "use strict";

    $(document).ready(function () {
        let brands = $('.bp-element-brands');

        brands.each(function () {
            let items_visible = $(this).attr('data-items-visible'),
                items_tablet = $(this).attr('data-items-tablet'),
                items_mobile = $(this).attr('data-items-mobile'),
                rtl = $('body').hasClass('rtl');

            $(this).find('.owl-carousel').owlCarousel({
                    rtl: rtl,
                    dots: false,
                    pagination: false,
                    responsive: {
                        0: {
                            items: 3,
                        },
                        600: {
                            items: items_mobile,
                        },
                        768: {
                            items: items_tablet,
                        },
                        1200: {
                            items: items_visible,
                        }
                    },
                }
            )
        })
    });

})(jQuery);