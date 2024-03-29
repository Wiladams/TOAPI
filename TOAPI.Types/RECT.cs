using System.Runtime.InteropServices;

namespace TOAPI.Types
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// RECT
    ///
    /// This is the basic geometry of a rectangle for the system
    /// This structure is compatible with the win32 RECT structure,
    /// and can be used in all system calls that require RECT.  In addition
    /// the methods in this class implement the various system provided RECT
    /// manipulation functions: 
    /// CopyRect
    /// EqualRect
    /// InflateRect
    /// IntersectRect
    /// IsRectEmpty
    /// OffsetRect
    /// PtInRect
    /// SetRect
    /// SetRectEmpty
    /// SubtractRect
    /// UnionRect
    /// 
    /// This is also a replacement for the Win32 supplied RECTL function which 
    /// is used when reading graphics metafiles.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT : IEquatable<RECT>
    {
        private Int32 fLeft;
        private Int32 fTop;
        private Int32 fRight;
        private Int32 fBottom;

        public static readonly RECT Empty = new RECT();

        public RECT(int x, int y, int width, int height)
        {
            fLeft = x;
            fTop = y;
            fRight = fLeft + width;
            fBottom = fTop + height;
        }

        public static RECT FromExtents(int x1, int y1, int x2, int y2)
        {
            RECT newRect = FromLTRB(Math.Min(x1, x2), Math.Min(y1, y2),
                Math.Max(x1, x2), Math.Max(y1, y2));

            return newRect;
        }

        public static RECT FromLTRB(int left, int top, int right, int bottom)
        {
            RECT newRect = new RECT(left, top, right-left, bottom-top);
            return newRect;
        }

        // Some properties
        public POINT Location
        {
            get
            {
                return new POINT(X, Y);
            }

            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public SIZE Size
        {
            get
            {
                return new SIZE(Width, Height);
            }

            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public int X
        {
            get
            {
                return fLeft;
            }

            set
            {
                fLeft = value;
            }
        }

        public int Y
        {
            get
            {
                return fTop;
            }

            set
            {
                fTop = value;
            }
        }

        public int Width
        {
            get
            {
                return fRight - fLeft;
            }

            set
            {
                fRight = fLeft + value;
            }
        }

        public int Height
        {
            get
            {
                return fBottom - fTop;
            }

            set
            {
                fBottom = fTop + value;
            }
        }

        public int Left
        {
            get { return fLeft; }
            set { fLeft = value; }
        }

        public int Top
        {
            get
            {
                return fTop;
            }

            set
            {
                fTop = value;
            }
        }

        public int Right
        {
            get
            {
                return fRight;
            }
            set { fRight = value; }
        }

        public int Bottom
        {
            get
            {
                return fBottom;
            }
            set { fBottom = value; }
        }

        /// <summary>
        /// Contains
        /// 
        /// Contains on rectangles is always tricky.
        /// The geometry here favors the upper left edge of a 
        /// pixel.  So, if you have a rectangle with origin
        /// 0,0, and size: 5,5.  The point 5,5 will NOT be Contained
        /// within the rectangle.  As long as everyone believes
        /// in this geometry, everything works out just fine.
        /// </summary>
        /// <param name="x">The X coordinate of the point to be tested.</param>
        /// <param name="y">The Y coordinate of the point to be tested.</param>
        /// <returns></returns>
        public bool Contains(int x, int y)
        {
            return (this.X <= x) && (x < this.Right) &&
                (this.Y <= y) && (y < this.Bottom);
        }

        public bool Contains(POINT pt)
        {
            return Contains(pt.X, pt.Y);
        }

        public bool Contains(RECT rect)
        {
            return (this.X <= rect.X) &&
                ((rect.Right) <= (this.Right)) &&
                (this.Y <= rect.Y) &&
                ((rect.Bottom) <= (this.Bottom));
        }

        /// <summary>
        /// Offset
        /// Displace the rectangle by the specified amount in both the
        /// x, and y axis.
        /// </summary>
        /// <param name="dx">The amount to displace the rectangle in the x axis.</param>
        /// <param name="dy">The amount to displace the rectangle in the y axis.</param>
        public void Offset(int dx, int dy)
        {
            fLeft += dx;
            fTop += dy;
            fRight += dx;
            fBottom += dy;
        }

        public void Offset(SIZE sz)
        {
            Offset(sz.cx, sz.cy);
        }

        public void Resize(int dw, int dh)
        {
            fRight += dw;
            fBottom += dh;
        }

        public void Inset(int dw, int dh)
        {
            Width = Width - dw;
            Height = Height - dh;

            X = X + (dw / 2);
            Y = Y + (dh / 2);
        }


        // Change the shape of this rectangle by intersecting
        // it with another one.
        public void Intersect(RECT rect)
        {
            RECT result = RECT.Intersect(rect, this);
            this.X = result.X;
            this.Y = result.Y;
            this.Width = result.Width;
            this.Height = result.Height;
        }

        // Generic routine to create the intersection between
        // two rectangles.
        //
        public static RECT Intersect(RECT left, RECT right)
        {
            int x1 = Math.Max(left.X, right.X);
            int x2 = Math.Min(left.Right, right.Right);
            int y1 = Math.Max(left.Y, right.Y);
            int y2 = Math.Min(left.Bottom, right.Bottom);

            if (x2 >= x1 && y2 >= y1)
            {
                return new RECT(x1, y1, x2 - x1, y2 - y1);
            }

            return RECT.Empty;
        }

        // Does this rectangle intersect with the one specified?
        public bool IntersectsWith(RECT rect)
        {
            return (rect.X < Right) &&
                (this.X < rect.Right) &&
                (rect.Y < this.Bottom) &&
                (this.Y < rect.Bottom);
        }

        public static RECT Union(RECT left, RECT right)
        {
            int x1 = Math.Min(left.X, right.X);
            int x2 = Math.Max(left.Right, right.Right);
            int y1 = Math.Min(left.Y, right.Y);
            int y2 = Math.Max(left.Bottom, right.Bottom);

            return new RECT(x1, y1, x2 - x1, y2 - y1);
        }

        #region IEquatable<T>
        public bool Equals(RECT rhs)
        {
            return this == rhs;
            //return (rhs.X == this.X) &&
            //    (rhs.Y == this.Y) &&
            //    (rhs.Width == this.Width) &&
            //    (rhs.Height == this.Height);
        }
        #endregion

        // Override from Object
        public override bool Equals(object obj)
        {
            if (!(obj is RECT))
            {
                return false;
            }

            RECT rhs = (RECT)obj;

            return Equals(rhs);
        }

        public static bool operator ==(RECT left, RECT right)
        {
            return (left.X == right.X) &&
                (left.Y == right.Y) &&
                (left.Width == right.Width) &&
                (left.Height == right.Height);
        }

        public static bool operator !=(RECT left, RECT right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            // TODO: fill this part in;
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "<RECT X='" + X.ToString() +
                "' Y='" + Y.ToString() +
                "' Width = '" + Width.ToString() +
                "' Height = '" + Height.ToString() + " />";
        }
    }
}
