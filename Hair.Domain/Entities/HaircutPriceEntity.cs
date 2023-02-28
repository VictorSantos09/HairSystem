namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração dos tipos de corte de cabelo
    /// </summary>
    public class HaircutPriceEntity
    {
        /// <summary>
        /// Valor do corte de cabelo
        /// </summary>
        public double Hair { get; set; }
        /// <summary>
        /// Valor do corte de barba
        /// </summary>
        public double? Beard { get; set; }
        /// <summary>
        /// Valor do corte de bigode
        /// </summary>
        public double? Mustache { get; set; }
        public HaircutPriceEntity(double hair, double? beard, double? mustache)
        {
            Hair = hair;
            Beard = beard;
            Mustache = mustache;
        }

        public HaircutPriceEntity()
        {

        }
    }
}
