namespace Hair.Domain.Entities
{
    public class HaircutPriceEntity
    {
        public double Hair { get; set; }
        public double? Beard { get; set; }
        public double? Mustache { get; set; }
        public HaircutPriceEntity(double hair, double? beard, double? mustache)
        {
            Hair = hair;
            Beard = beard;
            Mustache = mustache;
        }
    }
}
