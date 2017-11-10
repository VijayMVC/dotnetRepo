$(document).ready(function () {
    getSpecials();
}); 

function getSpecials() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55632/Specials',
        success: function (specials) {
            var output = "";
            var i = 0;

            for (i; i < specials.length; i++) {
                output += '<div class="col-md-12" style="height:200px"><div class="col-md-3" style="height:150px"><img src="' + specials[i].ImageLocation + '" width="100%" height="100%"></div>'
                output += '<div class="col-md-9"><h3>' + specials[i].SpecialName + '</h3><h4>' + specials[i].Description + '</h4></div></div>'
            }
            $('#specials').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}