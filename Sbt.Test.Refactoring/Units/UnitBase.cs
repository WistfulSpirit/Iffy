namespace Sbt.Test.Refactoring.Units
{
    public abstract class UnitBase : IUnit
    {
        protected Map map;
        public UnitBase(Map map) {
            this.map = map;
        }
        public IMap Map => map;
    }
}
