using Domain.Interfaces;
using Domain.Repository.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly MovieDB _context;
        public IAuthRepository auth { get; private set; }
        public IValidators validators { get; private set; }
        public IMovieReposiory movie { get; private set; }
        public UnitOfWorks(
            MovieDB context,
            IAuthRepository AuthRepository,
            IMovieReposiory MovieReposiory,
            IValidators ValidatorRepository
            )
        {
            _context = context;
            auth = AuthRepository;
            movie = MovieReposiory;
            validators = ValidatorRepository;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
