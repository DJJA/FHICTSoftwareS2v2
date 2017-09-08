using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class GraafAlgoritme
    {
        Graaf graaf1 = new Graaf()
        {
            new Route('A', 'B', 5),
            new Route('A', 'D', 6),
            new Route('D', 'E', 5),
            new Route('D', 'F', 8),
            new Route('F', 'C', 12),
            new Route('B', 'E', 7),
            new Route('B', 'C', 2),
            new Route('E', 'C', 3)
        };

        public static void Execute()
        {

        }

        public static void GetShortestRoute(Graaf graaf, char pointStart, char pointDestination)
        {
            Route twoNodeRoute = null;
            // pointStart and pointDestination route exists?
            foreach (var r in graaf)
            {
                if ((r.PointA == pointStart && r.PointB == pointDestination) || (r.PointA == pointDestination && r.PointB == pointStart))
                    twoNodeRoute = r;
            }

            //var routes = GetRoutesConnectedToNodes(graaf, pointStart, pointDestination);

            //var twoConnectionRoutes = new List<Route>();
            //foreach (var r in routes)
            //{

            //}

            var nodesConnectedToA = new List<char>();
            foreach (var route in graaf)
            {
                if (route.PointA == pointStart)
                    nodesConnectedToA.Add(route.PointB);
                else if (route.PointB == pointStart)
                    nodesConnectedToA.Add(route.PointA);
            }
            var nodesConnectedToB = new List<char>();
            foreach (var route in graaf)
            {
                if (route.PointA == pointDestination)
                    nodesConnectedToB.Add(route.PointB);
                else if (route.PointB == pointDestination)
                    nodesConnectedToB.Add(route.PointA);
            }


            var threeNodeRoutes = new List<Route>();
            // Welke nodes zitten aan A en F
            // Welke nodes komen overeen

            var fourNodeRoutes = new List<Route>();



            // alle routes
            // welke nodes zitten aan A?
            // welke nodes zitten aan A1 en hebben we nog niet gehad?
            // welke nodes zitten aan A2 en hebben we nog niet gehad?
            // ... ect

            // Vervolgens sorteren

            var routes = new List<List<char>>();
            var passedThrough = new List<char>();

            var conNodes = GetConnectedNodes(graaf, pointStart, passedThrough);
            //foreach (var conNode in conNodes)
            //{
            //    //var tempPassedThrough = new List<char>();
            //    //tempPassedThrough.AddRange(passedThrough);
            //    //tempPassedThrough.Add(conNode);
            //    var conNodes2 = GetConnectedNodes(graaf, conNode, )
            //}
        }

        private static List<Node> GetConnectedNodes(Graaf graaf, Node nodeStart, Node nodeStop, List<Node> nodesPassedThrough)
        {
            var connectedNodes = new List<Node>();

            foreach (var route in graaf)
            {
                // Check if route has nodeStart in it
                if (route.PointA == nodeStart.Id)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointB))
                    {
                        connectedNodes.Add(new Node(route.PointB));
                    }
                }
                else if (route.PointB == nodeStart.Id)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointA))
                    {
                        connectedNodes.Add(new Node(route.PointA));
                    }
                }
            }

            foreach (var item in connectedNodes)
            {
                var temp = new List<char>();
                temp.AddRange(nodesPassedThrough);
                temp.Add(item);

                var nodes = GetConnectedNodes(graaf, item, temp);
            }

            return connectedNodes;
        }

        private static bool IsNodeInList(List<Node> nodes, char node)
        {
            foreach (var n in nodes)
            {
                if (n.Id == node) return true;
            }
            return false;
        }

        public static List<Route> GetRoutes(Graaf graaf, char pointA, char pointB, int connections)
        {
            var list = new List<Route>();



            return list;
        }

        private static List<Route> GetRoutesConnectedToNodes(Graaf graaf, char pointA, char pointB)
        {
            var list = new List<Route>();

            foreach (var r in graaf)
            {
                if (r.PointA == pointA || r.PointA == pointB || r.PointB == pointA || r.PointB == pointB)
                    list.Add(r);
            }

            return list;
        }
    }

    public class Graaf : List<Route>
    {
        //public List<Route> Routes { get; set; }
    }

    public class Route
    {
        public char PointA { get; set; }
        public char PointB { get; set; }
        public int Distance { get; set; }
        public Direction Direction { get; set; }

        public Route(char pointA, char pointB, int distance)
        {
            PointA = pointA;
            PointB = pointB;
            Distance = distance;
            Direction = Direction.Both;
        }
    }

    public class Node
    {
        public char Id { get; set; }
        public List<Node> ConnectedNodes { get; set; }

        public Node(char id)
        {
            Id = id;
        }
    }

    public enum Direction
    {
        Both,
        AToB,
        BToA
    }
}
