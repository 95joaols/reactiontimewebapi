namespace ReactionGame.Entety
{
    public class Highscore
    {
        public Highscore(string name, long time)
        {
            Name = name;
            Time = time;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Time { get; set; }

        public override string ToString()
        {
            return Name + "  -  " + Time;
        }
    }
}