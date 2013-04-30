

function searchFailed() {
    $("#searchresults").html("Sorry, there was a problem with the search.");
}

$(function () {
    $(".title").animate({ height: '+=25', width: '+=25' })
    .animate({ height: '-=25', width: '-=25' })
    .size(200)
    ;
});