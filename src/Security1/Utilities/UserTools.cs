using Microsoft.AspNetCore.Identity;
using Security1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security1.Utilities
{
    public class UserTools
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserTools(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string GetUserId(ClaimsPrincipal user)
        {
            return _userManager.GetUserId(user);
        }
    }
}
