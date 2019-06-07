using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMHelper
{
    class LocationGraph
    {
        public List<Location> AllLocations = new List<Location>();
        public int?[,] adjacency;
        public Location CreateLocation(string name)
        {
            var location = new Location(name);
            AllLocations.Add(location);
            return location;
        }

        public int?[,] CreateAdjMatrix()
        {
            int?[,] adj = new int?[AllLocations.Count, AllLocations.Count];

            for(int i = 0; i < AllLocations.Count; i++)
            {
                Location loc1 = AllLocations[i];

                for(int j = 0; j < AllLocations.Count; j++)
                {
                    Location loc2 = AllLocations[j];
                    var path = loc1.paths.FirstOrDefault(a => a.Child == loc2);

                    if(path != null)
                    {
                        adj[i, j] = path.weight;
                    }
                }
            }
            return adj;
        }
        public void Dijkstra(string start, string end)
        {

        }
    }
    public class Location
    {
        public string Name;
        public List<Path> paths = new List<Path>();

        public Location(string name)
        {
            Name = name;
        }

        public Location AddPath(Location child, int w)
        {
            paths.Add(new Path
            {
                Parent = this,
                Child = child,
                weight = w
            });

            if(!child.paths.Exists(a => a.Parent == child && a.Child == this))
            {
                child.AddPath(this, w);
            }

            return this;
        }
    }
    public class Path
    {
        public int weight;
        public Location Parent;
        public Location Child;
    }
}
