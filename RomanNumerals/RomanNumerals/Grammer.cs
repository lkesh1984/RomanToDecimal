using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public abstract class Grammer
    {
        public virtual string Input
        {
            get;private set;
        }

        public Grammer(string input)
        {
            this.Input = input;
        }

        public abstract string Translate(GrammerParser parser);
    }

    public abstract class GrammerParser
    {
        public abstract string Parse(string input);
    }

    public class RomanGrammer : Grammer
    {
        public override string Input
        {
            get
            {
                return base.Input;
            }
        }

        public RomanGrammer(string input) : base(input)
        {
        }

        public override string Translate(GrammerParser parser)
        {
            return parser.Parse(this.Input);
        }
    }

    public class RomanToDecimalParser : GrammerParser
    {
        public RomanToDecimalParser()
        {
        }

        public override string Parse(string input)
        {
            List<RomanCharacterParser> characterParsers = new List<RomanCharacterParser>();
            
            characterParsers.Add(new RomanThousandParser());
            characterParsers.Add(new RomanHundredParser());
            characterParsers.Add(new RomanTenParser());
            characterParsers.Add(new RomanOneParser());
            int output = 0;

            foreach (var item in characterParsers)
            {
                if (input.StartsWith(item.Nine(input)))
                {
                    // convert nine to 9
                    output += (9 * item.Multiplier);
                    input = input.Substring(item.NextPointer);
                }
                else if (input.StartsWith(item.Five(input)))
                {
                    // convert to 5
                    output += (5 * item.Multiplier);
                    input = input.Substring(item.NextPointer);
                }
                else if (input.StartsWith(item.Four(input)))
                {
                    // convert to 4
                    output += (4 * item.Multiplier);
                    input = input.Substring(item.NextPointer);
                }

                while (input.StartsWith(item.One(input)))
                {
                    // convert to 1
                    output += (1 * item.Multiplier);
                    input = input.Substring(item.NextPointer);
                }
            }

            return output.ToString();
        }
    }

    public abstract class RomanCharacterParser
    {
        public abstract int Multiplier
        {
            get;
        }

        public int NextPointer
        {
            get;protected set;
        }

        public abstract string One(string input);
        public abstract string Four(string input);
        public abstract string Five(string input);
        public abstract string Nine(string input);
    }

    public class RomanThousandParser : RomanCharacterParser
    {
        public override int Multiplier
        {
            get
            {
                return 1000;
            }
        }

        public RomanThousandParser()
        {
            //this.Multiplier = 1000;
        }

        public override string Five(string input)
        {
            this.NextPointer = 0;
            return " ";
        }

        public override string Four(string input)
        {
            this.NextPointer = 0;
            return " ";
        }

        public override string Nine(string input)
        {
            this.NextPointer = 0;
            return " ";
        }

        public override string One(string input)
        {
            this.NextPointer = 1;
            return "M";
        }
    }

    public class RomanHundredParser : RomanCharacterParser
    {
        public override int Multiplier
        {
            get
            {
                return 100;
            }
        }
        public RomanHundredParser()
        {
            //this.Multiplier = 100;
        }

        public override string Five(string input)
        {
            this.NextPointer = 1;
            return "D";
        }

        public override string Four(string input)
        {
            this.NextPointer = 2;
            return "CD";
        }

        public override string Nine(string input)
        {
            this.NextPointer = 2;
            return "CM";
        }

        public override string One(string input)
        {
            this.NextPointer = 1;
            return "C";
        }
    }

    public class RomanTenParser : RomanCharacterParser
    {
        public override int Multiplier
        {
            get
            {
                return 10;
            }
        }
        public RomanTenParser()
        {
            //this.Multiplier = 10;
        }

        public override string Five(string input)
        {
            this.NextPointer = 1;
            return "L";
        }

        public override string Four(string input)
        {
            this.NextPointer = 2;
            return "XL";
        }

        public override string Nine(string input)
        {
            this.NextPointer = 2;
            return "XC";
        }

        public override string One(string input)
        {
            this.NextPointer = 1;
            return "X";
        }
    }

    public class RomanOneParser : RomanCharacterParser
    {
        public override int Multiplier
        {
            get
            {
                return 1;
            }
        }
        public RomanOneParser()
        {
            //this.Multiplier = 1;
        }

        public override string Five(string input)
        {
            this.NextPointer = 1;
            return "V";
        }

        public override string Four(string input)
        {
            this.NextPointer = 2;
            return "IV";
        }

        public override string Nine(string input)
        {
            this.NextPointer = 2;
            return "IX";
        }

        public override string One(string input)
        {
            this.NextPointer = 1;
            return "I";
        }
    }

}
