using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api
{
    internal class UnitConverter
    {
        /// <summary>
        /// Method to convert inches to points.
        /// </summary>
        /// <param  name="size">Size in inches.</param>
        /// <returns>Size in points.</returns>
        public static double InchesToPoints(double size)
        {
            return size * 72.0;
        }

        /// <summary>
        /// Method to convert millimeters to points.
        /// </summary>
        /// <param  name="size">Size in millimeters.</param>
        /// <returns>Size in points.</returns>
        public static double MillimetersToPoints(double size)
        {
            return size * 2.8346456692913385826771653543307;
        }

        internal static void GetPaperSize(PageSize size, out double smaller, out double larger)
        {
            switch (size)
            {
                case PageSize.Letter:
                    smaller = InchesToPoints(8.5f); larger = InchesToPoints(11f); break;
                case PageSize.Legal:
                    smaller = InchesToPoints(8.5f); larger = InchesToPoints(14f); break;
                case PageSize.Executive:
                    smaller = InchesToPoints(7.25f); larger = InchesToPoints(10.5f); break;
                case PageSize.Tabloid:
                    smaller = InchesToPoints(11f); larger = InchesToPoints(17f); break;
                case PageSize.Envelope10:
                    smaller = InchesToPoints(4.125f); larger = InchesToPoints(9.5f); break;
                case PageSize.EnvelopeMonarch:
                    smaller = InchesToPoints(3.875f); larger = InchesToPoints(7.5f); break;
                case PageSize.Folio:
                    smaller = InchesToPoints(8.5f); larger = InchesToPoints(13f); break;
                case PageSize.Statement:
                    smaller = InchesToPoints(5.5f); larger = InchesToPoints(8.5f); break;
                case PageSize.A4:
                    smaller = MillimetersToPoints(210f); larger = MillimetersToPoints(297f); break;
                case PageSize.A5:
                    smaller = MillimetersToPoints(148f); larger = MillimetersToPoints(210f); break;
                case PageSize.B4:
                    smaller = MillimetersToPoints(250f); larger = MillimetersToPoints(353f); break;
                case PageSize.B5:
                    smaller = MillimetersToPoints(176f); larger = MillimetersToPoints(250f); break;
                case PageSize.A3:
                    smaller = MillimetersToPoints(297f); larger = MillimetersToPoints(420f); break;
                case PageSize.B3:
                    smaller = MillimetersToPoints(353f); larger = MillimetersToPoints(500f); break;
                case PageSize.A6:
                    smaller = MillimetersToPoints(105f); larger = MillimetersToPoints(148f); break;
                case PageSize.B5JIS:
                    smaller = MillimetersToPoints(182f); larger = MillimetersToPoints(257f); break;
                case PageSize.EnvelopeDL:
                    smaller = MillimetersToPoints(110f); larger = MillimetersToPoints(220f); break;
                case PageSize.EnvelopeC5:
                    smaller = MillimetersToPoints(162f); larger = MillimetersToPoints(229f); break;
                case PageSize.EnvelopeB5:
                    smaller = MillimetersToPoints(176f); larger = MillimetersToPoints(250f); break;
                case PageSize.PRC16K:
                    smaller = MillimetersToPoints(146f); larger = MillimetersToPoints(215f); break;
                case PageSize.PRC32K:
                    smaller = MillimetersToPoints(97f); larger = MillimetersToPoints(151f); break;
                case PageSize.Quatro:
                    smaller = MillimetersToPoints(215f); larger = MillimetersToPoints(275f); break;
                case PageSize.DoublePostcard:
                    smaller = MillimetersToPoints(148.0f); larger = MillimetersToPoints(200.0f); break;
                case PageSize.Postcard:
                    smaller = InchesToPoints(3.94f); larger = InchesToPoints(5.83f); break;
                default:
                    smaller = InchesToPoints(8.5f); larger = InchesToPoints(11f); break;
            }
        }
    }
}
