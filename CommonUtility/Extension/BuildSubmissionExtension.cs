using System.Threading.Tasks;
using Microsoft.Build.Execution;

namespace CommonUtility.Extension
{
    public static class BuildSubmissionExtension
    {
        public static Task<BuildResult> ExecuteAsync(this BuildSubmission buildSubmission)
        {
            var taskCompletionSource = new TaskCompletionSource<BuildResult>();
            buildSubmission.ExecuteAsync(BuildSubmissionCompleteCallbackFunction, taskCompletionSource);
            return taskCompletionSource.Task;
        }

        private static void BuildSubmissionCompleteCallbackFunction(BuildSubmission submission)
        {
            var taskCompletionSource = (TaskCompletionSource<BuildResult>) submission.AsyncContext;
            taskCompletionSource.SetResult(submission.BuildResult);
        }
    }
}