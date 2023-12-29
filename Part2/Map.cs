using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Map
    {
        public char[][] CharMap { get; set; }

        public Map(List<string> lines)
        {
            CharMap = new char[lines.Count()][];

            for (int i = 0; i < lines.Count(); i++)
            {
                CharMap[i] = lines[i].ToCharArray();
            }
        }

        public int GetHorizontalMirror(int targetErrors)
        {
            int mirrorLine = 0;
            for (int row = 1; row < CharMap.Length; row++)
            {
                int errors = 0;
                int top = row - 1;
                int bottom = row;
                while (top >= 0 && bottom < CharMap.Length)
                {
                    for (int col = 0; col < CharMap[row].Length; col++)
                    {
                        if (CharMap[top][col] != CharMap[bottom][col])
                        {
                            errors++;
                        }

                        if (errors > targetErrors)
                            break;
                    }

                    if (errors > targetErrors)
                        break;

                    top -= 1;
                    bottom += 1;
                }

                if (errors == targetErrors)
                {
                    mirrorLine = row;
                    break;
                }
            }

            return mirrorLine;
        }

        public int GetVerticalMirror(int targetErrors)
        {
            int mirrorLine = 0;
            for (int col = 1; col < CharMap[0].Length; col++)
            {
                int errors = 0;
                int left = col - 1;
                int right = col;
                while (left >= 0 && right < CharMap[0].Length)
                {
                    for (int row = 0; row < CharMap.Length; row++)
                    {
                        if (CharMap[row][left] != CharMap[row][right])
                        {
                            errors++;
                        }

                        if (errors > targetErrors)
                            break;
                    }

                    if (errors > targetErrors)
                        break;

                    left -= 1;
                    right += 1;
                }

                if (errors == targetErrors)
                {
                    mirrorLine = col;
                    break;
                }
            }

            return mirrorLine;
        }
    }
}
