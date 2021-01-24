
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace lr5
{
    class MyFrac : IComparable<MyFrac>, IMyNumber<MyFrac>
    {
        BigInteger num;
        BigInteger denum;
        public MyFrac(BigInteger num, BigInteger denum)
        {
            BigInteger g1 = num;
            BigInteger g2 = denum;
            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }
            this.num = num / FindMax(g1, g2);
            this.denum = denum / FindMax(g1, g2);
        }


        public int CompareTo(MyFrac ob)
        {
            double r1 = (double)this.num / (double)this.denum;
            double r2 = (double)ob.num / (double)ob.denum;
            return r1.CompareTo(r2);
        }

        public MyFrac(int num, int denum)
        {
            int g1 = num;
            int g2 = denum;

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }
            this.num = num / Math.Max(g1, g2);
            this.denum = denum / Math.Max(g1, g2);
        }
        public MyFrac()
        {
        }
        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.num * that.num, this.denum * that.denum);
        }
        public MyFrac Divide(MyFrac that)
        {
            BigInteger a;
            a = this.denum * that.num;
            if (a == 0)
            {
                throw new System.DivideByZeroException();
            }
            return new MyFrac(this.num * that.denum, a);
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.num * that.denum + this.denum * that.num, this.denum * that.denum);
        }
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.num * that.denum - this.denum * that.num, this.num * that.num);
        }
        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            return f1.Add(f2);
        }
        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return f1.Subtract(f2);
        }
        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return f1.Multiply(f2);
        }
        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return f1.Divide(f2);
        }
        public override string ToString()
        {
            return num + "/" + denum;
        }
        public BigInteger FindMax(BigInteger b1, BigInteger b2)
        {
            if (b1 > b2)
            {
                return b1;
            }
            if (b2 > b1)
            {
                return b2;
            }
            return b1;
        }
    }
}