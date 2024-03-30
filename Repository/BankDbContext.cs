﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infras

namespace Repository
{
    public class BankDbContext : IdentityDbContext<User, Role, Guid>
    {
    }
}
