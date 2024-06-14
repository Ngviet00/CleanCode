namespace CleanCode.Common
{
    public static class Global
    {
        public static ControlPLC controlPLC = new ControlPLC();

        public static int AUTO_DELETE_IMAGE = 20; //day

        public static int AUTO_DELETE_EXCEL = 40; //day

        public static string PATH_SAVE_EXCEL = @"D:\MS_ResultStiffener\StiffenerInspection\Excel";

        public static string PATH_SAVE_IMAGE = @"D:\MS_ResultStiffener\StiffenerInspection\Image";
    }
}
