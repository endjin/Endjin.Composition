namespace System.Threading.Tasks
{
    public class TaskHelper
    {
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var task = new Task<TResult>(() => result);
            task.RunSynchronously();
            return task;
        }
    }
}