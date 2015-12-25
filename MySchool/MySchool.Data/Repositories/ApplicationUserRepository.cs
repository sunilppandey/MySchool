using MySchool.Data.Entities;
using MySchool.Model.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MySchool.Data.Repositories
{
    public class ApplicationUserRepository : IDisposable
    {
        //private ApplicationDbContext context;
        private ApplicationUserManager userManager;

        public ApplicationUserRepository()
        {
            //context = DataContextFactory.GetDataContext();
            userManager = new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()));
        }

        public List<ApplicationUser> GetUsers()
        {
            return userManager.Users.ToList();
        }

        public Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            var result = userManager.CreateAsync(user, password);

            return result;
        }

        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            var user = await userManager.FindAsync(userName, password);

            return user;
        }

        public Client FindClient(string clientId)
        {
            return DataContextFactory.GetDataContext().Set<Client>().Find(clientId);
        }

        #region Refresh token

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = DataContextFactory.GetDataContext().Set<RefreshToken>().Where(x => x.Subject == token.Subject && x.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            DataContextFactory.GetDataContext().Set<RefreshToken>().Add(token);

            return await DataContextFactory.GetDataContext().SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await DataContextFactory.GetDataContext().Set<RefreshToken>().FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                DataContextFactory.GetDataContext().Set<RefreshToken>().Remove(refreshToken);
                return await DataContextFactory.GetDataContext().SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            DataContextFactory.GetDataContext().Set<RefreshToken>().Remove(refreshToken);
            return await DataContextFactory.GetDataContext().SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await DataContextFactory.GetDataContext().Set<RefreshToken>().FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return DataContextFactory.GetDataContext().Set<RefreshToken>().ToList();
        }

        #endregion

        public void Dispose()
        {
            if (DataContextFactory.GetDataContext() != null)
            {
                DataContextFactory.GetDataContext().Dispose();
            }
        }
    }
}
