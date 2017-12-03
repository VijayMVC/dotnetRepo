$(document).ready(function () {
    $('#Results').hide()
        populateMessage();
}); 
var transmission;
var params;

$("#search").click(function () {
    $('#Results').hide('slow')
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

                output += '<div class="col-md-12" style="height:200px; border:solid; border-color:grey; margin-bottom:8px"><div style="height:inherit" class="col-md-3"><h4>' + vehicles[i].Year + ' ' + vehicles[i].CarMake.MakeName + ' ' + vehicles[i].CarModel.ModelName + '</h4><img src="http://localhost:55632/' + vehicles[i].ImageLocation + '"height="75%"></div>'
                output += '<div class="col-md-9"><div class="col-md-4"> <h5>Body Style: ' + vehicles[i].CarBody.BodyTypeName + '</h5><h5>Transmission: ' + transmission + '</h5><h5>Color: ' + vehicles[i].Color + '</h5></div>'
                output += '<div class="col-md-4"> <h5>Interior: ' + vehicles[i].Interior + '</h5><h5>Mileage: ' + vehicles[i].Mileage + '</h5><h5>Vin: ' + vehicles[i].VinNumber + '</h5></div>'
                output += '<div class="col-md-4"> <h5>Sale Price: $' + vehicles[i].SalePrice + '</h5><h5>MSRP: $' + vehicles[i].MSRP + '</h5><br/><a href="/Home/VehicleDetails/' + vehicles[i].VehicleID + '"><button type="button" class="btn btn-primary"">Details</button></a></div></div></div>'
            }
            $('#Results').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }
    })
}


//function vehicleDetails(id) {
//    $('#Results').hide('slow');
//    $('#Details').show('slow');
//    $.ajax({
//        type: 'GET',
//        url: 'http://localhost:55632/Vehicle/' + id,   
//        success: function (vehicle) {
//            var output = "";
//            var i = 0;
//            var buttonLabel;

//            if (vehicle.IsAutomatic == true) {
//                transmission = "Automatic"
//            }
//            else {
//                transmission = "Manual"
//            }

//            if (vehicle.IsAvailable == false) {
//                buttonLabel = "disabled>Unavailable-Sold";
//            }
//            else
//            {
//                buttonLabel = ">Contact Us";
//            }
                
//            output += '<div class="col-md-12" style="height:200px; border:solid; border-color:grey; margin-bottom:8px"><div class="col-md-3">' + vehicle.Year + ' ' + vehicle.CarMake.MakeName + ' ' + vehicle.CarModel.ModelName + '<img src="' + vehicle.ImageLocation + '" width="100%" height="100%"></div>'
//            output += '<div class="col-md-9"><div class="col-md-4"> <p>Body Style: ' + vehicle.CarBody.BodyTypeName + '</p><p>Transmission: ' + transmission + '</p><p>Color: ' + vehicle.Color + '</p></div>'
//            output += '<div class="col-md-4"> <p>Interior: ' + vehicle.Interior + '</p><p>Mileage: ' + vehicle.Mileage + '</p><p>Vin: ' + vehicle.VinNumber + '</p></div>'
//            output += '<div class="col-md-4"> <p>Sale Price: $' + vehicle.SalePrice + '</p><p>MSRP: $' + vehicle.MSRP + '</p><br/></div></div >'
//            output += '<div class="col-md-offset-3 col-md-7"><p>Description: ' + vehicle.Description + '</p></div><div class="col-md-2"><a href="http://localhost:55632/Home/ContactUs?vin=' + vehicle.VinNumber + '"><button type="button" class="btn btn-default" onclick="contactUs(' + "'" + vehicle.VinNumber + "'" + ')"'+buttonLabel+'</button></a></div></div></div>'

//        $('#Details').html(output);
//        },
//        error: function (jqxhr, techstatus, errorthrow) {
//        }
//    })
//}

function populateMessage() {
    params = (new URL(document.location)).searchParams;
    if (params.get('vin') != null) {
        $('#messageForm').val("Vin #: " + params.get('vin'));
    }
}