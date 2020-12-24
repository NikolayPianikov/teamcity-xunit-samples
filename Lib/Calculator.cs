namespace Lib
{
    public class Calculator  
    {
        public int Add(int leftOp, int rightOp)
        {
            checked
            {
                return leftOp + rightOp;
            }
        }
    }
}
