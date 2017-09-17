using Ninject;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Computer_Players;

namespace RockPaperScissors
{
    public static class DIContainer
    {
        public static IKernel kernel = new StandardKernel();

        static DIContainer()
        {
            string computerType = ConfigurationManager.AppSettings["compType"].ToString();

            switch (computerType)
            {
                case "Random":
                    kernel.Bind<IRPSPlayer>().To<TotallyRandom>().WithConstructorArgument("name","player2");
                    break;
                case "Biased":
                    kernel.Bind<IRPSPlayer>().To<Biased>().WithConstructorArgument("name", "player2");
                    break;
                case "AlwaysRock":
                    kernel.Bind<IRPSPlayer>().To<AlwaysRock>().WithConstructorArgument("name", "player2");
                    break;
                case "AlwaysPaper":
                    kernel.Bind<IRPSPlayer>().To<AlwaysPaper>().WithConstructorArgument("name", "player2");
                    break;
                case "AlwaysScissors":
                    kernel.Bind<IRPSPlayer>().To<AlwaysScissors>().WithConstructorArgument("name", "player2");
                    break;
            }
        }
    }
}
