using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor
{
    interface JpegMetaAdapter
    {
        void Save();
        void SaveAs(string path);
        void SetComment(String comment);


    }
}
