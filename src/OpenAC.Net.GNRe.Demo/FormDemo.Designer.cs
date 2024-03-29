﻿
namespace OpenAC.Net.GNRe.Demo
{
    partial class FormDemo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextTimeout = new System.Windows.Forms.NumericUpDown();
            this.TextDiretorioXmls = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextDiretorioSchemas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckSalvarXmlsSoap = new System.Windows.Forms.CheckBox();
            this.CheckSalvarXmls = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboAmbiente = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextCertificadoCaminho = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextCertificadoSenha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextCertificadoSerial = new System.Windows.Forms.TextBox();
            this.BtnRecepcaoLote = new System.Windows.Forms.Button();
            this.BtnResultadoLote = new System.Windows.Forms.Button();
            this.BtnConfiguracaoUf = new System.Windows.Forms.Button();
            this.TextXmlEnvio = new System.Windows.Forms.TextBox();
            this.TextXmlResposta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextTimeout)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TextTimeout);
            this.groupBox1.Controls.Add(this.TextDiretorioXmls);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TextDiretorioSchemas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CheckSalvarXmlsSoap);
            this.groupBox1.Controls.Add(this.CheckSalvarXmls);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboAmbiente);
            this.groupBox1.Location = new System.Drawing.Point(17, 234);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(503, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações do WebService";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Timeout";
            // 
            // TextTimeout
            // 
            this.TextTimeout.Location = new System.Drawing.Point(300, 75);
            this.TextTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextTimeout.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.TextTimeout.Name = "TextTimeout";
            this.TextTimeout.Size = new System.Drawing.Size(127, 31);
            this.TextTimeout.TabIndex = 10;
            // 
            // TextDiretorioXmls
            // 
            this.TextDiretorioXmls.Location = new System.Drawing.Point(16, 248);
            this.TextDiretorioXmls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextDiretorioXmls.Name = "TextDiretorioXmls";
            this.TextDiretorioXmls.Size = new System.Drawing.Size(465, 31);
            this.TextDiretorioXmls.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Diretório XMLs";
            // 
            // TextDiretorioSchemas
            // 
            this.TextDiretorioSchemas.Location = new System.Drawing.Point(16, 163);
            this.TextDiretorioSchemas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextDiretorioSchemas.Name = "TextDiretorioSchemas";
            this.TextDiretorioSchemas.Size = new System.Drawing.Size(465, 31);
            this.TextDiretorioSchemas.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Diretório Schemas";
            // 
            // CheckSalvarXmlsSoap
            // 
            this.CheckSalvarXmlsSoap.AutoSize = true;
            this.CheckSalvarXmlsSoap.Location = new System.Drawing.Point(212, 289);
            this.CheckSalvarXmlsSoap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckSalvarXmlsSoap.Name = "CheckSalvarXmlsSoap";
            this.CheckSalvarXmlsSoap.Size = new System.Drawing.Size(179, 29);
            this.CheckSalvarXmlsSoap.TabIndex = 5;
            this.CheckSalvarXmlsSoap.Text = "Salvar XMLs Soap";
            this.CheckSalvarXmlsSoap.UseVisualStyleBackColor = true;
            // 
            // CheckSalvarXmls
            // 
            this.CheckSalvarXmls.AutoSize = true;
            this.CheckSalvarXmls.Location = new System.Drawing.Point(19, 289);
            this.CheckSalvarXmls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckSalvarXmls.Name = "CheckSalvarXmls";
            this.CheckSalvarXmls.Size = new System.Drawing.Size(133, 29);
            this.CheckSalvarXmls.TabIndex = 4;
            this.CheckSalvarXmls.Text = "Salvar XMLs";
            this.CheckSalvarXmls.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ambiente";
            // 
            // ComboAmbiente
            // 
            this.ComboAmbiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAmbiente.FormattingEnabled = true;
            this.ComboAmbiente.Location = new System.Drawing.Point(16, 75);
            this.ComboAmbiente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboAmbiente.Name = "ComboAmbiente";
            this.ComboAmbiente.Size = new System.Drawing.Size(268, 33);
            this.ComboAmbiente.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TextCertificadoCaminho);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TextCertificadoSenha);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TextCertificadoSerial);
            this.groupBox2.Location = new System.Drawing.Point(17, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(503, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurações do Certificado";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Caminho Certificado";
            // 
            // TextCertificadoCaminho
            // 
            this.TextCertificadoCaminho.Location = new System.Drawing.Point(19, 148);
            this.TextCertificadoCaminho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextCertificadoCaminho.Name = "TextCertificadoCaminho";
            this.TextCertificadoCaminho.Size = new System.Drawing.Size(450, 31);
            this.TextCertificadoCaminho.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Senha";
            // 
            // TextCertificadoSenha
            // 
            this.TextCertificadoSenha.Location = new System.Drawing.Point(251, 72);
            this.TextCertificadoSenha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextCertificadoSenha.Name = "TextCertificadoSenha";
            this.TextCertificadoSenha.Size = new System.Drawing.Size(217, 31);
            this.TextCertificadoSenha.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Serial";
            // 
            // TextCertificadoSerial
            // 
            this.TextCertificadoSerial.Location = new System.Drawing.Point(19, 72);
            this.TextCertificadoSerial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextCertificadoSerial.Name = "TextCertificadoSerial";
            this.TextCertificadoSerial.Size = new System.Drawing.Size(217, 31);
            this.TextCertificadoSerial.TabIndex = 8;
            // 
            // BtnRecepcaoLote
            // 
            this.BtnRecepcaoLote.Location = new System.Drawing.Point(540, 35);
            this.BtnRecepcaoLote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRecepcaoLote.Name = "BtnRecepcaoLote";
            this.BtnRecepcaoLote.Size = new System.Drawing.Size(167, 50);
            this.BtnRecepcaoLote.TabIndex = 2;
            this.BtnRecepcaoLote.Text = "Recepção Lote";
            this.BtnRecepcaoLote.UseVisualStyleBackColor = true;
            this.BtnRecepcaoLote.Click += new System.EventHandler(this.BtnRecepcaoLote_Click);
            // 
            // BtnResultadoLote
            // 
            this.BtnResultadoLote.Location = new System.Drawing.Point(721, 35);
            this.BtnResultadoLote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnResultadoLote.Name = "BtnResultadoLote";
            this.BtnResultadoLote.Size = new System.Drawing.Size(167, 50);
            this.BtnResultadoLote.TabIndex = 3;
            this.BtnResultadoLote.Text = "Resultado Lote";
            this.BtnResultadoLote.UseVisualStyleBackColor = true;
            this.BtnResultadoLote.Click += new System.EventHandler(this.BtnResultadoLote_Click);
            // 
            // BtnConfiguracaoUf
            // 
            this.BtnConfiguracaoUf.Location = new System.Drawing.Point(903, 35);
            this.BtnConfiguracaoUf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnConfiguracaoUf.Name = "BtnConfiguracaoUf";
            this.BtnConfiguracaoUf.Size = new System.Drawing.Size(167, 50);
            this.BtnConfiguracaoUf.TabIndex = 4;
            this.BtnConfiguracaoUf.Text = "Configuração UF";
            this.BtnConfiguracaoUf.UseVisualStyleBackColor = true;
            this.BtnConfiguracaoUf.Click += new System.EventHandler(this.BtnConfiguracaoUf_Click);
            // 
            // TextXmlEnvio
            // 
            this.TextXmlEnvio.Location = new System.Drawing.Point(540, 127);
            this.TextXmlEnvio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextXmlEnvio.Multiline = true;
            this.TextXmlEnvio.Name = "TextXmlEnvio";
            this.TextXmlEnvio.ReadOnly = true;
            this.TextXmlEnvio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextXmlEnvio.Size = new System.Drawing.Size(428, 549);
            this.TextXmlEnvio.TabIndex = 5;
            // 
            // TextXmlResposta
            // 
            this.TextXmlResposta.Location = new System.Drawing.Point(980, 127);
            this.TextXmlResposta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextXmlResposta.Multiline = true;
            this.TextXmlResposta.Name = "TextXmlResposta";
            this.TextXmlResposta.ReadOnly = true;
            this.TextXmlResposta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextXmlResposta.Size = new System.Drawing.Size(428, 549);
            this.TextXmlResposta.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Xml Envio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(980, 93);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Xml Resposta";
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 693);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TextXmlResposta);
            this.Controls.Add(this.TextXmlEnvio);
            this.Controls.Add(this.BtnConfiguracaoUf);
            this.Controls.Add(this.BtnResultadoLote);
            this.Controls.Add(this.BtnRecepcaoLote);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDemo";
            this.Text = "Demo!";
            this.Load += new System.EventHandler(this.FrmDemo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextTimeout)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboAmbiente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown TextTimeout;
        private System.Windows.Forms.TextBox TextDiretorioXmls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextDiretorioSchemas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckSalvarXmlsSoap;
        private System.Windows.Forms.CheckBox CheckSalvarXmls;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextCertificadoSerial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextCertificadoSenha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextCertificadoCaminho;
        private System.Windows.Forms.Button BtnRecepcaoLote;
        private System.Windows.Forms.Button BtnResultadoLote;
        private System.Windows.Forms.Button BtnConfiguracaoUf;
        private System.Windows.Forms.TextBox TextXmlEnvio;
        private System.Windows.Forms.TextBox TextXmlResposta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}