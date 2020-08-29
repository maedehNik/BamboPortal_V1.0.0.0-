using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.DatabaseCenter.Class
{
    public class AddDataToDataBase
    {

        public string AddData()
        {
            PDBC db = new PDBC();
            db.Connect();

            string Type = db.Script("INSERT INTO [tbl_Product_Type]([PTname],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_PT VALUES(N'پارچه',0,0,GETDATE())");

            string[] SCkeys = { "اسم", "رنگ", "جنس", "نوع شستشو", "مورد مصرف", "واحد فروش" };

            string[] s = { "ابریشم", "بردری", "تور", "تافته", "اورگانزا", "پشمی", "فویلی", "جین", "گاواردین", "مخمل", "چرم", "شانل", "وال", "جوت", "لاکرا", "گیپور", "ژرسه", "کرپ", "کتان", "نخی", "حریر", "شانتون", "آستری", "میکرو", "ژاکارد", "یاخما", "عبایی", "تدی", "لمه", "فاستونی", "ساتن", "غواصی", "چادری", "هندی", "مجلسی", "دانتل", "پولکی" };

            for (int i = 0; i < s.Length; i++)
            {
                db.Script("INSERT INTO [tbl_Product_MainCategory]([id_PT],[MCName],[ISDESABLED],[ISDelete])VALUES("+Type+",N'"+s[i]+"',0,0)");
            }
//////////////////////////////////////////////////////////////////////////
            string T1 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'ابریشم'").Rows[0][0].ToString();
            string[] s1 = { "تافته", "وایوم", "شانتون", "ساری", "4S ساده", "4S طرحدار", "سوزن دوزی", "جنگلی", "کریستال", "کلاسیک", "سیلک ساده" };

            for (int i = 0; i < s1.Length; i++)
            {
               string sc=db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T1+",N'"+s1[i]+"',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES("+sc+",N'"+SCkeys[j]+"',0,0,GETDATE())");
                }
            }

//////////////////////////
            string T2 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'بردری'").Rows[0][0].ToString();
            string[] s2 = { "چاپی", "حاشیه", "سوزن دوزی" };

            for (int i = 0; i < s2.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T2 + ",N'" + s2[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
//////////////////////////

            string T3 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'تور'").Rows[0][0].ToString();
            string[] s3 = { "پولکی", "سنگ دوزی", "سوزن دوزی", "خامه دوزی", "هولوگرامی", "مخمل" };

            for (int i = 0; i < s3.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T3 + ",N'" + s3[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T4 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'تافته'").Rows[0][0].ToString();
            string[] s4 = { "کریستال", "کلاسیک", "سوزن دوزی", "لمه", "پشت ساتن", "دیور", "سوییسی", "دونخ", "ابریشم خام", "4S ساده", "4S طرحدار" };

            for (int i = 0; i < s4.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T4 + ",N'" + s4[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T5 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'اورگانزا'").Rows[0][0].ToString();
            string[] s5 = { "ساده", "ژاکارد", "سوزن دوزی", "طرحدار" };

            for (int i = 0; i < s5.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T5 + ",N'" + s5[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T6 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'پشمی'").Rows[0][0].ToString();
            string[] s6 = { "تویید", "کجرا", "جودون", "افکت دار", "مولتی", "کشمیر", "اسکوبا", "فوتر", "کچه", "فرانل", "آنقوره" };

            for (int i = 0; i < s6.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T6 + ",N'" + s6[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T7 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'فویلی'").Rows[0][0].ToString();
            string[] s7 = { "هولوگرامی", "اویلی"};

            for (int i = 0; i < s7.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T7 + ",N'" + s7[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T8 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'جین'").Rows[0][0].ToString();
            string[] s8 = { "ساده", "کشی" };

            for (int i = 0; i < s8.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T8 + ",N'" + s8[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T9 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'گاواردین'").Rows[0][0].ToString();
            string[] s9 = { "کش", "ساده", "چهارخونه", "راه راه", "فاستونی" };

            for (int i = 0; i < s9.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T9 + ",N'" + s9[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T10 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'مخمل'").Rows[0][0].ToString();
            string[] s10 = { "کبریتی", "کش", "لمه", "آینه ای", "پشت کتون", "ونوس" };

            for (int i = 0; i < s10.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T10 + ",N'" + s10[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T11 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'چرم'").Rows[0][0].ToString();
            string[] s11 = { "لیزرکات", "پشت جیر", "ساده" };

            for (int i = 0; i < s11.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T11 + ",N'" + s11[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T12 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'شانل'").Rows[0][0].ToString();
            string[] s12 = { "ساده", "لمه", "پشم", "حرارتی", "رفلکتیو" };

            for (int i = 0; i < s12.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T12 + ",N'" + s12[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T13 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'وال'").Rows[0][0].ToString();
            string[] s13 = { "پشمی", "سوزن دوزی", "اوریون", "راه راه", "پارمیرا", "کوپرا", "کوپر", "بوندینگ", "NC ساده", "NC کریشه", "لیندور", "لیندور پلاس", "بابوس", "سوییسی", "کش" };

            for (int i = 0; i < s13.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T13 + ",N'" + s13[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T14 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'جوت'").Rows[0][0].ToString();
            string[] s14 = { "لمه", "سوزن دوزی" };

            for (int i = 0; i < s14.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T14 + ",N'" + s14[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T15 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'لاکرا'").Rows[0][0].ToString();
            string[] s15 = { "کش", "پوست ماری" };

            for (int i = 0; i < s15.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T15 + ",N'" + s15[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T16 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'گیپور'").Rows[0][0].ToString();
            string[] s16 = { "کتان بردری", "ساده", "گل برجسته", "فرانسه" };

            for (int i = 0; i < s16.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T16 + ",N'" + s16[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T17 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'ژرسه'").Rows[0][0].ToString();
            string[] s17 = { "لمه بوندینگ", "لمه کش", "لمه ابر و بادی" };

            for (int i = 0; i < s17.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T17 + ",N'" + s17[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////


            string T18 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'کرپ'").Rows[0][0].ToString();
            string[] s18 = { "اسکاچی ساده", "اسکاچی طرحدار", "حریر", "جودون", "دوبل", "کشی", "کریشه", "لمه", "کنزو", "باربی", "BM", "ژرسه", "نخ", "مازراتی", "ژورژت", "ژولیت فرانسه", "مانی", "شانی" };

            for (int i = 0; i < s18.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T18 + ",N'" + s18[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////

            string T19 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'کتان'").Rows[0][0].ToString();
            string[] s19 = { "کریستال", "ابریشم ساده", "ابریشم طرحدار", "ابریشم کوک دوزی", "بردری", "سوزن دوزی", "زارا", "کاپشنی", "کریشه", "بارونی", "نخ", "گاواردین", "ترک", "ژاپن", "کره", "کش ساده", "کش طرحدار", "کش گلدار" };

            for (int i = 0; i < s19.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T19 + ",N'" + s19[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////

            string T20 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'نخی'").Rows[0][0].ToString();
            string[] s20 = { "شانتون", "باتیستا چروک", "باتیستا ساده", "باتیستا جین", "لینن پلیسه", "لینن کریشه", "لینن مولتی", "لینن سوپر لینن", "لینن راه راه", "لینن اسلپ", "لینن هند", "لینن ترک", "لینن ژاکارد", "لینن لمه", "لینن اصل هند", "لینن آپشنز", "لینن پیورترک", "لینن تنظیف", "لینن دونخ", "لینن شانتون", "لینن مولتی کالر", "لینن پیگمنت", "لینن سوزن دوزی", "لینن وال", "سوزن دوزی", "باتیک", "گاتاباتیک", "مادپرینت", "ویسکوز NC", "ویسکوز کریشه", "سوپر کراش", "سوپر کروز", "ملانژ", "کریشه", "میکرو", "شیمر", "کدری", "پوپلین", "برماندو", "KBC" };

            for (int i = 0; i < s20.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T20 + ",N'" + s20[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////

            string T21 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'حریر'").Rows[0][0].ToString();
            string[] s21 = { "پلیسه", "سیدان", "سوزن دوزی", "مخمل", "خامه دوزی", "موجی", "پم پم", "بامبو", "اورگانزا", "ابریشم", "لمه", "گلدار", "پلنگی", "ساده" };

            for (int i = 0; i < s21.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T21 + ",N'" + s21[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////
          
            string T22 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'شانتون'").Rows[0][0].ToString();
            string[] s22 = { "یاخما", "پابانا", "تایوان", "اندونزی", "کره", "چین", "ابریشم", "لمه", "بلوک", "تایلندی", "کاترینا", "نخ لمه دار", "وال" };

            for (int i = 0; i < s22.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T22 + ",N'" + s22[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            ///////////////////////////
            string T23 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'آستری'").Rows[0][0].ToString();
            string[] s23 = { "پونژه", "OK", "سارژ", "طرحدار", "ساده", "کش" };

            for (int i = 0; i < s23.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T23 + ",N'" + s23[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T24 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'میکرو'").Rows[0][0].ToString();
            string[] s24 = { "جیر", "بارونی", "ابریشم", "بوندینگ" };

            for (int i = 0; i < s24.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T24 + ",N'" + s24[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T25 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'ژاکارد'").Rows[0][0].ToString();
            string[] s25 = { "ترک", "ترک هانتاش", "ترک کوتون", "گلیمی", "لمه ترک", "اروپایی بومباردو", "اروپایی اترو", "اروپایی سعید کوبیسی", "اروپایی کادنا فرانسه", "اروپایی هانری ساده", "اروپایی هانری پفکی" };

            for (int i = 0; i < s25.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T25 + ",N'" + s25[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T26 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'یاخما'").Rows[0][0].ToString();
            string[] s26 = { "کسمه", "برنارد", "راه راه" };

            for (int i = 0; i < s26.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T26 + ",N'" + s26[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T27 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'عبایی'").Rows[0][0].ToString();
            string[] s27 = { "زبرا", "راه راه", "ساده" };

            for (int i = 0; i < s27.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T27 + ",N'" + s27[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T28 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'تدی'").Rows[0][0].ToString();
            string[] s28 = { "ببعی", "کوتاه", "بلند", "پله ای", "طرحدار" };

            for (int i = 0; i < s28.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T28 + ",N'" + s28[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T29 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'لمه'").Rows[0][0].ToString();
            string[] s29 = { "کش", "ساده", "راه راه", "پلیسه" };

            for (int i = 0; i < s29.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T29 + ",N'" + s29[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T30 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'فاستونی'").Rows[0][0].ToString();
            string[] s30 = { "ساده", "راه راه", "پرنس دوگال", "پیردوپل", "مطهری", "عالیجناب", "جامعه", "دورمیل انگلیس", "موسکینو ایتالیا", "SUPER S 120", "SUPER S 150", "کش", "چهارخونه", "ویسکوز", "پشمی" };

            for (int i = 0; i < s30.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T30 + ",N'" + s30[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T31 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'ساتن'").Rows[0][0].ToString();
            string[] s31 = { "ساده", "طرحدار", "گلدار", "ابریشم", "استات", "مرلین", "ماردین", "مازراتی", "10000", "9000", "8000", "پشت نخ", "مات", "براق", "کش", "سیلک" };

            for (int i = 0; i < s31.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T31 + ",N'" + s31[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T32 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'غواصی'").Rows[0][0].ToString();
            string[] s32 = { "ریون ساده", "ریون طرحدار", "ژرسه ساده", "ژرسه طرحدار", "تریکو ساده", "تریکو طرحدار", "تریکو نازک", "تریکو ضخیم", "تریکو دورس", "تریکو سوزدمیر" };

            for (int i = 0; i < s32.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T32 + ",N'" + s32[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T33 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'چادری'").Rows[0][0].ToString();
            string[] s33 = { "مشکی ساده", "مشکی گلدار", "عروس نخ ابریشم", "عروس ابریشم", "عروس حریر گل مخمل", "عروس نقره کوب", "عروس لمه دار", "گدار" };

            for (int i = 0; i < s33.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T33 + ",N'" + s33[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T34 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'هندی'").Rows[0][0].ToString();
            string[] s34 = { "نخی", "ابریشم", "تافته", "سوزن دوزی", "دیجیتال", "بردری" };

            for (int i = 0; i < s34.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T34 + ",N'" + s34[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T35 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'مجلسی'").Rows[0][0].ToString();
            string[] s35 = { "کریستال دوزی", "کار دست", "مروارید دوزی", "سنگ دوزی" };

            for (int i = 0; i < s35.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T35 + ",N'" + s35[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }

            //////////////////////////
            string T36 = db.Select("SELECT [id_MC] FROM [tbl_Product_MainCategory] WHERE [MCName] LIKE N'دانتل'").Rows[0][0].ToString();
            string[] s36 = { "ساده", "کش", "گل برجسته", "فرانسه", "پولکی ساده", "هفت رنگ", "کش" };

            for (int i = 0; i < s36.Length; i++)
            {
                string sc = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete],[CreatedDate]) output inserted.id_SC VALUES(" + T36 + ",N'" + s36[i] + "',0,0,GETDATE())");

                for (int j = 0; j < SCkeys.Length; j++)
                {
                    db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete],[CreatedDate]) VALUES(" + sc + ",N'" + SCkeys[j] + "',0,0,GETDATE())");
                }
            }
            db.DC();
            //////////////////////////
            return "Success";
        }
    }
}