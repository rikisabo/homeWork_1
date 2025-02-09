
using myModels;
using myModels.Interfaces;
namespace myServices;
public class OrdersServices : Iorders
{
    // IFileService<ChanisPizza> _file;

    // string _path=@"H:\webApi\חדש\mails.json";
    // public OrdersServices(IFileService<ChanisPizza> file){
    //     _file=file;
    // }
    List<Orders> orders = new List<Orders>()
    {
        new Orders(10,200,false,new CreditCardDetails())
    };
    //add order
    public  async Task<bool> addOrder(int id, int pay, bool ifPay,CreditCardDetails c1)
    {
        if (id < 200)
        {
            
            Orders o = new Orders(id, pay, ifPay,c1);
            orders.Add(o);
            Task<bool> pay1 =PayByCreditCard(ifPay,c1);
            bool t1=await pay1;
            Task<bool> makePizza1=makePizza();
            Task<bool> mailInvoke1=mailInvoke(id,pay);
            return true;
        }
        return false;
    }
    //pay
    public async Task<bool> PayByCreditCard(bool IfPay, CreditCardDetails creditCardDetails)
    {
        Console.WriteLine("paying$$$$");
        IfPay = true;
        Task.Delay(11000);
        return true;
    }
    //make pizza
    public async Task<bool> makePizza()
    {
        Task.Delay(100000);
        Console.WriteLine("the dough is ready!!!");
        Task.Delay(2000);
        Console.WriteLine("the pizza is ready,very tasty!!!");
        return true;
    }
    //send invoke
    public async Task<bool> mailInvoke(int Id, int Pay)
    {
        // _file.Write("the order: "+Id+" the pay: "+pay);
        Console.WriteLine("mail invoke!!!");
        Task.Delay(5678930);
        return true;
    }
 
}