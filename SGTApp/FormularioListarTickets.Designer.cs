namespace SGTApp;

partial class FormularioListarTickets
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        Enviar = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        listView1 = new System.Windows.Forms.ListView();
        Titulo = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // Enviar
        // 
        Enviar.ForeColor = System.Drawing.SystemColors.Desktop;
        Enviar.Location = new System.Drawing.Point(34, 164);
        Enviar.Name = "Enviar";
        Enviar.Size = new System.Drawing.Size(87, 30);
        Enviar.TabIndex = 0;
        Enviar.Text = "Enviar";
        Enviar.UseVisualStyleBackColor = true;
        Enviar.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(34, 123);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(233, 23);
        textBox1.TabIndex = 1;
        // 
        // listView1
        // 
        listView1.Location = new System.Drawing.Point(408, 42);
        listView1.Name = "listView1";
        listView1.Size = new System.Drawing.Size(218, 289);
        listView1.TabIndex = 2;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // Titulo
        // 
        Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        Titulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        Titulo.Location = new System.Drawing.Point(34, 69);
        Titulo.Name = "Titulo";
        Titulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        Titulo.Size = new System.Drawing.Size(284, 40);
        Titulo.TabIndex = 3;
        Titulo.Text = "Insira a matricula do Funcionario\r\n";
        Titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        Titulo.Click += label1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(Titulo);
        Controls.Add(listView1);
        Controls.Add(textBox1);
        Controls.Add(Enviar);
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label Titulo;

    private System.Windows.Forms.ListView listView1;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button Enviar;

    #endregion
}