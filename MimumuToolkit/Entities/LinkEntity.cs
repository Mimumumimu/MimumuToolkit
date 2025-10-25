namespace MimumuToolkit.Entities
{
    public class LinkEntity
    {
        public string Title { get; private set; }
        public object? LinkData { get; set; }
        public string Remarks { get; private set; }

        public LinkEntity(string title, string url, string remarks)
        {
            Title = title;
            LinkData = url;
            Remarks = remarks;
        }
    }
}
