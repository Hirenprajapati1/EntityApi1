using EntityApi.Models.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityApi.Services
{
    public interface IAuthenticateService
    {
        Admindata Authenticate(string userName, string password);
    }
}
