using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;


namespace matrix_calc
{

    
    public partial class Form1 : Form
    {
        Random random = new Random();
        int matrixwidth = 22 + 4;
        int matrixrez = 35;
        int matrixrank = 2;
        int maxrand = 25;
        int minrand = 0;

        public Form1()
        {
            InitializeComponent();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        public void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixgrid1.ColumnCount; i++)
            {
                for (int j = 0; j < matrixgrid1.RowCount; j++)
                {
                    matrixgrid1[i, j].Value = random.Next(minrand, maxrand);
                }
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixgrid1.RowCount; i++)
            {
                for (int j = 0; j < matrixgrid1.ColumnCount; j++)
                {
                    matrixresult.Columns[j].Width = matrixrez;
                    matrixresult[i, j].Value = Convert.ToInt32(matrixgrid1[i, j].Value) + Convert.ToInt32(matrixgrid2[i, j].Value);
                }
            }

        }

        private void minus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixgrid1.RowCount; i++)
            {
                for (int j = 0; j < matrixgrid1.ColumnCount; j++)
                {
                    matrixresult.Columns[j].Width = matrixrez;
                    matrixresult[i, j].Value = Convert.ToInt32(matrixgrid1[i, j].Value) - Convert.ToInt32(matrixgrid2[i, j].Value);
                }
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            int colom1 = 0;
            int row2 = 0;
            for (int i = 0,j = 0; i < trackBar1.Value; i++,j++)
            {
                if (matrixgrid1[i,j].Value!= null)
                {
                    colom1++;
                }
                if (matrixgrid2[i,j].Value != null)
                {
                    row2++;
                }
            }
            if (colom1==row2)
            {
                int[,] mass = new int[trackBar1.Value, trackBar1.Value];
                int[,] mass2 = new int[trackBar1.Value, trackBar1.Value];
                int[,] mass3 = new int[trackBar1.Value, trackBar1.Value];
                for (int i = 0; i < trackBar1.Value; i++)
                {
                    for (int j = 0; j < trackBar1.Value; j++)
                    {
                        mass[i, j] = Convert.ToInt32(matrixgrid1[j,i].Value); 
                        mass2[i, j] = Convert.ToInt32(matrixgrid2[j,i].Value);
                    }
                }
                for (int i = 0; i < trackBar1.Value; i++)
                {
                    for (int j = 0; j < trackBar1.Value; j++)
                    {
                        mass3[i, j] = 0;
                        for (int k = 0; k < trackBar1.Value; k++)
                        {
                            mass3[i, j] += mass[i, k] * mass2[k, j];
                        }
                        matrixresult[j,i].Value = mass3[i, j];
                        if (Convert.ToInt32(matrixresult[j, i].Value) == 0) { matrixresult[j, i].Value = null; }
                    }
                }
            }
            else
            {
                MessageBox.Show("Количество столбцов первой матрицы должно равняться количеству строк второй.","Ошибка");
            }
            
        }

        private void load_Click(object sender, EventArgs e)
        {
            matrixresult.RowCount = matrixrank;
            matrixresult.ColumnCount = matrixrank;
            matrixgrid1.ColumnHeadersVisible = false;
            matrixgrid1.RowHeadersVisible = false;
            matrixgrid2.ColumnHeadersVisible = false;
            matrixgrid2.RowHeadersVisible = false;
            matrixresult.ColumnHeadersVisible = false;
            matrixresult.RowHeadersVisible = false;
            matrixgrid1.RowCount = matrixrank;
            matrixgrid1.ColumnCount = matrixrank;
            matrixgrid2.RowCount = matrixrank;
            matrixgrid2.ColumnCount = matrixrank;
            for (int i = 0; i < matrixgrid1.RowCount; i++)
            {
                for (int j = 0; j < matrixgrid1.ColumnCount; j++)
                {
                    matrixgrid1.Columns[j].Width = matrixwidth;
                    matrixgrid2.Columns[j].Width = matrixwidth;
                    matrixgrid1[i, j].Value = random.Next(100);
                    matrixgrid2[i, j].Value = random.Next(100);
                    matrixresult.Columns[j].Width = matrixrez;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrixgrid2.ColumnCount; i++)
            {
                for (int j = 0; j < matrixgrid2.RowCount; j++)
                {
                    matrixgrid2[i, j].Value = random.Next(minrand, maxrand);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            matrixgrid1.RowCount = trackBar1.Value;
            matrixgrid1.ColumnCount = trackBar1.Value;
            matrixgrid2.RowCount = trackBar1.Value;
            matrixgrid2.ColumnCount = trackBar1.Value;
            matrixresult.RowCount = trackBar1.Value;
            matrixresult.ColumnCount = trackBar1.Value;
            for (int i = 0; i < matrixgrid1.RowCount; i++)
            {
                for (int j = 0; j < matrixgrid1.ColumnCount; j++)
                {
                    matrixgrid1.Columns[j].Width = matrixwidth;
                    matrixgrid2.Columns[j].Width = matrixwidth;
                    matrixresult.Columns[j].Width = matrixrez;
                }
            }
        }

        void rankmat()
        {
            matrixgrid1.RowCount = trackBar1.Value;
            matrixgrid1.ColumnCount = trackBar1.Value;
            matrixgrid2.RowCount = trackBar1.Value;
            matrixgrid2.ColumnCount = trackBar1.Value;
            matrixresult.RowCount = trackBar1.Value;
            matrixresult.ColumnCount = trackBar1.Value;
            for (int i = 0; i < matrixgrid1.RowCount; i++)
            {
                for (int j = 0; j < matrixgrid1.ColumnCount; j++)
                {
                    matrixgrid1.Columns[j].Width = matrixwidth;
                    matrixgrid2.Columns[j].Width = matrixwidth;
                    matrixresult.Columns[j].Width = matrixrez;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            string[] fileText = File.ReadAllLines(filename).Take(10).ToArray();

            rankmat();

            for (int i = 0; i < fileText.GetLength(0); i++)
            {
                int[] dataString = fileText[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                //MessageBox.Show(Convert.ToString(dataString.GetLength(0)), Convert.ToString(fileText.GetLength(0)));
                for (int j = 0; j < dataString.GetLength(0); j++)
                {
                    if (fileText.GetLength(0) >= dataString.GetLength(0))
                    {
                        trackBar1.Value = fileText.GetLength(0);
                        rankmat();
                    }
                    else
                    {
                        trackBar1.Value = dataString.GetLength(0);
                        rankmat();
                    }
                    matrixgrid1[j, i].Value = dataString[j];

                }
            }
            for (int i = 0; i < fileText.GetLength(0); i++)
            {
                int[] dataString = fileText[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int k = 0; k < trackBar1.Value; k++)
                {
                    for (int m = 0; m < trackBar1.Value; m++)
                    {
                        if (m >= dataString.GetLength(0) || k >= fileText.GetLength(0))
                        {
                            matrixgrid1[m, k].Value = null;
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            string[] fileText = File.ReadAllLines(filename).Take(10).ToArray();
            
            rankmat();

            for (int i = 0; i < fileText.GetLength(0); i++)
            {
                int[] dataString = fileText[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                //MessageBox.Show(Convert.ToString(dataString.GetLength(0)), Convert.ToString(fileText.GetLength(0)));
                for (int j = 0; j < dataString.GetLength(0); j++)
                {
                    if (fileText.GetLength(0) >= dataString.GetLength(0)){
                        trackBar1.Value = fileText.GetLength(0);
                        rankmat();
                    }
                    else
                    {
                        trackBar1.Value = dataString.GetLength(0);
                        rankmat();
                    }
                    matrixgrid2[j, i].Value = dataString[j];

                }
            }
            for (int i = 0; i < fileText.GetLength(0); i++)
            {
                int[] dataString = fileText[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int k = 0; k < trackBar1.Value; k++){
                    for (int m = 0; m < trackBar1.Value; m++){
                        if (m >= dataString.GetLength(0) || k >= fileText.GetLength(0)) {
                            matrixgrid2[m, k].Value = null; 
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            string[] content = new string[trackBar1.Value];
            string data = "";
            for (int i = 0; i < trackBar1.Value; i++)
            {
                for (int j = 0; j < trackBar1.Value; j++)
                {
                    data = data+Convert.ToString(matrixresult[j, i].Value)+'\t';
                }
                data = data+(Char)13;
            }
            File.WriteAllText(filename, data);
            MessageBox.Show("Файл сохранен");
        }
    }
}

