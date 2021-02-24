using DatabaseModel;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewsController : ControllerBase
    {
        private readonly SysMaturDbContext dbcontext = new();
    }
}