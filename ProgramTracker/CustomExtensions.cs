using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTracker
{
    public static class CustomExtensions
    {
        public static void UpdateOnThread(this Control input, MethodInvoker updates)
        {
            if (input.InvokeRequired)
            {
                input.Invoke(updates);
            }
            else
                updates.Invoke();
        }

        public static string ToPrettyString(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            StringBuilder output = new StringBuilder();
            output.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c) && !char.IsUpper(input[i-1]) && input[i-1] != ' ')
                    output.Append(' ');
                else if (char.IsDigit(input[i]) && !char.IsDigit(input[i-1]))
                    output.Append(' ');

                output.Append(c);
            }

            return output.ToString().Trim();
        }

        public static Dictionary<K, V> Sort<K, V>(this Dictionary<K,V> input)
        {
            var sorted = new Dictionary<K, V>(input.Count);
            var keys = input.Keys.ToList();
            keys.Sort();

            foreach (var key in keys)
            {
                sorted.Add(key, input[key]);
                //input[key] = temp[key];
            }

            return sorted;
        }


        /// <summary>
        /// Example:
        /// 2 days 03:02:01
        /// </summary>
        public static string DurationToString(this TimeSpan ts, bool singleLine=false)
        {
            string txt = "";
            char newLine = (!singleLine) ? '\n' : ' ';

            if (ts.Days == 1)
                txt += $"{ts.Days} day{newLine}";
            else if (ts.Days > 1)
                txt += $"{ts.Days} days{newLine}";

            txt += $"{ts.Hours.ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";

            return txt;
        }

        public static Ctrl_ButtonWithX FilterGroupButton(string text)
        {
            //Button btn = new Button();
            Ctrl_ButtonWithX btn = new Ctrl_ButtonWithX();

            btn.AutoSize = true;
            //btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn.Dock = DockStyle.Left;
            //btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Location = new System.Drawing.Point(0, 0);
            btn.Name = "btn_" + text.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToString();
            btn.Size = new System.Drawing.Size(50, 28);
            //btn.TabIndex = 1;
            btn.ButtonText = text;
            //btn.UseVisualStyleBackColor = true;

            return btn;
        }
    }
}
