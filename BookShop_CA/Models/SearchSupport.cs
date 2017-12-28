using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_CA.Models
{
    public static class SearchSupport
    {
        private static Mybooks context = new Mybooks();

        public static List<Book> SearchBooks(string input)
        {
            // Clean input
            input = StringConversion(input);

            List<Book> outputBook = new List<Book>();
            Book tempBook;

            List<int> output = FindSearchString(input, 0, 1);
            List<int> num2 = FindSearchString(input, 1, 1);
            List<int> num3 = FindSearchString(input, 0, 3);
            List<int> num4 = FindSearchString(input, 0, 4);

            output.AddRange(num2);
            output.AddRange(num3);
            output.AddRange(num4);

            // Removing any duplicates
            for (int i = 0; i < output.Count(); i++)
            {
                for (int j = i + 1; j < output.Count(); j++)
                {
                    if (output[i] == output[j])
                    {
                        output.RemoveAt(j);
                    }
                }
            }


            // Iterate thru our list of valid BookIDs to retrieve our book objs
            foreach (int item in output)
            {
                tempBook = context.Books.Where(x => x.BookID == item).First();
                outputBook.Add(tempBook);
            }



            return outputBook;
        }

        public static string StringConversion(string x)    //Making given string easily manageable
        {
            //A string array containing unwanted symbols and the like
            string[] c = new string[] { ",", ";", "\'", "\"", "/", ":", "?", " ", "!", "@", "$",
            "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "}", "[", "]", "~", "`", "|"};

            //Converts input into lower chars and trims any spaces behind and back
            string y = x.ToLower().Trim();

            //Replaces any symbols from input into 'nothing' for easier processing
            for (int i = 0; i < c.Length; i++)
            {
                y = y.Replace(c[i], "");
            }

            return y;
        }


        //Search database for the string. y => refers to the table & z => refers to the column of table y to search against.
        public static List<int> FindSearchString(string a, int y, int z) 
        {
            List<int> output = new List<int>();

            MybooksDataset ds = new MybooksDataset();   //Name of your .xsd file to initiate it.

            if (y == 0)
            {
                MybooksDatasetTableAdapters.BookTableAdapter ta = new MybooksDatasetTableAdapters.BookTableAdapter();
                ta.Fill(ds.Book);
                string b;

                for (int j = 0; j < ds.Tables[y].Rows.Count; j++)
                {
                    b = ds.Tables[y].Rows[j][z].ToString();

                    bool check = StringsComparisonTool(a, b);

                    if (check == true && z == 1)
                    {
                        Book c = context.Books.Where(x => x.Title == b).First();
                        output.Add(c.BookID);
                    }
                    else if (check == true && z == 3)
                    {
                        Book c = context.Books.Where(x => x.ISBN == b).First();
                        output.Add(c.BookID);
                    }
                    else if (check == true && z == 4)
                    {
                        Book c = context.Books.Where(x => x.Author == b).First();
                        output.Add(c.BookID);
                    }
                }

                //Return the List
                return output;
            }
            else
            {
                MybooksDatasetTableAdapters.CategoryTableAdapter ta = new MybooksDatasetTableAdapters.CategoryTableAdapter();
                ta.Fill(ds.Category);
                string b;

                for (int j = 0; j < ds.Tables[y].Rows.Count; j++)
                {
                    b = ds.Tables[y].Rows[j][z].ToString();

                    bool check = StringsComparisonTool(a, b);

                    if (check == true)
                    {
                        string aa = ds.Tables[y].Rows[j][0].ToString();

                        MybooksDataset ds1 = new MybooksDataset();
                        MybooksDatasetTableAdapters.BookTableAdapter ta1 = new MybooksDatasetTableAdapters.BookTableAdapter();
                        ta1.Fill(ds1.Book);

                        for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                        {
                            string bb = ds1.Tables[0].Rows[k][2].ToString();

                            bool check2 = StringsComparisonTool(aa, bb);

                            if (check2 == true)
                            {
                                bb = ds1.Tables[0].Rows[k][0].ToString();
                                int bbb = Convert.ToInt32(bb);
                                output.Add(bbb);
                            }
                        }
                    }
                }
                // Return the list
                return output;
            }
        }

        public static bool StringsComparisonTool(string a, string b)   //Checking if the two strings are the same.
        {
            a = StringConversion(a);
            b = StringConversion(b);

            char[] aa = a.ToCharArray();
            char[] bb = b.ToCharArray();

            string newString = "";

            for (int j = 0; j < bb.Length; j++)
            {
                if (aa[0] == bb[j] && bb.Length - j >= a.Length)
                {
                    //This 'for' loop here reconstruct a possibility from string b.
                    for (int k = j; k < j + a.Length; k++)
                    {
                        newString = newString + bb[k];
                    }
                    if (a == newString.ToString()) { return true; }
                    else { newString = ""; }   //This resets the string if it fails.
                }
            }

            return false;
        }






    }
}