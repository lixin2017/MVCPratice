$(function () {
    $('#album-list img').mouseover(function () {
        $(this).animate({ height: "+=25", width: "+=25" })
                .animate({ height: "-=25", width: "-=25" });
    });
});

function searchFailed() {
    $("#searchresults").html("Sorry,There was a problem");
}