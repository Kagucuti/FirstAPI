using Microsoft.AspNetCore.Mvc;

namespace ChemistryApiTask.Services
{
    public interface ISubstanceService
    {
        Task<IEnumerable<Substance>> GetAllAsync();
        Task<Substance?> GetSingleAsync(int Id);
        Task<Substance?> AddSubstanceAsync(Substance substance);
        Task<Substance?> UpdateSubstanceAsync(int Id, Substance substance);
        Task<Substance?> DeleteSubstanceAsync(int Id);
    }
}
