using System.ComponentModel.DataAnnotations;
using MediatR;

namespace LearningCenter.API.Handler.Query.Login;

public class LoginRequest : IRequest<LoginResponse>
{
    [Required]
    [MaxLength(10)]
    public  String Username { get; set; }

    [Microsoft.Build.Framework.Required]
    public  String Password { get; set; }
}