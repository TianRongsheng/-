using System.Collections.Generic;

namespace DataLib
{
    public class Team
    {
        
        public Team(string name, params int[] years)
        {
            //名字
            Name = name;
            //一组车商获得冠军的年份
            //一级方程赛，每年颁发两个冠军，一个是车手，一个是车商。
            Years = years != null ? new List<int>(years) : new List<int>();
        }
        public string Name { get; }
        public IEnumerable<int> Years { get; }
    }
}