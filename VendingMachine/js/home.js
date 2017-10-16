var amount = 0;
var selectedItem;
var selectedItemName;
$(document).ready(function () {
FillVendingMachine();
DisplayMoneyIn(amount);
});

$('#addDollar-button').click(function(){
    amount += 1;
    DisplayMoneyIn();
})
$('#addQuarter-button').click(function(){
    amount += .25;
    DisplayMoneyIn();
})
$('#addDime-button').click(function(){
    amount += .10;
    DisplayMoneyIn();
})
$('#addNickel-button').click(function(){
    amount += .05;
    DisplayMoneyIn();
})

function FillVendingMachine(){
$.ajax({
    type: 'GET',
    url: "http://localhost:8080/items",
    success: function(inventory){
        ClearVendingMachine();
        $.each(inventory,function(index,item){
            var thisItem = $('#item'+item.id);
            var itemInfo = '<p style="font-size:14pt;">';
            itemInfo += item.id + '<br><br><br></p><p style="font-size:14pt; text-align:center;">';
            itemInfo += item.name + '<br><br>';
            itemInfo += 'Price: $' + item.price.toFixed(2) + '<br><br><br>';
            itemInfo += 'Quantity Available: '+item.quantity;

            thisItem.append(itemInfo);
        })
    },
    error: function() {
            alert('FAILURE1!');
    }
})}

function ClearVendingMachine(){
$('.dataBox').empty();
$('#itemBox').val('');
}

function DisplayMoneyIn(){
    $('#moneyIn').empty();
    $('#moneyIn').append('$'+amount.toFixed(2));
}

function VendingAnItem(id){
    $.ajax({
        type: 'GET',
        url: "http://localhost:8080/money/"+amount.toFixed(2)+"/item/"+id,
        success: function(object){
            $('.messageBox').empty();
            $('.changeBox').empty();
            FillVendingMachine();
            $('#messageBox').append("<p style='font-size:14px'>Thank you!!!</p>");
            var change = "<p> Quarters: "+object.quarters+"<br><p> Dimes: "+object.dimes+"<br><p> Nickels: "+object.nickels+"<br><p> Pennies: "+object.pennies+"</p>";
            $('#changeBox').append(change);
            amount=0;
            DisplayMoneyIn();
        },
        error: function(object) {
            $('#messageBox').empty();
            if(object.responseJSON.message == "No message available"){
            $('#messageBox').append("Please select an item!");
            }
            else{  
            $('#messageBox').append(object.responseJSON.message);
            }
        }
    })
}

//make purchase
$('#makePurchase-button').click(function(){
    selectedItem=$('#itemBox').val()
    VendingAnItem(selectedItem);
})

//return change
$('#changeReturn-button').click(function(){
    amount = 0;
    ClearVendingMachine();
    FillVendingMachine();
    DisplayMoneyIn();
})

//Item selection elements:
$('#box1').click(function(){
    $('#itemBox').empty();
selectedItem = 1;
selectedItemName = "Snickers";
$('#itemBox').val(selectedItem);
})

$('#box2').click(function(){
$('#itemBox').empty();
selectedItem = 2;
selectedItemName = "M&M's";
$('#itemBox').val(selectedItem);
})

$('#box3').click(function(){
    $('#itemBox').empty();
selectedItem = 3;
selectedItemName = "Almond Joy";
$('#itemBox').val(selectedItem);
})

$('#box4').click(function(){
    $('#itemBox').empty();
selectedItem = 4;
selectedItemName = "Milky Way";
$('#itemBox').val(selectedItem);
})

$('#box5').click(function(){
    $('#itemBox').empty();
selectedItem = 5;
selectedItemName = "Payday";
$('#itemBox').val(selectedItem);
})

$('#box6').click(function(){
    $('#itemBox').empty();
selectedItem = 6;
selectedItemName = "Reese's";
$('#itemBox').val(selectedItem);
})

$('#box7').click(function(){
    $('#itemBox').empty();
selectedItem = 7;
selectedItemName = "Pringles";
$('#itemBox').val(selectedItem);
})

$('#box8').click(function(){
    $('#itemBox').empty();
selectedItem = 8;
selectedItemName = "Cheezits";
$('#itemBox').val(selectedItem);
})

$('#box9').click(function(){
    $('#itemBox').empty();
selectedItem = 9;
selectedItemName = "Doritos";
$('#itemBox').val(selectedItem);
})