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
        // ��������� ���� ����� 

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
        // ��������� ���� ��� ����� ��� ������������
        private void button5_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "�������� �����";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = folderDialog.SelectedPath;
                }
            }

        }

        // ��� ���������� ������
        private void ButtonExtractorClick(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("�� ���������� ����� �� ������� ���� ");
                return;
            }
            if (!Directory.Exists(textBoxFolder.Text))
            {
                MessageBox.Show("�� ���������� ����� ��� ���������� �� ������� ���� ");
                return;
            }
            if (ListBoxKeyWord.Items.Count == 0)
            {
                MessageBox.Show("������� ����� ��� ��������");
                return;
            }
            IExtractor extractor = new PdfExtractor();

            extractor.Extract(textBoxFile.Text, textBoxFolder.Text,
                CheckBoxAllKeyWord.Checked, CheckBoxIndexOf.Checked, ListBoxKeyWord.Items.Cast<string>().ToArray());

            MessageBox.Show("�������� ���������");
        }

        // ��� ���������� ����� �� ��������� �����  
        private void ButtonSlitterClick(object sender, EventArgs e)
        {

            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("�� ���������� ����� �� ������� ���� ");
                return;
            }
            if (!Directory.Exists(textBoxFolder.Text))
            {
                MessageBox.Show("�� ���������� ����� ��� ���������� �� ������� ���� ");
                return;
            }
            if (ListBoxKeyWord.Items.Count == 0)
            {
                MessageBox.Show("������� ����� ��� ��������");
                return;
            }
            ISlitter slitter = new PdfSlitter();

            slitter.Slitter(textBoxFile.Text, textBoxFolder.Text,
                CheckBoxAllKeyWord.Checked, CheckBoxIndexOf.Checked, ListBoxKeyWord.Items.Cast<string>().ToArray());

            MessageBox.Show("�������� ���������");
        }
        // ��������� ����
        private void ButtonExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //������� �������� �����
        private void ButtonAddKeyWordClick(object sender, EventArgs e)
        {
            string newKeyWord = Interaction.InputBox("�������� �����");
            if (string.IsNullOrEmpty(newKeyWord))
            {
                MessageBox.Show("�� �� ����� �����");
                return;
            }
            ListBoxKeyWord.Items.Add(newKeyWord);
        }

        // ������� �������� ����� 
        private void ButtonDeliteKeyWordClick(object sender, EventArgs e)
        {
            if(ListBoxKeyWord.SelectedItem == null)
            {
                MessageBox.Show("�������� ����� ��� ��������");
                return;
            }
            DialogResult result = MessageBox.Show(
                  "�� �������, ��� ������ ������� ���� �����?",
                  "������������� ��������",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question);

            // ���� ������������ ����� "��", ������� �������
            if (result == DialogResult.Yes)
            {
                ListBoxKeyWord.Items.Remove(ListBoxKeyWord.SelectedItem);
            }

        }
        
        private void CheckBoxAllKeyWord_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAllKeyWord.Text == "���� �� ���� ����� �� ��������")
            {
                CheckBoxAllKeyWord.Text = "��� ����� ������ ���� �� ��������";
            }
            else
            {
                CheckBoxAllKeyWord.Text = "���� �� ���� ����� �� ��������";
            }
        }

        private void CheckBoxIndexOf_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxIndexOf.Text == "�� ������������ �������")
            {
                CheckBoxIndexOf.Text = "������������ �������";
            }
            else
            {
                CheckBoxIndexOf.Text = "�� ������������ �������";
            }
        }

        
    }
}
  


