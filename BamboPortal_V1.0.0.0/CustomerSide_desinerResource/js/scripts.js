/* ------------------------------------------------
---------------------------------------------------

    Minth's Main JavaScript Document
    Version: 1.5
    Created By: Amazyne Themes

---------------------------------------------------
--------------------------------------------------- */


/* ------------------------------------------------

    Navigation

--------------------------------------------------- */


/* ------------------------------------------------
    Responsive Scripts for Navigation
--------------------------------------------------- */


function navResponsive() {
    
    if (screenWidth > 991) {
        
        $(".main-nav .navbar-nav > .dropdown > a").attr("data-toggle", "");
        $(".main-nav .navbar-nav.nav-search > .dropdown > a").attr("data-toggle", "dropdown");
        $('.main-nav .navbar-nav > .dropdown').removeClass('open');
        $('.main-nav .navbar-nav .dropdown-submenu').removeClass('open');
        $('.main-nav .navbar-nav > li').find(':focus').blur();
        if ( $('.main-nav .navbar-collapse').hasClass('in') ) {
            $('.main-nav .navbar-collapse').removeClass('in');
        }
        if($('.navbar-toggle').hasClass('active')){
            $('.navbar-toggle').removeClass('active');
        }
        
    }
    else if  (screenWidth <= 991)  {
        
        $(".main-nav .navbar-nav > .dropdown > a").attr("data-toggle", "dropdown");
        $('.main-nav .nav > li .dropdown-menu').removeAttr('style');
        $('.main-nav .nav > li > .dropdown-menu').removeAttr('style');
        
    }
}


/* ------------------------------------------------
    Navigation's Click, Hover and Keyup Events
--------------------------------------------------- */


function navEvents() {
    
    /*---- Dropdown Menu Events ----*/
    
    $('.main-nav .navbar-nav > .dropdown > .dropdown-menu').click(function(event) {
        if(screenWidth <= 991) {
            event.stopPropagation();
        }
    });

    $( ".main-nav .navbar-nav>.dropdown>.dropdown-menu>.dropdown-submenu" ).click(function(event) {
        if(screenWidth < 991) {
            $this = $(this);
            $this.siblings(".dropdown-submenu").removeClass("open").end(); 
            $this.parents(".dropdown-submenu").addClass('open');
            $this.toggleClass('open');
            event.stopPropagation();
        }
    });

    $('.main-nav .navbar-nav > .dropdown > a').click(function(event) {
        $('.main-nav .navbar-nav .dropdown-submenu').removeClass('open');
    });	

    $('.navbar-toggle').click(function(event){
        $(this).toggleClass('active')
    })

    $('.main-nav .nav > li .dropdown-submenu > a').click(function(event) {
        if(screenWidth > 991) {
            event.stopPropagation();
        }
    });
    
	 window.setTimeout( function(){
		var rtl = $('html').attr('dir');
		if(rtl=='rtl'){
			
			$('.main-nav .nav > li .dropdown-submenu .dropdown-menu').each(function(){
				var $thisWidth = $(this).actual( 'outerWidth', { includeMargin : true });
				$(this).css('left','-'+$thisWidth+'px')
			});
		
		}
	}, 500);
	
    $('.main-nav .nav > li').hover(function() {
        var dropdownList = $(this).find("> .dropdown-menu");
		var $current = $(this);
        if (screenWidth > 991) {
            
            /*---- Dropdown Animation on Hover ----*/
    
            dropdownList.addClass('animated fadeIn');        
            window.setTimeout( function(){
                dropdownList.removeClass('animated fadeIn');
            }, 500);        

            /*---- Positioning Dropdown Menu ----*/
            
            if(!dropdownList.hasClass('megamenu')){
				
				var rtl = $('html').attr('dir');
				
				if(rtl=='rtl'){
					var childDropdownList = $(this).find(".dropdown-submenu .dropdown-menu"),
					dropdoOffset = $current.offset(),
					dropdownLinkWidth = $(this).width(),
					offLeft = dropdoOffset.left,
					dropdownLeft = dropdownList.offset().left,
					dropdownWidth = dropdownList.width(),
					dropWidth = dropdownWidth;
					offLeft = offLeft,
					childWidth = childDropdownList.width(),
					docWidth = $(window).width(),
					linkRightOffset = offLeft + dropdownWidth,
					aWidth = $(this).children("a").outerWidth(),
					shiftWidth = Math.abs(dropdownWidth - aWidth),
					childShiftWidth = dropdownWidth + dropdownLeft,
					isDropdownVisible = (dropWidth <= offLeft+ dropdownLinkWidth),
					isChildDropdownVisible = (dropdownWidth + childWidth <= offLeft+ dropdownLinkWidth);
					if (!isDropdownVisible) {
						var offToLeft = offLeft - 30;
						dropdownList.attr('style', 'right:auto!important; left:0!important');
						dropdownList.css('margin-left','-'+offToLeft+'px');
						childDropdownList.addClass('reversed');
					} else if (!isChildDropdownVisible) {
						childDropdownList.addClass('reversed');
					}
					else {
						dropdownList.removeAttr('style')
						childDropdownList.removeClass('reversed')
					}
				}
				
				else {
					var childDropdownList = $(this).find(".dropdown-submenu .dropdown-menu"),
					dropdownOffset = $(this).offset(),
					offsetLeft = dropdownOffset.left,
					dropdownWidth = dropdownList.width(),
					childWidth = childDropdownList.width(),
					docWidth = $(window).width(),
					aWidth = $(this).children("a").outerWidth(),
					shiftWidth = Math.abs(dropdownWidth - aWidth),
					childShiftWidth = dropdownWidth + childWidth - 1,
					isDropdownVisible = (offsetLeft + dropdownWidth <= docWidth),
					isChildDropdownVisible = (offsetLeft + dropdownWidth + childWidth <= docWidth);
					if (!isDropdownVisible) {
						dropdownList.css('margin-left','-'+shiftWidth+'px')
						childDropdownList.css('margin-left','-'+childShiftWidth+'px')
					} else if (!isChildDropdownVisible) {
						childDropdownList.css('margin-left','-'+childShiftWidth+'px')
					}
					else {
						dropdownList.removeAttr('style')
						childDropdownList.removeAttr('style')
					}
				}
                
            }
            
            /*---- Positioning Mega Menu ----*/
            
            else if(dropdownList.hasClass('megamenu')){
				
				var rtl = $('html').attr('dir');
				
				if(rtl=='rtl'){
					var dropdownOffset = $(this).offset(),
					linkWidth = $(this).width(),
					dropdownListOffset = dropdownList.offset(),
					offsetLeft = dropdownOffset.left,
					dropdownListoffsetLeft = dropdownListOffset.left,
					dropdownWidth = dropdownList.width(),
					docWidth = $(window).width(),
					shiftOffset = (($('.navigation').hasClass('transparent')) ? 30 : 30),
					positionedValue = Math.abs(shiftOffset),
					shiftWidth = Math.abs(positionedValue + dropdownWidth + shiftOffset),
					isDropdownVisible = (offsetLeft <= dropdownWidth);
					if (!isDropdownVisible) {
						calculateOffset = offsetLeft - dropdownWidth + linkWidth;
						dropdownList.css('left',+calculateOffset+'px');
					}
					else {
						dropdownList.css('left',+positionedValue+'px');
					}
				}
				
				else {
					var dropdownOffset = $(this).offset(),
					linkWidth = $(this).width(),
					dropdownListOffset = dropdownList.offset(),
					offsetLeft = dropdownOffset.left,
					dropdownListoffsetLeft = dropdownListOffset.left,
					dropdownWidth = dropdownList.width(),
					docWidth = $(window).width(),
					shiftOffset = (($('.navigation').hasClass('transparent')) ? 30 : 30),
					positionedValue = Math.abs(offsetLeft),
					shiftWidth = Math.abs(positionedValue + dropdownWidth + shiftOffset),
					isDropdownVisible = (shiftWidth <= docWidth);
					if (!isDropdownVisible) {
						calculateOffset = docWidth - dropdownWidth - shiftOffset;
						dropdownList.css('left',+calculateOffset+'px');
					}
					else {
						dropdownList.css('left',+positionedValue+'px');
					}
				}
            }
        }
    });
	
    /*---- Full-screen Menu Events ----*/
            
    $('.full-screen-menu-trigger').click(function(event) {
        event.preventDefault();
        $('.full-screen-header').fadeToggle();
        $(this).toggleClass('active');
        $('html, body').toggleClass('full-screen-header-active');
    });

    /*---- Side Menu Events ----*/
            
    $('.side-menu-trigger').click(function(event) {
        event.preventDefault();
        $(this).toggleClass('active');
        $('body').toggleClass('in');
        $('.side-header').toggleClass('active');
    });

    $(document).mouseup(function (e){
        var container = $(".main-nav");
        if (!container.is(e.target)&& container.has(e.target).length === 0 && $('.side-header').hasClass('active')) {
            $('.side-menu-trigger').removeClass('active');
            $('.side-header').removeClass('active');
            $('body').removeClass('in');
        }
    });
	
	$('.side-header-close').click(function(event){
        event.preventDefault();
        if ($('.side-header').hasClass('active')) {
            $('.side-menu-trigger').removeClass('active');
            $('.side-header').removeClass('active');
            $('body').removeClass('in');
        }
    });
	

    /*---- Sub-menu Events ----*/
            
    $( ".menu-dropdown-link" ).click(function(event) {
        $(this)
            .parent(".with-dropdown")
            .siblings(".with-dropdown")
            .children(".menu-dropdown.collapse")
            .removeClass("in")
            .end(); 
        $( this ).parents(".with-dropdown").children(".menu-dropdown.collapse").toggleClass('in');
        event.stopPropagation();
    });
	
    $('li.with-dropdown a.menu-dropdown-link').click(function () {
        var dh = $( this ).parents(".with-dropdown").children(".menu-dropdown.collapse").outerHeight();
        if(!$(this).hasClass('active-dropdown')) {
            $( this ).parents(".with-dropdown").children(".menu-dropdown.collapse").css('height',dh+'px');
        }
        else {
            $( this ).parents(".with-dropdown").children(".menu-dropdown.collapse").attr('style','');
        }
        $('.active-dropdown').not($(this)).removeClass('active-dropdown');
        $(this).toggleClass('active-dropdown');
    });

    /*---- Search Box Events ----*/
            
    $('.search-box-trigger').click(function(event) {
        if($(window).width() < 992) {
            if($('.navbar-collapse').hasClass('in')){
                $('.navbar-collapse').removeClass('in');
            }
        }
        event.preventDefault();
        $('.full-screen-search').fadeToggle();
        $(this).toggleClass('active');
    });

    $(".search-field").keyup(function (e) {
        if (e.keyCode == 13) {
            $('#searchForm').submit();
        }
    });
	
}


if(document.getElementsByClassName('corner-navigation') || document.getElementsByClassName('.padded-fixed-footer')){
    window.addEventListener('scroll', function(e){
        if ($(window).scrollTop() > 50){
            $('.corner-navigation, .padded-fixed-footer').addClass('fill-in');
        }
        else{
            $('.corner-navigation, .padded-fixed-footer').removeClass('fill-in');
        }
    });
}


/* ------------------------------------------------
    Sticky Navigation
--------------------------------------------------- */


/*---- Sticky Nav's Global Variables ----*/

var headerHeight = 0,
    headerVisiblePos = 0,
	headerFixedPos = 0,
	isHeaderFixed = false,
	isHeaderVisible = false;

function stickyMenu(){
    if($('.main-nav').hasClass('sticky')){
        window.addEventListener('scroll', function(e){
            var screenTop = $(window).scrollTop();
            if (screenTop > 0 ) {
                $('.main-nav').addClass('shrink');
            }
            if (screenTop <= 0 ) {
                $('.main-nav').removeClass('shrink');
            }
        });
		var screenTop = $(window).scrollTop();
		if (screenTop > 0 ) {
			$('.main-nav').addClass('shrink');
		}
    }
}


/* ------------------------------------------------
    One Page Navigation
--------------------------------------------------- */


function navOnePage() {
    if( $('body').hasClass('one-page')){	
        var offset = 0,
			delay =0;
        var $sections = $('.one-page-section');
        if($('.main-nav').hasClass('sticky')){
            offset = 60;
        }
		if($('body').find('.owl-carousel.one-page-section')){
            delay = 800;
        }
		else {
			delay = 100;
		}
		window.setTimeout(function() {
			sectionOffset();
		}, delay);
		function sectionOffset(){
            var currentScroll = $(this).scrollTop() + offset;
            var $currentSection;
            $sections.each(function(){
                var divPosition = $(this).offset().top;
                var divHeight = $(this).outerHeight();
                var total = divPosition + divHeight;
                if($(window).scrollTop() + screenHeight >= $(document).height() - offset) {
                    $currentSection = $sections.last();
                }
                else if( divPosition - 1 < currentScroll ){
                    $currentSection = $(this);
                }
            });
            var id = $currentSection.attr('id');
            $('.main-nav .nav > li').removeClass('active');
            $("[href=#"+id+"]").parent('li').addClass('active');
        }
		var timer;  
        $(window).scroll(function(){
            if(timer){
                sectionOffset();
            }
            else {
                timer = window.setTimeout(function() {
                    sectionOffset();
                }, 100);
            }
        });
        var scrollActive = '';
        $('.main-nav .nav li a[href*=#]:not([href=#])').click(function() {
            if(scrollActive == true) {
                event.preventDefault();	
            }
            else {
                var offset = 59;
                scrollActive = true;
                if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
                    if (target.length) {
                        $('html,body').animate({
                            scrollTop: target.offset().top - offset
                        }, 1000, "easeInQuart" , function() {
                            scrollActive = false;
                        });
                        return false;
                    }
                }
            }
        });
    }
}


/* ------------------------------------------------

    Footer Reveal

--------------------------------------------------- */


function fixedFooter() {
    var footerHeight = $('.uncover-footer').outerHeight();
    $('.footer-reveal').css('height',footerHeight + 'px');
}


/* ------------------------------------------------

    Centred Modal Box

--------------------------------------------------- */


function centerModal() {
    if ($(window).height() >= 320){
        adjustModal();
    }
}
function adjustModal(){
    $('.modal').each(function(){
        if($(this).hasClass('in') == false){
            $(this).show();
        };
        var contentHeight = $(window).height() - 60;
        var headerHeight = $(this).find('.modal-header').outerHeight() || 2;
        var footerHeight = $(this).find('.modal-footer').outerHeight() || 2;
        $(this).find('.modal-content').css({
            'max-height': function () {
                return contentHeight;
            }
        });
        $(this).find('.modal-body').css({
            'max-height': function () {
                return (contentHeight - (headerHeight + footerHeight));
            }
        });
        $(this).find('.modal-dialog').addClass('modal-dialog-center').css({
            'margin-top': function () {
                return -($(this).outerHeight() / 2);
            },
            'margin-left': function () {
                return -($(this).outerWidth() / 2);
            }
        });
        if($(this).hasClass('in') == false){
            $(this).hide();
        };
    });
};


/* ------------------------------------------------

    Floating Sidebar

--------------------------------------------------- */


/*---- Sidebar's Global Variables ----*/


var isStickyElementFixed = false,
    stickyElementSetPoint = 0,
    stickyElementY = 0,
    screenWidth =  window.innerWidth,
    screenHeight = window.innerHeight, 
    stickyElementDisabled = false,
    winScrollY = 0,
    stickyElementTop = 0;

function stickElement() {
    if (document.getElementById('stickyElement')) {
        var elementW = $('.stickyElement').width(),
            relElement = $('.stick-to-side').offset().top + $('.stick-to-side').height(),
            elementW = $('.stickyElement').width(),
            elementH = $('.stickyElement').parent().height(),
            stickyContainer = document.getElementById("sticky-container");
            stickyContainer.style.width = elementW + 'px';
            stickyElementY = $('.stickyElement').offset().top - 60;
            stickyElementSetPoint = relElement - elementH - 60;
            stickyElementTop = $('.stick-to-side').innerHeight() -elementH;
        if (screenWidth < 991) {
            $('.stickyElement').removeClass('stickTop');
            $('.stickyElement').removeAttr('style');
        }
        else if ($(window).scrollTop() > stickyElementSetPoint) {
            $('.stickyElement').removeAttr('style');	
            isStickyElementFixed = false;
        }
        window.addEventListener('scroll', function(e){
            winScrollY = $(window).scrollTop();
            if(screenWidth > 991) {
                if((winScrollY > stickyElementY) && (winScrollY<stickyElementSetPoint)){
                    $('.stickyElement').addClass('stickTop');
                    $('.stickyElement').removeAttr('style');
                    isStickyElementFixed = false;
                }
                else if(winScrollY > stickyElementSetPoint && !isStickyElementFixed){
                    $('.stickyElement').removeClass('stickTop');
                    $('.stickyElement').attr('style','position:absolute; top:'+stickyElementTop+'px');
                    isStickyElementFixed = true;
                }
                else if(winScrollY < stickyElementY){
                    $('.stickyElement').removeClass('stickTop');
                    isStickyElementFixed = false;
                }
            }
            else if ((screenWidth < 991) && (!stickyElementDisabled)) {
                $('.stickyElement').removeClass('stickTop');
                $('.stickyElement').removeAttr('style');
                stickyElementDisabled = true;
            }
        });
    }
}


/* ------------------------------------------------

    Vertically Centred Elements

--------------------------------------------------- */


function verticallyCentered(){
    if(document.getElementsByClassName("vertical-centred-element")){
        $('.vertical-centred-element').each(function(){
            var $this = $(this),
                height = 0,
                width = 0,
                margin = 0;
            if($this.hasClass('flipped-vertical')){
                width = $this.outerWidth();
                margin = width/2;
                $this.css('margin-top',margin+'px');
            }
        });
    }
}


/* ------------------------------------------------

    Fixed Social Icons

--------------------------------------------------- */


function fixedSocialIcons () {
    var containerH = $('.social-fixed').outerHeight();
    var marginTop = containerH / 2;	
    $('.social-fixed').css('margin-top','-'+ marginTop + 'px');
}


/* ------------------------------------------------

    Coming Soon

--------------------------------------------------- */


$('.section-trigger').click(function(e){
    e.preventDefault();
    var $this = $(this);
    var $section = $('.coming-soon-sections.active-section');
    if($section.hasClass('intro')) {
        if($this.hasClass('home')) {
            return;
        }
        else {
            $('.section-trigger').parents('li').removeClass('active');
            $this.parent('li').addClass('active');
            $section.removeClass('active-section').fadeOut();
        }
    }
    else if($section.hasClass('about')) {
        if($this.hasClass('about')) {
            return;
        }
        else {
            $('.section-trigger').parents('li').removeClass('active');
            $this.parent('li').addClass('active');
            $section.removeClass('active-section').fadeOut();
        }
    }
    else if($section.hasClass('contact-section')) {
        if($this.hasClass('contact-section')) {
            return;
        }
        else {
            $('.section-trigger').parents('li').removeClass('active');
            $this.parent('li').addClass('active');
            $section.removeClass('active-section').fadeOut();
        }
    }
    else if($section.hasClass('login')) {
        if($this.hasClass('login')) {
            return;
        }
        else {
            $('.section-trigger').parents('li').removeClass('active');
            $this.parent('li').addClass('active');
            $section.removeClass('active-section').fadeOut();
        }
    }
    if($this.hasClass('home')){
        $('.intro').delay(1000).addClass('active-section').fadeIn();
    }
    else if($this.hasClass('contact-section')){
        $('.contact-section').delay(1000).addClass('active-section').fadeIn();
    }
    else if($this.hasClass('about')){
        $('.about').delay(1000).addClass('active-section').fadeIn();
    }
    else if($this.hasClass('login')){
        $('.login').delay(1000).addClass('active-section').fadeIn();
    }
    if(!$this.hasClass('btn')){
        $('.full-screen-header').fadeToggle();
        $('.full-screen-menu-trigger').toggleClass('active');
        $(".loader").fadeIn("slow");
        setTimeout(function(){ $(".loader").fadeOut("slow"); }, 1000);
    }
    else if($this.hasClass('btn')){
        $(".loader").fadeIn("slow");
        setTimeout(function(){ $(".loader").fadeOut("slow"); }, 1000);
    }
});


/* ------------------------------------------------

    Shop

--------------------------------------------------- */


/* ------------------------------------------------
    Shopping Cart
--------------------------------------------------- */


function shoppingCart () {
    if(document.getElementsByClassName("shopping-cart-slide")){
        var shoppingCartHeight = $('.shopping-cart-slide').outerHeight(),
        cartTitleHeight = $('.shopping-cart-slide').find('.title').outerHeight(),
        cartFooterHeight = $('.shopping-cart-slide').find('.cart-footer').outerHeight(),
        cartItemsHeight = shoppingCartHeight - cartTitleHeight - cartFooterHeight;
        $('.shopping-cart-slide').find('.cart-items').css('max-height', cartItemsHeight+'px');
    }
}


/* ------------------------------------------------
    Shop Slider
--------------------------------------------------- */


$('.thumb').click(function(){
    $('.thumb').removeClass('thumb-active');
    $(this).addClass('thumb-active');
});

function shopSlider() {
    if(document.getElementById('shop-carousel')) {
        var itemCount = $('#shop-carousel .item').length;
        $( ".carousel-control" ).click(function(e) {
            if($(this).hasClass('left')){
                var index = $('div.item.active').index();
                toSlideleft = index;
                if(toSlideleft < 1) {
                    toSlideleft = itemCount;
                }
                $('.shop-thumbnails li a').removeClass('thumb-active');
                $('.shop-thumbnails li:nth-child('+toSlideleft+') a').addClass('thumb-active');
            }
            else if($(this).hasClass('right')){
                var index = $('div.item.active').index();
                toSlide = index + 2;
                if(toSlide > itemCount) {
                    toSlide = 1;
                }
                $('.shop-thumbnails li a').removeClass('thumb-active');
                $('.shop-thumbnails li:nth-child('+toSlide+') a').addClass('thumb-active');
            }
        });
    }
}


/* ------------------------------------------------
    Shop's Click & Keyup Events
--------------------------------------------------- */


/*---- Shopping Cart Events ----*/

$('.shopping-cart-trigger').click(function(event) {
    event.preventDefault();
    $('.shopping-cart-slide').toggleClass('active');
});
$(document).mouseup(function (e) {
    var container = $(".main-nav, .shopping-cart-slide");
    if (!container.is(e.target)
        && container.has(e.target).length === 0
        && $('.shopping-cart-slide').hasClass('active')) {
        $('.shopping-cart-slide').removeClass('active');
    }
});

/*---- Coupon Code ----*/

$('a.coupon-trigger').click(function() {
	$('.inner.coupon-code').slideToggle();
});

/*---- Checkout Form's Conditional Fields ----*/

$('input:checkbox[name=existingAddress]').click(function() {
    if ($(this).is(':checked')) {
    $("#addressForm :input").not('button').prop("disabled", true);
        $(this).prop("disabled", false);
    }
    else {
        $("#addressForm :input").prop("disabled", false);
    }
});
$('input:radio[name=paymentOptions]').click(function(){
    var val = $('input:radio[name=paymentOptions]:checked').val();
    if (val == 1) {
        $("#paymentForm :input").prop("disabled", false);
        $(".btn-card-type").removeAttr("style");	
    }
    else {
        $("#paymentForm :input").not('button').prop("disabled", true);
        $(".btn-card-type").attr("style","pointer-events: none; opacity:.65");
    }
});


/* ------------------------------------------------

    Theme Background Section

--------------------------------------------------- */


function themeImageSection () {
    var fullScreenImage = document.getElementsByClassName("theme-background-section");
    if(document.getElementsByClassName("theme-background-section")){
        var windowH = window.innerHeight;
        $('.theme-background-section').each(function(){ 
            $selection =  $(this);
            if($selection.hasClass('custom-height')) {
                var customHeight = $selection.attr('data-custom-height');
                if (typeof customHeight !== typeof undefined && customHeight !== false && customHeight !== '') {
                    var decCustomHeight = customHeight/100;
                    windowH = windowH * decCustomHeight;
                }
            }
            else if($selection.hasClass('half-screen')){
                windowH = windowH/2;
            }
            else if($selection.hasClass('half-screen-width')){
                windowW = screenWidth/2;
                $selection.css('width', windowW + 'px');
            }
            else {
                var offsetContainer = $selection.attr('data-offset-container');
                if (typeof offsetContainer !== typeof undefined && offsetContainer !== false && offsetContainer !== '' && screenWidth > 767) {
                    var containerArray = offsetContainer.split(",");
                    var i, offsetHeight = 0, currentContainer;
                    for (i = 0; i < containerArray.length; i++) { 
                        currentContainer = String(containerArray[i]);
                        offsetHeight += $(currentContainer).outerHeight();
                    }
                    windowH = windowH - offsetHeight;
                }
            }
            if($selection.find('.content-container').outerHeight() > windowH) {
                $selection.css('height', 'auto');
                $selection.find('.fade-scroll').removeClass('fade-scroll');
            }
            else {
                $selection.css('height', windowH + 'px');
            }
            if($selection.closest(".owl-carousel").length ) {
                window.setTimeout(function(){
                    if($selection.find('.content-container').outerHeight() > windowH) {
                        $('.theme-background-section').css('height', 'auto');
                        $('.theme-background-section').find('.fade-scroll').removeClass('fade-scroll').addClass('no-fade-scroll');
                    }
                    else {
                        $('.theme-background-section').css('height', windowH + 'px');
                        $('.theme-background-section').find('.no-fade-scroll').removeClass('no-fade-scroll').addClass('fade-scroll');
                    }
                },300);
            }
            $(window).scroll(function(){
                $(".fade-scroll").css("opacity", 1 - $(window).scrollTop() / (windowH/2));
            });
        });
    }
}


/* ------------------------------------------------

    Sections Height

--------------------------------------------------- */


function sectionHeights(){
    if(document.getElementsByClassName('full-height')){
        $('.full-height').each(function(){
            $section  = $(this);
            if($section.hasClass('slider-item')){
                var offsetContainer = $section.closest('.owl-carousel').attr('data-offset-container');
                var dataOffsetHeight = $section.closest('.owl-carousel').attr('data-offset-height');
                if (typeof offsetContainer !== typeof undefined && offsetContainer !== false && offsetContainer !== '' && screenWidth > 767) {
                    var containerArray = offsetContainer.split(",");
                    var i, offsetHeight = 0, currentContainer;
                    for (i = 0; i < containerArray.length; i++) { 
                        currentContainer = String(containerArray[i]);
                        offsetHeight += $(currentContainer).outerHeight();
                    }
                    windowH = screenHeight - offsetHeight;
                    $section.css('height', windowH + 'px');
                }
                else if (typeof dataOffsetHeight !== typeof undefined && dataOffsetHeight !== false && dataOffsetHeight !== '' && screenWidth > 767) {
                    windowH = screenHeight - dataOffsetHeight;
                    $section.css('height', windowH + 'px');
                }
                else {
                     windowH = screenHeight;
                     $section.css('height', windowH + 'px');
                }   
            }
            else{
                var offsetContainer = $section.attr('data-offset-container');
                var dataOffsetHeight = $section.closest('.owl-carousel').attr('data-offset-height');
                if ($('.content-container').height() > screenHeight){
                    $section.css('height', 'auto');
                }
                else if (typeof offsetContainer !== typeof undefined && offsetContainer !== false && offsetContainer !== '' && screenWidth > 767) {
                    var containerArray = offsetContainer.split(",");
                    var i, offsetHeight = 0, currentContainer;
                    for (i = 0; i < containerArray.length; i++) { 
                        currentContainer = String(containerArray[i]);
                        offsetHeight += $(currentContainer).outerHeight();
                    }
                    windowH = screenHeight - offsetHeight;
                    $section.css('height', windowH + 'px');
                }
                else if (typeof dataOffsetHeight !== typeof undefined && dataOffsetHeight !== false && dataOffsetHeight !== '' && screenWidth > 767) {
                    windowH = screenHeight - dataOffsetHeight;
                    $section.css('height', windowH + 'px');
                }
                else if (screenWidth < 767){
                    $section.css('height', 'auto');
                }
                else {
                    $section.css('height', screenHeight + 'px');
                }
            }
        });
    }
}


/* ------------------------------------------------

    Initializing Plugins & Elements

--------------------------------------------------- */


/* ------------------------------------------------
    Init Owl Carousel
--------------------------------------------------- */


function owlC() {
    $(".owl-carousel").each(function (index) {
    var items_no = $(this).data('items');
	var items_no_desktop = $(this).data('items-desktop');
	var items_no_tablet = $(this).data('items-tablet');
	var items_no_mobile = $(this).data('items-mobile');
    var auto_play = $(this).data('auto-play');
	var auto_play_speed = $(this).data('auto-play-speed');
	var navigation = $(this).data('navigation');
	var navigation_speed = $(this).data('navigation-speed');
	var pagination = $(this).data('pagination');
	var pagination_speed = $(this).data('pagination-speed');
	var hover_stop = $(this).data('stop-on-hover');	
	var auto_height = $(this).data('auto-height');
	var animate_in = $(this).data('animate-in');
	var animate_out = $(this).data('animate-out');
    $(this).owlCarousel({ // use $(this)
		rtl:true,
		loop:true,
        navText: [
            "<i class='fa fa-angle-right'></i>",
            "<i class='fa fa-angle-left'></i>"
        ],
        items:items_no,
		autoHeight:auto_height,
        autoplay:auto_play,
		autoplaySpeed:auto_play_speed,
		nav:navigation,
		navSpeed:navigation_speed,
		dots:pagination,
		dotsSpeed:pagination_speed,
		animateIn:animate_in,
		animateOut:animate_out,
		responsive:{
        0:{
            items:items_no_mobile
        },
        768:{
            items:items_no_tablet
        },
        992:{
            items:items_no_desktop
        }
    }
    });
});	
}






/* ------------------------------------------------
    Init Counters
--------------------------------------------------- */


function counters() {
    $('.counter').counterUp({
        delay: 10,
        time: 2333
    });	
}


/* ------------------------------------------------
    Init Isotope
--------------------------------------------------- */


function isotope() {
    if ( document.querySelector('body').offsetHeight > window.innerHeight ) {
        document.documentElement.style.overflowY = 'scroll';
    }
    var $container = $('.js-isotope');
    $container.isotope({
        filter: '*',
		isOriginLeft: false,
        animationOptions: {
            duration: 750,
            easing: 'linear',
            queue: false
        }
    });
    var $container2 = $('.filterArea');
    $container2.isotope({
        filter: '*',
		isOriginLeft: false,
        animationOptions: {
            duration: 750,
            easing: 'linear',
            queue: false
        }
    });
    $('.filter a').click(function(){
        $('.filter .current').removeClass('current');
        $(this).addClass('current');
        var selector = $(this).attr('data-filter');
        $container2.isotope({
            filter: selector,
            animationOptions: {
                duration: 750,
                easing: 'linear',
                queue: false
            }
        });
        return false;
    });
}


/* ------------------------------------------------
    Init Parallax Scroll
--------------------------------------------------- */


function parallaxImages() {
    if(document.getElementsByClassName("parallax")){
        $('.parallax').each(function(){
            $(this).parallax("50%", .2);
        });
    }
}


/* ------------------------------------------------
    Init Invert Scroll
--------------------------------------------------- */


function invertScroll(){
    if( $('body').hasClass('invert-scroll')){	
        if(screenWidth > 991){
            $.jInvertScroll(['.scroll'],{
                height: '7200',
                width: 'auto'
            });
        }
    }
}


/* ------------------------------------------------
    Init Nivo Lightbox
--------------------------------------------------- */


function nivoLightbox() {
    $('a').nivoLightbox();
}


/* ------------------------------------------------
    Init Wow
--------------------------------------------------- */


function wowInit() {
    var wow = new WOW({
        //disabled for mobile
        mobile: false
    });
    wow.init();
}


/* ------------------------------------------------
    Init Bootstrap Carousel
--------------------------------------------------- */


$('.carousel').carousel({
    interval: false
});


/* ------------------------------------------------
    Init Progress Bars
--------------------------------------------------- */


function progressBarsOnView() {
    $('div.progress-bar').waypoint(function(){
        $(this).css('width', $(this).attr('aria-valuenow')+'%');
    }, {
        offset: '100%'
    });	
}


/* ------------------------------------------------
    Init Countdown
--------------------------------------------------- */


function countDown() {
    if(document.getElementById('countdown')){
        $('#countdown').countdown('2017/01/01', function(event) {
        $(this).html(event.strftime('<i>Launching in %w weeks and %d days</i>'));
      });
    }
}


/* ------------------------------------------------
    Init Recent Tweets
--------------------------------------------------- */


function tweets () {
    if (document.getElementById('recentTweets')) {
        !function(d,s,id){
            var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';
            if(!d.getElementById(id)){
                js=d.createElement(s);js.id=id;js.src=p+"://platform.twitter.com/widgets.js";
                fjs.parentNode.insertBefore(js,fjs);
            }
        }(document,"script","twitter-wjs");
    }
}


/* ------------------------------------------------
    Init Dribble Shots
--------------------------------------------------- */


function dribbleShots () {
    if (document.getElementById('shotsByPlayerId')) {
        var callback = function (playerShots) {
            var html = '';
            $.each(playerShots.shots, function (i, shot) {
                html += '<a target="_blank" href="' + shot.url + '">';
                html += '<img src="' + shot.image_url + '" ';
                html += 'alt="' + shot.title + '"></a>';
            });
            $('#shotsByPlayerId').html(html);
        };
        $.jribbble.getShotsByPlayerId('envato', callback, {page: 1, per_page: 15});
    }
}


/* ------------------------------------------------
    Init Instagram Feed
--------------------------------------------------- */


function instagramFeed () {
    if (document.getElementById('widget-instagram')) {
        var userFeed = new Instafeed({
            get: 'user',
            userId: 1555075289,
            useHttp: true,
            limit: 5,
            target: 'widget-instagram',
            accessToken: '1555075289.1677ed0.d62c13234461442b88f353a895b591a4',
            template: '<a target="_blank" href="{{link}}"><img src="{{image}}" /></a>'
        });
        userFeed.run();
    }
}


/* ------------------------------------------------
    Init Flickr Thumbnails
--------------------------------------------------- */


function flickrThumbnails () {
    $('.photo-link').attr('target','_blank')
}


/* ------------------------------------------------
    Init Tooltips
--------------------------------------------------- */


function tooltip() {
    $(".tip-top").tooltip({
        placement : 'top',
        container : 'body'
    });
    $(".tip-right").tooltip({
        placement : 'right',
        container : 'body'
    });
    $(".tip-bottom").tooltip({
        placement : 'bottom',
        container : 'body'
    });
    $(".tip-left").tooltip({
        placement : 'left',
        container : 'body'
    });	
}


/* ------------------------------------------------
    Init Parallax Container
--------------------------------------------------- */


function parallaxContainer() {
    
    $window = $(window);
    
    $('.parallax-contain').each(function(){
        var $scroll = $(this);
        $(window).scroll(function() {
            $scroll.css('top',$window.scrollTop() * .50 +'px')
            $scroll.css('opacity', 1- $window.scrollTop() * .0010)
        });
    });
    
}


/* ------------------------------------------------
    Init Google Map
--------------------------------------------------- */


function defaultMap() {
    if(document.getElementById('location-map')) {
        var image = 'images/map-pin.png';
        var mapOptions = {

            /*---- Map Location (Latitude,Longitude) ----*/

            center: new google.maps.LatLng(40.7903, -73.9597),
            zoom: 15,
            zoomControl:false,
            zoomControlOptions: {
                style:google.maps.ZoomControlStyle.SMALL
            },
            panControl:false,
            mapTypeControl:false,
            scaleControl:false,
            streetViewControl:false,
            overviewMapControl:false,
            rotateControl:false,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP,

            /*---- Map Style ----*/

            styles: [{"stylers":[{"visibility":"simplified"}]},{"stylers":[{"color":"#131314"}]},{"featureType":"water","stylers":[{"color":"#131313"},{"lightness":7}]},{"elementType":"labels.text.fill","stylers":[{"visibility":"on"},{"lightness":25}]}]
        };

        /*---- Plotting Map ----*/

        var map = new google.maps.Map(document.getElementById('location-map'), mapOptions);

        /*---- Setting Marker ----*/

        var mapMarker = new google.maps.Marker({
			position: map.getCenter(),
			map: map,
			icon: image
		});
    }
    
    /*---- Map with Pin Offset ----*/

    else if(document.getElementById('location-map-2')) {
        var image = 'images/map-pin.png';
        var mapOptions = {

            /*---- Map Location (Latitude,Longitude) ----*/

            center: new google.maps.LatLng(40.7903, -73.9597),
            zoom: 15,
            zoomControl:false,
            zoomControlOptions: {
                style:google.maps.ZoomControlStyle.SMALL
            },
            panControl:false,
            mapTypeControl:false,
            scaleControl:false,
            streetViewControl:false,
            overviewMapControl:false,
            rotateControl:false,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP,

            /*---- Map Style ----*/

            styles: [{"stylers":[{"visibility":"simplified"}]},{"stylers":[{"color":"#131314"}]},{"featureType":"water","stylers":[{"color":"#131313"},{"lightness":7}]},{"elementType":"labels.text.fill","stylers":[{"visibility":"on"},{"lightness":25}]}]
        };

        /*---- Plotting Map ----*/

        var map = new google.maps.Map(document.getElementById('location-map-2'), mapOptions);
        map.panBy(-300, 0);

        /*---- Setting Marker ----*/

        var mapMarker = new google.maps.Marker({
			position: map.getCenter(),
			map: map,
			icon: image
		});
    }
    
    /*---- Map with Default Pin ----*/

    else if(document.getElementById('location-map-3')) {
        var mapOptions = {

            /*---- Map Location (Latitude,Longitude) ----*/

            center: new google.maps.LatLng(40.7903, -73.9597),
            zoom: 15,
            zoomControl:false,
            zoomControlOptions: {
                style:google.maps.ZoomControlStyle.SMALL
            },
            panControl:false,
            mapTypeControl:false,
            scaleControl:false,
            streetViewControl:false,
            overviewMapControl:false,
            rotateControl:false,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP,

            /*---- Map Style ----*/

            styles: [{"stylers":[{"visibility":"simplified"}]},{"stylers":[{"color":"#131314"}]},{"featureType":"water","stylers":[{"color":"#131313"},{"lightness":7}]},{"elementType":"labels.text.fill","stylers":[{"visibility":"on"},{"lightness":25}]}]
        };

        /*---- Plotting Map ----*/

        var map = new google.maps.Map(document.getElementById('location-map-3'), mapOptions);
     
        /*---- Setting Marker ----*/

        var mapMarker = new google.maps.Marker({
			position: map.getCenter(),
			map: map
		});
    }
    
    /*---- Map without Pin ----*/

    else if(document.getElementById('location-map-4')) {
        var mapOptions = {

            /*---- Map Location (Latitude,Longitude) ----*/

            center: new google.maps.LatLng(40.7903, -73.9597),
            zoom: 15,
            zoomControl:false,
            zoomControlOptions: {
                style:google.maps.ZoomControlStyle.SMALL
            },
            panControl:false,
            mapTypeControl:false,
            scaleControl:false,
            streetViewControl:false,
            overviewMapControl:false,
            rotateControl:false,
            scrollwheel: false,
            mapTypeId: google.maps.MapTypeId.ROADMAP,

            /*---- Map Style ----*/

            styles: [{"stylers":[{"visibility":"simplified"}]},{"stylers":[{"color":"#131314"}]},{"featureType":"water","stylers":[{"color":"#131313"},{"lightness":7}]},{"elementType":"labels.text.fill","stylers":[{"visibility":"on"},{"lightness":25}]}]
        };

        /*---- Plotting Map ----*/

        var map = new google.maps.Map(document.getElementById('location-map-4'), mapOptions);
     
    }
    
    
}


/* ------------------------------------------------

    Click Events

--------------------------------------------------- */


/* ------------------------------------------------
    # Links
--------------------------------------------------- */


$('a').click(function(e) {
    var link = $(this).attr('href');
    if(link == '#'){
        e.preventDefault();
    }
});


/* ------------------------------------------------
    Jump Links
--------------------------------------------------- */


$('a[href*=#]:not([href=#]).jump').click(function() {
    if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
        var jumpOffset = 0;
        if($(this).attr('data-jump-offset')){
            jumpOffset = $(this).attr('data-jump-offset');
        }
        var target = $(this.hash);
        target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
        if (target.length) {
            $('html,body').animate({
                scrollTop: target.offset().top - jumpOffset
            }, 1000, "easeInQuart");
            return false;
        }
    }
});


/* ------------------------------------------------
    Expandable Section
--------------------------------------------------- */


$('.expandable-section a.expansion-trigger').click(function(e){
    e.preventDefault();
    if($(this).hasClass('down')) {
        $('.section-expand').slideDown();
        $('.expandable-section a.expansion-trigger.down, .expandable-section .expansion-text.exp').hide();
        $('.expandable-section a.expansion-trigger.up, .expandable-section .expansion-text.cls').fadeIn();
    }
    else if($(this).hasClass('up')) {
        $('.section-expand').slideUp();
        $('.expandable-section a.expansion-trigger.up, .expandable-section .expansion-text.cls').hide();
        $('.expandable-section a.expansion-trigger.down, .expandable-section .expansion-text.exp').fadeIn();

    }
});


/* ------------------------------------------------

    Contact Form Validation

--------------------------------------------------- */


function formValidation() {
	
    generateCaptcha();

    
/* ------------------------------------------------
    Init Contact Form
--------------------------------------------------- */


    $('#contactForm').formValidation({
        framework: 'bootstrap',
        
        /*---- Feedback Icons ----*/
    
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        
        /*---- Fields to be Validated ----*/
    
        fields: {
            firstName: {
                validators: {
                    notEmpty: {
                        message: 'The first name is required'
                    }
                }
            },
            lastName: {
                validators: {
                    notEmpty: {
                        message: 'The last name is required'
                    }
                }
            },
            phoneNumber: {
                validators: {
                    notEmpty: {
                        message: 'The phone number is required'
                    },
                    regexp: {
                        message: 'The phone number can only contain the digits, spaces, -, (, ), + and .',
                        regexp: /^[0-9\s\-()+\.]+$/
                    }
                }
            },
            company: {
                validators: {
                    stringLength: {
                        max: 50,
                        message: 'Company name must be less than 50 characters long'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'The email address is required'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    }
                }
            },
            msg: {
                validators: {
                    notEmpty: {
                        message: 'The message is required'
                    },
                    stringLength: {
                        max: 700,
                        message: 'The message must be less than 700 characters long'
                    }
                }
            },
            captcha: {
                validators: {
                    callback: {
                        message: 'Wrong answer',
                        callback: function(value, validator, $field) {
                            var items = $('#captchaOperation').html().split(' '),
                            sum   = parseInt(items[0]) + parseInt(items[2]);
                            return value == sum;
                        }
                    }
                }
            }
        }
    })
    .on('err.form.fv', function(e) {
        generateCaptcha();
    })
    .on('success.form.fv', function(e) {
        
        /*---- Ajax Code for Submitting Form ----*/
    
        e.preventDefault();
        var $form = $(e.target),
        id = $form.attr('id'),
        thisForm = '#'+id;
        $('.form-loader', thisForm).fadeIn();
        $.post($form.attr('action'), $form.serialize(), function(result) {}, 'json')
        .done(function() {
            $('.form-loader', thisForm).fadeOut();
            var output = document.getElementById('formResponse');
            output.innerHTML = 'Thank you for your message. We will get back to you shortly';
            $('#formResponse').addClass('alert-theme-success').fadeIn();
        })
        .fail(function() {
            $('.form-loader', thisForm).fadeOut();
            var output = document.getElementById('formResponse');
            output.innerHTML = 'We are experiencing some problems. Please try again later'
            $('#formResponse').addClass('alert-theme-danger').fadeIn();
        });
    });

    
/* ------------------------------------------------
    Init Footer Newsletter Form
--------------------------------------------------- */


    $('#footerNewsletterForm').formValidation({
        framework: 'bootstrap',
        
        /*---- Feedback Icons ----*/
    
        icon: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        
        /*---- Fields to be Validated ----*/
    
        fields: {
            newsletterEmail: {
                validators: {
                    notEmpty: {
                        message: 'The email address is required'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    }
                }
            },
        }
    });
    
    $('#newsletterForm').formValidation({
        framework: 'bootstrap',
        icon: false,
        fields: {
            newsletterEmail: {
                validators: {
                    notEmpty: {
                        message: 'The email address is required'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    }
                }
            },
        }
    });
}


/* ------------------------------------------------
    Generate Captcha Codes
--------------------------------------------------- */
 
 
function randomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

function generateCaptcha() {
    $('#captchaOperation').html([randomNumber(1, 100), '+', randomNumber(1, 200), '='].join(' '));
}


/* ------------------------------------------------
    Demo Panel
--------------------------------------------------- */


$('.demo-panel-button').click(function(e){
	e.preventDefault();
	$('.demo-panel').toggleClass('active');
})

$('.switch-dir').click(function(e){
    e.preventDefault();
	var filename = window.location.href.substr(window.location.href.lastIndexOf("/")+1);
	$url = 'http://minth.amazyne.com/v-1.7/'+filename;
	window.location.replace($url);
});

$('.color-switch').click(function(e){
    e.preventDefault();
	var filename = window.location.href.substr(window.location.href.lastIndexOf("/")+1);
    if($(this).hasClass('default')){
        $url = 'http://minth.amazyne.com/v-1.7/rtl/'+filename;
    }
    else if($(this).hasClass('green')){
        $url = 'http://minth.amazyne.com/v-1.7/rtl/green/'+filename;
    }
    else if($(this).hasClass('red')){
        $url = 'http://minth.amazyne.com/v-1.7/rtl/red/'+filename;
    }
    if($(this).hasClass('blue')){
        $url = 'http://minth.amazyne.com/v-1.7/rtl/blue/'+filename;
    }
    window.location.replace($url);
});


/* ------------------------------------------------

    Function Calls

--------------------------------------------------- */


var $win = $(window);


/* ------------------------------------------------
    Window Resize Events
--------------------------------------------------- */
  
  
$win.on('resize', function() {
    
    /*---- Resetting Variables ----*/
	
    isStickyElementFixed = false;
    winScrollY = 0;
    stickyElementSetPoint = 0;
    stickyElementY = 0;
    screenWidth =  window.innerWidth;
    screenHeight =  window.innerHeight;
    winScrollY = 0;
    stickyElementTop = 0;
    stickyElementDisabled = false;
    headerVisiblePos = 0;
    headerFixedPos = 0;
    isHeaderFixed = false;
    isHeaderVisible = false;
    headerHeight = 0;
    
    countDown();

    navResponsive();

    navOnePage();

    setTimeout(centerModal, 800)

    setTimeout(stickElement, 3000)

	stickyMenu();

    setTimeout(fixedFooter, 800)
	
    themeImageSection();

    shoppingCart();

    sectionHeights();

    invertScroll();

    verticallyCentered();
	
}).resize();


/* ------------------------------------------------
    Window Load Events
--------------------------------------------------- */
  
  
$win.on('load', function() {
	
    navEvents();

    progressBarsOnView();

    owlC();

    isotope();

    counters();

    wowInit();

    nivoLightbox();

    tooltip();

    fixedSocialIcons();

    flickrThumbnails();

    shopSlider();

    tweets();

    parallaxContainer();

    instagramFeed();

    dribbleShots();

    parallaxImages();

    defaultMap();

    formValidation();
	
    /*---- Auto Modal Box ----*/

    $('.modal.auto').modal('show');

    /*---- Hide Page Loader ----*/

    $(".loader").fadeOut("slow");

});
$(document).ready(function () {
    $("#change-number").on("click" , function () {
        $(".change-number-div").slideToggle();
    })
})