namespace Clean_Code
{
    public static class Global
    {
        public static ControlPLC controlPLC = new ControlPLC();

        public static string PathFileCurrentModel = @"D:\Projects\Clean_Code\Clean_Code\ClientModel\CurrentModel.txt";
        public static string PathFileListModel = @"D:\Projects\Clean_Code\Clean_Code\ClientModel\ListModels.txt";
        public static string PathFileMode = @"D:\Projects\Clean_Code\Clean_Code\ClientModel\Mode.txt";
        public static string PathFileLogProgram = @"D:\LogProgram\LogProgram.txt";
        public static string PathFileTimeLine = @"D:\Projects\Clean_Code\Clean_Code\ClientModel\TimeLine.txt";
        public static string PathFileHiddenSetting = @"D:\Projects\Clean_Code\Clean_Code\ClientModel\HiddenSetting.txt";
    }
}
