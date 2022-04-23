using TestGoalSystems.Application.Models.Identity;

namespace TestGoalSystems.Application.Contrats.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
