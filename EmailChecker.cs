using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;

namespace Email
{
    class EmailCheck
    {
        [STAThread]
        static void Main ( string [ ] args )
        {
            string RSSURL = @"https://mail.google.com/mail/feed/atom";
            string info = @"username:password";
            List<string> strArr = new List<string> ( );
           
            ASCIIEncoding encoding = new ASCIIEncoding ( );
            byte [ ] bytes = encoding.GetBytes ( info );
            var encoded = Convert.ToBase64String ( bytes );

            var request = HttpWebRequest.Create ( RSSURL );
            request.Method = "POST";
            request.ContentLength = 0;
            request.Headers.Add ( "Authorization", "Basic " + encoded );

            
                Console.Clear ( );
                var response = request.GetResponse ( );
                System.IO.Stream stream = response.GetResponseStream ( );

                XmlReader xmlread = XmlTextReader.Create ( stream );

                while ( xmlread.Read ( ) == true )
                    if ( xmlread.ReadString ( ) != string.Empty )
                        strArr.Add ( xmlread.ReadString ( ) );

                Console.WriteLine ( "\n Unread emails: " + strArr [ 3 ] );
                
                stream.Close ( );
                xmlread.Close ( );
                Thread.Sleep ( 3000 );
           


         // for ( int x = 0; x < strArr.Count; x++ )
           //     Console.WriteLine ( strArr [ x ] );


                // System.IO.StreamReader strRead = new System.IO.StreamReader ( stream );

                // while (strRead.Peek() != -1)
                // Console.WriteLine(strRead.ReadLine ( ));

                
           // strRead.Close ( );
                     

           
            





        //private List<string> GetRSS()
        //{
        //    List<string> RSSPosts = new List<string>();
        //    XmlTextReader reader;
        //    SyndicationFeed RSSFeed;
        //    try
        //    {
        //        reader = new XmlTextReader(RSSURL);
        //        RSSFeed = SyndicationFeed.Load(reader);

        //        foreach (SyndicationItem Alert in RSSFeed.Items)
        //            RSSPosts.Add(Alert.PublishDate.LocalDateTime.ToString() 
        //                + "    " + Alert.Title.Text.Replace("WarframeAlerts: ", ""));
        //        Error = false;
        //    }
        //    catch
        //    {
        //        if (!Error)
        //            Voice.Speak("Error retrieving alerts");
        //        Error = true;
        //    }
        //    return RSSPosts;
        //}
        }
    }
}
