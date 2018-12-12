using System;

namespace MicroIL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            

            

        }

        static void Run(MicroOpCode[] opCodes)
        {

        }

        class MicroOpCode
        {
            public MicroOpCodes OpCodes;
            public int Argument;
        }

        enum MicroOpCodes
        {
            LoadVar,
            StoreVar,
            CreateNew,
            LoadField
        }
    }
}
