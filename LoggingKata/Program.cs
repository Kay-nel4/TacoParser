using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized");

            // The File.ReadAllLines will read from the TacoBell-US-AL.csv file.
            //And the logger.LogError will notify if the method ReadAllLines returns empty with an error.
            
            var lines = File.ReadAllLines(csvPath);
            
            if (lines.Length == 0)
            {
                logger.LogError("Error: Empty file");
            }

            // Display the Line at index 0 to show that ReadAllLines is working.
            logger.LogInfo($"Lines: {lines[0]}");

            // Created a new instance of the TacoParser Class that can be called in the main.
            var parser = new TacoParser();

            // The LINQ method .Select will choose all lines in the csv file and parse them to an array called locations.
            var locations = lines.Select(parser.Parse).ToArray();

            // Created two variables from the "ITrackable" interface to hold null values that will later take on the 
            //values of the two Taco Bell locations that will be tested for distance.
            ITrackable bell1 = null;
            ITrackable bell2 = null;
            
            //This is a double variable called distance and initalized to 0 that will hold the distance from bell1 to bell2.
            double distance = 0;
            
            //Will be doing some more studying of the GeoCoordinate Library... Its crazy what you can do with this class! 
            //I will be practicing and creating so much more with it.
            
            // Nested for loops that will loop through the array twice and pull out two Taco Bell locations to compare for distance.

            // FIRST FOR LOOP -
            //This will iterate through the array and grab the first location and assign it to a variable called locA...
            //Then the latitude and longitude will be assigned to a new variable called corA using the method new GeoCoordinate.
            
            //SECOND FOR LOOP -
            //Will sit inside the first for loop and iterate through the same array to find a second Taco Bell location that will then
            //be stored as locB with the latitude and longitude assigned to corB and once again use the GeoCoordinate method.
            //Finally using the GetDistanceTo method corA and corB will be compared and return the two Bells with the greatest distance.
            //These are assigned to bell1 and bell2 and the names will be printed to the console.
            //Pull from the ConvertDistance class and use the ConvertMetersToMiles method and return the final distance as a double
            //rounded to the first decimal in miles.
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;
                
                for (int j = 1; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        bell1 = locA;
                        bell2 = locB;
                    }
                }
            }
            double meters = distance;
            double miles = ConvertDistance.ConvertMetersToMiles(meters);
            logger.LogInfo($"Bell1: {bell1.Name}, Bell2: {bell2.Name}");
            logger.LogInfo($"Distance: {Math.Round(miles, 1)} miles)");
            //meters to miles conversion
            
        }
    }
}
