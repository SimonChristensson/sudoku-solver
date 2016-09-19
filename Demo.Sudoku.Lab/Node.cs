namespace Demo.Sudoku.Lab
{
    public class Node
    {
        public int? Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public Node TopNode { get; set; }
        public Node BottomNode { get; set; }
    }
}
