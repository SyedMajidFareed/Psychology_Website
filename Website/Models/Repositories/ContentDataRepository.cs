using Website.Models.Interfaces;
namespace Website.Models.Repositories
{
    public class ContentDataRepository : IContentData
    {
        public void addContent(ContentData contentData)
        {
            var db = new WebsiteDBContext();
            db.ContentItems.Add(contentData);
            db.SaveChanges();
        }
        public ContentData GetContent(ContentData contentData)
        {
            var db = new WebsiteDBContext();
            var query = db.ContentItems.Where(u => u.Topic == contentData.Topic);
            if (query.Count() > 0)
            {
                return contentData;
            }
            else
            {
                return null;
            }
        }
    }
}
