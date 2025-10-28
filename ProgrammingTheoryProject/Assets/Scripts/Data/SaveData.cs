[System.Serializable]
public class SaveData
{
    public string playerName;
    // public string[] animalsInCare;

    public string catName;
    public int catAge;
    public string catDetails;

    public string dogName;
    public int dogAge;
    public string dogDetails;

    public string chickenName;
    public int chickenAge;
    public string chickenDetails;

    //TODO change below method to serializable list
    public (string name, int age, string details) GetAnimalData(string type)
    {
        switch (type.ToLower())
        {
            case "cat": return (catName, catAge, catDetails);
            case "dog": return (dogName, dogAge, dogDetails);
            case "chicken": return (chickenName, chickenAge, chickenDetails);
            default: return ("Unknown", 0, "No data");
        }
    }
}
