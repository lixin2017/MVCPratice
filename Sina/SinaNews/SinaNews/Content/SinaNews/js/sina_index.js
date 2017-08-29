$(function(){
	var link=$('.link-more');
	var list=$('#more-list li');
	link.hover(function(){
		list.css('display','block');		
	},function(){
		list.css('display','none');
	});
});


$(function(){
	var link=$('.link-list');
	var list=$('.tn-topmenulist');
	link.hover(function(){
		list.css('display','block');		
	},function(){
		list.css('display','none');
	});
});


$(document).ready(function(){
	var count=$('.imglist li').length,
		index=0;
	setInterval(function(){
		if(index<count-1){
			index++;
		}else{
			index=0;
		}	
		changeTo(index);
	},3000);

	function changeTo(num){
		var goLeft=num*240;
		$('.imglist').animate({left:"-"+goLeft+"px"},2000);	
	}
});


/*************新闻切换***********************/

$(document).ready(function(){
	function switchDiv(orderMenu,tabCont){
		orderMenu.hover(function(){
			var index=$(this).index();
			$(this).addClass('head-selected').siblings().removeClass('head-selected');
			tabCont.eq(index).css('display','block').siblings().css('display','none');
		});	
	}
	var orderMenu=$('.switch-menu span');
	var tabCont=$('.switch-div>div');
	switchDiv(orderMenu,tabCont);
	
	var orderMenu2=$('.switch-menu2 span');
	var tabCont2=$('.switch-div2>div');
	switchDiv(orderMenu2,tabCont2);
	
	var orderMenu3=$('.switch-menu3 span');
	var tabCont3=$('.switch-div3>div');
	switchDiv(orderMenu3,tabCont3);
})	


/*************新闻轮播***********************/
$(document).ready(function(){
	var list=$('.news-switch-m ul');
	var dot=$('.mod-guess-dots span');
	var index=0;
	dot.eq(index).find('img').attr('src','img/小图标黄.png').parent().siblings().find('img').attr('src','img/小图标灰.png');
	dot.hover(function(){
		index=$(this).index();
		$(this).find('img').attr('src','img/小图标黄.png').parent().siblings().find('img').attr('src','img/小图标灰.png');
		list.eq(index).css('display','block').siblings().css('display','none');
	});
	var prev=$('.mod-guess-prev');
	prev.click(function(){		
		if(index>0){
			index--;
		}
		else{
			index=list.length-1;
		}
		dot.eq(index).find('img').attr('src','img/小图标黄.png').parent().siblings().find('img').attr('src','img/小图标灰.png');
		list.eq(index).css('display','block').siblings().css('display','none');
	});
	var next=$('.mod-guess-next');
	next.click(function(){		
		if(index<list.length-1){
			index++;
		}
		else{
			index=0;
		}
		dot.eq(index).find('img').attr('src','img/小图标黄.png').parent().siblings().find('img').attr('src','img/小图标灰.png');
		list.eq(index).css('display','block').siblings().css('display','none');
	});
	
});