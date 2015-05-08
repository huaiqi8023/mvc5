using Devin.DataAccess;
using Devin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.Models;
using Devin.DataAccess.BaseDataAccess;
using Devin.IBLL;

namespace Devin.BLL
{
    public class UserService : BaseService.BaseService<UserInfoSet>,IUserService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为User仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = RepositoryFactory.UserRepository;
        }
        //private readonly IUserRepository _userRepository = RepositoryFactory.UserRepository;

        //public ty_pmi_user AddUserInfo(ty_pmi_user userInfo)
        //{
        //    return _userRepository.AddEntity(userInfo);
        //}
    }
}
