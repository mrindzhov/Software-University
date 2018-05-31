using System;
class DateModifier
{
    public long daysDifference;
    public string date1;
    public string date2;
    public DateModifier(string date1, string date2)
    {
        this.date1 = date1;
        this.date2 = date2;
    }
    public double CountDifference()
    {
        DateTime dateFirst = ConvertToDateTime(this.date1);
        DateTime dateSecond = ConvertToDateTime(this.date2);
        TimeSpan difference =dateFirst - dateSecond;
        var daysDiff = Math.Abs(difference.TotalDays);
        return daysDiff;
    }
    public static DateTime ConvertToDateTime(string input)
    {
        var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var date = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));

        return date;
    }


}
class Program
{
    static void Main(string[] args)
    {
        var diff = new DateModifier(Console.ReadLine(),Console.ReadLine());
        Console.WriteLine(diff.CountDifference());
    }
}
