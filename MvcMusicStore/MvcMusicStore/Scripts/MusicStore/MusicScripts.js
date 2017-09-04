//$(function () {
//    $('#album-list img').mouseover(function () {
//        $(this).animate({ height: "+=25", width: "+=25" })
//                .animate({ height: "-=25", width: "-=25" });
//    });
//});

$(function () {
    $("#album-list img").mouseover(function () {
        $(this).effect("bounce", { time: 13, distance: 40 });
    });

    $("input[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({ source: taret.attr("data-autocomplete-source") });
    });

    function searchFailed() {
        $("#searchresults").html("Sorry,There was a problem");
    };
});



