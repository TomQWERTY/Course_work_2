using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class MooreAut : Automaton
    {
        List<string> outs;

        public MooreAut() : base()
        {
            outs = new List<string>();
            allTransPresent = true;
        }

        public override void FillFromStrings(List<string> input)
        {
            FillStates(input);
            string[] str = input[input.Count - 1].TrimEnd().Split(' ');
            for (int i = 0; i < statesCount; i++)
            {
                try
                {
                    if (str[i] != "")
                    {
                        outs.Add(str[i]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    throw new AutTableException(i, 0, false);
                }
            }
        }

        protected override void CreateGroups()
        {
            groups = new List<List<State>>();
            List<State> temp = states;
            bool allWatched = false;
            for (int currGroup = -1; !allWatched; )
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
                    if (temp[currState] != null && outs[currState] == outs[groups[currGroup][0].Num])
                    {
                        groups[currGroup].Add(temp[currState]);
                        temp[currState].GroupNum = currGroup;
                        temp[currState] = null;
                    }
                }
            }
        }

        public override List<string> OutputMinimizedToStrings()
        {
            List<string> output = new List<string>();
            MinimizedStatesToStrings(ref output);
            StringBuilder strbl = new StringBuilder();
            for (int j = 0; j < GroupCount; j++)
            {
                strbl.Append(outs[groups[j][0].Num]);
                strbl.Append(" ");
            }
            output.Add(strbl.ToString());
            return output;
        }
    }
}
