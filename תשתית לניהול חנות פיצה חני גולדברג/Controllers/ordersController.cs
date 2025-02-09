using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using myModels;
using myModels.Interfaces;

namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers;

public class OrdersController : BaceController
{
    Iorders _Iorder;
    public OrdersController(Iorders order){
        _Iorder=order;
    }
    [Route("[action]/{id}/{pay}/{ifPay}/{creditCardDetailes}/{CardNumber}/{CardHolderName}/{CVV}/{CardType}")]
    [HttpPost]
    public  IActionResult addOrder(int id,int pay,bool ifPay,string CardNumber,string CardHolderName,string CVV,string CardType)
    {
        CreditCardDetails c1=new CreditCardDetails(CardNumber,CardHolderName,CVV,CardType);
       Task<bool> b= _Iorder.addOrder( id,  pay,  ifPay,c1);
        // if (1==1){
          return Created();
        // }
        //return NotFound("you need to enter id smaller");
        
    }
}
// using System.ComponentModel.DataAnnotations;
// using System.Security.Cryptography;
// using Microsoft.AspNetCore.Mvc;
// using myModels;
// using myModels.Interfaces;

// namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers
// {
//     public class OrdersController : BaceController
//     {
//         Iorders _Iorder;
//         public OrdersController(Iorders order)
//         {
//             _Iorder = order;
//         }

//         [Route("[action]")]
//         [HttpPost]
//         public async Task<IActionResult> addOrder(int id, int pay, bool ifPay, CreditCardDetails creditCardDetailes)
//         {
//             bool b = await _Iorder.addOrder(id, pay, ifPay, creditCardDetailes); // Await the task
//             if (b) // Check if b is true
//             {
//                 return Created();
//             }
//             return NotFound("You need to enter id smaller");
//         }
//     }
// }

