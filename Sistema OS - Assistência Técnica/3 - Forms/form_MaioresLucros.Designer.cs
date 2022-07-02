
namespace Sistema_OS___Assistência_Técnica._3___Forms
{
    partial class form_MaioresLucros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_MaioresLucros));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.gdv_ExibicaoLucrosGastos = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dtpDataInicio = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.dtpDataFim = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.btnBuscarMaioresLucros = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_ExibicaoLucrosGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // gdv_ExibicaoLucrosGastos
            // 
            this.gdv_ExibicaoLucrosGastos.AllowCustomTheming = true;
            this.gdv_ExibicaoLucrosGastos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.gdv_ExibicaoLucrosGastos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdv_ExibicaoLucrosGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdv_ExibicaoLucrosGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gdv_ExibicaoLucrosGastos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdv_ExibicaoLucrosGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdv_ExibicaoLucrosGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdv_ExibicaoLucrosGastos.ColumnHeadersHeight = 40;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.GridColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(198)))));
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.Name = null;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdv_ExibicaoLucrosGastos.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdv_ExibicaoLucrosGastos.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdv_ExibicaoLucrosGastos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gdv_ExibicaoLucrosGastos.EnableHeadersVisualStyles = false;
            this.gdv_ExibicaoLucrosGastos.GridColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.gdv_ExibicaoLucrosGastos.HeaderBgColor = System.Drawing.Color.Empty;
            this.gdv_ExibicaoLucrosGastos.HeaderForeColor = System.Drawing.Color.White;
            this.gdv_ExibicaoLucrosGastos.Location = new System.Drawing.Point(12, 12);
            this.gdv_ExibicaoLucrosGastos.Name = "gdv_ExibicaoLucrosGastos";
            this.gdv_ExibicaoLucrosGastos.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gdv_ExibicaoLucrosGastos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gdv_ExibicaoLucrosGastos.RowTemplate.Height = 40;
            this.gdv_ExibicaoLucrosGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdv_ExibicaoLucrosGastos.Size = new System.Drawing.Size(1146, 277);
            this.gdv_ExibicaoLucrosGastos.TabIndex = 100001;
            this.gdv_ExibicaoLucrosGastos.TabStop = false;
            this.gdv_ExibicaoLucrosGastos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.BackColor = System.Drawing.Color.Transparent;
            this.dtpDataInicio.BorderRadius = 1;
            this.dtpDataInicio.Color = System.Drawing.Color.Silver;
            this.dtpDataInicio.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpDataInicio.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpDataInicio.DisabledColor = System.Drawing.Color.Gray;
            this.dtpDataInicio.DisplayWeekNumbers = false;
            this.dtpDataInicio.DPHeight = 0;
            this.dtpDataInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDataInicio.FillDatePicker = false;
            this.dtpDataInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataInicio.ForeColor = System.Drawing.Color.Black;
            this.dtpDataInicio.Icon = ((System.Drawing.Image)(resources.GetObject("dtpDataInicio.Icon")));
            this.dtpDataInicio.IconColor = System.Drawing.Color.Gray;
            this.dtpDataInicio.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpDataInicio.LeftTextMargin = 5;
            this.dtpDataInicio.Location = new System.Drawing.Point(318, 309);
            this.dtpDataInicio.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(220, 32);
            this.dtpDataInicio.TabIndex = 100002;
            this.dtpDataInicio.Value = new System.DateTime(2022, 6, 29, 19, 8, 0, 0);
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.BackColor = System.Drawing.Color.Transparent;
            this.dtpDataFim.BorderRadius = 1;
            this.dtpDataFim.Color = System.Drawing.Color.Silver;
            this.dtpDataFim.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpDataFim.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpDataFim.DisabledColor = System.Drawing.Color.Gray;
            this.dtpDataFim.DisplayWeekNumbers = false;
            this.dtpDataFim.DPHeight = 0;
            this.dtpDataFim.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDataFim.FillDatePicker = false;
            this.dtpDataFim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDataFim.ForeColor = System.Drawing.Color.Black;
            this.dtpDataFim.Icon = ((System.Drawing.Image)(resources.GetObject("dtpDataFim.Icon")));
            this.dtpDataFim.IconColor = System.Drawing.Color.Gray;
            this.dtpDataFim.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpDataFim.LeftTextMargin = 5;
            this.dtpDataFim.Location = new System.Drawing.Point(605, 309);
            this.dtpDataFim.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(220, 32);
            this.dtpDataFim.TabIndex = 100003;
            this.dtpDataFim.Value = new System.DateTime(2022, 6, 29, 19, 8, 0, 0);
            // 
            // btnBuscarMaioresLucros
            // 
            this.btnBuscarMaioresLucros.AllowAnimations = true;
            this.btnBuscarMaioresLucros.AllowMouseEffects = true;
            this.btnBuscarMaioresLucros.AllowToggling = false;
            this.btnBuscarMaioresLucros.AnimationSpeed = 200;
            this.btnBuscarMaioresLucros.AutoGenerateColors = false;
            this.btnBuscarMaioresLucros.AutoRoundBorders = false;
            this.btnBuscarMaioresLucros.AutoSizeLeftIcon = true;
            this.btnBuscarMaioresLucros.AutoSizeRightIcon = true;
            this.btnBuscarMaioresLucros.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.BackColor1 = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarMaioresLucros.BackgroundImage")));
            this.btnBuscarMaioresLucros.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBuscarMaioresLucros.ButtonText = "";
            this.btnBuscarMaioresLucros.ButtonTextMarginLeft = 0;
            this.btnBuscarMaioresLucros.ColorContrastOnClick = 45;
            this.btnBuscarMaioresLucros.ColorContrastOnHover = 45;
            this.btnBuscarMaioresLucros.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnBuscarMaioresLucros.CustomizableEdges = borderEdges1;
            this.btnBuscarMaioresLucros.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscarMaioresLucros.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBuscarMaioresLucros.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBuscarMaioresLucros.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBuscarMaioresLucros.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnBuscarMaioresLucros.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscarMaioresLucros.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMaioresLucros.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarMaioresLucros.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarMaioresLucros.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnBuscarMaioresLucros.IconMarginLeft = 11;
            this.btnBuscarMaioresLucros.IconPadding = 10;
            this.btnBuscarMaioresLucros.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarMaioresLucros.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscarMaioresLucros.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnBuscarMaioresLucros.IconSize = 25;
            this.btnBuscarMaioresLucros.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.IdleBorderRadius = 1;
            this.btnBuscarMaioresLucros.IdleBorderThickness = 1;
            this.btnBuscarMaioresLucros.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarMaioresLucros.IdleIconLeftImage")));
            this.btnBuscarMaioresLucros.IdleIconRightImage = null;
            this.btnBuscarMaioresLucros.IndicateFocus = false;
            this.btnBuscarMaioresLucros.Location = new System.Drawing.Point(844, 299);
            this.btnBuscarMaioresLucros.Name = "btnBuscarMaioresLucros";
            this.btnBuscarMaioresLucros.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBuscarMaioresLucros.OnDisabledState.BorderRadius = 1;
            this.btnBuscarMaioresLucros.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBuscarMaioresLucros.OnDisabledState.BorderThickness = 1;
            this.btnBuscarMaioresLucros.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBuscarMaioresLucros.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBuscarMaioresLucros.OnDisabledState.IconLeftImage = null;
            this.btnBuscarMaioresLucros.OnDisabledState.IconRightImage = null;
            this.btnBuscarMaioresLucros.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.btnBuscarMaioresLucros.onHoverState.BorderRadius = 1;
            this.btnBuscarMaioresLucros.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBuscarMaioresLucros.onHoverState.BorderThickness = 1;
            this.btnBuscarMaioresLucros.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.btnBuscarMaioresLucros.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMaioresLucros.onHoverState.IconLeftImage = null;
            this.btnBuscarMaioresLucros.onHoverState.IconRightImage = null;
            this.btnBuscarMaioresLucros.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.OnIdleState.BorderRadius = 1;
            this.btnBuscarMaioresLucros.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBuscarMaioresLucros.OnIdleState.BorderThickness = 1;
            this.btnBuscarMaioresLucros.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.btnBuscarMaioresLucros.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMaioresLucros.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarLucroGastos.OnIdleState.IconLeftImage")));
            this.btnBuscarMaioresLucros.OnIdleState.IconRightImage = null;
            this.btnBuscarMaioresLucros.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.btnBuscarMaioresLucros.OnPressedState.BorderRadius = 1;
            this.btnBuscarMaioresLucros.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnBuscarMaioresLucros.OnPressedState.BorderThickness = 1;
            this.btnBuscarMaioresLucros.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(194)))));
            this.btnBuscarMaioresLucros.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnBuscarMaioresLucros.OnPressedState.IconLeftImage = null;
            this.btnBuscarMaioresLucros.OnPressedState.IconRightImage = null;
            this.btnBuscarMaioresLucros.Size = new System.Drawing.Size(57, 52);
            this.btnBuscarMaioresLucros.TabIndex = 100004;
            this.btnBuscarMaioresLucros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscarMaioresLucros.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscarMaioresLucros.TextMarginLeft = 0;
            this.btnBuscarMaioresLucros.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBuscarMaioresLucros.UseDefaultRadiusAndThickness = true;
            this.btnBuscarMaioresLucros.Click += new System.EventHandler(this.btnBuscarLucroGastos_Click);
            // 
            // form_MaioresLucros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1170, 525);
            this.Controls.Add(this.btnBuscarMaioresLucros);
            this.Controls.Add(this.dtpDataFim);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.gdv_ExibicaoLucrosGastos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_MaioresLucros";
            this.Text = "form_LucrosGastos";
            ((System.ComponentModel.ISupportInitialize)(this.gdv_ExibicaoLucrosGastos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuDataGridView gdv_ExibicaoLucrosGastos;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnBuscarMaioresLucros;
        public Bunifu.UI.WinForms.BunifuDatePicker dtpDataInicio;
        public Bunifu.UI.WinForms.BunifuDatePicker dtpDataFim;
    }
}