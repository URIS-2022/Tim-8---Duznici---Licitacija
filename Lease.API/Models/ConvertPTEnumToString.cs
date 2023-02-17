using Lease.API.Enums;

namespace Lease.API.Models;

public class ConvertPTEnumToString
{

    public  List<string> ConvertEnumToString(List<PriorityType> list)
    {

        var dict = new Dictionary<PriorityType, string>
{
     { PriorityType.None, "Nije dodeljeno" },
    { PriorityType.Irrigation, "Ima sistem za navodnjavanje" },
    { PriorityType.Border, "Granici se sa zemljistem" },
    { PriorityType.Registry, "Upisan u registar" },
    { PriorityType.Location, "Najblize zemljistu" },
};

        List<string> prioritiesString = new List<string>();

        foreach (PriorityType l in list)
        {

            prioritiesString.Add(dict[l]);

        }

        return prioritiesString;
    }
}


