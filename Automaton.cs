using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    abstract class Automaton
    {
        protected List<State> states;
        protected List<List<State>> groups;
        protected int startStateNum, symbolsCount, statesCount;

        public Automaton()
        {
            states = new List<State>();
            groups = new List<List<State>>();
            startStateNum = 0;
            symbolsCount = 0;
            statesCount = 0;
        }

        public void Algorithm()
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

        protected void FillStates(string[] input)
        {
            symbolsCount = Convert.ToInt32(input[0]);
            statesCount = Convert.ToInt32(input[1]);
            startStateNum = Convert.ToInt32(input[2]);
            for (int i = 0; i < statesCount; i++)
            {
                states.Add(new State(symbolsCount, i));
            }
            for (int i = 0; i < symbolsCount; i++)
            {
                string[] str = input[i + 3].Trim().Split(' ');
                for (int j = 0; j < statesCount; j++)
                {
                    states[j][i] = states[Convert.ToInt32(str[j])];
                }
            }
        }

        virtual public void FillFromStrings(string[] input) { }

        virtual public void CreateGroups() { }

        public int StartStateNum
        {
            get
            {
                return startStateNum;
            }
            set
            {
                startStateNum = value;
            }
        }

        public State this[int i]
        {
            get
            {
                return states[i];
            }
            set
            {
                states[i] = value;
            }
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

        protected void OutputMinimizedStatesToStrings(ref string[] output)
        {
            for (int i = 0; i < symbolsCount; i++)
            {
                output[i] = "";
                for (int j = 0; j < GroupCount; j++)
                {
                    output[i] += groups[j][0][i] + " ";
                }
            }
        }

        virtual public string[] OutputMinimizedToStrings()
        {
            return new string[1];
        }
    }
}
