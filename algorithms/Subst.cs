using System.Windows.Forms;

namespace algorithms
{
    public partial class Form1
    {
        class Subst
        {
            protected int[] subst = { 1, 2, 3, 4, 5, 6, 7, 8 };


            public void setSubst(int i, int number) 
            {
                 this.subst[i] = number;
            }

            public void resetSubst()
            {
                this.subst = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            }

            public int getByIndex(int n)
            {
                return this.subst[n];
            }

        }

        class Substitution : Subst
        {
            public string multilpyView()
            {
                string str = "";
                int j;
                bool[] used = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    if (this.subst[i] == i + 1 || used[i] == true)
                        continue;
                    str += "(";
                    str += (i + 1);
                    str += this.subst[i];
                    j = this.subst[i] - 1;
                    used[j] = true;
                    while (this.subst[j] - 1 != i)
                    {
                        used[this.subst[j] - 1] = true;
                        str += this.subst[j];
                        j = this.subst[j] - 1;
                    }
                    str += ")";
                }


                return str;
            }

            public void fillGrid(DataGridView dataGrid)
            {
                for (int i = 0; i < 8; i++)
                    dataGrid.Rows[0].Cells[i].Value = subst[i];
            }
        }

        class SubstitutionInv : Subst
        {
            private int[] substInv = new int[8];
            public int countOfInversions(int i)
            {
                int k = 0;
                int t = 0;
                //Расчёт количества инверсий
                for (int j = i+1; j < 8; j++)
                    if (subst[i] > subst[j])
                        k++;
                //Расчёт таблицы инверсий
                for (int j = i - 1; j >= 0; j--)
                    if (subst[i] < subst[j])
                        t++;
                this.substInv[subst[i] - 1] = t;
                return k;
            }

            public void setInvZero()
            {
                for (int i = 0; i < 8; i++)
                    substInv[i] = 0;
            }

            public void getByCount(int i, int j)
            {
                if (substInv[j] == 0)
                    substInv[j] = i;
                else
                {
                    do
                        j++;
                    while (substInv[j] != 0);
                    substInv[j] = i;
                }
            }

            public void fillGrid(DataGridView dataGridView)
            {
                for (int i = 0; i < 8; i++)
                    dataGridView.Rows[0].Cells[i].Value = substInv[i];
            }
        }
    }
}
