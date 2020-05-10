using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class MealyAut : Automaton
    {
        List<List<string>> outs;

        public MealyAut() : base()
        {
            outs = new List<List<string>>();
        }

        public override void FillFromStrings(string[] input)
        {
            FillStates(input);
            for (int i = input.Length - symbolsCount, k = 0; i < input.Length; i++, k++)
            {
                string[] str = input[i].Trim().Split(' ');
                outs.Add(new List<string>());
                for (int j = 0; j < statesCount; j++)
                {
                    outs[k].Add(str[j]);
                }
            }
        }

        public override void CreateGroups()
        {
            groups = new List<List<State>>();
            List<State> temp = states;
            bool allWatched = false;
            for (int currGroup = -1; !allWatched;)
            {
                allWatched = true;
                for (int currState = 0; currState < states.Count; currState++)
                {
                    if (temp[currState] != null)
                    {
                        allWatched = false;
                        groups.Add(new List<State>());
                        currGroup++;
                        groups[currGroup].Add(temp[currState]);
                        temp[currState].GroupNum = currGroup;
                        temp[currState] = null;
                        break;
                    }
                }
                for (int currState = 0; currState < states.Count; currState++)
                {
                    if (temp[currState] != null)
                    {
                        bool eq = true;
                        for (int currSymb = 0; currSymb < symbolsCount; currSymb++)
                        {
                            if (outs[currSymb][currState] != outs[currSymb][groups[currGroup][0].Num])
                            {
                                eq = false;
                                break;
                            }
                        }
                        if (eq)
                        {
                            groups[currGroup].Add(temp[currState]);
                            temp[currState].GroupNum = currGroup;
                            temp[currState] = null;
                        }
                    }
                }
            }
        }

        public override string[] OutputMinimizedToStrings()
        {
            string[] output = new string[symbolsCount * 2];
            OutputMinimizedStatesToStrings(ref output);
            for (int i = 0; i < symbolsCount; i++)
            {
                output[i + symbolsCount] = "";
                for (int j = 0; j < GroupCount; j++)
                {
                    output[i + symbolsCount] += outs[i][groups[j][0].Num] + " ";
                }
            }
            return output;
        }
    }
}
