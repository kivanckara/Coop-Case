using Coop.Entity;
using System;

namespace Coop.Business.Event
{
    public class KindEventArgs : EventArgs
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Count { get; set; }

        public KindEventArgs(string name, Gender gender, int count)
        {
            Name = name;
            Gender = gender;
            Count = count;
        }
    }
}