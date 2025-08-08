using System.ComponentModel;

namespace SGTApp;

partial class MainForm
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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(159, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(461, 33);
        label1.TabIndex = 0;
        label1.Text = "Bem vindo ao Sistema de Gerenciamento de Tickets";
        label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(12, 87);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(306, 31);
        label2.TabIndex = 1;
        label2.Text = "Escolha qual ação deseja realizar";
        label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(12, 189);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(73, 39);
        button1.TabIndex = 2;
        button1.Text = "Continuar";
        button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(12, 299);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(73, 39);
        button2.TabIndex = 3;
        button2.Text = "Continuar";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(128, 189);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(73, 39);
        button3.TabIndex = 4;
        button3.Text = "Continuar";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(128, 299);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(73, 39);
        button4.TabIndex = 5;
        button4.Text = "Continuar";
        button4.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(12, 148);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(73, 38);
        label3.TabIndex = 6;
        label3.Text = "Cadastrar Funcionario";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(128, 148);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(75, 39);
        label4.TabIndex = 7;
        label4.Text = "Atualizar Funcionario";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(12, 262);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(73, 34);
        label5.TabIndex = 8;
        label5.Text = "Cadastrar Ticket";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(128, 257);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(75, 39);
        label6.TabIndex = 9;
        label6.Text = "Atualizar Ticket";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(button4);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "MainForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}