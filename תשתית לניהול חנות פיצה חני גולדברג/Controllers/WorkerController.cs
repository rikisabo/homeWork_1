using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myModels.Interfaces;
namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Controllers;

public class WorkerController : BaceController
{
    Iworker _Iworker;
    public WorkerController(Iworker w){
        _Iworker=w;
    }
    [Route("[action]/{name}/{age}/{password}/{role}/{salary}")]
    [HttpPost]
    // [Authorize(Policy = "Admin")]
    public IActionResult addWorker(string name,int age,int salary,string role,string password){
       bool a=_Iworker.addWorker(name,age,salary,role,password);
       if(a==true){
        return Created();
       }
       return NotFound("you cant en this name its exist");
    }
    
}
