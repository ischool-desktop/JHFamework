namespace Framework.Security.UI
{
    partial class RoleManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelLeft = new DevComponents.DotNetBar.ExpandablePanel();
            this.TableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.Add = new DevComponents.DotNetBar.ButtonX();
            this.Delete = new DevComponents.DotNetBar.ButtonX();
            this.RolesPanel = new DevComponents.DotNetBar.ItemPanel();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.Splitter = new DevComponents.DotNetBar.ExpandableSplitter();
            this.Save = new DevComponents.DotNetBar.ButtonX();
            this.PanelTop = new DevComponents.DotNetBar.PanelEx();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.TreeMenu = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.AT = new DevComponents.AdvTree.AdvTree();
            this.DefaultStyle = new DevComponents.DotNetBar.ElementStyle();
            this.chName = new DevComponents.AdvTree.ColumnHeader();
            this.chView = new DevComponents.AdvTree.ColumnHeader();
            this.chEdit = new DevComponents.AdvTree.ColumnHeader();
            this.chExecute = new DevComponents.AdvTree.ColumnHeader();
            this.chNone = new DevComponents.AdvTree.ColumnHeader();
            this.chAdvanced = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.cell9 = new DevComponents.AdvTree.Cell();
            this.RadioCellStyle = new DevComponents.DotNetBar.ElementStyle();
            this.cell10 = new DevComponents.AdvTree.Cell();
            this.cell11 = new DevComponents.AdvTree.Cell();
            this.cell12 = new DevComponents.AdvTree.Cell();
            this.node2 = new DevComponents.AdvTree.Node();
            this.cell13 = new DevComponents.AdvTree.Cell();
            this.cell14 = new DevComponents.AdvTree.Cell();
            this.cell15 = new DevComponents.AdvTree.Cell();
            this.cell16 = new DevComponents.AdvTree.Cell();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cell1 = new DevComponents.AdvTree.Cell();
            this.cell2 = new DevComponents.AdvTree.Cell();
            this.cell3 = new DevComponents.AdvTree.Cell();
            this.cell4 = new DevComponents.AdvTree.Cell();
            this.cell5 = new DevComponents.AdvTree.Cell();
            this.cell6 = new DevComponents.AdvTree.Cell();
            this.cell7 = new DevComponents.AdvTree.Cell();
            this.cell8 = new DevComponents.AdvTree.Cell();
            this.PanelLeft.SuspendLayout();
            this.TableLayout1.SuspendLayout();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AT)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelLeft.Controls.Add(this.TableLayout1);
            this.PanelLeft.Controls.Add(this.RolesPanel);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.ExpandButtonVisible = false;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(172, 464);
            this.PanelLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.PanelLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.PanelLeft.Style.GradientAngle = 90;
            this.PanelLeft.TabIndex = 0;
            this.PanelLeft.TitleHeight = 30;
            this.PanelLeft.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.PanelLeft.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelLeft.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelLeft.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.PanelLeft.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelLeft.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelLeft.TitleStyle.GradientAngle = 90;
            this.PanelLeft.TitleText = "角色清單";
            // 
            // TableLayout1
            // 
            this.TableLayout1.ColumnCount = 2;
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout1.Controls.Add(this.Add, 0, 0);
            this.TableLayout1.Controls.Add(this.Delete, 1, 0);
            this.TableLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout1.Location = new System.Drawing.Point(0, 430);
            this.TableLayout1.Name = "TableLayout1";
            this.TableLayout1.RowCount = 1;
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout1.Size = new System.Drawing.Size(172, 34);
            this.TableLayout1.TabIndex = 3;
            // 
            // Add
            // 
            this.Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Add.Location = new System.Drawing.Point(19, 5);
            this.Add.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(62, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "新增";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Delete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Delete.Enabled = false;
            this.Delete.Location = new System.Drawing.Point(91, 5);
            this.Delete.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(62, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "刪除";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // RolesPanel
            // 
            // 
            // 
            // 
            this.RolesPanel.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.RolesPanel.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.RolesPanel.BackgroundStyle.BorderBottomWidth = 1;
            this.RolesPanel.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.RolesPanel.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.RolesPanel.BackgroundStyle.BorderLeftWidth = 1;
            this.RolesPanel.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.RolesPanel.BackgroundStyle.BorderRightWidth = 1;
            this.RolesPanel.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.RolesPanel.BackgroundStyle.BorderTopWidth = 1;
            this.RolesPanel.BackgroundStyle.PaddingBottom = 1;
            this.RolesPanel.BackgroundStyle.PaddingLeft = 1;
            this.RolesPanel.BackgroundStyle.PaddingRight = 1;
            this.RolesPanel.BackgroundStyle.PaddingTop = 1;
            this.RolesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RolesPanel.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.RolesPanel.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.RolesPanel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.RolesPanel.Location = new System.Drawing.Point(0, 30);
            this.RolesPanel.Name = "RolesPanel";
            this.RolesPanel.Size = new System.Drawing.Size(172, 400);
            this.RolesPanel.TabIndex = 1;
            this.RolesPanel.Text = "itemPanel1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "buttonItem1";
            // 
            // Splitter
            // 
            this.Splitter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.Splitter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Splitter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.Splitter.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.Splitter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Splitter.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Splitter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.Splitter.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Splitter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.Splitter.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Splitter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.Splitter.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.Splitter.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.Splitter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.Splitter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.Splitter.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.Splitter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Splitter.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Splitter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.Splitter.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.Splitter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.Splitter.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Splitter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.Splitter.Location = new System.Drawing.Point(172, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(3, 464);
            this.Splitter.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.Splitter.TabIndex = 1;
            this.Splitter.TabStop = false;
            // 
            // Save
            // 
            this.Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Save.Enabled = false;
            this.Save.Location = new System.Drawing.Point(543, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(62, 22);
            this.Save.TabIndex = 2;
            this.Save.Text = "儲存";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // PanelTop
            // 
            this.PanelTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.PanelTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelTop.Controls.Add(this.Save);
            this.PanelTop.Controls.Add(this.contextMenuBar1);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(175, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(609, 31);
            this.PanelTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelTop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelTop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PanelTop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelTop.Style.GradientAngle = 90;
            this.PanelTop.Style.MarginLeft = 10;
            this.PanelTop.TabIndex = 3;
            this.PanelTop.Text = "(角色名稱) ";
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.TreeMenu});
            this.contextMenuBar1.Location = new System.Drawing.Point(102, 4);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(97, 25);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.contextMenuBar1.TabIndex = 1;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "CM";
            // 
            // TreeMenu
            // 
            this.TreeMenu.AutoExpandOnClick = true;
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5});
            this.TreeMenu.Text = "TreeMenu";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Tag = "View";
            this.buttonItem2.Text = "變更權限成「檢視」";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Tag = "Edit";
            this.buttonItem3.Text = "變更權限成「編輯」";
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Tag = "Execute";
            this.buttonItem4.Text = "變更權限成「執行」";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Tag = "None";
            this.buttonItem5.Text = "變更權限成「無」";
            // 
            // AT
            // 
            this.AT.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.AT.AllowDrop = true;
            this.AT.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.AT.BackgroundStyle.Class = "TreeBorderKey";
            this.AT.CellStyleDefault = this.DefaultStyle;
            this.AT.Columns.Add(this.chName);
            this.AT.Columns.Add(this.chView);
            this.AT.Columns.Add(this.chEdit);
            this.AT.Columns.Add(this.chExecute);
            this.AT.Columns.Add(this.chNone);
            this.AT.Columns.Add(this.chAdvanced);
            this.contextMenuBar1.SetContextMenuEx(this.AT, this.TreeMenu);
            this.AT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AT.DragDropEnabled = false;
            this.AT.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AT.HotTracking = true;
            this.AT.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.AT.Location = new System.Drawing.Point(175, 31);
            this.AT.MultiSelect = true;
            this.AT.MultiSelectRule = DevComponents.AdvTree.eMultiSelectRule.AnyNode;
            this.AT.Name = "AT";
            this.AT.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node2});
            this.AT.NodesConnector = this.nodeConnector1;
            this.AT.NodeStyle = this.DefaultStyle;
            this.AT.PathSeparator = ";";
            this.AT.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.AT.Size = new System.Drawing.Size(609, 433);
            this.AT.Styles.Add(this.DefaultStyle);
            this.AT.Styles.Add(this.RadioCellStyle);
            this.AT.TabIndex = 4;
            // 
            // DefaultStyle
            // 
            this.DefaultStyle.Name = "DefaultStyle";
            this.DefaultStyle.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // chName
            // 
            this.chName.Name = "chName";
            this.chName.Text = "名稱";
            this.chName.Width.Relative = 60;
            // 
            // chView
            // 
            this.chView.Name = "chView";
            this.chView.Text = "檢視";
            this.chView.Width.Relative = 8;
            // 
            // chEdit
            // 
            this.chEdit.Name = "chEdit";
            this.chEdit.Text = "編輯";
            this.chEdit.Width.Relative = 8;
            // 
            // chExecute
            // 
            this.chExecute.Name = "chExecute";
            this.chExecute.Text = "執行";
            this.chExecute.Width.Relative = 8;
            // 
            // chNone
            // 
            this.chNone.Name = "chNone";
            this.chNone.Text = "無";
            this.chNone.Width.Relative = 8;
            // 
            // chAdvanced
            // 
            this.chAdvanced.Name = "chAdvanced";
            this.chAdvanced.Text = "進階";
            this.chAdvanced.Width.Relative = 8;
            // 
            // node1
            // 
            this.node1.Cells.Add(this.cell9);
            this.node1.Cells.Add(this.cell10);
            this.node1.Cells.Add(this.cell11);
            this.node1.Cells.Add(this.cell12);
            this.node1.Expanded = true;
            this.node1.FullRowBackground = true;
            this.node1.Name = "node1";
            this.node1.Text = "學生資料設定";
            // 
            // cell9
            // 
            this.cell9.CheckBoxVisible = true;
            this.cell9.Name = "cell9";
            this.cell9.StyleMouseOver = null;
            this.cell9.StyleNormal = this.RadioCellStyle;
            // 
            // RadioCellStyle
            // 
            this.RadioCellStyle.Name = "RadioCellStyle";
            this.RadioCellStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            // 
            // cell10
            // 
            this.cell10.CheckBoxVisible = true;
            this.cell10.Name = "cell10";
            this.cell10.StyleMouseOver = null;
            this.cell10.StyleNormal = this.RadioCellStyle;
            // 
            // cell11
            // 
            this.cell11.Name = "cell11";
            this.cell11.StyleMouseOver = null;
            this.cell11.StyleNormal = this.RadioCellStyle;
            // 
            // cell12
            // 
            this.cell12.CheckBoxVisible = true;
            this.cell12.Name = "cell12";
            this.cell12.StyleMouseOver = null;
            this.cell12.StyleNormal = this.RadioCellStyle;
            // 
            // node2
            // 
            this.node2.Cells.Add(this.cell13);
            this.node2.Cells.Add(this.cell14);
            this.node2.Cells.Add(this.cell15);
            this.node2.Cells.Add(this.cell16);
            this.node2.Name = "node2";
            this.node2.Text = "班級資料設定";
            // 
            // cell13
            // 
            this.cell13.Name = "cell13";
            this.cell13.StyleMouseOver = null;
            this.cell13.StyleNormal = this.RadioCellStyle;
            // 
            // cell14
            // 
            this.cell14.Name = "cell14";
            this.cell14.StyleMouseOver = null;
            this.cell14.StyleNormal = this.RadioCellStyle;
            // 
            // cell15
            // 
            this.cell15.CheckBoxVisible = true;
            this.cell15.Name = "cell15";
            this.cell15.StyleMouseOver = null;
            this.cell15.StyleNormal = this.RadioCellStyle;
            // 
            // cell16
            // 
            this.cell16.CheckBoxVisible = true;
            this.cell16.Name = "cell16";
            this.cell16.StyleMouseOver = null;
            this.cell16.StyleNormal = this.RadioCellStyle;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.Location = new System.Drawing.Point(323, 28);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(0, 0);
            this.checkBoxX1.TabIndex = 1;
            this.checkBoxX1.TextVisible = false;
            // 
            // cell1
            // 
            this.cell1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cell1.CheckBoxVisible = true;
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
            // 
            // cell2
            // 
            this.cell2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cell2.CheckBoxVisible = true;
            this.cell2.Name = "cell2";
            this.cell2.StyleMouseOver = null;
            // 
            // cell3
            // 
            this.cell3.Name = "cell3";
            this.cell3.StyleMouseOver = null;
            // 
            // cell4
            // 
            this.cell4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cell4.CheckBoxVisible = true;
            this.cell4.Name = "cell4";
            this.cell4.StyleMouseOver = null;
            // 
            // cell5
            // 
            this.cell5.Name = "cell5";
            this.cell5.StyleMouseOver = null;
            // 
            // cell6
            // 
            this.cell6.Name = "cell6";
            this.cell6.StyleMouseOver = null;
            // 
            // cell7
            // 
            this.cell7.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cell7.CheckBoxVisible = true;
            this.cell7.Name = "cell7";
            this.cell7.StyleMouseOver = null;
            // 
            // cell8
            // 
            this.cell8.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cell8.CheckBoxVisible = true;
            this.cell8.Name = "cell8";
            this.cell8.StyleMouseOver = null;
            // 
            // RoleManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.AT);
            this.Controls.Add(this.PanelTop);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.PanelLeft);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "RoleManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色權限管理";
            this.Load += new System.EventHandler(this.RoleManager_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RoleManager_FormClosed);
            this.PanelLeft.ResumeLayout(false);
            this.TableLayout1.ResumeLayout(false);
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel PanelLeft;
        private DevComponents.DotNetBar.ItemPanel RolesPanel;
        private DevComponents.DotNetBar.ExpandableSplitter Splitter;
        private DevComponents.DotNetBar.ButtonX Delete;
        private DevComponents.DotNetBar.ButtonX Add;
        private DevComponents.DotNetBar.ButtonX Save;
        private System.Windows.Forms.TableLayoutPanel TableLayout1;
        private DevComponents.DotNetBar.PanelEx PanelTop;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.AdvTree.Cell cell1;
        private DevComponents.AdvTree.Cell cell2;
        private DevComponents.AdvTree.Cell cell3;
        private DevComponents.AdvTree.Cell cell4;
        private DevComponents.AdvTree.Cell cell5;
        private DevComponents.AdvTree.Cell cell6;
        private DevComponents.AdvTree.Cell cell7;
        private DevComponents.AdvTree.Cell cell8;
        private DevComponents.AdvTree.AdvTree AT;
        private DevComponents.AdvTree.ColumnHeader chName;
        private DevComponents.AdvTree.ColumnHeader chView;
        private DevComponents.AdvTree.ColumnHeader chEdit;
        private DevComponents.AdvTree.ColumnHeader chExecute;
        private DevComponents.AdvTree.ColumnHeader chNone;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle DefaultStyle;
        private DevComponents.AdvTree.Cell cell9;
        private DevComponents.AdvTree.Cell cell10;
        private DevComponents.AdvTree.Cell cell11;
        private DevComponents.AdvTree.Cell cell12;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Cell cell13;
        private DevComponents.AdvTree.Cell cell14;
        private DevComponents.AdvTree.Cell cell15;
        private DevComponents.AdvTree.Cell cell16;
        private DevComponents.DotNetBar.ElementStyle RadioCellStyle;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem TreeMenu;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.AdvTree.ColumnHeader chAdvanced;
    }
}