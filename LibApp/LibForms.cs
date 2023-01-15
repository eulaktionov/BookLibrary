using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibLib;

namespace LibApp
{
    internal class AuthorsForm : GridForm<Author>
    {
        public AuthorsForm(IdNameList<Author> list)
            : base(list) { }
    }
}
