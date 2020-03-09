namespace SightlyTestTask.Sightly
{
    using System;

    public interface ISightlyClient : IDisposable
    {
        string DownloadPerformanceDetailReport();
    }
}