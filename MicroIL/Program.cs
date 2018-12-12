using System;
using System.Collections.Generic;

namespace MicroIL
{
    class Program
    {
        static void Main(string[] args)
        {            
            Run(new MicroOpCode[]
            {
                new MicroOpCode()
                {
                    OpCodes = MicroOpCodes.StoreVarLitInt,
                    Argument = 0,
                    Lit = 100
                },
                new MicroOpCode()
                {
                    OpCodes = MicroOpCodes.StoreVarLitInt,
                    Argument = 0,
                    Lit = 50
                },
                new MicroOpCode()
                {
                    OpCodes = MicroOpCodes.MulInt,
                },
                new MicroOpCode()
                {
                    OpCodes = MicroOpCodes.ReturnInt,
                }
            }, 2);
            
        }

        static void Run(MicroOpCode[] opCodes, int intVarCount = 0)
        {
            int index = 0;
            int length = opCodes.Length;

            if (length == 0)
                return;
            var intVars = new int[intVarCount];
            LinkedList<int> intStack = new LinkedList<int>();

            int spare;

            do
            {
                var item = opCodes[index];

                switch (item.OpCodes)
                {
                    case MicroOpCodes.LoadVarInt:
                        intStack.AddLast(intVars[item.Argument]);
                        break;
                    case MicroOpCodes.StoreVarInt:
                        spare = intStack.Last.Value;
                        intVars[item.Argument] = spare;
                        intStack.RemoveLast();
                        break;
                    case MicroOpCodes.StoreVarLitInt:
                        intVars[item.Argument] = item.Lit;
                        intStack.AddLast(intVars[item.Argument]);
                        break;
                    case MicroOpCodes.AddInt:
                        spare = intStack.Last.Value;                        
                        intStack.RemoveLast();

                        intStack.Last.Value = intStack.Last.Value + spare;

                        break;
                    case MicroOpCodes.SubInt:
                        spare = intStack.Last.Value;
                        intStack.RemoveLast();

                        intStack.Last.Value = intStack.Last.Value - spare;

                        break;
                    case MicroOpCodes.MulInt:
                        spare = intStack.Last.Value;
                        intStack.RemoveLast();

                        intStack.Last.Value = intStack.Last.Value * spare;

                        break;
                    case MicroOpCodes.DivInt:
                        spare = intStack.Last.Value;
                        intStack.RemoveLast();

                        intStack.Last.Value = intStack.Last.Value / spare;

                        break;
                    case MicroOpCodes.ReturnInt:
                        Console.WriteLine(intStack.Last.Value);
                        return;
                }

            } while (++index < length);
        }

        class MicroOpCode
        {
            public MicroOpCodes OpCodes;
            public int Argument;
            public int Lit;
        }

        enum MicroOpCodes
        {
            LoadVarInt,
            StoreVarInt,
            StoreVarLitInt,
            AddInt,
            SubInt,
            MulInt,
            DivInt,
            ReturnInt
        }
    }
}
