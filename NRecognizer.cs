using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class NRecognizer : Recognizer
    {
        public NRecognizer() : base()
        {
            allTransPresent = false;
        }

        public override void Minimize()
        {
            ConvertToTotal();
            base.Minimize();
            ConvertToNonTotal();
        }

        private void ConvertToTotal()
        {
            states.Add(new State(symbolsCount, statesCount));
            for (int i = 0; i < symbolsCount; i++)
            {
                states[statesCount][i] = states[statesCount];
                for (int j = 0; j < statesCount; j++)
                {
                    if (states[j][i] == null)
                    {
                        states[j][i] = states[statesCount];
                    }
                }
            }
            isAccept.Add(false);
            statesCount++;
        }

        private void ConvertToNonTotal()
        {
            bool found = false;
            for (int i = 0; i < groups.Count; i++)
            {
                if (!found)
                {
                    if (groups[i][0].Num == statesCount - 1)
                    {
                        groups.RemoveAt(i);
                        found = true;
                        i--;
                    }
                }
                else
                {
                    foreach (State s in groups[i])
                    {
                        s.GroupNum = i;
                    }
                }
            }
            states.RemoveAt(statesCount - 1);
            isAccept.RemoveAt(statesCount - 1);
            statesCount--;
            for (int i = 0; i < symbolsCount; i++)
            {
                for (int j = 0; j < statesCount; j++)
                {
                    if (states[j][i].Num == statesCount)
                    {
                        states[j][i] = null;
                    }
                }
            }
        }
    }
}
