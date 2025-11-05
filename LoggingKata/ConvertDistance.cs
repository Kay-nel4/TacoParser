namespace LoggingKata;

public class ConvertDistance
//A Class holding a method to call in the main that will properly convert the meters returned to miles.
{
    public static double ConvertMetersToMiles(double distance) 
    {
        return distance / 1609.344;
    }
}