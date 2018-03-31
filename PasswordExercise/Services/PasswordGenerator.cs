using PasswordExercise.Interfaces;
using PasswordExercise.Models;
using System;
using System.Linq;

namespace PasswordExercise.Services
{
    public class PasswordGenerator : IPasswordGeneratorService
    {
        //Create random for character string
        private static readonly Random Random = new Random();

        //populate array with all possible chars to meet password requirements
        private static readonly char[] Chars = Enumerable
                .Range(0, 128)
                .Select(x => (char)x)
                .Where(c => char.IsUpper(c) || char.IsLower(c) || char.IsSymbol(c) || char.IsPunctuation(c) || char.IsNumber(c))
                .ToArray();

        public string GeneratePassword(PasswordRequirements requirements)
        {
            var password = GenerateUppercase(requirements.MinUpperAlphaChars);
            password = string.Concat(password, GenerateLowercase(requirements.MinLowerAlphaChars));
            password = string.Concat(password, GenerateNumeric(requirements.MinNumericChars));
            password = string.Concat(password, GenerateSpecial(requirements.MinSpecialChars));
            password = string.Concat(password, GeneratePadding(requirements.MinLength, requirements.MaxLength, password.Length));

            //randomize the password
            return new string(password.ToCharArray().OrderBy(c => (Random.Next())).ToArray());

        }

        /// <summary>
        /// Generates an uppercase aplhabetic string of minimum length  
        /// </summary>
        /// <param name="minLength">The minimum length required</param>
        /// <returns>Uppercase string</returns>
        private string GenerateUppercase(int minLength)
        {
            var chars = Chars.Where(c => char.IsUpper(c)).ToArray();
            return BuildString(minLength, chars);
        }

        /// <summary>
        /// Generates an lowercase aplhabetic string of minimum length  
        /// </summary>
        /// <param name="minLength">The minimum length required</param>
        /// <returns>Lowercase string</returns>
        private string GenerateLowercase(int minLength)
        {
            var chars = Chars.Where(c => char.IsLower(c)).ToArray();
            return BuildString(minLength, chars);
        }

        /// <summary>
        /// Generates an string of numeric characters of minimum length  
        /// </summary>
        /// <param name="minLength">The minimum length of the string</param>
        /// <returns>String containing numeric characters</returns>
        private string GenerateNumeric(int minLength)
        {
            var chars = Chars.Where(c => char.IsNumber(c)).ToArray();
            return BuildString(minLength, chars);
        }

        /// <summary>
        ///  Generates an string of special characters of minimum length  
        /// </summary>
        /// <param name="minLength">The minimum length of the string</param>
        /// <returns>String containing special characters</returns>
        private string GenerateSpecial(int minLength)
        {
            var chars = Chars.Where(c => Char.IsPunctuation(c) || Char.IsSymbol(c)).ToArray();
            return BuildString(minLength, chars);
        }

        /// <summary>
        /// Generates padding by filling the password with alpha numeric characters to ensure password length meets requirements
        /// </summary>
        /// <param name="minLength">Min length of password</param>
        /// <param name="maxLength">Max length of password</param>
        /// <param name="currentLength">Current length of the password string</param>
        /// <returns>Current password string padded with alphanumeric characters</returns>
        private string GeneratePadding(int minLength, int maxLength, int currentLength)
        {
            minLength = Random.Next(minLength - currentLength, maxLength - currentLength);
            var chars = Chars.Where(c => char.IsUpper(c) || char.IsLower(c) || char.IsNumber(c)).ToArray();
            return BuildString(minLength, chars);
        }

        /// <summary>
        /// Returns a string of minLength generated from the given character array  
        /// </summary>
        /// <param name="minLength">The minimum length of the string</param>
        /// <param name="chars">The character array used to generate the string</param>
        /// <returns>A random string of minLength from the given char array</returns>
        private static string BuildString(int minLength, char[] chars)
        {
            return string.Concat(Enumerable.Repeat(chars, minLength).Select(c => c[Random.Next(c.Length)]));
        }
    }
}
