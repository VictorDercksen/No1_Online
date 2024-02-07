namespace No1_Online.ViewModels
{
    public class CsvVM
    {
        public string Vrag { get; set; }
        public string LoadNo { get; set; }
        public string Datum { get; set; }
        public string KlientOrderNo { get; set; }
        public string Klient { get; set; }
        public string Laaipunt { get; set; }
        public string Aflaaipunt { get; set; }
        public string Produk { get; set; }
        public string BeginKM { get; set; }
        public string VragKilometers { get; set; }
        public string VragTotal { get; set; }
        public string CPK { get; set; }
        public string TransporterRate { get; set; }
        public string RateVanafKlient { get; set; }
        public string Tonne { get; set; }
        public string Load { get; set; } // Assuming Load is a string in the CSV (e.g., "True" or "False")
    }
}
