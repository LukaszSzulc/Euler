namespace Euler
{
    public class Neighbor
    {
        public Neighbor()
        {
            Exists = default(bool);
            Index = default(int);
        }

        public bool Exists { get; set; }

        public int Index { get; set; }
    }
}