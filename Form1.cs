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
        AutType autType;

        public Form1()
        {
            InitializeComponent();
            SetInitialParams();
            mainTableIn.ForeColor = Color.Silver;
            addTableIn.ForeColor = Color.Silver;
            mainTableIn.EnabledChanged += dgViewForeColorInactive;
            addTableIn.EnabledChanged += dgViewForeColorInactive;
            acceptAllBut.Click += accept1_Click;
            acceptAllBut.Click += accept2_Click;
            acceptAllBut.Click += accept3_Click;
            createAutoButton.Click += FirstcreateAutoButton_Click;
            load += FirstLoad;
        }

        private void dgViewForeColorInactive(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Enabled)
            {
                dgv.ForeColor = Color.Black;
            }
            else
            {
                dgv.ForeColor = Color.Silver;
            }
        }

        private void SetInitialParams()
        {
            string inStates = "2", inSymb = "2", inStart = "0";
            numOfStatesTextBox.Text = inStates;
            numOfSymbolsTextBox.Text = inSymb;
            startState.Text = inStart;
            Create(inSymb, inStates);
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
            if (automaton is Recognizer)
            {
                add[0, 0].Value = "допуск";
            }
            else if (automaton is MealyAut)
            {
                add[0, 0].Value = "0";
            }
            else if (automaton is MooreAut)
            {
                add[0, 0].Value = "";
            }
            mainTableIn[0, 0].ReadOnly = true;
            addTableIn[0, 0].ReadOnly = true;
        }

        private void ChangeTableColCount(DataGridView main, DataGridView add, int newCount, string s)
        {
            if (newCount < 2)
            {
                throw new Exception("Кількість стовпців не може бути меншою за 1.");
            }
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

        private void ChangeTableRowCount(DataGridView main, DataGridView add, int newCount, string s, bool isInput)
        {
            if (newCount < 2)
            {
                throw new Exception("Кількість рядків не може бути меншою за 1.");
            }
            int oldCount;
            if (automaton is MealyAut)
            {
                oldCount = add.RowCount;
                if (isInput)
                {
                    for (int i = oldCount; i < newCount - 1; i++)
                    {
                        add.Rows.Add();
                        add[0, i].Value = s + i;
                        add[0, i].ReadOnly = true;
                    }
                }
                else
                {
                    for (int i = oldCount - 1; i < newCount - 1; i++)
                    {
                        add.Rows.Add();
                        add[0, i].Value = addTableIn[0, i].Value;
                    }
                    add.Rows.RemoveAt(add.RowCount - 1);
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
                if (isInput)
                {
                    main[0, i].Value = s + (i - 1);
                }
                else
                {
                    main[0, i].Value = mainTableIn[0, i].Value;
                }
            }
            for (int i = 0; i < oldCount - newCount; i++)
            {
                main.Rows.RemoveAt(oldCount - i - 1);
            }
            main.Height = newCount * 22 + 4;
            if (automaton is MooreAut)
            {
                add.Top = 48;
                main.Top = add.Top + add.Height + 5;
            }
            else
            {
                main.Top = 48;
                add.Top = main.Top + main.Height + 5;
            }
        }

        private void Create(string sNumOfSymbols, string sNumOfStates)
        {
            int numOfSymbols = (int)Convert.ToUInt32(sNumOfSymbols);
            int numOfStates = (int)Convert.ToUInt32(sNumOfStates);
            if (tRecogRadioButton.Checked)
            {
                automaton = new TRecognizer();
                autType = AutType.TRecognizer;
            }
            if (nRecogRadioButton.Checked)
            {
                automaton = new NRecognizer();
                autType = AutType.NRecognizer;
            }
            if (MooreRadioButton.Checked)
            {
                automaton = new MooreAut();
                autType = AutType.MooreAut;
            }
            if (MealyRadioButton.Checked)
            {
                automaton = new MealyAut();
                autType = AutType.MealyAut;
            }
            InitializeTable(mainTableIn, addTableIn);
            ChangeTableColCount(mainTableIn, addTableIn, numOfStates + 1, "q");
            ChangeTableRowCount(mainTableIn, addTableIn, numOfSymbols + 1, "", true);
        }

        private List<string> StringsFromForm()
        {
            List<string> textAut = new List<string>();
            textAut.Add(((int)autType).ToString());
            textAut.Add((mainTableIn.RowCount - 1).ToString());
            textAut.Add((mainTableIn.ColumnCount - 1).ToString());
            textAut.Add(startS22.Text);
            StringBuilder temp = new StringBuilder();
            StringBuilder symbols = new StringBuilder();
            for (int i = 1; i < mainTableIn.RowCount; i++)
            {
                symbols.Append(mainTableIn[0, i].Value);
                symbols.Append(" ");
                temp = new StringBuilder();
                for (int j = 1; j < mainTableIn.ColumnCount; j++)
                {
                    temp.Append(mainTableIn[j, i].Value);
                    temp.Append(" ");
                }
                textAut.Add(temp.ToString());
            }
            
            for (int i = 0; i < addTableIn.RowCount; i++)
            {
                temp = new StringBuilder();
                for (int j = 1; j < addTableIn.ColumnCount; j++)
                {
                    temp.Append(addTableIn[j, i].Value);
                    temp.Append(" ");
                }
                textAut.Add(temp.ToString());
            }
            textAut.Add(symbols.ToString());
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
            if (automaton is NRecognizer)
            {
                automaton = new NRecognizer();
            }
            List<string> textAut = StringsFromForm();
            textAut.RemoveAt(0);
            textAut.RemoveAt(textAut.Count - 1);
            try
            {
                automaton.FillFromStrings(textAut);
                automaton.Minimize();
                groupBox4.Top = groupBox3.Location.Y + groupBox3.Height + 10;
                InitializeTable(mainTableOut, addTableOut);
                ChangeTableColCount(mainTableOut, addTableOut, automaton.GroupCount + 1, "s");
                ChangeTableRowCount(mainTableOut, addTableOut, mainTableIn.RowCount, "", false);
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
                ForbidChangeData();
            }
            catch (AutTableException exp)
            {
                int errorRow = exp.SymbNum + 1;
                if (exp.TransTable)
                {
                    int errorCol = exp.StateNum + 1;
                    int errorValue;
                    if (mainTableIn[errorCol, errorRow].Value != null && Int32.TryParse(mainTableIn[errorCol, errorRow].Value.ToString(), out errorValue) && errorValue >= 0)
                    {
                        MessageBox.Show("Помилка! Неможливо здійснити перехід зі стану " + exp.StateNum + " в стан " + errorValue + " по символу \"" + mainTableIn[0, errorRow].Value.ToString() + "\", адже стану під номером " + errorValue + " не існує.");
                    }
                    else
                    {
                        MessageBox.Show("Помилка! Некоректне значення в переході зі стану " + exp.StateNum + " по символу \"" + mainTableIn[0, errorRow].Value.ToString() + "\". Потрібно ввести номер одного з існуючих станів.");
                    }
                }
                else
                {
                    if (automaton is Recognizer)
                    {
                        MessageBox.Show("Помилка! Некоректне значення допуску стану " + exp.StateNum + ". Потрібно ввести \"+\" якщо стан допусковий, і \"-\" якщо стан недопусковий.");
                    }
                    else if (automaton is MooreAut)
                    {
                        MessageBox.Show("Помилка! Потрібно ввести вихідний символ для стану " + exp.StateNum + ".");
                    }
                    else
                    {
                        MessageBox.Show("Помилка! Не введено вихідний символ для стану " + exp.StateNum + " при вхідному символу \"" + mainTableIn[0, errorRow].Value.ToString() + "\".");
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Помилка! " + exp.Message);
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

        private void ClearTable()
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
            if (!tRecogRadioButton.Checked)
            {
                SetInitialParams();
            }
        }

        private void OthercreateAutoButton_Click(object sender, EventArgs e)
        {
            Form2 ask = new Form2();
            if (ask.ShowDialog() == DialogResult.OK)
            {
                SetInitialParams();
                DeleteResult();
            }
        }

        private void accept1_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeTableRowCount(mainTableIn, addTableIn, (int)Convert.ToUInt32(numOfSymbolsTextBox.Text) + 1, "", true);
            }
            catch (Exception exp)
            {
                if (exp is FormatException || exp is OverflowException)
                {
                    MessageBox.Show("Помилка! Введена некоректна кількість символів.");
                }
                else
                {
                    MessageBox.Show("Помилка! " + exp.Message);
                }
            }
        }

        private void accept2_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeTableColCount(mainTableIn, addTableIn, (int)Convert.ToUInt32(numOfStatesTextBox.Text) + 1, "q");
                if (Convert.ToInt32(startS22.Text) >= mainTableIn.ColumnCount - 1)
                {
                    startS22.Text = (mainTableIn.ColumnCount - 2).ToString();
                }
            }
            catch (Exception exp)
            {
                if (exp is FormatException || exp is OverflowException)
                {
                    MessageBox.Show("Помилка! Введена некоректна кількість станів.");
                }
                else
                {
                    MessageBox.Show("Помилка! " + exp.Message);
                }
            }
        }

        private void accept3_Click(object sender, EventArgs e)
        {
            try
            {
                uint temp = Convert.ToUInt32(startState.Text);
                if (temp < mainTableIn.ColumnCount - 1)
                {
                    startS22.Text = temp.ToString();
                }
                else
                {
                    throw new Exception("Некоректний початковий стан (" + temp + "). Такого стану не існує.");
                }
            }
            catch (Exception exp)
            {
                if (exp is FormatException || exp is OverflowException)
                {
                    MessageBox.Show("Помилка! Введено не коректний номер початкового стану.");
                }
                else
                {
                    MessageBox.Show("Помилка! " + exp.Message);
                }
            }
        }

        private bool AutTypeCorrect(AutType at)
        {
            if (at == AutType.TRecognizer && tRecogRadioButton.Checked == true)
            {
                return true;
            }
            if (at == AutType.NRecognizer && nRecogRadioButton.Checked == true)
            {
                return true;
            }
            if (at == AutType.MooreAut && MooreRadioButton.Checked == true)
            {
                return true;
            }
            if (at == AutType.MealyAut && MealyRadioButton.Checked == true)
            {
                return true;
            }
            return false;
        }

        private delegate void DLoadAut();

        private void LoadAut()
        {
            try
            {
                StreamReader strrd = new StreamReader(openFileDialog1.FileName);
                AutType at = (AutType)Convert.ToInt32(strrd.ReadLine());
                if (!AutTypeCorrect(at))
                {
                    throw new AutTypeException();
                }
                string tempSymb = strrd.ReadLine(), tempStates = strrd.ReadLine(), tempStart = strrd.ReadLine();
                Create(tempSymb,tempStates);
                numOfSymbolsTextBox.Text = tempSymb;
                numOfStatesTextBox.Text = tempStates;
                startS22.Text = Convert.ToUInt32(tempStart).ToString();
                startState.Text = tempStart;
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
                temp = strrd.ReadLine().Trim().Split(' ');
                for (int i = 1; i < mainTableIn.RowCount; i++)
                {
                    mainTableIn[0, i].Value = temp[i - 1];
                    if (automaton is MealyAut)
                    {
                        addTableIn[0, i - 1].Value = temp[i - 1];
                    }
                }
                strrd.Close();
            }
            catch (AutTypeException e)
            {
                MessageBox.Show("Помилка! " + e.Message);
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Помилка! Файл не містить всієї необхідної інформації або містить некоректну інформацію про кількість станів/символів.");
                SetInitialParams();
                if (load.Method.Name == "FirstLoad")
                {
                    throw;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка! Не вдалося прочитати файл, неправильний формат.");
                SetInitialParams();
                throw;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Помилка! Файл містить некоректне значення (надто велике або від'ємне).");
                SetInitialParams();
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show("Помилка! " + e.Message);
                SetInitialParams();
                throw;
            }
        }

        private void FirstLoad()
        {
            try
            {
                LoadAut();
                ActivateControls();
                FirstAut();
            }
            catch (Exception) { }
        }

        private void OtherLoad()
        {
            Form2 ask = new Form2();
            if (ask.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadAut();
                    DeleteResult();
                }
                catch (Exception) { }
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
                string[] output = StringsFromForm().ToArray();
                File.WriteAllLines(saveFileDialog1.FileName, output);
            }
        }

        private void deleteResult_Click(object sender, EventArgs e)
        {
            DeleteResult();
        }

        private void mainTableOut_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                string str = "Стани вхідного автомата: ";
                if (e.RowIndex == 0)
                {
                    str += automaton.OldStateNumbers(e.ColumnIndex - 1);
                }
                else
                {
                    int temp;
                    if (Int32.TryParse(mainTableOut[e.ColumnIndex, e.RowIndex].Value.ToString(), out temp))
                    {
                        str += automaton.OldStateNumbers(temp);
                    }
                    else
                    {
                        str = "";
                    }
                }
                mainTableOut[e.ColumnIndex, e.RowIndex].ToolTipText = str;
            }
        }

        private void mainTableIn_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (automaton is MealyAut && e.ColumnIndex == 0 && e.RowIndex > 0)
            {
                addTableIn[0, e.RowIndex - 1].Value = mainTableIn[0, e.RowIndex].Value;
            }
        }

        private void DeleteResult()
        {
            groupBox4.Visible = false;
            AllowChangeData();
        }

        private void ForbidChangeData()
        {
            mainTableIn.Enter += ClicksForb;
            addTableIn.Enter += ClicksForb;
            accept1.Enter += ClicksForb;
            accept2.Enter += ClicksForb;
            accept3.Enter += ClicksForb;
            acceptAllBut.Enter += ClicksForb;
            cleanT1Button.Enter += ClicksForb;
        }

        private void AllowChangeData()
        {
            mainTableIn.Enter -= ClicksForb;
            addTableIn.Enter -= ClicksForb;
            accept1.Enter -= ClicksForb;
            accept2.Enter -= ClicksForb;
            accept3.Enter -= ClicksForb;
            acceptAllBut.Enter -= ClicksForb;
            cleanT1Button.Enter -= ClicksForb;
        }

        private void ClicksForb(object sender, EventArgs e)
        {
            MessageBox.Show("Редагування недоступне, доки не видалений результат мінімізації");
            if (sender is DataGridView)
            {
                (sender as DataGridView)[0, 0].Selected = true;
            }
            deleteResult.Focus();
        }

        private void startS22_SizeChanged(object sender, EventArgs e)
        {
            cleanT1Button.Left = startS22.Right + 9;
        }
    }
}
