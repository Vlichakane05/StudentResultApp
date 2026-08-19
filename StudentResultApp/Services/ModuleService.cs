using Microsoft.EntityFrameworkCore;
using StudentResultApp.Data;
using StudentResultApp.Models;

namespace StudentResultApp.Services
{
    public class ModuleService
    {
        private readonly StudentResultDbContext _context;

        public ModuleService(StudentResultDbContext context)
        {
            _context = context;
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.Modules
                .OrderBy(m => m.Code)
                .ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Module updatedModule)
        {
            var existingModule = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == updatedModule.Id);

            if (existingModule == null)
                return;

            existingModule.Code = updatedModule.Code;
            existingModule.Name = updatedModule.Name;
            existingModule.AcademicYear = updatedModule.AcademicYear;
            existingModule.StudentCount = updatedModule.StudentCount;
            existingModule.Status = updatedModule.Status;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var module = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);

            if (module == null)
                return;

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }
    }
}
