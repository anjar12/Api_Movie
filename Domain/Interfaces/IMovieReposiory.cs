using Domain.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieReposiory
    {
        Task<Tuple<bool, Result, ApiResponse<List<Movie>>>> GetListMovie();
        Task<Tuple<bool, Result, ApiResponse<Movie>>> GetMovieDetail(int Data);
        Task<Tuple<bool, Result, ApiResponse<Movie>>> InsertMovie(InsertMovie Data);
        Task<Tuple<bool, Result, ApiResponse<Movie>>> UpdateMovie(int ID,JsonPatchDocument Data);
        Task<Tuple<bool, Result>> DeleteMovie(int ID);

    }
}
