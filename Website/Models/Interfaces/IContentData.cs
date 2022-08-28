namespace Website.Models.Interfaces
{
    public interface IContentData
    {
        void addContent(ContentData contentData);
        List<ContentData> GetContent();
    }
}
