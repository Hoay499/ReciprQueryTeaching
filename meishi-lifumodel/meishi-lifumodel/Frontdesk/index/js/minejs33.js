$(function () {
    /*搜索*/
    $(".search_pic").click(function () {
        $(".headernav").fadeOut(500);
        $(".search_main").fadeIn(1000);
    });
    $(".search_main .close_btn").click(function () {
        $(".search_main").fadeOut(500);
        $(".headernav").fadeIn(1000);
    });
    /*登录*/
    $(".lista a").click(function () {
        $(".member").slideToggle(500);
    });

});




$().ready(function () {

    //setTimeout(function () {
    //    var cpx = ["菜谱大全", "食材", "菜谱属性", "饮食健康"];
        
    //    createstyle(cpx);

    //}, 300);


});

function search() {
    var l = $("#menu3-overlay-btn"); 
    var i = $("#menu0-overlay-btn");
    var j = $("#menu1-overlay-btn");
    var k = $("#menu2-overlay-btn");
    var a = $(".search-overlay, .search-overlay .search-overlay-close");
    i.on('click', function (event) {
        
        $(".search-overlay").addClass("open"),
        $('.search-overlay > form > input[type="search"]').focus();
    });
    j.on('click', function (event) {
         
        $(".search-overlay").addClass("open"),
        $('.search-overlay > form > input[type="search"]').focus();
    });
    k.on('click', function (event) {
        
        $(".search-overlay").addClass("open"),
        $('.search-overlay > form > input[type="search"]').focus();
    });
    l.on('click', function (event) {
       
        $(".search-overlay").addClass("open"),
        $('.search-overlay > form > input[type="search"]').focus();
    });
    a.on('click', function (event) {
        event.target != this && "search-overlay-close" != event.target.className && 32 != event.keyCode || $(this).removeClass("open");
    });
}

function createstyle(cpx,type,val) {
    if (type == "circle") {
        createcircle(cpx);
    }
    else if (type == "transverse") {
        
        createtransverse(cpx,val);
    }
   
    search();
}
function createtransverse(cpx,val) {
    var n = cpx.length - 1;//个数
    //var l = (14 - n) * 10;//距离原点距离
    var size = 60;//小菜谱的大小；
    var ax=[];
    for (var i = 0; i < n; i++) {
        ax[i] = -(size*i+(i+1)*val);
    }
    
    var csslist = "";
    var jstext = " $('.burger_menu').click(function () { $(this).toggleClass('toggle_burger');";
    var htmlinner = "";



    var styles = document.createElement('style');
    styles.id = 'id';
    styles.type = 'text/css';
    var cssname = ".burger_menu,";
    for (var i = 0; i < n; i++) {
        if (i == n - 1) {
            cssname += ".menucircle" + i + "{";
        }
        else {
            cssname += ".menucircle" + i + ",";
        }
    }
    csslist += cssname + "border-radius: 50%;cursor: pointer;width: 60px;height: 60px;position: absolute;";
    csslist += "top: 0;right: 0;justify-content: center; align-items: center;transition: all 0.3s ease;}";
    cssname = "";

    var circlemenulist = document.getElementById('circlemenulist');
    var hh = document.getElementById('circlemenu');

    for (var i = 0; i < n; i++) {
        
        cssname += ".toggle_menucircle" + i + "{width: " + size + "px; height: " + size + "px; background: #605770; transform: translate3d(" + ax[i] + "px, 0, 0);}";

        jstext += " setTimeout(function () { $('.menucircle" + i + "').toggleClass('toggle_menucircle" + i + "'); }, " + 100 * (i + 1) + ");";

        htmlinner += "   <div class='menucircle" + i + "' id='menu" + i + "-overlay-btn' >";
        
        htmlinner += "   <p class='fafafa' onclick='getclassification(&quot;" + cpx[i] + "&quot;)'>" + cpx[i] + "</p>";
         
        htmlinner += "  </div>";

    }
    csslist += cssname;
    jstext += "});";

    //ax[i]  
    // ay[i]

    if (styles.styleSheet) {
        styles.styleSheet.cssText = csslist;//IE
    } else {
        styles.appendChild(document.createTextNode(csslist));//for FF
    }
    document.getElementsByTagName('head')[0].appendChild(styles);



    var script = document.createElement("script");
    script.type = "text/javascript";
    script.text = jstext;
    document.body.appendChild(script);

    $('#circlemenulist').html(htmlinner);
    circlemenulist.htmlinner = htmlinner;
    circlemenulist.html = htmlinner;

}
function createcircle(cpx) {
    var n = cpx.length - 1;//个数
    var l = (14 - n) * 10;//距离原点距离
    var size = (8 - n) * 20;//小菜谱的大小；
    var angle = 0;//角度
    var w = 45;//暂时角度变量
    var ax = [];
    var ay = [];
    var cala = 0;
    var vSin = 0;
    var vCos = 0;

    angle = 360 / n;
    if (angle > 90) angle = 90;
    for (var i = 0; i < n; i++) {

        if (w == 0 || w == 360) {
            ax[i] = (-1) * l; ay[i] = 0;
        }
        else if (w < 90) {
            cala = w;
            vSin = Math.round(Math.sin((cala * Math.PI / 180)) * 1000000) / 1000000;
            vCos = Math.round(Math.cos((cala * Math.PI / 180)) * 1000000) / 1000000;
            ax[i] = (-1) * l * vCos; ay[i] = l * vSin;
        }
        else if (w == 90) {
            ax[i] = 0; ay[i] = l;

        }
        else if (w > 90 && w < 180) {
            cala = 180 - w;
            vSin = Math.round(Math.sin((cala * Math.PI / 180)) * 1000000) / 1000000;
            vCos = Math.round(Math.cos((cala * Math.PI / 180)) * 1000000) / 1000000;
            ax[i] = l * vCos; ay[i] = l * vSin;
        }
        else if (w == 180) {
            ax[i] = l; ay[i] = 0;

        }
        else if (w > 180 && w < 270) {
            cala = w - 180;
            vSin = Math.round(Math.sin((cala * Math.PI / 180)) * 1000000) / 1000000;
            vCos = Math.round(Math.cos((cala * Math.PI / 180)) * 1000000) / 1000000;
            ax[i] = l * vCos; ay[i] = (-1) * l * vSin;
        }
        else if (w == 270) {
            ax[i] = 0; ay[i] = (-1) * l;

        }
        else if (w > 270 && w < 360) {
            cala = 360 - w;
            vSin = Math.round(Math.sin((cala * Math.PI / 180)) * 1000000) / 1000000;
            vCos = Math.round(Math.cos((cala * Math.PI / 180)) * 1000000) / 1000000;
            ax[i] = (-1) * l * vCos; ay[i] = (-1) * l * vSin;
        }

        w += angle;
    }



    var csslist = "";
    var jstext = " $('.burger_menu').click(function () { $(this).toggleClass('toggle_burger');";
    var htmlinner = "";



    var styles = document.createElement('style');
    styles.id = 'id';
    styles.type = 'text/css';
    var cssname = ".burger_menu,";
    for (var i = 0; i < n; i++) {
        if (i == n - 1) {
            cssname += ".menucircle" + i + "{";
        }
        else {
            cssname += ".menucircle" + i + ",";
        }
    }
    csslist += cssname + "border-radius: 50%;cursor: pointer;width: 50px;height: 50px;position: absolute;";
    csslist += "top: 0;right: 0;justify-content: center; align-items: center;transition: all 0.3s ease;}";
    cssname = "";

    var circlemenulist = document.getElementById('circlemenulist');
    var hh = document.getElementById('circlemenu');

    for (var i = 0; i < n; i++) {

        cssname += ".toggle_menucircle" + i + "{width: " + size + "px; height: " + size + "px; background: #605770; transform: translate3d(" + ax[i] + "px, " + ay[i] + "px, 0);}";

        jstext += " setTimeout(function () { $('.menucircle" + i + "').toggleClass('toggle_menucircle" + i + "'); }, " + 100 * (i + 1) + ");";

        htmlinner += "   <div class='menucircle" + i + "' id='menu" + i + "-overlay-btn' >";

        htmlinner += "  <i class='fa' onclick='getclassification(&quot;" + cpx[i] + "&quot;)'>" + cpx[i] + "</i>";

        htmlinner += "  </div>";

    }
    csslist += cssname;
    jstext += "});";

    //ax[i]  
    // ay[i]

    if (styles.styleSheet) {
        styles.styleSheet.cssText = csslist;//IE
    } else {
        styles.appendChild(document.createTextNode(csslist));//for FF
    }
    document.getElementsByTagName('head')[0].appendChild(styles);



    var script = document.createElement("script");
    script.type = "text/javascript";
    script.text = jstext;
    document.body.appendChild(script);

    $('#circlemenulist').html(htmlinner);
    circlemenulist.htmlinner = htmlinner;
    circlemenulist.html = htmlinner;

    
}

