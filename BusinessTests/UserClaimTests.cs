using Autofac;
using Autofac.Builder;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Jwt;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace BusinessTests
{
    public class Tests
    {
        private IUserService _userService;
        private IContainer _container;
        public Tests()
        {
           
          
            var containerBuilder = new ContainerBuilder();

            // register module to test
            containerBuilder.RegisterModule<AutofacBusinessModule>();

            // don't start startable components - 
            // we don't need them to start for the unit test
            _container = containerBuilder.Build(
                ContainerBuildOptions.IgnoreStartableComponents);
            _userService= _container.Resolve<IUserService>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var user = _userService.GetByEmail("kadir@kadir.com");
           
            Assert.Pass(_userService.GetClaims(user)[0].Name);
        }
    }
}