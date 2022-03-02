using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace matrix_calc
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int matrixwidth = 22+4;
        int matrixrez = 35;
        int matrixrank = 2;
        int maxrand = 100;
        int minrand = -99;

        public Form1()
        {
            InitializeComponent();
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
            int rows = matrixgrid1.RowCount;
            int columns = matrixgrid2.ColumnCount;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    for (int inner = 0; inner < 2; inner++)
                    {
                        matrixresult[row, col].Value = Convert.ToInt32(matrixgrid1[row, inner].Value) * Convert.ToInt32(matrixgrid2[inner, col].Value);
                    }
                }
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

        private void button5_Click(object sender, EventArgs e)
        {

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
    }
}
