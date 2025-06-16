namespace CasCap
{
    public interface IDITestService
    {
        List<int> GetIntValues();
        List<string> GetStringValues();
    }

    /// <summary>
    /// This is a dependency injection test service.
    /// </summary>
    public class DITestService : IDITestService
    {
        public List<int> GetIntValues()
        {
            var now = DateTime.UtcNow;
            return [now.Year, now.Month, now.Day, now.Minute, now.Second];
        }

        public List<string> GetStringValues()
        {
            return [Environment.MachineName, DateTime.UtcNow.ToString()];
        }
    }
}