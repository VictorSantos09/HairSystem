namespace Hair.Domain.Entities
{
    public class HaircutePriceEntity
    {
        public double Hair { get; set; }
        public double? Beard { get; set; }
        public double? HairAndBeard { get; set; }
        public double? Mustache { get; set; }

        public HaircutePriceEntity(double hair, double? beard, double? hairAndBeard, double? mustache)
        {
            Hair = hair;
            Beard = beard;
            HairAndBeard = hairAndBeard;
            Mustache = mustache;
        }
    }
}
