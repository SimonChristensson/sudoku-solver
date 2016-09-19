using System.Collections.Generic;

namespace Demo.Sudoku.Lab
{
    public class DancingLinkQuery
    {
        public List<Node> LinkColumns(List<List<int?>> matrix)
        {
            //
            return new List<Node>();            
        }

        public Node DobuleLinkRows(List<Node> nodes)
        {

            //Remove first row
            if (nodes.Count == 1)
                return nodes[0];

            if (nodes[0].BottomNode == null)
                return nodes[0];



            nodes[0].RightNode = DobuleLinkRows(nodes.GetRange(1, nodes.Count - 1));
            nodes[0].RightNode.LeftNode = nodes[0];


            //nodes[0].BottomNode.RightNode = DobuleLinkRows()//nodes[1].BottomNode;
            nodes[0].BottomNode.RightNode.LeftNode = nodes[0].BottomNode;



            return nodes[0];
        }

        public List<Node> RemoveTopNodes(List<Node> nodes)
        {
            if (nodes[0].BottomNode == null)
                return nodes;


            if (nodes.Count == 1)
                return nodes;


            

            
            var newNodes = RemoveTopNodes(nodes.GetRange(1, nodes.Count-1));
            newNodes[0] = newNodes[0].BottomNode;


            return nodes;
        } 

      
     

        public Node GetDoubleLinkedList(List<int?> column)
        {
            var node = new Node {Value = column[0]};

            if (column.Count == 1)
                return node;

            node.Value = column[0];
            node.BottomNode = GetDoubleLinkedList(column.GetRange(1, column.Count - 1));
            node.BottomNode.TopNode = node;

            return node;
        } 
    }
}
