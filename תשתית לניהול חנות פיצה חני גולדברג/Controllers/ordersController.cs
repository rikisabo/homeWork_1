using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using myModels.Interfaces;
namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers;

public class OrdersController : BaceController
{
    Iorders _Iorder;
    public OrdersController(Iorders order){
        _Iorder=order;
    }
    [Route("[action]")]
    [HttpPost]
    public IActionResult addOrder(int id,int pay,bool ifPay){
        bool b=_Iorder.addOrder(id,pay,ifPay);
        if (b==true){
          return Created();
        }
        return NotFound("you nedd to enter id smaller");
        
    }
}