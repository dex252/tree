
namespace TreeNet.Views
{
    partial class Screen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screen));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RichText = new System.Windows.Forms.RichTextBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveNode = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.8289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.1711F));
            this.tableLayoutPanel1.Controls.Add(this.TreeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1315, 784);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Location = new System.Drawing.Point(3, 3);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(189, 778);
            this.TreeView.TabIndex = 1;
            this.TreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView_NodeMouseClick);
            this.TreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewMouseDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.RichText, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Panel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(198, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.0617F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.9383F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1114, 778);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // RichText
            // 
            this.RichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichText.Location = new System.Drawing.Point(3, 657);
            this.RichText.Name = "RichText";
            this.RichText.Size = new System.Drawing.Size(1108, 118);
            this.RichText.TabIndex = 0;
            this.RichText.Text = "";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.White;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(3, 3);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1108, 648);
            this.Panel.TabIndex = 1;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPaint);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNode,
            this.RemoveNode});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(154, 48);
            this.ContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuClickItem);
            // 
            // AddNode
            // 
            this.AddNode.Image = ((System.Drawing.Image)(resources.GetObject("AddNode.Image")));
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(153, 22);
            this.AddNode.Tag = "Add";
            this.AddNode.Text = "Добавить узел";
            // 
            // RemoveNode
            // 
            this.RemoveNode.Image = ((System.Drawing.Image)(resources.GetObject("RemoveNode.Image")));
            this.RemoveNode.Name = "RemoveNode";
            this.RemoveNode.Size = new System.Drawing.Size(153, 22);
            this.RemoveNode.Tag = "Remove";
            this.RemoveNode.Text = "Удалить узел";
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 784);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Screen";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripMenuItem AddNode;
        private System.Windows.Forms.ToolStripMenuItem RemoveNode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.RichTextBox RichText;
    }
}

