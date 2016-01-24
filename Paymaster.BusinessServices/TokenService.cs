using Paymaster.BusinessEntities;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using System;
using System.Configuration;
using System.Linq;
using FluentNHibernate.Automapping;
using AutoMapper;

namespace Paymaster.BusinessServices
{
    public class TokenService : ITokenService
    {
        #region Private member variables.

        private readonly ITokenRepository _tokenRepository;
        
        #endregion Private member variables.

        #region Public constructor.

        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
            Mapper.CreateMap<Token, TokenEntity>();
            Mapper.CreateMap<TokenEntity, Token >();
        }

        #endregion Public constructor.

        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            _tokenRepository.Add(tokendomain);

            return Mapper.Map<TokenEntity>(tokendomain);
            //var tokenModel = new TokenEntity()
            //{
            //    UserId = userId,
            //    IssuedOn = issuedOn,
            //    ExpiresOn = expiredOn,
            //    AuthToken = token
            //};
            //return tokenModel;

        }
        /// <summary>
        /// Method to fetch TokenEntity from database
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public TokenEntity Get(string tokenId)
        {
            var token = _tokenRepository.FindBy(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            return token == null? null : Mapper.Map<TokenEntity>(token);
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            var token = _tokenRepository.FindBy(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _tokenRepository.Update(token);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            _tokenRepository.Delete(x => x.AuthToken == tokenId);
            //_unitOfWork.Commit();
            var isNotDeleted = _tokenRepository.FilterBy(x => x.AuthToken == tokenId).Any();
            return !isNotDeleted;

            //_unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            //_unitOfWork.Save();

            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            //if (isNotDeleted) { return false; }
            //return true;
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
            _tokenRepository.Delete(x => x.UserId == userId);
            //_unitOfWork.Commit();
            var isNotDeleted = _tokenRepository.FilterBy(x => x.UserId == userId).Any();
            return !isNotDeleted;
            //_unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            //_unitOfWork.Save();
            //var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            //return !isNotDeleted;
        }

        #endregion Public member methods.
    }
}