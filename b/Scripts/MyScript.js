

//call it onblur = "WaterMark(this, event);" onfocus = "WaterMark(this, event);"
function WaterMark(txtName, event) {
    var defaultText = "Enter " + txtName + " Here";
    // Condition to check textbox length and event type
    if (txtName.value.length == 0 & event.type == "blur") {
        //if condition true then setting text color and default text in textbox
        txtName.style.color = "Gray";
        txtName.value = defaultText;
    }
    // Condition to check textbox value and event type
    if (txtName.value == defaultText & event.type == "focus") {
        txtName.style.color = "black";
        txtName.value = "";
    }
}

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