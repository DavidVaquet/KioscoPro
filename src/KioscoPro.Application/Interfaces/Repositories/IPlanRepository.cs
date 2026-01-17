using KioscoPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Application.Interfaces.Repositories
{
    public interface IPlanRepository
    {

        Task<List<Plan?>> GetAllPlanAsync();
        Task<Plan?> GetPlanByIdAsync(Guid id);
        Task AddAsync(Plan plan);
    }
}
