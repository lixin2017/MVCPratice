using Luna.Models;
using Luna.DAL;
using Luna.IBLL;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;


namespace Luna.BLL
{
    /// <summary>
    /// 用户服务
    /// <remarks>
    /// 创建时间：2017/9/5  参考：http://www.cnblogs.com/mzwhj/p/3547394.html
    /// </remarks>
    /// </summary>
    public class UserService:BaseService<User>,InterfaceUserService
    {
        public UserService() : base(RepositoryFactory.UserRepository) { }

        public bool Exist(string userName)
        {
            return CurrentRepository.Exist(u => u.UserName == userName);
        }

        public User Find(int userID) { return CurrentRepository.Find(u => u.UserID == userID); }

        public User Find(string userName) { return CurrentRepository.Find(u => u.UserName == userName); }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            switch (order)
            {
                case 0: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
                case 1: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.UserID);
                case 2: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.RegistrationTime);
                case 3: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.RegistrationTime);
                case 4: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.LoginTime);
                case 5: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, false, u => u.LoginTime);
                default: return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, true, u => u.UserID);
            }

        }


        public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
            return _identity;
        }

    }
}
