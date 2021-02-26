namespace Sbt.Test.Refactoring.Units
{
    public class Wind : UnitBase, ITurnable
    {
        private Orientation orientation;
        public Wind(Map map, Orientation orientation) : base(map) {
            this.orientation = orientation;
        }

        public Orientation Orientation => orientation;

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
