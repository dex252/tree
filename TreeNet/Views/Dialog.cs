using System.Linq;
using System.Windows.Forms;
using TreeNet.Models;
using TreeNet.ViewModels;

namespace TreeNet.Views
{
    public partial class Dialog : Form
    {
        public Node Selected { get; }

        public Screen Screen { get; }
        public Dialog(Node selected, Screen screen)
        {
            Selected = selected;
            Screen = screen;
            InitializeComponent();
            InputWeight.Text = "1";
        }

        private void ConfirmButtonClick(object sender, System.EventArgs e)
        {
            var nodeName = Input.Text;
            if (string.IsNullOrWhiteSpace(nodeName) || nodeName == Tree.ROOT)
            {
                return;
            }

            var isParse = int.TryParse(InputWeight.Text, out int weight);

            if (!isParse)
            {
                return;
            }

            Selected.AddNode(nodeName, weight);
            Screen.UpdateImage();
        }

        private void InputWeight_TextChanged(object sender, System.EventArgs e)
        {
            if (InputWeight.Text.Length == 0 || InputWeight.Text == "0")
            {
                InputWeight.Text = "10";
                return;
            }

            InputWeight.Text = string.Join("", InputWeight.Text.Where(e => char.IsDigit(e)));
            InputWeight.SelectionStart = InputWeight.Text.Length;
        }
    }
}
