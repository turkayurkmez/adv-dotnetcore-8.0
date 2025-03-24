namespace CustomMiddleware.Middlewares
{
    public class ApiMonitoringOption
    {
        /// <summary>
        /// Yavaş sayılacak isteklerin eşik değeri (ms)
        /// </summary>
        public int SlowRequestsThresholds { get; set; }

        /// <summary>
        /// İsteğin body'sinin loglanıp loglanmayacağı
        ///</summary> 
        public bool LogRequestBody { get; set; }

        /// <summary>
        /// Yanıtın body'sinin loglanıp loglanmayacağı
        /// </summary>
        public bool LogResponseBody { get; set; }

        /// <summary>
        /// Loglanacak maksimum karakter sayısı
        /// </summary>
        public int MaxLogLength { get; set; } = 4000;
    }
}
