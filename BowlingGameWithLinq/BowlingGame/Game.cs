using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        List<int> results = new List<int>();

        public void Roll(int pins)
        {
            results.Add(pins);
        }

        public int Score()
        {
            return results.EndGame().ToFrames().Take(10).Sum(f => f.Sum());
        }
    }

    public static class ListExtensions 
    {
        public static IEnumerable<IEnumerable<int>> ToFrames(this IEnumerable<int> list)
        {
            yield return list.TakeFrame();

            foreach(var frame in list.SkipFrame().ToFrames())
                yield return frame;
        }

        public static IEnumerable<int> TakeFrame(this IEnumerable<int> list)
        {
            if (list.IsSpare() || list.IsStrike())
                return list.Take(3);
            else
                return list.Take(2);
        }

        public static IEnumerable<int> SkipFrame(this IEnumerable<int> list)
        {
            if (list.IsStrike())
                return list.Skip(1);

            return list.Skip(2);
        }

        public static IEnumerable<int> EndGame(this IEnumerable<int> list)
        {
            return list.Concat(new int[21]);
        }

        public static bool IsSpare(this IEnumerable<int> list)
        {
            return list.Take(2).Sum() == 10;
        }

        public static bool IsStrike(this IEnumerable<int> list)
        {
            return list.First() == 10;
        }
    }
}
