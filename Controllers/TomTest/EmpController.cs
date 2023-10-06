using Microsoft.AspNetCore.Mvc;

using TEWebApi101.Models.TomTest;

namespace TEWebApi101.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpController : ControllerBase
    {
        private readonly ILogger<EmpController> _logger;

        public EmpController(ILogger<EmpController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmps")]
        public IEnumerable<Emp> GetEmps()
        {
            var retVal = Enumerable.Range(1, 5).Select(index => new Emp {
                Id = index,
                LName = "LName" + index.ToString(),
                FName = "FName" + index.ToString(),
                DeptId = 1,
                Salary = Random.Shared.Next(50000, 200000),
                Months = Random.Shared.Next(1, 12) })
            .ToArray();
            return retVal;
        }

        [HttpGet(Name = "GetEmp")]
        public Emp GetEmp(int id)
        {
            var retVal = new Emp {
                Id = id,
                LName = "LName" + id.ToString(),
                FName = "FName" + id.ToString(),
                DeptId = 1,
                Salary = Random.Shared.Next(50000, 200000),
                Months = Random.Shared.Next(1, 12) };
            return retVal;
        }
    }
}