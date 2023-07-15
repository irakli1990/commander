using System;
using System.Threading.Tasks;
using Commander.Src.Core.AuthCore;
using Commander.Src.Core.AuthCore.JWTModels;
using Commander.Src.Core.Errors;
using Commander.Src.Core.Utils;
using Commander.Src.Feature.Auth.Data.DataSource;
using Commander.Src.Feature.Auth.Domain.Entity;
using Commander.Src.Feature.Auth.Domain.Repository;
using Microsoft.AspNetCore.Identity;

namespace Commander.Src.Feature.Auth.Data.Repository
{
    public class AuthRepositoryImpl : IAuthRepository
    {

        private readonly IJwtHandler _jwtHandler;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthLocalDataSource _authLocalDataSource;
        private readonly IAuthTokenLocalDataSource _authTokenLocalDataSource;


        public AuthRepositoryImpl(
            IJwtHandler jwtHandler,
            IPasswordHasher<User> passwordHasher,
            IAuthLocalDataSource authLocalDataSource,
            IAuthTokenLocalDataSource authTokenLocalDataSource
            )
        {
            _jwtHandler = jwtHandler;
            _passwordHasher = passwordHasher;
            _authLocalDataSource = authLocalDataSource;
            _authTokenLocalDataSource = authTokenLocalDataSource;
        }
        public async Task<Either<Failure, JsonWebToken>> Login(Credentials credentials)
        {
            var user = await _authLocalDataSource.GetUser(credentials.UserName);
            if (user == null)
            {
                return (Either<Failure, JsonWebToken>)new DataBaseFailure();
            }
            var jwt = _jwtHandler.Create(credentials.UserName);
            var refreshToken = _passwordHasher.HashPassword(user, Guid.NewGuid().ToString())
                .Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);
            jwt.RefreshToken = refreshToken;
            await _authTokenLocalDataSource.SaveRefreshToken(new RefreshToken { Username = credentials.UserName, Token = refreshToken });

            return (Either<Failure, JsonWebToken>)jwt;
        }

        public async Task<Either<Failure, JsonWebToken>> RefreshAccessToken(string token)
        {
            var refreshToken = await _authTokenLocalDataSource.GetRefreshToken(token);
            if (refreshToken == null)
            {
                return (Either<Failure, JsonWebToken>)new AuthenticationFailure("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                return (Either<Failure, JsonWebToken>)new AuthenticationFailure("Refresh token was revoked");
            }
            var jwt = _jwtHandler.Create(refreshToken.Username); ;
            jwt.RefreshToken = refreshToken.Token;

            return (Either<Failure, JsonWebToken>)jwt;
        }

        public async Task<Either<Failure, Task>> Register(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                return (Either<Failure, Task>)new AuthenticationFailure("User name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return (Either<Failure, Task>)new AuthenticationFailure("Password cannot be empty");
            }
            var existingUser = await _authLocalDataSource.GetUser(user.UserName);
            if (existingUser != null)
            {
                return (Either<Failure, Task>)new AuthenticationFailure("There is not such user in database");
            }
            return (Either<Failure, Task>)_authLocalDataSource.SaveUser(new User { UserName = user.UserName, Password = _passwordHasher.HashPassword(user, user.Password) });
        }

        public Task<Either<Failure, Task>> RevokeRefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}