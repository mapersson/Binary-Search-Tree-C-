
namespace Trees
{
    public class Node
    {
        public int data { get; set; }
        public int height { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node()
        {

        }
        public Node(int data)
        {
            this.data = data;
            this.height = 0;
            this.left = null;
            this.right = null;
        }
    }
}