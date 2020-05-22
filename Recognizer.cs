using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    abstract class Recognizer : Automaton
    {
        protected List<bool> isAccept;

        public Recognizer() : base()
        {
            isAccept = new List<bool>();
        }

        public override void FillFromStrings(List<string> input)
        {
            FillStates(input);
            string[] str = input[input.Count - 1].Trim().Split(' ');
            for (int i = 0; i < statesCount; i++)
            {
                try
                {
                    if (str[i] == "+")
                    {
                        isAccept.Add(true);
                    }
                    else if (str[i] == "-")
                    {
                        isAccept.Add(false);
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
            groups.Add(new List<State>());
            groups.Add(new List<State>());
            foreach (State st in states)
            {
                if (isAccept[st.Num])
                {
                    groups[0].Add(st);
                    st.GroupNum = 0;
                }
                else
                {
                    groups[1].Add(st);
                    st.GroupNum = 1;
                }
            }
            if (groups[1].Count == 0)
            {
                groups.RemoveAt(1);
            }
            if (groups[0].Count == 0)
            {
                groups.RemoveAt(0);
                foreach (State st in groups[0])
                {
                    st.GroupNum = 0;
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
                strbl.Append(isAccept[groups[j][0].Num] ? "+ " : "- ");
            }
            output.Add(strbl.ToString());
            return output;
        }
    }
}
