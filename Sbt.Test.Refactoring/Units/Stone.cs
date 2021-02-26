using System.Drawing;

namespace Sbt.Test.Refactoring.Units
{
    public class Stone : UnitBase, IPositionable
    {
        private Point position; 
        public Stone(Map map, Point position) : base(map)
        {
            this.position = position;
        }

        public Point Position => position;
    }
}
