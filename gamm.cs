using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gamma
{
    public partial class Form1 : Form
    {
        public List<char> rusAlphabet = new List<char> { };
        public List<char> engAlphabet = new List<char> { };
        const int leftRusBorder = 1040;
        const int rightRusBorder = 1072;
        const int leftEngBorder = 65;
        const int rightEngBorder = 91;
        private int langType = 0; // 0 - рус 1 - англ
        private string rusKey = "шифрование";
        private string engKey = "encryption";
        double rusIndex = 0.0553;
        double engIndex = 0.0644;
        public Form1()
        {
            InitializeComponent();
        }

        private void РусскийToolStripMenuItem_Click(object sender, EventArgs e) // Рус
        {
            langType = 0;
            textBox3.Text = rusKey;
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e) // Англ
        {
            langType = 1;
            textBox3.Text = engKey;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string result = "";
            switch (langType)
            {
                case 0:
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsUpper(text[i]))
                            result += char.ToUpper(rusRes(text[i], char.ToUpper(rusKey[i % rusKey.Length])));
                        else 
                            result += char.ToLower(rusRes(text[i], char.ToUpper(rusKey[i % rusKey.Length])));
                    }
                    break;
                case 1:
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsUpper(text[i]))
                            result += char.ToUpper(engRes(text[i], char.ToUpper(engKey[i % engKey.Length])));
                        else
                            result += char.ToLower(engRes(text[i], char.ToUpper(engKey[i % engKey.Length])));

                    }
                    break;
            }
            textBox2.Text = result;
        }
        private char rusRes(char text, char keyChar)
        {
            char s = ' ';
            s += rusAlphabet[(rusAlphabet.IndexOf(char.ToUpper(text), 0) + rusAlphabet.IndexOf(keyChar, 0)) % 33];
            return s;
        }
        private char engRes(char text, char keyChar)
        {
            char s = ' ';
            s += engAlphabet[(engAlphabet.IndexOf(char.ToUpper(text), 0) + engAlphabet.IndexOf(keyChar, 0)) % 26];
            return s;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            switch (langType)
            {
                case 0:
                    rusKey = textBox3.Text;
                    break;
                case 1:
                    engKey = textBox3.Text;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = leftRusBorder; i < rightRusBorder;)
            {
                if (i == 1045)
                {
                    rusAlphabet.Add((char)i);
                    rusAlphabet.Add((char)1025); // Буква Ё
                    i++;
                }
                else
                {
                    rusAlphabet.Add((char)i);
                    i++;
                }
            }
            for (int i = leftEngBorder; i < rightEngBorder; i++)
            {
                engAlphabet.Add((char)i);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
