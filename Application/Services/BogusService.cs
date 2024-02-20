namespace spark_demo.Application.Services;

public class BogusService
{

    public string returnBogusValue(string fieldValue)
    {
        var returnValue = "";
        var bogus = new Bogus.Faker();

        switch (fieldValue)
        {
            case "Random Full Name":
                returnValue = bogus.Name.FullName();
                break;
            case "Random Job Title":
                returnValue = bogus.Name.JobTitle();
                break;
            case "Random Date":
                returnValue = bogus.Date.Past().ToString();
                break;
            case "Random Int":
                returnValue = bogus.Random.Number().ToString();
                break;
            case "Random Big Int":
                returnValue = bogus.Random.Long().ToString();
                break;
            case "Random Boolean":
                returnValue = bogus.Random.Bool().ToString();
                break;
            case "Random Avatar":
                returnValue = bogus.Internet.Avatar();
                break;
            case "Random Street Address":
                returnValue = bogus.Address.ToString();
                break;
            case "Random Paragraph":
                returnValue = bogus.Lorem.Paragraph();
                break;
            case "Random String":
                returnValue = bogus.Lorem.ToString();
                break;
            default:
                return "";
        }

        return returnValue;

    }

}