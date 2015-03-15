using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TrainRoute
{
    List<Node> Route;

    public TrainRoute(Node StartingNode)
    {
        Route = new List<Node>(new Node[]{StartingNode});        
    }

    public void AddNode(Node NextNode)
    {
        Route.Add(NextNode);
    }

    public override string ToString()
    {
        StringBuilder SB = new StringBuilder();
        foreach(Node n in Route)
        {
            SB.Append(n.ToString());
        }

        return SB.ToString();
    }

    public Node GetRouteEnd()
    {
        return Route.Last();
    }

    public void EndRoute()
    {
        foreach(Node n in Route)
        {
            n.SetSelected(false);
        }
    }
}

