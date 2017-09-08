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
            // alle routes
            // welke nodes zitten aan A?
            // welke nodes zitten aan A1 en hebben we nog niet gehad?
            // welke nodes zitten aan A2 en hebben we nog niet gehad?
            // ... ect

            // Vervolgens sorteren

            //var routes = new List<List<char>>();
            var startNode = new Node(pointStart);
            var stopNode = new Node(pointDestination);
            var passedThrough = new List<Node>()
            {
                startNode
            };

            startNode.ConnectedNodes = GetConnectedNodes(graaf, startNode, stopNode, passedThrough);


        }

        private static List<Node> GetConnectedNodes(Graaf graaf, Node nodeStart, Node nodeStop, List<Node> nodesPassedThrough)
        {
            var connectedNodes = new List<Node>();

            foreach (var route in graaf)
            {
                // Check if route has nodeStart in it
                if (route.PointA.Id == nodeStart.Id)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointB))
                    {
                        connectedNodes.Add(route.PointB);
                    }
                }
                else if (route.PointB.Id == nodeStart.Id)
                {
                    if (!IsNodeInList(nodesPassedThrough, route.PointA))
                    {
                        connectedNodes.Add(route.PointA);
                    }
                }
            }

            foreach (var item in connectedNodes)
            {
                if(item.Id != nodeStop.Id)
                {
                    var temp = new List<Node>();
                    temp.AddRange(nodesPassedThrough);
                    temp.Add(item);

                    item.ConnectedNodes = GetConnectedNodes(graaf, item, nodeStop, temp);
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

        //public static List<Route> GetRoutes(Graaf graaf, char pointA, char pointB, int connections)
        //{
        //    var list = new List<Route>();



        //    return list;
        //}

        //private static List<Route> GetRoutesConnectedToNodes(Graaf graaf, char pointA, char pointB)
        //{
        //    var list = new List<Route>();

        //    foreach (var r in graaf)
        //    {
        //        if (r.PointA == pointA || r.PointA == pointB || r.PointB == pointA || r.PointB == pointB)
        //            list.Add(r);
        //    }

        //    return list;
        //}
    }

    public class Graaf : List<Route>
    {
        //public List<Route> Routes { get; set; }
    }

    public class Route
    {
        public Node PointA { get; set; }
        public Node PointB { get; set; }
        public int Distance { get; set; }
        public Direction Direction { get; set; }

        public Route(char pointA, char pointB, int distance)
        {
            PointA = new Node(pointA);
            PointB = new Node(pointB);
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
        //public override bool Equals(object obj)
        //{
        //    if (((Node)obj).Id == Id)
        //        return true;
        //    return false;
        //}
        public override string ToString()
        {
            return $"[{Id}]";
        }
    }

    public enum Direction
    {
        Both,
        AToB,
        BToA
    }
}
