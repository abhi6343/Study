namespace ATM.Entities
{
    internal class Card(string cardNumber, string pin)
    {
        public string CardNumber => cardNumber;
        public string Pin => pin;
    }
}
