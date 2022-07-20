using System;
using System.Reactive.Concurrency;
using Microsoft.Reactive.Testing;

namespace RxTests.Service;

public class ServiceBuilder
{
    private TimeSpan _timeSpan = TimeSpan.FromSeconds(1);
    private IScheduler _scheduler = new TestScheduler();

    public ServiceBuilder WithTimeSpan(TimeSpan timeSpan)
    {
        _timeSpan = timeSpan;
        return this;
    }

    public ServiceBuilder WithScheduler(IScheduler scheduler)
    {
        _scheduler = scheduler;
        return this;
    }

    public Logic.Service Build() =>
        new (_timeSpan, _scheduler);

    public static implicit operator Logic.Service(ServiceBuilder builder) =>
        builder.Build();
}