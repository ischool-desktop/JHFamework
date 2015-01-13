namespace Framework.Security.UI
{
    partial class RoleAddForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.RoleName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.RoleDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.CopyRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(131, 157);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(60, 23);
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "新增";
            this.buttonX1.Click += new System.EventHandler(this.Add_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(196, 157);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(60, 23);
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "關閉";
            this.buttonX2.Click += new System.EventHandler(this.Close_Click);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.RoleName.Border.Class = "TextBoxBorder";
            this.RoleName.Location = new System.Drawing.Point(76, 11);
            this.RoleName.Name = "textBoxX1";
            this.RoleName.Size = new System.Drawing.Size(180, 25);
            this.RoleName.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(14, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 19);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "角色名稱";
            // 
            // errorProvider1
            // 
            this.Errors.BlinkRate = 0;
            this.Errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Errors.ContainerControl = this;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.RoleDescription.Border.Class = "TextBoxBorder";
            this.RoleDescription.Location = new System.Drawing.Point(76, 44);
            this.RoleDescription.Multiline = true;
            this.RoleDescription.Name = "textBoxX2";
            this.RoleDescription.Size = new System.Drawing.Size(180, 70);
            this.RoleDescription.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(14, 70);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 19);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "角色描述";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.CopyRole);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.RoleDescription);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.RoleName);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(272, 191);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(14, 117);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 35);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "複製現有角色權限";
            this.labelX3.WordWrap = true;
            // 
            // comboBoxEx1
            // 
            this.CopyRole.DisplayMember = "Text";
            this.CopyRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CopyRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CopyRole.FormattingEnabled = true;
            this.CopyRole.ItemHeight = 19;
            this.CopyRole.Location = new System.Drawing.Point(76, 122);
            this.CopyRole.Name = "comboBoxEx1";
            this.CopyRole.Size = new System.Drawing.Size(180, 25);
            this.CopyRole.TabIndex = 2;
            // 
            // RoleAddForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(272, 191);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleAddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增角色";
            this.Load += new System.EventHandler(this.RoleAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.TextBoxX RoleName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ErrorProvider Errors;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX RoleDescription;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CopyRole;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}