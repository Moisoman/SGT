using System.ComponentModel;

namespace SGTApp;

partial class AtualizarFuncionario
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
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        SituacaoCampo = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(120, 244);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(27, 74);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(168, 23);
        textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(27, 126);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(168, 23);
        textBox2.TabIndex = 2;
        // 
        // SituacaoCampo
        // 
        SituacaoCampo.FormattingEnabled = true;
        SituacaoCampo.Items.AddRange(new object[] { "A", "I" });
        SituacaoCampo.Location = new System.Drawing.Point(27, 177);
        SituacaoCampo.Name = "SituacaoCampo";
        SituacaoCampo.Size = new System.Drawing.Size(71, 23);
        SituacaoCampo.TabIndex = 3;
        // 
        // AtualizarFuncionario
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(SituacaoCampo);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Text = "AtualizarFuncionario";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.ComboBox SituacaoCampo;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;

    #endregion
}