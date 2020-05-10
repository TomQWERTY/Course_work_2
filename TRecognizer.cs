using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork2
{
    class TRecognizer : Automaton
    {
        List<bool> isAccept;

        public TRecognizer() : base()
        {
            isAccept = new List<bool>();
        }

        public override void FillFromStrings(string[] input)
        {
            FillStates(input);
            string[] str = input[input.Length - 1].Trim().Split(' ');
            for (int i = 0; i < statesCount; i++)
            {
                isAccept.Add(str[i] == "+" ? true : false);
            }
        }

        public override void CreateGroups()
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

        public override string[] OutputMinimizedToStrings()
        {
            string[] output = new string[symbolsCount + 1];
            OutputMinimizedStatesToStrings(ref output);
            output[symbolsCount] = "";
            for (int j = 0; j < GroupCount; j++)
            {
                output[symbolsCount] += isAccept[groups[j][0].Num] ? "+ " : "- ";
            }
            return output;
        }
    }
}
