using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using MediatR;

namespace LearningCenter.API.Handler.Query.Login;

public class LoginQuery : IRequestHandler<LoginRequest,LoginResponse>
{
    private IUserDomain _userDomain;

    public LoginQuery(IUserDomain userDomain)
    {
        _userDomain = userDomain;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        User user = new User()
        {
            Username = request.Username,
            Password = request.Password
        };
        
        var result = await _userDomain.Login(user);

        return new LoginResponse()
        {
            Success = true
        };

    }
}