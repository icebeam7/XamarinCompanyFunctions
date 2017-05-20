namespace XamarinCompanyFunctions.Model
{
    public class Address
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Coords { get; set; }

        public string AddressDetails
        {
            get
            {
                return string.Format("{0} {1}, {2} {3}", Street, Number, PostalCode, City);
            }
        }
    }
}
