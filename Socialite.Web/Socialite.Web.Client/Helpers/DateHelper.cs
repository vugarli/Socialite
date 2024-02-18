using System.Diagnostics;

namespace Socialite.Web.Client.Helpers
{
    public static class DateHelper
    {

        public static string ToReadableDifference(this DateTime dateTime)
        {
            var difference = DateTime.Now - dateTime;

            if (difference.TotalHours < 24)
                return $"{(int)difference.TotalHours} hours";
            else if (difference.TotalDays < 7)
                return $"{(int)difference.TotalDays} days";
            return $"{(int)difference.TotalDays / 7} weeks";
        }


    }
}
