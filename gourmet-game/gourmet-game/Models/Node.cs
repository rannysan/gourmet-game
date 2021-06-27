namespace gourmet_game.Models
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
    }
}
