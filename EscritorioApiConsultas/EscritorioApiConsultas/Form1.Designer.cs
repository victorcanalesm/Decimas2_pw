namespace EscritorioApiConsultas
{
    partial class Form1
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
            button1 = new Button();
            label1 = new Label();
            txtCodigo = new NumericUpDown();
            txtNombre = new TextBox();
            label2 = new Label();
            txtPrecio = new NumericUpDown();
            label3 = new Label();
            btnGuardar = new Button();
            dataGridView1 = new DataGridView();
            EDITAR = new DataGridViewButtonColumn();
            ELIMINAR = new DataGridViewButtonColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dgvVenta = new DataGridView();
            txtCantidad = new NumericUpDown();
            cmbProducto = new ComboBox();
            BtnGuardarVenta = new Button();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)txtCodigo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCantidad).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(17, 20);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "Recargar grilla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 1;
            label1.Text = "Código producto";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(33, 82);
            txtCodigo.Margin = new Padding(3, 2, 3, 2);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(108, 23);
            txtCodigo.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(154, 81);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(191, 23);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 53);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre producto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(366, 81);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(131, 23);
            txtPrecio.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 53);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Precio producto";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(521, 80);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 22);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EDITAR, ELIMINAR });
            dataGridView1.Location = new Point(33, 130);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(612, 194);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // EDITAR
            // 
            EDITAR.HeaderText = "EDITAR";
            EDITAR.MinimumWidth = 6;
            EDITAR.Name = "EDITAR";
            EDITAR.Text = "EDITAR";
            EDITAR.UseColumnTextForButtonValue = true;
            EDITAR.Width = 125;
            // 
            // ELIMINAR
            // 
            ELIMINAR.HeaderText = "ELIMINAR";
            ELIMINAR.MinimumWidth = 6;
            ELIMINAR.Name = "ELIMINAR";
            ELIMINAR.Text = "ELIMINAR";
            ELIMINAR.UseColumnTextForButtonValue = true;
            ELIMINAR.Width = 125;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 22);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(712, 384);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(btnGuardar);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtCodigo);
            tabPage1.Controls.Add(txtPrecio);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(704, 356);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Productos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvVenta);
            tabPage2.Controls.Add(txtCantidad);
            tabPage2.Controls.Add(cmbProducto);
            tabPage2.Controls.Add(BtnGuardarVenta);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(704, 356);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Venta";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvVenta
            // 
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Location = new Point(23, 103);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(636, 194);
            dgvVenta.TabIndex = 5;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(235, 55);
            txtCantidad.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(120, 23);
            txtCantidad.TabIndex = 4;
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(23, 55);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(188, 23);
            cmbProducto.TabIndex = 3;
            // 
            // BtnGuardarVenta
            // 
            BtnGuardarVenta.Location = new Point(387, 55);
            BtnGuardarVenta.Name = "BtnGuardarVenta";
            BtnGuardarVenta.Size = new Size(75, 23);
            BtnGuardarVenta.TabIndex = 2;
            BtnGuardarVenta.Text = "Guardar";
            BtnGuardarVenta.UseVisualStyleBackColor = true;
            BtnGuardarVenta.Click += BtnGuardarVenta_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(235, 19);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 1;
            label5.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 19);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 0;
            label4.Text = "Producto";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 430);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)txtCodigo).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private NumericUpDown txtCodigo;
        private TextBox txtNombre;
        private Label label2;
        private NumericUpDown txtPrecio;
        private Label label3;
        private Button btnGuardar;
        private DataGridView dataGridView1;
        private DataGridViewButtonColumn EDITAR;
        private DataGridViewButtonColumn ELIMINAR;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private DataGridView dgvVenta;
        private NumericUpDown txtCantidad;
        private ComboBox cmbProducto;
        private Button BtnGuardarVenta;
        private Label label5;
        private Label label4;
    }
}
