namespace _01.OOPIntro
{
    class Calculation
    {
        private const double Planck = 6.62606896e-34;
        private const double Pi = 3.14159;
        public static double ReducePlanck()
        {
            double result;
            result = Planck / (2 * Pi);
            return result;
        }
    }
}
