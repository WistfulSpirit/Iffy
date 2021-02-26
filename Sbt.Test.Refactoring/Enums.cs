using System;

namespace Sbt.Test.Refactoring
{
    public enum Orientation
    {
        North,
        East,
        South,
        West
    }
    public enum TurnDirection { 
        Clockwise, 
        CounterClockwise
    }
    public static class Extensions
    {
        public static T Next<T>(this T src) where T : Enum
        {
            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static T Previous<T>(this T src) where T : Enum
        {
            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (-1 == j) ? Arr[Arr.Length-1] : Arr[j];
        }
    }

}
