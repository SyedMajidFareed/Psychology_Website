namespace Website.Models.Interfaces
{
    public interface IContentData
    {
        void addContent(ContentData contentData);
        ContentData GetContent(ContentData contentData);
    }
}
