namespace InterfaceRealtimeExample
{
    internal interface IBankAccount
    {
        bool DepositAmount(decimal amount);
        bool WithdrawAmount(decimal amount);
        decimal CheckBalance();
    }
}
