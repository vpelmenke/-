using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form1 : Form
    {
        public int key = 1;
        public int b2Pressed = 0;
        public List<char> rusALphabet = new List<char> { };
        const int leftRusBorder = 1040;
        const int rightRusBorder = 1072;
        const int leftEngBorder = 65;
        const int rightEngBorder = 91;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Button3_Click(object sender, EventArgs e) // Установка пользовательского значения ключа, по умолчанию = 0
        {
            try
            {
                key = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        private void Button1_Click(object sender, EventArgs e) // Запуск шифрования введенного текста
        {
            textBox2.Text = transfer(textBox1.Text);
            b2Pressed = 0;
        }
        private string transfer(string text) // Механизм шифрования
        {
            string s = "";
            int flag;
            for (int i = 0; i < text.Length; i++)
            {
                flag = 0;
                if (Char.IsNumber(text[i]))
                    s += isNmbr(text, i);
                else if (Char.IsLetter(text[i]))
                {
                    if (char.IsUpper(text[i]))
                        flag = 1;
                    if (Char.ToUpper(text[i]) < 91)
                    {
                        s += isEng(text, i, flag);
                    }
                    else
                    {
                        s += isRus(text, i, flag);
                    }
                }
                else
                    MessageBox.Show("Ошибка ввода!");
            }
            return s;
               
        }

        private void Button2_Click(object sender, EventArgs e) // Механизм дешифрования, можно применить лишь 1 раз на 1 шифр
        {
            if (b2Pressed == 0)
            {
                int k = key;
                key = 0 - key;
                textBox2.Text = transfer(textBox2.Text);
                b2Pressed++;
                key = k;
            }
            else
                MessageBox.Show("Вы уже дешифровали данный код!");
        }
        private string isNmbr(string text, int index) // Для цифр
        {
            string s = "";
            int numKey = key % 10;
            if (text[index] + numKey < (char)58)
                s += (char)(text[index] + numKey);
            else
                s += (char)((char)48 + text[index] + numKey - (char)58);
            return s;
        }
        private string isRus(string text, int i, int flag) // Для русских букв
        {
            string s = "";
            int rusKey = key % 33;
           
            if (Char.ToUpper(text[i]) + rusKey < (char)rightRusBorder)
                s += noOverflow(text, i, flag, rusKey);
            else
            {
                s += Overflow(text, i, flag, leftRusBorder, rightRusBorder, rusKey);
            }
            return s;
        }
        private string isEng(string text, int i, int flag) // Для английских букв
        {
            string s = "";
            int engKey = key % 26;
            if (Char.ToUpper(text[i]) + engKey < (char)rightEngBorder)
                s += noOverflow(text, i, flag, engKey);
            else
            {
                s += Overflow(text, i, flag, leftEngBorder, rightEngBorder, engKey);
            }
            return s;
        }
        private string noOverflow(string text, int index, int flag, int keyCode) // Вызывается, если нет пересечения границ алфавита
        {
            string s = "";
            if (flag == 1)
                s += (char)(Char.ToUpper(text[index]) + keyCode);
            else
                s += (char)(Char.ToLower(text[index]) + keyCode);
            return s;
        }
        private string Overflow(string text, int index, int flag, int leftBorder, int rightBorder, int keyCode) // Вызывается при пересечении границы алфавита
        {
            string s = "";
            if (flag == 1)
                s += (char)((char)leftBorder + Char.ToUpper(text[index]) + keyCode - (char)rightBorder);
            else
                s += (char)((char)leftBorder + Char.ToLower(text[index]) + keyCode - (char)rightBorder);
            return s;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = leftRusBorder; i <= rightRusBorder;)
            {
                if (i == 1045)
                {
                    rusALphabet.Add((char)i);
                    rusALphabet.Add((char)1026); // Буква Ё
                    i++;
                }
                else
                {
                    rusALphabet.Add((char)i);
                    i++;
                }
            }
        }
    }
}
