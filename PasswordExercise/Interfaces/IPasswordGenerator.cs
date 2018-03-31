using PasswordExercise.Models;

namespace PasswordExercise.Interfaces
{
    /// <summary>
    /// Password Generator Interface
    /// </summary>
    public interface IPasswordGeneratorService
    {
        string GeneratePassword(PasswordRequirements requirements);
    }
}
