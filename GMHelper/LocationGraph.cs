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
                    else if(i == j)
                    {
                        adj[i, j] = 0;
                    }
                    else
                    {
                        adj[i, j] = 100000;
                    }
                }
            }
            return adj;
        }
        public void PrintShortestDistMap()
        {
            if(adjacency != null)
            {
                FloydWarshall(adjacency);
            }
            else
            {
                Console.WriteLine("No map to print");
            }
        }
        public void FloydWarshall(int?[,] graph)
        {
            int countOfLocations = graph.GetLength(1);
            int?[,] distances = graph.Clone() as int?[,];
            int?[,] predeccesor = new int?[AllLocations.Count, AllLocations.Count];
            for (int x = 0; x < countOfLocations; x++)
            {
                for (int i = 0; i < countOfLocations; i++)
                {
                    if (x == i || distances[i, x] == 100000)
                    {
                        continue;
                    }
                    for (int j = 0; j < countOfLocations; j++)
                    {
                        if (distances[i, x] + distances[x, j] < distances[i, j])
                        {
                            distances[i, j] = distances[i, x] + distances[x, j];
                            predeccesor[i, j] = x;
                        }
                    }
                }
            }
            printDistances(distances);
            //printPredeccesors(predeccesor);      
        }

        public void printDistances(int?[,] dist)
        {
            Console.Write("       ");
            for (int i = 0; i < dist.GetLength(1); i++)
            {
                Console.Write("{0}  ", AllLocations[i].Name);
            }
            Console.WriteLine();
            for(int i = 0; i < dist.GetLength(1); i++)
            {
                Console.Write("{0} | [ ", AllLocations[i].Name);
                for (int j = 0; j < dist.GetLength(1); j++)
                {

                    if (dist[i, j] == null)
                    {
                        Console.Write(" .,");
                    }
                    else if(dist[i, j] == 100000)
                    {
                        Console.Write(" inf,");
                    }
                    else
                    {
                        Console.Write(" {0},", dist[i, j]);
                    }

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }

        public void printPredeccesors(int?[,] pred)
        {
            Console.Write("       ");
            for (int i = 0; i < pred.GetLength(1); i++)
            {
                Console.Write("{0}:{1}  ", i, AllLocations[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < pred.GetLength(1); i++)
            {
                Console.Write("{0}:{1} | [ ", i, AllLocations[i]);
                for (int j = 0; j < pred.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write(" &,");
                    }
                    else if (pred[i, j] == null)
                    {
                        Console.Write(" .,");
                    }
                    else
                    {
                        Console.Write(" {0},", pred[i, j]);
                    }

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
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
