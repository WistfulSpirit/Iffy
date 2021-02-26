using System.Collections.Generic;
using Sbt.Test.Refactoring.Units;
using Sbt.Test.Refactoring.Exceptions;


namespace Sbt.Test.Refactoring
{
    public class Map : IMap
    {
        uint width, height;
        List<IUnit> allUnits;
        IPositionable[,] positionableUnits; 
        public Map(uint width, uint height) {
            this.width = width;
            this.height = height;
            positionableUnits = new IPositionable[width+1, height+1];
            allUnits = new List<IUnit>();
        }
        public uint Height { get => height; }
        public uint Width { get => width; }
        public IPositionable[,] PositionableUnits => positionableUnits;
        public virtual void Add(IUnit unit) {
            
            IPositionable positionable = unit as IPositionable;
            if (positionable != null) {
                if (positionableUnits[positionable.Position.X, positionable.Position.Y] == null) {
                    positionableUnits[positionable.Position.X, positionable.Position.Y] = (IPositionable)unit;
                }
                else {
                    throw new PlaceIsNotEmptyException($"Point {positionable.Position} is already occupied");
                }
            }
            allUnits.Add(unit);
        }
    }
}
