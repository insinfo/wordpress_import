using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace WordpressImport
{
    [XmlRoot(ElementName = "author", Namespace = "http://wordpress.org/export/1.2/")]
    public class Author
    {
        [XmlElement(ElementName = "author_id", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_id { get; set; } = "1";
        [XmlElement(ElementName = "author_login", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_login { get; set; } = "admin";
        [XmlElement(ElementName = "author_email", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_email { get; set; } = "leonardomw@gmail.com";
        [XmlElement(ElementName = "author_display_name", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_display_name { get; set; } = "Leonardo Calheiros";
        [XmlElement(ElementName = "author_first_name", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_first_name { get; set; } = "Leonardo";
        [XmlElement(ElementName = "author_last_name", Namespace = "http://wordpress.org/export/1.2/")]
        public string Author_last_name { get; set; } = "Calheiros";
    }

    [XmlRoot(ElementName = "category", Namespace = "http://wordpress.org/export/1.2/")]
    public class Category
    {
        [XmlElement(ElementName = "term_id", Namespace = "http://wordpress.org/export/1.2/")]
        public string Term_id { get; set; }
        [XmlElement(ElementName = "category_nicename", Namespace = "http://wordpress.org/export/1.2/")]
        public string Category_nicename { get; set; }
        [XmlElement(ElementName = "category_parent", Namespace = "http://wordpress.org/export/1.2/")]
        public string Category_parent { get; set; }
        [XmlElement(ElementName = "cat_name", Namespace = "http://wordpress.org/export/1.2/")]
        public string Cat_name { get; set; } = "Notícias";
    }

    [XmlRoot(ElementName = "guid")]
    public class Guid
    {
        [XmlAttribute(AttributeName = "isPermaLink")]
        public string IsPermaLink { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "category")]
    public class Category2
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; } = "category";
        [XmlAttribute(AttributeName = "nicename")]
        public string Nicename { get; set; } = "noticias";
        [XmlText]
        public string Text { get; set; } = "Notícias";
    }

    [XmlRoot(ElementName = "postmeta", Namespace = "http://wordpress.org/export/1.2/")]
    public class Postmeta
    {
        [XmlElement(ElementName = "meta_key", Namespace = "http://wordpress.org/export/1.2/")]
        public string Meta_key { get; set; } = "_edit_last";
        [XmlElement(ElementName = "meta_value", Namespace = "http://wordpress.org/export/1.2/")]
        public string Meta_value { get; set; } = "1";
    }

    [XmlRoot(ElementName = "comment", Namespace = "http://wordpress.org/export/1.2/")]
    public class Comment
    {
        [XmlElement(ElementName = "comment_id", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_id { get; set; }
        [XmlElement(ElementName = "comment_author", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_author { get; set; }
        [XmlElement(ElementName = "comment_author_email", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_author_email { get; set; }
        [XmlElement(ElementName = "comment_author_url", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_author_url { get; set; }
        [XmlElement(ElementName = "comment_author_IP", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_author_IP { get; set; }
        [XmlElement(ElementName = "comment_date", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_date { get; set; }
        [XmlElement(ElementName = "comment_date_gmt", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_date_gmt { get; set; }
        [XmlElement(ElementName = "comment_content", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_content { get; set; }
        [XmlElement(ElementName = "comment_approved", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_approved { get; set; }
        [XmlElement(ElementName = "comment_type", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_type { get; set; }
        [XmlElement(ElementName = "comment_parent", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_parent { get; set; }
        [XmlElement(ElementName = "comment_user_id", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_user_id { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
        [XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }
        [XmlElement(ElementName = "guid")]
        public Guid Guid { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; } = " ";

        [XmlElement(ElementName = "encoded", Namespace = "http://purl.org/rss/1.0/modules/content/")]
        public string Encoded { get; set; }

        [XmlElement(ElementName = "post_id", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_id { get; set; }
        [XmlElement(ElementName = "post_date", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_date { get; set; }
        [XmlElement(ElementName = "post_date_gmt", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_date_gmt { get; set; }
        [XmlElement(ElementName = "comment_status", Namespace = "http://wordpress.org/export/1.2/")]
        public string Comment_status { get; set; }
        [XmlElement(ElementName = "ping_status", Namespace = "http://wordpress.org/export/1.2/")]
        public string Ping_status { get; set; }
        [XmlElement(ElementName = "post_name", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_name { get; set; }
        [XmlElement(ElementName = "status", Namespace = "http://wordpress.org/export/1.2/")]
        public string Status { get; set; }
        [XmlElement(ElementName = "post_parent", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_parent { get; set; }
        [XmlElement(ElementName = "menu_order", Namespace = "http://wordpress.org/export/1.2/")]
        public string Menu_order { get; set; }
        [XmlElement(ElementName = "post_type", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_type { get; set; }
        [XmlElement(ElementName = "post_password", Namespace = "http://wordpress.org/export/1.2/")]
        public string Post_password { get; set; }
        [XmlElement(ElementName = "is_sticky", Namespace = "http://wordpress.org/export/1.2/")]
        public string Is_sticky { get; set; }
        [XmlElement(ElementName = "category")]
        public Category2 Category { get; set; }
        [XmlElement(ElementName = "postmeta", Namespace = "http://wordpress.org/export/1.2/")]
        public List<Postmeta> Postmeta { get; set; }
        [XmlElement(ElementName = "comment", Namespace = "http://wordpress.org/export/1.2/")]
        public List<Comment> Comment { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; } = "Prefeitura de Rio das Ostras";

        [XmlElement(ElementName = "link")]
        public string Link { get; set; } = "https://www.riodasostras.rj.gov.br";

        [XmlElement(ElementName = "description")]
        public string Description { get; set; } = " ";

        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; } = "Mon, 23 Apr 2018 15:09:42 +0000";

        [XmlElement(ElementName = "language")]
        public string Language { get; set; } = "pt-BR";

        [XmlElement(ElementName = "wxr_version", Namespace = "http://wordpress.org/export/1.2/")]
        public string Wxr_version { get; set; } = "1.2";

        [XmlElement(ElementName = "base_site_url", Namespace = "http://wordpress.org/export/1.2/")]
        public string Base_site_url { get; set; } = "https://www.riodasostras.rj.gov.br";

        [XmlElement(ElementName = "base_blog_url", Namespace = "http://wordpress.org/export/1.2/")]
        public string Base_blog_url { get; set; } = "https://www.riodasostras.rj.gov.br";

        [XmlElement(ElementName = "author", Namespace = "http://wordpress.org/export/1.2/")]
        public Author Author { get; set; } = new Author() {
            Author_id ="1",
            Author_login ="admin",
            Author_email = "leonardomw@gmail.com",
            Author_display_name = "Leonardo Calheiros",
            Author_first_name = "Leonardo",
            Author_last_name = "Calheiros"
        };

        [XmlElement(ElementName = "category", Namespace = "http://wordpress.org/export/1.2/")]
        public Category Category { get; set; } = new Category()
        {
            Term_id = "1",
            Category_nicename = "noticias",
            Category_parent = "",
            Cat_name = "Notícias"
        };

        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; } = "https://wordpress.org/?v=4.9.4";

        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; } = "2.0";
        [XmlAttribute(AttributeName = "excerpt", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Excerpt { get; set; } = "http://wordpress.org/export/1.2/excerpt/";
        [XmlAttribute(AttributeName = "content", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Content { get; set; } = "http://purl.org/rss/1.0/modules/content/";
        [XmlAttribute(AttributeName = "wfw", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wfw { get; set; } = "http://wellformedweb.org/CommentAPI/";
        [XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Dc { get; set; } = "http://purl.org/dc/elements/1.1/";
        [XmlAttribute(AttributeName = "wp", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Wp { get; set; } = "http://wordpress.org/export/1.2/";

        public string ToXML()
        {
            var stringwriter = new StringWriter();
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }
        public void SaveToFile(string filePath=@"c:\out.xml")
        {
            File.WriteAllText(filePath, ToXML());
        }

    }

}
