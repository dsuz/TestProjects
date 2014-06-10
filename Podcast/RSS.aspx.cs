using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ServiceModel.Syndication;
using System.Xml;

/*
http://deepumi.wordpress.com/2010/03/14/create-rss-2-0-and-atom-1-0-in-asp-net-3-5-csharp/

http://ja.wikipedia.org/wiki/%E3%83%9D%E3%83%83%E3%83%89%E3%82%AD%E3%83%A3%E3%82%B9%E3%83%88
*/

namespace Podcast
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/rss+xml";
            SyndicationFeed syndicationFeed = SyndicationHelper.GetSyndycationHelper();
            if ( syndicationFeed != null && syndicationFeed.Items.Count() > 0 )
            {
                Rss20FeedFormatter formatter = new Rss20FeedFormatter(syndicationFeed);
                XmlWriter writer = XmlWriter.Create(Response.Output, null);
                formatter.WriteTo(writer);
                writer.Flush();
            }
        }
    }

    public class Blog
    {
        //public Int32 BlogId { get; set; }
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public static List<Blog> GetMyBlogList()
        {
            //System.IO.FileInfo[] files = GetFiles(@"e:\Radio").ToArray();
            //System.IO.FileInfo[] files = GetFiles(@"\\\\dsuzuki2\d$\Radio").ToArray();
            System.IO.FileInfo[] files = GetFiles(HttpContext.Current.Server.MapPath("./Files/").ToString()).ToArray();

            List<Blog> entries = new List<Blog>(files.Count());
            
            //int i = 0;
            Blog entry = new Blog();

            foreach (System.IO.FileInfo file in files)
            {
                entries.Add(
                    new Blog
                    {
                        //BlogId = i + 1,
                        //BlogId = @"http://localhost/RadioFiles/" + file.Name,
                        BlogId = (new Uri(HttpContext.Current.Request.Url, "./Files/" + file.Name)).ToString(),
                        Title = System.IO.Path.GetFileNameWithoutExtension(file.Name),
                        Description = "",
                        //Url = @"http://localhost/RadioFiles/" + file.Name,
                        Url = (new Uri(HttpContext.Current.Request.Url, "./Files/" + file.Name)).ToString(),
                        CreateDate = file.CreationTime,
                        LastUpdated = file.LastWriteTime
                    }
                );
                //i++;
            }

            /*
            List<Blog> oBlogList = new List<Blog>
            {


                new Blog{
                    BlogId = 1,
                    Title = "Title 1",
                    Description = "Description 1",
                    Url = "http://localhost/WebApplication1/files/吉田照美 ソコダイジナトコ 20101231 full.m4a",
                    CreateDate = DateTime.Now,
                    LastUpdated = DateTime.Now.AddDays(1)
                },
                new Blog{
                    BlogId = 2,
                    Title = "Title 2",
                    Description = "Description 2",
                    Url = "http://localhost/WebApplication1/files/青山繁晴　ニュースの見方　Dec 29.mp3",
                    CreateDate = DateTime.Now,
                    LastUpdated = DateTime.Now.AddDays(1)
                }
            };
             */
            return entries;
        }

        static IEnumerable<System.IO.FileInfo> GetFiles(string startPath)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startPath);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*", System.IO.SearchOption.TopDirectoryOnly);
            IEnumerable<System.IO.FileInfo> sortedFi;

            try
            {
                sortedFi =
                    (
                        from file in fileList
                        let lastModified = GetFileCreatedDate(file)
                        //where file.Name != "web.config"             // exclude web.config
                        where file.Extension.ToLower() == ".mp3" || file.Extension.ToLower() == ".m4a"    // audio files
                        orderby lastModified descending
                        select file
                    ).Take(20);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error: possibly file not found. Check the exception...");
                //Console.WriteLine(e.ToString());
                throw;
            }

            return sortedFi;
        }

        static DateTime GetFileCreatedDate(System.IO.FileInfo fi)
        {
            DateTime ret;

            try
            {
                ret = fi.CreationTime;
            }
            catch (Exception e)
            {
                ret = DateTime.MinValue;
            }

            return ret;
        }

        static DateTime GetFileLastModified(System.IO.FileInfo fi)
        {
            DateTime ret;

            try
            {
                ret = fi.LastWriteTime;
            }
            catch (Exception e)
            {
                ret = DateTime.MinValue;
            }

            return ret;
        }
    }

    public static class SyndicationHelper
    {
        public static SyndicationFeed GetSyndycationHelper()
        {
            //Uri uri = new Uri("http://localhost/WebApplication1/");
            SyndicationFeed syndicationFeed = new SyndicationFeed(
                "AAA ラジオ",
                "",
                //uri,
                null,
                "",
                DateTime.Now);
            List<SyndicationItem> items = new List<SyndicationItem>();
            List<Blog> oBlogList = Blog.GetMyBlogList();
            foreach (Blog oBlog in oBlogList)
            {
                SyndicationItem oItem = new SyndicationItem(
                    oBlog.Title,
                    SyndicationContent.CreateHtmlContent(oBlog.Description),
                    new Uri(oBlog.Url),
                    oBlog.BlogId.ToString(),
                    oBlog.LastUpdated);
                SyndicationLink syndicationLink =
                    SyndicationLink.CreateMediaEnclosureLink(new Uri(oBlog.Url), "audio/mpeg", 0);
                oItem.Links.Add(syndicationLink);
                items.Add(oItem);
            }
            syndicationFeed.Items = items;
            return syndicationFeed;
        }
    }
}

