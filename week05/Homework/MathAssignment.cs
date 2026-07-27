public class MathAssignment : Assignment
{
    private string _sectionNumber;
    private string _problems;

    public MathAssignment(string studentName, string topic, string sectionNumber, string problems) 
        : base(studentName, topic)
    {
        _sectionNumber = sectionNumber;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_sectionNumber} Problems {_problems}";
    }
}
