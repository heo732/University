using System;

namespace MainTool.Utils
{
    public static class GraphPresets
    {
        private static readonly string nl = Environment.NewLine;

        public static string ShortestWay_Preset1 =>
            "1 2 23" + nl +
            "1 5 19" + nl +
            "2 3 13" + nl +
            "2 4 12" + nl +
            "2 5 15" + nl +
            "5 4 8" + nl +
            "5 7 13" + nl +
            "5 8 6" + nl +
            "5 9 13" + nl +
            "4 3 16" + nl +
            "4 9 7" + nl +
            "3 6 22" + nl +
            "3 7 14" + nl +
            "7 6 13" + nl +
            "9 8 6" + nl +
            "6 8 12";

        public static string ShortestWay_Preset2 =>
            "1 2 13" + nl +
            "1 5 13" + nl +
            "1 6 12" + nl +
            "2 3 3" + nl +
            "2 8 22" + nl +
            "2 5 17" + nl +
            "5 4 12" + nl +
            "5 8 19" + nl +
            "5 7 17" + nl +
            "5 9 12" + nl +
            "5 6 9" + nl +
            "6 7 8" + nl +
            "6 9 15" + nl +
            "9 8 3" + nl +
            "7 8 7" + nl +
            "4 3 6" + nl +
            "3 8 13";

        public static string ShortestWay_Preset3 =>
            "1 2 10" + nl +
            "1 4 12" + nl +
            "1 5 21" + nl +
            "2 3 14" + nl +
            "2 4 13" + nl +
            "4 3 11" + nl +
            "4 5 22" + nl +
            "3 5 12" + nl +
            "3 7 17" + nl +
            "5 6 11" + nl +
            "5 10 14" + nl +
            "6 9 18" + nl +
            "7 8 20" + nl +
            "7 10 7" + nl +
            "8 10 22" + nl +
            "8 9 24" + nl +
            "9 10 23";

        public static string ShortestWay_Preset4 =>
            "2 1 4" + nl +
            "2 3 13" + nl +
            "2 7 21" + nl +
            "2 4 25" + nl +
            "1 7 18" + nl +
            "1 3 10" + nl +
            "3 7 18" + nl +
            "3 4 21" + nl +
            "4 6 5" + nl +
            "4 5 19" + nl +
            "4 10 21" + nl +
            "6 7 1" + nl +
            "6 8 1" + nl +
            "6 9 17" + nl +
            "6 10 12" + nl +
            "6 5 23" + nl +
            "5 10 2" + nl +
            "7 8 9" + nl +
            "7 9 15" + nl +
            "9 8 8" + nl +
            "9 10 11";

        public static string ShortestWay_Preset5 =>
            "2 1 6" + nl +
            "2 3 23" + nl +
            "2 5 11" + nl +
            "1 5 7" + nl +
            "3 5 4" + nl +
            "3 4 23" + nl +
            "3 6 9" + nl +
            "4 6 24" + nl +
            "4 8 7" + nl +
            "4 7 3" + nl +
            "4 10 11" + nl +
            "6 8 2" + nl +
            "5 10 4" + nl +
            "7 9 10" + nl +
            "7 10 15" + nl +
            "8 9 20";

        public static string MaxFlow_Preset1 =>
            "1 2 10" + nl +
            "1 3 8" + nl +
            "1 4 7" + nl +
            "2 3 3" + nl +
            "2 4 4" + nl +
            "2 5 5" + nl +
            "2 6 6" + nl +
            "2 7 3" + nl +
            "3 5 10" + nl +
            "4 6 20" + nl +
            "5 7 3" + nl +
            "6 7 6" + nl +
            "6 3 8";

        public static string MaxFlow_Preset2 =>
            "1 2 2" + nl +
            "1 3 6" + nl +
            "2 4 7" + nl +
            "3 4 3" + nl +
            "3 5 4" + nl +
            "4 5 8" + nl +
            "3 6 9" + nl +
            "4 6 10" + nl +
            "4 8 4" + nl +
            "5 7 6" + nl +
            "5 6 2" + nl +
            "6 8 5" + nl +
            "7 8 8";

        public static string MaxFlow_Preset3 =>
            "1 2 7" + nl +
            "1 3 11" + nl +
            "2 3 12" + nl +
            "3 4 8" + nl +
            "3 5 13" + nl +
            "4 5 14" + nl +
            "4 6 15" + nl +
            "4 8 9" + nl +
            "5 7 11" + nl +
            "5 6 7" + nl +
            "6 7 10" + nl +
            "7 8 8" + nl +
            "7 2 12";

        public static string MaxFlow_Preset4 =>
            "1 2 3" + nl +
            "1 5 5" + nl +
            "2 3 7" + nl +
            "2 7 9" + nl +
            "3 4 6" + nl +
            "4 5 12" + nl +
            "4 6 4" + nl +
            "5 6 5" + nl +
            "5 8 8" + nl +
            "6 7 7" + nl +
            "6 8 6" + nl +
            "7 8 11" + nl +
            "7 2 6";

        public static string MaxFlow_Preset5 =>
            "1 2 4" + nl +
            "1 3 8" + nl +
            "1 4 9" + nl +
            "2 3 7" + nl +
            "2 4 5" + nl +
            "2 5 8" + nl +
            "2 6 6" + nl +
            "2 7 4" + nl +
            "4 6 7" + nl +
            "5 7 9" + nl +
            "6 7 5" + nl +
            "6 3 3" + nl +
            "3 7 7";
    }
}