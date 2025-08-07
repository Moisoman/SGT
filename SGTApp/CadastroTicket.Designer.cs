using System.ComponentModel;

namespace SGTApp;

partial class CadastroTicket
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        textBox1 = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(80, 85);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(80, 23);
        textBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(80, 138);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(75, 23);
        button1.TabIndex = 1;
        button1.Text = "Enviar";
        button1.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(147, 19);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(308, 41);
        label1.TabIndex = 2;
        label1.Text = "Formulário de Cadastro de Ticket";
        // 
        // CadastroTicket
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(textBox1);
        Text = "CadastroTicket";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;

    #endregion
}