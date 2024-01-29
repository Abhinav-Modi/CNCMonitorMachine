using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public class AlertNotifier : IObserver
    {
        private readonly IAlertNotifier alertNotifier;
        private static readonly Dictionary<string, DateTime> lastReportedTimestamps = new Dictionary<string, DateTime>();
        public AlertNotifier(IAlertNotifier alertNotifier)
        {
            this.alertNotifier = alertNotifier;

        }

        public void Update(float temperature, float dimension, int duration, byte selfstatuscode, DateTime timestamp)
        {

            CheckAndNotify(temperature, "Temperature", TimeSpan.FromMinutes(30), () => temperature > 35, isMachineObserver: false);
            CheckAndNotify(dimension, "Dimension", TimeSpan.FromMinutes(30), () => dimension > 0.05, isMachineObserver: true);
            CheckAndNotify(duration, "Duration", TimeSpan.FromMinutes(15), () => duration > 6 * 60, isMachineObserver: true);
            CheckAndNotify(selfstatuscode, "SelfTestStatus", TimeSpan.Zero, () => selfstatuscode != 0xFF, isMachineObserver: true);
        }

        private void CheckAndNotify<T>(T data, string dataType, TimeSpan reportingInterval, Func<bool> condition, bool isMachineObserver)
        {
            if (!IsTimeToReport(dataType, reportingInterval) || !condition())
            {
                return;
            }

            IAlert alert = CreateAlert(dataType, data, isMachineObserver);
            Notify(alert);
            lastReportedTimestamps[dataType] = DateTime.Now;
        }

        private IAlert CreateAlert<T>(string dataType, T data, bool isMachineObserver)
        {
            return isMachineObserver
                ? (IAlert)new MachineAlert($"{dataType} alert: {data}")
                : new EnvironmentAlert($"{dataType} alert: {data}.");
        }



        private bool IsTimeToReport(string dataType, TimeSpan reportingInterval)
        {
            if (lastReportedTimestamps == null || !lastReportedTimestamps.ContainsKey(dataType))
            {
                // First time reporting for this type of data, report immediately
                return true;
            }

            DateTime lastReportedTimestamp = lastReportedTimestamps[dataType];
            TimeSpan timeSinceLastReport = DateTime.Now - lastReportedTimestamp;
            return timeSinceLastReport >= reportingInterval;
        }

        public void Notify(IAlert alert)
        {
            alertNotifier.Notify(alert);
        }
    }
}