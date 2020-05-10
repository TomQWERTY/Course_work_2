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

namespace CourseWork2
{
    public partial class Form1 : Form
    {
        Automaton automaton;
        DLoadAut load;

        public Form1()
        {
            InitializeComponent();
            automaton = new TRecognizer();
            Create(Convert.ToInt32(numOfSymbolsTextBox.Text), Convert.ToInt32(numOfStatesTextBox.Text));
            mainTableIn.ForeColor = Color.Silver;
            mainTableIn.EnabledChanged += tableAut1_ForeColorInactive;
            acceptAllBut.Click += accept1_Click;
            acceptAllBut.Click += accept2_Click;
            acceptAllBut.Click += accept3_Click;
            createAutoButton.Click += FirstcreateAutoButton_Click;
            load += FirstLoad;
        }

        private void tableAut1_ForeColorInactive(object sender, EventArgs e)
        {
            if (mainTableIn.Enabled)
            {
                mainTableIn.ForeColor = Color.Black;
            }
            else
            {
                mainTableIn.ForeColor = Color.Silver;
            }
        }

        private void ActivateControls()
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox5.Enabled = true;
        }

        private void InitializeTable(DataGridView main, DataGridView add)
        {
            if (main.ColumnCount > 0)
            {
                for (int i = main.ColumnCount - 1; i >= 0; i--)
                {
                    main.Columns.RemoveAt(i);
                    add.Columns.RemoveAt(i);
                }
            }
            main.Columns.Add("0", "0");
            main.Columns[0].Width = 50;
            add.Columns.Add("0", "0");
            add.Columns[0].Width = 50;
            main.Height = 26;
            add.Height = 26;
            if (main.RowCount > 0)
            {
                for (int i = main.RowCount - 1; i >= 0; i--)
                {
                    main.Rows.RemoveAt(i);
                    add.Rows.RemoveAt(i);
                }
            }
            main.Rows.Add();
            add.Rows.Add();
            if (automaton is TRecognizer)
            {
                add[0, 0].Value = "допуск";
            }
            else if (automaton is MealyAut)
            {
                add[0, 0].Value = "0";
            }
            mainTableIn[0, 0].ReadOnly = true;
            addTableIn[0, 0].ReadOnly = true;
        }

        private void ChangeTableColCount(DataGridView main, DataGridView add, int newCount, string s)
        {
            int oldCount = main.ColumnCount;
            for (int i = oldCount; i < newCount; i++)
            {
                main.Columns.Add(i.ToString(), i.ToString());
                main.Columns[i].Width = 50;
                main[i, 0].Value = s + (i - 1);
                main[i, 0].ReadOnly = true;
                add.Columns.Add(i.ToString(), i.ToString());
                add.Columns[i].Width = 50;
            }
            for (int i = 0; i < oldCount - newCount; i++)
            {
                main.Columns.RemoveAt(oldCount - i - 1);
                add.Columns.RemoveAt(oldCount - i - 1);
            }
            main.Width = newCount * 50 + 4;
            add.Width = newCount * 50 + 4;
        }

        private void ChangeTableRowCount(DataGridView main, DataGridView add, int newCount, string s)
        {
            int oldCount;
            if (automaton is MealyAut)
            {
                oldCount = add.RowCount;
                for (int i = oldCount; i < newCount - 1; i++)
                {
                    add.Rows.Add();
                    add[0, i].Value = s + i;
                    add[0, i].ReadOnly = true;
                }
                for (int i = 0; i < oldCount - newCount + 1; i++)
                {
                    add.Rows.RemoveAt(oldCount - i - 1);
                }
                add.Height = (newCount - 1) * 22 + 4;
            }
            oldCount = main.RowCount;
            for (int i = oldCount; i < newCount; i++)
            {
                main.Rows.Add();
                main[0, i].Value = s + (i - 1);
                main[0, i].ReadOnly = true;
            }
            for (int i = 0; i < oldCount - newCount; i++)
            {
                main.Rows.RemoveAt(oldCount - i - 1);
            }
            main.Height = newCount * 22 + 4;
            add.Top = main.Top + main.Height + 5;
        }

        private void Create(int numOfSymbols, int numOfStates)
        {
            if (tRecogRadioButton.Checked)
            {
                automaton = new TRecognizer();
            }
            if (MealyRadioButton.Checked)
            {
                automaton = new MealyAut();
            }
            InitializeTable(mainTableIn, addTableIn);
            ChangeTableColCount(mainTableIn, addTableIn, numOfStates + 1, "q");
            ChangeTableRowCount(mainTableIn, addTableIn, numOfSymbols + 1, "");
        }

        private string[] StringsFromForm()
        {
            string[] textAut = new string[3 + mainTableIn.RowCount - 1 + addTableIn.RowCount];
            textAut[0] = (mainTableIn.RowCount - 1).ToString();
            textAut[1] = (mainTableIn.ColumnCount - 1).ToString();
            textAut[2] = startS22.Text;
            int textAutIndex = 3;
            for (int i = 1; i < mainTableIn.RowCount; i++, textAutIndex++)
            {
                textAut[textAutIndex] = "";
                for (int j = 1; j < mainTableIn.ColumnCount; j++)
                {
                    textAut[textAutIndex] += mainTableIn[j, i].Value + " ";
                }
            }
            for (int i = 0; i < addTableIn.RowCount; i++, textAutIndex++)
            {
                textAut[textAutIndex] = "";
                for (int j = 1; j < addTableIn.ColumnCount; j++)
                {
                    textAut[textAutIndex] += addTableIn[j, i].Value + " ";
                }
            }
            return textAut;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (automaton is TRecognizer)
            {
                automaton = new TRecognizer();
            }
            if (automaton is MealyAut)
            {
                automaton = new MealyAut();
            }
            string[] textAut = StringsFromForm();
            automaton.FillFromStrings(textAut);
            automaton.CreateGroups();
            automaton.Algorithm();
            groupBox4.Top = groupBox3.Location.Y + groupBox3.Height + 10;
            InitializeTable(mainTableOut, addTableOut);
            ChangeTableColCount(mainTableOut, addTableOut, automaton.GroupCount + 1, "s");
            ChangeTableRowCount(mainTableOut, addTableOut, mainTableIn.RowCount, "");
            textAut = automaton.OutputMinimizedToStrings();
            for (int i = 1; i < mainTableOut.RowCount; i++)
            {
                string[] str = textAut[i - 1].Trim().Split(' ');
                for (int j = 1; j < mainTableOut.ColumnCount; j++)
                {
                    mainTableOut[j, i].Value = str[j - 1];
                }
            }
            for (int i = 0; i < addTableOut.RowCount; i++)
            {
                string[] str = textAut[i + mainTableOut.RowCount - 1].Trim().Split(' ');
                for (int j = 1; j < addTableOut.ColumnCount; j++)
                {
                    addTableOut[j, i].Value = str[j - 1];
                }
            }
            finalSSLabel2.Text = automaton.NewStart().ToString();
            groupBox4.Visible = true;
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainTableIn.RowCount - 1; i++)
            {
                for (int j = 0; j < mainTableIn.ColumnCount - 1; j++)
                {
                    mainTableIn[j + 1, i + 1].Value = "";
                }
            }
            for (int i = 0; i < addTableIn.RowCount; i++)
            {
                for (int j = 0; j < addTableIn.ColumnCount - 1; j++)
                {
                    addTableIn[j + 1, i].Value = "";
                }
            }
        }

        private void FirstAut()
        {
            load -= FirstLoad;
            load += OtherLoad;
            createAutoButton.Click += OthercreateAutoButton_Click;
            createAutoButton.Click -= FirstcreateAutoButton_Click;
        }

        private void FirstcreateAutoButton_Click(object sender, EventArgs e)
        {
            ActivateControls();
            FirstAut();
        }

        private void OthercreateAutoButton_Click(object sender, EventArgs e)
        {
            Form2 ask = new Form2();
            if (ask.ShowDialog() == DialogResult.OK)
            {
                Create(Convert.ToInt32(numOfSymbolsTextBox.Text), Convert.ToInt32(numOfStatesTextBox.Text));
            }
        }

        private void accept1_Click(object sender, EventArgs e)
        {
            ChangeTableRowCount(mainTableIn, addTableIn, Convert.ToInt32(numOfSymbolsTextBox.Text) + 1, "");
        }

        private void accept2_Click(object sender, EventArgs e)
        {
            ChangeTableColCount(mainTableIn, addTableIn, Convert.ToInt32(numOfStatesTextBox.Text) + 1, "q");
        }

        private void accept3_Click(object sender, EventArgs e)
        {
            startS22.Text = startState.Text;
        }

        private delegate void DLoadAut();

        private void LoadAut()
        {
            StreamReader strrd = new StreamReader(openFileDialog1.FileName);
            Create(Convert.ToInt32(strrd.ReadLine()), Convert.ToInt32(strrd.ReadLine()));
            automaton.StartStateNum = Convert.ToInt32(strrd.ReadLine());
            startS22.Text = automaton.StartStateNum.ToString();
            string[] temp;
            for (int i = 0; i < mainTableIn.RowCount - 1; i++)
            {
                temp = strrd.ReadLine().Trim().Split(' ');
                for (int j = 0; j < mainTableIn.ColumnCount - 1; j++)
                {
                    mainTableIn[j + 1, i + 1].Value = temp[j];
                }
            }
            for (int i = 0; i < addTableIn.RowCount; i++)
            {
                temp = strrd.ReadLine().Trim().Split(' ');
                for (int j = 0; j < addTableIn.ColumnCount - 1; j++)
                {
                    addTableIn[j + 1, i].Value = temp[j];
                }
            }
            strrd.Close();
        }

        private void FirstLoad()
        {
            LoadAut();
            ActivateControls();
            FirstAut();
        }

        private void OtherLoad()
        {
            Form2 ask = new Form2();
            if (ask.ShowDialog() == DialogResult.OK)
            {
                LoadAut();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                load.Invoke();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] output = StringsFromForm();
                File.WriteAllLines(saveFileDialog1.FileName, output);
            }
        }

        private void deleteResult_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }
    }
}
