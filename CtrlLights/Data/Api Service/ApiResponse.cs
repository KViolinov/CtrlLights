namespace CtrlLights.Data.Api_Service
{
    public class ApiResponse<T>
    {
        public T? TrafficLightsList { get; set; }
        public T? AirQualityList { get; set; }
        public T? AdminUsersList { get; set; }
        public T? EspDevicesList { get; set; }
        public T? User { get; set; }
        public bool? Check { get; set; }
        public string? Message { get; set; }
    }
}
