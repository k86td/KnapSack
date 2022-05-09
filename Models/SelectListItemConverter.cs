using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KnapSack.Models
{
    public class SelectListItemConverter<T>
    {

        /// <summary>
        /// Convert either a list of strings with automatic values or a list of elements that must contains the members Id and Name
        /// </summary>
        /// <param name="collection"></param>
        /// <returns>SelectList</returns>
        public static SelectList Convert(List<T> collection)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (typeof(T).Name == "String")
            {
                int index = 0;
                foreach (T item in collection)
                {
                    items.Add(
                        new SelectListItem()
                        {
                            Value = index.ToString(),
                            Text = item.ToString()
                        });
                    index++;
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    items.Add(
                        new SelectListItem()
                        {
                            Value = typeof(T).GetProperty("idType").GetValue(item, null).ToString(),
                            Text = typeof(T).GetProperty("nomType").GetValue(item, null).ToString()
                        });
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList Convert(List<T> collection, string defaultValue, string defaultText = "Veuillez faire une sélection")
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (typeof(T).Name == "String")
            {
                int index = 0;
                foreach (T item in collection)
                {
                    items.Add(
                        new SelectListItem()
                        {
                            Value = index.ToString(),
                            Text = item.ToString()
                        });
                    index++;
                }
            }
            else
            {
                foreach (T item in collection)
                {
                    items.Add(
                        new SelectListItem()
                        {
                            Value = typeof(T).GetProperty("Id").GetValue(item, null).ToString(),
                            Text = typeof(T).GetProperty("Name").GetValue(item, null).ToString()
                        });
                }
            }
            items.Insert(0, new SelectListItem { Value = defaultValue, Text = defaultText });
            return new SelectList(items, "Value", "Text");
        }
    }
}