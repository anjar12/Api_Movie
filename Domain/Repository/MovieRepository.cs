using Domain.Interfaces;
using Domain.Model;
using Domain.Repository.DB;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class MovieRepository : IMovieReposiory
    {
        private readonly MovieDB _context;

        public MovieRepository(MovieDB context)
        {
            _context = context;
        }


        /// <summary> 
        /// 2001001 -> GetListMovie
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Tuple<bool, Result, ApiResponse<List<Movie>>>> GetListMovie()
        {
            Result result = new();
            ApiResponse<List<Movie>> resultValue = new ApiResponse<List<Movie>>();
            try
            {
                var temp = (from a in _context.Movie
                            select a).ToList() ?? new List<Movie>();
                if (temp.Count > 0)
                {
                    resultValue.Succeeded = true;
                    resultValue.Message = "";
                    resultValue.Value = temp;

                    result = new ResultError().result(0, false, "");
                    return new Tuple<bool, Result, ApiResponse<List<Movie>>>(true, result, resultValue);

                }
                else
                {
                    resultValue.Succeeded = false;
                    resultValue.Message = "Data tidak ditemukan";
                    resultValue.Value = null;

                    result = new ResultError().result(2001001, true, "Data tidak ditemukan");
                    return new Tuple<bool, Result, ApiResponse<List<Movie>>>(false, result, resultValue);

                }
            }
            catch (Exception e)
            {
                resultValue.Succeeded = false;
                resultValue.Message = e.Message;
                resultValue.Value = null;

                result = new ResultError().result(2001001, true, e.Message);
                return new Tuple<bool, Result, ApiResponse<List<Movie>>>(false, result, resultValue);

            }
        }

        /// <summary> 
        /// 2001002 -> GetMovieDetail
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Tuple<bool, Result, ApiResponse<Movie>>> GetMovieDetail(int Data)
        {
            Result result = new();
            ApiResponse<Movie> resultValue = new ApiResponse<Movie>();
            try
            {
                var temp = (from a in _context.Movie
                            where a.ID == Data
                            select a).FirstOrDefault() ?? new Movie();
                if (temp.ID > 0)
                {
                    resultValue.Succeeded = true;
                    resultValue.Message = "";
                    resultValue.Value = temp;

                    result = new ResultError().result(0, false, "");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(true, result, resultValue);
                }
                else
                {
                    resultValue.Succeeded = false;
                    resultValue.Message = "Data tidak ditemukan";
                    resultValue.Value = null;

                    result = new ResultError().result(2001002, true, "Data tidak ditemukan");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);
                }
            }
            catch (Exception e)
            {
                resultValue.Succeeded = false;
                resultValue.Message = e.Message;
                resultValue.Value = null;

                result = new ResultError().result(2001002, true, e.Message);
                return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);

            }
        }

        /// <summary> 
        /// 2001003 -> InsertMovie
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Tuple<bool, Result, ApiResponse<Movie>>> InsertMovie(InsertMovie Data)
        {
            Result result = new();
            ApiResponse<Movie> resultValue = new ApiResponse<Movie>();
            if (Data != null)
            {
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    Movie movie = new Movie()
                    {
                        Title = Data.Title,
                        Created_at = Data.Created_at.ToUniversalTime(),
                        Updated_at = Data.Updated_at.ToUniversalTime(),
                        Description = Data.Description,
                        Image = Data.Image,
                        Rating = Data.Rating,
                    };

                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    if (movie.ID > 0)
                    {
                        await transaction.CommitAsync();
                        resultValue.Succeeded = true;
                        resultValue.Message = "Insert Success";
                        resultValue.Value = null;


                        resultValue.Value = movie;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                    }
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                }
                finally 
                { 
                    transaction.Dispose(); 
                }

                if (resultValue.Value.ID > 0)
                {

                    result = new ResultError().result(0, false, "Insert Success");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(true, result, resultValue);
                }
                else
                {
                    result = new ResultError().result(2001003, true, "Insert Fail");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);
                }
            }
            else
            {
                result = new ResultError().result(2001003, true, "Bad Request");
                return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);
            }

        }

        /// <summary> 
        /// 2001004 -> UpdateMovie
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Tuple<bool, Result, ApiResponse<Movie>>> UpdateMovie(int ID,JsonPatchDocument Data)
        {
            ApiResponse<Movie> resultValue = new ApiResponse<Movie>();
            Result result = new();
            try 
            {
                Movie CekData = (from a in _context.Movie
                               where a.ID==ID
                               select a).FirstOrDefault() ?? new Movie();
                if (CekData.ID > 0)
                {

                    Data.ApplyTo(CekData);
                    await _context.SaveChangesAsync();

                   

                    resultValue.Succeeded = true;
                    resultValue.Message = "Update Success";
                    resultValue.Value = CekData;

                    result = new ResultError().result(0, false, "Update Success");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(true, result, resultValue);

                }
                else 
                {
                    result = new ResultError().result(2001004, true, "Data tidak ditemukan");
                    return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);
                }
            }
            catch (Exception e) 
            {
                result = new ResultError().result(2001004, true, e.Message);
                return new Tuple<bool, Result, ApiResponse<Movie>>(false, result, resultValue);
            }
        }

        /// <summary> 
        /// 2001005 -> UpdateMovie
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Tuple<bool, Result>> DeleteMovie(int ID)
        {
            Result result = new();
            try
            {
                Movie CekData = (from a in _context.Movie
                                 where a.ID == ID
                                 select a).FirstOrDefault() ?? new Movie();
                if (CekData.ID > 0)
                {
                    _context.Remove(CekData);
                    await _context.SaveChangesAsync();

                    result = new ResultError().result(0, false, "Delete Success");
                    return new Tuple<bool, Result>(true, result);

                }
                else
                {
                    result = new ResultError().result(2001005, true, "Data tidak ditemukan");
                    return new Tuple<bool, Result>(false, result);
                }
            }
            catch (Exception e)
            {
                result = new ResultError().result(2001005, true, e.Message);
                return new Tuple<bool, Result>(false, result );
            }
        }

    }
}
