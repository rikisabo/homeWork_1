using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers;

public class WorkerController : BaceController
{
    Iworker _Iworker;
    public WorkerController(Iworker w){
        _Iworker=w;
    }
    [Route("[action]")]
    [HttpPost]
    public IActionResult addWorker(string name,int age,int salary){
       bool a=_Iworker.addWorker(name,age,salary);
       if(a==true){
        return Created();
       }
       return NotFound("you cant en this name its exist");
    }
}
