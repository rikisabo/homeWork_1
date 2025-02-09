var baseURL = "http://localhost:5190";
var token;
function getToken() {
    // Logic to get the token, e.g., from local storage
    return localStorage.getItem('authToken') || "0"; // Default to "0" if no token found
}
function Login() {
    document.getElementById('loginForm').addEventListener('submit', function (e) {
        e.preventDefault();

        const name = document.getElementById('name').value;
        const password = document.getElementById('password').value;

        console.log('Name:', name);
        console.log('Password:', password);
        const myHeaders = new Headers();
        myHeaders.append("Content-type", "application/json");
        const requestOptions = {
            method: "POST",
            headers: myHeaders,
            redirect: "follow"
        };
        //const token = getToken();
        // var status = 0;
        fetch(baseURL + `/Login/Login/${name}/${password}`, requestOptions)
            .then(response =>

                // console.log( "Response: "+response.text());
                // // response.text();
                // if (response.ok) {
                //     // The request was successful, and the user is authorized
                //     const data = response;
                //     console.log('Authorized:', data);
                //     alert("you athorize!!!! 😘😘");
                //     const pizzaDiv = document.querySelector('.divFuncAddPizza');
                //     pizzaDiv.style.display = (pizzaDiv.style.display === 'block') ? 'none' : 'block';
                //     // window.open('addPizza.html')
                //     // .then((result) => requestOptions1.Authorize = "Bearer" + result)

                // } else if (response.status === 401) {
                //     // Unauthorized
                //     console.log('Unauthorized access - please log in.');
                //     alert("no no you dont athorize😒😒😒");
                // } else {
                //     // Other status codes
                //     console.log('Error:', response.status, response.statusText);
                // }
                response.text()
            )
            .then(res => {
                // token = data;
                token = res;
                if (!res.includes("Unauthorized")) {
                    // 
                    token = res; // Assuming the token is returned directly; otherwise, modify this to extract it from the response.
                if (!res.includes("Unauthorized")) {
                    console.log("token", res);
                    alert("You are authorized!!!! 😘😘");

                    const pizzaDiv = document.querySelector('.divFuncAddPizza');
                    // Decode the JWT token to get claims
                    const decodedToken = jwt_decode(token); // Use jwt-decode library or similar
                    
                    // Check the role from the decoded token
                    if (decodedToken.Role === "SuperWorker") {
                        pizzaDiv.style.display = 'block'; // Show the addPizza functionality
                    } else {
                        pizzaDiv.style.display = 'none'; // Hide it if the role is not superWorker
                    }
                    getListPizza();
                }
                else {
                    console.log("error", res);
                    console.log('Unauthorized access - please log in.');
                    alert("no no you dont athorize😒😒😒");
                }
                // console.log("Token:", token);
                // return response.json();
            }})
            .catch((error) => console.log('error', error))
    });
}


function addPizza() {
    var pizza = {};
    pizza.pizzaName = document.getElementById('pizzaName').value;
    pizza.pizzaId = document.getElementById('pizzaId').value;
    pizza.ifGloten = document.getElementById('ifGloten').value;
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    myHeaders.append("Authorization", `Bearer ${token}`);

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
function getListPizza() {
    const myHeaders = new Headers();
    myHeaders.append("Authorization", `Bearer ${token}`);

    const requestOptions = {
        method: "GET",
        headers: myHeaders,
        redirect: "follow"
    };

    fetch("http://localhost:5190/ChanisPizza/getPizzaList", requestOptions)
        .then((response) => response.text())
        .then((result) => console.log(result))
        .catch((error) => console.error(error));
}

function afterPost(params) {
    alert("");
    load();
}
