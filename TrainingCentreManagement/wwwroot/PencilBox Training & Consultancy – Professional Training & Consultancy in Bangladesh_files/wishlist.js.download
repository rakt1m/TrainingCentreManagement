;(function ($) {
	"use strict";
	var timer = null,
		submit = function () {
			var $button = $(this),
				course_id = $button.attr('data-id'),
				nonce = $button.attr('data-nonce'),
				text = $button.data('text');
			if ($button.hasClass('ajaxload_wishlist')) {
				return;
			}
			$button.addClass('ajaxload_wishlist').prop('disabled', true);
			if (text) {
				$button.html(text);
			}
			$.ajax({
				url     : window.location.href,
				type    : 'post',
				dataType: 'html',
				data    : {
					//action   : 'learn_press_toggle_course_wishlist',
					'lp-ajax': 'toggle_course_wishlist',
					course_id: course_id,
					nonce    : nonce
				},
				success : function (response) {
					response = LearnPress.parseJSON(response);
					var $b = $('.learn-press-course-wishlist-button-' + response.course_id),
						$p = $b.closest('[data-context="tab-wishlist"]');
					if ($p.length) {
						$p.fadeOut(function () {
							var $siblings = $p.siblings(),
								$parent = $p.closest('#learn-press-profile-tab-course-wishlist');
							$p.remove();
							if ($siblings.length == 0) {
								$parent.removeClass('has-courses');
							}
						});
					} else {
						$b.removeClass('ajaxload_wishlist')
							.toggleClass('on', response.state == 'on')
							.prop('title', response.title)
							.html(response.button_text);
					}
					$b.prop('disabled', false)
				}
			});
		};
	$(document).on('click', '.course-wishlist', function () {
		timer && clearTimeout(timer);
		timer = setTimeout($.proxy(submit, this), 50);
	});
})(jQuery);
