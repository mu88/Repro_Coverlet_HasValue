namespace Logic;

public static class ServiceExtensions
{
    public static bool IsInPast(this IService service)
    {
        var timeFromService = service.GetTime();
        if (!timeFromService.HasValue) return true;

        var isInPast = timeFromService < TimeOnly.FromDateTime(DateTime.UtcNow);

        return isInPast;
    }
}