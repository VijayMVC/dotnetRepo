$(document).ready(function () {
    getFeaturedVehicles();
});

function updateArea() {
    getFeaturedVehicles();
}

function getFeaturedVehicles() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55632/Featured',
        success: function (vehicles) {
            var output = "";
            var i = 0;

            for (i; i < vehicles.length; i++) {
                if (vehicles[i].IsFeatured) {
                    output += '<div class="col-md-3" style="height:200px"><div class="col-md-12" style="height:150px"><img src="' + vehicles[i].ImageLocation + '" width="100%" height="100%"></div>'
                    output += '<div style="padding-top:6px; text-align:center"><h4>' + vehicles[i].Year + ' ' + vehicles[i].CarMake.MakeName + ' ' + vehicles[i].CarModel.ModelName + '</br>$' + vehicles[i].SalePrice +'</h4></div></div>'
                }
            }
            $('#Featured').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}