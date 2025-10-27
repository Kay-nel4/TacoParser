using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.2223,-84.503673,Taco Bell Canton...", -84.503673)]
        [InlineData("31.306794,-85.714414,Taco Bell Daleville...", -85.714414)]
        [InlineData("30.392476,-86.498396,Taco Bell Desti...", -86.498396)]
        [InlineData("33.958057,-84.133918,Taco Bell Duluth...", -84.133918)]
        [InlineData("34.658019,-86.482886,Taco Bell Hampton Cov...", -86.482886)]
        [InlineData("34.872024,-86.571043,Taco Bell Meridianvill...", -86.571043)]
        [InlineData("31.447495,-85.657311,Taco Bell Ozar...", -85.657311)]
        [InlineData("30.533164,-87.262229,Taco Bell Pensacola...", -87.262229)]
        [InlineData("33.407997,-84.670408,Taco Bell Sharpsbur...", -84.670408)]
        [InlineData("33.824114,-84.107251,Taco Bell Stone Mountai...", -84.107251)]
        [InlineData("30.427835,-84.220516,Taco Bell Tallahassee...", -84.220516)]
        [InlineData("33.168176,-87.521815,Taco Bell Tuscaloosa...", -87.521815)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        
        
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacobell = new TacoParser();
            //Act
            ITrackable actual = tacobell.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("32.92496,-85.961342,Taco Bell Alexander Cit...", 32.92496)]
        [InlineData("32.609135,-85.479907,Taco Bell Auburn...", 32.609135)]
        [InlineData("33.544403,-85.073656,Taco Bell Carrollton...", 33.544403)]
        [InlineData("32.524378,-84.88839,Taco Bell Columbus...", 32.524378)]
        [InlineData("33.75433,-84.267319,Taco Bell Decatur...", 33.754319)]
        [InlineData("34.679723,-84.487535,Taco Bell East Ellija...", 34.679723)]
        [InlineData("30.357759,-87.163888,Taco Bell Gulf Breez...", 30.357759)]
        [InlineData("33.785605,-85.770014,Taco Bell Jacksonville...", 33.785605)]
        [InlineData("34.019885,-84.528291,Taco Bell Marietta...", 34.019885)]
        [InlineData("34.482976,-87.273815,Taco Bell Moulto...", 34.482976)]
        [InlineData("30.599281,-87.162921,Taco Bell Pac...", 30.599281)]
        [InlineData("33.933808,-85.610591,Taco Bell Piedmont...", 33.933808)]
        [InlineData("33.549829,-84.275044,Taco Bell Stockbridge...", 33.549829)]
        [InlineData("34.8709,-85.519289,Taco Bell Trenton...", 34.8709)]

        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacotime =  new TacoParser();
            //Act
            ITrackable actual = tacotime.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
