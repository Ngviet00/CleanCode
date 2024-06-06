using CsvHelper;
using System.Globalization;
using log4net;
using System.Net;

namespace CleanCode.CommonClass
{
    public static class CmFunc
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CmFunc));

        public static string GetPathFileSetting()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileSetting", "setting.json");
        }

        public static async Task<int?> UpdateValueFileSetting(string key, string value)
        {
            try
            {
                string filePathSetting = GetPathFileSetting();

                dynamic jsonObj = await ReadAllTextFileSetting(filePathSetting);

                jsonObj[key] = value;

                await WriteAllTextFileSetting(filePathSetting, jsonObj);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task<string?> ReadValueFileSetting(string key)
        {
            try
            {
                string filePathSetting = GetPathFileSetting();

                dynamic jsonObj = await ReadAllTextFileSetting(filePathSetting);

                string value = jsonObj[key];

                await WriteAllTextFileSetting(filePathSetting, jsonObj);

                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task<dynamic> ReadAllTextFileSetting(string filePathSetting)
        {
            string json = await File.ReadAllTextAsync(filePathSetting);

            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            return jsonObj;
        }

        public static async Task WriteAllTextFileSetting(string filePathSetting, dynamic jsonObj)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

            await File.WriteAllTextAsync(filePathSetting, output);
        }

        public static async Task SaveExcel(string path, List<object> data)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            try
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(data);
                }
            }
            catch (Exception ex)
            {
                Log("CmFunc", "SaveExcel", ex.Message);
            }
        }

        public static void DownloadImage(string path, List<object> imgs)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (WebClient client = new())
                {
                    foreach (var item in imgs)
                    {
                        try
                        {
                            client.DownloadFile("https://www.google.com.vn/?hl=vi", "test.jpg");
                        }
                        catch (WebException)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("CmFunc", "DownloadImage", ex.Message);
            }
        }

        public static void Log(string fileName = "file", string funcName = "function", string err = "err")
        {
            log.Error($"Error can not run program, file: {fileName}, func: {funcName}, error: {err}");
        }

        public static void Log(string msg)
        {
            log.Info($"{msg}");
        }
    }
}
