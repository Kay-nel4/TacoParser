namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Parsing...");
            // Splitting each line from the Taco Bell CSV file into seperate cells seperated by a ,.
            var cells = line.Split(',');

            // A notification of error if the Split method returns less than 3 cells.
            if (cells.Length < 3)
            {
                // Print error message and return null if cells equal less than 3.
                logger.LogError($"Invalid line: {line}");
                return null; 
            }
            
            //Created an in instance of latitude from cells array that will start at 0.
            double lat = double.Parse(cells[0]);
            
            
            //Created an instance of longitude from the same cells array that will start at 1.
            double lon = double.Parse(cells[1]);
            
            
            //Created a name instance from the cells array that will start at 2.
            var name = cells[2];

            //New instance of the Point struct that will properly set the latitude and longitude.
            Point location = new Point
            {
                Latitude = lat,
                Longitude = lon
            };
            
            //Created a TacoBell class to hold the name and location, this class conforms to the ITrackable Interface.
            //Created an instance of the Taco Bell class.
           TacoBell tacoBell = new TacoBell(name, location);
           tacoBell.Name = name;
           tacoBell.Location = location;

            return tacoBell;
        }
    }
}
