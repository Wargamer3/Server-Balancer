namespace ClientForm
{
    public class PlayerWithID
    {
        public readonly uint ID;
        public string Input;
        public bool HasFinishedLoadingGame;

        public PlayerWithID(uint ID)
            : this(ID, "")
        {
        }

        public PlayerWithID(uint ID, string Input)
        {
            this.ID = ID;
            this.Input = Input;
            HasFinishedLoadingGame = true;//Since there's nothing to load, always true.
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
