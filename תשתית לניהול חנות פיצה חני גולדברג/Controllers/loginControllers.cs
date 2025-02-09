using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myModels.Interfaces;
using myServices;


namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers
{
    [Route("[controller]")]
    public class LoginController : BaceController

    {
        private readonly ILogger<LoginController> _logger;
        Ilogin _login;

        public LoginController(ILogger<LoginController> logger, Ilogin login)
        {
            _logger = logger;
            _login = login;
        }

        [HttpPost]
        [Route("[action]/{name}/{password}")]
        public ActionResult<String> Login(string name, string password)
        {

            // var dt = DateTime.Now;
            Worker w1 = _login.IsExists(name, password);
            if (w1 == null)
            {
                return Unauthorized();
            }


            var claims = new List<Claim>
     {
         new Claim("Role", w1.Role)
        //  new Claim("name","superWorker"),
        //  new Claim("brithdatae","")
     };

            var token = PizzaTokenService.GetToken(claims);

            return new OkObjectResult(PizzaTokenService.WriteToken(token));
        }
    }

}







