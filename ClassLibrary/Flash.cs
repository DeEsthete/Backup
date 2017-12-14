using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Flash : Storage
    {
        public int Memory { get; set; }
        public int FilledMemory { get; set; }

        public Flash(string name, string model,int memory, int filledMemory, int speed)
        {
            SetName(name);
            SetModel(model);
            Memory = memory;
            FilledMemory = filledMemory;
            SetSpeed(speed);
        }

        public override int GetMemory()
        {
            return Memory;
        }

        public override void FillMemory(int memory)
        {
            FilledMemory = memory;
        }

        public override int GetEmptyMemory()
        {
            return Memory - FilledMemory;
        }

        public override string Show()
        {
            string info = String.Format(" Name; {0} \n Model; {1} \n Memory; {2} \n Filled Memory; {3} \n Speed; {4} \n", GetName(), GetModel(), Memory, FilledMemory, GetSpeed());
            return info;
        }
    }
}
