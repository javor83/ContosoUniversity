namespace ContosoUniversity.Models
{
    public class VDSort
    {
        public enum_ColumnStudent Column { get; set; } = enum_ColumnStudent.ID;

        public enum_SortType Order { get; set; } = enum_SortType.None;
        //*************************************************************************************************************
        public string Glyph()
        {
            string result = "";

            if (this.Order == enum_SortType.Asc)
            {
                result = "&#8595;"; 
               
            }
            else
                if (this.Order == enum_SortType.Desc)
                {
                    result = "&#x2191;";
                    
                }
            return result;
        }

        //*************************************************************************************************************

        /// <summary>
        /// ако е false, сортирането е ASC
        /// ако е true , сортирането е по следващото възможно - asc/desc
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CurrentSort(enum_ColumnStudent k)
        {
            return this.Column == k;
        }
        //*************************************************************************************************************
        public int IntegerColumnID()
        {
            return (int)enum_ColumnStudent.ID;
        }
        public int IntegerColumnFName()
        {
            return (int)enum_ColumnStudent.FName;
        }
        public int IntegerColumnLName()
        {
            return (int)enum_ColumnStudent.LName;
        }
        public int IntegerColumnEDate()
        {
            return (int)enum_ColumnStudent.EDate;
        }

        //*************************************************************************************************************
        public int IntegerAsc()
        {
            return (int)enum_SortType.Asc;
        }

        //*************************************************************************************************************

        public int NextOrderType()
        {
            enum_SortType result = enum_SortType.None;

            if (this.Order == enum_SortType.None)
            {
                result = enum_SortType.Asc;
            }
            else

                if (this.Order == enum_SortType.Asc)
                {
                    result = enum_SortType.Desc;

                }
                else
                    if (this.Order == enum_SortType.Desc)
                    {
                        result = enum_SortType.Asc;

                    }

            return (int)result;
        }
        //*************************************************************************************************************
    }
}
