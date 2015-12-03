namespace MessageEncoder
{
    using System;
    using System.Collections.Generic;

    public sealed class TopologicalSort<T> where T : IEquatable<T>, IComparable
    {
        private Dictionary<T, NodeInfo> Nodes = new Dictionary<T, NodeInfo>();
   
 
        public bool Edge(T nodeKey)
        {
            if (nodeKey == null)
                return false;

            if (!Nodes.ContainsKey(nodeKey))
                Nodes.Add(nodeKey, new NodeInfo());

            return true;
        }

        public bool Edge(T successor, T predecessor)
        {
                if (!Edge(successor)) return false;
            if (!Edge(predecessor)) return false;

            if (successor.Equals(predecessor)) return false;

            var successorsOfPredecessor = Nodes[predecessor].Successors;

            if (!successorsOfPredecessor.Contains(successor))
            {
                successorsOfPredecessor.Add(successor);

                Nodes[successor].PredecessorCount++;
            }
            return true;

        }

        public bool Sort(out Queue<T> sortedQueue)
        {
            sortedQueue = new Queue<T>(); 

            var outputQueue = new PriorityQueue<T>(); 

            foreach (KeyValuePair<T, NodeInfo> kvp in Nodes)
            {
                if (kvp.Value.PredecessorCount == 0)
                {
                    outputQueue.Enqueue(kvp.Key);
                }
            }

            T nodeKey;
            NodeInfo nodeInfo;

            while (outputQueue.Count != 0)
            {
                nodeKey = outputQueue.Dequeue();

                sortedQueue.Enqueue(nodeKey); 
                nodeInfo = Nodes[nodeKey]; 

                Nodes.Remove(nodeKey);

                foreach (T successor in nodeInfo.Successors)
                    if (--Nodes[successor].PredecessorCount == 0)
                        outputQueue.Enqueue(successor);

                nodeInfo.Clear();

            }

            if (Nodes.Count == 0)
                return true;	

            CycleInfo(sortedQueue);
            return false; 

        }

        public void Clear()
        {
            foreach (NodeInfo nodeInfo in Nodes.Values)
                nodeInfo.Clear();

            Nodes.Clear();
        }
      
        public void CycleInfo(Queue<T> cycleQueue)
        {
            cycleQueue.Clear(); 

            foreach (NodeInfo nodeInfo in Nodes.Values)
                nodeInfo.ContainsCycleKey = nodeInfo.CycleWasOutput = false;

            T cycleKey = default(T);
            bool cycleKeyFound = false;

            NodeInfo successorInfo;

            foreach (KeyValuePair<T, NodeInfo> kvp in Nodes)
            {
                foreach (T successor in kvp.Value.Successors)
                {
                    successorInfo = Nodes[successor];

                    if (!successorInfo.ContainsCycleKey)
                    {
                        successorInfo.CycleKey = kvp.Key;
                        successorInfo.ContainsCycleKey = true;

                        if (!cycleKeyFound)
                        {
                            cycleKey = kvp.Key;
                            cycleKeyFound = true;
                        }
                    }
                }
                kvp.Value.Clear();
            }

            if (!cycleKeyFound)
                throw new Exception("program error: !cycleKeyFound");

            NodeInfo cycleNodeInfo;
            while (!(cycleNodeInfo = Nodes[cycleKey]).CycleWasOutput)
            {
                if (!cycleNodeInfo.ContainsCycleKey)
                    throw new Exception("program error: nodeInfo.ContainsCycleKey");

                cycleQueue.Enqueue(cycleKey);
                cycleNodeInfo.CycleWasOutput = true;
                cycleKey = cycleNodeInfo.CycleKey;

            }


        }
        public class NodeInfo
        {
            public int PredecessorCount;
            public List<T> Successors = new List<T>();

            public T CycleKey;
            public bool ContainsCycleKey;
            public bool CycleWasOutput;

            public void Clear()
            {
                Successors.Clear();
            }

        }
    }
}
