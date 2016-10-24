$(".subs-title").each(function () {
    if ($(this).html().length > 30) {
        var text = $(this).html();
        text = text.substr(0, 30) + "...";
        $(this).html(text);
    }
})