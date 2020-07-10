using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InteresesBancarios
{
    interface Visitable
    {
        public double accept(Visitor visitor);
    }
}
