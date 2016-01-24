using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    /// <summary>
    /// Offers services for user specific operations
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string userName, string password)
        {
            var user = _userRepository.FindBy(u => u.UserName == userName && u.Password == password);
            if (user != null && user.Id > 0)
            {
                return user.Id;
            }
            return 0;
        }


        public IQueryable<User> All()
        {
            return _userRepository.All();
        }

        public User FindBy(Func<User, bool> @where)
        {
            return _userRepository.FindBy(@where);
        }

        public IQueryable<User> FilterBy(Func<User, bool> @where)
        {
            return _userRepository.FilterBy(@where);
        }

        public bool Add(User entity)
        {
            return _userRepository.Add(entity);
        }

        public bool Add(IEnumerable<User> items)
        {
            return _userRepository.Add(items);
        }

        public bool Update(User entity)
        {
            return _userRepository.Update(entity);
        }

        public bool Delete(User entity)
        {
            return _userRepository.Delete(entity);
        }

        public bool Delete(IEnumerable<User> entities)
        {
            return _userRepository.Delete(entities);
        }

        public bool Delete(Expression<Func<User, bool>> expression)
        {
            return _userRepository.Delete(expression);
        }

        public User FindBy(int id)
        {
            return _userRepository.FindBy(t=>t.Id == id);
        }
    }
}
