namespace SunamoRandom._sunamo.SunamoValues.Constants;

/// <summary>
/// Date and time related constants used across the application.
/// </summary>
internal class DTConstants
{
    /// <summary>
    /// Number of seconds in one minute.
    /// </summary>
    internal const long SecondsInMinute = 60;

    /// <summary>
    /// Number of seconds in one hour.
    /// </summary>
    internal const long SecondsInHour = SecondsInMinute * 60;

    /// <summary>
    /// Number of seconds in one day.
    /// </summary>
    internal const long SecondsInDay = SecondsInHour * 24;

    /// <summary>
    /// Abbreviated English day names (Mon, Tue, etc.).
    /// </summary>
    internal static readonly List<string> DaysInWeekENShortcut = new List<string>(["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"]);

    /// <summary>
    /// Full English day names.
    /// </summary>
    internal static readonly List<string> DaysInWeekEN = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    /// <summary>
    /// Full English month names.
    /// </summary>
    internal static readonly List<string> MonthsInYearEN = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    /// <summary>
    /// The starting year of Unix epoch (1970).
    /// </summary>
    internal const int YearStartUnixDate = 1970;

    /// <summary>
    /// Unix file system start date.
    /// </summary>
    internal static readonly DateTime UnixFsStart = new DateTime(YearStartUnixDate, 1, 1);

    /// <summary>
    /// Czech day names.
    /// </summary>
    internal static readonly List<string> DaysInWeekCS = new List<string> { Pondeli, Utery, Streda, Ctvrtek, Patek, Sobota, Nedele };

    /// <summary>
    /// Unix epoch start (1970-01-01 00:00:00 UTC).
    /// </summary>
    internal static readonly DateTime UnixTimeStartEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Windows epoch start (1601-01-01 01:00:00 UTC).
    /// </summary>
    internal static readonly DateTime WinTimeStartEpoch = new DateTime(1601, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    internal const string Pondeli = "Pond\u011Bl\u00ED";
    internal const string Utery = "\u00DAter\u00FD";
    internal const string Streda = "St\u0159eda";
    internal const string Ctvrtek = "\u010Ctvrtek";
    internal const string Patek = "P\u00E1tek";
    internal const string Sobota = "Sobota";
    internal const string Nedele = "Ned\u011Ble";

    internal const string Leden = "Leden";
    internal const string Unor = "\u00DAnor";
    internal const string Brezen = "B\u0159ezen";
    internal const string Duben = "Duben";
    internal const string Kveten = "Kv\u011Bten";
    internal const string Cerven = "\u010Cerven";
    internal const string Cervenec = "\u010Cervenec";
    internal const string Srpen = "Srpen";
    internal const string Zari = "Z\u00E1\u0159\u00ED";
    internal const string Rijen = "\u0158\u00EDjen";
    internal const string Listopad = "Listopad";
    internal const string Prosinec = "Prosinec";

    /// <summary>
    /// Czech month names.
    /// </summary>
    internal static readonly List<string> MonthsInYearCZ = new List<string> { Leden, Unor, Brezen, Duben, Kveten, Cerven, Cervenec, Srpen, Zari, Rijen, Listopad, Prosinec };
}
