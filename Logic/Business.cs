using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Logic;

public class Business : IDisposable
{
    private readonly IService service;
    private CompositeDisposable disposables = new();

    public Business(IService service)
    {
        this.service = service;

        this.disposables.Add(
            this
                .service
                .GetTenNumberAndComplete
                .Do(this.ServicedResult)
                .Subscribe(i => Console.WriteLine($"{i}"),
                    () => Console.WriteLine("Completed")));
    }

    public void ServicedResult(int input)
    {
        // where the monad ends
    }


    public void Dispose()
    {
        this.disposables.Dispose();
    }
}