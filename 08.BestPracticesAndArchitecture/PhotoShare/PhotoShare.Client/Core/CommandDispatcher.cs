namespace PhotoShare.Client.Core
{
    using Commands;
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string cmdName = commandParameters[0];
            string result = string.Empty;
            switch (cmdName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand();
                    result = addTown.Execute(commandParameters);
                    break;

                case "ModifyUser":
                    ModifyUserCommand modifyUser = new ModifyUserCommand();
                    result = modifyUser.Execute(commandParameters);
                    break;

                case "DeleteUser":
                    DeleteUser deleteUser = new DeleteUser();
                    result = deleteUser.Execute(commandParameters);
                    break;

            }
            throw new NotImplementedException();
        }
    }
}
