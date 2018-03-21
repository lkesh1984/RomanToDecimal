using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Grammer grammer = new RomanGrammer("MCMXXVIII");
            GrammerParser parser = new RomanToDecimalParser();
            string output = grammer.Translate(parser);

            Console.WriteLine(output);
        }
    }
}
