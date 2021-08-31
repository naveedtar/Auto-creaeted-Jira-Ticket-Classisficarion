/* INDEX
----------------------------------------------------------------------------------------

01. Preloader js

02. change Menu background on scroll js 

03. Navigation js

04. Smooth scroll to anchor

05. Portfolio js

06. Magnific Popup js

07. Portfolio js  

08. Testimonial js

09. client js

10. News js

11. Google Map js   

12. Ajax Contact Form js

13. MailChimp js   

-------------------------------------------------------------------------------------- */

(function ($) {
    "use strict";
    /*-------------------------------------------------------------------------*
     *                  *. Scroll js                                       *
     *-------------------------------------------------------------------------*/
    
    $(function () {
        $.scrollUp({
          scrollName: 'scrollUp', // Element ID
          topDistance: '300', // Distance from top before showing element (px)
          topSpeed: 600, // Speed back to top (ms)
          animation: 'fade', // Fade, slide, none
          animationInSpeed: 200, // Animation in speed (ms)
          animationOutSpeed: 200, // Animation out speed (ms)
          activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
        });
      });
    /*-------------------------------------------------------------------------*
     *                  01. Preloader js                                       *
     *-------------------------------------------------------------------------*/
    $(window).on("load", function () {
        $("#preloader")
            .delay(300)
            .fadeOut("slow", function () {
                $(this).remove();
            });
    }); // $(window).on end

    $(document).ready(function () {
        /*-------------------------------------------------------------------------*
         *             02. change Menu background on scroll js                     *
         *-------------------------------------------------------------------------*/
        $(window).on("scroll", function () {
            var menu_area = $(".header");
            if ($(window).scrollTop() > 200) {
                menu_area.addClass("sticky-menu").css('transition','0.5s');
            } else {
                menu_area.removeClass("sticky-menu").css('transition','0.5s');
            }
        }); // $(window).on('scroll' end

        /*-------------------------------------------------------------------------*
         *                   03. Navigation js                                     *
         *-------------------------------------------------------------------------*/
        const openedMenu = document.querySelector('.opened-menu');
        const closedMenu = document.querySelector('.closed-menu');
        const navbarMenu = document.querySelector('.navbar');
        const menuOverlay = document.querySelector('.overlay');

        // Opened navbarMenu
        // Closed navbarMenu
        // Closed navbarMenu by Click Outside
        openedMenu.addEventListener('click', toggleMenu);
        closedMenu.addEventListener('click', toggleMenu);
        menuOverlay.addEventListener('click', toggleMenu);

        // Toggle Menu Function
        function toggleMenu() {
        navbarMenu.classList.toggle('active');
        menuOverlay.classList.toggle('active');
        document.body.classList.toggle('scrolling');
        }

        navbarMenu.addEventListener('click', (event) => {
        if (event.target.hasAttribute('data-toggle') && window.innerWidth <= 992) {
            // Prevent Default Anchor Click Behavior
            event.preventDefault();
            const menuItemHasChildren = event.target.parentElement;

            // If menuItemHasChildren is Expanded, Collapse It
            if (menuItemHasChildren.classList.contains('active')) {
                collapseSubMenu();
            } else {
                // Collapse Existing Expanded menuItemHasChildren
                if (navbarMenu.querySelector('.menu-item-has-children.active')) {
                    collapseSubMenu();
                }
                // Expand New menuItemHasChildren
                menuItemHasChildren.classList.add('active');
                const subMenu = menuItemHasChildren.querySelector('.sub-menu');
                subMenu.style.maxHeight = subMenu.scrollHeight + 'px';
            }
        }
        });

        // Collapse Sub Menu Function
        function collapseSubMenu() {
        navbarMenu.querySelector('.menu-item-has-children.active .sub-menu').removeAttribute('style');
        navbarMenu.querySelector('.menu-item-has-children.active').classList.remove('active');
        }

        // Fixed Resize Screen Function
        function resizeScreen() {
        // If navbarMenu is Open, Close It
        if (navbarMenu.classList.contains('active')) {
            toggleMenu();
        }

        // If menuItemHasChildren is Expanded, Collapse It
        if (navbarMenu.querySelector('.menu-item-has-children.active')) {
            collapseSubMenu();
        }
        }

        window.addEventListener('resize', () => {
        if (this.innerWidth > 992) {
            resizeScreen();
        }
        });


        /*-------------------------------------------------------------------------*
         *                   04. Smooth scroll to anchor                           *
         *-------------------------------------------------------------------------*/
        $("a.smooth_scroll").on("click", function (e) {
            e.preventDefault();
            var anchor = $(this);
            $("html, body")
                .stop()
                .animate(
                    {
                        scrollTop: $(anchor.attr("href")).offset().top - 50,
                    },
                    1000
                );
        });

        /*-------------------------------------------------------------------------*
         *                  06. Magnific Popup js                                  *
         *-------------------------------------------------------------------------*/
        $(".work-popup").magnificPopup({
            type: "image",
            gallery: {
                enabled: true,
            },
        });
        $(".popup-youtube, .popup-vimeo, .popup-gmaps").magnificPopup({
            disableOn: 700,
            type: "iframe",
            mainClass: "mfp-fade",
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false,
        });

        /*-------------------------------------------------------------------------*
         *                  07. Portfolio js                                       *
         *-------------------------------------------------------------------------*/
        $(".portfolio").mixItUp();

        /*-------------------------------------------------------------------------*
         *                  08. Testimonial js                                     *
         *-------------------------------------------------------------------------*/
        $(".testimonial-list").owlCarousel({
            slideSpeed: 1000,
            paginationSpeed: 500,
            singleItem: true,
            lazyLoad: false,
            pagination: true,
            navigation: false,
            autoPlay: true,
        });

        /*-------------------------------------------------------------------------*
         *                       09. Slider js                                     *
         *-------------------------------------------------------------------------*/
        $(".home").owlCarousel({
            items: 1,
            autoPlay: true,
            itemsDesktop: [1200, 1],
            itemsDesktopSmall: [980, 1],
            itemsTablet: [768, 1],
            itemsTabletSmall: [767, 1],
            itemsMobile: [480, 1],
            pagination: true,
            navigation: true,
            autoHeight: true,
            navigationText: ['<span class="ti-arrow-left"></span>', '<span class="ti-arrow-right"></span>'],
        });
        /*-------------------------------------------------------------------------*
         *                       10. News js                                     *
         *-------------------------------------------------------------------------*/

        $(".news-list").owlCarousel({
            items: 3,
            autoPlay: true,
            itemsDesktop: [1200, 2],
            itemsDesktopSmall: [980, 2],
            itemsTablet: [768, 2],
            itemsTabletSmall: [767, 1],
            itemsMobile: [480, 1],
            pagination: true,
            navigation: false,
            autoHeight: true,
            navigationText: ['<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>', '<span class="ti-layout-line-solid"></span>'],
        });

        /*-------------------------------------------------------------------------*
         *                       11. Google Map js                                 *
         *-------------------------------------------------------------------------*/
        var myCenter = new google.maps.LatLng(23.8028085, 90.4070036);
        function initialize() {
            var mapProp = {
                zoom: 14,
                center: myCenter,
                scrollwheel: false,
                mapTpeIdy: google.maps.MapTypeId.ROADMAP,
            };
            var map = new google.maps.Map(document.getElementById("contactgoogleMap"), mapProp);
        }
        google.maps.event.addDomListener(window, "load", initialize);

        /*-------------------------------------------------------------------------*
         *                  12. Ajax Contact Form js                               *
         *-------------------------------------------------------------------------*/
        // Get the form.
        var form = $("#ajax-contact");

        // Get the messages div.
        var formMessages = $("#form-messages");

        // Set up an event listener for the contact form.
        $(form).on("submit", function (e) {
            // Stop the browser from submitting the form.
            e.preventDefault();

            // Serialize the form data.
            var formData = $(form).serialize();

            // Submit the form using AJAX.
            $.ajax({
                type: "POST",
                url: $(form).attr("action"),
                data: formData,
            })
                .done(function (response) {
                    // Make sure that the formMessages div has the 'success' class.
                    $(formMessages).removeClass("error");
                    $(formMessages).addClass("success");

                    // Set the message text.
                    $(formMessages).text(response);

                    // Clear the form.
                    $("#name").val("");
                    $("#email").val("");
                    $("#subject").val("");
                    $("#message").val("");
                })
                .fail(function (data) {
                    // Make sure that the formMessages div has the 'error' class.
                    $(formMessages).removeClass("success");
                    $(formMessages).addClass("error");

                    // Set the message text.
                    if (data.responseText !== "") {
                        $(formMessages).text(data.responseText);
                    } else {
                        $(formMessages).text("Oops! An error occured and your message could not be sent.");
                    }
                });
        });     
         /*-------------------------------------------------------------------------*
         *                   13. MailChimp js                                    *
         *-------------------------------------------------------------------------*/
        $("#mc-form").ajaxChimp({
            language: "en",
            callback: mailChimpResponse,

            // ADD YOUR MAILCHIMP URL BELOW HERE!
            url: "http://coderspoint.us14.list-manage.com/subscribe/post?u=e5d45c203261b0686dad32537&amp;id=d061f39c51",
        });

        function mailChimpResponse(resp) {
            if (resp.result === "success") {
                $(".mailchimp-success")
                    .html("" + resp.msg)
                    .fadeIn(900);
                $(".mailchimp-error").fadeOut(400);
            } else if (resp.result === "error") {
                $(".mailchimp-error")
                    .html("" + resp.msg)
                    .fadeIn(900);
            }
        }

        // Home Page Slider Settings
        $("#carousel-example-generic").carousel({
            interval: 6000,
            cycle: true,
        });
    }); // $(document).ready end
})(jQuery);

        /*-------------------------------------------------------------------------*
         *                   #. The End                                  *
         *-------------------------------------------------------------------------*/