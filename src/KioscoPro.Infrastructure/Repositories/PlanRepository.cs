using KioscoPro.Application.Interfaces.Repositories;
using KioscoPro.Domain.Entities;
using KioscoPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly AppDbContext _context;
        public PlanRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Plan plan)
        {
            await _context.Plans.AddAsync(plan);
        }
        public async Task<List<Plan>> GetAllPlanAsync()
        {
            var plans = await _context.Plans
                                      .AsNoTracking()
                                      .ToListAsync();
            return plans;
        }
        public async Task<Plan?> GetPlanByIdAsync(Guid id)
        {
            return await _context.Plans.AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id == id); 
        }
    }
}
