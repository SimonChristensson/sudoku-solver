using System.Collections.Generic;

namespace Demo.Sudoku.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new DancingLinkQuery();

            var leftNode= data.GetDoubleLinkedList(new List<int?>() {1, 3});
            var rightNode = data.GetDoubleLinkedList(new List<int?>() {2, 4});

            var nodes = new List<Node>();
            nodes.Add(leftNode);
            nodes.Add(rightNode);

            var test1 = data.RemoveTopNodes(nodes);
            var test = data.DobuleLinkRows(nodes);




        }
    }
}
