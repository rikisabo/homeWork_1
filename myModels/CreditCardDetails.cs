
namespace myModels
{
    public class CreditCardDetails  // Corrected class name
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        // public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string CardType { get; set; } // Uncommented to include CardType

        // Default Constructor
        public CreditCardDetails() 
        {
            CardNumber="1111111";
            CardHolderName="rikisabo";
            // ExpirationDate=DateTime.Now;
            CVV="123";
            CardType="visa";

         }

        // Parameterized Constructor
        public CreditCardDetails(string cardNumber, string cardHolderName,  string cvv, string cardType)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            // ExpirationDate = expirationDate;
            CVV = cvv;
            CardType = cardType;
        }
    }
}