using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api_Movie.Controllers
{
    /// <summary>
    [Authorize(AuthenticationSchemes = "access_auth")]
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly ILogger<AuthController> _logger;

        public MoviesController(IUnitOfWorks unitOfWork, ILogger<AuthController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MoviesList()
        {
            var response = await _unitOfWork.movie.GetListMovie();
            if (response.Item1)
            {
                ApiResponse<List<Movie>> resultValue = response.Item3;
                return Ok(resultValue);
            }
            else
            {
                Result result = response.Item2;
                return Ok(result);
            }
        }

        [HttpGet]
        [Route(":{id}")]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var validation = await _unitOfWork.validators.ValidationByID(id);
            if (validation.Item1)
            {

                var response = await _unitOfWork.movie.GetListMovie();
                if (response.Item1)
                {
                    ApiResponse<List<Movie>> resultValue = response.Item3;
                    return Ok(resultValue);
                }
                else
                {
                    Result result = response.Item2;
                    return Ok(result);
                }
            }
            else
            {
                Result result = validation.Item2;
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovie([FromBody] InsertMovie Data)
        {
            var validation = await _unitOfWork.validators.ValidationInsert(Data);
            if (validation.Item1)
            {

                var response = await _unitOfWork.movie.InsertMovie(Data);
                if (response.Item1)
                {
                    ApiResponse<Movie> resultValue = response.Item3;
                    return Ok(resultValue);
                }
                else
                {
                    Result result = response.Item2;
                    return Ok(result);
                }
            }
            else
            {
                Result result = validation.Item2;
                return Ok(result);
            }
        }
        [HttpPatch(":{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] JsonPatchDocument Data)
        {
            var validation = await _unitOfWork.validators.ValidationByID(id);
            if (validation.Item1)
            {

                var response = await _unitOfWork.movie.UpdateMovie(id, Data);
                if (response.Item1)
                {
                    ApiResponse<Movie> resultValue = response.Item3;
                    return Ok(resultValue);
                }
                else
                {
                    Result result = response.Item2;
                    return Ok(result);
                }
            }
            else
            {
                Result result = validation.Item2;
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route(":{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var validation = await _unitOfWork.validators.ValidationByID(id);
            if (validation.Item1)
            {
                var response = await _unitOfWork.movie.DeleteMovie(id);
                Result result = response.Item2;
                return Ok(result);
            }
            else
            {
                Result result = validation.Item2;
                return Ok(result);
            }
        }
    }
}