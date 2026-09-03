namespace RealtimeEncapsulationExample
{
    internal class Car
    {
        private int wheelRotations;
        private double gearRatio = 4.2;  // Simplified representation of gear ratio
        private const double WHEEL_CIRCUMFERENCE = 2.0; // Assuming each wheel rotation covers 2 meters
        // Constructor to initialize the car
        public Car()
        {
            wheelRotations = 0;
        }
        // This method simulates the car moving and the wheel rotating
        private void Move()
        {
            // For simplicity, we're assuming each call to Move represents one wheel rotation.
            wheelRotations++;
        }
        private double CalculateSpeed()
        {
            // Calculates speed based on wheel rotations and gear ratio
            double distanceCovered = wheelRotations * WHEEL_CIRCUMFERENCE;
            double time = 1.0; // Assume 1 second for simplicity
            return (distanceCovered * gearRatio) / time;
        }
        // Public method to drive the car
        public void Drive()
        {
            Move();
            Console.WriteLine($"Current speed: {CalculateSpeed()} m/s");
        }
        // Let's say there's a mechanism to reset the speedometer
        public void ResetSpeedometer()
        {
            wheelRotations = 0;
        }
    }
}
