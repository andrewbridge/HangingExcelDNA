﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangingExcelDNA
{
    using System.Diagnostics;

    using ExcelDna.Integration;

    using FakeApiClient;
    using FakeApiClient.ResponseTypes;

    /*
    public class Commands
    {
        //static Commands()
        //{
        //    ThreadPool.SetMinThreads(200, 200);
        //}

        private static int longCallCount = 0;

        [ExcelFunction(Name = "hangexcel_long", Description = "Do a long async call")]
        public static object LongRun(string name, DateTime when)
        {
            return ExcelAsyncUtil.Run(
                "LongRun",
                new object[] { name, when },
                delegate
                    {
                        DebugTaskStart("LongRun");
                        var request = new DetailsRequest { Name = name, Date = when };
                        var client = new FakeCallsClient();
                        // Vary long calls
                        var response = (longCallCount % 2 == 0 ? client.GetColoursTooSlowlyAsync(request) : client.GetColoursVerySlowlyAsync(request)).GetAwaiter().GetResult();
                        longCallCount++;
                        return "Hello " + name + " on " + when.ToShortDateString();
                    });
        }

        [ExcelFunction(Name = "hangexcel_med", Description = "Do a medium async call")]
        public static object MediumRun(string name, DateTime when)
        {
            return ExcelAsyncUtil.Run(
                "MediumRun",
                new object[] { name, when },
                delegate
                    {
                        DebugTaskStart("MediumRun");
                        var request = new DetailsRequest { Name = name, Date = when };
                        var client = new FakeCallsClient();
                        var response = client.GetColoursSlowlyAsync(request).GetAwaiter().GetResult();
                        return "On the fence " + name + " on " + when.ToShortDateString();
                    });
        }

        [ExcelFunction(Name = "hangexcel_short", Description = "Do a short async call")]
        public static object ShortRun(string name, DateTime when)
        {
            return ExcelAsyncUtil.Run(
                "ShortRun",
                new object[] { name, when },
                delegate
                    {
                        DebugTaskStart("ShortRun");
                        var request = new DetailsRequest { Name = name, Date = when };
                        var client = new FakeCallsClient();
                        var response = client.GetColoursAsync(request).GetAwaiter().GetResult();
                        return "Goodbye " + name + " on " + when.ToShortDateString();
                    });
        }

        [ExcelFunction(Name = "hangexcel_spam", Description = "Spam lots of calls")]
        public static object SpamCalls(string name, DateTime when)
        {
            return ExcelAsyncUtil.Run(
                "SpamCalls", 
                new object[] { name, when },
                delegate
                    {
                        DebugTaskStart("SpamCalls");
                        var request = new DetailsRequest { Name = name, Date = when };
                        var client = new FakeCallsClient();
                        Task.WhenAll(new Task[]
                                             {
                                                 client.GetColoursAsync(request),
                                                 client.GetColoursSlowlyAsync(request),
                                                 client.GetColoursVerySlowlyAsync(request),
                                                 client.GetColoursTooSlowlyAsync(request),
                                                 client.GetColoursAsync(request),
                                                 client.GetColoursSlowlyAsync(request),
                                                 client.GetColoursVerySlowlyAsync(request),
                                                 client.GetColoursTooSlowlyAsync(request),
                                                 client.GetColoursAsync(request),
                                                 client.GetColoursSlowlyAsync(request),
                                                 client.GetColoursVerySlowlyAsync(request),
                                                 client.GetColoursTooSlowlyAsync(request),
                                                 client.GetColoursAsync(request),
                                                 client.GetColoursSlowlyAsync(request),
                                                 client.GetColoursVerySlowlyAsync(request),
                                                 client.GetColoursTooSlowlyAsync(request),
                                                 client.GetColoursAsync(request),
                                                 client.GetColoursSlowlyAsync(request),
                                                 client.GetColoursVerySlowlyAsync(request),
                                                 client.GetColoursTooSlowlyAsync(request)
                                             }).GetAwaiter().GetResult();
                        return "All complete";
                    });
        }

        static void DebugTaskStart(string name)
        {
            Debug.WriteLine($"Task start: {name} on {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
    */
    public class AsyncCommands
    {
        private static int longCallCount = 0;

        [ExcelFunction(Name = "hangexcel_long", Description = "Do a long async call")]
        public static async Task<object> LongRun(string name, DateTime when)
        {
            DebugTaskStart("LongRun");
            var request = new DetailsRequest { Name = name, Date = when };
            var client = new FakeCallsClient();
            // Vary long calls
            var response = await (longCallCount % 2 == 0 ? client.GetColoursTooSlowlyAsync(request) : client.GetColoursVerySlowlyAsync(request));
            longCallCount++;
            return "Hello " + name + " on " + when.ToShortDateString();
        }

        [ExcelFunction(Name = "hangexcel_med", Description = "Do a medium async call")]
        public static async Task<object> MediumRun(string name, DateTime when)
        {
            DebugTaskStart("MediumRun");
            var request = new DetailsRequest { Name = name, Date = when };
            var client = new FakeCallsClient();
            var response = await client.GetColoursSlowlyAsync(request);
            return "On the fence " + name + " on " + when.ToShortDateString();
        }

        [ExcelFunction(Name = "hangexcel_short", Description = "Do a short async call")]
        public static async Task<object> ShortRun(string name, DateTime when)
        {
            DebugTaskStart("ShortRun");
            var request = new DetailsRequest { Name = name, Date = when };
            var client = new FakeCallsClient();
            var response = client.GetColoursAsync(request).GetAwaiter().GetResult();
            return "Goodbye " + name + " on " + when.ToShortDateString();
        }

        [ExcelFunction(Name = "hangexcel_spam", Description = "Spam lots of calls")]
        public static async Task<object> SpamCalls(string name, DateTime when)
        {
            DebugTaskStart("SpamCalls");
            var request = new DetailsRequest { Name = name, Date = when };
            var client = new FakeCallsClient();
            await Task.WhenAll(new Task[]
                                    {
                                            client.GetColoursAsync(request),
                                            client.GetColoursSlowlyAsync(request),
                                            client.GetColoursVerySlowlyAsync(request),
                                            client.GetColoursTooSlowlyAsync(request),
                                            client.GetColoursAsync(request),
                                            client.GetColoursSlowlyAsync(request),
                                            client.GetColoursVerySlowlyAsync(request),
                                            client.GetColoursTooSlowlyAsync(request),
                                            client.GetColoursAsync(request),
                                            client.GetColoursSlowlyAsync(request),
                                            client.GetColoursVerySlowlyAsync(request),
                                            client.GetColoursTooSlowlyAsync(request),
                                            client.GetColoursAsync(request),
                                            client.GetColoursSlowlyAsync(request),
                                            client.GetColoursVerySlowlyAsync(request),
                                            client.GetColoursTooSlowlyAsync(request),
                                            client.GetColoursAsync(request),
                                            client.GetColoursSlowlyAsync(request),
                                            client.GetColoursVerySlowlyAsync(request),
                                            client.GetColoursTooSlowlyAsync(request)
                                    });
            return "All complete";
        }

        static void DebugTaskStart(string name)
        {
            Debug.WriteLine($"Task start: {name} on {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
