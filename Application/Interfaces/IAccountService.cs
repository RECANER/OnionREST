using Application.DTOs.Users;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AutenticateAsycn(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsycn(RegisterRequest request, string origin);
    }
}
