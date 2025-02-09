using myModels;
using myModels.Interfaces;
using FileService; 
using FileService.Interfaces;
namespace myServices;
public class ChanisPizzaServices : IpizzaMannager
{
    IFileService<ChanisPizza> _file;

    string _path=@"H:\webApi\חדש\file.json";
    public ChanisPizzaServices(IFileService<ChanisPizza> file){
        _file=file;
    }
    List<ChanisPizza> p1 = new List<ChanisPizza>()
    {
        new ChanisPizza("pizzaShemesh",1,true),
        new ChanisPizza("pizzaHot",2,false),
        new ChanisPizza("pizzaStory",3,true),
        new ChanisPizza("Shamenet",4,true)
    };
    public List<ChanisPizza> getPizzaList()
    {
       var p2=_file.Read(_path);
       if(p2!=null){
        return p2;
       }
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
 
    public ChanisPizza getPizzaByName( string name)
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
        _file.Write(c1,_path);

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
