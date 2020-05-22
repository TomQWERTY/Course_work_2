using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class MealyAut : Automaton
    {
        List<string[]> outs;

        public MealyAut() : base()
        {
            outs = new List<string[]>();
            allTransPresent = true;
        }

        public override void FillFromStrings(List<string> input)
        {
            FillStates(input);
            for (int i = input.Count - symbolsCount, k = 0; i < input.Count; i++, k++)
            {
                string[] str = input[i].TrimEnd().Split(' ');
                outs.Add(new string[statesCount]);
                for (int j = 0; j < statesCount; j++)
                {
                    try
                    {
                        if (str[j] != "")
                        {
                            outs[k][j] = str[j];
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        throw new AutTableException(j, k, false);
                    }
                }
            }
        }

        protected override void CreateGroups()
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

        public override List<string> OutputMinimizedToStrings()
        {
            List<string> output = new List<string>();
            MinimizedStatesToStrings(ref output);
            for (int i = 0; i < symbolsCount; i++)
            {
                StringBuilder strbl = new StringBuilder();
                for (int j = 0; j < GroupCount; j++)
                {
                    strbl.Append(outs[i][groups[j][0].Num]);
                    strbl.Append(" ");
                }
                output.Add(strbl.ToString());
            }
            return output;
        }
    }
}
