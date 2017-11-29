$(document).ready(function () {
    $('#Results').hide()
    $('#Details').hide()
});
var transmission;

$("#search").click(function () {
    quickSearch();
    $('#Results').show('slow')
});


function quickSearch() {
    var Type = $('#vehType').val();
    var SearchKey = $('#searchKey').val();
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

                output += '<div class="col-md-12" style="height:200px; border:solid; border-color:grey; margin-bottom:8px"><div class="col-md-3">' + vehicles[i].Year + ' ' + vehicles[i].CarMake.MakeName + ' ' + vehicles[i].CarModel.ModelName + '<img src="' + vehicles[i].ImageLocation + '" width="100%" height="100%"></div>'
                output += '<div class="col-md-9"><div class="col-md-4"> <p>Body Style: ' + vehicles[i].CarBody.BodyTypeName + '</p><p>Transmission: ' + transmission + '</p><p>Color: ' + vehicles[i].Color + '</p></div>'
                output += '<div class="col-md-4"> <p>Interior: ' + vehicles[i].Interior + '</p><p>Mileage: ' + vehicles[i].Mileage + '</p><p>Vin: ' + vehicles[i].VinNumber + '</p></div>'
                output += '<div class="col-md-4"> <p>Sale Price: $' + vehicles[i].SalePrice + '</p><p>MSRP: $' + vehicles[i].MSRP + '</p><br/> <a href="/Admin/EditVehicle/' + vehicles[i].VehicleID + '"><button type="button" class="btn btn-default"> Edit </button></a></div></div></div>'
            }
            $('#Results').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }
    })
}

$('#makeDrop').on('change', function () {
    getModels($(this).val())
});

function getModels(makeID) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:55632/Vehicle/Models/Make/' + makeID,
        success: function (models) {
            var i = 0;
            var output = "<div id= 'modelDrop'> <select class='form-control' data-val='true' data-val-number='The field CarModelID must be a number.' data-val-required='The CarModelID field is required.' id='AVehicle_CarModel_CarModelID' name='AVehicle.CarModel.CarModelID'><option value=''>Select Model</option>";
            for (i; i < models.length; i++) {
                output += "<option value=" + models[i].CarModelID + ">" + models[i].ModelName + "</option>"
            }
            output += "</select>"
            $('#modelDrop').empty();
            $('#modelDrop').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}

$('#userSave').on("click", function () {
    if ($('#pw').val() !== $('#pwConf').val())
    {
        alert("Confirm password does not match original, please re-enter")
        return false;
    }
})