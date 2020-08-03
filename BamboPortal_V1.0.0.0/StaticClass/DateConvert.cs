using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public class DateConvert
    {
        /// <summary>
        ///  زمان را به صورت رشته دریافت میکند و به صورت های مختلف تاریخ شمسی تبدیل میکند
        /// </summary>
        /// <param name="date_">زمان به صورت رشته</param>
        /// <param name="DateType">
        /// Date : تاریخ 
        /// Time : زمان
        /// DateTime : تاریخ و زمان به طور کامل
        /// Ago : چند دقیقه ، ساعت یا روز پیش
        /// </param>
        /// <returns>تاریخ تبدیل شده به صورت رشته</returns>
        public string DateReturner(string date_, string DateType)
        {
            DateTime date = Convert.ToDateTime(date_);
            PersianDateTime persianDateTime = new PersianDateTime(date);

            if (DateType == "Date")
            {
                return persianDateTime.ToLongDateString();
            }
            else if (DateType == "Time")
            {
                return persianDateTime.ToLongTimeString();
            }
            else if (DateType == "DateTime")
            {
                return persianDateTime.ToLongDateTimeString();
            }
            else if (DateType == "Ago")
            {
                string LastSeen = "";
                PersianDateTime PerNow = new PersianDateTime(DateTime.Now);
                var dateTest = PerNow.Subtract(persianDateTime);
                if (dateTest.Days < 1)
                {
                    if (dateTest.Hours < 1)
                    {
                        LastSeen = dateTest.Minutes + " دقیقه ی پیش";

                    }
                    else
                    {
                        LastSeen = dateTest.Hours + "ساعت پیش";
                    }
                }
                else
                {
                    LastSeen = dateTest.Days + "روز پیش";
                }
                return LastSeen;

            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// زمان را به صورت تاریخ وزمان دریافت میکند و به صورت های مختلف تاریخ شمسی تبدیل میکند
        /// </summary>
        /// <param name="date_">زمان</param>
        /// <param name="DateType">
        /// Date : تاریخ 
        /// Time : زمان
        /// DateTime : تاریخ و زمان به طور کامل
        /// Ago : چند دقیقه ، ساعت یا روز پیش
        /// </param>
        /// <returns>تاریخ تبدیل شده به صورت رشته</returns>
        public string DateReturner(DateTime date_, string DateType)
        {

            PersianDateTime persianDateTime = new PersianDateTime(date_);

            if (DateType == "Date")
            {
                return persianDateTime.ToLongDateString();
            }
            else if (DateType == "Time")
            {
                return persianDateTime.ToLongTimeString();
            }
            else if (DateType == "DateTime")
            {
                return persianDateTime.ToLongDateTimeString();
            }
            else if (DateType == "Ago")
            {
                string LastSeen = "";
                PersianDateTime PerNow = new PersianDateTime(DateTime.Now);
                var dateTest = PerNow.Subtract(persianDateTime);
                if (dateTest.Days < 1)
                {
                    if (dateTest.Hours < 1)
                    {
                        LastSeen = dateTest.Minutes + " دقیقه ی پیش";

                    }
                    else
                    {
                        LastSeen = dateTest.Hours + "ساعت پیش";
                    }
                }
                else
                {
                    LastSeen = dateTest.Days + "روز پیش";
                }
                return LastSeen;

            }
            else
            {
                return "";
            }
        }

    }
}