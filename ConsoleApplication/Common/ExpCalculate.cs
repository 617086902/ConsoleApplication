using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApplication.Common
{
    /// <summary>
    /// 计算表达式的值
    /// </summary>
    public class ExpCalculate
    {
        static readonly string[] Ope = { "+", "-", "*", "/", "(", ")" };
        public static decimal Calculate(string expression)
        {
            var uarr = GetUnitChar(expression);
            var opeStack = new Stack<string>();
            var numStack = new Stack<decimal>();
            decimal v1, v2, val = 0m;
            foreach (var c in uarr)
            {
                if ("(" == c) { opeStack.Push(c); continue; }
                if (opeStack.Any() && ("*" == opeStack.Peek() || "/" == opeStack.Peek()))
                {
                    if (!numStack.Any()) return -1;
                    if ("*" == opeStack.Peek()) numStack.Push(numStack.Pop() * Convert.ToDecimal(c));
                    if ("/" == opeStack.Peek()) numStack.Push(numStack.Pop() / Convert.ToDecimal(c));
                    opeStack.Pop();
                    continue;
                }
                if (")" == c)
                {
                    while (opeStack.Peek() != "(")
                    {
                        v2 = numStack.Pop();
                        v1 = numStack.Pop();
                        if ("+" == opeStack.Peek()) val = v1 + v2;
                        else if ("-" == opeStack.Peek()) val = v1 - v2;
                        opeStack.Pop();
                        numStack.Push(val);
                    }
                    opeStack.Pop();
                    if (opeStack.Any() && ("*" == opeStack.Peek() || "/" == opeStack.Peek()))
                    {
                        v2 = numStack.Pop();
                        v1 = numStack.Pop();
                        if ("*" == opeStack.Peek()) val = v1 * v2;
                        if ("/" == opeStack.Peek()) val = v1 / v2;
                        numStack.Push(val);
                        opeStack.Pop();
                    }
                    continue;
                }
                if (Ope.Contains(c)) opeStack.Push(c);
                else numStack.Push(Convert.ToDecimal(c));
            }
            while (opeStack.Any())
            {
                if (!numStack.Any()) return -1;
                v2 = numStack.Pop();
                v1 = numStack.Pop();
                var ope = opeStack.Pop();
                if (opeStack.Any() && opeStack.Peek() == "-") ope = "+";
                if ("+" == ope) val = v1 + v2;
                else if ("-" == ope) val = v1 - v2;
                else if ("*" == ope) val = v1 * v2;
                else if ("/" == ope) val = v1 / v2;
                numStack.Push(val);
            }
            return numStack.Any() ? numStack.Pop() : -1;
        }

        private static List<string> GetUnitChar(string expression)
        {
            List<string> uarr = new List<string>();
            if (expression.Trim() == "") return uarr;
            var num = "";
            if ("-" == expression.First().ToString())
            {
                uarr.Add(expression.Substring(0, 2));
                expression = expression.Substring(2);
            }
            else if ("+" == expression.First().ToString())
                expression = expression.Substring(1);
            foreach (var unit in expression)
            {
                if (Ope.Contains(unit.ToString()))
                {
                    if (num != "") uarr.Add(num); num = "";
                    uarr.Add(unit.ToString());
                }
                else
                    num += unit.ToString();
            }
            if (num != "") uarr.Add(num);
            return uarr;
        }
    }
}