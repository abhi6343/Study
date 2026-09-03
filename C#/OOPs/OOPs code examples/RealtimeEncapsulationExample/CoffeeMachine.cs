namespace RealtimeEncapsulationExample
{
    internal class CoffeeMachine
    {
        private int waterAmount; // in milliliters
        private int beansAmount; // in grams
        private bool isHeated;
        public CoffeeMachine(int water, int beans)
        {
            waterAmount = water;
            beansAmount = beans;
            isHeated = false;
        }
        private void HeatWater()
        {
            if (!isHeated)
            {
                Console.WriteLine("Heating water...");
                isHeated = true;
            }
        }
        private void GrindBeans(int amount)
        {
            if (beansAmount < amount)
            {
                throw new InvalidOperationException("Not enough coffee beans!");
            }
            Console.WriteLine("Grinding coffee beans...");
            beansAmount -= amount;
        }
        // This is the method exposed to the user.
        public void MakeEspresso()
        {
            HeatWater();
            GrindBeans(20); // let's say we need 20 grams of beans for an espresso
            Console.WriteLine("Making Espresso...");
        }
        // Another method exposed to the user.
        public void MakeLatte()
        {
            HeatWater();
            GrindBeans(25); // we need 25 grams of beans for a latte
            Console.WriteLine("Making Latte...");
        }
        public int BeansLeft()
        {
            return beansAmount;
        }
        public int WaterLeft()
        {
            return waterAmount;
        }
    }
}
