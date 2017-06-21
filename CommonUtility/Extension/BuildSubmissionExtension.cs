using Microsoft.Build.Execution;
using System.Threading.Tasks;

namespace CommonUtility.Extension
{
    static public class BuildSubmissionExtension
    {
        static public Task<BuildResult> ExecuteAsync(this BuildSubmission buildSubmission)
        {
            var taskCompletionSource = new TaskCompletionSource<BuildResult>();
            buildSubmission.ExecuteAsync(BuildSubmissionCompleteCallbackFunction, taskCompletionSource);
            return taskCompletionSource.Task;
        }

        private static void BuildSubmissionCompleteCallbackFunction(BuildSubmission submission)
        {
            var taskCompletionSource = (TaskCompletionSource<BuildResult>)submission.AsyncContext;
            taskCompletionSource.SetResult(submission.BuildResult);
        }
    }
}
