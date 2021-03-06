﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Infra.CrossCutting.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Cpf { get; set; }
    }
}
