using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TreeNet.Models;
using TreeNet.ViewModels;

namespace TreeNet.Views
{
    public partial class Screen : Form
    {
        private Tree Tree { get; set; }

        private Node Selected { get; set; }

        public Screen()
        {
            Tree = new Tree();
            InitializeComponent();

            TreeView.Nodes.Add(Tree.Root);
        }

        private void PanelPaint(object sender, PaintEventArgs e)
        {
            RichText.Text = "";
            var canvas = e.Graphics;
            canvas.Clear(Color.White);
            Tree.DrawTree(canvas);

            if (Selected == null)
            {
                return;
            }

            RichText.Text += $"Выбранная нода: {Selected.Text} ; id: {Selected.Name}\n";

            var selectedPen = new Pen(Color.Orange);
            var minPen = new Pen(Color.Green);
            var maxPen = new Pen(Color.Red);

            canvas.DrawEllipse(selectedPen, Selected.Point.X, Selected.Point.Y, Tree.NODE_SIZE, Tree.NODE_SIZE);

            if (Selected.MinWay != null)
            {
                
                foreach (var path in Selected.MinWay)
                {
                    RichText.Text += $"Короткий путь: {Selected.Text} => ";
                    foreach (var node in path.Path)
                    {
                        RichText.Text += $"{node.Text} => ";
                        canvas.DrawEllipse(minPen, node.Point.X, node.Point.Y, Tree.NODE_SIZE, Tree.NODE_SIZE);
                    }
                    RichText.Text = RichText.Text.Substring(0, RichText.Text.Length - 3) + "\n";
                }

               
            }

            if (Selected.MaxWay != null)
            {

                foreach (var path in Selected.MaxWay)
                {
                    RichText.Text += $"Длинный путь: {Selected.Text} => ";
                    foreach (var node in path.Path)
                    {
                        RichText.Text += $"{node.Text} => ";
                    }

                    canvas.DrawEllipse(maxPen, path.Path.Last().Point.X, path.Path.Last().Point.Y, Tree.NODE_SIZE, Tree.NODE_SIZE);
                    RichText.Text = RichText.Text.Substring(0, RichText.Text.Length - 3) + "\n";

                }
            }
        }

        private void ContextMenuClickItem(object sender, ToolStripItemClickedEventArgs e)
        {
            var selected = TreeView.SelectedNode as Node;

            if (selected == null)
            {
                return;
            }

            if (e.ClickedItem.Tag?.ToString() == "Add")
            {
                var dialog = new Dialog(selected, this);
                dialog.ShowDialog();
                dialog.Dispose();

                return;
            }

            if (selected.Name == Tree.Root.Name)
            {
                return;
            }

            if (e.ClickedItem.Tag?.ToString() == "Remove")
            {
                selected.RemoveNode(selected.Name);
                Selected = null;
                Panel.Invalidate();

                return;
            }

            if (e.ClickedItem.Tag?.ToString() == "Calc")
            {
                Tree.CalculateAll();
                Panel.Invalidate();
            }
        }

        public void UpdateImage()
        {
            Selected = null;
            Panel.Invalidate();
        }

        private void TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ContextMenu.Show(MousePosition, ToolStripDropDownDirection.Right);
        }


        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selected = e.Node as Node;

            if (selected == null)
            {
                Selected = null;
                return;
            }

            Selected = selected;
            Panel.Invalidate();
        }
    }
}
