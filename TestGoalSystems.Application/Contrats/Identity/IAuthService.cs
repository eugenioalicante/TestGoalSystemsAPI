using TestGoalSystems.Application.Models.Identity;

namespace TestGoalSystems.Application.Contrats.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthResponse> Login(AuthRequest request);

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
