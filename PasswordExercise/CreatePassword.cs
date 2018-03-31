using PasswordExercise.Interfaces;
using PasswordExercise.Models;
using System;

namespace PasswordExercise
{
    /// <summary>
    /// Password service for creating the password requirements
    /// </summary>
    public class PasswordService : IPasswordService 
    {
        /// <summary>
        /// Injected password service
        /// </summary>
        private readonly IPasswordGeneratorService _passwordGenerator;

        /// <summary>
        /// .ctr
        /// </summary>
        /// <param name="passwordGenerator">IPasswordGeneratorService</param>
        public PasswordService(IPasswordGeneratorService passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }

        /// <summary>
        /// Main menu
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("Create a password");
            Console.WriteLine();
            Console.WriteLine("1. Create simple password");
            Console.WriteLine("2. Create moderate password");
            Console.WriteLine("3. Create complex password");
            Console.WriteLine("Press the Escape (Esc) key to quit: {0}", Environment.NewLine);
        }

        /// <summary>
        /// Create a simple password option
        /// </summary>
        /// <returns>A simple password string</returns>
        public string SimplePassword()
        {
            var requirements = new PasswordRequirements
            {
                MinLength = 8,
                MaxLength = 10
            };

           return _passwordGenerator.GeneratePassword(requirements);
        }

        /// <summary>
        /// Create a moderate password option
        /// </summary>
        /// <returns>A moderate password string</returns>
        public string ModeratePassword()
        {
            var requirements = new PasswordRequirements
            {
                MinLength = 10,
                MaxLength = 12,
                MinSpecialChars = 1
            };

            return _passwordGenerator.GeneratePassword(requirements);
        }

        /// <summary>
        /// Create a strong password option
        /// </summary>
        /// <returns>A strong password string</returns>
        public string StrongPassword()
        {
            var requirements = new PasswordRequirements
            {
                MinLength = 12,
                MaxLength = 16,
                MinNumericChars = 3,
                MinUpperAlphaChars = 3,
                MinLowerAlphaChars = 3,
                MinSpecialChars = 3
            };

            return _passwordGenerator.GeneratePassword(requirements);
        }
    }
}
