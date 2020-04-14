using System;
using System.Text.RegularExpressions;

namespace LinqQueryKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            FromClause.LowNums();
            FromClause.CompoundFromStudent();
            FromClause.CompoundFromXY();
            WhereClause.PredicatesExpresion();
            WhereClause.PredicatesExpresion();
            SelectClause.SelectSampleInt();
            SelectClause.SelectSampleStudentInfo();
            GroupClause.GroupByChar();
            GroupClause.GroupByBool();
            JoinClause.InnerJoin();
            JoinClause.GroupJoin();
            JoinClause.GroupInnerJoin();
            JoinClause.GroupJoin3();
            JoinClause.LeftOuterJoin();
            JoinClause.LeftOuterJoin2();

        }
    }
}
