#nullable enable
using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    static class Program
    {
        static Random rGen = new Random( );
        
        public static double Atan2Fast ( double y, double x )
        {
            double r = 0;
            double vR = 0;
            double oR = 0;
            
            if ( x == 0 && y == 0 ) return 0;
            
            else if ( y < x && y >= -x ) // first condition 
            {
                r = y / x;
                vR =  ( 0.994766 + ( -0.285434 + 0.0760663 * r * r ) * r * r ) * r;
                oR = vR;
            }
            
            else if ( y >= x && y >= -x ) // second condition 
            {
                r = x / y;
                vR =  ( 0.994766 + ( -0.285434 + 0.0760663 * r * r ) * r * r ) * r;
                oR = ( Math.PI / 2 ) - vR;
            }
            
            else if ( y >= x && y < -x ) // third condition
            {
                r = y / x;
                vR =  ( 0.994766 + ( -0.285434 + 0.0760663 * r * r ) * r * r ) * r;
                oR = Math.PI + vR;
            }
            
            else if ( y < x && y < -x ) // fourth condition
            {
                r = x / y;
                vR =  ( 0.994766 + ( -0.285434 + 0.0760663 * r * r ) * r * r ) * r;
                oR = ( -Math.PI / 2 ) - vR;
            }           
            return oR; 
        }
        
        static void Main( )
        {
            WriteLine( );
            WriteLine( "Exact and fast arctangent for random points" ); 
            WriteLine( "   Y-Coord   X-Coord     Exact      Fast     Error " ); 
            
            for ( int i = 0; i < 20; i++ )
            {
                // generates the random numbers 
                double yCoord = rGen.NextDouble( ) * 2 - 1;
                double xCoord = rGen.NextDouble( ) * 2 - 1;
                double fast = Atan2Fast ( yCoord, xCoord );                
                
                // if the angle is greater than pi, subtract 2pi from it 
                if ( fast > Math.PI ) fast = fast - 2 * Math.PI;
                
                double exact = Math.Atan2 ( yCoord, xCoord );
                double error = exact - fast;
                WriteLine ( "{0,10:f4} {1,9:f4} {2,9:f4} {3,9:f4} {4,9:f4}", yCoord, xCoord, exact, fast, error.ToString ( "E0" ) ); 
            }
            WriteLine( );
        }
    }
}
