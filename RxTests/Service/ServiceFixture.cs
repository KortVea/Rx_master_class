using System;
using System.Reactive;
using Microsoft.Reactive.Testing;
using RxTests.Extensions;
using Xunit;

namespace RxTests.Service;

public class ServiceFixture
{
    [Fact]
    public void get_data_outputs_10_elements_and_completes()
    {
        var scheduler = new TestScheduler();
        var testObserver = scheduler.CreateObserver<int>();
        var service = new ServiceBuilder()
            .WithTimeSpan(TimeSpan.FromSeconds(1))
            .WithScheduler(scheduler)
            .Build();
        using var sut = service.GetTenNumberAndComplete.Subscribe(testObserver);
        scheduler.AdvanceMinimal();
        Assert.Equal(0, testObserver.Messages.Count);
            
            scheduler.AdvanceBy(TimeSpan.FromSeconds(1).Ticks);
            Assert.Equal(1, testObserver.Messages.Count);
            Assert.Equal(0, testObserver.Messages[0].Value.Value);
            
            scheduler.AdvanceBy(TimeSpan.FromSeconds(1).Ticks);
            Assert.Equal(2, testObserver.Messages.Count);
            Assert.Equal(1, testObserver.Messages[1].Value.Value);
            
            scheduler.AdvanceBy(TimeSpan.FromSeconds(8).Ticks);
            Assert.Equal(11, testObserver.Messages.Count);
            Assert.Equal(9, testObserver.Messages[9].Value.Value);
            Assert.Equal(NotificationKind.OnCompleted, testObserver.Messages[10].Value.Kind);
    }
}

