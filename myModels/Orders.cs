// 
using myModels;  // Ensures the namespace is correctly included

public class Orders
{
    public int Id { get; set; }  // It is a convention to use PascalCase for public properties
    public int Pay { get; set; }
    public bool IfPay { get; set; }
    public bool PayByCreditCard { get; set; }
    public CreditCardDetails CreditCardDetails { get; set; }  // Declare the property
    
    public Orders(int id, int pay, bool ifPay, CreditCardDetails creditCardDetails)
    {
        this.Id = id;
        this.Pay = pay;
        this.IfPay = ifPay;
        this.CreditCardDetails = creditCardDetails;
    }
}