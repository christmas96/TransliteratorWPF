
namespace Transliteration.Tools
{
    internal interface IHaveSignInPass
    {
        System.Security.SecureString SignInPassword { get; }
    }
}
