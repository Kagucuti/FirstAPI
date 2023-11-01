using ChemistryApiTask.Controllers;
using ChemistryApiTask.Data;
using ChemistryApiTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ChemistryApiTask.Services
{
    public class SubstanceService : ISubstanceService
    {
        private readonly DataContext _dbContext;
        public SubstanceService(DataContext dbContext)
        {
            _dbContext = dbContext;

        }
        public static List<Substance> substances = new List<Substance>()
        {
            new Substance(1,"HCl",SubstanceType.Acid),
            new Substance(2,"C2O",SubstanceType.Oxyde),
            new Substance(3, "C2H5OH", SubstanceType.Alcohol)
        };

        public async Task<Substance?> AddSubstanceAsync(Substance substance)
        {
            //substance.Id = substances.Count + 1;
            _dbContext.Substances.Add(substance);
            await _dbContext.SaveChangesAsync();
            substances.Add(substance);
            return substance;
        }

        public async Task<IEnumerable<Substance>> GetAllAsync()
        {
            var _substances = await _dbContext.Substances.ToListAsync();
            return _substances;
        }

        public async Task<Substance?> GetSingleAsync(int Id)
        {
            var _substance = await _dbContext.Substances.FindAsync(Id);
            return _substance;
        }

        public async Task<Substance?> UpdateSubstanceAsync(int Id, Substance substance)
        {
            var _substance = await _dbContext.Substances.FindAsync(Id);
            if (_substance is not null)
            {
                _substance.Name = substance.Name;
                _substance.Type = substance.Type;
                await _dbContext.SaveChangesAsync();
                return _substance;
            }
            else
            {
                return null;
            }
        }

        public async Task<Substance?> DeleteSubstanceAsync(int Id) 
        {
            var _substance = await _dbContext.Substances.FindAsync(Id);
            if (_substance is null)
                return null;
            _dbContext.Substances.Remove(_substance);
            await _dbContext.SaveChangesAsync();
            return _substance;
        }
    }
}
