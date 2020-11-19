using System;

namespace ProjectEternity.Core.Online
{
    public class Player
    {
        public string ID;
        public string Name;
        public string Password;
        public int Money;
        public int Exp;

        public override string ToString()
        {
            return Name + " (" + ID + ")";
        }
    }
}
