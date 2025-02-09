var baseURL = "http://localhost:5190";


function addPizza() {
    var pizza = {};
    pizza.pizzaName = document.getElementById('pizzaName').value;
    pizza.pizzaId = document.getElementById('pizzaId').value;
    pizza.ifGloten = document.getElementById('ifGloten').value;
    // var pizza = {
    //     name: document.getElementById('pizzaName').value,
    //     isGluten: document.getElementById('ifGloten').value === 'true', // לדוג' אם יש לבחור בין "true" ו-"false"
    //     id: document.getElementById('pizzaId').value,
    // };

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify(pizza);

    var requestOptions1 = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    };
    console.log("Sending data:", raw);
    fetch(baseURL + `/ChanisPizza/setPizza/${pizza.pizzaName}/${pizza.pizzaId}/${pizza.ifGloten}`
        , requestOptions1)
        .then((result) => console.log("riki:"))
        // .then((response) => response.json())
        .then((result) => alert("good good"))
        // .then((data) => fillPizzaTbl(data))
        .catch((error) => console.log('error', error));
}
// function fillPizzaTbl(data) {
// var table = document.getElementById('Pizzalist');
// data.forEach(function (pizza) {
//     var tr = document.createElement('tr');
//     tr.innerHTML = '<td>' + pizza.pizzaName + '</td>' +
//         '<td>' + pizza.pizzaId + '</td>' +
//         '<td>' + pizza.ifGloten + '</td>'        
//     var tBody = table.getElementsByTagName('tbody')[0];
//     tBody.appendChild(tr);
// });

// }
function afterPost(params) {
    alert("");
    load();
}