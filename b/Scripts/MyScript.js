
if ($.validator && $.validator.unobtrusive) {

    $.validator.unobtrusive.adapters.addSingleVal("maxwords", "maxwords");
    $.validator.addMethod("maxwords", function (value, element, maxwords) {
        if (value) {
            if (value.split(' ').length > maxwords) {
                return false;
            }
        }
        return true;
    });
}

function searchFailed() {
    $("#searchresults").html("Sorry, there was a problem with the search.");
}

$(function () {
    //$(".title").animate({ height: '+=25', width: '+=25' })
    //.animate({ height: '-=25', width: '-=25' })
    //.size(200)
    //;
    $(".title").mouseover(function () {
        $(this).effect("bounce", { time: 3, distance: 40 });
    });
});