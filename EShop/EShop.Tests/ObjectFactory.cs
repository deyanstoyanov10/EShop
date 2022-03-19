namespace EShop.Tests
{
    using Common.Entities;
    using EShop.Services.Providers.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class ObjectFactory
    {
        public static Mock<UserManager<AppUser>> GetMockedUserManager()
        {
            var store = new Mock<IUserStore<AppUser>>();
            var userManager = new Mock<UserManager<AppUser>>(store.Object, null, null, null, null, null, null, null, null);
            //userManager.Object.UserValidators.Add(new UserValidator<AppUser>());
            //userManager.Object.PasswordValidators.Add(new PasswordValidator<AppUser>());

            return userManager;
        }

        public static IJwtTokenProvider GetMockedJwtTokenProvider()
        {
            var jwtTokenProvider = new Mock<IJwtTokenProvider>();
            var appUser = new AppUser();
            jwtTokenProvider.Setup(t => t.GenerateToken(appUser, null)).Returns("TestToken");

            return jwtTokenProvider.Object;
        }

        public class MockedLoginUserManager : UserManager<AppUser>
        {
            internal const string ValidLoginUsername = "ValidLoginUsername";
            internal const string ValidLoginEmail = "ValidLoginEmail@valid.com";
            internal const string ValidLoginPassword = "ValidLoginPassword";

            internal AppUser ValidLoginAppUser = new AppUser() { UserName = ValidLoginUsername, Email = ValidLoginEmail };

            public MockedLoginUserManager(
                IUserStore<AppUser> store,
                IOptions<IdentityOptions> optionsAccessor,
                IPasswordHasher<AppUser> passwordHasher,
                IEnumerable<IUserValidator<AppUser>> userValidators,
                IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
                ILookupNormalizer keyNormalizer, 
                IdentityErrorDescriber errors,
                IServiceProvider services, 
                ILogger<UserManager<AppUser>> logger) 
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
            {
            }

            public override Task<AppUser> FindByNameAsync(string userName)
            {
                if (userName == ValidLoginUsername)
                {
                    return Task.FromResult(ValidLoginAppUser);
                }
                else
                {
                    return Task.FromResult<AppUser>(null);
                }
            }

            public override Task<bool> CheckPasswordAsync(AppUser user, string password)
            {
                if (user.UserName == ValidLoginUsername && user.Email == ValidLoginEmail && password == ValidLoginPassword)
                {
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }

            public override Task<IList<string>> GetRolesAsync(AppUser user)
            {
                IList<string> roles = new List<string>();

                return Task.FromResult(roles);
            }
        }

        public class MockedRegistrationUserManager : UserManager<AppUser>
        {
            internal const string ValidRegistrationUsername = "ValidRegistrationUsername";
            internal const string ValidRegistrationPassword = "ValidRegistrationPassword";
            internal const string ValidRegistrationEmail = "ValidRegistrationEmail@valid.com";

            public MockedRegistrationUserManager(
                IUserStore<AppUser> store,
                IOptions<IdentityOptions> optionsAccessor,
                IPasswordHasher<AppUser> passwordHasher,
                IEnumerable<IUserValidator<AppUser>> userValidators,
                IEnumerable<IPasswordValidator<AppUser>> passwordValidators,
                ILookupNormalizer keyNormalizer,
                IdentityErrorDescriber errors,
                IServiceProvider services,
                ILogger<UserManager<AppUser>> logger)
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
            {
            }

            public override Task<AppUser> FindByNameAsync(string userName)
            {
                if (userName == ValidRegistrationUsername)
                {
                    return Task.FromResult<AppUser>(null);
                }
                else
                {
                    return Task.FromResult(new AppUser());
                }
            }

            public override Task<AppUser> FindByEmailAsync(string email)
            {
                if (email == ValidRegistrationEmail)
                {
                    return Task.FromResult<AppUser>(null);
                }
                else
                {
                    return Task.FromResult(new AppUser());
                }
            }

            public override Task<IdentityResult> CreateAsync(AppUser user, string password)
            {
                if (user.UserName == ValidRegistrationUsername && user.Email == ValidRegistrationEmail && password == ValidRegistrationPassword)
                {
                    return Task.FromResult(IdentityResult.Success);
                }
                else
                {
                    return Task.FromResult(IdentityResult.Failed(new IdentityError() { Code = "TestCode", Description = "TestDescription" }));
                }
            }

            public override Task<IList<string>> GetRolesAsync(AppUser user)
            {
                IList<string> roles = new List<string>();

                return Task.FromResult(roles);
            }
        }
    }
}
