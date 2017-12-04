$(document).ready(function () {
    $('#Results').hide()
    $('#Details').hide()
    $('#PurchaseVehicle').hide()
});
var transmission;

$("#search").click(function () {
    quickSearch();
    $('#Results').show('slow')
});


function quickSearch() {
    var Type = $('#vehType').val();
    var SearchKey = $('#searchKey').val();
    if (SearchKey == '') {
        SearchKey = "null";
    }
    var PriceMin = $('#minPrice').val();
    var PriceMax = $('#maxPrice').val();
    var YearMin = $('#minYear').val();
    var YearMax = $('#maxYear').val();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55632/Vehicles/' + Type + "/" + SearchKey + "/" + YearMin + "/" + YearMax + "/" + PriceMin + "/" + PriceMax,
        success: function (vehicles) {
            var output = "";
            var i = 0;

            if (vehicles[i].IsAutomatic == true) {
                transmission = "Automatic"
            }
            else {
                transmission = "Manual"
            }

            for (i; i < vehicles.length; i++) {

                output += '<div class="col-md-12" style="height:200px; border:solid; border-color:grey; margin-bottom:8px"><div style="height:inherit" class="col-md-3"><h4>' + vehicles[i].Year + ' ' + vehicles[i].CarMake.MakeName + ' ' + vehicles[i].CarModel.ModelName + '</h4><img src="http://localhost:55632/' + vehicles[i].ImageLocation + '" height="75%"></div>'
                output += '<div class="col-md-9"><div class="col-md-4"> <h5>Body Style: ' + vehicles[i].CarBody.BodyTypeName + '</h5><h5>Transmission: ' + transmission + '</h5><h5>Color: ' + vehicles[i].Color + '</h5></div>'
                output += '<div class="col-md-4"> <h5>Interior: ' + vehicles[i].Interior + '</h5><h5>Mileage: ' + vehicles[i].Mileage + '</h5><h5>Vin: ' + vehicles[i].VinNumber + '</h5></div>'
                output += '<div class="col-md-4"> <h5>Sale Price: $' + vehicles[i].SalePrice + '</h5><h5>MSRP: $' + vehicles[i].MSRP + '</h5><br/><button type="button" class="btn btn-default" onclick="vehicleDetails(' +"'"+ vehicles[i].VinNumber +"'"+ ')">Purchase</button></div></div></div>'          
            }
            $('#Results').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }
    })
}


function vehicleDetails(vin) {
    $('#Results').hide('slow');
    $('#Details').show('slow');
    $('#PurchaseVehicle').show('slow');
    $('#vinBox').val(vin);
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55632/Vehicle/Vin/' + vin,
        success: function (vehicle) {
            var output = "";
            var i = 0;
            var buttonLabel;

            if (vehicle.IsAutomatic == true) {
                transmission = "Automatic"
            }
            else {
                transmission = "Manual"
            }

            output += '<div class="col-md-12" style="height:200px; border:solid; border-color:grey; margin-bottom:8px"><div style="height:inherit" class="col-md-3"><h4>' + vehicle.Year + ' ' + vehicle.CarMake.MakeName + ' ' + vehicle.CarModel.ModelName + '</h4><img src="http://localhost:55632/' + vehicle.ImageLocation + '" height="75%"></div>'
            output += '<div class="col-md-9"><div class="col-md-4"> <h5>Body Style: ' + vehicle.CarBody.BodyTypeName + '</h5><h5>Transmission: ' + transmission + '</h5><h5>Color: ' + vehicle.Color + '</h5></div>'
            output += '<div class="col-md-4"> <h5>Interior: ' + vehicle.Interior + '</h5><h5>Mileage: ' + vehicle.Mileage + '</h5><h5>Vin: ' + vehicle.VinNumber + '</h5></div>'
            output += '<div class="col-md-4"> <h5>Sale Price: $' + vehicle.SalePrice + '</h5><h5>MSRP: $' + vehicle.MSRP + '</h5><br/></div>'
            output += '<div class="col-md-12"><h5>Description: ' + vehicle.Description + '</h5></div></div></div></div>'

            $('#Details').html(output)
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }
    })
}