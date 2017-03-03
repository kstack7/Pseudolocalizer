namespace PseudoLocalizer.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// A transform which makes all words approximately one third longer.
    /// </summary>
    public static class ExtraLength
    {
        public static string Transform(string value, decimal wordLengthGrowthPercentage)
        {
            return string.Join(
                " ", 
                value.Split(' ')
                    .Select(word => Lengthen(word, wordLengthGrowthPercentage)));
        }

        private static string Lengthen(string word, decimal wordLengthGrowthPercentage)
        {
            char[] accentList =
            {
                '\u00fe', //p
                '\u00e9', //e
                '\u00f1', //n
                '\u00fb', //u
                '\u00e7', //c
                '\u0181', //B
                '\u0180', //b
                '\u00c7', //C
                '\u00c5', //A
                '\u0154', //R
                '\u00f0', //d
                '\u01ea', //Q
                '\u00ee', //i
                '\u011d', //g
                '\u00fd'  //y

            };
            var count = Math.Round((Decimal)((wordLengthGrowthPercentage / 100m) * word.Length));

            Random rand = new Random((int)DateTime.Now.Ticks);
            //Sleep so the random character-grabber can do its job
            System.Threading.Thread.Sleep(5);

            //This loops through and grabs a random character using the count
            //then adds the new group of accent characters to the existing word
            var extraChars = "";
            for (var i = 0; i < count; i++)
            {
                extraChars = extraChars + accentList[rand.Next(accentList.Length)];
            }
            return word + extraChars;
        }
    }
}
