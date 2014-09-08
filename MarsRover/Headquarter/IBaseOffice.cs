namespace MarsRover.Headquarter
{
    public interface IBaseOffice
    {
        IBaseOffice Setup(string inputLines);
        IBaseOffice StartNavigate();
        IBaseOffice SendReportEarth();
        string GetRoversInfo();
    }
}