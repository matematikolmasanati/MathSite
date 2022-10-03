using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable All

namespace Business.BusinessAspects.AutoFac
{

    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// parametre olarak girilen roles değişkenini Split aracılığıyla parantezin içindeki karakterle ayırma
        /// </summary>
        /// <param name="roles"></param>
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var item in _roles)
            {
                if (roleClaims.Contains(item))
                {
                    return;
                }
            }

            throw new AuthenticationException(Messages.AuthorizationDenied);
        }
    }
}
//2 haftaya görüşmek üzere 19.03.2022 , 23.43
//e's
