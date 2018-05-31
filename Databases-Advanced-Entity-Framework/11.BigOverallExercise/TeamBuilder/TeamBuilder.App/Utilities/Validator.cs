namespace TeamBuilder.App.Utilities
{
    using System;
    using System.IO;
    using System.Linq;
    using TeamBuilder.App.Core;
    using TeamBuilder.Models;

    public static class Validator
    {
        public static void ValidateLength(int expectedLength, string[] array)
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

        public static void ValidateLogin()
        {
            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

        }

        public static void ValidatePath(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
        }

        public static void ValidateAddTeamToEventCommand(string eventName, string teamName, int currentUserId)
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

        public static void ValidateRegisterUserCommand(string username, string password, string repeatPassword, int age, bool isNumber, bool isGenderValid)
        {
            if (username.Length > Constants.MaxUsernameLength || username.Length < Constants.MinUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }


            if (password != repeatPassword)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordDoesNotMatch));
            }


            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }
            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }
        }

        public static void ValidateShowEventCommand(string eventName)
        {
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }
        }

        public static void ValidateShowTeamCommand(string teamName)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
        }

        public static void ValidateAddTeamToCommand(string teamName, string username)
        {
            if (!CommandHelper.IsTeamExisting(teamName) || !CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }
            if (CommandHelper.IsInvitePending(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!CommandHelper.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
        }

        public static void ValidateExportTeamCommand(string teamName)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
        }

        public static void ValidateKickMemberCommand(string teamName, string username)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, username));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, username, teamName));
            }
            if (CommandHelper.IsCreatorOfTeam(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
            if (AuthenticationManager.GetCurrentUser().Username == username)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "Disband Team"));
            }
        }

        public static void ValidateDisbandCommand(string teamName)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
            if (!CommandHelper.IsCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser().Username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
        }

        public static void ValidateCreateTeamCommand(string[] args, string teamName, string acronym)
        {
            if (args.Length != 2 && args.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(args));
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }
        }

        public static void ValidateCreateEventCommand(DateTime startDate, DateTime endDate, bool IsStartDate, bool IsEndDate)
        {
            if (!IsEndDate || !IsStartDate)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date should be before end date.");
            }
        }
    }
}