namespace SemaphoreSlim
{
    internal class CreditCard
    {
        //public string CardNumber { get; set; }
        public long CardNumber { get; set; }
        public string Name { get; set; }
        public static List<CreditCard> GenerateCreditCards(int number)
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            for (int i = 0; i < number; i++)
            {
                CreditCard card = new CreditCard()
                {
                    //CardNumber = "10000000" + i,
                    CardNumber = 10000000 + i,
                    Name = "CreditCard-" + i
                };
                creditCards.Add(card);
            }
            return creditCards;
        }
    }
}
