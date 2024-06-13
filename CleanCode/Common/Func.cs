using CleanCode.Common;
using CsvHelper;
using System.Globalization;
using System.Net;

namespace CleanCode.CommonClass
{
    public static class Func
    {
        public static string GetPathFileSetting()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Common", "setting_client.json");
        }

        public static async Task UpdateValueFileSetting(string key, string value)
        {
            try
            {
                string filePathSetting = GetPathFileSetting();

                dynamic jsonObj = await ReadAllTextFileSetting(filePathSetting);

                jsonObj[key] = value;

                await WriteAllTextFileSetting(filePathSetting, jsonObj);
            }
            catch (Exception ex)
            {
                Log.Error("Func", "UpdateValueFileSetting", ex.Message);
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
                Log.Error("Func", "ReadValueFileSetting", ex.Message);
                return null;
            }
        }

        public static async Task<dynamic?> ReadAllTextFileSetting(string filePathSetting)
        {
            try
            {
                string json = await File.ReadAllTextAsync(filePathSetting);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                return jsonObj;
            }
            catch (Exception ex)
            {
                Log.Error("Func", "ReadAllTextFileSetting", ex.Message);
                return null;
            }
        }

        public static async Task WriteAllTextFileSetting(string filePathSetting, dynamic jsonObj)
        {
            try
            {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                await File.WriteAllTextAsync(filePathSetting, output);
            }
            catch (Exception ex)
            {
                Log.Error("Func", "WriteAllTextFileSetting", ex.Message);
            }
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow.AddHours(7);
        }

        public static async Task SaveExcel(string basePath, string fileName, List<object> data)
        {
            DateTime now = DateTime.Now;

            string directoryPath = Path.Combine(basePath, now.Year.ToString(), now.Month.ToString("D2"), now.Day.ToString("D2"));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                using (var writer = new StreamWriter(Path.Combine(directoryPath, fileName)))

                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(data);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Func", "SaveExcel", ex.Message);
            }
        }

        public static void DownloadImage(string basePath, List<object> imgs)
        {
            DateTime now = DateTime.Now;

            string directoryPath = Path.Combine(basePath, now.Year.ToString(), now.Month.ToString("D2"), now.Day.ToString("D2"));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            try
            {
                using (WebClient client = new())
                {
                    foreach (var item in imgs)
                    {
                        try
                        {
                            client.DownloadFile("https://www.google.com.vn/?hl=vi", Path.Combine(directoryPath, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg"));
                        }
                        catch (WebException ex)
                        {
                            Log.Error("Func-DownloadImage", "Forloop download image", ex.Message);
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Func", "DownloadImage", ex.Message);
            }
        }
    }
}
