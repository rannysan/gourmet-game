using gourmet_game.Concrete;
using gourmet_game.Models;
using gourmet_game.Views;
using System;
using System.Windows.Forms;

namespace gourmet_game
{
    public partial class FirstView : Form
    {
        GuessingFoodTree guessingFoodTree = new GuessingFoodTree();

        public FirstView()
        {
            InitializeComponent();
        }

        private void FirstView_Load(object sender, EventArgs e)
        {
            guessingFoodTree.CreateTree();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            PlayGame(guessingFoodTree.GetTree());
        }

        public void PlayGame(Node<GuessingFood> root)
        {
            if (TryGuessing(root))// left
            {
                if(root.LeftNode != null)
                {
                    PlayGame(root.LeftNode);
                }
                else
                {
                    MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK);
                }
            }
            else// right
            {
                if (root.RightNode != null)
                {
                    PlayGame(root.RightNode);
                }
                else
                {
                    GiveUp(root);
                }
            }
        }

        public void GiveUp(Node<GuessingFood> lastNode)
        {
            GiveUpDialog newFoodDialog = new GiveUpDialog() { labelText = "Qual prato você pensou?"};
            newFoodDialog.ShowDialog();

            GiveUpDialog newQuestionDialog = new GiveUpDialog() { labelText = $"{newFoodDialog.result} é _____, mas {lastNode.Value.Text} não." };
            newQuestionDialog.ShowDialog();

            guessingFoodTree.InsertNewFood(lastNode, newFoodDialog.result, newQuestionDialog.result);

            PlayGame(guessingFoodTree.GetTree());
        }

        public bool TryGuessing(Node<GuessingFood> node)
        {
            DialogResult answer;

            switch (node.Value.Type)
            {
                case Util.EType.Question:
                    answer = MessageBox.Show($"O prato que você pensou é {node.Value.Text} ?", "Confirm", MessageBoxButtons.YesNo);
                    return answer == DialogResult.Yes ? true : false;
                case Util.EType.Food:
                    answer = MessageBox.Show($"O prato que você pensou é {node.Value.Text} ?", "Confirm", MessageBoxButtons.YesNo);
                    return answer == DialogResult.Yes ? true : false;
            }

            return false;
        }
    }
}
