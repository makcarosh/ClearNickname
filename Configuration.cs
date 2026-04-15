using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClearNick
{
    public class Configuration : IRocketPluginConfiguration
    {

        public List<string> tags;
        public void LoadDefaults()
        {
            tags = new List<string>
            {
                "roez",
                "cobra",
                "redline",
                "recate",
                "whyme",
                "militaryserv",
                "pandahut"
            };
        }
    }
}
