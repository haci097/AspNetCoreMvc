using System.Text;

namespace AspNetCoreMvc.Utilities
{
    public enum NotificationType
    {
        Success,
        Error,
        Info
    }
    public static class Notification
    {
        public static string BasicNotification(string message, NotificationType type, string title = "")
        {
            return $"Swal.fire('{title}','{message}','{type.ToString().ToLower()}')";
        }
    }
}
