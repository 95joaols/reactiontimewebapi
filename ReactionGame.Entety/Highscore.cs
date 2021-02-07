namespace ReactionGame.Entety
{
    public class Highscore : IdEntety
    {
        public Highscore(string name, long time) : base(name)
        {
            Time = time;
        }

        
        public long Time { get; set; }

        public override string ToString()
        {
            return Name + "  -  " + Time;
        }
    }
}