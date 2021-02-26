using System.Drawing;

namespace Sbt.Test.Refactoring.Units
{
    public interface IUnit {
        IMap Map { get; }
    }
    public interface IPositionable : IUnit { 
        Point Position { get;}
    }
    public interface IMoveable : ITurnable, IPositionable {
        Point Move(int step);
        Point Move();
    }

    public interface ITurnable : IUnit {
        Orientation Orientation { get; }
        Orientation Turn(TurnDirection turnDirection);
        Orientation Turn();
    }

    public static class IMoveableHelper {
        public static Point MoveDefault(this IMoveable obj, int step) {
            var tempPos = obj.Position;
            var tempOrientation = obj.Orientation;
            if (tempOrientation == Refactoring.Orientation.North) tempPos.Y += step;
            else if (tempOrientation == Refactoring.Orientation.East) tempPos.X += step;
            else if (tempOrientation == Refactoring.Orientation.South) tempPos.Y -= step;
            else if (tempOrientation == Refactoring.Orientation.West) tempPos.X -= step;
            return tempPos;
        }
    }

    public static class ITurnableHelper {
        public static Orientation TurnDefault(this ITurnable obj, TurnDirection turnDirection)
        {
            return turnDirection == TurnDirection.Clockwise ? obj.Orientation.Next() : obj.Orientation.Previous();
        }
    }
}
