namespace ListSamples
{
    public class FindCountry
    {
        public FindCountry(string country)
        {
            _country = country;
        }

        private readonly string _country;

        public bool FindCountryPredicate(Racer racer) 
        {
            return racer?.Country == _country;
        } 
    }
}
