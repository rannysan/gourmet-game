using gourmet_game.Models;
using gourmet_game.Util;

namespace gourmet_game.Concrete
{
    public class GuessingFoodTree : TreeFactory<GuessingFood>
    {
        private Node<GuessingFood> Tree;

        public override void CreateTree()
        {
            GuessingFood firstQuestion = new GuessingFood()
            {
                Text = "O prato que você pensou é massa?",
                Type = EType.Question
            };

            GuessingFood firstLeftNode = new GuessingFood()
            {
                Text = "Lasanha",
                Type = EType.Food
            };

            GuessingFood firstRightNode = new GuessingFood()
            {
                Text = "Bolo de Chocolate",
                Type = EType.Food
            };

            Node<GuessingFood> root = new Node<GuessingFood>()
            {
                Value = firstQuestion,
                LeftNode = new Node<GuessingFood>() { Value = firstLeftNode },
                RightNode = new Node<GuessingFood>() { Value = firstRightNode }
            };

            Tree = root;
        }


        public override Node<GuessingFood> GetTree()
        {
            return Tree;
        }

        public override void InsertLeftNode(Node<GuessingFood> node, string text, EType type)
        {
            Node<GuessingFood> lastNode = FindNode(GetTree(), node.Value.Text);

            lastNode.LeftNode = new Node<GuessingFood>() { Value = new GuessingFood() { Text = text, Type = type } };
        }

        public override void InsertRightNode(Node<GuessingFood> node, string text, EType type)
        {
            Node<GuessingFood> lastNode = FindNode(GetTree(), node.Value.Text);

            lastNode.RightNode = new Node<GuessingFood>() { Value = new GuessingFood() { Text = text, Type = type } };
        }

        public override void InsertNewFood(Node<GuessingFood> node, string newFoodName, string newQuestion)
        {
            Node<GuessingFood> lastFoodNode = FindNode(GetTree(), node.Value.Text);

            GuessingFood oldFood = lastFoodNode.Value;

            lastFoodNode.Value = new GuessingFood() { Text = newQuestion, Type = EType.Question };

            lastFoodNode.LeftNode = new Node<GuessingFood>()
            {
                Value = new GuessingFood() { Text = newFoodName, Type = EType.Food }
            };

            lastFoodNode.RightNode = new Node<GuessingFood>()
            {
                Value = oldFood
            };
        }

        private Node<GuessingFood> FindNode(Node<GuessingFood> node, string text)
        {
            if (node == null) { return null;  }
            if (node.Value.Text == text) { return node; }

            Node<GuessingFood> leftNode = FindNode(node.LeftNode, text);

            if (leftNode != null) { return leftNode; }

            return FindNode(node.RightNode, text);
        }
    }
}
