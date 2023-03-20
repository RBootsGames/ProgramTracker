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

        /// <summary></summary>
        /// <returns>Returns true if item was addedd successfully.</returns>
        public static bool AddWithoutDupes<T>(this List<T> input, T item)
        {
            if (input.Contains(item))
                return false;
            else
            {
                input.Add(item);
                return true;
            }
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

        /// <summary>
        /// Checks parents recursively and grabs the nearest parent of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentLevel">The number of times a parent of type <typeparamref name="T"/> needs to be found.</param>
        /// <returns></returns>
        public static T GetParentOfType<T>(this Control input, int parentLevel=1) where T : Control
        {
            T correctParent = null;
            Control tempParent = input.Parent;
            while (tempParent != null && parentLevel > 0)
            {
                //Console.WriteLine(tempParent.GetType);
                if (tempParent is T)
                {
                    correctParent = (T)tempParent;
                    parentLevel--;
                }
                else
                    tempParent = tempParent.Parent;
            }

            return correctParent;
        }
    }
}
