namespace Rent.Service.VoitureAPI.Models.Dto
{
    public class VoitureDto
    {
        public int VoitureId { get; set; }

        public string marque { get; set; }

        public double PriceByDay { get; set; }

        public string CategoryName { get; set; }

        public string ImageURL { get; set; }
    }
}
