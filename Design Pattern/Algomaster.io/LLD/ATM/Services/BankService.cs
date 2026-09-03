using ATM.Entities;

namespace ATM.Services
{
    internal class BankService
    {
        readonly Dictionary<string, Account> accounts = [];
        readonly Dictionary<string, Card> cards = [];
        readonly Dictionary<Card, Account> cardAccountMap = [];

        public BankService()
        {
            // Create sample accounts and cards
            var account1 = CreateAccount("1234567890", 1000.0);
            var card1 = CreateCard("1234-5678-9012-3456", "1234");
            LinkCardToAccount(card1, account1);

            var account2 = CreateAccount("9876543210", 500.0);
            var card2 = CreateCard("9876-5432-1098-7654", "4321");
            LinkCardToAccount(card2, account2);
        }

        public Account CreateAccount(string accountNumber, double initialBalance)
        {
            Account account = new(accountNumber, initialBalance);
            accounts[accountNumber] = account;
            return account;
        }

        public Card CreateCard(string cardNumber, string pin)
        {
            Card card = new(cardNumber, pin);
            cards[cardNumber] = card;
            return card;
        }

        public static bool AuthenticateCard(Card? card, string pin) => card?.Pin == pin;

        public Card? IsCardPresentInCardsDict(string cardNumber)
        {
            return cards.TryGetValue(cardNumber, out var card) ? card : null;
        }

        public double GetBalance(Card? card)
        {
            return cardAccountMap[card].Balance;
        }

        public void WithdrawMoney(Card? card, double amount)
        {
            cardAccountMap[card].Withdraw(amount);
        }

        public void DepositMoney(Card? card, double amount)
        {
            cardAccountMap[card].Deposit(amount);
        }

        public void LinkCardToAccount(Card card, Account account)
        {
            account.Cards[card.CardNumber] = card;
            cardAccountMap[card] = account;
        }
    }
}
