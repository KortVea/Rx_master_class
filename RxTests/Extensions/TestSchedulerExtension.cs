using System;
using Microsoft.Reactive.Testing;

namespace RxTests.Extensions;

public static class TestSchedulerExtension
{
    public static void AdvanceMinimal(this TestScheduler scheduler)
    {
        scheduler.AdvanceBy(TimeSpan.FromMilliseconds(100).Ticks);
    }
}