using gourmet_game.Models;

namespace gourmet_game.Util
{
    public abstract class TreeFactory<T>
    {
        private Node<T> Tree;
        public abstract void CreateTree();
        public abstract Node<T> GetTree();
        public abstract void InsertLeftNode(Node<GuessingFood> node, string text, EType type);
        public abstract void InsertRightNode(Node<GuessingFood> node, string text, EType type);
        public abstract void InsertNewFood(Node<GuessingFood> lastNode, string newFoodName, string newQuestion);
    }
}
