using System.Data;
using System;

namespace FirstProject.Models
{
    public class Medicine
    {
        public string Name { get; set; }
        public string Form  { get; set; }
        public int Doza  { get; set; }
        public DataSetDateTime dataTimeOffSet  { get; set; }
        public int YaroqlilikMuddati { get; set; }
        public string IshlabChiqruvchi { get; set; }

    }
}
