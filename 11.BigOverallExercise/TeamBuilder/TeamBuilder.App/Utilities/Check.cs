namespace TeamBuilder.App.Utilities
{
    public static class Check
    {
        public static void CheckLength(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new System.FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }
        }
        //TODO add more checkers .... should be static only

    }
}