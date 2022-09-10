namespace Website.Models.Interfaces
{
    public interface IContentData
    {
        void addContent(ContentData contentData);
        List<ContentData> GetContent();
        public List<ContentData> GetLatestContent();
        public List<ContentData> GetModernContent();
        public List<ContentData> GetQuranicContent();
    }
}
