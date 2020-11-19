namespace ServerForm
{
    public class PlayerWithID
    {
        public readonly uint ID;
        public string Input;
        public bool HasFinishedLoadingGame;

        public PlayerWithID(uint ID)
        {
            this.ID = ID;
            Input = "";
            HasFinishedLoadingGame = false;
        }

        internal void CreateSquare()
        {
            Input = "[]";
        }

        internal void CreateCircle()
        {
            Input = "O";
        }
    }
}
