namespace ATM.ChainOfResponsibility
{
    internal interface IDispenseChain
    {
        public IDispenseChain? NextChain { get; set; }
        void Dispense(int amount);
        bool CanDispense(int amount);
    }
}
