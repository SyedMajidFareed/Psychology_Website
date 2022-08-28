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
        public List<ContentData> GetContent()
        {
            ContentData contentData = new ContentData();

            var db = new WebsiteDBContext();
            var query = from data in db.ContentItems select data;
            List<ContentData> list = new List<ContentData>();
            

            foreach (var item in query)
            {

                list.Add(item);
            }
            return list;
         
        }
    }
}
