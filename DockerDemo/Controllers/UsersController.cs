using DockerDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Hosting;

namespace DockerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ODataController
    {
        private readonly SampleDbContext _context;
        private static readonly string[] Summaries = new[]
        {
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, SampleDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet(Name = "GET"), Route("GetUsersV2")]
        [EnableQuery]
        public IEnumerable<UserViewModel> GetV2(int id)
        {
            return _context.Users.Select(x => new UserViewModel
            {
                Age = x.Age,
                FullName = x.Name + " " + x.FatherName,
                MotherName = x.MotherName
            }).ToList();
        }
        [HttpGet(Name = "GET"), Route("GetUsersV1")]
        [EnableQuery]
        public PageResult<User> Get(ODataQueryOptions<User> opts)
        
        {

            //var data = opts.ApplyTo(_context.Users) as IQueryable<User>;
            //return data;


            #region page result doesn't return count when top and skip are sent through query string and selecting single coulmn will not work
            var result = opts.ApplyTo(_context.Users) as IQueryable<User>;
            var pageResult = new PageResult<User>(
            result,
            null,
            count: result?.Count());
            return pageResult;
            #endregion

            #region not woking with select query string
            //ODataQuerySettings settings = new ODataQuerySettings();
            //var posts = _context.Users;
            //var results = opts.ApplyTo(posts, settings);
            //var result = new PageResult<User>(results as IEnumerable<User>, null, 0);
            //return result;
            #endregion

            #region querable results
            //IQueryable<User> querableUsers = _context.Users;
            //var queryResult = (IQueryable<User>)opts.ApplyTo(querableUsers);
            //var queryResult = opts.ApplyTo(querableUsers);
            //var totalCount = (queryResult as IQueryable<User>).Count();
            //var pageResult = new PageResult<User>(querableUsers, null, totalCount);
            //return pageResult;
            #endregion

            //if (opts.Skip != null && opts.Skip != null)
            //    querableUsers = queryResult.Skip(opts.Skip.Value).Take(opts.Top.Value);
            //var pageResult = new PageResult<User>(querableUsers, null, totalCount);
            //return pageResult;

            //return new PageResult<User>(_context.Users,null,);
        }
    }
}