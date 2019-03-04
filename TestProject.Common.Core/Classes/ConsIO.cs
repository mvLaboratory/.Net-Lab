﻿
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace TestProject.Common.Core.Classes
{
    public static class ConsIO
    {
        /// <summary>
        /// Gets or sets the height of the console window area.
        /// </summary>
        public static int WindowHeight
        {
            get { return Console.WindowHeight; }
            set
            {
                Console.WindowHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the console window.
        /// </summary>
        public static int WindowWidth
        {
            get { return Console.WindowWidth; }
            set
            {
                Console.WindowWidth = value;
            }
        }

        /// <summary>
        /// Writes the text representation of the specified value or values to the standard output stream.
        /// </summary>
        /// <param name="s">Required parameter. Can be ""</param>
        /// <param name="obj">Optional array of objects to write using s</param>
        public static void Write(string s, params object[] obj)
        {
            Console.Write(s, obj);
        }
        /// <summary>
        /// Writes the specified data, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="s">Your string.</param>
        /// <param name="obj">Optional array of objects to write using s</param>
        public static void WriteLine(string s, params object[] obj)
        {
            Console.WriteLine(s, obj);
        }
        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        public static void WriteLine()
        {
            Console.WriteLine();
        }


        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>String The next line of characters from the input stream,
        /// or null if no more lines are available.</returns>
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns>Int32 The next character from the input stream, or negative one(-1)
        /// if there are currently no more characters to be read.</returns>
        public static int Read()
        {
            return Console.Read();
        }

        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left">The column position of the cursor. Columns are numbered from left to right starting at 0.</param>
        /// <param name="top">The row position of the cursor. Rows are numbered from top to bottom starting at 0.</param>
        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left,top);
        }

        /// <summary>
        /// Checks entered value do we want to break current task.
        /// </summary>
        /// <param name="s">Entered string from the outstream</param>
        public static void CheckForExitTask(ref string s)
        {
            if ((s.ToLower() == "q") | (s.ToLower() == "b"))
            {
                Environment.Exit(0);
            }
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ClearBottom(ref int offsetBottom)
        {
            StringBuilder sb = new StringBuilder();
            SetCursorPosition(0, WindowHeight - offsetBottom);
            for (int i = 0; i < offsetBottom-1; i++)
            {
                for (int j = 0; j < WindowWidth; j++)
                {
                    sb.Append(" ");
                }
                if (i<offsetBottom-1)
                {
                    //sb.Append("\n");
                }
            }
            Write(sb.ToString());
            SetCursorPosition(0, WindowHeight - offsetBottom);
        }
    }
}
