namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        protected GatheringLocation(string name, LocationType locType, ItemType gatheredItemType, ItemType requiredItemType) : base(name,locType)
        {
            this.GatheredType = gatheredItemType;
            this.RequiredItem = requiredItemType;
        }

        public ItemType GatheredType { get; protected set; }


        public ItemType RequiredItem { get; protected set; }


        public abstract Item ProduceItem(string name);
    }
}