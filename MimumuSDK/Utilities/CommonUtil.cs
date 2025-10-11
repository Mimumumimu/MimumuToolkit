using Discord;
using MimumuSDK.Utilities.Discord;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MimumuSDK.Utilities
{
    public class CommonUtil
    {
        public static async Task SendNtfy(string key, string title, string value)
        {
            string escapedTitle = title.Replace("\"", "\\\"");
            string escapedValue = value.Replace("\"", "\\\"");

            StringBuilder args = new StringBuilder();
            args.AppendFormat("ntfy.sh/{0} ", key);
            args.AppendFormat("-H \"Title:{0}\" ", escapedTitle);
            args.AppendFormat("-d \"{0}\" ", escapedValue);
            // スマホ側で画像とurlは対応していなかった……
            //args.AppendFormat("-H \"Click:{0}\" ", "http://www.google.com");
            //args.AppendFormat("-H \"Attach:{0}\" ", "https://www.google.co.jp/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");

            ProcessStartInfo processStartInfo = new ProcessStartInfo("curl", args.ToString())
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                await process.WaitForExitAsync();
            }
        }

        public static void SendDiscord(string key, string title, string value, string userName = "")
        {
            var hook = new DiscordWebhook
            {
                Url = key
            };

            var message = new DiscordMessage
            {
                Username = userName,
                //message.TTS = true;
                Content = value
            };

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    hook.Send(message);
                }
                catch
                {
                    Thread.Sleep(1000);
                    continue;
                }
                break;
            }
        }

        public static void SpeakText(string value, int speed = 0, int volume = 100)
        {
            Task.Run(() =>
            {
                try
                {
                    // PowerShellプロセスを起動
                    ProcessStartInfo processStartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = "-NoProfile -ExecutionPolicy Bypass -Command -", // 標準入力からコマンドを読み取る
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true
                    };

                    using (Process powerShellProcess = new Process())
                    {
                        powerShellProcess.StartInfo = processStartInfo;
                        powerShellProcess.Start();

                        using (StreamWriter powerShellStreamWriter = powerShellProcess.StandardInput)
                        {
                            // System.Speechアセンブリをロード
                            powerShellStreamWriter.WriteLine("Add-Type -AssemblyName System.Speech;");
                            powerShellStreamWriter.Flush();

                            // ボリュームと速度を制限
                            volume = Math.Clamp(volume, 0, 100);
                            speed = Math.Clamp(speed, -10, 10);

                            string escapedValue = value.Replace("\"", "\\\"");
                            string script = $"$synth = New-Object System.Speech.Synthesis.SpeechSynthesizer; $synth.Volume = {volume}; $synth.Rate = {speed}; $synth.Speak(\"{escapedValue}\");";

                            // PowerShellにコマンドを送信
                            powerShellStreamWriter.WriteLine(script);
                            powerShellStreamWriter.Flush();
                        }

                        powerShellProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error speaking message: {ex.Message}");
                }
            });
        }

        public static List<string> GetPhysicalAddress()
        {
            var results = new List<string>();
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var adapter in interfaces)
            {
                if (adapter.OperationalStatus == OperationalStatus.Up &&
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Unknown &&
                    adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    PhysicalAddress address = adapter.GetPhysicalAddress();
                    // MACアドレスが存在しない場合をチェック
                    if (address.ToString() != "000000000000")
                    {
                        results.Add(address.ToString());
                    }
                }
            }

            return results;
        }

    }
}
