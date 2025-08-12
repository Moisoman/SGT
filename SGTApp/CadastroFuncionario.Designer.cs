using System.ComponentModel;

namespace SGTApp;

partial class CadastroFuncionario
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
        nomeBox = new System.Windows.Forms.TextBox();
        cpfBox = new System.Windows.Forms.TextBox();
        nomeLabel = new System.Windows.Forms.Label();
        cpfFuncionario = new System.Windows.Forms.Label();
        sendButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // nomeBox
        // 
        nomeBox.Location = new System.Drawing.Point(12, 53);
        nomeBox.Name = "nomeBox";
        nomeBox.Size = new System.Drawing.Size(143, 23);
        nomeBox.TabIndex = 0;
        // 
        // cpfBox
        // 
        cpfBox.Location = new System.Drawing.Point(12, 123);
        cpfBox.Name = "cpfBox";
        cpfBox.Size = new System.Drawing.Size(143, 23);
        cpfBox.TabIndex = 1;
        // 
        // nomeLabel
        // 
        nomeLabel.Location = new System.Drawing.Point(12, 27);
        nomeLabel.Name = "nomeLabel";
        nomeLabel.Size = new System.Drawing.Size(143, 23);
        nomeLabel.TabIndex = 2;
        nomeLabel.Text = "Nome do Funcionario";
        // 
        // cpfFuncionario
        // 
        cpfFuncionario.Location = new System.Drawing.Point(12, 97);
        cpfFuncionario.Name = "cpfFuncionario";
        cpfFuncionario.Size = new System.Drawing.Size(143, 23);
        cpfFuncionario.TabIndex = 3;
        cpfFuncionario.Text = "CPF";
        // 
        // sendButton
        // 
        sendButton.Location = new System.Drawing.Point(80, 180);
        sendButton.Name = "sendButton";
        sendButton.Size = new System.Drawing.Size(75, 23);
        sendButton.TabIndex = 4;
        sendButton.Text = "Enviar Fomulário";
        sendButton.UseVisualStyleBackColor = true;
        sendButton.Click += sendButton_Click;
        // 
        // CadastroFuncionario
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(sendButton);
        Controls.Add(cpfFuncionario);
        Controls.Add(nomeLabel);
        Controls.Add(cpfBox);
        Controls.Add(nomeBox);
        Text = "CadastroFuncionario";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button sendButton;

    private System.Windows.Forms.TextBox nomeBox;
    private System.Windows.Forms.TextBox cpfBox;
    private System.Windows.Forms.Label nomeLabel;
    private System.Windows.Forms.Label cpfFuncionario;

    #endregion
}