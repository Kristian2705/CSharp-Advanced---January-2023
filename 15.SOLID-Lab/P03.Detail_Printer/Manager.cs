﻿using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
            => $"{base.ToString()}{Environment.NewLine}{string.Join(Environment.NewLine, Documents)}";
    }
}
