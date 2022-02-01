namespace IssueTracker
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
