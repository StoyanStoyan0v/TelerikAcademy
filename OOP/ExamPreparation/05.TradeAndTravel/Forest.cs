
namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        public Forest(string name) : base(name,LocationType.Forest,ItemType.Wood,ItemType.Weapon)
        {
            
        }

        public override Item ProduceItem(string name)
        {
            return new Wood(name, null);
        }
    }
}