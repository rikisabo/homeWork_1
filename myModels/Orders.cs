using myModels;
public class Orders
{
    private int v1;
    private int v2;
    private bool v3;

    public int id{get;set;}
    public int pay{get;set;}
    public bool ifPay{get;set;}
    
    public Orders(int id,int pay, bool ifPay){
    this.id=id;
    this.pay=pay;
    this.ifPay=ifPay;
    }

    public Orders(int v1, int id, int v2, int pay, bool v3, bool ifPay)
    {
        this.v1 = v1;
        this.id = id;
        this.v2 = v2;
        this.pay = pay;
        this.v3 = v3;
        this.ifPay = ifPay;
    }
}