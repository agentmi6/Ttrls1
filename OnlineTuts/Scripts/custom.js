$(document).ready(function () {

    //show/hide tutorial description
    $("#show-more").on("click", function () {
        if (!$(".desc").is(":visible")) {
            $("#summary").text("Show Less");
        }
        else {
            $("#summary").text("Show More");
        }
    });


    //active li element
    $(".applist li").on("click", function () {
        $("li.active-el").removeClass("active-el");
        $(this).addClass("active-el");
    });

    ////////////////////
    //close menu bar
    $(".menu-bar").on("click", function (e) {
        $(this).toggleClass("change");
        $(".menu-bar-content").fadeToggle("350");
        e.stopPropagation();
    });

    $(".menu-bar-content").on("click", function (e) {
        e.stopPropagation();
    });
    ////////////////////


    ///////////////////
    //add to playlist
    $("#addToListBtn").on("click", function (e) {
        e.stopPropagation();
        $(".playlists").toggle();
    });

    $(".playlists").on("click", function (e) {
        e.stopPropagation();
    });
    //////////////////

    //goto comment
    function offsetAnchor() {
        if (location.hash.length !== 0) {
            window.scrollTo(window.scrollX, window.scrollY - 100);
        }
    }
    $(window).on("hashchange", offsetAnchor);
    window.setTimeout(offsetAnchor, 1);

    //subscription added/removed
    var $subscribe = $(".subscription-alert");
    var $unsubscribe = $(".unsubscription-alert");

    var subscribeBtn = $("#video-userinfo-subscribe");
    var unsubscribeBtn = $("#video-userinfo-unsubscribe");

    $(document).on("click", ".sub-btn", function () {
        if ($(this).attr("id") == "video-userinfo-subscribe") {
            $(".subscription-alert").fadeIn(350).delay(2000).fadeOut(1350);
        }
        else if ($(this).attr("id") == "video-userinfo-unsubscribe") {
            $(".unsubscription-alert").fadeIn(350).delay(2000).fadeOut(1350);
        }
    });

    //goto specific tab in profile
    var hash = window.location.hash;
    hash && $('ul.nav a[href="' + hash + '"]').tab('show');

    $("#menubarlink-subs").on("click", function () {
        $("#exTab2 a[href='#2']").tab("show");
    });

    $("#menubarlink-favs").on("click", function () {
        $("#exTab2 a[href='#3']").tab("show");
    });

    //tooltips
    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });

    //$(".fav-remove").on("click", function () {       
    //    $(this).parent().parent().fadeOut(300);
    //    $.ajax({
    //        type: "POST",
    //        url: "@Url.Action('RemoveFavorite','Tutorials', new { id = ViewBag.Favorite })",
    //    });
    //});    

    $(".fav-tutorial").hover(function () {
        $(this).children(".fav-tutorial-remove").child(".fav-remove > a").show();
    });

    //$("#modalBtn").on("click", function() {
    //    $("#myModal").modal();
    //})


    //disable post button if text area is empty
    $(".commentBody").on("keyup", function () {
        if ($(".commentBody").val() != "") {
            $(".postBtn").attr("disabled", false);
        }
        else {
            $(".postBtn").attr("disabled", true);
        }
    });
       

});

//close menu bar
$(document).on("click", function () {
    if($(".menu-bar").hasClass("change")) {
        $(".menu-bar").removeClass("change");
    }
    if($(".menu-bar-content").is(":visible")) {
        $(".menu-bar-content").fadeOut("350");
    }
    if ($(".playlists").is(":visible")) {
        $(".playlists").hide();
    }
})







