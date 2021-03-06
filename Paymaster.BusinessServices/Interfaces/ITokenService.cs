﻿using Paymaster.BusinessEntities;

namespace Paymaster.BusinessServices.Interfaces
{
    public interface ITokenService
    {
        #region Interface member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        TokenEntity GenerateToken(int userId);

        /// <summary>
        /// Function to fetch TokenEntity from database
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        TokenEntity Get(string tokenId);

        /// <summary>
        /// Function to validate token againt expiry and existance in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        bool ValidateToken(string tokenId);

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId"></param>
        bool Kill(string tokenId);

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool DeleteByUserId(int userId);

        /// <summary>
        /// Function to validate username/password and generate the session token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        TokenEntity AuthenticateUser(string username, string password);

        #endregion Interface member methods.
    }
}