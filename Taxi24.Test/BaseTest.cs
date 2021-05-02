using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Test
{
    public class BaseTest
    {
        protected IServiceProvider _services;

        public virtual void SetUp()
        {
            _services = Program.CreateHostBuilder(new string[] { }).Build().Services;
        }
    }
}
