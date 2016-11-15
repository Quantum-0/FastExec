namespace Fast_Exec
{
    partial class FormEditing
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonApplication = new System.Windows.Forms.RadioButton();
            this.radioButtonFolder = new System.Windows.Forms.RadioButton();
            this.radioButtonLink = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxApplication = new System.Windows.Forms.TextBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(197, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(260, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выполняемая команда:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 64);
            this.textBox3.MaxLength = 1;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кнопка:";
            // 
            // radioButtonApplication
            // 
            this.radioButtonApplication.AutoSize = true;
            this.radioButtonApplication.Checked = true;
            this.radioButtonApplication.Location = new System.Drawing.Point(16, 103);
            this.radioButtonApplication.Name = "radioButtonApplication";
            this.radioButtonApplication.Size = new System.Drawing.Size(84, 17);
            this.radioButtonApplication.TabIndex = 8;
            this.radioButtonApplication.TabStop = true;
            this.radioButtonApplication.Text = "Программа";
            this.radioButtonApplication.UseVisualStyleBackColor = true;
            this.radioButtonApplication.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize = true;
            this.radioButtonFolder.Location = new System.Drawing.Point(16, 126);
            this.radioButtonFolder.Name = "radioButtonFolder";
            this.radioButtonFolder.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFolder.TabIndex = 9;
            this.radioButtonFolder.Text = "Папка";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            this.radioButtonFolder.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButtonLink
            // 
            this.radioButtonLink.AutoSize = true;
            this.radioButtonLink.Location = new System.Drawing.Point(16, 149);
            this.radioButtonLink.Name = "radioButtonLink";
            this.radioButtonLink.Size = new System.Drawing.Size(64, 17);
            this.radioButtonLink.TabIndex = 10;
            this.radioButtonLink.Text = "Ссылка";
            this.radioButtonLink.UseVisualStyleBackColor = true;
            this.radioButtonLink.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Запуск:";
            // 
            // textBoxApplication
            // 
            this.textBoxApplication.Location = new System.Drawing.Point(107, 103);
            this.textBoxApplication.Name = "textBoxApplication";
            this.textBoxApplication.Size = new System.Drawing.Size(100, 20);
            this.textBoxApplication.TabIndex = 12;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(107, 125);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(100, 20);
            this.textBoxFolder.TabIndex = 13;
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(107, 148);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(165, 20);
            this.textBoxLink.TabIndex = 14;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Program";
            this.openFileDialog.Filter = "Приложение|*.exe|BAT - файл|*.bat|CMD - файл|*.cmd|Ярлык|*.lnk|Все файлы|*.*";
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(213, 103);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(59, 20);
            this.buttonChooseFile.TabIndex = 15;
            this.buttonChooseFile.Text = "Выбрать";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Location = new System.Drawing.Point(213, 125);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(59, 20);
            this.buttonChooseFolder.TabIndex = 16;
            this.buttonChooseFolder.Text = "Выбрать";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // FormEditing
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(284, 255);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.buttonChooseFile);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.textBoxApplication);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioButtonLink);
            this.Controls.Add(this.radioButtonFolder);
            this.Controls.Add(this.radioButtonApplication);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditing";
            this.Text = "Редактирование";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonApplication;
        private System.Windows.Forms.RadioButton radioButtonFolder;
        private System.Windows.Forms.RadioButton radioButtonLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxApplication;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.Button buttonChooseFolder;
    }
}