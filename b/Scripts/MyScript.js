

function m(msg) {
    $.jGrowl(msg, { pool: 2 });
    //statusMessage(msg, 1);
}
function statusMessage(msg, life) {
    //$.jGrowl(msg, { position: bottom - right });
    //$.jGrowl(msg, { life: (life * 1000), position: bottom - left });
    $.jGrowl(msg, { life: (life * 1000) });
}

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

(function ($) {
    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
              .addClass("custom-combobox")
              .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
              value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
              .appendTo(this.wrapper)
              .val(value)
              .attr("title", "")
              .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
              .autocomplete({
                  delay: 0,
                  minLength: 0,
                  source: $.proxy(this, "_source")
              })
            .tooltip({
                tooltipClass: "ui-state-highlight"
            })
            ;

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {
            var input = this.input,
              wasOpen = false;

            $("<a>")
              .attr("tabIndex", -1)
              .attr("title", "Show All Items")
              .tooltip()
              .appendTo(this.wrapper)
              .button({
                  icons: {
                      primary: "ui-icon-triangle-1-s"
                  },
                  text: false
              })
              .removeClass("ui-corner-all")
              .addClass("custom-combobox-toggle ui-corner-right")
              .mousedown(function () {
                  wasOpen = input.autocomplete("widget").is(":visible");
              })
              .click(function () {
                  input.focus();

                  // Close if already visible
                  if (wasOpen) {
                      return;
                  }

                  // Pass empty string as value to search for, displaying all results
                  input.autocomplete("search", "");
              });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {
                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
              valueLowerCase = value.toLowerCase(),
              valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

            // Remove invalid value
            this.input
              .val("")
              .attr("title", value + " didn't match any item")
              .tooltip("open");
            this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            this.input.data("ui-autocomplete").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });
})(jQuery);

$(function () {

    $(".water").each(function () {
        $tb = $(this);
        if ($tb.val() != this.title) {
            $tb.removeClass("water");
        }
    });

    $(".water").focus(function () {
        $tb = $(this);
        if ($tb.val() == this.title) {
            $tb.val("");
            $tb.removeClass("water");
        }
    });

    $(".water").blur(function () {
        $tb = $(this);
        if ($.trim($tb.val()) == "") {
            $tb.val(this.title);
            $tb.addClass("water");
        }
    });

    //$(".title").animate({ height: '+=25', width: '+=25' })
    //.animate({ height: '-=25', width: '-=25' })
    //.size(200)
    //;
    $(".title").mouseover(function () {
        $(this).effect("bounce", { time: 3, distance: 40 });
    });
});