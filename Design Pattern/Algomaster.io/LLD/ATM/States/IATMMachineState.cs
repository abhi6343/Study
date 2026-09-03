using ATM.Enums;
using ATM.Singleton;

namespace ATM.States
{
    internal interface IATMMachineState
    {
        void InsertCard(ATMMachine atm, string cardNumber);
        void EnterPin(ATMMachine atm, string pin);
        void SelectOperation(ATMMachine atm, OperationType op, int amount = 0);
        void EjectCard(ATMMachine atm);
    }
}
