using myModels;
namespace myModels.Interfaces;
public interface Iorders
{
  Task<bool> addOrder(int id, int pay, bool ifPay,CreditCardDetails c1);
    Task<bool> PayByCreditCard(bool ifPay,CreditCardDetails creditCardDetails);
    Task<bool> makePizza();
    Task<bool> mailInvoke(int Id,int Pay);
        // void addPizza(int id,int pay,bool ifPay);
}