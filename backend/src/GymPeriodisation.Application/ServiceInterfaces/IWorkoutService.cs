using GymPeriodisation.Application.DTOs.Users;
using GymPeriodisation.Application.DTOs.Workouts;
using GymPeriodisation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymPeriodisation.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto userDto);
        Task<List<User>> GetUsers();
    }
}
