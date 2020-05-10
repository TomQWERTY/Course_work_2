using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class State
    {
        State[] states;
        int groupNum, num;

        public State(int symbolsCount, int num_)
        {
            states = new State[symbolsCount];
            groupNum = 0;
            num = num_;
        }

        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
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
        
        public int GroupNum
        {
            get
            {
                return groupNum;
            }
            set
            {
                groupNum = value;
            }
        }

        public override string ToString()
        {
            return groupNum.ToString();
        }
    }
}
