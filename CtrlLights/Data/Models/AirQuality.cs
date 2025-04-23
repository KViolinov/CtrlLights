namespace CtrlLights.Data.Models
{
    public class AirQuality
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public int EspDeviceId { get; set; }
        public EspDevice EspDevice { get; set; }
    }
}
