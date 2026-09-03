namespace RestaurantManagementSystem.Decorators
{
    internal interface IBillComponent
    {
        double CalculateTotal();
        string GetDescription();
    }
}
