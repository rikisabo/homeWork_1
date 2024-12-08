var baseURL = "http://localhost:5190";
function load() {
    // fetch(baseURL +"/getPizzaList")
    //     .then((res) => res.json())
    //     .then((data) => fillPizzaTbl(data))
    //     .catch((error) => console.log(error))
    fetch("http://localhost:5190/ChanisPizza/setPizza", requestOptions)
    .then((response) => response.json())
    .then((result) => console.log(result))
    .then((data) => fillPizzaTbl(data))
    .catch((error) => console.error(error));
}

function fillPizzaTbl(data) {
    var table = document.getElementById('Pizzalist');
    data.forEach(function (pizza) {
        var tr = document.createElement('tr');
        tr.innerHTML = '<td>' + pizza.pizzaName + '</td>' +
            '<td>' + pizza.pizzaId + '</td>' +
            '<td>' + pizza.ifGloten + '</td>'        
        var tBody = table.getElementsByTagName('tbody')[0];
        tBody.appendChild(tr);
    });
}
function addPizza() {
    var pizza={};
    pizza.pizzaName=document.getElementById('pizzaName').value;
    pizza.pizzaId=document.getElementById('pizzaId').value;
    pizza.ifGloten=document.getElementById('pizzaIdpizzaId').value;
    

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza);

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    };

    fetch(baseURL+"תשתית לניהול חנות פיצה חני גולדברג/getPizzaList", requestOptions)
        .then(response => afterPost())
        // .then(response => ())
        .catch(error => console.log('error', error));
}

function afterPost(params) {
    alert("");
    load();
}