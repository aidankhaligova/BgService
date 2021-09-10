using System;
using System.Threading;
using System.Threading.Tasks;

namespace BgClass
{
    public interface IBgTaskQueue
    {
        void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);
        Task<Func<CancellationToken, Task>> DequeueAsync(
            CancellationToken cancellationToken);
    }
}
