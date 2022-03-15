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
        Substitution substitution = new Substitution { };

        private void textBoxLR11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonLR11_Click(object sender, EventArgs e)
        {
            string str1 = textBoxLR11.Text;
            if (str1 == "" || str1.Length==1) { labelLR11.Text = "wwdjkbngkj"; return; }
            if (str1.Length + textBoxLR12.Text.Length + textBoxLR13.Text.Length > 8) { labelLR11.Text = "GGGh"; return; }
            string str2 = textBoxLR12.Text;
            string str3 = textBoxLR13.Text;
            int[] stroke = new int[str1.Length];
            for (int i = 0; i < str1.Length; i++)
            {
                stroke[i] = Convert.ToInt32(str1[i]) - 48;
            }
            for (int i = 0; i < str1.Length; i++)
                if(i!= str1.Length-1)
                    substitution.setSubst(true, stroke[i]-1, stroke[i + 1]);
                else
                    substitution.setSubst(true, stroke[i]-1, stroke[0]);


        }
        

        class Substitution
        {
            private int[] Q = { 1, 2, 3, 4, 5, 6, 7, 8 };
            private int[] T = { 1, 2, 3, 4, 5, 6, 7, 8 };


            public void setSubst(bool Q, int i, int number) 
            {
                if (Q)
                    this.Q[i] = number;
                else
                    this.T[i] = number;
            }

            public int getMultiply(bool QT, int number)
            {
                return 0;
            }

            public int getInversion(bool QT, int number)
            {

                return 0;
            }
        }
    }
}
