using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Services;
public class WorkerServices : Iworker
{
List <Worker> workers=new List<Worker>
    {
        new Worker("Avi",20,1548),
        new Worker("Dovi",25,45987)
    };
    public bool addWorker(string name,int age,int salary){
   foreach (var item in workers)
   {
    if(item.name!=name){
        Worker i=new Worker(name,age,salary);
        workers.Add(i);
        return true; 
    }
    
   }return false;
    }
}