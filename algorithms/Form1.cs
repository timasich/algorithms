using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "%ОЗУ и %ЦПУ";
        }
        Substitution Q = new Substitution { };
        Substitution T = new Substitution { };
        SubstitutionInv TInv = new SubstitutionInv { };
        SubstitutionInv QInv = new SubstitutionInv { };

        //Первая часть
        private void textBoxLR11_KeyPress(object sender, KeyPressEventArgs e)
        {                  //Ограничение ввода: только цифры 1-8, и удаление
            char number = e.KeyChar;
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonLR11_Click(object sender, EventArgs e)
        {               //Преобразование из строк в структуру Q и запись в таблицу
            string str1 = textBoxLR11.Text;
            if (str1 == "" || str1.Length==1) { labelLR11.Text = "wwdjkbngkj"; return; }
            if (str1.Length + textBoxLR12.Text.Length + textBoxLR13.Text.Length > 8) { labelLR11.Text = "GGGh"; return; }
            Q.resetSubst();                     //Обнуляем Q
            setQwithTextBox(str1);              //Запись из строк в Q
            setQwithTextBox(textBoxLR12.Text);
            setQwithTextBox(textBoxLR13.Text);
            Q.fillGrid(dataGridViewLR12);       //Запись из Q в таблицу
        }

        private void setQwithTextBox(string str)        //Преобразование строки в символы ASCII и сохранение в массив
        {
            int[] stroke = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
                stroke[i] = Convert.ToInt32(str[i]) - 48;       //Создание массива цифр строки
            for (int i = 0; i < str.Length-1; i++)                //Заполнение массива цифр в соответствующие элементы Q
                Q.setSubst(stroke[i] - 1, stroke[i + 1]);
            Q.setSubst(stroke[str.Length-1] - 1, stroke[0]);
        }

        //Вторая часть
        private void buttonLR12_Click(object sender, EventArgs e)
        {
            T.resetSubst();
            for (int i = 0; i < 8; i++)
            {
                if (dataGridViewLR11.Rows[0].Cells[i].Value == null)
                    T.setSubst(i, i + 1);
                else
                    T.setSubst(i, Convert.ToInt32(dataGridViewLR11.Rows[0].Cells[i].Value));
            }
            textBoxLR14.Text = T.multilpyView();
        }

        private void buttonLR13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                dataGridViewLR13.Rows[0].Cells[T.getByIndex(i)-1].Value = i + 1;
                dataGridViewLR14.Rows[0].Cells[i].Value = Q.getByIndex(T.getByIndex(i) - 1);
                dataGridViewLR15.Rows[0].Cells[i].Value = T.getByIndex(Q.getByIndex(i) - 1);
            }

        }

        //Третья часть
        private void buttonLR14_Click(object sender, EventArgs e)
        {
           if (dataGridViewLR16.Rows.Count == 1)
                dataGridViewLR16.Rows.Add();
           for (int i = 0; i < 8; i++)          //Заполнение структуры 
                TInv.setSubst(i, Convert.ToInt32(dataGridViewLR16.Rows[0].Cells[i].Value));
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                int j = TInv.countOfInversions(i);
                dataGridViewLR16.Rows[1].Cells[i].Value = j;
                sum += j;
            }
            labelLR133.Text += " Инверсий всего: " + sum;
            if (sum % 2 == 1)
                labelLR133.Text += " Подстановка нечётная";
            else
                labelLR133.Text += " Подстановка чётная";
            TInv.fillGrid(dataGridViewLR17);
        }

        private void buttonLR15_Click(object sender, EventArgs e)
        {
            QInv.setInvZero();
            for (int i = 0; i < 8; i++)
                QInv.getByCount(i + 1, Convert.ToInt32(dataGridViewLR18.Rows[0].Cells[i].Value));
            QInv.fillGrid(dataGridViewLR19);
        }
    }
}
