namespace TemplateDesignPattern
{
    public abstract class Game
    {
        public abstract void initialize();
        public abstract void startPlay();
        public abstract void endPlay();
        public void play()  // Final so it can't be overridden
        {
            // Initialize the game
            initialize();
            // Start game
            startPlay();
            // End game
            endPlay();
        }

    }
}
