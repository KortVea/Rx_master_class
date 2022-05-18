using System;
using System.Reactive.Concurrency;
using Microsoft.Reactive.Testing;

namespace RxTests;

public static class TestSchedulerExtension
{
    public static void AdvanceMinimal(this TestScheduler scheduler)
    {
        scheduler.AdvanceBy(TimeSpan.FromMilliseconds(100).Ticks);
    }
}