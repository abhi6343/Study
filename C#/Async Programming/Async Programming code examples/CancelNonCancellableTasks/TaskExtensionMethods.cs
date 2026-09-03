namespace CancelNonCancellableTasks
{
    public static class TaskExtensionMethods
    {
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var TCoS = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (cancellationToken.Register(state => { ((TaskCompletionSource<object>)state).TrySetResult(null); }, TCoS))
            {
                var resultTask = await Task.WhenAny(task, TCoS.Task);
                if (resultTask == TCoS.Task)
                {
                    throw new OperationCanceledException(cancellationToken);
                }
                return await task;
            };
        }
    }
}
