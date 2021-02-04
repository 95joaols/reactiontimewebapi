namespace ReactionGame.Entety
{
    public class Highscore
    {
        public string Name { get; set; }
        public long Time { get; set; }

        public override string ToString()
        {
            return Name + "  -  " + Time;
        }
    }
}