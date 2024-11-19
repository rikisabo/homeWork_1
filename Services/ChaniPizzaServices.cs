using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.Services;
public class ChanisPizzaServices : IpizzaMannager
{
    List<ChanisPizza> p1 = new List<ChanisPizza>()
    {
        new ChanisPizza("pizzaShemesh",1,true),
        new ChanisPizza("pizzaHot",2,false),
        new ChanisPizza("pizzaStory",3,true),
        new ChanisPizza("Shamenet",4,true)
    };
    public List<ChanisPizza> getPizzaList()
    {
        if (p1 != null)
            return p1;
        return null;
    }
    public ChanisPizza getPizza(int id)
    {
        foreach (var i in p1)
        {
            if (i.pizzaId == id)
                return i;
        }
        return null;
    }
    public ChanisPizza getPizzaByName(string name)
    {
        foreach (var i in p1)
        {
            if (i.pizzaName.Equals(name))
                return i;
        }
        return null;
    }
    public void setPizza(string name, int id, bool ifGloten)
    {
        ChanisPizza c1 = new ChanisPizza(name, id, ifGloten);
        p1.Add(c1);

    }
    public bool deletePizza(int id)
    {
        foreach (var i in p1)
        {
            if (i.pizzaId == id)
            {
                p1.Remove(i);
                return true;
            }
        }
        return false;
    }
    public bool updatePizza(int id, bool ifGloten)
    {
  foreach (var i in p1)
            {
                  if (i.pizzaId == id)
                  {
                        i.ifGloten = ifGloten;
                        return true;
                  }
            }
            return false;
    }


}
