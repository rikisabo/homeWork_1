using Microsoft.AspNetCore.Mvc;
using תשתית_לניהול_חנות_פיצה_חני_גולדברג;
public interface Iorders
{
    bool addOrder(int id, int pay, bool ifPay);
    void addPizza(int id,int pay,bool ifPay);
}