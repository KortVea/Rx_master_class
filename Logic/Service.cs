using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Logic;

public class Service: IService
{
    public IObservable<int> GetData { get; }

    public Service(TimeSpan interval, IScheduler scheduler)
    {

        this.GetData = Observable
            .Interval(interval, scheduler)
            .Select(Convert.ToInt32)
            .Take(10, scheduler);
    }
}

public interface IService
{
    IObservable<int> GetData { get; }
}