using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class AutTableException : Exception
    {
        int stateNum, symbNum;
        bool transTable;

        public AutTableException(int stateNum_, int symbNum_, bool transTable_) : base("Некоректне значення в табличному поданні автомата")
        {
            stateNum = stateNum_;
            symbNum = symbNum_;
            transTable = transTable_;
        }

        public int StateNum
        {
            get
            {
                return stateNum;
            }
        }

        public int SymbNum
        {
            get
            {
                return symbNum;
            }
        }

        public bool TransTable
        {
            get
            {
                return transTable;
            }
        }
    }

    class AutTypeException : Exception
    {
        public AutTypeException() : base("Невідповідність типу автомату.") { }
    }

    enum AutType
    {
        TRecognizer, NRecognizer, MooreAut, MealyAut
    }

    abstract class Automaton
    {
        protected List<State> states;
        protected List<List<State>> groups;
        protected int startStateNum, symbolsCount, statesCount;
        protected bool? allTransPresent;

        public Automaton()
        {
            states = new List<State>();
            groups = new List<List<State>>();
            startStateNum = 0;
            symbolsCount = 0;
            statesCount = 0;
            allTransPresent = null;
        }

        public virtual void Minimize()
        {
            CreateGroups();
            Algorithm();
        }

        private void Algorithm()
        {
            bool equivalent = false;
            while (!equivalent)
            {
                equivalent = true;
                int initialGroupsCount = groups.Count;
                for (int currGroup = 0; currGroup < initialGroupsCount; currGroup++)
                {
                    while (groups[currGroup].Count > 0)
                    {
                        groups.Add(new List<State>());
                        groups.Last().Add(groups[currGroup][0]);
                        groups[currGroup].RemoveAt(0);
                        for (int currState = 0; currState < groups[currGroup].Count; currState++)
                        {
                            bool equalPerhs = true;
                            for (int currSymb = 0; currSymb < symbolsCount; currSymb++)
                            {
                                if (groups[currGroup][currState][currSymb].GroupNum != groups.Last()[0][currSymb].GroupNum)
                                {
                                    equalPerhs = false;
                                    break;
                                }
                            }
                            if (equalPerhs)
                            {
                                groups.Last().Add(groups[currGroup][currState]);
                                groups[currGroup].RemoveAt(currState);
                                currState--;
                            }
                        }
                    }
                    groups[currGroup] = groups.Last();
                    groups.RemoveAt(groups.Count - 1);
                }
                if (groups.Count != initialGroupsCount)
                {
                    equivalent = false;
                    for (int currGroup = 0; currGroup < groups.Count; currGroup++)
                    {
                        for (int currState = 0; currState < groups[currGroup].Count; currState++)
                        {
                            groups[currGroup][currState].GroupNum = currGroup;
                        }
                    }
                }
            }
        }

        protected void FillStates(List<string> input)
        {
            symbolsCount = Convert.ToInt32(input[0]);
            statesCount = Convert.ToInt32(input[1]);
            startStateNum = Convert.ToInt32(input[2]);           
            states.Clear();
            for (int i = 0; i < statesCount; i++)
            {
                states.Add(new State(symbolsCount, i));
            }
            for (int i = 0; i < symbolsCount; i++)
            {
                string[] str = input[i + 3].TrimEnd().Split(' ');
                for (int j = 0; j < statesCount; j++)
                {
                    try
                    {
                        if (allTransPresent.Value || str[j] != "-")
                        {
                            states[j][i] = states[Convert.ToInt32(str[j])];
                        }
                    }
                    catch (Exception)
                    {
                        throw new AutTableException(j, i, true);
                    }
                }
            }
        }

        virtual public void FillFromStrings(List<string> input) { }

        virtual protected void CreateGroups() { }

        public string OldStateNumbers(int i)
        {
            StringBuilder strbl = new StringBuilder();
            for (int j = 0; j < groups[i].Count; j++)
            {
                strbl.Append(groups[i][j].Num);
                strbl.Append(", ");
            }
            string str = strbl.ToString();
            return str.Substring(0, str.Length - 2);
        }

        public int GroupCount
        {
            get
            {
                return groups.Count;
            }
        }

        public int NewStart()
        {
            for (int i = 0; i < groups.Count; i++)
            {
                for (int j = 0; j < groups[i].Count; j++)
                {
                    if (groups[i][j].Num == startStateNum)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        protected void MinimizedStatesToStrings(ref List<string> output)
        {
            for (int i = 0; i < symbolsCount; i++)
            {
                StringBuilder strbl = new StringBuilder();
                for (int j = 0; j < GroupCount; j++)
                {
                    if (groups[j][0][i] != null)
                    {
                        strbl.Append(groups[j][0][i]);
                    }
                    else
                    {
                        strbl.Append("-");
                    }
                    strbl.Append(" ");
                }
                output.Add(strbl.ToString());
            }
        }

        virtual public List<string> OutputMinimizedToStrings()
        {
            return new List<string>();
        }
    }
}
