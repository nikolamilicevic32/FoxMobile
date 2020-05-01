using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fox.Common.Models;
using Fox.Repository.Models;

namespace Fox.Presentation.Extensions
{
    public static class Converter
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> items) where T: class
        {
            return new ObservableCollection<T>(items);
        }
    }
}
