namespace Console
{
    class Program
    {
        #region --SQL--
        /// <summary>
        /// create table Student ( Id bigint primary key, Name nvarchar(50) )
        /// </summary>
        #endregion
        static void Main(string[] args)
        {
            //TableDataDemo.Run();
            //RowDataDemo.Run();
            ActiveRecordDemo.Run();
            //MapperDemo.Run();
        }

    }
}
