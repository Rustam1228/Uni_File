namespace Uni_File
{
    partial class FormUniFile
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
            ButtonExtractor = new Button();
            ButtonSlitter = new Button();
            ButtonExit = new Button();
            textBoxFile = new TextBox();
            textBoxFolder = new TextBox();
            ListBoxKeyWord = new ListBox();
            ButtonTextPath = new Button();
            ButtonTextNewFolder = new Button();
            CheckBoxAllKeyWord = new CheckBox();
            CheckBoxIndexOf = new CheckBox();
            ButtonAddKeyWord = new Button();
            TextNewFolder = new Label();
            TextKeyWords = new Label();
            TextPathFile = new Label();
            ButtonDeliteKeyWord = new Button();
            SuspendLayout();
            // 
            // ButtonExtractor
            // 
            ButtonExtractor.Location = new Point(30, 359);
            ButtonExtractor.Name = "ButtonExtractor";
            ButtonExtractor.Size = new Size(178, 43);
            ButtonExtractor.TabIndex = 0;
            ButtonExtractor.Text = "Сохранить страницы";
            ButtonExtractor.UseVisualStyleBackColor = true;
            ButtonExtractor.Click += ButtonExtractorClick;
            // 
            // ButtonSlitter
            // 
            ButtonSlitter.Location = new Point(310, 359);
            ButtonSlitter.Name = "ButtonSlitter";
            ButtonSlitter.Size = new Size(180, 43);
            ButtonSlitter.TabIndex = 1;
            ButtonSlitter.Text = "Разделить фаил";
            ButtonSlitter.UseVisualStyleBackColor = true;
            ButtonSlitter.Click += ButtonSlitterClick;
            // 
            // ButtonExit
            // 
            ButtonExit.Location = new Point(605, 359);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(165, 43);
            ButtonExit.TabIndex = 2;
            ButtonExit.Text = "Закрыть";
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += ButtonExitClick;
            // 
            // textBoxFile
            // 
            textBoxFile.Location = new Point(30, 52);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(564, 27);
            textBoxFile.TabIndex = 3;
            // 
            // textBoxFolder
            // 
            textBoxFolder.Location = new Point(30, 131);
            textBoxFolder.Name = "textBoxFolder";
            textBoxFolder.Size = new Size(564, 27);
            textBoxFolder.TabIndex = 4;
            // 
            // ListBoxKeyWord
            // 
            ListBoxKeyWord.FormattingEnabled = true;
            ListBoxKeyWord.Location = new Point(30, 215);
            ListBoxKeyWord.Name = "ListBoxKeyWord";
            ListBoxKeyWord.RightToLeft = RightToLeft.No;
            ListBoxKeyWord.Size = new Size(274, 84);
            ListBoxKeyWord.TabIndex = 6;
          
            // 
            // ButtonTextPath
            // 
            ButtonTextPath.Location = new Point(641, 52);
            ButtonTextPath.Name = "ButtonTextPath";
            ButtonTextPath.Size = new Size(147, 32);
            ButtonTextPath.TabIndex = 7;
            ButtonTextPath.Text = "Выбрать Фаил";
            ButtonTextPath.UseVisualStyleBackColor = true;
            ButtonTextPath.Click += button4_Click;
            // 
            // ButtonTextNewFolder
            // 
            ButtonTextNewFolder.Location = new Point(641, 129);
            ButtonTextNewFolder.Name = "ButtonTextNewFolder";
            ButtonTextNewFolder.Size = new Size(147, 29);
            ButtonTextNewFolder.TabIndex = 8;
            ButtonTextNewFolder.Text = "Выбрать Папку";
            ButtonTextNewFolder.UseVisualStyleBackColor = true;
            ButtonTextNewFolder.Click += button5_Click;
            // 
            // CheckBoxAllKeyWord
            // 
            CheckBoxAllKeyWord.AutoSize = true;
            CheckBoxAllKeyWord.Location = new Point(310, 232);
            CheckBoxAllKeyWord.Name = "CheckBoxAllKeyWord";
            CheckBoxAllKeyWord.Size = new Size(264, 24);
            CheckBoxAllKeyWord.TabIndex = 9;
            CheckBoxAllKeyWord.Text = "Хотя бы одно слово на страницы";
            CheckBoxAllKeyWord.UseVisualStyleBackColor = true;
            CheckBoxAllKeyWord.CheckedChanged += CheckBoxAllKeyWord_CheckedChanged;
            // 
            // CheckBoxIndexOf
            // 
            CheckBoxIndexOf.AutoSize = true;
            CheckBoxIndexOf.Location = new Point(310, 282);
            CheckBoxIndexOf.Name = "CheckBoxIndexOf";
            CheckBoxIndexOf.Size = new Size(211, 24);
            CheckBoxIndexOf.TabIndex = 10;
            CheckBoxIndexOf.Text = "Не игнорировать регистр";
            CheckBoxIndexOf.UseVisualStyleBackColor = true;
            CheckBoxIndexOf.CheckedChanged += CheckBoxIndexOf_CheckedChanged;
            // 
            // ButtonAddKeyWord
            // 
            ButtonAddKeyWord.Location = new Point(641, 215);
            ButtonAddKeyWord.Name = "ButtonAddKeyWord";
            ButtonAddKeyWord.Size = new Size(147, 29);
            ButtonAddKeyWord.TabIndex = 11;
            ButtonAddKeyWord.Text = "Добавить слова";
            ButtonAddKeyWord.UseVisualStyleBackColor = true;
            ButtonAddKeyWord.Click += ButtonAddKeyWordClick;
            // 
            // TextNewFolder
            // 
            TextNewFolder.AutoSize = true;
            TextNewFolder.Location = new Point(30, 97);
            TextNewFolder.Name = "TextNewFolder";
            TextNewFolder.Size = new Size(332, 20);
            TextNewFolder.TabIndex = 12;
            TextNewFolder.Text = "Укажите полный путь к папки для сохранения";
            TextNewFolder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextKeyWords
            // 
            TextKeyWords.AutoSize = true;
            TextKeyWords.Location = new Point(30, 173);
            TextKeyWords.Name = "TextKeyWords";
            TextKeyWords.Size = new Size(307, 20);
            TextKeyWords.TabIndex = 13;
            TextKeyWords.Text = "Укажите ключивые слова для фильтрации ";
            TextKeyWords.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextPathFile
            // 
            TextPathFile.AutoSize = true;
            TextPathFile.Location = new Point(30, 18);
            TextPathFile.Name = "TextPathFile";
            TextPathFile.Size = new Size(217, 20);
            TextPathFile.TabIndex = 14;
            TextPathFile.Text = "Укажите полный путь к файлу";
            TextPathFile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonDeliteKeyWord
            // 
            ButtonDeliteKeyWord.Location = new Point(641, 277);
            ButtonDeliteKeyWord.Name = "ButtonDeliteKeyWord";
            ButtonDeliteKeyWord.Size = new Size(147, 29);
            ButtonDeliteKeyWord.TabIndex = 15;
            ButtonDeliteKeyWord.Text = "Удалить слова";
            ButtonDeliteKeyWord.UseVisualStyleBackColor = true;
            ButtonDeliteKeyWord.Click += ButtonDeliteKeyWordClick;
            // 
            // FormUniFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonDeliteKeyWord);
            Controls.Add(TextPathFile);
            Controls.Add(TextKeyWords);
            Controls.Add(TextNewFolder);
            Controls.Add(ButtonAddKeyWord);
            Controls.Add(CheckBoxIndexOf);
            Controls.Add(CheckBoxAllKeyWord);
            Controls.Add(ButtonTextNewFolder);
            Controls.Add(ButtonTextPath);
            Controls.Add(ListBoxKeyWord);
            Controls.Add(textBoxFolder);
            Controls.Add(textBoxFile);
            Controls.Add(ButtonExit);
            Controls.Add(ButtonSlitter);
            Controls.Add(ButtonExtractor);
            Name = "FormUniFile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonExtractor;
        private Button ButtonSlitter;
        private Button ButtonExit;
        private TextBox textBoxFile;
        private TextBox textBoxFolder;
        private ListBox ListBoxKeyWord;
        private Button ButtonTextPath;
        private Button ButtonTextNewFolder;
        private CheckBox CheckBoxAllKeyWord;
        private CheckBox CheckBoxIndexOf;
        private Button ButtonAddKeyWord;
        private Label TextNewFolder;
        private Label TextKeyWords;
        private Label TextPathFile;
        private Button ButtonDeliteKeyWord;
    }
}
