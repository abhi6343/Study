using ElevatorSystem.Observer;

namespace ElevatorSystem.Entities
{
    internal class Floor(int floorNumber)
    {
        bool _upButtonPressed = false;
        bool _downButtonPressed = false;
        readonly Display _display = new(0);

        public void PressUpButton()
        {
            _upButtonPressed = true;
        }

        public void PressDownButton()
        {
            _downButtonPressed = true;
        }

        public void ResetButtons()
        {
            _upButtonPressed = false;
            _downButtonPressed = false;
        }

        public int FloorNumber => floorNumber;
        public bool IsUpButtonPressed => _upButtonPressed;
        public bool IsDownButtonPressed => _downButtonPressed;
        public Display Display => _display;
    }
}
