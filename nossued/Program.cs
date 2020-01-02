using System;
using System.Threading;
using IctBaden.Stonehenge3.Hosting;
using IctBaden.Stonehenge3.Kestrel;
using IctBaden.Stonehenge3.Resources;
using IctBaden.Stonehenge3.Vue;

namespace nossued
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@"nossued website");

            // client framework (use Vue.js)
            var vue = new VueResourceProvider();
            var provider = StonehengeResourceLoader.CreateDefaultLoader(vue);

            // options
            var options = new StonehengeHostOptions
            {
                Title = "NOSSUED",
                StartPage = "home",
                ServerPushMode = ServerPushModes.LongPolling,
                PollIntervalMs = 5000
            };

            // hosting
            var host = new KestrelHost(provider, options);
            if (!host.Start("localhost", 32000))
            {
                Console.WriteLine(@"Failed to start server on: " + host.BaseUrl);
                Environment.Exit(1);
            }

            // wait for user pressing Ctrl+C to terminate
            var terminate = new AutoResetEvent(false);
            Console.CancelKeyPress += (sender, eventArgs) => { terminate.Set(); };
            Console.WriteLine(@"Started server on: " + host.BaseUrl);
            terminate.WaitOne();
            Console.WriteLine(@"Server terminated.");
            host.Terminate();
        }
    }
}