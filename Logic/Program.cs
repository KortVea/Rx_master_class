using System.Reactive.Concurrency;
using Logic;

IScheduler scheduler = NewThreadScheduler.Default;

IService service = new Service(TimeSpan.FromSeconds(1), scheduler);

var business = new Business(service);

Console.Read();