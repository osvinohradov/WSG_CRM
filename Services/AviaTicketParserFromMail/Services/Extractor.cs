using System;
using Microsoft.Office.Interop.Word;

namespace AviaTicketParserFromMail
{
    static class Extractor
    {
        public static string Extract(string name)
        {
            object path = name;
            string result = null;

            Application app = new Application();
            Document doc;
            object missing = Type.Missing;
            object readOnly = true;
            try
            {
                doc = app.Documents.Open(ref path, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                result = doc.Content.Text;
            }
            catch
            {
                throw new Exception("An error occured. Please check the file path to your word document, and whether the word document is valid.");
            }
            finally
            {
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                app.Quit(ref saveChanges, ref missing, ref missing);
            }

            return result;
        }
    }
}
