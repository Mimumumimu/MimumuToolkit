namespace MimumuToolkit.Entities
{
    public class LinkEntity
    {
        public string Title { get; private set; }
        public string Url { get; private set; }
        public string Remarks { get; private set; }

        public LinkEntity(string title, string url, string remarks)
        {
            Title = title;
            Url = url;
            Remarks = remarks;
        }
    }
}
