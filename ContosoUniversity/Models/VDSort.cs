namespace ContosoUniversity.Models
{
    public class VDSort
    {
        public enum_ColumnStudent Column { get; set; } = enum_ColumnStudent.ID;

        public enum_SortType Order { get; set; } = enum_SortType.None;

        public string Filter { get; set; } = string.Empty;
        //*************************************************************************************************************
        public string Glyph()
        {
            string result =
                this.Order switch
                {
                    enum_SortType.Asc => "&#8595;",
                    enum_SortType.Desc => "&#x2191;",
                    _ => ""
                };


          
            return result;
        }
        //*************************************************************************************************************
        /// <summary>
        /// преобразува колоната в число - get заявка при филтриране
        /// </summary>
        /// <returns></returns>
        public int IntegerColumn()
        {
            return (int)this.Column;
        }
        //*************************************************************************************************************
        /// <summary>
        /// преобразува реда в число - get заявка при филтриране
        /// </summary>
        /// <returns></returns>
        public int IntegerOrder()
        {
            return (int)this.Order;
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
        /// <summary>
        /// колоната в числов вид
        /// </summary>
        /// <returns></returns>
        public int IntegerColumnID()
        {
            return (int)enum_ColumnStudent.ID;
        }
        //*************************************************************************************************************
        /// <summary>
        /// колоната в числов вид
        /// </summary>
        /// <returns></returns>
        public int IntegerColumnFName()
        {
            return (int)enum_ColumnStudent.FName;
        }
        //*************************************************************************************************************
        /// <summary>
        /// колоната в числов вид
        /// </summary>
        /// <returns></returns>
        public int IntegerColumnLName()
        {
            return (int)enum_ColumnStudent.LName;
        }
        //*************************************************************************************************************
        /// <summary>
        /// колоната в числов вид
        /// </summary>
        /// <returns></returns>
        public int IntegerColumnEDate()
        {
            return (int)enum_ColumnStudent.EDate;
        }

        //*************************************************************************************************************
        /// <summary>
        /// сортиране по подразбиране за следващата колона
        /// </summary>
        /// <returns></returns>
        public int IntegerAsc()
        {
            return (int)enum_SortType.Asc;
        }

        //*************************************************************************************************************

        /// <summary>
        /// следващо възможно сортиране
        /// </summary>
        /// <returns></returns>
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
