
$(document).ready(function(){
  $('.hasmenu>a').click(function(){  
  	$('.hasmenu a').removeClass('active')
  	$(this).addClass('active')  	
    $(this).next('.submenu').slideToggle('slow')
    $('.submenu').not($(this).next('.submenu')).slideUp('slow')
     $('.submenu').not($(this)).removeClass('active')

  });

  $('.navbar-toggle').click(function(){
  	$('.side-collapse').toggleClass('in');
  	$('#page-wrapper').toggleClass('large')
  });
  $(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();   
});
   
})
 

