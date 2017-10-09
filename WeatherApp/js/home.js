$(document).ready(function () {
    $('#getWeather').on('click',function(){
        var zip = $('#zipInput').val();
        getCurrentWeatherForZip(zip);
    })
});


function getCurrentWeatherForZip(zip){
    $.ajax({
        type: 'GET',
        url: "http://api.openweathermap.org/data/2.5/weather?zip="+zip+"&appid=a67baf3017f2b999dbc75f34426589f4&units=imperial",
        success: function(currentWeather){
            clearMain();
            var infoReturn = "<h1> Current conditions in "+currentWeather.name+"</h1>";
            var description = "<p>Weather: "+currentWeather.weather[0].description+"</p>";
            var temp = "<p>Temperature: "+currentWeather.main.temp+" F</p>";
            var humidity = "<p>Humidity: "+currentWeather.main.humidity+"%</p>";
            var wind =  "<p>Wind Speed: "+currentWeather.wind.speed+" miles/hour</p>";
            
            $('#currentConditionsHeader').append(infoReturn);
            $('#description').append(description);
            $('#temp').append(temp);
            $('#humidity').append(humidity);
            $('#wind').append(wind);
        },
        error: function(){
            alert("fail");
        }
    }) 
} 

function clearMain(){
    $('#currentConditionsHeader').empty();
            $('#description').empty();
            $('#temp').empty();
            $('#humidity').empty();
            $('#wind').empty();
}