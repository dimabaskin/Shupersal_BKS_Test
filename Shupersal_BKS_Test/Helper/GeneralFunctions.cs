using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Drawing;
using System.Configuration;

namespace Shupersal_BKS_Test.Helper
{
    public static class GeneralFunctions
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringAlphaBet(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringNumeric(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomStringHex(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEF0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool HaveAtLeastXCharacters(string element, int CharacterNumber)
        {
            if (element.Count() >= CharacterNumber) { return true; }
            else { return false; }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            var st = new StackTrace(new StackFrame(1));
            var methodName = st.GetFrame(0).GetMethod().Name;
            //var regex = new System.Text.RegularExpressions.Regex("");

            if (!methodName.StartsWith("<"))
            {
                return methodName;
            }

            methodName = st.GetFrame(0).GetMethod().Name.Split(new string[] { "<" }, StringSplitOptions.None)[1].Split('>')[0].Trim();

            return methodName;
        }
    }
}
