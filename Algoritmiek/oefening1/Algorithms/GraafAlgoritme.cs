using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class GraafAlgoritme
    {
        public static Graaf graaf1 = new Graaf()
        {
            new Link('A', 'B', 5),
            new Link('A', 'D', 6),
            new Link('D', 'E', 5),
            new Link('D', 'F', 8),
            new Link('F', 'C', 12),
            new Link('B', 'E', 7),
            new Link('B', 'C', 2),
            new Link('E', 'C', 3)
        };

        public static Graaf graaf1WithDirections = new Graaf()
        {
            new Link('A', 'B', 5, Direction.AToB),
            new Link('A', 'D', 6),
            new Link('D', 'E', 5),
            new Link('D', 'F', 8),
            new Link('F', 'C', 12),
            new Link('B', 'E', 7, Direction.BToA),
            new Link('B', 'C', 2),
            new Link('E', 'C', 3)
        };

        public static Graaf graaf2 = new Graaf()
        {
            #region outer ring
            new Link('A', 'E', 4),
            new Link('E', 'L', 3),
            new Link('L', 'T', 18),
            new Link('T', 'O', 3),
            new Link('O', 'N', 5),
            new Link('N', 'K', 2),
            new Link('K', 'H', 3),
            new Link('H', 'D', 2),
            new Link('D', 'S', 11),
            new Link('S', 'A', 1),
            #endregion
            #region outer nodes to inner nodes
            new Link('A', 'B', 2),
            new Link('A', 'F', 5),

            new Link('E', 'F', 2),
            new Link('E', 'I', 1),

            new Link('L', 'I', 1),
            new Link('L', 'J', 2),
            new Link('L', 'M', 10),

            new Link('T', 'M', 7),

            new Link('O', 'M', 3),

            new Link('N', 'M', 1),
            new Link('N', 'J', 10),

            new Link('K', 'J', 7),
            new Link('K', 'G', 9),

            new Link('H', 'G', 6),
            new Link('H', 'C', 3),

            new Link('D', 'C', 2),

            new Link('S', 'C', 13),
            new Link('S', 'B', 2),
            #endregion

            new Link('F', 'I', 3),
            new Link('I', 'J', 1),
            new Link('J', 'G', 3),
            new Link('G', 'C', 1),
            new Link('C', 'B', 9),
            new Link('B', 'F', 3),

            new Link('J', 'M', 9),
            new Link('I', 'G', 2),
            new Link('F', 'G', 1),
            new Link('B', 'G', 5)

        };


        public static List<Route> GetPossibleRoutes(Graaf graaf, char pointStart, char pointDestination)
        {
            // alle routes
            // welke nodes zitten aan A?
            // welke nodes zitten aan A1 en hebben we nog niet gehad?
            // welke nodes zitten aan A2 en hebben we nog niet gehad?
            // ... ect

            var startNode = new Node(pointStart);
            var stopNode = new Node(pointDestination);
            var passedThrough = new List<Node>()
            {
                startNode
            };

            startNode.ConnectedNodes = GetConnectedNodes(graaf, startNode, stopNode, passedThrough);

            //var paths = GetConnectedNodesPathsAsString(startNode);
            //Console.WriteLine("Possible Paths:");
            //foreach (var path in paths)
            //{
            //    Console.WriteLine(path);
            //}

            var routes = GetConnectedNodeRoutes(startNode, graaf);

            var routesWithEnding = new List<Route>();
            foreach (var route in routes)
            {
                var lastLink = route.Links[route.Links.Count - 1];
                if (lastLink.PointA.Id == pointDestination || lastLink.PointB.Id == pointDestination)
                    routesWithEnding.Add(route);
            }

            return routesWithEnding;
        }

        public static Route GetShortestRoute(List<Route> routes)
        {
            //BubleSortRoutes(routes);
            Route shortest = null;
            foreach (var route in routes)
            {
                if (shortest == null)
                {
                    shortest = route;
                }
                else
                {
                    if (route.Distance < shortest.Distance)
                    {
                        shortest = route;
                    }
                }
            }
            return shortest;
        }

        public static List<Route> Get10ShortestRoutes(List<Route> routes)
        {
            BubleSortRoutes(routes);

            var temp = new List<Route>();
            for (int i = 0; i < (routes.Count >= 10 ? 10 : routes.Count); i++)
            {
                temp.Add(routes[i]);
            }

            return temp;
        }

        private static List<string> GetConnectedNodesPathsAsString(Node node)
        {
            var list = new List<string>();
            var curNode = node.Id.ToString();
            if (node.ConnectedNodes != null && node.ConnectedNodes.Count > 0)   // If the GetConnectedNodes algorithm reaches the specified endNode, connected nodes will be null. If it finds a node without connection, path to nowhere, it's not null
            {
                foreach (var conNode in node.ConnectedNodes)
                {
                    var childPaths = GetConnectedNodesPathsAsString(conNode);
                    foreach (var childPath in childPaths)
                    {
                        list.Add(curNode + " " + childPath);
                    }
                }
            }
            else
            {
                list.Add(curNode);
            }
            return list;
        }

        private static List<Route> GetConnectedNodeRoutes(Node node, Graaf graaf)
        {
            var list = new List<Route>();

            if (node.ConnectedNodes != null && node.ConnectedNodes.Count > 0)
            {
                foreach (var conNode in node.ConnectedNodes)
                {
                    // We have a link --> add it to the route
                    // Check if this node has more links
                    var curLink = graaf.GetLink(node.Id, conNode.Id);
                    //var temp = new Route();
                    //temp.AddLink(curLink);

                    var subRoutes = GetConnectedNodeRoutes(conNode, graaf);
                    if (subRoutes.Count > 0)
                    {
                        foreach (var subRoute in subRoutes)
                        {
                            var temp = new Route();
                            temp.AddLink(curLink);
                            foreach (var link in subRoute.Links)
                            {
                                temp.AddLink(link);
                            }
                            list.Add(temp);
                        }
                    }
                    else
                    {
                        // No more subroutes, only add the current link
                        var temp = new Route();                             // Should perhaps use a List<Link> in stead of Route to save memory
                        temp.AddLink(curLink);
                        list.Add(temp);
                    }
                }
            }
            else
            {
                // If there are no more connected nodes, there're no new links
            }

            return list;
        }

        private static List<Node> GetConnectedNodes(Graaf graaf, Node nodeStart, Node nodeStop, List<Node> nodesPassedThrough)
        {
            var connectedNodes = new List<Node>();

            foreach (var route in graaf)
            {
                // Check if route has nodeStart in it
                if (route.PointA.Id == nodeStart.Id && route.Direction != Direction.BToA)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointB))
                    {
                        connectedNodes.Add(new Node(route.PointB.Id));  // Was a reference problem --> connectedNodes.Add(route.PointB); --> Takes point from graaf, does it again later and changes it what causes the bug
                    }
                }
                else if (route.PointB.Id == nodeStart.Id && route.Direction != Direction.AToB)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointA))
                    {
                        connectedNodes.Add(new Node(route.PointA.Id));
                    }
                }
            }

            foreach (var node in connectedNodes)
            {
                if (node.Id != nodeStop.Id)
                {
                    var curNodesPassedThrough = new List<Node>();
                    curNodesPassedThrough.AddRange(nodesPassedThrough);
                    curNodesPassedThrough.Add(node);

                    node.IgnoredNodes = curNodesPassedThrough;
                    node.ConnectedNodes = GetConnectedNodes(graaf, node, nodeStop, curNodesPassedThrough);
                }
            }

            return connectedNodes;
        }

        private static bool IsNodeInList(List<Node> nodes, Node node)
        {
            foreach (var n in nodes)
            {
                if (n.Id == node.Id) return true;
            }
            return false;
        }

        public static void BubleSortRoutes(List<Route> routes)
        {
            var swapped = true;
            int iteration = 0;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < (routes.Count - iteration); i++)
                {
                    if (routes[i].Distance < routes[i - 1].Distance)
                    {
                        var temp = routes[i];
                        routes[i] = routes[i - 1];
                        routes[i - 1] = temp;
                        swapped = true;
                    }
                }
                iteration++;
            }
        }
    }

    public class Graaf : List<Link>
    {
        public Link GetLink(char pointFrom, char pointTo)
        {
            foreach (var link in this)
            {
                if (((link.PointA.Id == pointFrom && link.PointB.Id == pointTo && link.Direction != Direction.BToA) || (link.PointA.Id == pointTo && link.PointB.Id == pointFrom && link.Direction != Direction.AToB)))
                {
                    return link;
                }
            }
            return null;
        }
    }

    public class Route
    {
        public List<Link> Links { get; }
        public int Distance { get; private set; }

        public Route()
        {
            Links = new List<Link>();
            Distance = 0;
        }
        public void AddLink(Link link)
        {
            Links.Add(link);
            Distance += link.Distance;
        }

        public override string ToString()
        {
            string str = $"[{Distance}]".PadRight(5, ' ');
            foreach (var link in Links)
            {
                str += link.ToString() + " ";
            }
            return str;
        }

        public string ToShortString()
        {
            string str = $"({Distance})".PadRight(5, ' ');

            if (Links.Count == 1)
            {
                str += $"{Links[0].PointA.Id} {Links[0].PointB.Id}";
            }
            else
            {
                for (int i = 0; i < (Links.Count - 1); i++)
                {
                    var curLink = Links[i];
                    var nexLink = Links[i + 1];

                    if (curLink.PointA.Id == nexLink.PointA.Id || curLink.PointA.Id == nexLink.PointB.Id)
                    {
                        if (i == 0)
                            str += curLink.PointB.Id + " ";

                        str += curLink.PointA.Id + " ";

                        if (i == Links.Count - 2)
                            str += curLink.PointA.Id == nexLink.PointA.Id ? nexLink.PointB.Id : nexLink.PointA.Id;
                    }
                    else if (curLink.PointB.Id == nexLink.PointA.Id || curLink.PointB.Id == nexLink.PointB.Id)
                    {
                        if (i == 0)
                            str += curLink.PointA.Id + " ";

                        str += curLink.PointB.Id + " ";

                        if (i == Links.Count - 2)
                            str += curLink.PointB.Id == nexLink.PointA.Id ? nexLink.PointB.Id : nexLink.PointA.Id;
                    }
                }
            }


            return str;
        }
    }

    public class Link
    {
        public Node PointA { get; set; }
        public Node PointB { get; set; }
        public int Distance { get; set; }
        public Direction Direction { get; set; }

        public Link(char pointA, char pointB, int distance)
        {
            PointA = new Node(pointA);
            PointB = new Node(pointB);
            Distance = distance;
            Direction = Direction.Both;
        }

        public Link(char pointA, char pointB, int distance, Direction direction) 
            : this(pointA, pointB, distance)
        {
            Direction = direction;
        }

        public override string ToString()
        {
            var leftDirection = (Direction == Direction.Both || Direction == Direction.BToA) ? "<" : "-";
            var rightDirection = (Direction == Direction.Both || Direction == Direction.AToB) ? ">" : "-";
            return $"{PointA}-{leftDirection}{Distance.ToString().PadLeft(3, '_')}{rightDirection}-{PointB}";
        }
    }

    public class Node
    {
        public char Id { get; set; }
        public List<Node> ConnectedNodes { get; set; }
        public List<Node> IgnoredNodes { get; set; }

        public Node(char id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"({Id})";
        }
    }

    public enum Direction
    {
        Both,
        AToB,
        BToA
    }
}
