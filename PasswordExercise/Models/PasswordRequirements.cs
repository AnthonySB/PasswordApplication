using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordExercise.Models
{
    /// <summary>
    /// Password requirements model
    /// </summary>
    public class PasswordRequirements
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public int MinUpperAlphaChars { get; set; }
        public int MinLowerAlphaChars { get; set; }
        public int MinNumericChars { get; set; }
        public int MinSpecialChars { get; set; }
    }
}
