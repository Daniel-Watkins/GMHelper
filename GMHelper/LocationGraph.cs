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
        public Location CreateLocation(string name)
        {
            var location = new Location(name);
            AllLocations.Add(location);
            return location;
        }
        public void Dijkstra(string start, string end)
        {

        }
        public void addLocation()
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
