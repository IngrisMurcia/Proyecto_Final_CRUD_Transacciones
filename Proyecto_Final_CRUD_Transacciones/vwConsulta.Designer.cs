namespace Proyecto_Final_GrupoD
{
    partial class vwConsulta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vwConsulta));
            this.northwindDataSet = new Proyecto_Final_GrupoD.NorthwindDataSet();
            this.vwComprasAñoClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vwComprasAñoClienteTableAdapter = new Proyecto_Final_GrupoD.NorthwindDataSetTableAdapters.vwComprasAñoClienteTableAdapter();
            this.tableAdapterManager = new Proyecto_Final_GrupoD.NorthwindDataSetTableAdapters.TableAdapterManager();
            this.vwComprasAñoClienteBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.vwComprasAñoClienteBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.vwComprasAñoClienteDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btTodos = new System.Windows.Forms.Button();
            this.btAño = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAños = new System.Windows.Forms.ComboBox();
            this.añosComprasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.northwindDataSet1 = new Proyecto_Final_GrupoD.NorthwindDataSet();
            this.añosComprasTableAdapter = new Proyecto_Final_GrupoD.NorthwindDataSetTableAdapters.AñosComprasTableAdapter();
            this.btLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteBindingNavigator)).BeginInit();
            this.vwComprasAñoClienteBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.añosComprasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName = "NorthwindDataSet";
            this.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwComprasAñoClienteBindingSource
            // 
            this.vwComprasAñoClienteBindingSource.DataMember = "vwComprasAñoCliente";
            this.vwComprasAñoClienteBindingSource.DataSource = this.northwindDataSet;
            // 
            // vwComprasAñoClienteTableAdapter
            // 
            this.vwComprasAñoClienteTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Proyecto_Final_GrupoD.NorthwindDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vwComprasAñoClienteBindingNavigator
            // 
            this.vwComprasAñoClienteBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.vwComprasAñoClienteBindingNavigator.BindingSource = this.vwComprasAñoClienteBindingSource;
            this.vwComprasAñoClienteBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.vwComprasAñoClienteBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.vwComprasAñoClienteBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.vwComprasAñoClienteBindingNavigatorSaveItem});
            this.vwComprasAñoClienteBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.vwComprasAñoClienteBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.vwComprasAñoClienteBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.vwComprasAñoClienteBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.vwComprasAñoClienteBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.vwComprasAñoClienteBindingNavigator.Name = "vwComprasAñoClienteBindingNavigator";
            this.vwComprasAñoClienteBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.vwComprasAñoClienteBindingNavigator.Size = new System.Drawing.Size(678, 25);
            this.vwComprasAñoClienteBindingNavigator.TabIndex = 0;
            this.vwComprasAñoClienteBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // vwComprasAñoClienteBindingNavigatorSaveItem
            // 
            this.vwComprasAñoClienteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vwComprasAñoClienteBindingNavigatorSaveItem.Enabled = false;
            this.vwComprasAñoClienteBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("vwComprasAñoClienteBindingNavigatorSaveItem.Image")));
            this.vwComprasAñoClienteBindingNavigatorSaveItem.Name = "vwComprasAñoClienteBindingNavigatorSaveItem";
            this.vwComprasAñoClienteBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.vwComprasAñoClienteBindingNavigatorSaveItem.Text = "Guardar datos";
            // 
            // vwComprasAñoClienteDataGridView
            // 
            this.vwComprasAñoClienteDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vwComprasAñoClienteDataGridView.AutoGenerateColumns = false;
            this.vwComprasAñoClienteDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.vwComprasAñoClienteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vwComprasAñoClienteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.vwComprasAñoClienteDataGridView.DataSource = this.vwComprasAñoClienteBindingSource;
            this.vwComprasAñoClienteDataGridView.Location = new System.Drawing.Point(12, 128);
            this.vwComprasAñoClienteDataGridView.Name = "vwComprasAñoClienteDataGridView";
            this.vwComprasAñoClienteDataGridView.Size = new System.Drawing.Size(498, 265);
            this.vwComprasAñoClienteDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CustomerID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 87;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CompanyName";
            this.dataGridViewTextBoxColumn2.HeaderText = "CompanyName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Año";
            this.dataGridViewTextBoxColumn3.HeaderText = "Año";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 51;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Total";
            this.dataGridViewTextBoxColumn4.HeaderText = "Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 56;
            // 
            // btTodos
            // 
            this.btTodos.Location = new System.Drawing.Point(354, 81);
            this.btTodos.Name = "btTodos";
            this.btTodos.Size = new System.Drawing.Size(75, 23);
            this.btTodos.TabIndex = 9;
            this.btTodos.Text = "Todos";
            this.btTodos.UseVisualStyleBackColor = true;
            this.btTodos.Click += new System.EventHandler(this.btTodos_Click);
            // 
            // btAño
            // 
            this.btAño.Location = new System.Drawing.Point(273, 81);
            this.btAño.Name = "btAño";
            this.btAño.Size = new System.Drawing.Size(75, 23);
            this.btAño.TabIndex = 8;
            this.btAño.Text = "Por Año";
            this.btAño.UseVisualStyleBackColor = true;
            this.btAño.Click += new System.EventHandler(this.btAño_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleccione el Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(20, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Compras por Año de Clientes";
            // 
            // cmbAños
            // 
            this.cmbAños.DataSource = this.añosComprasBindingSource;
            this.cmbAños.DisplayMember = "Año";
            this.cmbAños.FormattingEnabled = true;
            this.cmbAños.Location = new System.Drawing.Point(146, 83);
            this.cmbAños.Name = "cmbAños";
            this.cmbAños.Size = new System.Drawing.Size(121, 21);
            this.cmbAños.TabIndex = 11;
            this.cmbAños.ValueMember = "Año";
            // 
            // añosComprasBindingSource
            // 
            this.añosComprasBindingSource.DataMember = "AñosCompras";
            this.añosComprasBindingSource.DataSource = this.northwindDataSet1;
            // 
            // northwindDataSet1
            // 
            this.northwindDataSet1.DataSetName = "NorthwindDataSet";
            this.northwindDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // añosComprasTableAdapter
            // 
            this.añosComprasTableAdapter.ClearBeforeFill = true;
            // 
            // btLimpiar
            // 
            this.btLimpiar.Location = new System.Drawing.Point(435, 81);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btLimpiar.TabIndex = 12;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // vwConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(678, 405);
            this.Controls.Add(this.btLimpiar);
            this.Controls.Add(this.cmbAños);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btTodos);
            this.Controls.Add(this.btAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vwComprasAñoClienteDataGridView);
            this.Controls.Add(this.vwComprasAñoClienteBindingNavigator);
            this.Name = "vwConsulta";
            this.Text = "vwConsulta";
            this.Load += new System.EventHandler(this.vwConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteBindingNavigator)).EndInit();
            this.vwComprasAñoClienteBindingNavigator.ResumeLayout(false);
            this.vwComprasAñoClienteBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vwComprasAñoClienteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.añosComprasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NorthwindDataSet northwindDataSet;
        private System.Windows.Forms.BindingSource vwComprasAñoClienteBindingSource;
        private NorthwindDataSetTableAdapters.vwComprasAñoClienteTableAdapter vwComprasAñoClienteTableAdapter;
        private NorthwindDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator vwComprasAñoClienteBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton vwComprasAñoClienteBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView vwComprasAñoClienteDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btTodos;
        private System.Windows.Forms.Button btAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAños;
        private NorthwindDataSet northwindDataSet1;
        private System.Windows.Forms.BindingSource añosComprasBindingSource;
        private NorthwindDataSetTableAdapters.AñosComprasTableAdapter añosComprasTableAdapter;
        private System.Windows.Forms.Button btLimpiar;
    }
}