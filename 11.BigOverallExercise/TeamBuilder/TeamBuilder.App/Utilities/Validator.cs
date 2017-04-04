namespace TeamBuilder.App.Utilities
{
    using System;
    using TeamBuilder.Models;

    public static class Validator
    {
        public static void CheckLength(int expectedLength, string[] array)
        {
            if (expectedLength != array.Length)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }
        }
        public static void ValidateInvitation(string teamName, User user)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, user))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
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

        public static void ValidateAddTeamToEvent(string eventName, string teamName, int currentUserId)
        {
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsUserCreatorOfEvent(eventName, currentUserId))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }
        }
    }
}
