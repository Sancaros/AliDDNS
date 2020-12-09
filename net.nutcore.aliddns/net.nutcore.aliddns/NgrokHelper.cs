using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace net.nutcore.aliddns
{
    internal class NgrokHelper
    {
        private static readonly string ngrokExecutable = "ngrok.exe";
        private static readonly string ngrokYamlConfig = "ngrok.cfg";
        public static readonly string currentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string ngrokExecutableFile = Path.Combine(currentDirectory, ngrokExecutable);
        public static readonly string ngrokConfigFile = Path.Combine(currentDirectory, ngrokYamlConfig);
        private static string localHost = "localhost:4040";
        public Config ngrokConfig = new Config();

        public NgrokHelper()
        {
            if (!File.Exists(ngrokConfigFile))
            {
                this.CreateDefaultConfig(ngrokConfigFile);
                this.Load();
            }
            else
            {
                FileInfo filereader = new FileInfo(ngrokConfigFile);
                if (filereader.Length == 0)
                {
                    this.CreateDefaultConfig(ngrokConfigFile);
                }
                this.Load();
            }
        }

        public class Config
        {
            public string authtoken { get; set; }
            public string server_addr { get; set; }
            public string region { get; set; }
            public bool console_ui { get; set; }
            public string log_level { get; set; }
            public string log_format { get; set; }
            public string log { get; set; }
            public string web_addr { get; set; }
            public bool trust_host_root_certs { get; set; }
            public bool run_website { get; set; }
            public bool run_tcp { get; set; }
            //public Tunnel tunnels { get; set; }
            public object tunnels { get; set; }
        }

        public class Tunnel
        {
            public Protocol weisite { get; set; }
            public Protocol tcp { get; set; }
        }

        public class Protocol
        {
            public Proto proto { get; set; }
            public int remote_port { get; set; }
            public string subdomain { get; set; }
            public string auth { get; set; }
        }

        public class Proto
        {
            public int http { get; set; }
            public int https { get; set; }
            public int tcp { get; set; }
        }

        public class Response
        {
            public JsonTunnel[] tunnels { get; set; }
        }

        public class JsonTunnel
        {
            public string name { get; set; }
            public string public_url { get; set; }
            public string proto { get; set; }
        }

        public void CreateDefaultConfig(String ngrokConfigFile)
        {
            var config = new Config();
            config.authtoken = string.Empty;
            config.server_addr = "tunnels.ngrok.io:4443";
            config.console_ui = true;
            config.region = "us";
            config.log_level = "info";
            config.log_format = "logfmt";
            config.log = "ngrok.log";
            config.web_addr = "localhost:4040";
            config.trust_host_root_certs = false;
            config.run_website = true;
            config.run_tcp = true;
            Protocol tunnel0 = new Protocol { proto = new Proto { http = 80 }, subdomain = "web1" };
            Protocol tunnel1 = new Protocol { proto = new Proto { https = 443 }, subdomain = "web1" };
            Protocol tunnel2 = new Protocol { proto = new Proto { tcp = 21 }, remote_port = 8021 };
            Protocol tunnel3 = new Protocol { proto = new Proto { tcp = 3306 }, remote_port = 8306 };
            Protocol tunnel4 = new Protocol { proto = new Proto { tcp = 3389 }, remote_port = 8389 };
            Protocol tunnel5 = new Protocol { proto = new Proto { tcp = 9000 }, remote_port = 8900 };
            config.tunnels = new { item0 = tunnel0, item1 = tunnel1, item2 = tunnel2, item3 = tunnel3, item4 = tunnel4, item5 = tunnel5 };

            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(config);
            File.WriteAllText(ngrokConfigFile, yaml);
        }

        public bool IsExists()
        {
            return File.Exists(ngrokExecutableFile);
        }

        public Response GetResponse()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    var content = web.DownloadString($"http://{localHost}/api/tunnels");
                    return JsonConvert.DeserializeObject<NgrokHelper.Response>(content);
                }
            }
            catch
            {
                return null;
            }
        }

        public void Load()
        {
            var yaml = File.ReadAllText(ngrokConfigFile);
            var deserializer = new Deserializer();
            this.ngrokConfig = deserializer.Deserialize<Config>(yaml); 
        }

        public void Save()
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(this.ngrokConfig);
            File.WriteAllText(ngrokConfigFile, yaml);
        }

        public void Start(int code = 0)
        {
            var exec = new ProcessStartInfo();
            exec.WorkingDirectory = currentDirectory;
            exec.FileName = ngrokExecutable;
            exec.CreateNoWindow = true;
            exec.UseShellExecute = false;
            exec.Arguments = $"-config \"{ngrokYamlConfig}\" start-all ";

            try
            {
                new Thread(()=>
                {
                    try
                    {
                        var proc = Process.Start(exec);
                        proc.WaitForExit();
                        proc.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ngrok start running error：" + ex.ToString());
                        Console.WriteLine(ex.Message);
                    }
                }).Start();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("Ngrok start running error：" + ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            try
            {
                new Thread(() =>
                {
                    try
                    {
                        Process[] pList = Process.GetProcessesByName("Ngrok");
                        foreach (Process p in pList)
                        {
                            Console.WriteLine($"Kill: {p.Id}");
                            p.Kill();
                            p.WaitForExit();
                            p.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ngrok start running error：" + ex.ToString());
                        Console.WriteLine(ex.Message);
                    }
                }).Start();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("Ngrok stop running error：" + ex.ToString());
                Console.WriteLine(ex.Message);
            }

        }
    }
}
