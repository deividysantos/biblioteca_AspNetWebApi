using biblioteca_AspNetWebApi.Models;

using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;
using System;
using System.Threading.Tasks;

namespace biblioteca_AspNetWebApi.Services
{
    public class ClerkService
    {
        private readonly IClerkRepository _clerkRepository;

        public ClerkService(IClerkRepository clerkRepository)
        {
            _clerkRepository = clerkRepository;
        }

        public async Task<bool> AddAsync(Clerk clerk)
        {
            if(await _clerkRepository.CreateAsync(clerk)) return true;

            return false;
        }

        public async Task<bool> UpdateAsync(Clerk clerk, Guid id)
        {
            if(await _clerkRepository.UpdateAsync(clerk, id)) return true;

            return false;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if(await _clerkRepository.DeleteAsync(id)) return true;

            return false;
        }

        public async Task<bool> ExistingEmailAsync(string email) 
        {
            Clerk clerk = await _clerkRepository.GetByEmailAsync(email);

            if(clerk is null) return false;

            return true;
        }

        public async Task<bool> Inactivate(Guid id)
        {
            return await _clerkRepository.Inactivate(id);
        }
    }
}