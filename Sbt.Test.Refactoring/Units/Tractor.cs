using System.Drawing;
using Sbt.Test.Refactoring.Exceptions;

namespace Sbt.Test.Refactoring.Units
{
    public class Tractor : UnitBase, IMoveable
    {
        private Point position;
        private Orientation orientation;
        public Tractor(Map map, Point position, Orientation orientation) : base(map) {
            this.position = position;
            this.orientation = orientation;
        }
        public Orientation Orientation => orientation;
        public Point Position => position; 

        public virtual Point Move(int step) {
            position = this.MoveDefault(step);
            if (position.X >= map.Width || position.X < 0 || position.Y >= map.Height || position.Y < 0)
                throw new TractorInDitchException();
            return position;
        }
        public virtual Point Move() {
            return Move(1);
        }

        public virtual Orientation Turn(TurnDirection turnDirection)
        {
            orientation = this.TurnDefault(turnDirection);
            return orientation;
        }

        public virtual Orientation Turn()
        {
            return Turn(TurnDirection.Clockwise);
        }
    }
}
