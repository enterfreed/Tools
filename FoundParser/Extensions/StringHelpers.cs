namespace FoundParser.Extensions;

public static class StringHelpers
{
    public static bool IsStartsWithNum(string str, out int number)
    {
        var trimmedStr = str.Trim('(', ' ');
        
        int index = trimmedStr.IndexOf(':');
        
        if (index != -1)
        {
            string substringNum = trimmedStr.Substring(0, index);

            if (!int.TryParse(substringNum, out number))
            {
                throw new Exception("Ваши строки не числа");
            }

            return true;
        }

        number = -1;
        return false;
    }

    public static string GetClearedString(string str)
    {
        string cutString = str;
        
        if (str.Contains('('))
        {
            int endIndex = str.IndexOf('(');
            cutString = str.Substring(0, endIndex).Replace('<', ' ').Replace('>', ' ').Trim();
        }
        return cutString;
    }
}