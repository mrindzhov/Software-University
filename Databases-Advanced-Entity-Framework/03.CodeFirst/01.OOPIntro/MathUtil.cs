namespace _01.OOPIntro
{
    public class MathUtil
    {
        public static float Sum(float firstNum, float secondNum)
        {
            float result;
            result = firstNum + secondNum;
            return result;
        }
        public static float Subtract(float firstNum, float secondNum)
        {
            float result;
            result = firstNum - secondNum;
            return result;
        }
        public static float Multiply(float firstNum, float secondNum)
        {
            float result;
            result = firstNum * secondNum;
            return result;
        }
        public static float Divide(float divident, float divisor)
        {
            float result;
            result = divident / divisor;
            return result;
        }
        public static float Percentage(float baseNum, float percent)
        {
            float result;
            result = baseNum * percent/100;
            return result;
        }
    }
}