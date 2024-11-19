using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Services;
public class OrdersServices : Iorders
{
     List<Orders> orders=new List<Orders>()
    {
        new Orders(10,200,true)
    };
public bool addOrder(int id,int pay ,bool ifPay)
{
     if(id<200){
        Orders o=new Orders(id,pay,ifPay);
        orders.Add(o);
        return true;
        }
        return false;
}

    public void addPizza(int id, int pay, bool ifPay)
    {
        throw new NotImplementedException();
    }
}