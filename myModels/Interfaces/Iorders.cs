
namespace myModels.Interfaces;
public interface Iorders
{
    bool addOrder(int id, int pay, bool ifPay);
    void addPizza(int id,int pay,bool ifPay);
}