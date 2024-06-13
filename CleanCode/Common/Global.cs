namespace Clean_Code
{
    public static class Global
    {
        public static ControlPLC controlPLC = new ControlPLC();

        //15 day
        public static int AUTO_DELETE_IMAGE = 15;

        //15 day
        public static int AUTO_DELETE_EXCEL = 15;

        public static string PATH_SAVE_EXCEL = @"D:\MS_ResultStiffener\StiffenerInspection\Excel";

        public static string PATH_SAVE_IMAGE = @"D:\MS_ResultStiffener\StiffenerInspection\Image";
    }
}
