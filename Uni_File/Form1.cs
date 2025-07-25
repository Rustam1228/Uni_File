using Microsoft.VisualBasic;
using Uni_File.Core.Abstracts.IExtractor;
using Uni_File.Core.Abstracts.ISlitter;
using Uni_File.Core.Files_PDF;

namespace Uni_File
{
    public partial class FormUniFile : Form
    {
        public FormUniFile()
        {
            InitializeComponent();
        }
        // сохраняет путь файла 

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Text files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFile.Text = openFileDialog.FileName;
                }
            }

        }
        // сохраняет путь для папки для сохранениями
        private void button5_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = folderDialog.SelectedPath;
                }
            }

        }

        // для сохранение листов
        private void ButtonExtractorClick(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("Не существует файла по данному пути ");
                return;
            }
            if (!Directory.Exists(textBoxFolder.Text))
            {
                MessageBox.Show("Не существует папки для сохранения по данному пути ");
                return;
            }
            if (ListBoxKeyWord.Items.Count == 0)
            {
                MessageBox.Show("Введите слова для проверки");
                return;
            }
            IExtractor extractor = new PdfExtractor();

            extractor.Extract(textBoxFile.Text, textBoxFolder.Text,
                CheckBoxAllKeyWord.Checked, CheckBoxIndexOf.Checked, ListBoxKeyWord.Items.Cast<string>().ToArray());

            MessageBox.Show("Операция выполнена");
        }

        // Для разбивания файла на отдельные части  
        private void ButtonSlitterClick(object sender, EventArgs e)
        {

            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("Не существует файла по данному пути ");
                return;
            }
            if (!Directory.Exists(textBoxFolder.Text))
            {
                MessageBox.Show("Не существует папки для сохранения по данному пути ");
                return;
            }
            if (ListBoxKeyWord.Items.Count == 0)
            {
                MessageBox.Show("Введите слова для проверки");
                return;
            }
            ISlitter slitter = new PdfSlitter();

            slitter.Slitter(textBoxFile.Text, textBoxFolder.Text,
                CheckBoxAllKeyWord.Checked, CheckBoxIndexOf.Checked, ListBoxKeyWord.Items.Cast<string>().ToArray());

            MessageBox.Show("Операция выполнена");
        }
        // Закрывает окно
        private void ButtonExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //вносить ключевые слова
        private void ButtonAddKeyWordClick(object sender, EventArgs e)
        {
            string newKeyWord = Interaction.InputBox("Добавить слово");
            if (string.IsNullOrEmpty(newKeyWord))
            {
                MessageBox.Show("Вы не ввели слово");
                return;
            }
            ListBoxKeyWord.Items.Add(newKeyWord);
        }

        // удаляет ключевые слова 
        private void ButtonDeliteKeyWordClick(object sender, EventArgs e)
        {
            if(ListBoxKeyWord.SelectedItem == null)
            {
                MessageBox.Show("Выберите слова для удаление");
                return;
            }
            DialogResult result = MessageBox.Show(
                  "Вы уверены, что хотите удалить этот слово?",
                  "Подтверждение удаления",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            // Если пользователь нажал "Да", удаляем элемент
            if (result == DialogResult.Yes)
            {
                ListBoxKeyWord.Items.Remove(ListBoxKeyWord.SelectedItem);
            }

        }
        
        private void CheckBoxAllKeyWord_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAllKeyWord.Text == "Хотя бы одно слово на страницы")
            {
                CheckBoxAllKeyWord.Text = "Все слова должны быть на страницы";
            }
            else
            {
                CheckBoxAllKeyWord.Text = "Хотя бы одно слово на страницы";
            }
        }

        private void CheckBoxIndexOf_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxIndexOf.Text == "Не игнорировать регистр")
            {
                CheckBoxIndexOf.Text = "Игнорировать регистр";
            }
            else
            {
                CheckBoxIndexOf.Text = "Не игнорировать регистр";
            }
        }

        
    }
}
  


