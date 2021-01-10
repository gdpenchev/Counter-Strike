using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
      
        public string Start(ICollection<IPlayer> players)
        {
            var terrorist = players.Where(t => t.GetType() == typeof(Terrorist));
            var counterTerrorist = players.Where(t => t.GetType() == typeof(CounterTerrorist));

            while (terrorist.Any(t => t.IsAlive) && counterTerrorist.Any(c => c.IsAlive))
            {
                foreach (var terro in terrorist)
                {
                    if (!terro.IsAlive)
                    {
                        continue;
                    }
                    foreach (var counterTeror in counterTerrorist)
                    {
                        if (!counterTeror.IsAlive)
                        {
                            continue;
                        }
                        counterTeror.TakeDamage(terro.Gun.Fire());
                    }
                }
                foreach (var counterTeror in counterTerrorist)
                {
                    if (!counterTeror.IsAlive)
                    {
                        continue;
                    }
                    foreach (var terro in terrorist)
                    {
                        if (!terro.IsAlive)
                        {
                            continue;
                        }
                        terro.TakeDamage(counterTeror.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;

            if (terrorist.Any(x=>x.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else if (counterTerrorist.Any(x=>x.IsAlive))
            {
                result = "Counter Terrorist wins!";
            }
            return result;
        }
    }
}
