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
        public List<ContentData> GetLatestContent()
        {
            ContentData contentData = new ContentData();

            var db = new WebsiteDBContext();
            var query = from data in db.ContentItems where data.Category == "Latest" select data;
            List<ContentData> list = new List<ContentData>();


            foreach (var item in query)
            {

                list.Add(item);
            }
            return list;

        }
        public List<ContentData> GetModernContent()
        {
            ContentData contentData = new ContentData();

            var db = new WebsiteDBContext();
            var query = from data in db.ContentItems where data.Category == "Modern" select data;

            List<ContentData> list = new List<ContentData>();


            foreach (var item in query)
            {

                list.Add(item);
            }
            return list;

        }
        public List<ContentData> GetQuranicContent()
        {
            ContentData contentData = new ContentData();

            var db = new WebsiteDBContext();
            var query = from data in db.ContentItems where data.Category == "Quranic" select data;

            List<ContentData> list = new List<ContentData>();


            foreach (var item in query)
            {

                list.Add(item);
            }
            return list;

        }
        public List<ContentData> searchContent(string TopicName)
        {
            ContentData contentData = new ContentData();

            var db = new WebsiteDBContext();
            var query = from data in db.ContentItems where data.Topic == TopicName select data;

            List<ContentData> list = new List<ContentData>();


            foreach (var item in query)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
