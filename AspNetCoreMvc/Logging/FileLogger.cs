namespace AspNetCoreMvc.Logging
{
    public class FileLogger
    {
        public static void Log(string methodname, string message)
        {
            string docPath = Environment.CurrentDirectory + "\\wwwroot\\Logs\\";

            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            string fileName = $"log_{DateTime.Now:dd_MM_yyyy}.txt";

            string[] lines = { $"DATE: {DateTime.Now:dd - MM - yyyy HH: mm}", "METHOD: " + methodname,
                "MESSAGE: " + message, "---------------------------------", Environment.NewLine };


            File.AppendAllLines(docPath + fileName, lines);
        }

        public static void LogHttpRequest(string sentjson, string receivejson)
        {
            string docPath = Environment.CurrentDirectory + "\\wwwroot\\Logs\\";

            if (!Directory.Exists(docPath)) Directory.CreateDirectory(docPath);

            string fileName = $"httplog_{DateTime.Now:MM_yyyy}.txt";

            string[] lines = { $"DATE: {DateTime.Now:dd - MM - yyyy HH: mm}", $"SENTJSON: {sentjson}",
                $"RECEIVEJSON: {receivejson}", "---------------------------------", Environment.NewLine };

            File.AppendAllLines(docPath + fileName, lines);
        }
    }
}
