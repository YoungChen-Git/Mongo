using System;
using Microsoft.Extensions.Configuration;

namespace testMangoDb.AppCode
{
    public class Website
    {
        public static readonly Website Instance = new Website();
        public IConfiguration Configuration { get; private set; }
        public void Init(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
    }
}
