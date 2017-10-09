$(document).ready(function(){
    $('#add-form').hide();

    $('#create-button').on('click', function(){
        $('#add-form').show();
        $('#dvdList').hide();
        $('#navBar').hide();
        
    })

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function(dvdArray) {
            var dvdsDiv = $('#allDvds');

            $.each(dvdArray, function(index, dvd) {
                var dvdInfo = '<tr>';
                dvdInfo += '<td>' + dvd.title + '</td><td>' + dvd.realeaseYear + '</td><td>'+ dvd.director + '</td><td>' + dvd.rating +
                "<td><a href='edit"+dvd.dvdId+"'>Edit</a> | <button onclick='Delete("+dvd.dvdId+")' id="+dvd.dvdId+"'>Delete</button>";  
                dvdInfo += '</td></tr>';

                dvdsDiv.append(dvdInfo); 
            })
        },
        error: function(jqXHL,textStatus,errorThrown) {
            var a = jqXHL;
            var b = textStatus;
            var c = errorThrown;
            alert(a);
        }
    })

    $('#create-button-submit').on('click', function() {
        $('#add-form').hide();
        $('#dvdList').show('slow');
        $('#navBar').show();
        $.ajax({
            type: 'POST',
            url: 'http://localhost:8080/dvd',
            data: JSON.stringify({
                title: $('#add-title').val(),
                realeaseYear: $('#add-release-year').val(),
                director: $('#add-director').val(),
                rating: $('#add-rating').val(),
                notes: $('#add-note').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            dataType: 'json',
            success: function(dvd) {
                var dvdInfo = '<tr>';
                dvdInfo += '<td>' + dvd.title + '</td><td>' + dvd.realeaseYear + '</td><td>'+ dvd.director + '</td><td>' + dvd.rating +
                "<td><a href='edit"+dvd.dvdId+"'>Edit</a> | <button onclick='Delete("+dvd.dvdId+")' id="+dvd.dvdId+"'>Delete</button>";    
                dvdInfo += '</td></tr>';
                
                $('#allDvds').append(dvdInfo);
            },
            error: function(jqXHL,textStatus,errorThrown) {
            var a = jqXHL;
            var b = textStatus;
            var c = errorThrown;
            alert(a);
            }
        })
    })


});
    function Delete(id){
        if (window.confirm("Are you sure you want to delete?")==true){
        $.ajax({
            type: 'DELETE',
            url: "http://localhost:8080/dvd/"+id,
        })
        }
    }