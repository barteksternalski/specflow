using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace specflowPoC.Helpers
{
    class GmailExtractor
    {
        public static void DeleteMessages()
        {
            ImapClient gmail = new ImapClient();
            gmail.Connect("imap.gmail.com", 993, true);
            gmail.Authenticate("bartavanade@gmail.com", "Infusi0n!");

            var inbox = gmail.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            for (int i = 0; i < inbox.Count; i++) 
            {
                inbox.AddFlags(i, MessageFlags.Deleted, true);
                Console.WriteLine($"Message deleted");
            }
            gmail.Inbox.Expunge();
            gmail.Disconnect(true);
        }

        public static int GetNoOfMessages()
        {
            ImapClient gmail = new ImapClient();
            gmail.Connect("imap.gmail.com", 993, true);
            gmail.Authenticate("bartavanade@gmail.com", "Infusi0n!");

            var inbox = gmail.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            int messagesCount = inbox.Count;

            gmail.Disconnect(true);

            return messagesCount;
        }


        public static string GetPasswordFromLastEmail()
        {
            ImapClient gmail = new ImapClient();
            gmail.Connect("imap.gmail.com", 993, true);
            gmail.Authenticate("bartavanade@gmail.com", "Infusi0n!");

            List<string> password = new List<string>();

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("INFO: Checking email...");
                System.Threading.Thread.Sleep(5000);

                var inbox = gmail.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                foreach (var summary in inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure))
                {
                    
                    if (summary.TextBody != null)
                    {
                        // this will download *just* the text/plain part
                        var text = inbox.GetBodyPart(summary.UniqueId, summary.TextBody);

                        var objRegex = new System.Text.RegularExpressions.Regex("(?<=Password: ).{8}");
                        var objMatch = objRegex.Match(text.ToString());
                        if (objMatch.Success)
                        {
                            password.Add(objMatch.Groups[0].ToString());
                        }
                    }

                    if (summary.HtmlBody != null)
                    {
                        // this will download *just* the text/html part
                        var html = inbox.GetBodyPart(summary.UniqueId, summary.HtmlBody);

                        var objRegex = new System.Text.RegularExpressions.Regex("(?<=Password: ).{8}");
                        var objMatch = objRegex.Match(html.ToString());
                        if (objMatch.Success)
                        {
                            password.Add(objMatch.Groups[0].ToString());
                        }
                    }

                    if (summary.Body is BodyPartMultipart)
                    {
                        var multipart = (BodyPartMultipart)summary.Body;

                        var attachment = multipart.BodyParts.OfType<BodyPartBasic>().FirstOrDefault(x => x.FileName == "logo.jpg");
                        if (attachment != null)
                        {
                            // this will download *just* the attachment
                            var part = inbox.GetBodyPart(summary.UniqueId, attachment);
                        }
                    }
                }
                if (password.Count > 0) break;
            }
            
            gmail.Disconnect(true);
            return password.ElementAt(0);
        }
    }
}
