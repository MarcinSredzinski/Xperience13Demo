using BestPDemoSite.Kentico.EventLogWriters;
using CMS;
using CMS.Core;
using Sentry;

[assembly: RegisterImplementation(typeof(IEventLogWriter), typeof(SentryErrorEventWriter))]
namespace BestPDemoSite.Kentico.EventLogWriters
{
    public class SentryErrorEventWriter : IEventLogWriter
    {
        public SentryErrorEventWriter()
        {
        }

        public void WriteLog(EventLogData eventLogData)
        {
            if (eventLogData.EventType > EventTypeEnum.Information)
            {
                SentrySdk.CaptureMessage("Hello Sentry from Event log writer" + eventLogData.EventDescription);
            }
        }
    }
}
