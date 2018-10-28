using MRWInterface;
using MRWRepository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MRWApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IMovieRepository, MovieRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();
            container.RegisterType<IReplyRepository, ReplyRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}