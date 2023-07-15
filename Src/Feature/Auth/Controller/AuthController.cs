using System;
using System.Threading.Tasks;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Cmd.Domain.UseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Src.Feature.Auth.Controller
{

    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly RegisterUseCase _registerUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;


        public AuthController(LoginUseCase loginUseCase, RegisterUseCase registerUseCase, RefreshTokenUseCase refreshTokenUseCase)
        {
            _loginUseCase = loginUseCase;
            _registerUseCase = registerUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
        }



        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] User request)
        {
            var useCaseResults = await _registerUseCase.execute(request);
            try
            {
                return useCaseResults.Match(
                     leftFunc: (error) => throw new Exception(),
                     rightFunc: (data) => NoContent()
                 );

            }
            catch (System.Exception e)
            {

                return Problem(e.StackTrace);
            }
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] Credentials credentials)
        {
            var useCaseResults = await _loginUseCase.execute(credentials);
            try
            {
                return useCaseResults.Match(
                     leftFunc: (error) => throw new Exception("Unauthorized"),
                     rightFunc: (data) => Ok(data)
                 );

            }
            catch (System.Exception e)
            {

                return Unauthorized(new { message = e.Message });
            }
        }

        [HttpPost("tokens/{token}/refresh")]
        public async Task<IActionResult> RefreshAccessToken(string token)
        {
            var useCaseResults = await _refreshTokenUseCase.execute(token);
            try
            {
                return useCaseResults.Match(
                     leftFunc: (error) => throw new Exception("Unauthorized"),
                     rightFunc: (data) => Ok(data)
                 );

            }
            catch (System.Exception e)
            {

                return Unauthorized(new { message = e.Message });
            }
        }
    }
}