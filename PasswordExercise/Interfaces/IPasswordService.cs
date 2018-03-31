using PasswordExercise.Models;

namespace PasswordExercise.Interfaces
{
    /// <summary>
    /// Password Service Interface
    /// </summary>
    public interface IPasswordService
    {
        void Menu();
        string SimplePassword();
        string ModeratePassword();
        string StrongPassword();

    }
}
