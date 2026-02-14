using GymPeriodisation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymPeriodisation.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
