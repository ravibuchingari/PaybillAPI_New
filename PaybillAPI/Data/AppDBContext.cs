﻿using Microsoft.EntityFrameworkCore;
using PaybillAPI.DTO;

namespace PaybillAPI.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

}
