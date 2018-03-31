using System;
using Microsoft.Extensions.DependencyInjection;
using PasswordExercise.Interfaces;
using PasswordExercise.Services;

namespace PasswordExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPasswordGeneratorService, PasswordGenerator>()
                .AddSingleton<IPasswordService, PasswordService>()
                .BuildServiceProvider();

            //Get the required service
            var passwordService = serviceProvider.GetService<IPasswordService>();

            //For reading from the console
            ConsoleKeyInfo key;

            //Display the menu
            passwordService.Menu();

            do
            {

                //Read the console key, do not display on the screen
                key = Console.ReadKey(true);

                switch (key.KeyChar.ToString())
                {
                    case "1":
                        Console.WriteLine("Simple password: {0}", passwordService.SimplePassword());
                        break;
                    case "2":
                        Console.WriteLine("Moderate password: {0}", passwordService.ModeratePassword());
                        break;
                    case "3":
                        Console.WriteLine("Strong password: {0}", passwordService.StrongPassword());
                        break;
                }

            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
