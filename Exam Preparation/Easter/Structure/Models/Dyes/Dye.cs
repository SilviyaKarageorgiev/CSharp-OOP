using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {

        }

        public int Power => throw new System.NotImplementedException();

        public bool IsFinished()
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
