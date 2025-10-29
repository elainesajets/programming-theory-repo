[System.Serializable]
public class SaveData
{
    public string playerName;

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
        return type.ToLower() switch
        {
            "cat" => (catName, catAge, catDetails),
            "dog" => (dogName, dogAge, dogDetails),
            "chicken" => (chickenName, chickenAge, chickenDetails),
            _ => ("Unknown", 0, "No data"),
        };
    }
}
