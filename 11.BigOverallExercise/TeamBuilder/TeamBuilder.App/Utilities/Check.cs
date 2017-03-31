namespace TeamBuilder.App.Utilities
{
    public static class Check
    {
        public static void Length(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new System.FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }
        }
        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        //TODO add more checkers .... should be static only

    }
}