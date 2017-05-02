using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class StrafnieFunkcii
    {
        private double x1;
        private double x2;
        private double h;
        private double extremum;
        private Direction direction;

        private enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        public StrafnieFunkcii()
        {
            direction = Direction.Right;
        }


        public List<ExtremumCoordinates> extremumFunction(double x1_begin, double x2_begin, double h_begin, double e)
        {
            List<ExtremumCoordinates> extremumCoordinatesList = new List<ExtremumCoordinates>();

            x1 = x1_begin;
            x2 = x2_begin;

            h = h_begin;
            extremum = f(x1, x2);

            do
            {
                double extremumOld = extremum;


                basisPointNext();

                if (extremumOld.Equals(extremum))
                {
                    h = h / 10;
                }

                else
                {
                    x1 = Math.Round(x1, 3);
                    x2 = Math.Round(x2, 3);
                    extremum = Math.Round(extremum, 3);
                    ExtremumCoordinates basisPoint = new ExtremumCoordinates();
                    basisPoint.Add(x1, x2, extremum);
                    extremumCoordinatesList.Add(basisPoint);

                }
            } while (h > e);
            return extremumCoordinatesList;
        }



        private void basisPointNext()
        {
            if (minFunctionValue(direction)) return;
            for (Direction dir = Direction.Right; dir <= Direction.Down; dir++)
            {
                if (!dir.Equals(direction))
                {
                    if (minFunctionValue(dir)) return;
                }
            }

        }

        private bool minFunctionValue(Direction direction)
        {
            double x1WithStep = x1, x2WithStep = x2;
            if (Direction.Right.Equals(direction))
            {
                x1WithStep -= h;
            }
            else if (Direction.Left.Equals(direction))
            {
                x1WithStep += h;
            }
            else if (Direction.Up.Equals(direction))
            {
                x2WithStep += h;
            }
            else if (Direction.Down.Equals(direction))
            {
                x2WithStep -= h;
            }

            if (borderOn(x1WithStep, x2WithStep))
            {
                double basisPointNewFunction = f(x1WithStep, x2WithStep);
                if (basisPointNewFunction < extremum)
                {
                    x1 = x1WithStep;
                    x2 = x2WithStep;
                    extremum = basisPointNewFunction;
                    this.direction = direction;
                    return true;
                }
            }
            return false;
        }


        private bool borderOn(double x1, double x2)
        {
            double first_border = 2 * x1 + 3 * x2;
            if (first_border >= 6 && x1 >= 0 && x2 >= 0 && x1 + 4 * x2 >= 5)
            {
                return true;
            }
            return false;
        }

        private double f(double x1, double x2)
        {
            int r;
            r = 3;
            return (0.5 * Math.Pow(x1, 2) + 0.5 * Math.Pow(x2, 2) - x1 - 2 * x2 + 5) + r * g(x1, x2);

        }

        private double g(double x1, double x2)
        {
            double g = 0;
            double[] border = {2 * x1 + 3 * x2+6,
                                  x1,
                                  x2,
                                  x1+4*x2+5};
            for (int m = 0; m < 4; m++)
            {
                if (border[m] >= 0)
                {
                    g += 0;
                }
                else
                {
                    g += Math.Pow(border[m], 2);
                }
            }
            return g;
        }

    }
}

